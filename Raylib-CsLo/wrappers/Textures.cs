// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

public unsafe partial class RaylibS
{
    /// <summary> Load color data from image as a Color array (RGBA - 32bit) </summary>
    public static Color[] LoadImageColors(Image image)
    {
        Color* nativeColorArray = Raylib.LoadImageColors(image);
        Color[] toReturn = Helpers.CopyPtrToArray(nativeColorArray, image.width * image.height);
        Raylib.UnloadImageColors(nativeColorArray);
        return toReturn;
    }

    /// <summary> Load colors palette from image as a Color array (RGBA - 32bit) </summary>
    public static Color[] LoadImagePalette(Image image, int maxPaletteSize, ref int colorCount)
    {
        fixed (int* colorCount_ = &colorCount)
        {
            return Helpers.CopyPtrToArray(Raylib.LoadImagePalette(image, maxPaletteSize, colorCount_), maxPaletteSize);
        }
    }

    /// <summary> Update GPU texture with new data </summary>
    public static void UpdateTexture(Texture2D texture, Color[] pixels)
    {
        fixed (void* pixels_ = pixels)
        {
            Raylib.UpdateTexture(texture, pixels_);
        }
    }

    /// <summary> Update GPU texture rectangle with new data </summary>
    public static void UpdateTextureRec(Texture2D texture, Rectangle rec, Color[] pixels)
    {
        fixed (void* pixels_ = pixels)
        {
            Raylib.UpdateTextureRec(texture, rec, pixels_);
        }
    }
}
