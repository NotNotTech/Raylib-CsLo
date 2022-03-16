// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;

public class NativeClassGenerator : ClassGenerator
{
    List<RaylibFunction> functions;
    string fileName;
    public static readonly string[] Usings =
    {
        "System.Runtime.InteropServices",
        "System.Numerics",
    };

    public NativeClassGenerator(List<RaylibFunction> functions, string fileName)
    {
        this.functions = functions;
        this.fileName = fileName;
        Debug = false;
    }

    public void Generate()
    {
        Line(CodegenSettings.CodeHeader);
        Blank();

        Line($"#pragma warning disable");
        Blank();

        Line($"namespace {CodegenSettings.NamespaceName};");

        UsingsList();

        Line($"public unsafe partial class {fileName}");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                GenFunction(func);
            }
        }
        EndBlock();
        Blank();
        Line($"#pragma warning restore");

        string file = CodegenSettings.OutputFolder + fileName + "/" + fileName + ".cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());
    }

    void GenFunction(RaylibFunction func)
    {
        DocumentationBlock(func.Description);

        Line($"[DllImport(\"{fileName.ToLowerInvariant()}\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]");

        string returnType = GenReturnType(func);
        string parameters = GenParameterDefinitions(func);
        Line($"public static extern {returnType} {func.Name}({parameters});");
        Blank();
    }

    static string GenReturnType(RaylibFunction func)
    {
        return TypeConverter.FromCToUnsafeCs(func.Return);
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
                if (parameter.Type == "params object[]")
                {
                    parameters = parameters.Remove(parameters.LastIndexOf(","), 2);
                    continue;
                }

                DebugLine(parameter.Type + " => " + TypeConverter.FromCToUnsafeCs(parameter.Type));
                string type = TypeConverter.FromCToUnsafeCs(parameter.Type);
                string name = parameter.Name;

                if (parameter.Type == "...")
                {
                    name = "";
                }

                parameters += $"{type} {name}";

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
}
