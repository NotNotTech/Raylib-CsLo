// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class RaylibFunction
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RaylibParameter> Parameters { get; set; }
    public RaylibReturn Return { get; set; }
    public bool IsNativeOnly { get; set; }
    public bool IsManual { get; set; }
}

public class RaylibParameter
{
    public string Name { get; set; }
    public string TypeCs { get; set; }
    public string TypeC { get; set; }

    public RaylibParameter(string name, string typeCs, string typeC)
    {
        Name = name;
        TypeCs = typeCs;
        TypeC = typeC;
    }
}

public class RaylibReturn
{
    public string TypeCs { get; set; }
    public string TypeC { get; set; }
}

public class RaylibParam
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}
