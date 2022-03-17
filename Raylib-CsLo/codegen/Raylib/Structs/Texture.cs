// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> Texture, tex data stored in GPU memory (VRAM) </summary>
public unsafe partial struct Texture
{
    /// <summary> OpenGL texture id </summary>
    public uint id;

    /// <summary> Texture base width </summary>
    public int width;

    /// <summary> Texture base height </summary>
    public int height;

    /// <summary> Mipmap levels, 1 by default </summary>
    public int mipmaps;

    /// <summary> Data format (PixelFormat type) </summary>
    public int format;

}
