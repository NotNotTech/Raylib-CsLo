// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

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
        Directory.CreateDirectory(CodegenSettings.OutputFolder + "Native/");
        Directory.CreateDirectory(CodegenSettings.OutputFolder + "Safe/");

        foreach (string binding in Directory.GetFiles(CodegenSettings.BindingsFolder))
        {
            List<RaylibFunction> functions = new();

            StringBuilder fileName = new(Path.GetFileNameWithoutExtension(binding.Replace("_api", "")));
            fileName[0] = char.ToUpperInvariant(fileName[0]);

            if (!fileName.Equals("Raylib") && !fileName.Equals("Raygui"))
            {
                continue;
            }

            using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(binding)))
            {
                FunctionParser.Parse(functions, document);
            }

            NativeClassGenerator native = new(functions, fileName.ToString());
            native.Generate();
            native.Output(fileName.ToString());

            SafeClassGenerator safe = new(functions, fileName.ToString());
            safe.Generate();
            safe.Output(fileName.ToString());
        }
    }
}
