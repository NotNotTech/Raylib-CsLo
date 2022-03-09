// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo;

using Raylib_CsLo.autogen.bindings;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class Raylib
{
    // TODO use inheriddoc for comments

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
    /// Setup init configuration flags (view FLAGS)
    /// </summary>
    public static void SetConfigFlags(ConfigFlags flags)
    {
        SetConfigFlags((uint)flags);
    }

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    public static bool IsKeyPressed(KeyboardKey key)
    {
        return IsKeyPressed((int)key);
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public static bool IsKeyDown(KeyboardKey key)
    {
        return IsKeyDown((int)key);
    }

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    public static void SetTextureFilter(Texture2D texture, TextureFilter filter)
    {
        SetTextureFilter(texture, (int)filter);
    }

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    public static void SetTextureWrap(Texture2D texture, TextureWrap wrap)
    {
        SetTextureWrap(texture, (int)wrap);
    }

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    public static bool IsMouseButtonDown(MouseButton button)
    {
        return IsMouseButtonDown((int)button);
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
    /// Check if a gesture have been detected
    /// </summary>
    public static bool IsGestureDetected(Gesture gesture)
    {
        return IsGestureDetected((int)gesture);
    }

    /// <summary>
    /// Set camera mode (multiple camera modes available)
    /// </summary>
    public static void SetCameraMode(Camera camera, CameraMode mode)
    {
        SetCameraMode(camera, (int)mode);
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetShaderValueV<T>(Shader shader, int locIndex, ref T arrayOffset, ShaderUniformDataType uniformType, int count) where T : unmanaged
    {
        fixed (T* p_array = &arrayOffset)
        {
            SetShaderValueV(shader, locIndex, (IntPtr)p_array, (int)uniformType, count);
        }
    }
}
