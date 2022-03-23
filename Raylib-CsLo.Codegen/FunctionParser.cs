// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Parsers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public static class FunctionParser
{
    public static List<RaylibFunction> Parse(JsonDocument document)
    {
        List<RaylibFunction> funcs = new();

        foreach (JsonElement element in document.RootElement.GetProperty("functions").EnumerateArray())
        {
            RaylibFunction func = new();
            func.Name = element.GetProperty("name").ToString();
            func.Description = element.GetProperty("description").ToString();
            func.Return = element.GetProperty("returnType").ToString().Replace(" *", "*");

            List<RaylibParam> parameters = null;

            if (element.TryGetProperty("params", out JsonElement val))
            {
                parameters = val.Deserialize<List<RaylibParam>>();
            }

            // Skip auto gening these functions be sure to add them manually
            if (Settings.FunctionsToHandleManually.Contains(func.Name))
            {
                func.Manual = true;
            }

            bool isReturnSame = Converter.FromCToUnsafeCs(func.Return).Equals(Converter.FromCToSafeCs(func.Return), StringComparison.Ordinal);
            bool isParamsSame = true;
            if (parameters != null)
            {
                func.Parameters = new();

                foreach (RaylibParam param in parameters)
                {
                    string type = param.Type.Replace(" *", "*");

                    if (Converter.FromCToUnsafeCs(func.Return) != Converter.FromCToSafeCs(func.Return))
                    {
                        isParamsSame = false;
                    }

                    // Handle C# keyword named variables
                    if (param.Name == "checked")
                    {
                        param.Name = "@checked";
                    }
                    else if (param.Name == "readonly")
                    {
                        param.Name = "@readonly";
                    }

                    func.Parameters.Add(new RaylibParameter(param.Name, type));
                }
            }

            if (isReturnSame && isParamsSame)
            {
                func.SameTypes = true;
            }

            funcs.Add(func);
        }

        return funcs;
    }
}
