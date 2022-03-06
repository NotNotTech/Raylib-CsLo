#pragma warning disable
namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    public Image LoadImage(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadImage(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public Image LoadImageRaw(string fileName, int width, int height, int format, int headerSize)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.LoadImageRaw(fileNameLocal.AsPtr(), width, height, format, headerSize);
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public Image LoadImageAnim(string fileName, int* frames)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int * => int*  |*/
        return Raylib.LoadImageAnim(fileNameLocal.AsPtr(), frames);
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public Image LoadImageFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        return Raylib.LoadImageFromMemory(fileTypeLocal.AsPtr(), fileDataLocal, dataSize);
    }

    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    public Image LoadImageFromTexture(Texture2D texture)
    {
        /*|  Texture2D => Texture2D  |*/
        return Raylib.LoadImageFromTexture(texture);
    }

    /// <summary>
    /// Load image from screen buffer and (screenshot)
    /// </summary>
    public Image LoadImageFromScreen()
    {
        return Raylib.LoadImageFromScreen();
    }

    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    public void UnloadImage(Image image)
    {
        /*|  Image => Image  |*/
        Raylib.UnloadImage(image);
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public bool ExportImage(Image image, string fileName)
    {
        /*|  Image => Image  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportImage(image, fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public bool ExportImageAsCode(Image image, string fileName)
    {
        /*|  Image => Image  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportImageAsCode(image, fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Generate image: plain color
    /// </summary>
    public Image GenImageColor(int width, int height, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageColor(width, height, color);
    }

    /// <summary>
    /// Generate image: vertical gradient
    /// </summary>
    public Image GenImageGradientV(int width, int height, Color top, Color bottom)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientV(width, height, top, bottom);
    }

    /// <summary>
    /// Generate image: horizontal gradient
    /// </summary>
    public Image GenImageGradientH(int width, int height, Color left, Color right)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientH(width, height, left, right);
    }

    /// <summary>
    /// Generate image: radial gradient
    /// </summary>
    public Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientRadial(width, height, density, inner, outer);
    }

    /// <summary>
    /// Generate image: checked
    /// </summary>
    public Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageChecked(width, height, checksX, checksY, col1, col2);
    }

    /// <summary>
    /// Generate image: white noise
    /// </summary>
    public Image GenImageWhiteNoise(int width, int height, float factor)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        return Raylib.GenImageWhiteNoise(width, height, factor);
    }

    /// <summary>
    /// Generate image: cellular algorithm, bigger tileSize means bigger cells
    /// </summary>
    public Image GenImageCellular(int width, int height, int tileSize)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenImageCellular(width, height, tileSize);
    }

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    public Image ImageCopy(Image image)
    {
        /*|  Image => Image  |*/
        return Raylib.ImageCopy(image);
    }

    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    public Image ImageFromImage(Image image, Rectangle rec)
    {
        /*|  Image => Image  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.ImageFromImage(image, rec);
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public Image ImageText(string text, int fontSize, Color color)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        return Raylib.ImageText(textLocal.AsPtr(), fontSize, color);
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        return Raylib.ImageTextEx(font, textLocal.AsPtr(), fontSize, spacing, tint);
    }

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    public void ImageFormat(Image* image, int newFormat)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        Raylib.ImageFormat(image, newFormat);
    }

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    public void ImageToPOT(Image* image, Color fill)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageToPOT(image, fill);
    }

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    public void ImageCrop(Image* image, Rectangle crop)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        Raylib.ImageCrop(image, crop);
    }

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    public void ImageAlphaCrop(Image* image, float threshold)
    {
        /*|  Image * => Image*  |*/
        /*|  float => float  |*/
        Raylib.ImageAlphaCrop(image, threshold);
    }

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    public void ImageAlphaClear(Image* image, Color color, float threshold)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        Raylib.ImageAlphaClear(image, color, threshold);
    }

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    public void ImageAlphaMask(Image* image, Image alphaMask)
    {
        /*|  Image * => Image*  |*/
        /*|  Image => Image  |*/
        Raylib.ImageAlphaMask(image, alphaMask);
    }

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    public void ImageAlphaPremultiply(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageAlphaPremultiply(image);
    }

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    public void ImageResize(Image* image, int newWidth, int newHeight)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageResize(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public void ImageResizeNN(Image* image, int newWidth, int newHeight)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageResizeNN(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    public void ImageResizeCanvas(Image* image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageResizeCanvas(image, newWidth, newHeight, offsetX, offsetY, fill);
    }

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    public void ImageMipmaps(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageMipmaps(image);
    }

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public void ImageDither(Image* image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageDither(image, rBpp, gBpp, bBpp, aBpp);
    }

    /// <summary>
    /// Flip image vertically
    /// </summary>
    public void ImageFlipVertical(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageFlipVertical(image);
    }

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    public void ImageFlipHorizontal(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageFlipHorizontal(image);
    }

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    public void ImageRotateCW(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageRotateCW(image);
    }

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    public void ImageRotateCCW(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageRotateCCW(image);
    }

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    public void ImageColorTint(Image* image, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageColorTint(image, color);
    }

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    public void ImageColorInvert(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageColorInvert(image);
    }

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    public void ImageColorGrayscale(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageColorGrayscale(image);
    }

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    public void ImageColorContrast(Image* image, float contrast)
    {
        /*|  Image * => Image*  |*/
        /*|  float => float  |*/
        Raylib.ImageColorContrast(image, contrast);
    }

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    public void ImageColorBrightness(Image* image, int brightness)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        Raylib.ImageColorBrightness(image, brightness);
    }

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    public void ImageColorReplace(Image* image, Color color, Color replace)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.ImageColorReplace(image, color, replace);
    }

    /// <summary>
    /// Load color data from image as a Color array (RGBA - 32bit)
    /// </summary>
    public Color[] LoadImageColors(Image image)
    {
        /*|  Image => Image  |*/
        return Helpers.PrtToArray(Raylib.LoadImageColors(image));
    }

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    public Color[] LoadImagePalette(Image image, int maxPaletteSize, int* colorCount)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadImagePalette(image, maxPaletteSize, colorCount));
    }

    /// <summary>
    /// Unload color data loaded with LoadImageColors()
    /// </summary>
    public void UnloadImageColors(Color* colors)
    {
        /*|  Color * => Color*  |*/
        Raylib.UnloadImageColors(colors);
    }

    /// <summary>
    /// Unload colors palette loaded with LoadImagePalette()
    /// </summary>
    public void UnloadImagePalette(Color* colors)
    {
        /*|  Color * => Color*  |*/
        Raylib.UnloadImagePalette(colors);
    }

    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    public Rectangle GetImageAlphaBorder(Image image, float threshold)
    {
        /*|  Image => Image  |*/
        /*|  float => float  |*/
        return Raylib.GetImageAlphaBorder(image, threshold);
    }

    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    public Color GetImageColor(Image image, int x, int y)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetImageColor(image, x, y);
    }

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    public void ImageClearBackground(Image* dst, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageClearBackground(dst, color);
    }

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    public void ImageDrawPixel(Image* dst, int posX, int posY, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawPixel(dst, posX, posY, color);
    }

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    public void ImageDrawPixelV(Image* dst, Vector2 position, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawPixelV(dst, position, color);
    }

    /// <summary>
    /// Draw line within an image
    /// </summary>
    public void ImageDrawLine(Image* dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawLine(dst, startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    public void ImageDrawLineV(Image* dst, Vector2 start, Vector2 end, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawLineV(dst, start, end, color);
    }

    /// <summary>
    /// Draw circle within an image
    /// </summary>
    public void ImageDrawCircle(Image* dst, int centerX, int centerY, int radius, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawCircle(dst, centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw circle within an image (Vector version)
    /// </summary>
    public void ImageDrawCircleV(Image* dst, Vector2 center, int radius, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawCircleV(dst, center, radius, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public void ImageDrawRectangle(Image* dst, int posX, int posY, int width, int height, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangle(dst, posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    public void ImageDrawRectangleV(Image* dst, Vector2 position, Vector2 size, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleV(dst, position, size, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public void ImageDrawRectangleRec(Image* dst, Rectangle rec, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleRec(dst, rec, color);
    }

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    public void ImageDrawRectangleLines(Image* dst, Rectangle rec, int thick, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleLines(dst, rec, thick, color);
    }

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public void ImageDraw(Image* dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        /*|  Image * => Image*  |*/
        /*|  Image => Image  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDraw(dst, src, srcRec, dstRec, tint);
    }

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    public void ImageDrawText(Image* dst, string text, int posX, int posY, int fontSize, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawText(dst, textLocal.AsPtr(), posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public void ImageDrawTextEx(Image* dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        /*|  Image * => Image*  |*/
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawTextEx(dst, font, textLocal.AsPtr(), position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public Texture2D LoadTexture(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadTexture(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load texture from image data
    /// </summary>
    public Texture2D LoadTextureFromImage(Image image)
    {
        /*|  Image => Image  |*/
        return Raylib.LoadTextureFromImage(image);
    }

    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    public TextureCubemap LoadTextureCubemap(Image image, int layout)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        return Raylib.LoadTextureCubemap(image, layout);
    }

    /// <summary>
    /// Load texture for rendering (framebuffer)
    /// </summary>
    public RenderTexture2D LoadRenderTexture(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.LoadRenderTexture(width, height);
    }

    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    public void UnloadTexture(Texture2D texture)
    {
        /*|  Texture2D => Texture2D  |*/
        Raylib.UnloadTexture(texture);
    }

    /// <summary>
    /// Unload render texture from GPU memory (VRAM)
    /// </summary>
    public void UnloadRenderTexture(RenderTexture2D target)
    {
        /*|  RenderTexture2D => RenderTexture2D  |*/
        Raylib.UnloadRenderTexture(target);
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public void UpdateTexture(Texture2D texture, IntPtr pixels)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  const void * => IntPtr  |*/
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTexture(texture, pixelsLocal);
    }

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    public void UpdateTextureRec(Texture2D texture, Rectangle rec, IntPtr pixels)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  const void * => IntPtr  |*/
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTextureRec(texture, rec, pixelsLocal);
    }

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    public void GenTextureMipmaps(Texture2D* texture)
    {
        /*|  Texture2D * => Texture2D*  |*/
        Raylib.GenTextureMipmaps(texture);
    }

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    public void SetTextureFilter(Texture2D texture, int filter)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        Raylib.SetTextureFilter(texture, filter);
    }

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    public void SetTextureWrap(Texture2D texture, int wrap)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        Raylib.SetTextureWrap(texture, wrap);
    }

    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    public void DrawTexture(Texture2D texture, int posX, int posY, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexture(texture, posX, posY, tint);
    }

    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    public void DrawTextureV(Texture2D texture, Vector2 position, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureV(texture, position, tint);
    }

    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    public void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    public void DrawTextureRec(Texture2D texture, Rectangle source, Vector2 position, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureRec(texture, source, position, tint);
    }

    /// <summary>
    /// Draw texture quad with tiling and offset parameters
    /// </summary>
    public void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureQuad(texture, tiling, offset, quad, tint);
    }

    /// <summary>
    /// Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.
    /// </summary>
    public void DrawTextureTiled(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureTiled(texture, source, dest, origin, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    public void DrawTexturePro(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    public void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  NPatchInfo => NPatchInfo  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draw a textured polygon
    /// </summary>
    public void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2* points, Vector2* texcoords, int pointCount, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 * => Vector2*  |*/
        /*|  Vector2 * => Vector2*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexturePoly(texture, center, points, texcoords, pointCount, tint);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public Color Fade(Color color, float alpha)
    {
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        return Raylib.Fade(color, alpha);
    }

    /// <summary>
    /// Get hexadecimal value for a Color
    /// </summary>
    public int ColorToInt(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorToInt(color);
    }

    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    public Vector4 ColorNormalize(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorNormalize(color);
    }

    /// <summary>
    /// Get Color from normalized values [0..1]
    /// </summary>
    public Color ColorFromNormalized(Vector4 normalized)
    {
        /*|  Vector4 => Vector4  |*/
        return Raylib.ColorFromNormalized(normalized);
    }

    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    public Vector3 ColorToHSV(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorToHSV(color);
    }

    /// <summary>
    /// Get a Color from HSV values, hue [0..360], saturation/value [0..1]
    /// </summary>
    public Color ColorFromHSV(float hue, float saturation, float value)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.ColorFromHSV(hue, saturation, value);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public Color ColorAlpha(Color color, float alpha)
    {
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        return Raylib.ColorAlpha(color, alpha);
    }

    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    public Color ColorAlphaBlend(Color dst, Color src, Color tint)
    {
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.ColorAlphaBlend(dst, src, tint);
    }

    /// <summary>
    /// Get Color structure from hexadecimal value
    /// </summary>
    public Color GetColor(uint hexValue)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.GetColor(hexValue);
    }

    /// <summary>
    /// Get Color from a source pixel pointer of certain format
    /// </summary>
    public Color GetPixelColor(IntPtr srcPtr, int format)
    {
        /*|  void * => IntPtr  |*/
        var srcPtrLocal = (void*)srcPtr;
        /*|  int => int  |*/
        return Raylib.GetPixelColor(srcPtrLocal, format);
    }

    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    public void SetPixelColor(IntPtr dstPtr, Color color, int format)
    {
        /*|  void * => IntPtr  |*/
        var dstPtrLocal = (void*)dstPtr;
        /*|  Color => Color  |*/
        /*|  int => int  |*/
        Raylib.SetPixelColor(dstPtrLocal, color, format);
    }

    /// <summary>
    /// Get pixel data size in bytes for certain format
    /// </summary>
    public int GetPixelDataSize(int width, int height, int format)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetPixelDataSize(width, height, format);
    }

}
#pragma warning restore
