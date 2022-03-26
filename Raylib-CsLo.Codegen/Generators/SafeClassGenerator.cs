// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Raylib_CsLo.Codegen.Parsers;

public class SafeClassGenerator : BaseGenerator
{
    List<RaylibFunction> functions;
    string fileName;

    int numClosingBrackets;

    public SafeClassGenerator(JsonDocument document, string fileName)
    {
        this.fileName = fileName;
        Debug = false;

        functions = FunctionParser.Parse(document);
    }

    public void Generate()
    {
        Line(Settings.CodeHeader);
        Blank();

        Line($"#pragma warning disable");
        Blank();

        Line($"namespace {Settings.NamespaceName};");
        Blank();

        Line($"public unsafe partial class {fileName}S");

        StartBlock();
        foreach (RaylibFunction func in functions)
        {
            if (Settings.ParamTypeEnumOverride.TryGetValue(func.Name, out (string type, string name) value))
            {
                for (int i = 0; i < func.Parameters.Count; i++)
                {
                    if (func.Parameters[i].Name == value.name)
                    {
                        func.Parameters[i].Type = value.type;
                    }
                }
            }

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

        string file = Settings.OutputFolder + fileName + "/" + fileName + "S.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());
    }

    /// <summary>
    /// Gen whole function docs, definition, params and implementation
    /// </summary>
    void GenFunction(RaylibFunction func)
    {
        DocumentationBlock(func.Description);

        string paramters = GenDefinitionParameters(func);
        string returnType = Converter.FromCToSafeCs(func.Return);

        Line($"public static {returnType} {func.Name}({paramters})");
        StartBlock();
        {
            GenFunctionContents(func);

            for (int i = 0; i < numClosingBrackets; i++)
            {
                EndBlock();
            }
            numClosingBrackets = 0;
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
                string paramType = Converter.FromCToSafeCs(parameter.Type);
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

        string unsafeCall = $"{fileName}.{func.Name}({parameters})";

        DebugLine($"return {Converter.FromCToUnsafeCs(func.Return)} => {Converter.FromCToSafeCs(func.Return)}");

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
        string unsafeType = Converter.FromCToUnsafeCs(type);

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
        string unsafeType = Converter.FromCToUnsafeCs(func.Return);
        string helper;

        switch (unsafeType)
        {
            case "sbyte*":
            helper = Settings.Utf8ToStringFunction;
            break;

            case "byte*":
            helper = Settings.PrtToArrayFunction;
            break;

            case "Color*":
            helper = Settings.PrtToArrayFunction;
            break;

            default:
            return unsafeCall;
        }

        RaylibParameter param = func.Parameters?.Find((p) => p.Name.ToLowerInvariant().Contains("length"));

        if (param != null && helper == Settings.PrtToArrayFunction)
        {
            return Call(helper, unsafeCall + ", " + param.Name);
        }
        else
        {
            return Call(helper, unsafeCall);
        }
    }

    /// <summary>
    /// Raylib.*([HERE])
    /// </summary>
    string GenParameter(RaylibFunction func, RaylibParameter parameter, int i)
    {
        DebugLine($"{Converter.FromCToUnsafeCs(parameter.Type)} => {Converter.FromCToSafeCs(parameter.Type)}");

        string cast = CastEnumParams(parameter.Type);
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
    /// Cast any enum parameters to ints
    /// </summary>
    static string CastEnumParams(string type)
    {
        if (Settings.EnumCastType.TryGetValue(type, out string value))
        {
            return value;
        }
        else
        {
            return "";
        }
    }

    /// <summary>
    /// Convert parameters to unsafe as needed to pass to unsafe call
    /// </summary>
    string GenParameterConversion(RaylibParameter parameter)
    {
        const string localVariableSuffix = "_";

        string localVariable = parameter.Name;

        if (Converter.FromCToSafeCs(parameter.Type).Contains("ref ") && parameter.Type.EndsWith('*'))
        {
            Line($"fixed ({Converter.FromCToUnsafeCs(parameter.Type)} {localVariable + localVariableSuffix} = &{localVariable})");
            StartBlock();
            localVariable += localVariableSuffix;
            numClosingBrackets++;
        }
        else
        {
            switch (parameter.Type)
            {
                case "const char*":
                case "char*":
                Line($"using var {localVariable + localVariableSuffix} = {localVariable}.MarshalUtf8();");
                localVariable += localVariableSuffix;
                localVariable += ".AsPtr()";
                break;

                case "const void*":
                case "void*":
                Line($"var {localVariable + localVariableSuffix} = (void*){localVariable};");
                localVariable += localVariableSuffix;
                break;

                case "IntPtr":
                Line($"var {localVariable + localVariableSuffix} = (int*){localVariable};");
                localVariable += localVariableSuffix;
                break;

                case "unsigned char*":
                case "const unsigned char*":
                Line($"fixed ({Converter.FromCToUnsafeCs(parameter.Type)} {localVariable + localVariableSuffix} = {localVariable})");
                StartBlock();
                localVariable += localVariableSuffix;
                numClosingBrackets++;
                break;

                case "const Matrix*":
                case "Matrix*":
                case "Vector2*":
                case "Color*":
                Line($"fixed ({Converter.FromCToUnsafeCs(parameter.Type)} {localVariable + localVariableSuffix} = {localVariable})");
                StartBlock();
                localVariable += localVariableSuffix;
                numClosingBrackets++;
                break;

                case "Camera*":
                localVariable = "&" + parameter.Name;
                break;

                default:
                break;
            }
        }
        return localVariable;
    }
}
