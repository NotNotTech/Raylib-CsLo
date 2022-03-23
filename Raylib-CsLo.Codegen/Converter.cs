// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;

public static class Converter
{
    // Used in gen of DllImport
    public static string FromCToUnsafeCs(string type)
    {
        type = type.Replace("const ", "");
        return Settings.CToUnsafeConversion.GetValueOrDefault(type, type);
    }

    // Uses the above output as input
    // Used in gen of Safe Cs types
    public static string FromCToSafeCs(string type)
    {
        type = FromCToUnsafeCs(type);
        return Settings.UnsafeToSafeConversion.GetValueOrDefault(type, type);
    }

    public static string FromSnakeToPascalCase(string value)
    {
        string[] words = value.Split('_');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 1)
            {
                words[i] = words[i][0] + words[i][1..].ToLowerInvariant();
            }
        }
        return string.Join("", words);
    }
}
