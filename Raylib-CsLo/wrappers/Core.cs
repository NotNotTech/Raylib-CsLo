// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Microsoft.Toolkit.HighPerformance.Buffers;

#pragma warning disable IDE0008

// TODO organzie into the correct modules im just throwing them all cause lazy
public unsafe partial class RaylibS
{
    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(int logLevel, string text, params object[] args)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.TraceLog(logLevel, text_.AsPtr(), __arglist(args));
    }

    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(TraceLogLevel logLevel, string text, params object[] args)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.TraceLog((int)logLevel, text_.AsPtr(), __arglist(args));
    }

    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(TraceLogLevel logLevel, string text)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.TraceLog((int)logLevel, text_.AsPtr(), __arglist());
    }

    /// <summary> Set mouse position XY </summary>
    public static void SetMousePosition(Vector2 position)
    {
        Raylib.SetMousePosition((int)position.X, (int)position.Y);
    }

    /// <summary> Set mouse offset </summary>
    public static void SetMouseOffset(Vector2 offset)
    {
        Raylib.SetMouseOffset((int)offset.X, (int)offset.Y);
    }

    /// <summary> Set mouse scaling </summary>
    public static void SetMouseScale(Vector2 scale)
    {
        Raylib.SetMouseScale(scale.X, scale.Y);
    }

    /// <summary>
    /// Text formatting with variables (sprintf() style)
    /// </summary>
    public static string TextFormat(string format, params object[] args)
    {
        return format.SPrintF(args);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream(AudioStream stream, Span<short> data, int frameCount)
    {
        fixed (short* data_ = data)
        {
            Raylib.UpdateAudioStream(stream, data_, frameCount);
        }
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public static bool IsKeyDown(char key)
    {
        return Raylib.IsKeyDown(key);
    }

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    public static Gesture GetGestureDetected()
    {
        return (Gesture)Raylib.GetGestureDetected();
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(string text, float posX, float posY, int fontSize, Color color)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.DrawText(text_.AsPtr(), (int)posX, (int)posY, fontSize, color);
    }
    //public static void SetShaderValue(Shader shader, int locIndex, float* value, ShaderUniformDataType uniformType) => SetShaderValue(shader, locIndex, value, (int)uniformType);
    public static void SetShaderValue<T>(Shader shader, int locIndex, T* value, ShaderUniformDataType uniformType) where T : unmanaged
    {
        Raylib.SetShaderValue(shader, locIndex, value, (int)uniformType);
    }

    public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, ref T value, ShaderUniformDataType uniformType) where T : unmanaged
    {
        fixed (T* valuePtr = &value)
        {
            Raylib.SetShaderValue(shader, uniformLoc, valuePtr, (int)uniformType);
        }
    }
    public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType) where T : unmanaged
    {
        Raylib.SetShaderValue(shader, uniformLoc, &value, (int)uniformType);
    }

    public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType) where T : unmanaged
    {
        SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
    }

    public static unsafe void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType) where T : unmanaged
    {
        fixed (T* valuePtr = values)
        {
            Raylib.SetShaderValue(shader, uniformLoc, valuePtr, (int)uniformType);
        }
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void UpdateCamera(ref Camera3D camera)
    {
        fixed (Camera3D* ptr = &camera)
        {
            Raylib.UpdateCamera(ptr);
        }
    }

    /// <summary>
    /// 'vector' (array) version of this function.
    /// </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, Span<T> values, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = values)
        {
            Raylib.SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    /// <summary>
    /// 'vector' (array) version of this function.  can pass a `ref` to an arrayItem instead of the entire array
    /// </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, ref T arrayOffset, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = &arrayOffset)
        {
            Raylib.SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    public static string[] GetDroppedFiles()
    {
        int count;
        sbyte** buffer = Raylib.GetDroppedFiles(&count);
        string[] files = new string[count];

        for (int i = 0; i < count; i++)
        {
            files[i] = Helpers.Utf8ToString(buffer[i]);
        }

        return files;
    }

    public static string[] GetDroppedFilesAndClear()
    {
        string[] files = GetDroppedFiles();
        ClearDroppedFiles();
        return files;
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(char stringChar, out int bytesProcessed)
    {
        sbyte charSbyte = (sbyte)stringChar;
        int byteCount = 0;
        int toReturn = Raylib.GetCodepoint(&charSbyte, &byteCount);
        bytesProcessed = byteCount;
        return toReturn;
    }

    /// <summary>
    /// Load file data as byte array (read)
    /// </summary>
    public static byte* LoadFileData(string fileName, out uint bytesRead)
    {
        using SpanOwner<sbyte> soFilename = fileName.MarshalUtf8();
        uint output;
        byte* toReturn = Raylib.LoadFileData(soFilename.AsPtr(), &output);
        bytesRead = output;
        return toReturn;
    }

    /// <summary>
    /// Load fragment shader from files and bind default locations
    /// </summary>
    public static Shader LoadFShader(string fsFileName)
    {
        using var fsFileName_ = fsFileName.MarshalUtf8();
        return Raylib.LoadShader(null, fsFileName_.AsPtr());
    }

    /// <summary>
    /// Load vertex shader from files and bind default locations
    /// </summary>
    public static Shader LoadVShader(string vsFileName)
    {
        using var vsFileName_ = vsFileName.MarshalUtf8();
        return Raylib.LoadShader(vsFileName_.AsPtr(), null);
    }

    /// <summary>
    /// free animations via UnloadModelAnimation() when done
    /// </summary>
    public static ModelAnimation[] LoadModelAnimations(string fileName)
    {
        using SpanOwner<sbyte> soFileName = fileName.MarshalUtf8();
        uint count;
        ModelAnimation* p_animations = Raylib.LoadModelAnimations(soFileName.AsPtr(), &count);
        ModelAnimation[] toReturn = new ModelAnimation[count];
        for (int i = 0; i < count; i++)
        {
            toReturn[i] = p_animations[i];
        }
        //this ptr isn't needed.
        Raylib.MemFree(p_animations);
        return toReturn;
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public static void UpdateTexture(Texture2D texture, Color[] pixels)
    {
        fixed (void* pixels_ = pixels)
        {
            Raylib.UpdateTexture(texture, pixels_);
        }
    }

    /// <summary> Load color data from image as a Color array (RGBA - 32bit) </summary>
    public static Color[] LoadImageColors(Image image)
    {
        var nativeColorArray = Raylib.LoadImageColors(image);
        var toReturn = Helpers.CopyPtrToArray(nativeColorArray, image.width * image.height);
        Raylib.UnloadImageColors(nativeColorArray);
        return toReturn;
    }
}
#pragma warning restore IDE0008
