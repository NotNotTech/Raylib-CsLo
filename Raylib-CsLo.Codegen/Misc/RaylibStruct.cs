// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Text.Json.Serialization;

public class RaylibStructType
{
    public string Name { get; set; }
    public string Description { get; set; }
    public RaylibStructValue[] Fields { get; set; }
}

public class RaylibStructValue
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("type")] public string Type { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
}
