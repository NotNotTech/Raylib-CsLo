// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.IO;
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

        List<RaylibFunction> functions = new();

        using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(CodegenSettings.ApiJsonFile)))
        {
            FunctionParser.Parse(functions, document);
        }

        NativeClassGenerator native = new(functions);
        native.Generate();
        native.Output();

        SafeClassGenerator safe = new(functions);
        safe.Generate();
        safe.Output();
    }
}
