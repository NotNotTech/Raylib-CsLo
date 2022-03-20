// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> Image, pixel data stored in CPU memory (RAM) </summary>
public unsafe partial struct Image
{
    /// <summary> Image raw data </summary>
    public void* data;

    /// <summary> Image base width </summary>
    public int width;

    /// <summary> Image base height </summary>
    public int height;

    /// <summary> Mipmap levels, 1 by default </summary>
    public int mipmaps;

    /// <summary> Data format (PixelFormat type) </summary>
    public int format;

}
