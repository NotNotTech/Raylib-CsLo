// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;

public class SafeClassGenerator : ClassGenerator
{
    bool debug;

    List<RaylibFunction> functions;

    const string ClassName = "RaylibS";

    public static readonly string[] Usings =
    {
        "System.Numerics",
        "Microsoft.Toolkit.HighPerformance.Buffers",
        "Raylib_CsLo.InternalHelpers",
    };

    public SafeClassGenerator(List<RaylibFunction> functions)
    {
        this.functions = functions;
    }

    public void Generate()
    {
        Line($"#pragma warning disable");
        Line($"namespace {CodegenSettings.NamespaceName};");

        UsingsList();

        Line($"public unsafe partial class {ClassName}");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                if (!func.IsManual)
                {
                    GenFunction(func);
                }
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
                parameters += HandleParameter(parameter);

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
        if (func.Return.TypeCs != func.Return.TypeC)
        {
            returnStatement += $"({func.Return.TypeCs})";
        }

        return returnStatement;
    }

    string HandleParameter(RaylibParameter parameter)
    {
        string localVariable = parameter.Name;
        const string localVariableSuffix = "Local";

        Debug($"{parameter.TypeC} => {parameter.TypeCs}");

        string call;
        switch (parameter.TypeCs)
        {
            // case "string":
            //     Line($"using var {localVariable + localVariableSuffix} = {localVariable}.MarshalUtf8();");
            //     localVariable += localVariableSuffix;
            //     localVariable += ".AsPtr()";
            //     break;

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
                Line($"var {parameter.Name + localVariableSuffix} = {call};");
                localVariable = "&" + parameter.Name;
                localVariable += localVariableSuffix;
                break;

            default:
                break;
        }

        switch (parameter.TypeC)
        {
            case "Camera*":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {parameter.Name + localVariableSuffix} = {call};");
                localVariable = "&" + parameter.Name;
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

        if (func.Return.TypeCs == "string" && func.Return.TypeC.EndsWith("char*"))
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

    void UsingsList()
    {
        Blank();
        foreach (string import in Usings)
        {
            Line("using " + import + ';');
        }
        Blank();
    }

    void Debug(string v)
    {
        if (debug)
        {
            Line($"/*|  {v}  |*/");
        }
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibSafe.cs", fileContents.ToString());
    }
}
