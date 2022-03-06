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
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadFont(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load font from file with extended parameters
    /// </summary>
    public Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        return Raylib.LoadFontEx(fileNameLocal.AsPtr(), fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    public Font LoadFontFromImage(Image image, Color key, int firstChar)
    {
        /*|  Image => Image  |*/
        /*|  Color => Color  |*/
        /*|  int => int  |*/
        return Raylib.LoadFontFromImage(image, key, firstChar);
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public Font LoadFontFromMemory(string fileType, byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        return Raylib.LoadFontFromMemory(fileTypeLocal.AsPtr(), fileDataLocal, dataSize, fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public GlyphInfo[] LoadFontData(byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, int type)
    {
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Helpers.PrtToArray(Raylib.LoadFontData(fileDataLocal, dataSize, fontSize, fontChars, glyphCount, type));
    }

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public Image GenImageFontAtlas(GlyphInfo* chars, Rectangle[] recs, int glyphCount, int fontSize, int padding, int packMethod)
    {
        /*|  const GlyphInfo * => GlyphInfo*  |*/
        /*|  Rectangle ** => Rectangle[]  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenImageFontAtlas(chars, recs, glyphCount, fontSize, padding, packMethod);
    }

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    public void UnloadFontData(GlyphInfo* chars, int glyphCount)
    {
        /*|  GlyphInfo * => GlyphInfo*  |*/
        /*|  int => int  |*/
        Raylib.UnloadFontData(chars, glyphCount);
    }

    /// <summary>
    /// Unload Font from GPU memory (VRAM)
    /// </summary>
    public void UnloadFont(Font font)
    {
        /*|  Font => Font  |*/
        Raylib.UnloadFont(font);
    }

    /// <summary>
    /// Draw current FPS
    /// </summary>
    public void DrawFPS(int posX, int posY)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.DrawFPS(posX, posY);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawText(textLocal.AsPtr(), posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextEx(font, textLocal.AsPtr(), position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextPro(font, textLocal.AsPtr(), position, origin, rotation, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    public void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public int MeasureText(string text, int fontSize)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        return Raylib.MeasureText(textLocal.AsPtr(), fontSize);
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.MeasureTextEx(font, textLocal.AsPtr(), fontSize, spacing);
    }

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public int GetGlyphIndex(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphIndex(font, codepoint);
    }

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public GlyphInfo GetGlyphInfo(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphInfo(font, codepoint);
    }

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public Rectangle GetGlyphAtlasRec(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphAtlasRec(font, codepoint);
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public int[] LoadCodepoints(string text, int* count)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadCodepoints(textLocal.AsPtr(), count));
    }

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    public void UnloadCodepoints(int* codepoints)
    {
        /*|  int * => int*  |*/
        Raylib.UnloadCodepoints(codepoints);
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public int GetCodepointCount(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.GetCodepointCount(textLocal.AsPtr());
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public int GetCodepoint(string text, int* bytesProcessed)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int * => int*  |*/
        return Raylib.GetCodepoint(textLocal.AsPtr(), bytesProcessed);
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public string CodepointToUTF8(int codepoint, int* byteSize)
    {
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.Utf8ToString(Raylib.CodepointToUTF8(codepoint, byteSize));
    }

    /// <summary>
    /// Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)
    /// </summary>
    public string TextCodepointsToUTF8(int* codepoints, int length)
    {
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        return (string)Raylib.TextCodepointsToUTF8(codepoints, length);
    }

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    public int TextCopy(string dst, string src)
    {
        /*|  char * => string  |*/
        using var dstLocal = dst.MarshalUtf8();
        /*|  const char * => string  |*/
        using var srcLocal = src.MarshalUtf8();
        return Raylib.TextCopy(dstLocal.AsPtr(), srcLocal.AsPtr());
    }

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    public bool TextIsEqual(string text1, string text2)
    {
        /*|  const char * => string  |*/
        using var text1Local = text1.MarshalUtf8();
        /*|  const char * => string  |*/
        using var text2Local = text2.MarshalUtf8();
        return Raylib.TextIsEqual(text1Local.AsPtr(), text2Local.AsPtr());
    }

    /// <summary>
    /// Get text length, checks for ' 0' ending
    /// </summary>
    public uint TextLength(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return (uint)Raylib.TextLength(textLocal.AsPtr());
    }

    /// <summary>
    /// Text formatting with variables (sprintf() style)
    /// </summary>
    public string TextFormat(string text, params object[] args)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  params object[] => params object[]  |*/
        return Helpers.Utf8ToString(Raylib.TextFormat(textLocal.AsPtr(), args));
    }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    public string TextSubtext(string text, int position, int length)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.TextSubtext(textLocal.AsPtr(), position, length));
    }

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    public string TextReplace(string text, string replace, string by)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var replaceLocal = replace.MarshalUtf8();
        /*|  const char * => string  |*/
        using var byLocal = by.MarshalUtf8();
        return (string)Raylib.TextReplace(textLocal.AsPtr(), replaceLocal.AsPtr(), byLocal.AsPtr());
    }

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    public string TextInsert(string text, string insert, int position)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var insertLocal = insert.MarshalUtf8();
        /*|  int => int  |*/
        return (string)Raylib.TextInsert(textLocal.AsPtr(), insertLocal.AsPtr(), position);
    }

    /// <summary>
    /// Join text strings with delimiter
    /// </summary>
    public string TextJoin(string[] textList, int count, string delimiter)
    {
        /*|  const char ** => string[]  |*/
        /*|  int => int  |*/
        /*|  const char * => string  |*/
        using var delimiterLocal = delimiter.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextJoin(textList, count, delimiterLocal.AsPtr()));
    }

    /// <summary>
    /// Split text into multiple strings
    /// </summary>
    public string[] TextSplit(string text, char delimiter, int* count)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  char => char  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.TextSplit(textLocal.AsPtr(), delimiter, count));
    }

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    public void TextAppend(string text, string append, int* position)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var appendLocal = append.MarshalUtf8();
        /*|  int * => int*  |*/
        Raylib.TextAppend(textLocal.AsPtr(), appendLocal.AsPtr(), position);
    }

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    public int TextFindIndex(string text, string find)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var findLocal = find.MarshalUtf8();
        return Raylib.TextFindIndex(textLocal.AsPtr(), findLocal.AsPtr());
    }

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    public string TextToUpper(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToUpper(textLocal.AsPtr()));
    }

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    public string TextToLower(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToLower(textLocal.AsPtr()));
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public string TextToPascal(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToPascal(textLocal.AsPtr()));
    }

    /// <summary>
    /// Get integer value from text (negative values not supported)
    /// </summary>
    public int TextToInteger(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.TextToInteger(textLocal.AsPtr());
    }

}
#pragma warning restore
