// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary>
/// Color blending modes (pre-defined)
/// </summary>
public enum BlendMode
{
    /// <summary>
    /// Blend textures considering alpha (default)
    /// </summary>
    BLEND_ALPHA = 0,
    /// <summary>
    /// Blend textures adding colors
    /// </summary>
    BLEND_ADDITIVE = 1,
    /// <summary>
    /// Blend textures multiplying colors
    /// </summary>
    BLEND_MULTIPLIED = 2,
    /// <summary>
    /// Blend textures adding colors (alternative)
    /// </summary>
    BLEND_ADD_COLORS = 3,
    /// <summary>
    /// Blend textures subtracting colors (alternative)
    /// </summary>
    BLEND_SUBTRACT_COLORS = 4,
    /// <summary>
    /// Blend premultiplied textures considering alpha
    /// </summary>
    BLEND_ALPHA_PREMUL = 5,
    /// <summary>
    /// Blend textures using custom src/dst factors (use rlSetBlendMode())
    /// </summary>
    BLEND_CUSTOM = 6,
}
