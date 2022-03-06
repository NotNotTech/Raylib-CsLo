// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Codegen;

using System.Collections.Generic;
using System.Text.Json.Serialization;


public class RaylibFunction
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("description")] public string Description { get; set; }
    [JsonPropertyName("returnType")] public string ReturnTypeC { get; set; }
    [JsonPropertyName("params")] public Dictionary<string, string> ParametersC { get; set; }

    public string ReturnType { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
}
