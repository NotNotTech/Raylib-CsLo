// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class EnumGenerator : BaseGenerator
{
    List<RaylibEnumType> enumTypes;
    readonly JsonDocument document;
    readonly string fileName;

    public EnumGenerator(JsonDocument document, string fileName)
    {
        this.document = document;
        this.fileName = fileName;
        Debug = false;

        Parse();
    }

    public void Generate()
    {
        foreach (RaylibEnumType enumType in enumTypes)
        {
            Line(Settings.CodeHeader);

            Blank();

            Line($"namespace {Settings.NamespaceName};");

            Blank();

            DocumentationBlock(enumType.Description);

            Line($"public enum {char.ToUpperInvariant(enumType.Name[0]) + enumType.Name[1..]}");
            StartBlock();
            foreach (RaylibEnumValue value in enumType.Values)
            {
                DocumentationBlock(value.Description);
                string name = Converter.FromSnakeToPascalCase(value.Name);
                Line($"{name} = {value.Value},");
            }
            EndBlock();

            string file = Settings.OutputFolder + fileName + "/Enums/" + enumType.Name + ".cs";
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            File.WriteAllText(file, fileContents.ToString());
            fileContents.Clear();
        }
    }

    public void Parse()
    {
        enumTypes = new();

        foreach (JsonElement element in document.RootElement.GetProperty("enums").EnumerateArray())
        {
            RaylibEnumType enumType = new();
            enumType.Name = element.GetProperty("name").ToString();
            enumType.Description = element.GetProperty("description").ToString();

            if (element.TryGetProperty("values", out JsonElement val))
            {
                enumType.Values = val.Deserialize<List<RaylibEnumValue>>().ToArray();
            }

            enumTypes.Add(enumType);
        }
    }
}
