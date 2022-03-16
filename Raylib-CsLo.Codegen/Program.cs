// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Raylib_CsLo.Codegen.Generators;
using Raylib_CsLo.Codegen.Parsers;

public class Program
{

    public static void Main()
    {
        Console.WriteLine("\n-- Raylib Code Gen --\n");

        if (Directory.Exists(CodegenSettings.OutputFolder))
        {
            Directory.Delete(CodegenSettings.OutputFolder, true);
        }

        Directory.CreateDirectory(CodegenSettings.OutputFolder);
        foreach (string bindingPath in Directory.GetFiles(CodegenSettings.BindingsFolder))
        {
            List<RaylibFunction> functions = new();
            List<RaylibDefine> defines = new();
            List<RaylibEnumType> enums = new();

            string fileName = new(Path.GetFileNameWithoutExtension(bindingPath.Replace("_api", "")));

            fileName = fileName switch
            {
                "raylib" => "Raylib",
                "raygui" => "RayGui",
                "rlgl" => "RlGl",
                _ => fileName,
            };

            using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(bindingPath)))
            {
                FunctionParser.Parse(functions, document);
                DefineParser.Parse(defines, document);
                EnumParser.Parse(enums, document);
            }

            NativeClassGenerator nativeGenerator = new(functions, fileName.ToString());
            nativeGenerator.Generate();

            SafeClassGenerator safeGenerator = new(functions, fileName.ToString());
            safeGenerator.Generate();

            DefineGenerator defineGenerator = new(defines, fileName.ToString());
            defineGenerator.Generate();

            EnumGenerator enumGenerator = new(enums, fileName.ToString());
            enumGenerator.Generate();
        }
    }
}
