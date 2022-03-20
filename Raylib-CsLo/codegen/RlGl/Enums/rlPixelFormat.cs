// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Texture formats (support depends on OpenGL version) </summary>
public enum RlPixelFormat
{
    /// <summary> 8 bit per pixel (no alpha) </summary>
    RlPixelformatUncompressedGrayscale = 1,
    /// <summary> 8*2 bpp (2 channels) </summary>
    RlPixelformatUncompressedGrayAlpha = 2,
    /// <summary> 16 bpp </summary>
    RlPixelformatUncompressedR5g6b5 = 3,
    /// <summary> 24 bpp </summary>
    RlPixelformatUncompressedR8g8b8 = 4,
    /// <summary> 16 bpp (1 bit alpha) </summary>
    RlPixelformatUncompressedR5g5b5a1 = 5,
    /// <summary> 16 bpp (4 bit alpha) </summary>
    RlPixelformatUncompressedR4g4b4a4 = 6,
    /// <summary> 32 bpp </summary>
    RlPixelformatUncompressedR8g8b8a8 = 7,
    /// <summary> 32 bpp (1 channel - float) </summary>
    RlPixelformatUncompressedR32 = 8,
    /// <summary> 32*3 bpp (3 channels - float) </summary>
    RlPixelformatUncompressedR32g32b32 = 9,
    /// <summary> 32*4 bpp (4 channels - float) </summary>
    RlPixelformatUncompressedR32g32b32a32 = 10,
    /// <summary> 4 bpp (no alpha) </summary>
    RlPixelformatCompressedDxt1Rgb = 11,
    /// <summary> 4 bpp (1 bit alpha) </summary>
    RlPixelformatCompressedDxt1Rgba = 12,
    /// <summary> 8 bpp </summary>
    RlPixelformatCompressedDxt3Rgba = 13,
    /// <summary> 8 bpp </summary>
    RlPixelformatCompressedDxt5Rgba = 14,
    /// <summary> 4 bpp </summary>
    RlPixelformatCompressedEtc1Rgb = 15,
    /// <summary> 4 bpp </summary>
    RlPixelformatCompressedEtc2Rgb = 16,
    /// <summary> 8 bpp </summary>
    RlPixelformatCompressedEtc2EacRgba = 17,
    /// <summary> 4 bpp </summary>
    RlPixelformatCompressedPvrtRgb = 18,
    /// <summary> 4 bpp </summary>
    RlPixelformatCompressedPvrtRgba = 19,
    /// <summary> 8 bpp </summary>
    RlPixelformatCompressedAstc4x4Rgba = 20,
    /// <summary> 2 bpp </summary>
    RlPixelformatCompressedAstc8x8Rgba = 21,
}
