// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Texture parameters: filter mode </summary>
public enum TextureFilter
{
    /// <summary> No filter, just pixel approximation </summary>
    TextureFilterPoint = 0,
    /// <summary> Linear filtering </summary>
    TextureFilterBilinear = 1,
    /// <summary> Trilinear filtering (linear with mipmaps) </summary>
    TextureFilterTrilinear = 2,
    /// <summary> Anisotropic filtering 4x </summary>
    TextureFilterAnisotropic4x = 3,
    /// <summary> Anisotropic filtering 8x </summary>
    TextureFilterAnisotropic8x = 4,
    /// <summary> Anisotropic filtering 16x </summary>
    TextureFilterAnisotropic16x = 5,
}
