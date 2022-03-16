// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen.Parsers;

using System;
using System.Collections.Generic;
using System.Text.Json;

public static class DefineParser
{
    public static void Parse(List<RaylibDefine> defines, JsonDocument document)
    {
        foreach (JsonElement element in document.RootElement.GetProperty("defines").EnumerateArray())
        {
            RaylibDefine define = new();
            define.Name = element.GetProperty("name").ToString();
            define.Value = element.GetProperty("value").ToString();
            define.Type = element.GetProperty("type").ToString();
            define.Description = element.GetProperty("description").ToString();

            defines.Add(define);

            Console.WriteLine("define {0,-50} {1,-12} {2,-12}", define.Name, define.Type, define.Value);
        }
    }
}
