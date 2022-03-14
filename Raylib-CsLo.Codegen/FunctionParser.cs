// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public static class FunctionParser
{
    public static void Parse(List<RaylibFunction> functions, JsonDocument document)
    {
        Console.WriteLine("\n-- Parsing Functions --\n");
        ExtractFromJson(functions, document);

        Console.WriteLine("\n-- Implemented Manually in wrappers/ --\n");
        ManuallyImplement();

        UnhandledTypeConversions();
    }

    static void ExtractFromJson(List<RaylibFunction> functions, JsonDocument document)
    {
        foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
        {
            RaylibFunction func = new();
            func.Name = element.GetProperty("name").ToString();
            func.Description = element.GetProperty("description").ToString();
            func.Return = element.GetProperty("returnType").ToString().Replace(" *", "*");

            List<RaylibParam> parameters = null;

            if (element.TryGetProperty("params", out JsonElement val))
            {
                parameters = JsonSerializer.Deserialize<List<RaylibParam>>(val);
            }

            // Skip auto gening these functions be sure to add them manually
            if (CodegenSettings.FunctionsToHandleManually.Contains(func.Name))
            {
                func.Manual = true;
            }

            bool isReturnSame = TypeConverter.FromCToUnsafeCs(func.Return).Equals(TypeConverter.FromCToSafeCs(func.Return), StringComparison.Ordinal);
            bool isParamsSame = true;
            if (parameters != null)
            {
                func.Parameters = new();

                foreach (RaylibParam param in parameters)
                {
                    string type = param.Type.Replace(" *", "*");

                    if (TypeConverter.FromCToUnsafeCs(func.Return) != TypeConverter.FromCToSafeCs(func.Return))
                    {
                        isParamsSame = false;
                    }

                    // Handle C# keyword named variables
                    if (param.Name == "checked")
                    {
                        param.Name = "@checked";
                    }

                    func.Parameters.Add(new RaylibParameter(param.Name, type));
                }
            }

            if (isReturnSame && isParamsSame)
            {
                func.SameTypes = true;
            }

            functions.Add(func);

            Console.WriteLine("{0,-34} {1,15} {2,5}", func.Name + "()", func.SameTypes ? "SameTypes" : "", func.Manual ? "Manual" : "");
        }
    }

    static void ManuallyImplement()
    {
        for (int i = 0; i < CodegenSettings.FunctionsToHandleManually.Length; i++)
        {
            string line = CodegenSettings.FunctionsToHandleManually[i];
            Console.WriteLine(i + 1 + ".\t" + line + "()");
        }
    }

    static void UnhandledTypeConversions()
    {
        Console.WriteLine("\n-- Unhandled Unsafe Types --");
        foreach (string type in TypeConverter.UnsafePrinted)
        {
            Console.WriteLine(type);
        }

        Console.WriteLine("\n-- Unhandled Safe Types --");
        foreach (string type in TypeConverter.SafePrinted)
        {
            Console.WriteLine(type);
        }
    }
}
