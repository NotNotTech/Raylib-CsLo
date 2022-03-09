// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.IO;

public class NativeClassGenerator : ClassGenerator
{
    bool debug;

    List<RaylibFunction> functions;

    const string ClassName = "Raylib";

    public static readonly string[] Usings =
    {
        "System.Runtime.InteropServices",
        "System.Numerics",
    };

    public NativeClassGenerator(List<RaylibFunction> functions)
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
                GenFunction(func);
            }
        }
        EndBlock();
        Line($"#pragma warning restore");
    }

    void GenFunction(RaylibFunction func)
    {
        Line("[DllImport(\"raylib\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]");

        string returnType = GenReturnType(func);
        string parameters = GenParameterDefinitions(func);
        Line($"public static extern {returnType} {func.Name}({parameters});");
        Blank();
    }

    static string GenReturnType(RaylibFunction func)
    {
        return TypeConverter.CToCsNativeTypes(func.Return.TypeC);
    }

    // (...);
    string GenParameterDefinitions(RaylibFunction func)
    {
        string parameters = "";

        int index = 0;
        if (func.Parameters != null)
        {
            foreach (RaylibParameter parameter in func.Parameters)
            {
                if (parameter.TypeC == "params object[]")
                {
                    parameters = parameters.Remove(parameters.LastIndexOf(","), 2);
                    continue;
                }

                Debug(parameter.TypeC + " => " + parameter.TypeCs);
                string resultC = TypeConverter.CToCsNativeTypes(parameter.TypeC);

                parameters += $"{resultC} {parameter.Name}";

                if (index < func.Parameters.Count - 1)
                {
                    parameters += ", ";
                }

                index++;
            }
        }

        return parameters;
    }

    public void UsingsList()
    {
        Blank();
        foreach (string import in Usings)
        {
            Line("using " + import + ';');
        }
        Blank();
    }

    public void Debug(string v)
    {
        if (debug)
        {
            Line($"/*|  {v}  |*/");
        }
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibNative.cs", fileContents.ToString());
    }
}
