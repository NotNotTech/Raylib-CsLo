// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.IO;
using System.Text.Json;
using Raylib_CsLo.Codegen.Generators;

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

        // For manual ordering
        string[] bindingFiles = {
            CodegenSettings.BindingsFolder+"raylib_api.json",
            CodegenSettings.BindingsFolder+"raygui_api.json",
            CodegenSettings.BindingsFolder+"rlgl_api.json",
            CodegenSettings.BindingsFolder+"raymath_api.json",
            CodegenSettings.BindingsFolder+"physac_api.json",
        };

        foreach (string bindingPath in bindingFiles)
        {
            Console.WriteLine(bindingPath);
            string fileName = Path.GetFileNameWithoutExtension(bindingPath).Replace("_api", "");

            fileName = fileName switch
            {
                "raylib" => "Raylib",
                "raygui" => "RayGui",
                "rlgl" => "RlGl",
                "easings" => "Easings",
                "physac" => "Physac",
                "raymath" => "RayMath",
                _ => fileName,
            };

            using JsonDocument document = JsonDocument.Parse(File.ReadAllText(bindingPath));

            NativeClassGenerator nativeGenerator = new(document, fileName.ToString());
            nativeGenerator.Generate();

            SafeClassGenerator safeGenerator = new(document, fileName.ToString());
            safeGenerator.Generate();

            DefineGenerator defineGenerator = new(document, fileName.ToString());
            defineGenerator.Generate();

            EnumGenerator enumGenerator = new(document, fileName.ToString());
            enumGenerator.Generate();

            StructGenerator structGenerator = new(document, fileName.ToString());
            structGenerator.Generate();
        }

        EasingsGenerator easingsGenerator = new(CodegenSettings.BindingsFolder + "easings.h");
        easingsGenerator.Generate();
    }
}
