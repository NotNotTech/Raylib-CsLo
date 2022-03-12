// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

#pragma warning disable IDE0008

// TODO organzie into the correct modules im just throwing them all cause lazy
public unsafe partial class RaylibS
{

    public static void TraceLog(int logLevel, string text)
    {
        TraceLog(logLevel, text);
    }

    public static void TraceLog(TraceLogLevel logLevel, string text, params object[] args)
    {
        text = text.SPrintF(args);
        TraceLog((int)logLevel, text);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(string text, float posX, float posY, int fontSize, Color color)
    {
        using var text_ = text.MarshalUtf8();
        Raylib.DrawText(text_.AsPtr(), (int)posX, (int)posY, fontSize, color);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream(AudioStream stream, Span<short> data, int frameCount)
    {
        fixed (short* writeBufPtr = data)
        {
            UpdateAudioStream(stream, writeBufPtr, frameCount);
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
    /// Set shader uniform value
    /// </summary>
    public static void SetShaderValue(Shader shader, int locIndex, void* value, ShaderUniformDataType uniformType)
    {
        Raylib.SetShaderValue(shader, locIndex, value, (int)uniformType);
    }

    public static string TextFormat(string format, params object[] args)
    {
        return format.SPrintF(args);
    }

    //public static void SetShaderValue(Shader shader, int locIndex, float* value, ShaderUniformDataType uniformType) => SetShaderValue(shader, locIndex, value, (int)uniformType);
    public static void SetShaderValue<T>(Shader shader, int locIndex, T* value, ShaderUniformDataType uniformType) where T : unmanaged
    {
        SetShaderValue(shader, locIndex, value, (int)uniformType);
    }


    public static void SetShaderValue<T>(Shader shader, int uniformLoc, T value, ShaderUniformDataType uniformType) where T : unmanaged
    {
        SetShaderValue(shader, uniformLoc, &value, (int)uniformType);
    }

    public static void SetShaderValue<T>(Shader shader, int uniformLoc, T[] values, ShaderUniformDataType uniformType) where T : unmanaged
    {
        SetShaderValue(shader, uniformLoc, (Span<T>)values, uniformType);
    }
    public static void SetShaderValue<T>(Shader shader, int uniformLoc, Span<T> values, ShaderUniformDataType uniformType) where T : unmanaged
    {
        fixed (T* valuePtr = values)
        {
            SetShaderValue(shader, uniformLoc, valuePtr, (int)uniformType);
        }
    }

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    public static Gesture GetGestureDetected()
    {
        return (Gesture)Raylib.GetGestureDetected();
    }

    /// <summary>
    /// 'vector' (array) version of this function.
    /// </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, Span<T> values, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = values)
        {
            SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    /// <summary>
    /// 'vector' (array) version of this function.  can pass a `ref` to an arrayItem instead of the entire array
    /// </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, ref T arrayOffset, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = &arrayOffset)
        {
            SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    public static string[] GetDroppedFiles()
    {
        int count;
        sbyte** buffer = Raylib.GetDroppedFiles(&count);
        string[]? files = new string[count];

        for (int i = 0; i < count; i++)
        {
            files[i] = Helpers.Utf8ToString(buffer[i]);
        }

        return files;
    }

    public static string[] GetDroppedFilesAndClear()
    {
        string[]? files = GetDroppedFiles();
        ClearDroppedFiles();
        return files;
    }

    public static byte* LoadFileData(string fileName, out uint bytesRead)
    {
        using SpanOwner<sbyte> soFilename = fileName.MarshalUtf8();
        uint output;
        byte* toReturn = Raylib.LoadFileData(soFilename.AsPtr(), &output);
        bytesRead = output;
        return toReturn;

    }
}
#pragma warning restore IDE0008
