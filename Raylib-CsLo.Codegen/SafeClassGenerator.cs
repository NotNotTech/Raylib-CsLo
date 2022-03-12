// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Collections.Generic;
using System.IO;

public class SafeClassGenerator : ClassGenerator
{
    const string ClassName = "RaylibS";

    public static readonly string[] Usings =
    {
        "System.Numerics",
        "Microsoft.Toolkit.HighPerformance.Buffers",
        "Raylib_CsLo.InternalHelpers",
    };

    List<RaylibFunction> functions;

    public SafeClassGenerator(List<RaylibFunction> functions)
    {
        this.functions = functions;
        Debug = true;
    }

    public void Generate()
    {
        Line(CodegenSettings.CodeHeader);
        Blank();

        Line($"#pragma warning disable");
        Blank();

        Line($"namespace {CodegenSettings.NamespaceName};");

        GenUsings();

        Line($"public unsafe partial class {ClassName}");

        StartBlock();
        foreach (RaylibFunction func in functions)
        {
            if (!func.Manual)
            {
                GenFunction(func);
            }
            else
            {
                Commented = true;
                GenFunction(func);
                Commented = false;
            }
        }
        EndBlock();

        Blank();
        Line($"#pragma warning restore");
    }

    /// <summary>
    /// Gen whole function docs, definition, params and implementation
    /// </summary>
    void GenFunction(RaylibFunction func)
    {
        DocumentationBlock(func);

        string paramters = GenDefinitionParameters(func);
        string returnType = TypeConverter.FromCToSafeCs(func.Return);

        Line($"public static {returnType} {func.Name}({paramters})");
        StartBlock();
        {
            GenFunctionContents(func);
        }
        EndBlock();

        Blank();
    }

    /// <summary>
    /// public static void InitWindow([HERE])
    /// </summary>
    string GenDefinitionParameters(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                string paramType = TypeConverter.FromCToSafeCs(parameter.Type);
                if (Debug)
                {
                    parameters += $"/* {parameter.Type} */ ";
                }
                parameters += $"{paramType} {parameter.Name}";

                if (index < func.Parameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    /// <summary>
    /// { [HERE] }
    /// </summary>
    void GenFunctionContents(RaylibFunction func)
    {
        // Call Parameters
        string parameters = "";
        if (func.Parameters != null)
        {
            for (int i = 0; i < func.Parameters.Count; i++)
            {
                RaylibParameter parameter = func.Parameters[i];
                parameters += GenParameter(func, parameter, i);
            }
        }

        string unsafeCall = $"Raylib.{func.Name}({parameters})";

        DebugLine($"return {TypeConverter.FromCToUnsafeCs(func.Return)} => {TypeConverter.FromCToSafeCs(func.Return)}");

        string line = "";

        if (func.Return != "void")
        {
            line += "return ";
        }

        string cast = CastToReturn(func.Return);

        line += ConvertReturnUsingHelper(func, cast + unsafeCall);

        // line += unsafeCall;
        line += ";";

        Line(line);
    }

    /// <summary>
    /// return ([HERE])Raylib.Foo();
    /// </summary>
    static string CastToReturn(string type)
    {
        string unsafeType = TypeConverter.FromCToUnsafeCs(type);

        return unsafeType switch
        {
            "void*" => "(IntPtr)",
            _ => "",
        };
    }

    /// <summary>
    /// return Helpers.[HERE](Raylib.Foo());
    /// </summary>
    static string ConvertReturnUsingHelper(RaylibFunction func, string unsafeCall)
    {
        string unsafeType = TypeConverter.FromCToUnsafeCs(func.Return);
        string helper;

        switch (unsafeType)
        {
            case "sbyte*":
                helper = CodegenSettings.Utf8ToStringFunction;
                break;

            case "byte*":
                helper = CodegenSettings.PrtToArrayFunction;
                break;

            case "Color*":
                helper = CodegenSettings.PrtToArrayFunction;
                break;

            default:
                return unsafeCall;
        }

        return Call(helper, unsafeCall);
    }

    /// <summary>
    /// Raylib.*([HERE])
    /// </summary>
    string GenParameter(RaylibFunction func, RaylibParameter parameter, int i)
    {
        string cast = "";

        DebugLine($"{TypeConverter.FromCToUnsafeCs(parameter.Type)} => {TypeConverter.FromCToSafeCs(parameter.Type)}");

        string parameters = cast + GenParameterConversion(parameter);

        // var arg __arglist handling
        if (parameter.Type == "...")
        {
            parameters = "__arglist(" + parameters + ")";
        }

        if (i < func.Parameters.Count - 1)
        {
            parameters += ", ";
        }

        return parameters;
    }

    /// <summary>
    /// Convert parameters to unsafe as needed to pass to unsafe call
    /// </summary>
    string GenParameterConversion(RaylibParameter parameter)
    {
        const string localVariableSuffix = "_";

        string localVariable = parameter.Name;
        string call;

        switch (TypeConverter.FromCToSafeCs(parameter.Type))
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

            case "Vector2[]":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {localVariable + localVariableSuffix} = {call};");
                localVariable += localVariableSuffix;
                break;

            case "byte[]":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {localVariable + localVariableSuffix} = {call};");
                localVariable += localVariableSuffix;
                break;

            case "Color[]":
                call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
                Line($"var {localVariable + localVariableSuffix} = {call};");
                localVariable += localVariableSuffix;
                break;

            // case "Rectangle[]":
            //     call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
            //     Line($"var {parameter.Name + localVariableSuffix} = {call};");
            //     localVariable = "&" + parameter.Name;
            //     localVariable += localVariableSuffix;
            //     break;

            // case "Camera*":
            //     call = Call(CodegenSettings.ArrayToPtrFunction, localVariable);
            //     Line($"var {parameter.Name + localVariableSuffix} = {call};");
            //     localVariable = "&" + parameter.Name;
            //     localVariable += localVariableSuffix;
            //     break;

            default:
                break;
        }

        return localVariable;
    }

    // Gen class usings at top
    void GenUsings()
    {
        Blank();
        foreach (string import in Usings)
        {
            Line("using " + import + ';');
        }
        Blank();
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibSafe.cs", fileContents.ToString());
    }
}
