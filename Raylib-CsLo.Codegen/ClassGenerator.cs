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
    // const string SByteToStringHelper = "Helpers.Utf8ToString";

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

        Line("public unsafe partial class RaylibS");

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

        Line($"public {func.ReturnType} {func.Name}({parameters})");
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
            foreach (KeyValuePair<string, string> parameter in func.Parameters)
            {
                parameters += $"{parameter.Value} {parameter.Key}";

                if (index < func.Parameters.Count - 1)
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
        if (func.Parameters != null)
        {
            foreach (KeyValuePair<string, string> parameter in func.Parameters)
            {
                string nativeParameterName = HandleParameter(parameter.Key, parameter.Value);
                parameters += $"{nativeParameterName}";

                if (index < func.Parameters.Count - 1)
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
        if (func.ReturnType != func.ReturnTypeC)
        {
            returnStatement += $"({func.ReturnType})";
        }

        return returnStatement;
    }

    string HandleParameter(string name, string type)
    {
        switch (type)
        {
            case "string":
                Line($"using var {name + "_"} = {name}.MarshalUtf8();");
                name += "_" + ".AsPtr()";
                break;

            default:
                // Console.WriteLine($"Unhandled Parameter: {type} {name}");
                break;
        }
        return name;
    }

    static string HandleReturn(RaylibFunction func, string paramaters, string returnStatement)
    {
        if (true)
        {
            returnStatement += CastReturn(func);
        }

        returnStatement += $"Raylib.{func.Name}({paramaters});";
        return returnStatement;
    }

    void Usings()
    {
        Blank();
        foreach (string import in usings)
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
