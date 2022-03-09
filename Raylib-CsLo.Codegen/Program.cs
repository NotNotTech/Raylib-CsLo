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

        Console.WriteLine("\n-- C => CSharp mapping --");

        // Debug only
        foreach (string cType in types)
        {
            string csType = CToCsTypes(cType);
            if (cType != csType || csType.Contains('*'))
            {
                Console.WriteLine("{0,16} -> {1,-10}", cType, csType);
            }
        }

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
            func.Return.TypeC = element.GetProperty("returnType").ToString().Replace(" *", "*");

            List<RaylibParam> parametersC = null;

            if (element.TryGetProperty("params", out JsonElement val))
            {
                parametersC = JsonSerializer.Deserialize<List<RaylibParam>>(val);
            }

            // Skip auto gening these functions be sure to add them manually
            if (CodegenSettings.FunctionsToHandleManually.Contains(func.Name))
            {
                func.IsManual = true;
            }

            if (!types.Contains(func.Return.TypeC))
            {
                types.Add(func.Return.TypeC);
            }

            func.Return.TypeCs = CToCsTypes(func.Return.TypeC);

            if (parametersC != null)
            {
                func.Parameters = new();

                foreach (RaylibParam param in parametersC)
                {
                    string typeC = param.Type.Replace(" *", "*");
                    if (!types.Contains(typeC))
                    {
                        types.Add(typeC);
                    }

                    string typeCs = CToCsTypes(typeC);
                    func.Parameters.Add(new RaylibParameter(param.Name, typeCs, typeC));
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

    static string CToCsTypes(string type)
    {
        // remove const
        type = type.Replace("const ", "");

        // Convert C types to safe types
        type = type switch
        {
            "void*" => "IntPtr",
            "char*" => "string",
            "char**" => "string[]",
            "unsigned char*" => "byte[]",
            "..." => "params object[]", // var args array
            _ => type
        };

        type = type.Replace("unsigned ", "u");

        if (type.EndsWith("*"))
        {
            type = "ref " + type[0..(type.Length - 1)];
        }

        return type;
    }
}
