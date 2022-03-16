// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary>
/// Texture parameters: filter mode
/// </summary>
public enum rlTextureFilter
{
    /// <summary>
    /// No filter, just pixel approximation
    /// </summary>
    RL_TEXTURE_FILTER_POINT = 0,
    /// <summary>
    /// Linear filtering
    /// </summary>
    RL_TEXTURE_FILTER_BILINEAR = 1,
    /// <summary>
    /// Trilinear filtering (linear with mipmaps)
    /// </summary>
    RL_TEXTURE_FILTER_TRILINEAR = 2,
    /// <summary>
    /// Anisotropic filtering 4x
    /// </summary>
    RL_TEXTURE_FILTER_ANISOTROPIC_4X = 3,
    /// <summary>
    /// Anisotropic filtering 8x
    /// </summary>
    RL_TEXTURE_FILTER_ANISOTROPIC_8X = 4,
    /// <summary>
    /// Anisotropic filtering 16x
    /// </summary>
    RL_TEXTURE_FILTER_ANISOTROPIC_16X = 5,
}
