// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Texture parameters: filter mode </summary>
public enum RlTextureFilter
{
    /// <summary> No filter, just pixel approximation </summary>
    RlTextureFilterPoint = 0,
    /// <summary> Linear filtering </summary>
    RlTextureFilterBilinear = 1,
    /// <summary> Trilinear filtering (linear with mipmaps) </summary>
    RlTextureFilterTrilinear = 2,
    /// <summary> Anisotropic filtering 4x </summary>
    RlTextureFilterAnisotropic4x = 3,
    /// <summary> Anisotropic filtering 8x </summary>
    RlTextureFilterAnisotropic8x = 4,
    /// <summary> Anisotropic filtering 16x </summary>
    RlTextureFilterAnisotropic16x = 5,
}
