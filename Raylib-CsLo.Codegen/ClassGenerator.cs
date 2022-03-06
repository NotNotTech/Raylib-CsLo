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
    const string NamespaceName = "Raylib_CsLo";
    static string[] usings =
    {
        "System.Numerics",
        "Microsoft.Toolkit.HighPerformance.Buffers",
        "Raylib_CsLo.InternalHelpers",
    };


    readonly string module;
    int indent;
    List<RaylibFunction> functions;
    StringBuilder fileContents = new();

    public ClassGenerator(RaylibModule module, List<RaylibFunction> functions)
    {
        this.module = Enum.GetName(typeof(RaylibModule), module);
        Console.WriteLine(this.module);
        this.functions = functions;
    }

    public void Generate()
    {
        Line($"#pragma warning disable");
        Line($"namespace {NamespaceName};");

        Usings();

        Line("public unsafe partial class RaylibS");

        StartBlock();
        {
            foreach (RaylibFunction func in functions)
            {
                DocumentationBlock(func);

                string paramters = "";

                int index = 0;
                if (func.ParamatersC != null)
                {
                    foreach (KeyValuePair<string, string> parameter in func.Paramaters)
                    {
                        paramters += $"{parameter.Value} {parameter.Key}";

                        if (index < func.Paramaters.Count - 1)
                        {
                            paramters += ", ";
                        }

                        index++;
                    }
                }

                Line($"public {func.ReturnType} {func.Name}({paramters})");
                StartBlock();
                {
                    GenerateFunctionContents(func);
                }
                EndBlock();
                Blank();
            }
        }
        EndBlock();
        Line($"#pragma warning restore");
    }

    void DocumentationBlock(RaylibFunction func)
    {
        Line($"/// <summary>");
        Line($"/// {func.Description}");
        Line($"/// </summary>");
    }

    void GenerateFunctionContents(RaylibFunction func)
    {
        string paramters = "";

        int index = 0;
        if (func.Paramaters != null)
        {
            foreach (KeyValuePair<string, string> parameter in func.Paramaters)
            {
                string nativeParameterName = HandleParamter(parameter.Key, parameter.Value);
                paramters += $"{nativeParameterName}";

                if (index < func.Paramaters.Count - 1)
                {
                    paramters += ", ";
                }

                index++;
            }
        }

        string returnStatement = "";
        if (func.ReturnTypeC != "void")
        {
            returnStatement += "return ";
        }
        returnStatement += CastReturn(func);

        returnStatement += $"Raylib.{func.Name}({paramters});";

        Line(returnStatement);
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

    string HandleParamter(string name, string type)
    {
        switch (type)
        {
            case "string":
                Line($"using var {name + "_"} = {name}.MarshalUtf8();");
                name += "_" + ".AsPtr()";
                break;

            default:
                Console.WriteLine($"Unhandled Paramter: {type} {name}");
                break;
        }
        return name;
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
        File.WriteAllText(Program.OutputFolder + module + ".cs", fileContents.ToString());
    }
}
