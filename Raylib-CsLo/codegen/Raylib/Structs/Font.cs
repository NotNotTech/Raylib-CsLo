// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost
namespace Raylib_CsLo;

/// <summary> Font, font texture and GlyphInfo array data </summary>
public unsafe partial struct Font
{
    /// <summary> Base size (default chars height) </summary>
    public int baseSize;

    /// <summary> Number of glyph characters </summary>
    public int glyphCount;

    /// <summary> Padding around the glyph characters </summary>
    public int glyphPadding;

    /// <summary> Texture atlas containing the glyphs </summary>
    public Texture texture;

    /// <summary> Rectangles in texture for the glyphs </summary>
    public Rectangle * recs;

    /// <summary> Glyphs info data </summary>
    public GlyphInfo * glyphs;

}
