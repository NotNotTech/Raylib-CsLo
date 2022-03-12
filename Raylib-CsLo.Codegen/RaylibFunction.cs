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
    public string Return { get; set; }
    public bool SameTypes { get; set; }
    public bool Manual { get; set; }
}

public class RaylibParameter
{
    public string Name { get; set; }
    public string Type { get; set; }

    public RaylibParameter(string name, string type)
    {
        Name = name;
        Type = type;
    }
}

public class RaylibParam
{
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}
