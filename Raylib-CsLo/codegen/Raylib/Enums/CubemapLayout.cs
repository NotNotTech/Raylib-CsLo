// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary>
/// Cubemap layouts
/// </summary>
public enum CubemapLayout
{
    /// <summary>
    /// Automatically detect layout type
    /// </summary>
    CUBEMAP_LAYOUT_AUTO_DETECT = 0,
    /// <summary>
    /// Layout is defined by a vertical line with faces
    /// </summary>
    CUBEMAP_LAYOUT_LINE_VERTICAL = 1,
    /// <summary>
    /// Layout is defined by an horizontal line with faces
    /// </summary>
    CUBEMAP_LAYOUT_LINE_HORIZONTAL = 2,
    /// <summary>
    /// Layout is defined by a 3x4 cross with cubemap faces
    /// </summary>
    CUBEMAP_LAYOUT_CROSS_THREE_BY_FOUR = 3,
    /// <summary>
    /// Layout is defined by a 4x3 cross with cubemap faces
    /// </summary>
    CUBEMAP_LAYOUT_CROSS_FOUR_BY_THREE = 4,
    /// <summary>
    /// Layout is defined by a panorama image (equirectangular map)
    /// </summary>
    CUBEMAP_LAYOUT_PANORAMA = 5,
}
