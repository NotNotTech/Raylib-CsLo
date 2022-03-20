// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Color blending modes (pre-defined) </summary>
public enum RlBlendMode
{
    /// <summary> Blend textures considering alpha (default) </summary>
    RlBlendAlpha = 0,
    /// <summary> Blend textures adding colors </summary>
    RlBlendAdditive = 1,
    /// <summary> Blend textures multiplying colors </summary>
    RlBlendMultiplied = 2,
    /// <summary> Blend textures adding colors (alternative) </summary>
    RlBlendAddColors = 3,
    /// <summary> Blend textures subtracting colors (alternative) </summary>
    RlBlendSubtractColors = 4,
    /// <summary> Blend premultiplied textures considering alpha </summary>
    RlBlendAlphaPremul = 5,
    /// <summary> Blend textures using custom src/dst factors (use rlSetBlendFactors()) </summary>
    RlBlendCustom = 6,
}
