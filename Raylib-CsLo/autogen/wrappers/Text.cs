#pragma warning disable
namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Get the default Font
    /// </summary>
    public Font GetFontDefault()
    {
        return Raylib.GetFontDefault();
    }

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    public Font LoadFont(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.LoadFont(fileName_.AsPtr());
    }

    /// <summary>
    /// Load font from file with extended parameters
    /// </summary>
    public Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.LoadFontEx(fileName_.AsPtr(), fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    public Font LoadFontFromImage(Image image, Color key, int firstChar)
    {
        return Raylib.LoadFontFromImage(image, key, firstChar);
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public Font LoadFontFromMemory(string fileType, byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount)
    {
        using var fileType_ = fileType.MarshalUtf8();
        return Raylib.LoadFontFromMemory(fileType_.AsPtr(), fileData, dataSize, fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public GlyphInfo[] LoadFontData(byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, int type)
    {
        return (GlyphInfo[])Raylib.LoadFontData(fileData, dataSize, fontSize, fontChars, glyphCount, type);
    }

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public Image GenImageFontAtlas(GlyphInfo* chars, Rectangle[] recs, int glyphCount, int fontSize, int padding, int packMethod)
    {
        return Raylib.GenImageFontAtlas(chars, recs, glyphCount, fontSize, padding, packMethod);
    }

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    public void UnloadFontData(GlyphInfo* chars, int glyphCount)
    {
        Raylib.UnloadFontData(chars, glyphCount);
    }

    /// <summary>
    /// Unload Font from GPU memory (VRAM)
    /// </summary>
    public void UnloadFont(Font font)
    {
        Raylib.UnloadFont(font);
    }

    /// <summary>
    /// Draw current FPS
    /// </summary>
    public void DrawFPS(int posX, int posY)
    {
        Raylib.DrawFPS(posX, posY);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.DrawText(text_.AsPtr(), posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.DrawTextEx(font, text_.AsPtr(), position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.DrawTextPro(font, text_.AsPtr(), position, origin, rotation, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    public void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint)
    {
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public int MeasureText(string text, int fontSize)
    {
        using var text_ = text.MarshalUtf8();
        return Raylib.MeasureText(text_.AsPtr(), fontSize);
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        using var text_ = text.MarshalUtf8();
        return Raylib.MeasureTextEx(font, text_.AsPtr(), fontSize, spacing);
    }

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public int GetGlyphIndex(Font font, int codepoint)
    {
        return Raylib.GetGlyphIndex(font, codepoint);
    }

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public GlyphInfo GetGlyphInfo(Font font, int codepoint)
    {
        return Raylib.GetGlyphInfo(font, codepoint);
    }

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public Rectangle GetGlyphAtlasRec(Font font, int codepoint)
    {
        return Raylib.GetGlyphAtlasRec(font, codepoint);
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public int[] LoadCodepoints(string text, int* count)
    {
        using var text_ = text.MarshalUtf8();
        return (int[])Raylib.LoadCodepoints(text_.AsPtr(), count);
    }

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    public void UnloadCodepoints(int* codepoints)
    {
        Raylib.UnloadCodepoints(codepoints);
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public int GetCodepointCount(string text)
    {
        using var text_ = text.MarshalUtf8();
        return Raylib.GetCodepointCount(text_.AsPtr());
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public int GetCodepoint(string text, int* bytesProcessed)
    {
        using var text_ = text.MarshalUtf8();
        return Raylib.GetCodepoint(text_.AsPtr(), bytesProcessed);
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public string CodepointToUTF8(int codepoint, int* byteSize)
    {
        return Helpers.Utf8ToString(Raylib.CodepointToUTF8(codepoint, byteSize));
    }

    /// <summary>
    /// Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)
    /// </summary>
    public string TextCodepointsToUTF8(int* codepoints, int length)
    {
        return (string)Raylib.TextCodepointsToUTF8(codepoints, length);
    }

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    public int TextCopy(string dst, string src)
    {
        using var dst_ = dst.MarshalUtf8();
        using var src_ = src.MarshalUtf8();
        return Raylib.TextCopy(dst_.AsPtr(), src_.AsPtr());
    }

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    public bool TextIsEqual(string text1, string text2)
    {
        using var text1_ = text1.MarshalUtf8();
        using var text2_ = text2.MarshalUtf8();
        return Raylib.TextIsEqual(text1_.AsPtr(), text2_.AsPtr());
    }

    /// <summary>
    /// Get text length, checks for ' 0' ending
    /// </summary>
    public uint TextLength(string text)
    {
        using var text_ = text.MarshalUtf8();
        return (uint)Raylib.TextLength(text_.AsPtr());
    }

    /// <summary>
    /// Text formatting with variables (sprintf() style)
    /// </summary>
    public string TextFormat(string text, params object[] args)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextFormat(text_.AsPtr(), args));
    }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    public string TextSubtext(string text, int position, int length)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextSubtext(text_.AsPtr(), position, length));
    }

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    public string TextReplace(string text, string replace, string by)
    {
        using var text_ = text.MarshalUtf8();
        using var replace_ = replace.MarshalUtf8();
        using var by_ = by.MarshalUtf8();
        return (string)Raylib.TextReplace(text_.AsPtr(), replace_.AsPtr(), by_.AsPtr());
    }

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    public string TextInsert(string text, string insert, int position)
    {
        using var text_ = text.MarshalUtf8();
        using var insert_ = insert.MarshalUtf8();
        return (string)Raylib.TextInsert(text_.AsPtr(), insert_.AsPtr(), position);
    }

    /// <summary>
    /// Join text strings with delimiter
    /// </summary>
    public string TextJoin(string[] textList, int count, string delimiter)
    {
        using var delimiter_ = delimiter.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextJoin(textList, count, delimiter_.AsPtr()));
    }

    /// <summary>
    /// Split text into multiple strings
    /// </summary>
    public string[] TextSplit(string text, char delimiter, int* count)
    {
        using var text_ = text.MarshalUtf8();
        return (string[])Raylib.TextSplit(text_.AsPtr(), delimiter, count);
    }

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    public void TextAppend(string text, string append, int* position)
    {
        using var text_ = text.MarshalUtf8();
        using var append_ = append.MarshalUtf8();
        Raylib.TextAppend(text_.AsPtr(), append_.AsPtr(), position);
    }

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    public int TextFindIndex(string text, string find)
    {
        using var text_ = text.MarshalUtf8();
        using var find_ = find.MarshalUtf8();
        return Raylib.TextFindIndex(text_.AsPtr(), find_.AsPtr());
    }

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    public string TextToUpper(string text)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToUpper(text_.AsPtr()));
    }

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    public string TextToLower(string text)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToLower(text_.AsPtr()));
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public string TextToPascal(string text)
    {
        using var text_ = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToPascal(text_.AsPtr()));
    }

    /// <summary>
    /// Get integer value from text (negative values not supported)
    /// </summary>
    public int TextToInteger(string text)
    {
        using var text_ = text.MarshalUtf8();
        return Raylib.TextToInteger(text_.AsPtr());
    }

}
#pragma warning restore
