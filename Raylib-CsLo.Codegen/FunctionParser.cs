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
    static List<string> types = new();

    public static void Parse(List<RaylibFunction> functions, JsonDocument document)
    {
        Console.WriteLine("\n-- Parsing Functions --");
        ExtractFromJson(functions, document);

        Console.WriteLine("\n-- Implemented Manually in wrappers/ --");
        ManuallyImplement();
    }

    static void ExtractFromJson(List<RaylibFunction> functions, JsonDocument document)
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

            func.Return.TypeCs = TypeConverter.CToCsTypes(func.Return.TypeC);

            bool returnSame = func.Return.TypeCs == TypeConverter.CToCsTypes(func.Return.TypeC);
            bool paramsSame = true;

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

                    string typeCs = TypeConverter.CToCsTypes(typeC);

                    if (TypeConverter.CToCsTypes(typeC) != typeCs)
                    {
                        paramsSame = false;
                    }
                    func.Parameters.Add(new RaylibParameter(param.Name, typeCs, typeC));
                }
            }

            if (returnSame && paramsSame)
            {
                func.IsNativeOnly = returnSame && paramsSame;
            }

            functions.Add(func);

            Console.WriteLine("{0,-30} NativeOnly={1,-5} Manual={2,-5}", func.Name + "()", func.IsNativeOnly, func.IsManual);
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
}
