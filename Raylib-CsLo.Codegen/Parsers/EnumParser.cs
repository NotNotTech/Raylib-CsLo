// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Parsers;

using System;
using System.Collections.Generic;
using System.Text.Json;

public static class EnumParser
{
    public static void Parse(List<RaylibEnumType> enums, JsonDocument document)
    {
        foreach (JsonElement element in document.RootElement.GetProperty("enums").EnumerateArray())
        {
            RaylibEnumType enumType = new();
            enumType.Name = element.GetProperty("name").ToString();
            enumType.Description = element.GetProperty("description").ToString();

            if (element.TryGetProperty("values", out JsonElement val))
            {
                enumType.Values = val.Deserialize<List<RaylibEnumValue>>().ToArray();
            }

            enums.Add(enumType);

            Console.WriteLine("enum {0,-34} ", enumType.Name);
        }
    }
}
