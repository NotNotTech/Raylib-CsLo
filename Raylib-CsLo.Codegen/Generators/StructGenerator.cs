// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class StructGenerator : BaseGenerator
{
    static List<string> structs = new();

    List<RaylibStructType> structTypes;
    readonly JsonDocument document;
    readonly string fileName;

    public StructGenerator(JsonDocument document, string fileName)
    {
        this.document = document;
        this.fileName = fileName;
        Debug = false;

        Parse();
    }

    public void Generate()
    {
        foreach (RaylibStructType structType in structTypes)
        {
            if (structs.Contains(structType.Name) || CodegenSettings.StructsOverride.Contains(structType.Name))
            {
                continue;
            }

            structs.Add(structType.Name);
            Line(CodegenSettings.CodeHeader);

            Blank();

            Line($"namespace {CodegenSettings.NamespaceName};");

            Blank();

            DocumentationBlock(structType.Description);
            Line($"public unsafe partial struct {char.ToUpperInvariant(structType.Name[0]) + structType.Name[1..]}");
            StartBlock();
            if (structType.Fields != null)
            {
                foreach (RaylibStructValue value in structType.Fields)
                {
                    DocumentationBlock(value.Description);

                    string name = value.Name;

                    bool isArray = name.Contains('[');
                    string type = Converter.FromCToUnsafeCs(value.Type.Replace(" *", "*"));

                    if (name.StartsWith("params"))
                    {
                        name = name.Replace("params", "@params");
                    }

                    if (isArray)
                    {
                        if (type == "Matrix4x4")
                        {
                            type = "FixedMatrix4x4";
                            Line($"public {type} {name[0..name.IndexOf('[')]};");
                        }
                        else
                        {
                            int startArray = name.IndexOf('[');
                            int endArray = name.IndexOf(']');

                            int multiplier = 1;

                            if (type == "Vector2")
                            {
                                type = "float";
                                multiplier *= 2;
                            }
                            else if (type == "Vector3")
                            {
                                type = "float";
                                multiplier *= 3;
                            }
                            else if (type == "Vector4")
                            {
                                type = "float";
                                multiplier *= 4;
                            }

                            if (int.TryParse(name[(startArray + 1)..endArray], out int arraySize))
                            {
                                _ = " * " + multiplier;
                                Line($"public fixed {type} {name[..startArray]}[{arraySize}];");
                            }
                            else
                            {
                                Line($"public fixed {type} {name[..startArray]}[{Converter.FromSnakeToPascalCase(name[(startArray + 1)..endArray])}];");
                            }
                        }
                    }
                    else
                    {
                        Line($"public {type} {name};");
                    }
                    Blank();
                }
            }
            EndBlock();

            string file = CodegenSettings.OutputFolder + fileName + "/Structs/" + structType.Name + ".cs";
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            File.WriteAllText(file, fileContents.ToString());
            fileContents.Clear();
        }
    }

    public void Parse()
    {
        structTypes = new();

        foreach (JsonElement element in document.RootElement.GetProperty("structs").EnumerateArray())
        {
            RaylibStructType structType = new();
            structType.Name = element.GetProperty("name").ToString();
            structType.Description = element.GetProperty("description").ToString();

            if (element.TryGetProperty("fields", out JsonElement val))
            {
                structType.Fields = val.Deserialize<List<RaylibStructValue>>().ToArray();
            }

            structTypes.Add(structType);
        }
    }
}
