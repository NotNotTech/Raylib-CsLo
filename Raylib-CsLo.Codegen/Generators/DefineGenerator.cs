// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class DefineGenerator : BaseGenerator
{
    List<RaylibDefine> defines;
    readonly JsonDocument document;
    readonly string fileName;

    public DefineGenerator(JsonDocument document, string fileName)
    {
        this.document = document;
        this.fileName = fileName;
        Debug = false;

        Parse();
    }

    public void Generate()
    {
        Line(CodegenSettings.CodeHeader);
        Blank();

        Line($"#pragma warning disable");
        Blank();

        Line($"namespace {CodegenSettings.NamespaceName};");


        Line($"public unsafe partial class {fileName}");

        StartBlock();
        {
            foreach (RaylibDefine define in defines)
            {

                switch (define.Type)
                {
                    case "STRING":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        Line($"public static readonly string {define.Name} = \"{define.Value}\";");
                        break;

                    case "FLOAT":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        Line($"public static readonly float {define.Name} = {define.Value}f;");
                        break;

                    case "DOUBLE":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        Line($"public static readonly double {define.Name} = {define.Value};");
                        break;

                    case "INT":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        Line($"public static readonly int {define.Name} = {define.Value};");
                        break;

                    case "LONG":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        Line($"public static readonly long {define.Name} = {define.Value};");
                        break;

                    case "COLOR":
                        if (define.Description != "")
                        {
                            DocumentationBlock(define.Description);
                        }
                        string val = define.Value.Replace("CLITERAL", "new").Replace("(", " ").Replace(")", "").Replace("{ ", "(").Replace(" }", ")");
                        Line($"public static readonly Color {define.Name} = {val};");
                        break;

                    case "GUARD":
                    case "MAKRO":
                    case "UNKNOWN":
                    default:
                        Line($"// {define.Type} {define.Name} {define.Value}");
                        break;
                }

                Blank();
            }
        }
        EndBlock();
        Blank();
        Line($"#pragma warning restore");

        string file = CodegenSettings.OutputFolder + fileName + "/" + fileName + "D.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());
    }

    public void Parse()
    {
        defines = new();

        foreach (JsonElement element in document.RootElement.GetProperty("defines").EnumerateArray())
        {
            RaylibDefine define = new();
            define.Name = element.GetProperty("name").ToString();
            define.Value = element.GetProperty("value").ToString();
            define.Type = element.GetProperty("type").ToString();
            define.Description = element.GetProperty("description").ToString();

            defines.Add(define);
        }
    }
}
