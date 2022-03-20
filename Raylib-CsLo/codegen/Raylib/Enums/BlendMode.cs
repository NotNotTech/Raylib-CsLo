// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Color blending modes (pre-defined) </summary>
public enum BlendMode
{
    /// <summary> Blend textures considering alpha (default) </summary>
    BlendAlpha = 0,
    /// <summary> Blend textures adding colors </summary>
    BlendAdditive = 1,
    /// <summary> Blend textures multiplying colors </summary>
    BlendMultiplied = 2,
    /// <summary> Blend textures adding colors (alternative) </summary>
    BlendAddColors = 3,
    /// <summary> Blend textures subtracting colors (alternative) </summary>
    BlendSubtractColors = 4,
    /// <summary> Blend premultiplied textures considering alpha </summary>
    BlendAlphaPremul = 5,
    /// <summary> Blend textures using custom src/dst factors (use rlSetBlendMode()) </summary>
    BlendCustom = 6,
}
