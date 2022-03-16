// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Generators;

using System.Collections.Generic;
using System.IO;

public class EnumGenerator : ClassGenerator
{
    List<RaylibEnumType> enumTypes;
    readonly string fileName;

    public EnumGenerator(List<RaylibEnumType> enumTypes, string fileName)
    {
        this.enumTypes = enumTypes;
        this.fileName = fileName;
        Debug = false;
    }

    public void Generate()
    {
        foreach (RaylibEnumType enumType in enumTypes)
        {
            Line(CodegenSettings.CodeHeader);

            Blank();

            Line($"namespace {CodegenSettings.NamespaceName};");

            Blank();

            DocumentationBlock(enumType.Description);
            Line($"public enum {enumType.Name}");
            StartBlock();
            foreach (RaylibEnumValue value in enumType.Values)
            {
                DocumentationBlock(value.Description);
                Line($"{value.Name} = {value.Value},");
            }
            EndBlock();

            string file = CodegenSettings.OutputFolder + fileName + "/Enums/" + enumType.Name + ".cs";
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            File.WriteAllText(file, fileContents.ToString());
            fileContents.Clear();
        }
    }
}
