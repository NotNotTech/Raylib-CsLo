// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

#pragma warning disable

namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Initialize window and OpenGL context
    /// </summary>
    public static void InitWindow(/* int */ int width, /* int */ int height, /* const char* */ string title)
    {
        // int => int
        // int => int
        // sbyte* => string
        using var title_ = title.MarshalUtf8();
        // return void => void
        Raylib.InitWindow(width, height, title_.AsPtr());
    }

    /// <summary>
    /// Check if KEY_ESCAPE pressed or Close icon pressed
    /// </summary>
    public static bool WindowShouldClose()
    {
        // return bool => bool
        return Raylib.WindowShouldClose();
    }

    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    public static void CloseWindow()
    {
        // return void => void
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    public static bool IsWindowReady()
    {
        // return bool => bool
        return Raylib.IsWindowReady();
    }

    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    public static bool IsWindowFullscreen()
    {
        // return bool => bool
        return Raylib.IsWindowFullscreen();
    }

    /// <summary>
    /// Check if window is currently hidden (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowHidden()
    {
        // return bool => bool
        return Raylib.IsWindowHidden();
    }

    /// <summary>
    /// Check if window is currently minimized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMinimized()
    {
        // return bool => bool
        return Raylib.IsWindowMinimized();
    }

    /// <summary>
    /// Check if window is currently maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMaximized()
    {
        // return bool => bool
        return Raylib.IsWindowMaximized();
    }

    /// <summary>
    /// Check if window is currently focused (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowFocused()
    {
        // return bool => bool
        return Raylib.IsWindowFocused();
    }

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    public static bool IsWindowResized()
    {
        // return bool => bool
        return Raylib.IsWindowResized();
    }

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    public static bool IsWindowState(/* unsigned int */ uint flag)
    {
        // uint => uint
        // return bool => bool
        return Raylib.IsWindowState(flag);
    }

    /// <summary>
    /// Set window configuration state using flags (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowState(/* unsigned int */ uint flags)
    {
        // uint => uint
        // return void => void
        Raylib.SetWindowState(flags);
    }

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    public static void ClearWindowState(/* unsigned int */ uint flags)
    {
        // uint => uint
        // return void => void
        Raylib.ClearWindowState(flags);
    }

    /// <summary>
    /// Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)
    /// </summary>
    public static void ToggleFullscreen()
    {
        // return void => void
        Raylib.ToggleFullscreen();
    }

    /// <summary>
    /// Set window state: maximized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MaximizeWindow()
    {
        // return void => void
        Raylib.MaximizeWindow();
    }

    /// <summary>
    /// Set window state: minimized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MinimizeWindow()
    {
        // return void => void
        Raylib.MinimizeWindow();
    }

    /// <summary>
    /// Set window state: not minimized/maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static void RestoreWindow()
    {
        // return void => void
        Raylib.RestoreWindow();
    }

    /// <summary>
    /// Set icon for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowIcon(/* Image */ Image image)
    {
        // Image => Image
        // return void => void
        Raylib.SetWindowIcon(image);
    }

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowTitle(/* const char* */ string title)
    {
        // sbyte* => string
        using var title_ = title.MarshalUtf8();
        // return void => void
        Raylib.SetWindowTitle(title_.AsPtr());
    }

    /// <summary>
    /// Set window position on screen (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowPosition(/* int */ int x, /* int */ int y)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.SetWindowPosition(x, y);
    }

    /// <summary>
    /// Set monitor for the current window (fullscreen mode)
    /// </summary>
    public static void SetWindowMonitor(/* int */ int monitor)
    {
        // int => int
        // return void => void
        Raylib.SetWindowMonitor(monitor);
    }

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    public static void SetWindowMinSize(/* int */ int width, /* int */ int height)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.SetWindowMinSize(width, height);
    }

    /// <summary>
    /// Set window dimensions
    /// </summary>
    public static void SetWindowSize(/* int */ int width, /* int */ int height)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.SetWindowSize(width, height);
    }

    /// <summary>
    /// Set window opacity [0.0f..1.0f] (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowOpacity(/* float */ float opacity)
    {
        // float => float
        // return void => void
        Raylib.SetWindowOpacity(opacity);
    }

    /// <summary>
    /// Get native window handle
    /// </summary>
    public static IntPtr GetWindowHandle()
    {
        // return void* => IntPtr
        return (IntPtr)Raylib.GetWindowHandle();
    }

    /// <summary>
    /// Get current screen width
    /// </summary>
    public static int GetScreenWidth()
    {
        // return int => int
        return Raylib.GetScreenWidth();
    }

    /// <summary>
    /// Get current screen height
    /// </summary>
    public static int GetScreenHeight()
    {
        // return int => int
        return Raylib.GetScreenHeight();
    }

    /// <summary>
    /// Get current render width (it considers HiDPI)
    /// </summary>
    public static int GetRenderWidth()
    {
        // return int => int
        return Raylib.GetRenderWidth();
    }

    /// <summary>
    /// Get current render height (it considers HiDPI)
    /// </summary>
    public static int GetRenderHeight()
    {
        // return int => int
        return Raylib.GetRenderHeight();
    }

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    public static int GetMonitorCount()
    {
        // return int => int
        return Raylib.GetMonitorCount();
    }

    /// <summary>
    /// Get current connected monitor
    /// </summary>
    public static int GetCurrentMonitor()
    {
        // return int => int
        return Raylib.GetCurrentMonitor();
    }

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    public static Vector2 GetMonitorPosition(/* int */ int monitor)
    {
        // int => int
        // return Vector2 => Vector2
        return Raylib.GetMonitorPosition(monitor);
    }

    /// <summary>
    /// Get specified monitor width (max available by monitor)
    /// </summary>
    public static int GetMonitorWidth(/* int */ int monitor)
    {
        // int => int
        // return int => int
        return Raylib.GetMonitorWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor height (max available by monitor)
    /// </summary>
    public static int GetMonitorHeight(/* int */ int monitor)
    {
        // int => int
        // return int => int
        return Raylib.GetMonitorHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    public static int GetMonitorPhysicalWidth(/* int */ int monitor)
    {
        // int => int
        // return int => int
        return Raylib.GetMonitorPhysicalWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    public static int GetMonitorPhysicalHeight(/* int */ int monitor)
    {
        // int => int
        // return int => int
        return Raylib.GetMonitorPhysicalHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    public static int GetMonitorRefreshRate(/* int */ int monitor)
    {
        // int => int
        // return int => int
        return Raylib.GetMonitorRefreshRate(monitor);
    }

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    public static Vector2 GetWindowPosition()
    {
        // return Vector2 => Vector2
        return Raylib.GetWindowPosition();
    }

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    public static Vector2 GetWindowScaleDPI()
    {
        // return Vector2 => Vector2
        return Raylib.GetWindowScaleDPI();
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the primary monitor
    /// </summary>
    public static string GetMonitorName(/* int */ int monitor)
    {
        // int => int
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetMonitorName(monitor));
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public static void SetClipboardText(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return void => void
        Raylib.SetClipboardText(text_.AsPtr());
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public static string GetClipboardText()
    {
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetClipboardText());
    }

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    public static void SwapScreenBuffer()
    {
        // return void => void
        Raylib.SwapScreenBuffer();
    }

    /// <summary>
    /// Register all input events
    /// </summary>
    public static void PollInputEvents()
    {
        // return void => void
        Raylib.PollInputEvents();
    }

    /// <summary>
    /// Wait for some milliseconds (halt program execution)
    /// </summary>
    public static void WaitTime(/* float */ float ms)
    {
        // float => float
        // return void => void
        Raylib.WaitTime(ms);
    }

    /// <summary>
    /// Shows cursor
    /// </summary>
    public static void ShowCursor()
    {
        // return void => void
        Raylib.ShowCursor();
    }

    /// <summary>
    /// Hides cursor
    /// </summary>
    public static void HideCursor()
    {
        // return void => void
        Raylib.HideCursor();
    }

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    public static bool IsCursorHidden()
    {
        // return bool => bool
        return Raylib.IsCursorHidden();
    }

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    public static void EnableCursor()
    {
        // return void => void
        Raylib.EnableCursor();
    }

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    public static void DisableCursor()
    {
        // return void => void
        Raylib.DisableCursor();
    }

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    public static bool IsCursorOnScreen()
    {
        // return bool => bool
        return Raylib.IsCursorOnScreen();
    }

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    public static void ClearBackground(/* Color */ Color color)
    {
        // Color => Color
        // return void => void
        Raylib.ClearBackground(color);
    }

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    public static void BeginDrawing()
    {
        // return void => void
        Raylib.BeginDrawing();
    }

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    public static void EndDrawing()
    {
        // return void => void
        Raylib.EndDrawing();
    }

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    public static void BeginMode2D(/* Camera2D */ Camera2D camera)
    {
        // Camera2D => Camera2D
        // return void => void
        Raylib.BeginMode2D(camera);
    }

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    public static void EndMode2D()
    {
        // return void => void
        Raylib.EndMode2D();
    }

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public static void BeginMode3D(/* Camera3D */ Camera3D camera)
    {
        // Camera3D => Camera3D
        // return void => void
        Raylib.BeginMode3D(camera);
    }

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public static void EndMode3D()
    {
        // return void => void
        Raylib.EndMode3D();
    }

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    public static void BeginTextureMode(/* RenderTexture2D */ RenderTexture target)
    {
        // RenderTexture => RenderTexture
        // return void => void
        Raylib.BeginTextureMode(target);
    }

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    public static void EndTextureMode()
    {
        // return void => void
        Raylib.EndTextureMode();
    }

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    public static void BeginShaderMode(/* Shader */ Shader shader)
    {
        // Shader => Shader
        // return void => void
        Raylib.BeginShaderMode(shader);
    }

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    public static void EndShaderMode()
    {
        // return void => void
        Raylib.EndShaderMode();
    }

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    public static void BeginBlendMode(/* int */ int mode)
    {
        // int => int
        // return void => void
        Raylib.BeginBlendMode(mode);
    }

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    public static void EndBlendMode()
    {
        // return void => void
        Raylib.EndBlendMode();
    }

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    public static void BeginScissorMode(/* int */ int x, /* int */ int y, /* int */ int width, /* int */ int height)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // return void => void
        Raylib.BeginScissorMode(x, y, width, height);
    }

    /// <summary>
    /// End scissor mode
    /// </summary>
    public static void EndScissorMode()
    {
        // return void => void
        Raylib.EndScissorMode();
    }

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    public static void BeginVrStereoMode(/* VrStereoConfig */ VrStereoConfig config)
    {
        // VrStereoConfig => VrStereoConfig
        // return void => void
        Raylib.BeginVrStereoMode(config);
    }

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    public static void EndVrStereoMode()
    {
        // return void => void
        Raylib.EndVrStereoMode();
    }

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    public static VrStereoConfig LoadVrStereoConfig(/* VrDeviceInfo */ VrDeviceInfo device)
    {
        // VrDeviceInfo => VrDeviceInfo
        // return VrStereoConfig => VrStereoConfig
        return Raylib.LoadVrStereoConfig(device);
    }

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    public static void UnloadVrStereoConfig(/* VrStereoConfig */ VrStereoConfig config)
    {
        // VrStereoConfig => VrStereoConfig
        // return void => void
        Raylib.UnloadVrStereoConfig(config);
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public static Shader LoadShader(/* const char* */ string vsFileName, /* const char* */ string fsFileName)
    {
        // sbyte* => string
        using var vsFileName_ = vsFileName.MarshalUtf8();
        // sbyte* => string
        using var fsFileName_ = fsFileName.MarshalUtf8();
        // return Shader => Shader
        return Raylib.LoadShader(vsFileName_.AsPtr(), fsFileName_.AsPtr());
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public static Shader LoadShaderFromMemory(/* const char* */ string vsCode, /* const char* */ string fsCode)
    {
        // sbyte* => string
        using var vsCode_ = vsCode.MarshalUtf8();
        // sbyte* => string
        using var fsCode_ = fsCode.MarshalUtf8();
        // return Shader => Shader
        return Raylib.LoadShaderFromMemory(vsCode_.AsPtr(), fsCode_.AsPtr());
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetShaderLocation(/* Shader */ Shader shader, /* const char* */ string uniformName)
    {
        // Shader => Shader
        // sbyte* => string
        using var uniformName_ = uniformName.MarshalUtf8();
        // return int => int
        return Raylib.GetShaderLocation(shader, uniformName_.AsPtr());
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetShaderLocationAttrib(/* Shader */ Shader shader, /* const char* */ string attribName)
    {
        // Shader => Shader
        // sbyte* => string
        using var attribName_ = attribName.MarshalUtf8();
        // return int => int
        return Raylib.GetShaderLocationAttrib(shader, attribName_.AsPtr());
    }

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetShaderValue(/* Shader */ Shader shader, /* int */ int locIndex, /* const void* */ IntPtr value, /* int */ int uniformType)
    {
        // Shader => Shader
        // int => int
        // void* => IntPtr
        var value_ = (void*)value;
        // int => int
        // return void => void
        Raylib.SetShaderValue(shader, locIndex, value_, uniformType);
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetShaderValueV(/* Shader */ Shader shader, /* int */ int locIndex, /* const void* */ IntPtr value, /* int */ int uniformType, /* int */ int count)
    {
        // Shader => Shader
        // int => int
        // void* => IntPtr
        var value_ = (void*)value;
        // int => int
        // int => int
        // return void => void
        Raylib.SetShaderValueV(shader, locIndex, value_, uniformType, count);
    }

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetShaderValueMatrix(/* Shader */ Shader shader, /* int */ int locIndex, /* Matrix */ Matrix4x4 mat)
    {
        // Shader => Shader
        // int => int
        // Matrix4x4 => Matrix4x4
        // return void => void
        Raylib.SetShaderValueMatrix(shader, locIndex, mat);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetShaderValueTexture(/* Shader */ Shader shader, /* int */ int locIndex, /* Texture2D */ Texture texture)
    {
        // Shader => Shader
        // int => int
        // Texture => Texture
        // return void => void
        Raylib.SetShaderValueTexture(shader, locIndex, texture);
    }

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    public static void UnloadShader(/* Shader */ Shader shader)
    {
        // Shader => Shader
        // return void => void
        Raylib.UnloadShader(shader);
    }

    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public static Ray GetMouseRay(/* Vector2 */ Vector2 mousePosition, /* Camera */ Camera3D camera)
    {
        // Vector2 => Vector2
        // Camera3D => Camera3D
        // return Ray => Ray
        return Raylib.GetMouseRay(mousePosition, camera);
    }

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public static Matrix4x4 GetCameraMatrix(/* Camera */ Camera3D camera)
    {
        // Camera3D => Camera3D
        // return Matrix4x4 => Matrix4x4
        return Raylib.GetCameraMatrix(camera);
    }

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    public static Matrix4x4 GetCameraMatrix2D(/* Camera2D */ Camera2D camera)
    {
        // Camera2D => Camera2D
        // return Matrix4x4 => Matrix4x4
        return Raylib.GetCameraMatrix2D(camera);
    }

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(/* Vector3 */ Vector3 position, /* Camera */ Camera3D camera)
    {
        // Vector3 => Vector3
        // Camera3D => Camera3D
        // return Vector2 => Vector2
        return Raylib.GetWorldToScreen(position, camera);
    }

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreenEx(/* Vector3 */ Vector3 position, /* Camera */ Camera3D camera, /* int */ int width, /* int */ int height)
    {
        // Vector3 => Vector3
        // Camera3D => Camera3D
        // int => int
        // int => int
        // return Vector2 => Vector2
        return Raylib.GetWorldToScreenEx(position, camera, width, height);
    }

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    public static Vector2 GetWorldToScreen2D(/* Vector2 */ Vector2 position, /* Camera2D */ Camera2D camera)
    {
        // Vector2 => Vector2
        // Camera2D => Camera2D
        // return Vector2 => Vector2
        return Raylib.GetWorldToScreen2D(position, camera);
    }

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    public static Vector2 GetScreenToWorld2D(/* Vector2 */ Vector2 position, /* Camera2D */ Camera2D camera)
    {
        // Vector2 => Vector2
        // Camera2D => Camera2D
        // return Vector2 => Vector2
        return Raylib.GetScreenToWorld2D(position, camera);
    }

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    public static void SetTargetFPS(/* int */ int fps)
    {
        // int => int
        // return void => void
        Raylib.SetTargetFPS(fps);
    }

    /// <summary>
    /// Get current FPS
    /// </summary>
    public static int GetFPS()
    {
        // return int => int
        return Raylib.GetFPS();
    }

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    public static float GetFrameTime()
    {
        // return float => float
        return Raylib.GetFrameTime();
    }

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    public static double GetTime()
    {
        // return double => double
        return Raylib.GetTime();
    }

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    public static int GetRandomValue(/* int */ int min, /* int */ int max)
    {
        // int => int
        // int => int
        // return int => int
        return Raylib.GetRandomValue(min, max);
    }

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    public static void SetRandomSeed(/* unsigned int */ uint seed)
    {
        // uint => uint
        // return void => void
        Raylib.SetRandomSeed(seed);
    }

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    public static void TakeScreenshot(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return void => void
        Raylib.TakeScreenshot(fileName_.AsPtr());
    }

    /// <summary>
    /// Setup init configuration flags (view FLAGS)
    /// </summary>
    public static void SetConfigFlags(/* unsigned int */ uint flags)
    {
        // uint => uint
        // return void => void
        Raylib.SetConfigFlags(flags);
    }

//  /// <summary>
//  /// Show trace log messages (LOG_DEBUG, LOG_INFO, LOG_WARNING, LOG_ERROR...)
//  /// </summary>
//  public static void TraceLog(/* int */ int logLevel, /* const char* */ string text, /* ... */ params object[] args)
//  {
//      // int => int
//      // sbyte* => string
//      using var text_ = text.MarshalUtf8();
//      // __arglist => params object[]
//      // return void => void
//      Raylib.TraceLog(logLevel, text_.AsPtr(), __arglist(args));
//  }

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    public static void SetTraceLogLevel(/* int */ int logLevel)
    {
        // int => int
        // return void => void
        Raylib.SetTraceLogLevel(logLevel);
    }

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    public static IntPtr MemAlloc(/* int */ int size)
    {
        // int => int
        // return void* => IntPtr
        return (IntPtr)Raylib.MemAlloc(size);
    }

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    public static IntPtr MemRealloc(/* void* */ IntPtr ptr, /* int */ int size)
    {
        // void* => IntPtr
        var ptr_ = (void*)ptr;
        // int => int
        // return void* => IntPtr
        return (IntPtr)Raylib.MemRealloc(ptr_, size);
    }

    /// <summary>
    /// Internal memory free
    /// </summary>
    public static void MemFree(/* void* */ IntPtr ptr)
    {
        // void* => IntPtr
        var ptr_ = (void*)ptr;
        // return void => void
        Raylib.MemFree(ptr_);
    }

    /// <summary>
    /// Set custom trace log
    /// </summary>
    public static void SetTraceLogCallback(/* TraceLogCallback */ delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void> callback)
    {
        // delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void> => delegate* unmanaged[Cdecl]<int, sbyte*, sbyte*, void>
        // return void => void
        Raylib.SetTraceLogCallback(callback);
    }

//  /// <summary>
//  /// Set custom file binary data loader
//  /// </summary>
//  public static void SetLoadFileDataCallback(/* LoadFileDataCallback */ delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*> callback)
//  {
//      // delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*> => delegate* unmanaged[Cdecl]<sbyte*, uint*, byte*>
//      // return void => void
//      Raylib.SetLoadFileDataCallback(callback);
//  }

//  /// <summary>
//  /// Set custom file binary data saver
//  /// </summary>
//  public static void SetSaveFileDataCallback(/* SaveFileDataCallback */ delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool> callback)
//  {
//      // delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool> => delegate* unmanaged[Cdecl]<sbyte*, void*, uint, bool>
//      // return void => void
//      Raylib.SetSaveFileDataCallback(callback);
//  }

//  /// <summary>
//  /// Set custom file text data loader
//  /// </summary>
//  public static void SetLoadFileTextCallback(/* LoadFileTextCallback */ delegate* unmanaged[Cdecl]<sbyte*, sbyte*> callback)
//  {
//      // delegate* unmanaged[Cdecl]<sbyte*, sbyte*> => delegate* unmanaged[Cdecl]<sbyte*, sbyte*>
//      // return void => void
//      Raylib.SetLoadFileTextCallback(callback);
//  }

//  /// <summary>
//  /// Set custom file text data saver
//  /// </summary>
//  public static void SetSaveFileTextCallback(/* SaveFileTextCallback */ delegate* unmanaged[Cdecl]<sbyte*, sbyte*> callback)
//  {
//      // delegate* unmanaged[Cdecl]<sbyte*, sbyte*> => delegate* unmanaged[Cdecl]<sbyte*, sbyte*>
//      // return void => void
//      Raylib.SetSaveFileTextCallback(callback);
//  }

//  /// <summary>
//  /// Load file data as byte array (read)
//  /// </summary>
//  public static byte[] LoadFileData(/* const char* */ string fileName, /* unsigned int* */ uint* bytesRead)
//  {
//      // sbyte* => string
//      using var fileName_ = fileName.MarshalUtf8();
//      // uint* => uint*
//      // return byte* => byte[]
//      return Helpers.PrtToArray(Raylib.LoadFileData(fileName_.AsPtr(), bytesRead));
//  }

    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    public static void UnloadFileData(/* unsigned char* */ byte[] data)
    {
        // byte* => byte[]
        var data_ = Helpers.ArrayToPtr(data);
        // return void => void
        Raylib.UnloadFileData(data_);
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public static bool SaveFileData(/* const char* */ string fileName, /* void* */ IntPtr data, /* unsigned int */ uint bytesToWrite)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // void* => IntPtr
        var data_ = (void*)data;
        // uint => uint
        // return bool => bool
        return Raylib.SaveFileData(fileName_.AsPtr(), data_, bytesToWrite);
    }

    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    public static string LoadFileText(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.LoadFileText(fileName_.AsPtr()));
    }

    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    public static void UnloadFileText(/* char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return void => void
        Raylib.UnloadFileText(text_.AsPtr());
    }

    /// <summary>
    /// Save text data to file (write), string must be '\0' terminated, returns true on success
    /// </summary>
    public static bool SaveFileText(/* const char* */ string fileName, /* char* */ string text)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return bool => bool
        return Raylib.SaveFileText(fileName_.AsPtr(), text_.AsPtr());
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public static bool FileExists(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.FileExists(fileName_.AsPtr());
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public static bool DirectoryExists(/* const char* */ string dirPath)
    {
        // sbyte* => string
        using var dirPath_ = dirPath.MarshalUtf8();
        // return bool => bool
        return Raylib.DirectoryExists(dirPath_.AsPtr());
    }

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    public static bool IsFileExtension(/* const char* */ string fileName, /* const char* */ string ext)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // sbyte* => string
        using var ext_ = ext.MarshalUtf8();
        // return bool => bool
        return Raylib.IsFileExtension(fileName_.AsPtr(), ext_.AsPtr());
    }

    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    public static int GetFileLength(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return int => int
        return Raylib.GetFileLength(fileName_.AsPtr());
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public static string GetFileExtension(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetFileExtension(fileName_.AsPtr()));
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public static string GetFileName(/* const char* */ string filePath)
    {
        // sbyte* => string
        using var filePath_ = filePath.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetFileName(filePath_.AsPtr()));
    }

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    public static string GetFileNameWithoutExt(/* const char* */ string filePath)
    {
        // sbyte* => string
        using var filePath_ = filePath.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetFileNameWithoutExt(filePath_.AsPtr()));
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public static string GetDirectoryPath(/* const char* */ string filePath)
    {
        // sbyte* => string
        using var filePath_ = filePath.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetDirectoryPath(filePath_.AsPtr()));
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public static string GetPrevDirectoryPath(/* const char* */ string dirPath)
    {
        // sbyte* => string
        using var dirPath_ = dirPath.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetPrevDirectoryPath(dirPath_.AsPtr()));
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public static string GetWorkingDirectory()
    {
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetWorkingDirectory());
    }

    /// <summary>
    /// Get the directory if the running application (uses static string)
    /// </summary>
    public static string GetApplicationDirectory()
    {
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetApplicationDirectory());
    }

//  /// <summary>
//  /// Get filenames in a directory path (memory should be freed)
//  /// </summary>
//  public static sbyte** GetDirectoryFiles(/* const char* */ string dirPath, /* int* */ int* count)
//  {
//      // sbyte* => string
//      using var dirPath_ = dirPath.MarshalUtf8();
//      // int* => int*
//      // return sbyte** => sbyte**
//      return Raylib.GetDirectoryFiles(dirPath_.AsPtr(), count);
//  }

    /// <summary>
    /// Clear directory files paths buffers (free memory)
    /// </summary>
    public static void ClearDirectoryFiles()
    {
        // return void => void
        Raylib.ClearDirectoryFiles();
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public static bool ChangeDirectory(/* const char* */ string dir)
    {
        // sbyte* => string
        using var dir_ = dir.MarshalUtf8();
        // return bool => bool
        return Raylib.ChangeDirectory(dir_.AsPtr());
    }

    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    public static bool IsFileDropped()
    {
        // return bool => bool
        return Raylib.IsFileDropped();
    }

//  /// <summary>
//  /// Get dropped files names (memory should be freed)
//  /// </summary>
//  public static sbyte** GetDroppedFiles(/* int* */ int* count)
//  {
//      // int* => int*
//      // return sbyte** => sbyte**
//      return Raylib.GetDroppedFiles(count);
//  }

    /// <summary>
    /// Clear dropped files paths buffer (free memory)
    /// </summary>
    public static void ClearDroppedFiles()
    {
        // return void => void
        Raylib.ClearDroppedFiles();
    }

    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    public static long GetFileModTime(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return long => long
        return Raylib.GetFileModTime(fileName_.AsPtr());
    }

    /// <summary>
    /// Compress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] CompressData(/* const unsigned char* */ byte[] data, /* int */ int dataLength, /* int* */ int* compDataLength)
    {
        // byte* => byte[]
        var data_ = Helpers.ArrayToPtr(data);
        // int => int
        // int* => int*
        // return byte* => byte[]
        return Helpers.PrtToArray(Raylib.CompressData(data_, dataLength, compDataLength));
    }

    /// <summary>
    /// Decompress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] DecompressData(/* const unsigned char* */ byte[] compData, /* int */ int compDataLength, /* int* */ int* dataLength)
    {
        // byte* => byte[]
        var compData_ = Helpers.ArrayToPtr(compData);
        // int => int
        // int* => int*
        // return byte* => byte[]
        return Helpers.PrtToArray(Raylib.DecompressData(compData_, compDataLength, dataLength));
    }

    /// <summary>
    /// Encode data to Base64 string
    /// </summary>
    public static string EncodeDataBase64(/* const unsigned char* */ byte[] data, /* int */ int dataLength, /* int* */ int* outputLength)
    {
        // byte* => byte[]
        var data_ = Helpers.ArrayToPtr(data);
        // int => int
        // int* => int*
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.EncodeDataBase64(data_, dataLength, outputLength));
    }

    /// <summary>
    /// Decode Base64 string data
    /// </summary>
    public static byte[] DecodeDataBase64(/* const unsigned char* */ byte[] data, /* int* */ int* outputLength)
    {
        // byte* => byte[]
        var data_ = Helpers.ArrayToPtr(data);
        // int* => int*
        // return byte* => byte[]
        return Helpers.PrtToArray(Raylib.DecodeDataBase64(data_, outputLength));
    }

    /// <summary>
    /// Save integer value to storage file (to defined position), returns true on success
    /// </summary>
    public static bool SaveStorageValue(/* unsigned int */ uint position, /* int */ int value)
    {
        // uint => uint
        // int => int
        // return bool => bool
        return Raylib.SaveStorageValue(position, value);
    }

    /// <summary>
    /// Load integer value from storage file (from defined position)
    /// </summary>
    public static int LoadStorageValue(/* unsigned int */ uint position)
    {
        // uint => uint
        // return int => int
        return Raylib.LoadStorageValue(position);
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public static void OpenURL(/* const char* */ string url)
    {
        // sbyte* => string
        using var url_ = url.MarshalUtf8();
        // return void => void
        Raylib.OpenURL(url_.AsPtr());
    }

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    public static bool IsKeyPressed(/* int */ int key)
    {
        // int => int
        // return bool => bool
        return Raylib.IsKeyPressed(key);
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public static bool IsKeyDown(/* int */ int key)
    {
        // int => int
        // return bool => bool
        return Raylib.IsKeyDown(key);
    }

    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    public static bool IsKeyReleased(/* int */ int key)
    {
        // int => int
        // return bool => bool
        return Raylib.IsKeyReleased(key);
    }

    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    public static bool IsKeyUp(/* int */ int key)
    {
        // int => int
        // return bool => bool
        return Raylib.IsKeyUp(key);
    }

    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    public static void SetExitKey(/* int */ int key)
    {
        // int => int
        // return void => void
        Raylib.SetExitKey(key);
    }

    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetKeyPressed()
    {
        // return int => int
        return Raylib.GetKeyPressed();
    }

    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetCharPressed()
    {
        // return int => int
        return Raylib.GetCharPressed();
    }

    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    public static bool IsGamepadAvailable(/* int */ int gamepad)
    {
        // int => int
        // return bool => bool
        return Raylib.IsGamepadAvailable(gamepad);
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public static string GetGamepadName(/* int */ int gamepad)
    {
        // int => int
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.GetGamepadName(gamepad));
    }

    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    public static bool IsGamepadButtonPressed(/* int */ int gamepad, /* int */ int button)
    {
        // int => int
        // int => int
        // return bool => bool
        return Raylib.IsGamepadButtonPressed(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    public static bool IsGamepadButtonDown(/* int */ int gamepad, /* int */ int button)
    {
        // int => int
        // int => int
        // return bool => bool
        return Raylib.IsGamepadButtonDown(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    public static bool IsGamepadButtonReleased(/* int */ int gamepad, /* int */ int button)
    {
        // int => int
        // int => int
        // return bool => bool
        return Raylib.IsGamepadButtonReleased(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    public static bool IsGamepadButtonUp(/* int */ int gamepad, /* int */ int button)
    {
        // int => int
        // int => int
        // return bool => bool
        return Raylib.IsGamepadButtonUp(gamepad, button);
    }

    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    public static int GetGamepadButtonPressed()
    {
        // return int => int
        return Raylib.GetGamepadButtonPressed();
    }

    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    public static int GetGamepadAxisCount(/* int */ int gamepad)
    {
        // int => int
        // return int => int
        return Raylib.GetGamepadAxisCount(gamepad);
    }

    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    public static float GetGamepadAxisMovement(/* int */ int gamepad, /* int */ int axis)
    {
        // int => int
        // int => int
        // return float => float
        return Raylib.GetGamepadAxisMovement(gamepad, axis);
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public static int SetGamepadMappings(/* const char* */ string mappings)
    {
        // sbyte* => string
        using var mappings_ = mappings.MarshalUtf8();
        // return int => int
        return Raylib.SetGamepadMappings(mappings_.AsPtr());
    }

    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    public static bool IsMouseButtonPressed(/* int */ int button)
    {
        // int => int
        // return bool => bool
        return Raylib.IsMouseButtonPressed(button);
    }

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    public static bool IsMouseButtonDown(/* int */ int button)
    {
        // int => int
        // return bool => bool
        return Raylib.IsMouseButtonDown(button);
    }

    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    public static bool IsMouseButtonReleased(/* int */ int button)
    {
        // int => int
        // return bool => bool
        return Raylib.IsMouseButtonReleased(button);
    }

    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    public static bool IsMouseButtonUp(/* int */ int button)
    {
        // int => int
        // return bool => bool
        return Raylib.IsMouseButtonUp(button);
    }

    /// <summary>
    /// Get mouse position X
    /// </summary>
    public static int GetMouseX()
    {
        // return int => int
        return Raylib.GetMouseX();
    }

    /// <summary>
    /// Get mouse position Y
    /// </summary>
    public static int GetMouseY()
    {
        // return int => int
        return Raylib.GetMouseY();
    }

    /// <summary>
    /// Get mouse position XY
    /// </summary>
    public static Vector2 GetMousePosition()
    {
        // return Vector2 => Vector2
        return Raylib.GetMousePosition();
    }

    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    public static Vector2 GetMouseDelta()
    {
        // return Vector2 => Vector2
        return Raylib.GetMouseDelta();
    }

    /// <summary>
    /// Set mouse position XY
    /// </summary>
    public static void SetMousePosition(/* int */ int x, /* int */ int y)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.SetMousePosition(x, y);
    }

    /// <summary>
    /// Set mouse offset
    /// </summary>
    public static void SetMouseOffset(/* int */ int offsetX, /* int */ int offsetY)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.SetMouseOffset(offsetX, offsetY);
    }

    /// <summary>
    /// Set mouse scaling
    /// </summary>
    public static void SetMouseScale(/* float */ float scaleX, /* float */ float scaleY)
    {
        // float => float
        // float => float
        // return void => void
        Raylib.SetMouseScale(scaleX, scaleY);
    }

    /// <summary>
    /// Get mouse wheel movement Y
    /// </summary>
    public static float GetMouseWheelMove()
    {
        // return float => float
        return Raylib.GetMouseWheelMove();
    }

    /// <summary>
    /// Set mouse cursor
    /// </summary>
    public static void SetMouseCursor(/* int */ int cursor)
    {
        // int => int
        // return void => void
        Raylib.SetMouseCursor(cursor);
    }

    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchX()
    {
        // return int => int
        return Raylib.GetTouchX();
    }

    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchY()
    {
        // return int => int
        return Raylib.GetTouchY();
    }

    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    public static Vector2 GetTouchPosition(/* int */ int index)
    {
        // int => int
        // return Vector2 => Vector2
        return Raylib.GetTouchPosition(index);
    }

    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    public static int GetTouchPointId(/* int */ int index)
    {
        // int => int
        // return int => int
        return Raylib.GetTouchPointId(index);
    }

    /// <summary>
    /// Get number of touch points
    /// </summary>
    public static int GetTouchPointCount()
    {
        // return int => int
        return Raylib.GetTouchPointCount();
    }

    /// <summary>
    /// Enable a set of gestures using flags
    /// </summary>
    public static void SetGesturesEnabled(/* unsigned int */ uint flags)
    {
        // uint => uint
        // return void => void
        Raylib.SetGesturesEnabled(flags);
    }

    /// <summary>
    /// Check if a gesture have been detected
    /// </summary>
    public static bool IsGestureDetected(/* int */ int gesture)
    {
        // int => int
        // return bool => bool
        return Raylib.IsGestureDetected(gesture);
    }

//  /// <summary>
//  /// Get latest detected gesture
//  /// </summary>
//  public static int GetGestureDetected()
//  {
//      // return int => int
//      return Raylib.GetGestureDetected();
//  }

    /// <summary>
    /// Get gesture hold time in milliseconds
    /// </summary>
    public static float GetGestureHoldDuration()
    {
        // return float => float
        return Raylib.GetGestureHoldDuration();
    }

    /// <summary>
    /// Get gesture drag vector
    /// </summary>
    public static Vector2 GetGestureDragVector()
    {
        // return Vector2 => Vector2
        return Raylib.GetGestureDragVector();
    }

    /// <summary>
    /// Get gesture drag angle
    /// </summary>
    public static float GetGestureDragAngle()
    {
        // return float => float
        return Raylib.GetGestureDragAngle();
    }

    /// <summary>
    /// Get gesture pinch delta
    /// </summary>
    public static Vector2 GetGesturePinchVector()
    {
        // return Vector2 => Vector2
        return Raylib.GetGesturePinchVector();
    }

    /// <summary>
    /// Get gesture pinch angle
    /// </summary>
    public static float GetGesturePinchAngle()
    {
        // return float => float
        return Raylib.GetGesturePinchAngle();
    }

    /// <summary>
    /// Set camera mode (multiple camera modes available)
    /// </summary>
    public static void SetCameraMode(/* Camera */ Camera3D camera, /* int */ int mode)
    {
        // Camera3D => Camera3D
        // int => int
        // return void => void
        Raylib.SetCameraMode(camera, mode);
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void UpdateCamera(/* Camera* */ Camera3D* camera)
    {
        // Camera3D* => Camera3D*
        // return void => void
        Raylib.UpdateCamera(camera);
    }

    /// <summary>
    /// Set camera pan key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraPanControl(/* int */ int keyPan)
    {
        // int => int
        // return void => void
        Raylib.SetCameraPanControl(keyPan);
    }

    /// <summary>
    /// Set camera alt key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraAltControl(/* int */ int keyAlt)
    {
        // int => int
        // return void => void
        Raylib.SetCameraAltControl(keyAlt);
    }

    /// <summary>
    /// Set camera smooth zoom key to combine with mouse (free camera)
    /// </summary>
    public static void SetCameraSmoothZoomControl(/* int */ int keySmoothZoom)
    {
        // int => int
        // return void => void
        Raylib.SetCameraSmoothZoomControl(keySmoothZoom);
    }

    /// <summary>
    /// Set camera move controls (1st person and 3rd person cameras)
    /// </summary>
    public static void SetCameraMoveControls(/* int */ int keyFront, /* int */ int keyBack, /* int */ int keyRight, /* int */ int keyLeft, /* int */ int keyUp, /* int */ int keyDown)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // int => int
        // int => int
        // return void => void
        Raylib.SetCameraMoveControls(keyFront, keyBack, keyRight, keyLeft, keyUp, keyDown);
    }

    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    public static void SetShapesTexture(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle source)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // return void => void
        Raylib.SetShapesTexture(texture, source);
    }

    /// <summary>
    /// Draw a pixel
    /// </summary>
    public static void DrawPixel(/* int */ int posX, /* int */ int posY, /* Color */ Color color)
    {
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawPixel(posX, posY, color);
    }

    /// <summary>
    /// Draw a pixel (Vector version)
    /// </summary>
    public static void DrawPixelV(/* Vector2 */ Vector2 position, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawPixelV(position, color);
    }

    /// <summary>
    /// Draw a line
    /// </summary>
    public static void DrawLine(/* int */ int startPosX, /* int */ int startPosY, /* int */ int endPosX, /* int */ int endPosY, /* Color */ Color color)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawLine(startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    public static void DrawLineV(/* Vector2 */ Vector2 startPos, /* Vector2 */ Vector2 endPos, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawLineV(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    public static void DrawLineEx(/* Vector2 */ Vector2 startPos, /* Vector2 */ Vector2 endPos, /* float */ float thick, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawLineEx(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    public static void DrawLineBezier(/* Vector2 */ Vector2 startPos, /* Vector2 */ Vector2 endPos, /* float */ float thick, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawLineBezier(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    public static void DrawLineBezierQuad(/* Vector2 */ Vector2 startPos, /* Vector2 */ Vector2 endPos, /* Vector2 */ Vector2 controlPos, /* float */ float thick, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawLineBezierQuad(startPos, endPos, controlPos, thick, color);
    }

    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    public static void DrawLineBezierCubic(/* Vector2 */ Vector2 startPos, /* Vector2 */ Vector2 endPos, /* Vector2 */ Vector2 startControlPos, /* Vector2 */ Vector2 endControlPos, /* float */ float thick, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawLineBezierCubic(startPos, endPos, startControlPos, endControlPos, thick, color);
    }

    /// <summary>
    /// Draw lines sequence
    /// </summary>
    public static void DrawLineStrip(/* Vector2* */ Vector2* points, /* int */ int pointCount, /* Color */ Color color)
    {
        // Vector2* => Vector2*
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawLineStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public static void DrawCircle(/* int */ int centerX, /* int */ int centerY, /* float */ float radius, /* Color */ Color color)
    {
        // int => int
        // int => int
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCircle(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(/* Vector2 */ Vector2 center, /* float */ float radius, /* float */ float startAngle, /* float */ float endAngle, /* int */ int segments, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public static void DrawCircleSectorLines(/* Vector2 */ Vector2 center, /* float */ float radius, /* float */ float startAngle, /* float */ float endAngle, /* int */ int segments, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(/* int */ int centerX, /* int */ int centerY, /* float */ float radius, /* Color */ Color color1, /* Color */ Color color2)
    {
        // int => int
        // int => int
        // float => float
        // Color => Color
        // Color => Color
        // return void => void
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
    }

    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    public static void DrawCircleV(/* Vector2 */ Vector2 center, /* float */ float radius, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCircleV(center, radius, color);
    }

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(/* int */ int centerX, /* int */ int centerY, /* float */ float radius, /* Color */ Color color)
    {
        // int => int
        // int => int
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCircleLines(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(/* int */ int centerX, /* int */ int centerY, /* float */ float radiusH, /* float */ float radiusV, /* Color */ Color color)
    {
        // int => int
        // int => int
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(/* int */ int centerX, /* int */ int centerY, /* float */ float radiusH, /* float */ float radiusV, /* Color */ Color color)
    {
        // int => int
        // int => int
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ring
    /// </summary>
    public static void DrawRing(/* Vector2 */ Vector2 center, /* float */ float innerRadius, /* float */ float outerRadius, /* float */ float startAngle, /* float */ float endAngle, /* int */ int segments, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // float => float
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw ring outline
    /// </summary>
    public static void DrawRingLines(/* Vector2 */ Vector2 center, /* float */ float innerRadius, /* float */ float outerRadius, /* float */ float startAngle, /* float */ float endAngle, /* int */ int segments, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // float => float
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(/* int */ int posX, /* int */ int posY, /* int */ int width, /* int */ int height, /* Color */ Color color)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawRectangle(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    public static void DrawRectangleV(/* Vector2 */ Vector2 position, /* Vector2 */ Vector2 size, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawRectangleV(position, size, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangleRec(/* Rectangle */ Rectangle rec, /* Color */ Color color)
    {
        // Rectangle => Rectangle
        // Color => Color
        // return void => void
        Raylib.DrawRectangleRec(rec, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    public static void DrawRectanglePro(/* Rectangle */ Rectangle rec, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* Color */ Color color)
    {
        // Rectangle => Rectangle
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawRectanglePro(rec, origin, rotation, color);
    }

    /// <summary>
    /// Draw a vertical-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientV(/* int */ int posX, /* int */ int posY, /* int */ int width, /* int */ int height, /* Color */ Color color1, /* Color */ Color color2)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // Color => Color
        // return void => void
        Raylib.DrawRectangleGradientV(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a horizontal-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientH(/* int */ int posX, /* int */ int posY, /* int */ int width, /* int */ int height, /* Color */ Color color1, /* Color */ Color color2)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // Color => Color
        // return void => void
        Raylib.DrawRectangleGradientH(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public static void DrawRectangleGradientEx(/* Rectangle */ Rectangle rec, /* Color */ Color col1, /* Color */ Color col2, /* Color */ Color col3, /* Color */ Color col4)
    {
        // Rectangle => Rectangle
        // Color => Color
        // Color => Color
        // Color => Color
        // Color => Color
        // return void => void
        Raylib.DrawRectangleGradientEx(rec, col1, col2, col3, col4);
    }

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public static void DrawRectangleLines(/* int */ int posX, /* int */ int posY, /* int */ int width, /* int */ int height, /* Color */ Color color)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawRectangleLines(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    public static void DrawRectangleLinesEx(/* Rectangle */ Rectangle rec, /* float */ float lineThick, /* Color */ Color color)
    {
        // Rectangle => Rectangle
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawRectangleLinesEx(rec, lineThick, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    public static void DrawRectangleRounded(/* Rectangle */ Rectangle rec, /* float */ float roundness, /* int */ int segments, /* Color */ Color color)
    {
        // Rectangle => Rectangle
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawRectangleRounded(rec, roundness, segments, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    public static void DrawRectangleRoundedLines(/* Rectangle */ Rectangle rec, /* float */ float roundness, /* int */ int segments, /* float */ float lineThick, /* Color */ Color color)
    {
        // Rectangle => Rectangle
        // float => float
        // int => int
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawRectangleRoundedLines(rec, roundness, segments, lineThick, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle(/* Vector2 */ Vector2 v1, /* Vector2 */ Vector2 v2, /* Vector2 */ Vector2 v3, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawTriangle(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangleLines(/* Vector2 */ Vector2 v1, /* Vector2 */ Vector2 v2, /* Vector2 */ Vector2 v3, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public static void DrawTriangleFan(/* Vector2* */ Vector2* points, /* int */ int pointCount, /* Color */ Color color)
    {
        // Vector2* => Vector2*
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawTriangleFan(points, pointCount, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip(/* Vector2* */ Vector2* points, /* int */ int pointCount, /* Color */ Color color)
    {
        // Vector2* => Vector2*
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawTriangleStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    public static void DrawPoly(/* Vector2 */ Vector2 center, /* int */ int sides, /* float */ float radius, /* float */ float rotation, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // int => int
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    public static void DrawPolyLines(/* Vector2 */ Vector2 center, /* int */ int sides, /* float */ float radius, /* float */ float rotation, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // int => int
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    public static void DrawPolyLinesEx(/* Vector2 */ Vector2 center, /* int */ int sides, /* float */ float radius, /* float */ float rotation, /* float */ float lineThick, /* Color */ Color color)
    {
        // Vector2 => Vector2
        // int => int
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, lineThick, color);
    }

    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    public static bool CheckCollisionRecs(/* Rectangle */ Rectangle rec1, /* Rectangle */ Rectangle rec2)
    {
        // Rectangle => Rectangle
        // Rectangle => Rectangle
        // return bool => bool
        return Raylib.CheckCollisionRecs(rec1, rec2);
    }

    /// <summary>
    /// Check collision between two circles
    /// </summary>
    public static bool CheckCollisionCircles(/* Vector2 */ Vector2 center1, /* float */ float radius1, /* Vector2 */ Vector2 center2, /* float */ float radius2)
    {
        // Vector2 => Vector2
        // float => float
        // Vector2 => Vector2
        // float => float
        // return bool => bool
        return Raylib.CheckCollisionCircles(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    public static bool CheckCollisionCircleRec(/* Vector2 */ Vector2 center, /* float */ float radius, /* Rectangle */ Rectangle rec)
    {
        // Vector2 => Vector2
        // float => float
        // Rectangle => Rectangle
        // return bool => bool
        return Raylib.CheckCollisionCircleRec(center, radius, rec);
    }

    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    public static bool CheckCollisionPointRec(/* Vector2 */ Vector2 point, /* Rectangle */ Rectangle rec)
    {
        // Vector2 => Vector2
        // Rectangle => Rectangle
        // return bool => bool
        return Raylib.CheckCollisionPointRec(point, rec);
    }

    /// <summary>
    /// Check if point is inside circle
    /// </summary>
    public static bool CheckCollisionPointCircle(/* Vector2 */ Vector2 point, /* Vector2 */ Vector2 center, /* float */ float radius)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // return bool => bool
        return Raylib.CheckCollisionPointCircle(point, center, radius);
    }

    /// <summary>
    /// Check if point is inside a triangle
    /// </summary>
    public static bool CheckCollisionPointTriangle(/* Vector2 */ Vector2 point, /* Vector2 */ Vector2 p1, /* Vector2 */ Vector2 p2, /* Vector2 */ Vector2 p3)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // return bool => bool
        return Raylib.CheckCollisionPointTriangle(point, p1, p2, p3);
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public static bool CheckCollisionLines(/* Vector2 */ Vector2 startPos1, /* Vector2 */ Vector2 endPos1, /* Vector2 */ Vector2 startPos2, /* Vector2 */ Vector2 endPos2, /* Vector2* */ Vector2* collisionPoint)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2* => Vector2*
        // return bool => bool
        return Raylib.CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, collisionPoint);
    }

    /// <summary>
    /// Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]
    /// </summary>
    public static bool CheckCollisionPointLine(/* Vector2 */ Vector2 point, /* Vector2 */ Vector2 p1, /* Vector2 */ Vector2 p2, /* int */ int threshold)
    {
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Vector2 => Vector2
        // int => int
        // return bool => bool
        return Raylib.CheckCollisionPointLine(point, p1, p2, threshold);
    }

    /// <summary>
    /// Get collision rectangle for two rectangles collision
    /// </summary>
    public static Rectangle GetCollisionRec(/* Rectangle */ Rectangle rec1, /* Rectangle */ Rectangle rec2)
    {
        // Rectangle => Rectangle
        // Rectangle => Rectangle
        // return Rectangle => Rectangle
        return Raylib.GetCollisionRec(rec1, rec2);
    }

    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    public static Image LoadImage(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Image => Image
        return Raylib.LoadImage(fileName_.AsPtr());
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public static Image LoadImageRaw(/* const char* */ string fileName, /* int */ int width, /* int */ int height, /* int */ int format, /* int */ int headerSize)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // int => int
        // int => int
        // int => int
        // int => int
        // return Image => Image
        return Raylib.LoadImageRaw(fileName_.AsPtr(), width, height, format, headerSize);
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public static Image LoadImageAnim(/* const char* */ string fileName, /* int* */ int* frames)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // int* => int*
        // return Image => Image
        return Raylib.LoadImageAnim(fileName_.AsPtr(), frames);
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public static Image LoadImageFromMemory(/* const char* */ string fileType, /* const unsigned char* */ byte[] fileData, /* int */ int dataSize)
    {
        // sbyte* => string
        using var fileType_ = fileType.MarshalUtf8();
        // byte* => byte[]
        var fileData_ = Helpers.ArrayToPtr(fileData);
        // int => int
        // return Image => Image
        return Raylib.LoadImageFromMemory(fileType_.AsPtr(), fileData_, dataSize);
    }

    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    public static Image LoadImageFromTexture(/* Texture2D */ Texture texture)
    {
        // Texture => Texture
        // return Image => Image
        return Raylib.LoadImageFromTexture(texture);
    }

    /// <summary>
    /// Load image from screen buffer and (screenshot)
    /// </summary>
    public static Image LoadImageFromScreen()
    {
        // return Image => Image
        return Raylib.LoadImageFromScreen();
    }

    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    public static void UnloadImage(/* Image */ Image image)
    {
        // Image => Image
        // return void => void
        Raylib.UnloadImage(image);
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public static bool ExportImage(/* Image */ Image image, /* const char* */ string fileName)
    {
        // Image => Image
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportImage(image, fileName_.AsPtr());
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static bool ExportImageAsCode(/* Image */ Image image, /* const char* */ string fileName)
    {
        // Image => Image
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportImageAsCode(image, fileName_.AsPtr());
    }

    /// <summary>
    /// Generate image: plain color
    /// </summary>
    public static Image GenImageColor(/* int */ int width, /* int */ int height, /* Color */ Color color)
    {
        // int => int
        // int => int
        // Color => Color
        // return Image => Image
        return Raylib.GenImageColor(width, height, color);
    }

    /// <summary>
    /// Generate image: vertical gradient
    /// </summary>
    public static Image GenImageGradientV(/* int */ int width, /* int */ int height, /* Color */ Color top, /* Color */ Color bottom)
    {
        // int => int
        // int => int
        // Color => Color
        // Color => Color
        // return Image => Image
        return Raylib.GenImageGradientV(width, height, top, bottom);
    }

    /// <summary>
    /// Generate image: horizontal gradient
    /// </summary>
    public static Image GenImageGradientH(/* int */ int width, /* int */ int height, /* Color */ Color left, /* Color */ Color right)
    {
        // int => int
        // int => int
        // Color => Color
        // Color => Color
        // return Image => Image
        return Raylib.GenImageGradientH(width, height, left, right);
    }

    /// <summary>
    /// Generate image: radial gradient
    /// </summary>
    public static Image GenImageGradientRadial(/* int */ int width, /* int */ int height, /* float */ float density, /* Color */ Color inner, /* Color */ Color outer)
    {
        // int => int
        // int => int
        // float => float
        // Color => Color
        // Color => Color
        // return Image => Image
        return Raylib.GenImageGradientRadial(width, height, density, inner, outer);
    }

    /// <summary>
    /// Generate image: checked
    /// </summary>
    public static Image GenImageChecked(/* int */ int width, /* int */ int height, /* int */ int checksX, /* int */ int checksY, /* Color */ Color col1, /* Color */ Color col2)
    {
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // Color => Color
        // return Image => Image
        return Raylib.GenImageChecked(width, height, checksX, checksY, col1, col2);
    }

    /// <summary>
    /// Generate image: white noise
    /// </summary>
    public static Image GenImageWhiteNoise(/* int */ int width, /* int */ int height, /* float */ float factor)
    {
        // int => int
        // int => int
        // float => float
        // return Image => Image
        return Raylib.GenImageWhiteNoise(width, height, factor);
    }

    /// <summary>
    /// Generate image: cellular algorithm, bigger tileSize means bigger cells
    /// </summary>
    public static Image GenImageCellular(/* int */ int width, /* int */ int height, /* int */ int tileSize)
    {
        // int => int
        // int => int
        // int => int
        // return Image => Image
        return Raylib.GenImageCellular(width, height, tileSize);
    }

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    public static Image ImageCopy(/* Image */ Image image)
    {
        // Image => Image
        // return Image => Image
        return Raylib.ImageCopy(image);
    }

    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    public static Image ImageFromImage(/* Image */ Image image, /* Rectangle */ Rectangle rec)
    {
        // Image => Image
        // Rectangle => Rectangle
        // return Image => Image
        return Raylib.ImageFromImage(image, rec);
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public static Image ImageText(/* const char* */ string text, /* int */ int fontSize, /* Color */ Color color)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int => int
        // Color => Color
        // return Image => Image
        return Raylib.ImageText(text_.AsPtr(), fontSize, color);
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public static Image ImageTextEx(/* Font */ Font font, /* const char* */ string text, /* float */ float fontSize, /* float */ float spacing, /* Color */ Color tint)
    {
        // Font => Font
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // float => float
        // float => float
        // Color => Color
        // return Image => Image
        return Raylib.ImageTextEx(font, text_.AsPtr(), fontSize, spacing, tint);
    }

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    public static void ImageFormat(/* Image* */ Image* image, /* int */ int newFormat)
    {
        // Image* => Image*
        // int => int
        // return void => void
        Raylib.ImageFormat(image, newFormat);
    }

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    public static void ImageToPOT(/* Image* */ Image* image, /* Color */ Color fill)
    {
        // Image* => Image*
        // Color => Color
        // return void => void
        Raylib.ImageToPOT(image, fill);
    }

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    public static void ImageCrop(/* Image* */ Image* image, /* Rectangle */ Rectangle crop)
    {
        // Image* => Image*
        // Rectangle => Rectangle
        // return void => void
        Raylib.ImageCrop(image, crop);
    }

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    public static void ImageAlphaCrop(/* Image* */ Image* image, /* float */ float threshold)
    {
        // Image* => Image*
        // float => float
        // return void => void
        Raylib.ImageAlphaCrop(image, threshold);
    }

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    public static void ImageAlphaClear(/* Image* */ Image* image, /* Color */ Color color, /* float */ float threshold)
    {
        // Image* => Image*
        // Color => Color
        // float => float
        // return void => void
        Raylib.ImageAlphaClear(image, color, threshold);
    }

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    public static void ImageAlphaMask(/* Image* */ Image* image, /* Image */ Image alphaMask)
    {
        // Image* => Image*
        // Image => Image
        // return void => void
        Raylib.ImageAlphaMask(image, alphaMask);
    }

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    public static void ImageAlphaPremultiply(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageAlphaPremultiply(image);
    }

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    public static void ImageResize(/* Image* */ Image* image, /* int */ int newWidth, /* int */ int newHeight)
    {
        // Image* => Image*
        // int => int
        // int => int
        // return void => void
        Raylib.ImageResize(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public static void ImageResizeNN(/* Image* */ Image* image, /* int */ int newWidth, /* int */ int newHeight)
    {
        // Image* => Image*
        // int => int
        // int => int
        // return void => void
        Raylib.ImageResizeNN(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    public static void ImageResizeCanvas(/* Image* */ Image* image, /* int */ int newWidth, /* int */ int newHeight, /* int */ int offsetX, /* int */ int offsetY, /* Color */ Color fill)
    {
        // Image* => Image*
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageResizeCanvas(image, newWidth, newHeight, offsetX, offsetY, fill);
    }

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    public static void ImageMipmaps(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageMipmaps(image);
    }

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public static void ImageDither(/* Image* */ Image* image, /* int */ int rBpp, /* int */ int gBpp, /* int */ int bBpp, /* int */ int aBpp)
    {
        // Image* => Image*
        // int => int
        // int => int
        // int => int
        // int => int
        // return void => void
        Raylib.ImageDither(image, rBpp, gBpp, bBpp, aBpp);
    }

    /// <summary>
    /// Flip image vertically
    /// </summary>
    public static void ImageFlipVertical(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageFlipVertical(image);
    }

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    public static void ImageFlipHorizontal(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageFlipHorizontal(image);
    }

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    public static void ImageRotateCW(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageRotateCW(image);
    }

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    public static void ImageRotateCCW(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageRotateCCW(image);
    }

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    public static void ImageColorTint(/* Image* */ Image* image, /* Color */ Color color)
    {
        // Image* => Image*
        // Color => Color
        // return void => void
        Raylib.ImageColorTint(image, color);
    }

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    public static void ImageColorInvert(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageColorInvert(image);
    }

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    public static void ImageColorGrayscale(/* Image* */ Image* image)
    {
        // Image* => Image*
        // return void => void
        Raylib.ImageColorGrayscale(image);
    }

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    public static void ImageColorContrast(/* Image* */ Image* image, /* float */ float contrast)
    {
        // Image* => Image*
        // float => float
        // return void => void
        Raylib.ImageColorContrast(image, contrast);
    }

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    public static void ImageColorBrightness(/* Image* */ Image* image, /* int */ int brightness)
    {
        // Image* => Image*
        // int => int
        // return void => void
        Raylib.ImageColorBrightness(image, brightness);
    }

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    public static void ImageColorReplace(/* Image* */ Image* image, /* Color */ Color color, /* Color */ Color replace)
    {
        // Image* => Image*
        // Color => Color
        // Color => Color
        // return void => void
        Raylib.ImageColorReplace(image, color, replace);
    }

    /// <summary>
    /// Load color data from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color[] LoadImageColors(/* Image */ Image image)
    {
        // Image => Image
        // return Color* => Color[]
        return Helpers.PrtToArray(Raylib.LoadImageColors(image));
    }

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color[] LoadImagePalette(/* Image */ Image image, /* int */ int maxPaletteSize, /* int* */ int* colorCount)
    {
        // Image => Image
        // int => int
        // int* => int*
        // return Color* => Color[]
        return Helpers.PrtToArray(Raylib.LoadImagePalette(image, maxPaletteSize, colorCount));
    }

    /// <summary>
    /// Unload color data loaded with LoadImageColors()
    /// </summary>
    public static void UnloadImageColors(/* Color* */ Color[] colors)
    {
        // Color* => Color[]
        var colors_ = Helpers.ArrayToPtr(colors);
        // return void => void
        Raylib.UnloadImageColors(colors_);
    }

    /// <summary>
    /// Unload colors palette loaded with LoadImagePalette()
    /// </summary>
    public static void UnloadImagePalette(/* Color* */ Color[] colors)
    {
        // Color* => Color[]
        var colors_ = Helpers.ArrayToPtr(colors);
        // return void => void
        Raylib.UnloadImagePalette(colors_);
    }

    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    public static Rectangle GetImageAlphaBorder(/* Image */ Image image, /* float */ float threshold)
    {
        // Image => Image
        // float => float
        // return Rectangle => Rectangle
        return Raylib.GetImageAlphaBorder(image, threshold);
    }

    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    public static Color GetImageColor(/* Image */ Image image, /* int */ int x, /* int */ int y)
    {
        // Image => Image
        // int => int
        // int => int
        // return Color => Color
        return Raylib.GetImageColor(image, x, y);
    }

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    public static void ImageClearBackground(/* Image* */ Image* dst, /* Color */ Color color)
    {
        // Image* => Image*
        // Color => Color
        // return void => void
        Raylib.ImageClearBackground(dst, color);
    }

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    public static void ImageDrawPixel(/* Image* */ Image* dst, /* int */ int posX, /* int */ int posY, /* Color */ Color color)
    {
        // Image* => Image*
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawPixel(dst, posX, posY, color);
    }

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    public static void ImageDrawPixelV(/* Image* */ Image* dst, /* Vector2 */ Vector2 position, /* Color */ Color color)
    {
        // Image* => Image*
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.ImageDrawPixelV(dst, position, color);
    }

    /// <summary>
    /// Draw line within an image
    /// </summary>
    public static void ImageDrawLine(/* Image* */ Image* dst, /* int */ int startPosX, /* int */ int startPosY, /* int */ int endPosX, /* int */ int endPosY, /* Color */ Color color)
    {
        // Image* => Image*
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawLine(dst, startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    public static void ImageDrawLineV(/* Image* */ Image* dst, /* Vector2 */ Vector2 start, /* Vector2 */ Vector2 end, /* Color */ Color color)
    {
        // Image* => Image*
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.ImageDrawLineV(dst, start, end, color);
    }

    /// <summary>
    /// Draw circle within an image
    /// </summary>
    public static void ImageDrawCircle(/* Image* */ Image* dst, /* int */ int centerX, /* int */ int centerY, /* int */ int radius, /* Color */ Color color)
    {
        // Image* => Image*
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawCircle(dst, centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw circle within an image (Vector version)
    /// </summary>
    public static void ImageDrawCircleV(/* Image* */ Image* dst, /* Vector2 */ Vector2 center, /* int */ int radius, /* Color */ Color color)
    {
        // Image* => Image*
        // Vector2 => Vector2
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawCircleV(dst, center, radius, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangle(/* Image* */ Image* dst, /* int */ int posX, /* int */ int posY, /* int */ int width, /* int */ int height, /* Color */ Color color)
    {
        // Image* => Image*
        // int => int
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawRectangle(dst, posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    public static void ImageDrawRectangleV(/* Image* */ Image* dst, /* Vector2 */ Vector2 position, /* Vector2 */ Vector2 size, /* Color */ Color color)
    {
        // Image* => Image*
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.ImageDrawRectangleV(dst, position, size, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangleRec(/* Image* */ Image* dst, /* Rectangle */ Rectangle rec, /* Color */ Color color)
    {
        // Image* => Image*
        // Rectangle => Rectangle
        // Color => Color
        // return void => void
        Raylib.ImageDrawRectangleRec(dst, rec, color);
    }

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    public static void ImageDrawRectangleLines(/* Image* */ Image* dst, /* Rectangle */ Rectangle rec, /* int */ int thick, /* Color */ Color color)
    {
        // Image* => Image*
        // Rectangle => Rectangle
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawRectangleLines(dst, rec, thick, color);
    }

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public static void ImageDraw(/* Image* */ Image* dst, /* Image */ Image src, /* Rectangle */ Rectangle srcRec, /* Rectangle */ Rectangle dstRec, /* Color */ Color tint)
    {
        // Image* => Image*
        // Image => Image
        // Rectangle => Rectangle
        // Rectangle => Rectangle
        // Color => Color
        // return void => void
        Raylib.ImageDraw(dst, src, srcRec, dstRec, tint);
    }

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    public static void ImageDrawText(/* Image* */ Image* dst, /* const char* */ string text, /* int */ int posX, /* int */ int posY, /* int */ int fontSize, /* Color */ Color color)
    {
        // Image* => Image*
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.ImageDrawText(dst, text_.AsPtr(), posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void ImageDrawTextEx(/* Image* */ Image* dst, /* Font */ Font font, /* const char* */ string text, /* Vector2 */ Vector2 position, /* float */ float fontSize, /* float */ float spacing, /* Color */ Color tint)
    {
        // Image* => Image*
        // Font => Font
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // Vector2 => Vector2
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.ImageDrawTextEx(dst, font, text_.AsPtr(), position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public static Texture LoadTexture(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Texture => Texture
        return Raylib.LoadTexture(fileName_.AsPtr());
    }

    /// <summary>
    /// Load texture from image data
    /// </summary>
    public static Texture LoadTextureFromImage(/* Image */ Image image)
    {
        // Image => Image
        // return Texture => Texture
        return Raylib.LoadTextureFromImage(image);
    }

    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    public static TextureCubemap LoadTextureCubemap(/* Image */ Image image, /* int */ int layout)
    {
        // Image => Image
        // int => int
        // return TextureCubemap => TextureCubemap
        return Raylib.LoadTextureCubemap(image, layout);
    }

    /// <summary>
    /// Load texture for rendering (framebuffer)
    /// </summary>
    public static RenderTexture LoadRenderTexture(/* int */ int width, /* int */ int height)
    {
        // int => int
        // int => int
        // return RenderTexture => RenderTexture
        return Raylib.LoadRenderTexture(width, height);
    }

    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadTexture(/* Texture2D */ Texture texture)
    {
        // Texture => Texture
        // return void => void
        Raylib.UnloadTexture(texture);
    }

    /// <summary>
    /// Unload render texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadRenderTexture(/* RenderTexture2D */ RenderTexture target)
    {
        // RenderTexture => RenderTexture
        // return void => void
        Raylib.UnloadRenderTexture(target);
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public static void UpdateTexture(/* Texture2D */ Texture texture, /* const void* */ IntPtr pixels)
    {
        // Texture => Texture
        // void* => IntPtr
        var pixels_ = (void*)pixels;
        // return void => void
        Raylib.UpdateTexture(texture, pixels_);
    }

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    public static void UpdateTextureRec(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle rec, /* const void* */ IntPtr pixels)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // void* => IntPtr
        var pixels_ = (void*)pixels;
        // return void => void
        Raylib.UpdateTextureRec(texture, rec, pixels_);
    }

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    public static void GenTextureMipmaps(/* Texture2D* */ Texture* texture)
    {
        // Texture* => Texture*
        // return void => void
        Raylib.GenTextureMipmaps(texture);
    }

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    public static void SetTextureFilter(/* Texture2D */ Texture texture, /* int */ int filter)
    {
        // Texture => Texture
        // int => int
        // return void => void
        Raylib.SetTextureFilter(texture, filter);
    }

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    public static void SetTextureWrap(/* Texture2D */ Texture texture, /* int */ int wrap)
    {
        // Texture => Texture
        // int => int
        // return void => void
        Raylib.SetTextureWrap(texture, wrap);
    }

    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    public static void DrawTexture(/* Texture2D */ Texture texture, /* int */ int posX, /* int */ int posY, /* Color */ Color tint)
    {
        // Texture => Texture
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawTexture(texture, posX, posY, tint);
    }

    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    public static void DrawTextureV(/* Texture2D */ Texture texture, /* Vector2 */ Vector2 position, /* Color */ Color tint)
    {
        // Texture => Texture
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawTextureV(texture, position, tint);
    }

    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    public static void DrawTextureEx(/* Texture2D */ Texture texture, /* Vector2 */ Vector2 position, /* float */ float rotation, /* float */ float scale, /* Color */ Color tint)
    {
        // Texture => Texture
        // Vector2 => Vector2
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    public static void DrawTextureRec(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Vector2 */ Vector2 position, /* Color */ Color tint)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawTextureRec(texture, source, position, tint);
    }

    /// <summary>
    /// Draw texture quad with tiling and offset parameters
    /// </summary>
    public static void DrawTextureQuad(/* Texture2D */ Texture texture, /* Vector2 */ Vector2 tiling, /* Vector2 */ Vector2 offset, /* Rectangle */ Rectangle quad, /* Color */ Color tint)
    {
        // Texture => Texture
        // Vector2 => Vector2
        // Vector2 => Vector2
        // Rectangle => Rectangle
        // Color => Color
        // return void => void
        Raylib.DrawTextureQuad(texture, tiling, offset, quad, tint);
    }

    /// <summary>
    /// Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.
    /// </summary>
    public static void DrawTextureTiled(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Rectangle */ Rectangle dest, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* float */ float scale, /* Color */ Color tint)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // Rectangle => Rectangle
        // Vector2 => Vector2
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextureTiled(texture, source, dest, origin, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    public static void DrawTexturePro(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Rectangle */ Rectangle dest, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* Color */ Color tint)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // Rectangle => Rectangle
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    public static void DrawTextureNPatch(/* Texture2D */ Texture texture, /* NPatchInfo */ NPatchInfo nPatchInfo, /* Rectangle */ Rectangle dest, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* Color */ Color tint)
    {
        // Texture => Texture
        // NPatchInfo => NPatchInfo
        // Rectangle => Rectangle
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draw a textured polygon
    /// </summary>
    public static void DrawTexturePoly(/* Texture2D */ Texture texture, /* Vector2 */ Vector2 center, /* Vector2* */ Vector2* points, /* Vector2* */ Vector2* texcoords, /* int */ int pointCount, /* Color */ Color tint)
    {
        // Texture => Texture
        // Vector2 => Vector2
        // Vector2* => Vector2*
        // Vector2* => Vector2*
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawTexturePoly(texture, center, points, texcoords, pointCount, tint);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color Fade(/* Color */ Color color, /* float */ float alpha)
    {
        // Color => Color
        // float => float
        // return Color => Color
        return Raylib.Fade(color, alpha);
    }

    /// <summary>
    /// Get hexadecimal value for a Color
    /// </summary>
    public static int ColorToInt(/* Color */ Color color)
    {
        // Color => Color
        // return int => int
        return Raylib.ColorToInt(color);
    }

    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    public static Vector4 ColorNormalize(/* Color */ Color color)
    {
        // Color => Color
        // return Vector4 => Vector4
        return Raylib.ColorNormalize(color);
    }

    /// <summary>
    /// Get Color from normalized values [0..1]
    /// </summary>
    public static Color ColorFromNormalized(/* Vector4 */ Vector4 normalized)
    {
        // Vector4 => Vector4
        // return Color => Color
        return Raylib.ColorFromNormalized(normalized);
    }

    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Vector3 ColorToHSV(/* Color */ Color color)
    {
        // Color => Color
        // return Vector3 => Vector3
        return Raylib.ColorToHSV(color);
    }

    /// <summary>
    /// Get a Color from HSV values, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Color ColorFromHSV(/* float */ float hue, /* float */ float saturation, /* float */ float value)
    {
        // float => float
        // float => float
        // float => float
        // return Color => Color
        return Raylib.ColorFromHSV(hue, saturation, value);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color ColorAlpha(/* Color */ Color color, /* float */ float alpha)
    {
        // Color => Color
        // float => float
        // return Color => Color
        return Raylib.ColorAlpha(color, alpha);
    }

    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    public static Color ColorAlphaBlend(/* Color */ Color dst, /* Color */ Color src, /* Color */ Color tint)
    {
        // Color => Color
        // Color => Color
        // Color => Color
        // return Color => Color
        return Raylib.ColorAlphaBlend(dst, src, tint);
    }

    /// <summary>
    /// Get Color structure from hexadecimal value
    /// </summary>
    public static Color GetColor(/* unsigned int */ uint hexValue)
    {
        // uint => uint
        // return Color => Color
        return Raylib.GetColor(hexValue);
    }

    /// <summary>
    /// Get Color from a source pixel pointer of certain format
    /// </summary>
    public static Color GetPixelColor(/* void* */ IntPtr srcPtr, /* int */ int format)
    {
        // void* => IntPtr
        var srcPtr_ = (void*)srcPtr;
        // int => int
        // return Color => Color
        return Raylib.GetPixelColor(srcPtr_, format);
    }

    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    public static void SetPixelColor(/* void* */ IntPtr dstPtr, /* Color */ Color color, /* int */ int format)
    {
        // void* => IntPtr
        var dstPtr_ = (void*)dstPtr;
        // Color => Color
        // int => int
        // return void => void
        Raylib.SetPixelColor(dstPtr_, color, format);
    }

    /// <summary>
    /// Get pixel data size in bytes for certain format
    /// </summary>
    public static int GetPixelDataSize(/* int */ int width, /* int */ int height, /* int */ int format)
    {
        // int => int
        // int => int
        // int => int
        // return int => int
        return Raylib.GetPixelDataSize(width, height, format);
    }

    /// <summary>
    /// Get the default Font
    /// </summary>
    public static Font GetFontDefault()
    {
        // return Font => Font
        return Raylib.GetFontDefault();
    }

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    public static Font LoadFont(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Font => Font
        return Raylib.LoadFont(fileName_.AsPtr());
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for fontChars and 0 for glyphCount to load the default character set
    /// </summary>
    public static Font LoadFontEx(/* const char* */ string fileName, /* int */ int fontSize, /* int* */ int* fontChars, /* int */ int glyphCount)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // int => int
        // int* => int*
        // int => int
        // return Font => Font
        return Raylib.LoadFontEx(fileName_.AsPtr(), fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    public static Font LoadFontFromImage(/* Image */ Image image, /* Color */ Color key, /* int */ int firstChar)
    {
        // Image => Image
        // Color => Color
        // int => int
        // return Font => Font
        return Raylib.LoadFontFromImage(image, key, firstChar);
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(/* const char* */ string fileType, /* const unsigned char* */ byte[] fileData, /* int */ int dataSize, /* int */ int fontSize, /* int* */ int* fontChars, /* int */ int glyphCount)
    {
        // sbyte* => string
        using var fileType_ = fileType.MarshalUtf8();
        // byte* => byte[]
        var fileData_ = Helpers.ArrayToPtr(fileData);
        // int => int
        // int => int
        // int* => int*
        // int => int
        // return Font => Font
        return Raylib.LoadFontFromMemory(fileType_.AsPtr(), fileData_, dataSize, fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo* LoadFontData(/* const unsigned char* */ byte[] fileData, /* int */ int dataSize, /* int */ int fontSize, /* int* */ int* fontChars, /* int */ int glyphCount, /* int */ int type)
    {
        // byte* => byte[]
        var fileData_ = Helpers.ArrayToPtr(fileData);
        // int => int
        // int => int
        // int* => int*
        // int => int
        // int => int
        // return GlyphInfo* => GlyphInfo*
        return Raylib.LoadFontData(fileData_, dataSize, fontSize, fontChars, glyphCount, type);
    }

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public static Image GenImageFontAtlas(/* const GlyphInfo* */ GlyphInfo* chars, /* Rectangle** */ Rectangle** recs, /* int */ int glyphCount, /* int */ int fontSize, /* int */ int padding, /* int */ int packMethod)
    {
        // GlyphInfo* => GlyphInfo*
        // Rectangle** => Rectangle**
        // int => int
        // int => int
        // int => int
        // int => int
        // return Image => Image
        return Raylib.GenImageFontAtlas(chars, recs, glyphCount, fontSize, padding, packMethod);
    }

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    public static void UnloadFontData(/* GlyphInfo* */ GlyphInfo* chars, /* int */ int glyphCount)
    {
        // GlyphInfo* => GlyphInfo*
        // int => int
        // return void => void
        Raylib.UnloadFontData(chars, glyphCount);
    }

    /// <summary>
    /// Unload font from GPU memory (VRAM)
    /// </summary>
    public static void UnloadFont(/* Font */ Font font)
    {
        // Font => Font
        // return void => void
        Raylib.UnloadFont(font);
    }

    /// <summary>
    /// Export font as code file, returns true on success
    /// </summary>
    public static bool ExportFontAsCode(/* Font */ Font font, /* const char* */ string fileName)
    {
        // Font => Font
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportFontAsCode(font, fileName_.AsPtr());
    }

    /// <summary>
    /// Draw current FPS
    /// </summary>
    public static void DrawFPS(/* int */ int posX, /* int */ int posY)
    {
        // int => int
        // int => int
        // return void => void
        Raylib.DrawFPS(posX, posY);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(/* const char* */ string text, /* int */ int posX, /* int */ int posY, /* int */ int fontSize, /* Color */ Color color)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int => int
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawText(text_.AsPtr(), posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public static void DrawTextEx(/* Font */ Font font, /* const char* */ string text, /* Vector2 */ Vector2 position, /* float */ float fontSize, /* float */ float spacing, /* Color */ Color tint)
    {
        // Font => Font
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // Vector2 => Vector2
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextEx(font, text_.AsPtr(), position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawTextPro(/* Font */ Font font, /* const char* */ string text, /* Vector2 */ Vector2 position, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* float */ float fontSize, /* float */ float spacing, /* Color */ Color tint)
    {
        // Font => Font
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextPro(font, text_.AsPtr(), position, origin, rotation, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    public static void DrawTextCodepoint(/* Font */ Font font, /* int */ int codepoint, /* Vector2 */ Vector2 position, /* float */ float fontSize, /* Color */ Color tint)
    {
        // Font => Font
        // int => int
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <summary>
    /// Draw multiple character (codepoint)
    /// </summary>
    public static void DrawTextCodepoints(/* Font */ Font font, /* const int* */ int* codepoints, /* int */ int count, /* Vector2 */ Vector2 position, /* float */ float fontSize, /* float */ float spacing, /* Color */ Color tint)
    {
        // Font => Font
        // int* => int*
        // int => int
        // Vector2 => Vector2
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawTextCodepoints(font, codepoints, count, position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public static int MeasureText(/* const char* */ string text, /* int */ int fontSize)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int => int
        // return int => int
        return Raylib.MeasureText(text_.AsPtr(), fontSize);
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public static Vector2 MeasureTextEx(/* Font */ Font font, /* const char* */ string text, /* float */ float fontSize, /* float */ float spacing)
    {
        // Font => Font
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // float => float
        // float => float
        // return Vector2 => Vector2
        return Raylib.MeasureTextEx(font, text_.AsPtr(), fontSize, spacing);
    }

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static int GetGlyphIndex(/* Font */ Font font, /* int */ int codepoint)
    {
        // Font => Font
        // int => int
        // return int => int
        return Raylib.GetGlyphIndex(font, codepoint);
    }

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static GlyphInfo GetGlyphInfo(/* Font */ Font font, /* int */ int codepoint)
    {
        // Font => Font
        // int => int
        // return GlyphInfo => GlyphInfo
        return Raylib.GetGlyphInfo(font, codepoint);
    }

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static Rectangle GetGlyphAtlasRec(/* Font */ Font font, /* int */ int codepoint)
    {
        // Font => Font
        // int => int
        // return Rectangle => Rectangle
        return Raylib.GetGlyphAtlasRec(font, codepoint);
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public static int* LoadCodepoints(/* const char* */ string text, /* int* */ int* count)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int* => int*
        // return int* => int*
        return Raylib.LoadCodepoints(text_.AsPtr(), count);
    }

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    public static void UnloadCodepoints(/* int* */ int* codepoints)
    {
        // int* => int*
        // return void => void
        Raylib.UnloadCodepoints(codepoints);
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public static int GetCodepointCount(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return int => int
        return Raylib.GetCodepointCount(text_.AsPtr());
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(/* const char* */ string text, /* int* */ int* bytesProcessed)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int* => int*
        // return int => int
        return Raylib.GetCodepoint(text_.AsPtr(), bytesProcessed);
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public static string CodepointToUTF8(/* int */ int codepoint, /* int* */ int* byteSize)
    {
        // int => int
        // int* => int*
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.CodepointToUTF8(codepoint, byteSize));
    }

    /// <summary>
    /// Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextCodepointsToUTF8(/* const int* */ int* codepoints, /* int */ int length)
    {
        // int* => int*
        // int => int
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextCodepointsToUTF8(codepoints, length));
    }

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    public static int TextCopy(/* char* */ string dst, /* const char* */ string src)
    {
        // sbyte* => string
        using var dst_ = dst.MarshalUtf8();
        // sbyte* => string
        using var src_ = src.MarshalUtf8();
        // return int => int
        return Raylib.TextCopy(dst_.AsPtr(), src_.AsPtr());
    }

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    public static bool TextIsEqual(/* const char* */ string text1, /* const char* */ string text2)
    {
        // sbyte* => string
        using var text1_ = text1.MarshalUtf8();
        // sbyte* => string
        using var text2_ = text2.MarshalUtf8();
        // return bool => bool
        return Raylib.TextIsEqual(text1_.AsPtr(), text2_.AsPtr());
    }

    /// <summary>
    /// Get text length, checks for '\0' ending
    /// </summary>
    public static uint TextLength(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return uint => uint
        return Raylib.TextLength(text_.AsPtr());
    }

//  /// <summary>
//  /// Text formatting with variables (sprintf() style)
//  /// </summary>
//  public static string TextFormat(/* const char* */ string text, /* ... */ params object[] args)
//  {
//      // sbyte* => string
//      using var text_ = text.MarshalUtf8();
//      // __arglist => params object[]
//      // return sbyte* => string
//      return Helpers.Utf8ToString(Raylib.TextFormat(text_.AsPtr(), __arglist(args)));
//  }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    public static string TextSubtext(/* const char* */ string text, /* int */ int position, /* int */ int length)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // int => int
        // int => int
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextSubtext(text_.AsPtr(), position, length));
    }

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextReplace(/* char* */ string text, /* const char* */ string replace, /* const char* */ string by)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // sbyte* => string
        using var replace_ = replace.MarshalUtf8();
        // sbyte* => string
        using var by_ = by.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextReplace(text_.AsPtr(), replace_.AsPtr(), by_.AsPtr()));
    }

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    public static string TextInsert(/* const char* */ string text, /* const char* */ string insert, /* int */ int position)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // sbyte* => string
        using var insert_ = insert.MarshalUtf8();
        // int => int
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextInsert(text_.AsPtr(), insert_.AsPtr(), position));
    }

//  /// <summary>
//  /// Join text strings with delimiter
//  /// </summary>
//  public static string TextJoin(/* const char** */ sbyte** textList, /* int */ int count, /* const char* */ string delimiter)
//  {
//      // sbyte** => sbyte**
//      // int => int
//      // sbyte* => string
//      using var delimiter_ = delimiter.MarshalUtf8();
//      // return sbyte* => string
//      return Helpers.Utf8ToString(Raylib.TextJoin(textList, count, delimiter_.AsPtr()));
//  }

//  /// <summary>
//  /// Split text into multiple strings
//  /// </summary>
//  public static sbyte** TextSplit(/* const char* */ string text, /* char */ sbyte delimiter, /* int* */ int* count)
//  {
//      // sbyte* => string
//      using var text_ = text.MarshalUtf8();
//      // sbyte => sbyte
//      // int* => int*
//      // return sbyte** => sbyte**
//      return Raylib.TextSplit(text_.AsPtr(), delimiter, count);
//  }

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    public static void TextAppend(/* char* */ string text, /* const char* */ string append, /* int* */ int* position)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // sbyte* => string
        using var append_ = append.MarshalUtf8();
        // int* => int*
        // return void => void
        Raylib.TextAppend(text_.AsPtr(), append_.AsPtr(), position);
    }

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    public static int TextFindIndex(/* const char* */ string text, /* const char* */ string find)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // sbyte* => string
        using var find_ = find.MarshalUtf8();
        // return int => int
        return Raylib.TextFindIndex(text_.AsPtr(), find_.AsPtr());
    }

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    public static string TextToUpper(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextToUpper(text_.AsPtr()));
    }

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    public static string TextToLower(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextToLower(text_.AsPtr()));
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public static string TextToPascal(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return sbyte* => string
        return Helpers.Utf8ToString(Raylib.TextToPascal(text_.AsPtr()));
    }

    /// <summary>
    /// Get integer value from text (negative values not supported)
    /// </summary>
    public static int TextToInteger(/* const char* */ string text)
    {
        // sbyte* => string
        using var text_ = text.MarshalUtf8();
        // return int => int
        return Raylib.TextToInteger(text_.AsPtr());
    }

    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    public static void DrawLine3D(/* Vector3 */ Vector3 startPos, /* Vector3 */ Vector3 endPos, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawLine3D(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    public static void DrawPoint3D(/* Vector3 */ Vector3 position, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawPoint3D(position, color);
    }

    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    public static void DrawCircle3D(/* Vector3 */ Vector3 center, /* float */ float radius, /* Vector3 */ Vector3 rotationAxis, /* float */ float rotationAngle, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // Vector3 => Vector3
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle3D(/* Vector3 */ Vector3 v1, /* Vector3 */ Vector3 v2, /* Vector3 */ Vector3 v3, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawTriangle3D(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip3D(/* Vector3* */ Vector3* points, /* int */ int pointCount, /* Color */ Color color)
    {
        // Vector3* => Vector3*
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawTriangleStrip3D(points, pointCount, color);
    }

    /// <summary>
    /// Draw cube
    /// </summary>
    public static void DrawCube(/* Vector3 */ Vector3 position, /* float */ float width, /* float */ float height, /* float */ float length, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCube(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    public static void DrawCubeV(/* Vector3 */ Vector3 position, /* Vector3 */ Vector3 size, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawCubeV(position, size, color);
    }

    /// <summary>
    /// Draw cube wires
    /// </summary>
    public static void DrawCubeWires(/* Vector3 */ Vector3 position, /* float */ float width, /* float */ float height, /* float */ float length, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCubeWires(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    public static void DrawCubeWiresV(/* Vector3 */ Vector3 position, /* Vector3 */ Vector3 size, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawCubeWiresV(position, size, color);
    }

    /// <summary>
    /// Draw cube textured
    /// </summary>
    public static void DrawCubeTexture(/* Texture2D */ Texture texture, /* Vector3 */ Vector3 position, /* float */ float width, /* float */ float height, /* float */ float length, /* Color */ Color color)
    {
        // Texture => Texture
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCubeTexture(texture, position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube with a region of a texture
    /// </summary>
    public static void DrawCubeTextureRec(/* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Vector3 */ Vector3 position, /* float */ float width, /* float */ float height, /* float */ float length, /* Color */ Color color)
    {
        // Texture => Texture
        // Rectangle => Rectangle
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawCubeTextureRec(texture, source, position, width, height, length, color);
    }

    /// <summary>
    /// Draw sphere
    /// </summary>
    public static void DrawSphere(/* Vector3 */ Vector3 centerPos, /* float */ float radius, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawSphere(centerPos, radius, color);
    }

    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    public static void DrawSphereEx(/* Vector3 */ Vector3 centerPos, /* float */ float radius, /* int */ int rings, /* int */ int slices, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawSphereEx(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    public static void DrawSphereWires(/* Vector3 */ Vector3 centerPos, /* float */ float radius, /* int */ int rings, /* int */ int slices, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // int => int
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawSphereWires(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    public static void DrawCylinder(/* Vector3 */ Vector3 position, /* float */ float radiusTop, /* float */ float radiusBottom, /* float */ float height, /* int */ int slices, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderEx(/* Vector3 */ Vector3 startPos, /* Vector3 */ Vector3 endPos, /* float */ float startRadius, /* float */ float endRadius, /* int */ int sides, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCylinderEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    public static void DrawCylinderWires(/* Vector3 */ Vector3 position, /* float */ float radiusTop, /* float */ float radiusBottom, /* float */ float height, /* int */ int slices, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // float => float
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderWiresEx(/* Vector3 */ Vector3 startPos, /* Vector3 */ Vector3 endPos, /* float */ float startRadius, /* float */ float endRadius, /* int */ int sides, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector3 => Vector3
        // float => float
        // float => float
        // int => int
        // Color => Color
        // return void => void
        Raylib.DrawCylinderWiresEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    public static void DrawPlane(/* Vector3 */ Vector3 centerPos, /* Vector2 */ Vector2 size, /* Color */ Color color)
    {
        // Vector3 => Vector3
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawPlane(centerPos, size, color);
    }

    /// <summary>
    /// Draw a ray line
    /// </summary>
    public static void DrawRay(/* Ray */ Ray ray, /* Color */ Color color)
    {
        // Ray => Ray
        // Color => Color
        // return void => void
        Raylib.DrawRay(ray, color);
    }

    /// <summary>
    /// Draw a grid (centered at (0, 0, 0))
    /// </summary>
    public static void DrawGrid(/* int */ int slices, /* float */ float spacing)
    {
        // int => int
        // float => float
        // return void => void
        Raylib.DrawGrid(slices, spacing);
    }

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    public static Model LoadModel(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Model => Model
        return Raylib.LoadModel(fileName_.AsPtr());
    }

    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    public static Model LoadModelFromMesh(/* Mesh */ Mesh mesh)
    {
        // Mesh => Mesh
        // return Model => Model
        return Raylib.LoadModelFromMesh(mesh);
    }

    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModel(/* Model */ Model model)
    {
        // Model => Model
        // return void => void
        Raylib.UnloadModel(model);
    }

    /// <summary>
    /// Unload model (but not meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModelKeepMeshes(/* Model */ Model model)
    {
        // Model => Model
        // return void => void
        Raylib.UnloadModelKeepMeshes(model);
    }

    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    public static BoundingBox GetModelBoundingBox(/* Model */ Model model)
    {
        // Model => Model
        // return BoundingBox => BoundingBox
        return Raylib.GetModelBoundingBox(model);
    }

    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    public static void DrawModel(/* Model */ Model model, /* Vector3 */ Vector3 position, /* float */ float scale, /* Color */ Color tint)
    {
        // Model => Model
        // Vector3 => Vector3
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawModel(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    public static void DrawModelEx(/* Model */ Model model, /* Vector3 */ Vector3 position, /* Vector3 */ Vector3 rotationAxis, /* float */ float rotationAngle, /* Vector3 */ Vector3 scale, /* Color */ Color tint)
    {
        // Model => Model
        // Vector3 => Vector3
        // Vector3 => Vector3
        // float => float
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    public static void DrawModelWires(/* Model */ Model model, /* Vector3 */ Vector3 position, /* float */ float scale, /* Color */ Color tint)
    {
        // Model => Model
        // Vector3 => Vector3
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawModelWires(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    public static void DrawModelWiresEx(/* Model */ Model model, /* Vector3 */ Vector3 position, /* Vector3 */ Vector3 rotationAxis, /* float */ float rotationAngle, /* Vector3 */ Vector3 scale, /* Color */ Color tint)
    {
        // Model => Model
        // Vector3 => Vector3
        // Vector3 => Vector3
        // float => float
        // Vector3 => Vector3
        // Color => Color
        // return void => void
        Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    public static void DrawBoundingBox(/* BoundingBox */ BoundingBox box, /* Color */ Color color)
    {
        // BoundingBox => BoundingBox
        // Color => Color
        // return void => void
        Raylib.DrawBoundingBox(box, color);
    }

    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    public static void DrawBillboard(/* Camera */ Camera3D camera, /* Texture2D */ Texture texture, /* Vector3 */ Vector3 position, /* float */ float size, /* Color */ Color tint)
    {
        // Camera3D => Camera3D
        // Texture => Texture
        // Vector3 => Vector3
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawBillboard(camera, texture, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    public static void DrawBillboardRec(/* Camera */ Camera3D camera, /* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Vector3 */ Vector3 position, /* Vector2 */ Vector2 size, /* Color */ Color tint)
    {
        // Camera3D => Camera3D
        // Texture => Texture
        // Rectangle => Rectangle
        // Vector3 => Vector3
        // Vector2 => Vector2
        // Color => Color
        // return void => void
        Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    public static void DrawBillboardPro(/* Camera */ Camera3D camera, /* Texture2D */ Texture texture, /* Rectangle */ Rectangle source, /* Vector3 */ Vector3 position, /* Vector3 */ Vector3 up, /* Vector2 */ Vector2 size, /* Vector2 */ Vector2 origin, /* float */ float rotation, /* Color */ Color tint)
    {
        // Camera3D => Camera3D
        // Texture => Texture
        // Rectangle => Rectangle
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Vector2 => Vector2
        // Vector2 => Vector2
        // float => float
        // Color => Color
        // return void => void
        Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
    }

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public static void UploadMesh(/* Mesh* */ Mesh* mesh, /* bool */ bool dynamic)
    {
        // Mesh* => Mesh*
        // bool => bool
        // return void => void
        Raylib.UploadMesh(mesh, dynamic);
    }

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public static void UpdateMeshBuffer(/* Mesh */ Mesh mesh, /* int */ int index, /* const void* */ IntPtr data, /* int */ int dataSize, /* int */ int offset)
    {
        // Mesh => Mesh
        // int => int
        // void* => IntPtr
        var data_ = (void*)data;
        // int => int
        // int => int
        // return void => void
        Raylib.UpdateMeshBuffer(mesh, index, data_, dataSize, offset);
    }

    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    public static void UnloadMesh(/* Mesh */ Mesh mesh)
    {
        // Mesh => Mesh
        // return void => void
        Raylib.UnloadMesh(mesh);
    }

    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    public static void DrawMesh(/* Mesh */ Mesh mesh, /* Material */ Material material, /* Matrix */ Matrix4x4 transform)
    {
        // Mesh => Mesh
        // Material => Material
        // Matrix4x4 => Matrix4x4
        // return void => void
        Raylib.DrawMesh(mesh, material, transform);
    }

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    public static void DrawMeshInstanced(/* Mesh */ Mesh mesh, /* Material */ Material material, /* const Matrix* */ Matrix4x4* transforms, /* int */ int instances)
    {
        // Mesh => Mesh
        // Material => Material
        // Matrix4x4* => Matrix4x4*
        // int => int
        // return void => void
        Raylib.DrawMeshInstanced(mesh, material, transforms, instances);
    }

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    public static bool ExportMesh(/* Mesh */ Mesh mesh, /* const char* */ string fileName)
    {
        // Mesh => Mesh
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportMesh(mesh, fileName_.AsPtr());
    }

    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    public static BoundingBox GetMeshBoundingBox(/* Mesh */ Mesh mesh)
    {
        // Mesh => Mesh
        // return BoundingBox => BoundingBox
        return Raylib.GetMeshBoundingBox(mesh);
    }

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    public static void GenMeshTangents(/* Mesh* */ Mesh* mesh)
    {
        // Mesh* => Mesh*
        // return void => void
        Raylib.GenMeshTangents(mesh);
    }

    /// <summary>
    /// Compute mesh binormals
    /// </summary>
    public static void GenMeshBinormals(/* Mesh* */ Mesh* mesh)
    {
        // Mesh* => Mesh*
        // return void => void
        Raylib.GenMeshBinormals(mesh);
    }

    /// <summary>
    /// Generate polygonal mesh
    /// </summary>
    public static Mesh GenMeshPoly(/* int */ int sides, /* float */ float radius)
    {
        // int => int
        // float => float
        // return Mesh => Mesh
        return Raylib.GenMeshPoly(sides, radius);
    }

    /// <summary>
    /// Generate plane mesh (with subdivisions)
    /// </summary>
    public static Mesh GenMeshPlane(/* float */ float width, /* float */ float length, /* int */ int resX, /* int */ int resZ)
    {
        // float => float
        // float => float
        // int => int
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshPlane(width, length, resX, resZ);
    }

    /// <summary>
    /// Generate cuboid mesh
    /// </summary>
    public static Mesh GenMeshCube(/* float */ float width, /* float */ float height, /* float */ float length)
    {
        // float => float
        // float => float
        // float => float
        // return Mesh => Mesh
        return Raylib.GenMeshCube(width, height, length);
    }

    /// <summary>
    /// Generate sphere mesh (standard sphere)
    /// </summary>
    public static Mesh GenMeshSphere(/* float */ float radius, /* int */ int rings, /* int */ int slices)
    {
        // float => float
        // int => int
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate half-sphere mesh (no bottom cap)
    /// </summary>
    public static Mesh GenMeshHemiSphere(/* float */ float radius, /* int */ int rings, /* int */ int slices)
    {
        // float => float
        // int => int
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshHemiSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate cylinder mesh
    /// </summary>
    public static Mesh GenMeshCylinder(/* float */ float radius, /* float */ float height, /* int */ int slices)
    {
        // float => float
        // float => float
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshCylinder(radius, height, slices);
    }

    /// <summary>
    /// Generate cone/pyramid mesh
    /// </summary>
    public static Mesh GenMeshCone(/* float */ float radius, /* float */ float height, /* int */ int slices)
    {
        // float => float
        // float => float
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshCone(radius, height, slices);
    }

    /// <summary>
    /// Generate torus mesh
    /// </summary>
    public static Mesh GenMeshTorus(/* float */ float radius, /* float */ float size, /* int */ int radSeg, /* int */ int sides)
    {
        // float => float
        // float => float
        // int => int
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshTorus(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate trefoil knot mesh
    /// </summary>
    public static Mesh GenMeshKnot(/* float */ float radius, /* float */ float size, /* int */ int radSeg, /* int */ int sides)
    {
        // float => float
        // float => float
        // int => int
        // int => int
        // return Mesh => Mesh
        return Raylib.GenMeshKnot(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate heightmap mesh from image data
    /// </summary>
    public static Mesh GenMeshHeightmap(/* Image */ Image heightmap, /* Vector3 */ Vector3 size)
    {
        // Image => Image
        // Vector3 => Vector3
        // return Mesh => Mesh
        return Raylib.GenMeshHeightmap(heightmap, size);
    }

    /// <summary>
    /// Generate cubes-based map mesh from image data
    /// </summary>
    public static Mesh GenMeshCubicmap(/* Image */ Image cubicmap, /* Vector3 */ Vector3 cubeSize)
    {
        // Image => Image
        // Vector3 => Vector3
        // return Mesh => Mesh
        return Raylib.GenMeshCubicmap(cubicmap, cubeSize);
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public static Material* LoadMaterials(/* const char* */ string fileName, /* int* */ int* materialCount)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // int* => int*
        // return Material* => Material*
        return Raylib.LoadMaterials(fileName_.AsPtr(), materialCount);
    }

    /// <summary>
    /// Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
    /// </summary>
    public static Material LoadMaterialDefault()
    {
        // return Material => Material
        return Raylib.LoadMaterialDefault();
    }

    /// <summary>
    /// Unload material from GPU memory (VRAM)
    /// </summary>
    public static void UnloadMaterial(/* Material */ Material material)
    {
        // Material => Material
        // return void => void
        Raylib.UnloadMaterial(material);
    }

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    public static void SetMaterialTexture(/* Material* */ Material* material, /* int */ int mapType, /* Texture2D */ Texture texture)
    {
        // Material* => Material*
        // int => int
        // Texture => Texture
        // return void => void
        Raylib.SetMaterialTexture(material, mapType, texture);
    }

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    public static void SetModelMeshMaterial(/* Model* */ Model* model, /* int */ int meshId, /* int */ int materialId)
    {
        // Model* => Model*
        // int => int
        // int => int
        // return void => void
        Raylib.SetModelMeshMaterial(model, meshId, materialId);
    }

//  /// <summary>
//  /// Load model animations from file
//  /// </summary>
//  public static ModelAnimation* LoadModelAnimations(/* const char* */ string fileName, /* unsigned int* */ uint* animCount)
//  {
//      // sbyte* => string
//      using var fileName_ = fileName.MarshalUtf8();
//      // uint* => uint*
//      // return ModelAnimation* => ModelAnimation*
//      return Raylib.LoadModelAnimations(fileName_.AsPtr(), animCount);
//  }

    /// <summary>
    /// Update model animation pose
    /// </summary>
    public static void UpdateModelAnimation(/* Model */ Model model, /* ModelAnimation */ ModelAnimation anim, /* int */ int frame)
    {
        // Model => Model
        // ModelAnimation => ModelAnimation
        // int => int
        // return void => void
        Raylib.UpdateModelAnimation(model, anim, frame);
    }

    /// <summary>
    /// Unload animation data
    /// </summary>
    public static void UnloadModelAnimation(/* ModelAnimation */ ModelAnimation anim)
    {
        // ModelAnimation => ModelAnimation
        // return void => void
        Raylib.UnloadModelAnimation(anim);
    }

    /// <summary>
    /// Unload animation array data
    /// </summary>
    public static void UnloadModelAnimations(/* ModelAnimation* */ ModelAnimation* animations, /* unsigned int */ uint count)
    {
        // ModelAnimation* => ModelAnimation*
        // uint => uint
        // return void => void
        Raylib.UnloadModelAnimations(animations, count);
    }

    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    public static bool IsModelAnimationValid(/* Model */ Model model, /* ModelAnimation */ ModelAnimation anim)
    {
        // Model => Model
        // ModelAnimation => ModelAnimation
        // return bool => bool
        return Raylib.IsModelAnimationValid(model, anim);
    }

    /// <summary>
    /// Check collision between two spheres
    /// </summary>
    public static bool CheckCollisionSpheres(/* Vector3 */ Vector3 center1, /* float */ float radius1, /* Vector3 */ Vector3 center2, /* float */ float radius2)
    {
        // Vector3 => Vector3
        // float => float
        // Vector3 => Vector3
        // float => float
        // return bool => bool
        return Raylib.CheckCollisionSpheres(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    public static bool CheckCollisionBoxes(/* BoundingBox */ BoundingBox box1, /* BoundingBox */ BoundingBox box2)
    {
        // BoundingBox => BoundingBox
        // BoundingBox => BoundingBox
        // return bool => bool
        return Raylib.CheckCollisionBoxes(box1, box2);
    }

    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    public static bool CheckCollisionBoxSphere(/* BoundingBox */ BoundingBox box, /* Vector3 */ Vector3 center, /* float */ float radius)
    {
        // BoundingBox => BoundingBox
        // Vector3 => Vector3
        // float => float
        // return bool => bool
        return Raylib.CheckCollisionBoxSphere(box, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    public static RayCollision GetRayCollisionSphere(/* Ray */ Ray ray, /* Vector3 */ Vector3 center, /* float */ float radius)
    {
        // Ray => Ray
        // Vector3 => Vector3
        // float => float
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionSphere(ray, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    public static RayCollision GetRayCollisionBox(/* Ray */ Ray ray, /* BoundingBox */ BoundingBox box)
    {
        // Ray => Ray
        // BoundingBox => BoundingBox
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionBox(ray, box);
    }

    /// <summary>
    /// Get collision info between ray and model
    /// </summary>
    public static RayCollision GetRayCollisionModel(/* Ray */ Ray ray, /* Model */ Model model)
    {
        // Ray => Ray
        // Model => Model
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionModel(ray, model);
    }

    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    public static RayCollision GetRayCollisionMesh(/* Ray */ Ray ray, /* Mesh */ Mesh mesh, /* Matrix */ Matrix4x4 transform)
    {
        // Ray => Ray
        // Mesh => Mesh
        // Matrix4x4 => Matrix4x4
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionMesh(ray, mesh, transform);
    }

    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    public static RayCollision GetRayCollisionTriangle(/* Ray */ Ray ray, /* Vector3 */ Vector3 p1, /* Vector3 */ Vector3 p2, /* Vector3 */ Vector3 p3)
    {
        // Ray => Ray
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Vector3 => Vector3
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionTriangle(ray, p1, p2, p3);
    }

    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    public static RayCollision GetRayCollisionQuad(/* Ray */ Ray ray, /* Vector3 */ Vector3 p1, /* Vector3 */ Vector3 p2, /* Vector3 */ Vector3 p3, /* Vector3 */ Vector3 p4)
    {
        // Ray => Ray
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Vector3 => Vector3
        // Vector3 => Vector3
        // return RayCollision => RayCollision
        return Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
    }

    /// <summary>
    /// Initialize audio device and context
    /// </summary>
    public static void InitAudioDevice()
    {
        // return void => void
        Raylib.InitAudioDevice();
    }

    /// <summary>
    /// Close the audio device and context
    /// </summary>
    public static void CloseAudioDevice()
    {
        // return void => void
        Raylib.CloseAudioDevice();
    }

    /// <summary>
    /// Check if audio device has been initialized successfully
    /// </summary>
    public static bool IsAudioDeviceReady()
    {
        // return bool => bool
        return Raylib.IsAudioDeviceReady();
    }

    /// <summary>
    /// Set master volume (listener)
    /// </summary>
    public static void SetMasterVolume(/* float */ float volume)
    {
        // float => float
        // return void => void
        Raylib.SetMasterVolume(volume);
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public static Wave LoadWave(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Wave => Wave
        return Raylib.LoadWave(fileName_.AsPtr());
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public static Wave LoadWaveFromMemory(/* const char* */ string fileType, /* const unsigned char* */ byte[] fileData, /* int */ int dataSize)
    {
        // sbyte* => string
        using var fileType_ = fileType.MarshalUtf8();
        // byte* => byte[]
        var fileData_ = Helpers.ArrayToPtr(fileData);
        // int => int
        // return Wave => Wave
        return Raylib.LoadWaveFromMemory(fileType_.AsPtr(), fileData_, dataSize);
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public static Sound LoadSound(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Sound => Sound
        return Raylib.LoadSound(fileName_.AsPtr());
    }

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public static Sound LoadSoundFromWave(/* Wave */ Wave wave)
    {
        // Wave => Wave
        // return Sound => Sound
        return Raylib.LoadSoundFromWave(wave);
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public static void UpdateSound(/* Sound */ Sound sound, /* const void* */ IntPtr data, /* int */ int sampleCount)
    {
        // Sound => Sound
        // void* => IntPtr
        var data_ = (void*)data;
        // int => int
        // return void => void
        Raylib.UpdateSound(sound, data_, sampleCount);
    }

    /// <summary>
    /// Unload wave data
    /// </summary>
    public static void UnloadWave(/* Wave */ Wave wave)
    {
        // Wave => Wave
        // return void => void
        Raylib.UnloadWave(wave);
    }

    /// <summary>
    /// Unload sound
    /// </summary>
    public static void UnloadSound(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.UnloadSound(sound);
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public static bool ExportWave(/* Wave */ Wave wave, /* const char* */ string fileName)
    {
        // Wave => Wave
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportWave(wave, fileName_.AsPtr());
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static bool ExportWaveAsCode(/* Wave */ Wave wave, /* const char* */ string fileName)
    {
        // Wave => Wave
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return bool => bool
        return Raylib.ExportWaveAsCode(wave, fileName_.AsPtr());
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public static void PlaySound(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.PlaySound(sound);
    }

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public static void StopSound(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.StopSound(sound);
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    public static void PauseSound(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.PauseSound(sound);
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public static void ResumeSound(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.ResumeSound(sound);
    }

    /// <summary>
    /// Play a sound (using multichannel buffer pool)
    /// </summary>
    public static void PlaySoundMulti(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return void => void
        Raylib.PlaySoundMulti(sound);
    }

    /// <summary>
    /// Stop any sound playing (using multichannel buffer pool)
    /// </summary>
    public static void StopSoundMulti()
    {
        // return void => void
        Raylib.StopSoundMulti();
    }

    /// <summary>
    /// Get number of sounds playing in the multichannel
    /// </summary>
    public static int GetSoundsPlaying()
    {
        // return int => int
        return Raylib.GetSoundsPlaying();
    }

    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    public static bool IsSoundPlaying(/* Sound */ Sound sound)
    {
        // Sound => Sound
        // return bool => bool
        return Raylib.IsSoundPlaying(sound);
    }

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public static void SetSoundVolume(/* Sound */ Sound sound, /* float */ float volume)
    {
        // Sound => Sound
        // float => float
        // return void => void
        Raylib.SetSoundVolume(sound, volume);
    }

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public static void SetSoundPitch(/* Sound */ Sound sound, /* float */ float pitch)
    {
        // Sound => Sound
        // float => float
        // return void => void
        Raylib.SetSoundPitch(sound, pitch);
    }

    /// <summary>
    /// Set pan for a sound (0.5 is center)
    /// </summary>
    public static void SetSoundPan(/* Sound */ Sound sound, /* float */ float pan)
    {
        // Sound => Sound
        // float => float
        // return void => void
        Raylib.SetSoundPan(sound, pan);
    }

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public static Wave WaveCopy(/* Wave */ Wave wave)
    {
        // Wave => Wave
        // return Wave => Wave
        return Raylib.WaveCopy(wave);
    }

    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public static void WaveCrop(/* Wave* */ Wave* wave, /* int */ int initSample, /* int */ int finalSample)
    {
        // Wave* => Wave*
        // int => int
        // int => int
        // return void => void
        Raylib.WaveCrop(wave, initSample, finalSample);
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public static void WaveFormat(/* Wave* */ Wave* wave, /* int */ int sampleRate, /* int */ int sampleSize, /* int */ int channels)
    {
        // Wave* => Wave*
        // int => int
        // int => int
        // int => int
        // return void => void
        Raylib.WaveFormat(wave, sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Load samples data from wave as a 32bit float data array
    /// </summary>
    public static float* LoadWaveSamples(/* Wave */ Wave wave)
    {
        // Wave => Wave
        // return float* => float*
        return Raylib.LoadWaveSamples(wave);
    }

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    public static void UnloadWaveSamples(/* float* */ float* samples)
    {
        // float* => float*
        // return void => void
        Raylib.UnloadWaveSamples(samples);
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public static Music LoadMusicStream(/* const char* */ string fileName)
    {
        // sbyte* => string
        using var fileName_ = fileName.MarshalUtf8();
        // return Music => Music
        return Raylib.LoadMusicStream(fileName_.AsPtr());
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public static Music LoadMusicStreamFromMemory(/* const char* */ string fileType, /* const unsigned char* */ byte[] data, /* int */ int dataSize)
    {
        // sbyte* => string
        using var fileType_ = fileType.MarshalUtf8();
        // byte* => byte[]
        var data_ = Helpers.ArrayToPtr(data);
        // int => int
        // return Music => Music
        return Raylib.LoadMusicStreamFromMemory(fileType_.AsPtr(), data_, dataSize);
    }

    /// <summary>
    /// Unload music stream
    /// </summary>
    public static void UnloadMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.UnloadMusicStream(music);
    }

    /// <summary>
    /// Start music playing
    /// </summary>
    public static void PlayMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.PlayMusicStream(music);
    }

    /// <summary>
    /// Check if music is playing
    /// </summary>
    public static bool IsMusicStreamPlaying(/* Music */ Music music)
    {
        // Music => Music
        // return bool => bool
        return Raylib.IsMusicStreamPlaying(music);
    }

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    public static void UpdateMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.UpdateMusicStream(music);
    }

    /// <summary>
    /// Stop music playing
    /// </summary>
    public static void StopMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.StopMusicStream(music);
    }

    /// <summary>
    /// Pause music playing
    /// </summary>
    public static void PauseMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.PauseMusicStream(music);
    }

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    public static void ResumeMusicStream(/* Music */ Music music)
    {
        // Music => Music
        // return void => void
        Raylib.ResumeMusicStream(music);
    }

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    public static void SeekMusicStream(/* Music */ Music music, /* float */ float position)
    {
        // Music => Music
        // float => float
        // return void => void
        Raylib.SeekMusicStream(music, position);
    }

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    public static void SetMusicVolume(/* Music */ Music music, /* float */ float volume)
    {
        // Music => Music
        // float => float
        // return void => void
        Raylib.SetMusicVolume(music, volume);
    }

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    public static void SetMusicPitch(/* Music */ Music music, /* float */ float pitch)
    {
        // Music => Music
        // float => float
        // return void => void
        Raylib.SetMusicPitch(music, pitch);
    }

    /// <summary>
    /// Set pan for a music (0.5 is center)
    /// </summary>
    public static void SetMusicPan(/* Music */ Music music, /* float */ float pan)
    {
        // Music => Music
        // float => float
        // return void => void
        Raylib.SetMusicPan(music, pan);
    }

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    public static float GetMusicTimeLength(/* Music */ Music music)
    {
        // Music => Music
        // return float => float
        return Raylib.GetMusicTimeLength(music);
    }

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    public static float GetMusicTimePlayed(/* Music */ Music music)
    {
        // Music => Music
        // return float => float
        return Raylib.GetMusicTimePlayed(music);
    }

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    public static AudioStream LoadAudioStream(/* unsigned int */ uint sampleRate, /* unsigned int */ uint sampleSize, /* unsigned int */ uint channels)
    {
        // uint => uint
        // uint => uint
        // uint => uint
        // return AudioStream => AudioStream
        return Raylib.LoadAudioStream(sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    public static void UnloadAudioStream(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return void => void
        Raylib.UnloadAudioStream(stream);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream(/* AudioStream */ AudioStream stream, /* const void* */ IntPtr data, /* int */ int frameCount)
    {
        // AudioStream => AudioStream
        // void* => IntPtr
        var data_ = (void*)data;
        // int => int
        // return void => void
        Raylib.UpdateAudioStream(stream, data_, frameCount);
    }

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    public static bool IsAudioStreamProcessed(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return bool => bool
        return Raylib.IsAudioStreamProcessed(stream);
    }

    /// <summary>
    /// Play audio stream
    /// </summary>
    public static void PlayAudioStream(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return void => void
        Raylib.PlayAudioStream(stream);
    }

    /// <summary>
    /// Pause audio stream
    /// </summary>
    public static void PauseAudioStream(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return void => void
        Raylib.PauseAudioStream(stream);
    }

    /// <summary>
    /// Resume audio stream
    /// </summary>
    public static void ResumeAudioStream(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return void => void
        Raylib.ResumeAudioStream(stream);
    }

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    public static bool IsAudioStreamPlaying(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return bool => bool
        return Raylib.IsAudioStreamPlaying(stream);
    }

    /// <summary>
    /// Stop audio stream
    /// </summary>
    public static void StopAudioStream(/* AudioStream */ AudioStream stream)
    {
        // AudioStream => AudioStream
        // return void => void
        Raylib.StopAudioStream(stream);
    }

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    public static void SetAudioStreamVolume(/* AudioStream */ AudioStream stream, /* float */ float volume)
    {
        // AudioStream => AudioStream
        // float => float
        // return void => void
        Raylib.SetAudioStreamVolume(stream, volume);
    }

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public static void SetAudioStreamPitch(/* AudioStream */ AudioStream stream, /* float */ float pitch)
    {
        // AudioStream => AudioStream
        // float => float
        // return void => void
        Raylib.SetAudioStreamPitch(stream, pitch);
    }

    /// <summary>
    /// Set pan for audio stream (0.5 is centered)
    /// </summary>
    public static void SetAudioStreamPan(/* AudioStream */ AudioStream stream, /* float */ float pan)
    {
        // AudioStream => AudioStream
        // float => float
        // return void => void
        Raylib.SetAudioStreamPan(stream, pan);
    }

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    public static void SetAudioStreamBufferSizeDefault(/* int */ int size)
    {
        // int => int
        // return void => void
        Raylib.SetAudioStreamBufferSizeDefault(size);
    }

}

#pragma warning restore
