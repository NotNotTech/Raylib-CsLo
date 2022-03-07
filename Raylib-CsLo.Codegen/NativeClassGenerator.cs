// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Collections.Generic;
using System.IO;

public class NativeClassGenerator : ClassGenerator
{
    bool debug = true;

    List<RaylibFunction> functions;

    const string ClassName = "RaylibN";

    public static readonly string[] Usings =
    {
        "System.Runtime.InteropServices",
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

        string parameters = GenParameterDefinitions(func);
        Line($"public static extern {func.Return.TypeCs} {func.Name}({parameters});");
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
