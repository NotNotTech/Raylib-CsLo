// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> It should be redesigned to be provided by user </summary>
public unsafe partial struct Font
{
    /// <summary> Base size (default chars height) </summary>
    public int baseSize;

    /// <summary> Number of characters </summary>
    public int glyphCount;

    /// <summary> Characters texture atlas </summary>
    public Texture texture;

    /// <summary> Characters rectangles in texture </summary>
    public Rectangle * recs;

    /// <summary> Characters info data </summary>
    public GlyphInfo * chars;

}
