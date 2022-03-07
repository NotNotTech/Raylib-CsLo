// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class NativeClassGenerator
{
    int indent;
    List<RaylibFunction> functions;
    StringBuilder fileContents = new();

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

    int test;
    void GenFunction(RaylibFunction func)
    {
        Line("// " + test + " " + func.Name);
        Line("[DllImport(\"raylib\", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]");
        Line($"public static extern void {func.Name}();");
        test++;
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

    void Blank()
    {
        fileContents.AppendLine();
    }

    void Line(string v)
    {
        for (int i = 0; i < indent; i++)
        {
            fileContents.Append("    ");
        }
        fileContents.AppendLine(v);
    }

    public void Output()
    {
        File.WriteAllText(CodegenSettings.OutputFolder + "RaylibNative.cs", fileContents.ToString());
    }
}
