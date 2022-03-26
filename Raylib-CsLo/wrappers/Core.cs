// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Microsoft.Toolkit.HighPerformance.Buffers;

// TODO organzie into the correct modules im just throwing them all cause lazy
public unsafe partial class RaylibS
{
    /// <summary> Get dropped files names (memory should be freed) </summary>
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

    /// <summary> Get dropped files names and clear them (memory should be freed) </summary>
    public static string[] GetDroppedFilesAndClear()
    {
        string[] files = GetDroppedFiles();
        ClearDroppedFiles();
        return files;
    }

    /// <summary> Get latest detected gesture </summary>
    public static Gesture GetGestureDetected()
    {
        return (Gesture)Raylib.GetGestureDetected();
    }

    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(int logLevel, string text, params object[] args)
    {
        using SpanOwner<sbyte> text_ = text.MarshalUtf8();
        Raylib.TraceLog(logLevel, text_.AsPtr(), __arglist(args));
    }

    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(TraceLogLevel logLevel, string text, params object[] args)
    {
        using SpanOwner<sbyte> text_ = text.MarshalUtf8();
        Raylib.TraceLog((int)logLevel, text_.AsPtr(), __arglist(args));
    }

    /// <summary> Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...) </summary>
    public static void TraceLog(TraceLogLevel logLevel, string text)
    {
        using SpanOwner<sbyte> text_ = text.MarshalUtf8();
        Raylib.TraceLog((int)logLevel, text_.AsPtr(), __arglist());
    }

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

    /// <summary> 'vector' (array) version of this function. </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, Span<T> values, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = values)
        {
            Raylib.SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    /// <summary> 'vector' (array) version of this function.  can pass a `ref` to an arrayItem instead of the entire array </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, ref T arrayOffset, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = &arrayOffset)
        {
            Raylib.SetShaderValueV(shader, locIndex, p_array, (int)uniformType, count);
        }
    }

    /// <summary> Load fragment shader from files and bind default locations </summary>
    public static Shader LoadFShader(string fsFileName)
    {
        using SpanOwner<sbyte> fsFileName_ = fsFileName.MarshalUtf8();
        return Raylib.LoadShader(null, fsFileName_.AsPtr());
    }

    /// <summary> Load vertex shader from files and bind default locations </summary>
    public static Shader LoadVShader(string vsFileName)
    {
        using SpanOwner<sbyte> vsFileName_ = vsFileName.MarshalUtf8();
        return Raylib.LoadShader(vsFileName_.AsPtr(), null);
    }

    /// <summary> Draw text (using default font) </summary>
    public static void DrawText(string text, float posX, float posY, int fontSize, Color color)
    {
        using SpanOwner<sbyte> text_ = text.MarshalUtf8();
        Raylib.DrawText(text_.AsPtr(), (int)posX, (int)posY, fontSize, color);
    }
}
