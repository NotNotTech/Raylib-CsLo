// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class StructGenerator : BaseGenerator
{
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
            if (CodegenSettings.StructsOverride.Contains(structType.Name))
            {
                continue;
            }
            Line(CodegenSettings.CodeHeader);

            Line($"namespace {CodegenSettings.NamespaceName};");

            Blank();

            DocumentationBlock(structType.Description);
            Line($"public unsafe partial struct {structType.Name}");
            StartBlock();
            if (structType.Fields != null)
            {
                foreach (RaylibStructValue value in structType.Fields)
                {
                    DocumentationBlock(value.Description);
                    Line($"public {TypeConverter.FromCToUnsafeCs(value.Type)} {value.Name};");
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
