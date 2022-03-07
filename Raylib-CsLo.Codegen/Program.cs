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
        Console.Clear();// For watch
        Console.WriteLine("\n-- Raylib Code Gen --\n");

        if (Directory.Exists(CodegenSettings.OutputFolder))
        {
            Directory.Delete(CodegenSettings.OutputFolder, true);
        }
        Directory.CreateDirectory(CodegenSettings.OutputFolder);

        Dictionary<string, string> structs = new();
        Dictionary<string, string> enums = new();
        List<RaylibFunction> functions = new();

        using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(CodegenSettings.ApiJsonFile)))
        {
            ParseStructs(structs, document);
            ParseEnums(enums, document);
            ParseFunctions(functions, document);
        }

        // Debug only
        // foreach (string item in types)
        // {
        //     Console.WriteLine(item);
        // }

        SafeClassGenerator safe = new(functions);
        safe.Generate();
        safe.Output();

        NativeClassGenerator native = new(functions);
        native.Generate();
        native.Output();
    }

    static void ParseStructs(Dictionary<string, string> structs, JsonDocument document)
    {
        // Console.WriteLine("Structs");
        foreach (JsonElement element in document.RootElement.GetProperty("structs").EnumerateArray())
        {
            // Console.WriteLine("\t" + element.GetProperty("name"));
            structs.Add(element.GetProperty("name").ToString(), "TODO ADD STRUCT stuff");
        }
    }

    static void ParseEnums(Dictionary<string, string> enums, JsonDocument document)
    {
        // Console.WriteLine("Enums");
        foreach (JsonElement element in document.RootElement.GetProperty("enums").EnumerateArray())
        {
            // Console.WriteLine("\t" + element.GetProperty("name"));
            enums.Add(element.GetProperty("name").ToString(), "TODO ADD STRUCT stuff");
        }
    }

    static void ParseFunctions(List<RaylibFunction> functions, JsonDocument document)
    {
        foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
        {
            RaylibFunction func = new();
            func.Name = element.GetProperty("name").ToString();
            func.Description = element.GetProperty("description").ToString();
            func.Return = new();
            func.Return.TypeC = element.GetProperty("returnType").ToString();
            Dictionary<string, string> parametersC = null;
            if (element.TryGetProperty("params", out JsonElement val))
            {
                parametersC = JsonSerializer.Deserialize<Dictionary<string, string>>(val);
            }

            // Skip auto gening these functions be sure to add them manually
            if (CodegenSettings.FunctionsToHandleManually.Contains(func.Name))
            {
                func.IsManual = true;
            }

            func.Return.TypeCs = ConvertCTypesToCSharpReturn(func.Return.TypeC);

            if (parametersC != null)
            {
                // Variable len args have name and type of ""
                if (parametersC.ContainsKey(""))
                {
                    parametersC.Remove("");
                    parametersC.Add("args", "params object[]");
                }

                func.Parameters = new();
                // disable this when generating all functions
                // including one that are already safe
                // bool duplicateFunction = true;
                foreach ((string name, string type) in parametersC)
                {
                    string typeCs = ConvertCTypesToCSharpParameter(type);
                    // if (typeCs != type)
                    // {
                    //     duplicateFunction = false;
                    // }
                    func.Parameters.Add(new RaylibParameter(name, typeCs, type));
                }
            }

            functions.Add(func);
        }

        Console.Write("Below are ignored functions to be ");
        Console.WriteLine("implemented manually in Raylib-CsLo/wrappers/");
        for (int i = 0; i < CodegenSettings.FunctionsToHandleManually.Length; i++)
        {
            string line = CodegenSettings.FunctionsToHandleManually[i];
            Console.WriteLine(i + 1 + ".\t" + line + "()");
        }
    }

    static string ConvertCTypesToCSharpParameter(string type)
    {
        type = ConvertCTypesToCSharpBase(type);

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

            "unsigned int *" => "uint",
            "unsigned int" => "uint",

            "Rectangle **" => "Rectangle[]",
            "unsigned char *" => "byte[]",

            _ => type
        };

        return type;
    }
}
