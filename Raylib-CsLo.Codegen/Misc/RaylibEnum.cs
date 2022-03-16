// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;
using System.Text.Json.Serialization;

public class RaylibEnumType
{
    public string Name { get; set; }
    public string Description { get; set; }
    public RaylibEnumValue[] Values { get; set; }
}

public class RaylibEnumValue
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("value")] public int Value { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
}
