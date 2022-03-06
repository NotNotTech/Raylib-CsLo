// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class ClassGenerator
{
    readonly string module;
    int indent;
    List<RaylibFunction> functions;
    StringBuilder fileContents = new();

    public ClassGenerator(RaylibModule module, List<RaylibFunction> functions)
    {
        this.module = Enum.GetName(typeof(RaylibModule), module);
        this.functions = functions;
    }

    public void Generate()
    {
        Line($"#pragma warning disable");
        Line($"namespace {CodegenSettings.NamespaceName};");

        Usings();

        Line($"public unsafe partial class {CodegenSettings.ClassName}");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                GenFunction(func);
            }
        }
        EndBlock();
        Line($"#pragma warning restore");
    }

    void GenFunction(RaylibFunction func)
    {
        DocumentationBlock(func);

        string parameters = GenParameterDefinitions(func);

        Line($"public {func.CsReturnType} {func.Name}({parameters})");
        StartBlock();
        {
            GenFunctionContents(func);
        }
        EndBlock();
        Blank();
    }

    static string GenParameterDefinitions(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.ParametersC != null)
        {
            foreach ((string name, string type) in func.CsParameters)
            {
                parameters += $"{type} {name}";

                if (index < func.CsParameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    void DocumentationBlock(RaylibFunction func)
    {
        Line($"/// <summary>");
        Line($"/// {func.Description}");
        Line($"/// </summary>");
    }

    void GenFunctionContents(RaylibFunction func)
    {
        string paramaters = GenParameters(func);

        string returnStatement = "";
        if (func.ReturnTypeC != "void")
        {
            returnStatement += "return ";
        }

        returnStatement = HandleReturn(func, paramaters, returnStatement);

        Line(returnStatement);
    }

    string GenParameters(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.CsParameters != null)
        {
            foreach ((string name, string type) in func.CsParameters)
            {
                string nativeParameterName = HandleParameter(type, name);
                parameters += $"{nativeParameterName}";

                if (index < func.CsParameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    static string CastReturn(RaylibFunction func)
    {
        string returnStatement = "";
        if (func.CsReturnType != func.ReturnTypeC)
        {
            returnStatement += $"({func.CsReturnType})";
        }

        return returnStatement;
    }

    string HandleParameter(string type, string name)
    {
        switch (type)
        {
            case "string":
                Line($"using var {name + "_"} = {name}.MarshalUtf8();");
                name += "_";
                name += ".AsPtr()";
                break;

            case "IntPtr":
                Line($"var {name + "_"} = (void*){name};");
                name += "_";
                break;


            default:
                // Console.WriteLine($"Unhandled Parameter: {type} {name}");
                break;
        }
        return name;
    }

    /*TODO
            fixed (byte* variable = fileData)
            {
                return Raylib.LoadWaveFromMemory(fileType_.AsPtr(), variable, dataSize);
            }
    */
    static string HandleReturn(RaylibFunction func, string paramaters, string returnStatement)
    {
        string nativeCall = $"Raylib.{func.Name}({paramaters})";

        switch (func.CsReturnType)
        {
            case string t when t == "string" && func.ReturnTypeC == "const char *":
                returnStatement += Call(CodegenSettings.Utf8ToString, nativeCall);
                break;

            case string t when t == "float[]" && func.ReturnTypeC == "float *":
                returnStatement += Call(CodegenSettings.PrtToArray, nativeCall);
                break;

            default:
                returnStatement += CastReturn(func);
                returnStatement += nativeCall;
                break;
        }

        returnStatement += ";";

        return returnStatement;
    }

    void Usings()
    {
        Blank();
        foreach (string import in CodegenSettings.Usings)
        {
            Line("using " + import + ';');
        }
        Blank();
    }

    void StartBlock()
    {
        Line("{");
        indent++;
    }

    void EndBlock()
    {
        indent--;
        Line("}");
    }

    static string Call(string functionName, string contents)
    {
        return $"{functionName}({contents})";
    }

    void Line(string v)
    {
        for (int i = 0; i < indent; i++)
        {
            fileContents.Append("    ");
        }
        fileContents.AppendLine(v);
    }

    void Blank()
    {
        fileContents.AppendLine();
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + module + ".cs", fileContents.ToString());
    }
}
