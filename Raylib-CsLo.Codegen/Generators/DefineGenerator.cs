// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        Line(Settings.CodeHeader);

        Blank();

        Line($"#pragma warning disable");

        Blank();

        Line($"namespace {Settings.NamespaceName};");

        Blank();

        string definition = $"public unsafe partial class {fileName}";
        Line(definition);

        StartBlock();
        {
            foreach (RaylibDefine define in defines)
            {
                if (Settings.DefinesOverride.Contains(define.Name))
                {
                    continue;
                }

                string name = Converter.FromSnakeToPascalCase(define.Name);

                switch (define.Type)
                {
                    case "STRING":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    Line($"public const string {name} = \"{define.Value}\";");
                    break;

                    case "FLOAT":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    Line($"public const float {name} = {define.Value}f;");
                    break;

                    case "DOUBLE":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    Line($"public const double {name} = {define.Value};");
                    break;

                    case "INT":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    Line($"public const int {name} = {define.Value};");
                    break;

                    case "LONG":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    Line($"public const long {name} = {define.Value};");
                    break;

                    case "COLOR":
                    if (define.Description != "")
                    {
                        DocumentationBlock(define.Description);
                    }
                    string val = define.Value.Replace("CLITERAL(Color)", "new Color").Replace("{ ", "(").Replace(" }", ")");
                    Line($"public static readonly Color {name} = {val};");
                    break;

                    case "GUARD":
                    case "MAKRO":
                    case "UNKNOWN":
                    default:
                    Line($"// {define.Type} {name} {define.Value}");
                    break;
                }

                Blank();
            }
        }
        EndBlock();
        Blank();
        Line($"#pragma warning restore");

        string file = Settings.OutputFolder + fileName + "/" + fileName + "Defines.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        File.WriteAllText(file, fileContents.ToString());

        file = Settings.OutputFolder + fileName + "/" + fileName + "SafeDefines.cs";
        Directory.CreateDirectory(Path.GetDirectoryName(file));
        fileContents.Replace(definition, definition + "S");
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
