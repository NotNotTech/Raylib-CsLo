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
    static List<string> types = new();
    public static void Main()
    {
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

                func.ReturnType = ConvertCTypesToCSharpReturn(func.ReturnTypeC);

                if (func.ParametersC != null)
                {
                    func.Parameters = new();
                    foreach (KeyValuePair<string, string> kvp in func.ParametersC)
                    {
                        func.Parameters.Add(kvp.Key, (string)kvp.Value.Clone());
                    }

                    foreach (KeyValuePair<string, string> parameter in func.ParametersC)
                    {
                        func.Parameters[parameter.Key] = ConvertCTypesToCSharpParameter(parameter.Value);
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

        foreach (string item in types)
        {
            Console.WriteLine(item);
        }

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

        type = type.Replace(" *", "[]");

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

        return type;
    }

    static string ConvertCTypesToCSharpBase(string type)
    {
        // remove const
        type = type.Replace("const ", "");

        // TextFormat & TraceLog takes any parms
        if (type == "")
        {
            type = "params object[] args";
        }

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
