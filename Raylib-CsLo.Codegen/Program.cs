// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Program
{
    static List<string> types = new();

    public static void Main()
    {
        Console.WriteLine("\n-- Raylib Code Gen --\n");

        if (Directory.Exists(CodegenSettings.OutputFolder))
        {
            Directory.Delete(CodegenSettings.OutputFolder, true);
        }
        Directory.CreateDirectory(CodegenSettings.OutputFolder);

        Dictionary<RaylibModule, List<RaylibFunction>> modules = new();
        modules.Add(RaylibModule.Core, new List<RaylibFunction>());

        using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(CodegenSettings.ApiJsonFile)))
        {
            RaylibModule module = RaylibModule.Core;
            foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
            {
                RaylibFunction func = JsonSerializer.Deserialize<RaylibFunction>(element);

                // Skip auto gening these functions be sure to add them manually
                if (CodegenSettings.FunctionsToHandleManually.Contains(func.Name))
                {
                    Console.WriteLine("Handle these functions inside Raylib-CsLo/wrappers/" + module + ".cs " + func.Name + "()");
                    continue;
                }

                func.ReturnTypeCs = ConvertCTypesToCSharpReturn(func.ReturnTypeC);

                if (func.ParametersC != null)
                {
                    // Variable len args have name and type of ""
                    if (func.ParametersC.ContainsKey(""))
                    {
                        func.ParametersC.Remove("");
                        func.ParametersC.Add("args", "params object[]");
                    }

                    func.ParametersCs = new();
                    foreach ((string name, string type) in func.ParametersC)
                    {
                        func.ParametersCs[name] = ConvertCTypesToCSharpParameter(type);
                    }
                }

                modules[module].Add(func);

                if (module != RaylibModule.Audio && func.Name == CodegenSettings.LastFunctionInModule[(int)module])
                {
                    module++;
                    modules.Add(module, new List<RaylibFunction>());
                }
            }
        }

        // Debug only
        // foreach (string item in types)
        // {
        //     Console.WriteLine(item);
        // }

        foreach (KeyValuePair<RaylibModule, List<RaylibFunction>> module in modules)
        {
            ClassGenerator classGenerator = new(module.Key, module.Value);
            classGenerator.Generate();
            classGenerator.Output();
        }
    }


    static string ConvertCTypesToCSharpParameter(string type)
    {
        type = ConvertCTypesToCSharpBase(type);

        type = type switch
        {
            "unsigned int *" => "out uint",
            _ => type
        };

        // Fix the formatting
        type = type.Replace(" *", "*");

        // Debug pruposes only
        if (!types.Contains(type))
        {
            types.Add(type);
        }

        return type;
    }

    static string ConvertCTypesToCSharpReturn(string type)
    {
        type = ConvertCTypesToCSharpBase(type);

        type = type.Replace(" *", "[]");

        // Debug pruposes only
        if (!types.Contains(type))
        {
            types.Add(type);
        }

        return type;
    }

    static string ConvertCTypesToCSharpBase(string type)
    {
        // remove const
        type = type.Replace("const ", "");

        // Convert C types to param and return safe types
        type = type switch
        {
            "void *" => "IntPtr",

            "char *" => "string",
            "char **" => "string[]",

            "unsigned int" => "uint",

            "Rectangle **" => "Rectangle[]",
            "unsigned char *" => "byte[]",

            _ => type
        };

        return type;
    }
}
