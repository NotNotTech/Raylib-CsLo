// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;
using System.Text;

public class ClassGenerator
{
    int indent;
    List<RaylibFunction> functions;
    StringBuilder fileContents = new();

    public ClassGenerator(List<RaylibFunction> functions)
    {
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

        Line($"public static {func.Return.TypeCs} {func.Name}({parameters})");
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
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                parameters += $"{parameter.TypeCs} {parameter.Name}";

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
        if (func.Return.TypeC != "void")
        {
            returnStatement += "return ";
        }

        returnStatement += HandleReturn(func, paramaters);

        Line(returnStatement);

        Debug("return " + func.Return.TypeC + " => " + func.Return.TypeCs);
    }

    string GenParameters(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                string parameterVariableName = HandleParameter(parameter.Name, parameter.TypeCs, parameter.TypeC);
                parameters += HandleNativeCallParameter(parameterVariableName);

                if (index < func.Parameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    // Raylib.*(Theses, Params, Here);
    static string HandleNativeCallParameter(string nativeParameterName)
    {

        return $"{nativeParameterName}";
    }

    static string CastReturn(RaylibFunction func)
    {
        string returnStatement = "";
        if (func.Return.TypeCs != func.Return.TypeC)
        {
            returnStatement += $"({func.Return.TypeCs})";
        }

        return returnStatement;
    }

    string HandleParameter(string parameterName, string typeCs, string typeC)
    {
        string localVariable = parameterName;
        const string localVariableSuffix = "Local";

        Debug($"{typeC} => {typeCs}");

        string call;
        switch (typeCs)
        {
            case "string":
                Line($"using var {localVariable + localVariableSuffix} = {localVariable}.MarshalUtf8();");
                localVariable += localVariableSuffix;
                localVariable += ".AsPtr()";
                break;

            case "IntPtr":
                Line($"var {localVariable + localVariableSuffix} = (void*){localVariable};");
                localVariable += localVariableSuffix;
                break;

            case "byte[]":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {localVariable + localVariableSuffix} = {call};");
                localVariable += localVariableSuffix;
                break;

            case "Rectangle[]":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {parameterName + localVariableSuffix} = {call};");
                localVariable = "&" + parameterName;
                localVariable += localVariableSuffix;
                break;

            default:
                break;
        }

        switch (typeC)
        {
            case "Camera*":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {parameterName + localVariableSuffix} = {call};");
                localVariable = "&" + parameterName;
                localVariable += localVariableSuffix;
                break;

            default:
                break;
        }

        return localVariable;
    }

    static string HandleReturn(RaylibFunction func, string paramaters)
    {
        string nativeCall = $"Raylib.{func.Name}({paramaters})";

        string returnStatement = "";

        if (func.Return.TypeCs == "string" && func.Return.TypeC.EndsWith("char *"))
        {
            returnStatement += Call(CodegenSettings.Utf8ToStringFunction, nativeCall);
        }
        else if (func.Return.TypeCs.EndsWith("[]") && func.Return.TypeC.EndsWith("*"))
        {
            returnStatement += Call(CodegenSettings.PrtToArrayFunction, nativeCall);
        }
        else
        {
            returnStatement += CastReturn(func);
            returnStatement += nativeCall;
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

    void Debug(string v)
    {
        _ = v;
        _ = indent;
        // Line($"/*|  {v}  |*/");
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibSafe.cs", fileContents.ToString());
    }
}
