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
    public static void InitWindow(int width, int height, string title)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  const char * => string  |*/
        using var titleLocal = title.MarshalUtf8();
        Raylib.InitWindow(width, height, titleLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if KEY_ESCAPE pressed or Close icon pressed
    /// </summary>
    public static bool WindowShouldClose()
    {
        return Raylib.WindowShouldClose();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    public static void CloseWindow()
    {
        Raylib.CloseWindow();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    public static bool IsWindowReady()
    {
        return Raylib.IsWindowReady();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    public static bool IsWindowFullscreen()
    {
        return Raylib.IsWindowFullscreen();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window is currently hidden (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowHidden()
    {
        return Raylib.IsWindowHidden();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window is currently minimized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMinimized()
    {
        return Raylib.IsWindowMinimized();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window is currently maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMaximized()
    {
        return Raylib.IsWindowMaximized();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window is currently focused (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowFocused()
    {
        return Raylib.IsWindowFocused();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    public static bool IsWindowResized()
    {
        return Raylib.IsWindowResized();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    public static bool IsWindowState(uint flag)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.IsWindowState(flag);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Set window configuration state using flags
    /// </summary>
    public static void SetWindowState(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetWindowState(flags);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    public static void ClearWindowState(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.ClearWindowState(flags);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)
    /// </summary>
    public static void ToggleFullscreen()
    {
        Raylib.ToggleFullscreen();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window state: maximized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MaximizeWindow()
    {
        Raylib.MaximizeWindow();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window state: minimized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MinimizeWindow()
    {
        Raylib.MinimizeWindow();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window state: not minimized/maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static void RestoreWindow()
    {
        Raylib.RestoreWindow();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set icon for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowIcon(Image image)
    {
        /*|  Image => Image  |*/
        Raylib.SetWindowIcon(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowTitle(string title)
    {
        /*|  const char * => string  |*/
        using var titleLocal = title.MarshalUtf8();
        Raylib.SetWindowTitle(titleLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window position on screen (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowPosition(int x, int y)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowPosition(x, y);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set monitor for the current window (fullscreen mode)
    /// </summary>
    public static void SetWindowMonitor(int monitor)
    {
        /*|  int => int  |*/
        Raylib.SetWindowMonitor(monitor);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    public static void SetWindowMinSize(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowMinSize(width, height);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set window dimensions
    /// </summary>
    public static void SetWindowSize(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowSize(width, height);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get native window handle
    /// </summary>
    public static IntPtr GetWindowHandle()
    {
        return (IntPtr)Raylib.GetWindowHandle();
        /*|  return void * => IntPtr  |*/
    }

    /// <summary>
    /// Get current screen width
    /// </summary>
    public static int GetScreenWidth()
    {
        return Raylib.GetScreenWidth();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get current screen height
    /// </summary>
    public static int GetScreenHeight()
    {
        return Raylib.GetScreenHeight();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    public static int GetMonitorCount()
    {
        return Raylib.GetMonitorCount();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get current connected monitor
    /// </summary>
    public static int GetCurrentMonitor()
    {
        return Raylib.GetCurrentMonitor();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    public static Vector2 GetMonitorPosition(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPosition(monitor);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get specified monitor width (max available by monitor)
    /// </summary>
    public static int GetMonitorWidth(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorWidth(monitor);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get specified monitor height (max available by monitor)
    /// </summary>
    public static int GetMonitorHeight(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorHeight(monitor);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    public static int GetMonitorPhysicalWidth(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPhysicalWidth(monitor);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    public static int GetMonitorPhysicalHeight(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPhysicalHeight(monitor);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    public static int GetMonitorRefreshRate(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorRefreshRate(monitor);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    public static Vector2 GetWindowPosition()
    {
        return Raylib.GetWindowPosition();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    public static Vector2 GetWindowScaleDPI()
    {
        return Raylib.GetWindowScaleDPI();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the primary monitor
    /// </summary>
    public static string GetMonitorName(int monitor)
    {
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.GetMonitorName(monitor));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public static void SetClipboardText(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        Raylib.SetClipboardText(textLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public static string GetClipboardText()
    {
        return Helpers.Utf8ToString(Raylib.GetClipboardText());
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    public static void SwapScreenBuffer()
    {
        Raylib.SwapScreenBuffer();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Register all input events
    /// </summary>
    public static void PollInputEvents()
    {
        Raylib.PollInputEvents();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Wait for some milliseconds (halt program execution)
    /// </summary>
    public static void WaitTime(float ms)
    {
        /*|  float => float  |*/
        Raylib.WaitTime(ms);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Shows cursor
    /// </summary>
    public static void ShowCursor()
    {
        Raylib.ShowCursor();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Hides cursor
    /// </summary>
    public static void HideCursor()
    {
        Raylib.HideCursor();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    public static bool IsCursorHidden()
    {
        return Raylib.IsCursorHidden();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    public static void EnableCursor()
    {
        Raylib.EnableCursor();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    public static void DisableCursor()
    {
        Raylib.DisableCursor();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    public static bool IsCursorOnScreen()
    {
        return Raylib.IsCursorOnScreen();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    public static void ClearBackground(Color color)
    {
        /*|  Color => Color  |*/
        Raylib.ClearBackground(color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    public static void BeginDrawing()
    {
        Raylib.BeginDrawing();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    public static void EndDrawing()
    {
        Raylib.EndDrawing();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    public static void BeginMode2D(Camera2D camera)
    {
        /*|  Camera2D => Camera2D  |*/
        Raylib.BeginMode2D(camera);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    public static void EndMode2D()
    {
        Raylib.EndMode2D();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public static void BeginMode3D(Camera3D camera)
    {
        /*|  Camera3D => Camera3D  |*/
        Raylib.BeginMode3D(camera);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public static void EndMode3D()
    {
        Raylib.EndMode3D();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    public static void BeginTextureMode(RenderTexture2D target)
    {
        /*|  RenderTexture2D => RenderTexture2D  |*/
        Raylib.BeginTextureMode(target);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    public static void EndTextureMode()
    {
        Raylib.EndTextureMode();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    public static void BeginShaderMode(Shader shader)
    {
        /*|  Shader => Shader  |*/
        Raylib.BeginShaderMode(shader);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    public static void EndShaderMode()
    {
        Raylib.EndShaderMode();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    public static void BeginBlendMode(int mode)
    {
        /*|  int => int  |*/
        Raylib.BeginBlendMode(mode);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    public static void EndBlendMode()
    {
        Raylib.EndBlendMode();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    public static void BeginScissorMode(int x, int y, int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.BeginScissorMode(x, y, width, height);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// End scissor mode
    /// </summary>
    public static void EndScissorMode()
    {
        Raylib.EndScissorMode();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    public static void BeginVrStereoMode(VrStereoConfig config)
    {
        /*|  VrStereoConfig => VrStereoConfig  |*/
        Raylib.BeginVrStereoMode(config);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    public static void EndVrStereoMode()
    {
        Raylib.EndVrStereoMode();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    public static VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device)
    {
        /*|  VrDeviceInfo => VrDeviceInfo  |*/
        return Raylib.LoadVrStereoConfig(device);
        /*|  return VrStereoConfig => VrStereoConfig  |*/
    }

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    public static void UnloadVrStereoConfig(VrStereoConfig config)
    {
        /*|  VrStereoConfig => VrStereoConfig  |*/
        Raylib.UnloadVrStereoConfig(config);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public static Shader LoadShader(string vsFileName, string fsFileName)
    {
        /*|  const char * => string  |*/
        using var vsFileNameLocal = vsFileName.MarshalUtf8();
        /*|  const char * => string  |*/
        using var fsFileNameLocal = fsFileName.MarshalUtf8();
        return Raylib.LoadShader(vsFileNameLocal.AsPtr(), fsFileNameLocal.AsPtr());
        /*|  return Shader => Shader  |*/
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
    {
        /*|  const char * => string  |*/
        using var vsCodeLocal = vsCode.MarshalUtf8();
        /*|  const char * => string  |*/
        using var fsCodeLocal = fsCode.MarshalUtf8();
        return Raylib.LoadShaderFromMemory(vsCodeLocal.AsPtr(), fsCodeLocal.AsPtr());
        /*|  return Shader => Shader  |*/
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetShaderLocation(Shader shader, string uniformName)
    {
        /*|  Shader => Shader  |*/
        /*|  const char * => string  |*/
        using var uniformNameLocal = uniformName.MarshalUtf8();
        return Raylib.GetShaderLocation(shader, uniformNameLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetShaderLocationAttrib(Shader shader, string attribName)
    {
        /*|  Shader => Shader  |*/
        /*|  const char * => string  |*/
        using var attribNameLocal = attribName.MarshalUtf8();
        return Raylib.GetShaderLocationAttrib(shader, attribNameLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetShaderValue(Shader shader, int locIndex, IntPtr value, int uniformType)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  const void * => IntPtr  |*/
        var valueLocal = (void*)value;
        /*|  int => int  |*/
        Raylib.SetShaderValue(shader, locIndex, valueLocal, uniformType);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetShaderValueV(Shader shader, int locIndex, IntPtr value, int uniformType, int count)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  const void * => IntPtr  |*/
        var valueLocal = (void*)value;
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetShaderValueV(shader, locIndex, valueLocal, uniformType, count);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetShaderValueMatrix(Shader shader, int locIndex, Matrix mat)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  Matrix => Matrix  |*/
        Raylib.SetShaderValueMatrix(shader, locIndex, mat);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetShaderValueTexture(Shader shader, int locIndex, Texture2D texture)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  Texture2D => Texture2D  |*/
        Raylib.SetShaderValueTexture(shader, locIndex, texture);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    public static void UnloadShader(Shader shader)
    {
        /*|  Shader => Shader  |*/
        Raylib.UnloadShader(shader);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public static Ray GetMouseRay(Vector2 mousePosition, Camera camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera => Camera  |*/
        return Raylib.GetMouseRay(mousePosition, camera);
        /*|  return Ray => Ray  |*/
    }

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public static Matrix GetCameraMatrix(Camera camera)
    {
        /*|  Camera => Camera  |*/
        return Raylib.GetCameraMatrix(camera);
        /*|  return Matrix => Matrix  |*/
    }

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    public static Matrix GetCameraMatrix2D(Camera2D camera)
    {
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetCameraMatrix2D(camera);
        /*|  return Matrix => Matrix  |*/
    }

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(Vector3 position, Camera camera)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Camera => Camera  |*/
        return Raylib.GetWorldToScreen(position, camera);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreenEx(Vector3 position, Camera camera, int width, int height)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Camera => Camera  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetWorldToScreenEx(position, camera, width, height);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    public static Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetWorldToScreen2D(position, camera);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    public static Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetScreenToWorld2D(position, camera);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    public static void SetTargetFPS(int fps)
    {
        /*|  int => int  |*/
        Raylib.SetTargetFPS(fps);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get current FPS
    /// </summary>
    public static int GetFPS()
    {
        return Raylib.GetFPS();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    public static float GetFrameTime()
    {
        return Raylib.GetFrameTime();
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    public static double GetTime()
    {
        return Raylib.GetTime();
        /*|  return double => double  |*/
    }

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    public static int GetRandomValue(int min, int max)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetRandomValue(min, max);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    public static void SetRandomSeed(uint seed)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetRandomSeed(seed);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    public static void TakeScreenshot(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        Raylib.TakeScreenshot(fileNameLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Setup init configuration flags (view FLAGS)
    /// </summary>
    public static void SetConfigFlags(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetConfigFlags(flags);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    public static void SetTraceLogLevel(int logLevel)
    {
        /*|  int => int  |*/
        Raylib.SetTraceLogLevel(logLevel);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    public static IntPtr MemAlloc(int size)
    {
        /*|  int => int  |*/
        return (IntPtr)Raylib.MemAlloc(size);
        /*|  return void * => IntPtr  |*/
    }

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    public static IntPtr MemRealloc(IntPtr ptr, int size)
    {
        /*|  void * => IntPtr  |*/
        var ptrLocal = (void*)ptr;
        /*|  int => int  |*/
        return (IntPtr)Raylib.MemRealloc(ptrLocal, size);
        /*|  return void * => IntPtr  |*/
    }

    /// <summary>
    /// Internal memory free
    /// </summary>
    public static void MemFree(IntPtr ptr)
    {
        /*|  void * => IntPtr  |*/
        var ptrLocal = (void*)ptr;
        Raylib.MemFree(ptrLocal);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    public static void UnloadFileData(byte[] data)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        Raylib.UnloadFileData(dataLocal);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public static bool SaveFileData(string fileName, IntPtr data, uint bytesToWrite)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  unsigned int => uint  |*/
        return Raylib.SaveFileData(fileNameLocal.AsPtr(), dataLocal, bytesToWrite);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Load text data from file (read), returns a ' 0' terminated string
    /// </summary>
    public static string LoadFileText(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.LoadFileText(fileNameLocal.AsPtr()));
        /*|  return char * => string  |*/
    }

    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    public static void UnloadFileText(string text)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        Raylib.UnloadFileText(textLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Save text data to file (write), string must be ' 0' terminated, returns true on success
    /// </summary>
    public static bool SaveFileText(string fileName, string text)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.SaveFileText(fileNameLocal.AsPtr(), textLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public static bool FileExists(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.FileExists(fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public static bool DirectoryExists(string dirPath)
    {
        /*|  const char * => string  |*/
        using var dirPathLocal = dirPath.MarshalUtf8();
        return Raylib.DirectoryExists(dirPathLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    public static bool IsFileExtension(string fileName, string ext)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  const char * => string  |*/
        using var extLocal = ext.MarshalUtf8();
        return Raylib.IsFileExtension(fileNameLocal.AsPtr(), extLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public static string GetFileExtension(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileExtension(fileNameLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public static string GetFileName(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileName(filePathLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    public static string GetFileNameWithoutExt(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileNameWithoutExt(filePathLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public static string GetDirectoryPath(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetDirectoryPath(filePathLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public static string GetPrevDirectoryPath(string dirPath)
    {
        /*|  const char * => string  |*/
        using var dirPathLocal = dirPath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetPrevDirectoryPath(dirPathLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public static string GetWorkingDirectory()
    {
        return Helpers.Utf8ToString(Raylib.GetWorkingDirectory());
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Clear directory files paths buffers (free memory)
    /// </summary>
    public static void ClearDirectoryFiles()
    {
        Raylib.ClearDirectoryFiles();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public static bool ChangeDirectory(string dir)
    {
        /*|  const char * => string  |*/
        using var dirLocal = dir.MarshalUtf8();
        return Raylib.ChangeDirectory(dirLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    public static bool IsFileDropped()
    {
        return Raylib.IsFileDropped();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Clear dropped files paths buffer (free memory)
    /// </summary>
    public static void ClearDroppedFiles()
    {
        Raylib.ClearDroppedFiles();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    public static long GetFileModTime(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.GetFileModTime(fileNameLocal.AsPtr());
        /*|  return long => long  |*/
    }

    /// <summary>
    /// Compress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] CompressData(byte[] data, int dataLength, int* compDataLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.CompressData(dataLocal, dataLength, compDataLength));
        /*|  return unsigned char * => byte[]  |*/
    }

    /// <summary>
    /// Decompress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] DecompressData(byte[] compData, int compDataLength, int* dataLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var compDataLocal = Helpers.ArrayToPtr(compData);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.DecompressData(compDataLocal, compDataLength, dataLength));
        /*|  return unsigned char * => byte[]  |*/
    }

    /// <summary>
    /// Encode data to Base64 string
    /// </summary>
    public static string EncodeDataBase64(byte[] data, int dataLength, int* outputLength)
    {
        /*|  const unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.Utf8ToString(Raylib.EncodeDataBase64(dataLocal, dataLength, outputLength));
        /*|  return char * => string  |*/
    }

    /// <summary>
    /// Decode Base64 string data
    /// </summary>
    public static byte[] DecodeDataBase64(byte[] data, int* outputLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.DecodeDataBase64(dataLocal, outputLength));
        /*|  return unsigned char * => byte[]  |*/
    }

    /// <summary>
    /// Save integer value to storage file (to defined position), returns true on success
    /// </summary>
    public static bool SaveStorageValue(uint position, int value)
    {
        /*|  unsigned int => uint  |*/
        /*|  int => int  |*/
        return Raylib.SaveStorageValue(position, value);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Load integer value from storage file (from defined position)
    /// </summary>
    public static int LoadStorageValue(uint position)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.LoadStorageValue(position);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public static void OpenURL(string url)
    {
        /*|  const char * => string  |*/
        using var urlLocal = url.MarshalUtf8();
        Raylib.OpenURL(urlLocal.AsPtr());
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    public static bool IsKeyPressed(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyPressed(key);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public static bool IsKeyDown(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyDown(key);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    public static bool IsKeyReleased(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyReleased(key);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    public static bool IsKeyUp(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyUp(key);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    public static void SetExitKey(int key)
    {
        /*|  int => int  |*/
        Raylib.SetExitKey(key);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetKeyPressed()
    {
        return Raylib.GetKeyPressed();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetCharPressed()
    {
        return Raylib.GetCharPressed();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    public static bool IsGamepadAvailable(int gamepad)
    {
        /*|  int => int  |*/
        return Raylib.IsGamepadAvailable(gamepad);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public static string GetGamepadName(int gamepad)
    {
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.GetGamepadName(gamepad));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    public static bool IsGamepadButtonPressed(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonPressed(gamepad, button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    public static bool IsGamepadButtonDown(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonDown(gamepad, button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    public static bool IsGamepadButtonReleased(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonReleased(gamepad, button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    public static bool IsGamepadButtonUp(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonUp(gamepad, button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    public static int GetGamepadButtonPressed()
    {
        return Raylib.GetGamepadButtonPressed();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    public static int GetGamepadAxisCount(int gamepad)
    {
        /*|  int => int  |*/
        return Raylib.GetGamepadAxisCount(gamepad);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    public static float GetGamepadAxisMovement(int gamepad, int axis)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetGamepadAxisMovement(gamepad, axis);
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public static int SetGamepadMappings(string mappings)
    {
        /*|  const char * => string  |*/
        using var mappingsLocal = mappings.MarshalUtf8();
        return Raylib.SetGamepadMappings(mappingsLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    public static bool IsMouseButtonPressed(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonPressed(button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    public static bool IsMouseButtonDown(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonDown(button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    public static bool IsMouseButtonReleased(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonReleased(button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    public static bool IsMouseButtonUp(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonUp(button);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get mouse position X
    /// </summary>
    public static int GetMouseX()
    {
        return Raylib.GetMouseX();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get mouse position Y
    /// </summary>
    public static int GetMouseY()
    {
        return Raylib.GetMouseY();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get mouse position XY
    /// </summary>
    public static Vector2 GetMousePosition()
    {
        return Raylib.GetMousePosition();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    public static Vector2 GetMouseDelta()
    {
        return Raylib.GetMouseDelta();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Set mouse position XY
    /// </summary>
    public static void SetMousePosition(int x, int y)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetMousePosition(x, y);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set mouse offset
    /// </summary>
    public static void SetMouseOffset(int offsetX, int offsetY)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetMouseOffset(offsetX, offsetY);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set mouse scaling
    /// </summary>
    public static void SetMouseScale(float scaleX, float scaleY)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        Raylib.SetMouseScale(scaleX, scaleY);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get mouse wheel movement Y
    /// </summary>
    public static float GetMouseWheelMove()
    {
        return Raylib.GetMouseWheelMove();
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Set mouse cursor
    /// </summary>
    public static void SetMouseCursor(int cursor)
    {
        /*|  int => int  |*/
        Raylib.SetMouseCursor(cursor);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchX()
    {
        return Raylib.GetTouchX();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchY()
    {
        return Raylib.GetTouchY();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    public static Vector2 GetTouchPosition(int index)
    {
        /*|  int => int  |*/
        return Raylib.GetTouchPosition(index);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    public static int GetTouchPointId(int index)
    {
        /*|  int => int  |*/
        return Raylib.GetTouchPointId(index);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get number of touch points
    /// </summary>
    public static int GetTouchPointCount()
    {
        return Raylib.GetTouchPointCount();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Enable a set of gestures using flags
    /// </summary>
    public static void SetGesturesEnabled(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetGesturesEnabled(flags);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if a gesture have been detected
    /// </summary>
    public static bool IsGestureDetected(int gesture)
    {
        /*|  int => int  |*/
        return Raylib.IsGestureDetected(gesture);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    public static int GetGestureDetected()
    {
        return Raylib.GetGestureDetected();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get gesture hold time in milliseconds
    /// </summary>
    public static float GetGestureHoldDuration()
    {
        return Raylib.GetGestureHoldDuration();
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Get gesture drag vector
    /// </summary>
    public static Vector2 GetGestureDragVector()
    {
        return Raylib.GetGestureDragVector();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get gesture drag angle
    /// </summary>
    public static float GetGestureDragAngle()
    {
        return Raylib.GetGestureDragAngle();
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Get gesture pinch delta
    /// </summary>
    public static Vector2 GetGesturePinchVector()
    {
        return Raylib.GetGesturePinchVector();
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get gesture pinch angle
    /// </summary>
    public static float GetGesturePinchAngle()
    {
        return Raylib.GetGesturePinchAngle();
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Set camera mode (multiple camera modes available)
    /// </summary>
    public static void SetCameraMode(Camera camera, int mode)
    {
        /*|  Camera => Camera  |*/
        /*|  int => int  |*/
        Raylib.SetCameraMode(camera, mode);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void UpdateCamera(Camera* camera)
    {
        /*|  Camera * => Camera*  |*/
        Raylib.UpdateCamera(camera);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set camera pan key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraPanControl(int keyPan)
    {
        /*|  int => int  |*/
        Raylib.SetCameraPanControl(keyPan);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set camera alt key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraAltControl(int keyAlt)
    {
        /*|  int => int  |*/
        Raylib.SetCameraAltControl(keyAlt);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set camera smooth zoom key to combine with mouse (free camera)
    /// </summary>
    public static void SetCameraSmoothZoomControl(int keySmoothZoom)
    {
        /*|  int => int  |*/
        Raylib.SetCameraSmoothZoomControl(keySmoothZoom);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set camera move controls (1st person and 3rd person cameras)
    /// </summary>
    public static void SetCameraMoveControls(int keyFront, int keyBack, int keyRight, int keyLeft, int keyUp, int keyDown)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetCameraMoveControls(keyFront, keyBack, keyRight, keyLeft, keyUp, keyDown);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    public static void SetShapesTexture(Texture2D texture, Rectangle source)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        Raylib.SetShapesTexture(texture, source);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a pixel
    /// </summary>
    public static void DrawPixel(int posX, int posY, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPixel(posX, posY, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a pixel (Vector version)
    /// </summary>
    public static void DrawPixelV(Vector2 position, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPixelV(position, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a line
    /// </summary>
    public static void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLine(startPosX, startPosY, endPosX, endPosY, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    public static void DrawLineV(Vector2 startPos, Vector2 endPos, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineV(startPos, endPos, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    public static void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineEx(startPos, endPos, thick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    public static void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineBezier(startPos, endPos, thick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    public static void DrawLineBezierQuad(Vector2 startPos, Vector2 endPos, Vector2 controlPos, float thick, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineBezierQuad(startPos, endPos, controlPos, thick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    public static void DrawLineBezierCubic(Vector2 startPos, Vector2 endPos, Vector2 startControlPos, Vector2 endControlPos, float thick, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineBezierCubic(startPos, endPos, startControlPos, endControlPos, thick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw lines sequence
    /// </summary>
    public static void DrawLineStrip(Vector2* points, int pointCount, Color color)
    {
        /*|  Vector2 * => Vector2*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLineStrip(points, pointCount, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public static void DrawCircle(int centerX, int centerY, float radius, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircle(centerX, centerY, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public static void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    public static void DrawCircleV(Vector2 center, float radius, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircleV(center, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(int centerX, int centerY, float radius, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircleLines(centerX, centerY, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw ring
    /// </summary>
    public static void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw ring outline
    /// </summary>
    public static void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(int posX, int posY, int width, int height, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangle(posX, posY, width, height, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    public static void DrawRectangleV(Vector2 position, Vector2 size, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleV(position, size, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangleRec(Rectangle rec, Color color)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleRec(rec, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    public static void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectanglePro(rec, origin, rotation, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a vertical-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleGradientV(posX, posY, width, height, color1, color2);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a horizontal-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleGradientH(posX, posY, width, height, color1, color2);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public static void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleGradientEx(rec, col1, col2, col3, col4);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public static void DrawRectangleLines(int posX, int posY, int width, int height, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleLines(posX, posY, width, height, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    public static void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleLinesEx(rec, lineThick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    public static void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleRounded(rec, roundness, segments, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    public static void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, float lineThick, Color color)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRectangleRoundedLines(rec, roundness, segments, lineThick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangle(v1, v2, v3, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangleLines(v1, v2, v3, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public static void DrawTriangleFan(Vector2* points, int pointCount, Color color)
    {
        /*|  Vector2 * => Vector2*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangleFan(points, pointCount, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip(Vector2* points, int pointCount, Color color)
    {
        /*|  Vector2 * => Vector2*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangleStrip(points, pointCount, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    public static void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPoly(center, sides, radius, rotation, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    public static void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    public static void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, lineThick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    public static bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.CheckCollisionRecs(rec1, rec2);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check collision between two circles
    /// </summary>
    public static bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionCircles(center1, radius1, center2, radius2);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    public static bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.CheckCollisionCircleRec(center, radius, rec);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    public static bool CheckCollisionPointRec(Vector2 point, Rectangle rec)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.CheckCollisionPointRec(point, rec);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if point is inside circle
    /// </summary>
    public static bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionPointCircle(point, center, radius);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if point is inside a triangle
    /// </summary>
    public static bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        return Raylib.CheckCollisionPointTriangle(point, p1, p2, p3);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public static bool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, Vector2* collisionPoint)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 * => Vector2*  |*/
        return Raylib.CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, collisionPoint);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]
    /// </summary>
    public static bool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        return Raylib.CheckCollisionPointLine(point, p1, p2, threshold);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get collision rectangle for two rectangles collision
    /// </summary>
    public static Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2)
    {
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.GetCollisionRec(rec1, rec2);
        /*|  return Rectangle => Rectangle  |*/
    }

    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    public static Image LoadImage(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadImage(fileNameLocal.AsPtr());
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public static Image LoadImageRaw(string fileName, int width, int height, int format, int headerSize)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.LoadImageRaw(fileNameLocal.AsPtr(), width, height, format, headerSize);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public static Image LoadImageAnim(string fileName, int* frames)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int * => int*  |*/
        return Raylib.LoadImageAnim(fileNameLocal.AsPtr(), frames);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public static Image LoadImageFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        return Raylib.LoadImageFromMemory(fileTypeLocal.AsPtr(), fileDataLocal, dataSize);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    public static Image LoadImageFromTexture(Texture2D texture)
    {
        /*|  Texture2D => Texture2D  |*/
        return Raylib.LoadImageFromTexture(texture);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Load image from screen buffer and (screenshot)
    /// </summary>
    public static Image LoadImageFromScreen()
    {
        return Raylib.LoadImageFromScreen();
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    public static void UnloadImage(Image image)
    {
        /*|  Image => Image  |*/
        Raylib.UnloadImage(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public static bool ExportImage(Image image, string fileName)
    {
        /*|  Image => Image  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportImage(image, fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static bool ExportImageAsCode(Image image, string fileName)
    {
        /*|  Image => Image  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportImageAsCode(image, fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Generate image: plain color
    /// </summary>
    public static Image GenImageColor(int width, int height, Color color)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageColor(width, height, color);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: vertical gradient
    /// </summary>
    public static Image GenImageGradientV(int width, int height, Color top, Color bottom)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientV(width, height, top, bottom);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: horizontal gradient
    /// </summary>
    public static Image GenImageGradientH(int width, int height, Color left, Color right)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientH(width, height, left, right);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: radial gradient
    /// </summary>
    public static Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageGradientRadial(width, height, density, inner, outer);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: checked
    /// </summary>
    public static Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.GenImageChecked(width, height, checksX, checksY, col1, col2);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: white noise
    /// </summary>
    public static Image GenImageWhiteNoise(int width, int height, float factor)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  float => float  |*/
        return Raylib.GenImageWhiteNoise(width, height, factor);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Generate image: cellular algorithm, bigger tileSize means bigger cells
    /// </summary>
    public static Image GenImageCellular(int width, int height, int tileSize)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenImageCellular(width, height, tileSize);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    public static Image ImageCopy(Image image)
    {
        /*|  Image => Image  |*/
        return Raylib.ImageCopy(image);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    public static Image ImageFromImage(Image image, Rectangle rec)
    {
        /*|  Image => Image  |*/
        /*|  Rectangle => Rectangle  |*/
        return Raylib.ImageFromImage(image, rec);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public static Image ImageText(string text, int fontSize, Color color)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        return Raylib.ImageText(textLocal.AsPtr(), fontSize, color);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        return Raylib.ImageTextEx(font, textLocal.AsPtr(), fontSize, spacing, tint);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    public static void ImageFormat(Image* image, int newFormat)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        Raylib.ImageFormat(image, newFormat);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    public static void ImageToPOT(Image* image, Color fill)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageToPOT(image, fill);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    public static void ImageCrop(Image* image, Rectangle crop)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        Raylib.ImageCrop(image, crop);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    public static void ImageAlphaCrop(Image* image, float threshold)
    {
        /*|  Image * => Image*  |*/
        /*|  float => float  |*/
        Raylib.ImageAlphaCrop(image, threshold);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    public static void ImageAlphaClear(Image* image, Color color, float threshold)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        Raylib.ImageAlphaClear(image, color, threshold);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    public static void ImageAlphaMask(Image* image, Image alphaMask)
    {
        /*|  Image * => Image*  |*/
        /*|  Image => Image  |*/
        Raylib.ImageAlphaMask(image, alphaMask);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    public static void ImageAlphaPremultiply(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageAlphaPremultiply(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    public static void ImageResize(Image* image, int newWidth, int newHeight)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageResize(image, newWidth, newHeight);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public static void ImageResizeNN(Image* image, int newWidth, int newHeight)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageResizeNN(image, newWidth, newHeight);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    public static void ImageResizeCanvas(Image* image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageResizeCanvas(image, newWidth, newHeight, offsetX, offsetY, fill);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    public static void ImageMipmaps(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageMipmaps(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public static void ImageDither(Image* image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.ImageDither(image, rBpp, gBpp, bBpp, aBpp);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Flip image vertically
    /// </summary>
    public static void ImageFlipVertical(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageFlipVertical(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    public static void ImageFlipHorizontal(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageFlipHorizontal(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    public static void ImageRotateCW(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageRotateCW(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    public static void ImageRotateCCW(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageRotateCCW(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    public static void ImageColorTint(Image* image, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageColorTint(image, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    public static void ImageColorInvert(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageColorInvert(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    public static void ImageColorGrayscale(Image* image)
    {
        /*|  Image * => Image*  |*/
        Raylib.ImageColorGrayscale(image);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    public static void ImageColorContrast(Image* image, float contrast)
    {
        /*|  Image * => Image*  |*/
        /*|  float => float  |*/
        Raylib.ImageColorContrast(image, contrast);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    public static void ImageColorBrightness(Image* image, int brightness)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        Raylib.ImageColorBrightness(image, brightness);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    public static void ImageColorReplace(Image* image, Color color, Color replace)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        Raylib.ImageColorReplace(image, color, replace);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load color data from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color[] LoadImageColors(Image image)
    {
        /*|  Image => Image  |*/
        return Helpers.PrtToArray(Raylib.LoadImageColors(image));
        /*|  return Color * => Color[]  |*/
    }

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color[] LoadImagePalette(Image image, int maxPaletteSize, int* colorCount)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadImagePalette(image, maxPaletteSize, colorCount));
        /*|  return Color * => Color[]  |*/
    }

    /// <summary>
    /// Unload color data loaded with LoadImageColors()
    /// </summary>
    public static void UnloadImageColors(Color* colors)
    {
        /*|  Color * => Color*  |*/
        Raylib.UnloadImageColors(colors);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload colors palette loaded with LoadImagePalette()
    /// </summary>
    public static void UnloadImagePalette(Color* colors)
    {
        /*|  Color * => Color*  |*/
        Raylib.UnloadImagePalette(colors);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    public static Rectangle GetImageAlphaBorder(Image image, float threshold)
    {
        /*|  Image => Image  |*/
        /*|  float => float  |*/
        return Raylib.GetImageAlphaBorder(image, threshold);
        /*|  return Rectangle => Rectangle  |*/
    }

    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    public static Color GetImageColor(Image image, int x, int y)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetImageColor(image, x, y);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    public static void ImageClearBackground(Image* dst, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Color => Color  |*/
        Raylib.ImageClearBackground(dst, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    public static void ImageDrawPixel(Image* dst, int posX, int posY, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawPixel(dst, posX, posY, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    public static void ImageDrawPixelV(Image* dst, Vector2 position, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawPixelV(dst, position, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw line within an image
    /// </summary>
    public static void ImageDrawLine(Image* dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawLine(dst, startPosX, startPosY, endPosX, endPosY, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    public static void ImageDrawLineV(Image* dst, Vector2 start, Vector2 end, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawLineV(dst, start, end, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw circle within an image
    /// </summary>
    public static void ImageDrawCircle(Image* dst, int centerX, int centerY, int radius, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawCircle(dst, centerX, centerY, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw circle within an image (Vector version)
    /// </summary>
    public static void ImageDrawCircleV(Image* dst, Vector2 center, int radius, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawCircleV(dst, center, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangle(Image* dst, int posX, int posY, int width, int height, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangle(dst, posX, posY, width, height, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    public static void ImageDrawRectangleV(Image* dst, Vector2 position, Vector2 size, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleV(dst, position, size, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangleRec(Image* dst, Rectangle rec, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleRec(dst, rec, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    public static void ImageDrawRectangleLines(Image* dst, Rectangle rec, int thick, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawRectangleLines(dst, rec, thick, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public static void ImageDraw(Image* dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        /*|  Image * => Image*  |*/
        /*|  Image => Image  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDraw(dst, src, srcRec, dstRec, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    public static void ImageDrawText(Image* dst, string text, int posX, int posY, int fontSize, Color color)
    {
        /*|  Image * => Image*  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.ImageDrawText(dst, textLocal.AsPtr(), posX, posY, fontSize, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void ImageDrawTextEx(Image* dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
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
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public static Texture2D LoadTexture(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadTexture(fileNameLocal.AsPtr());
        /*|  return Texture2D => Texture2D  |*/
    }

    /// <summary>
    /// Load texture from image data
    /// </summary>
    public static Texture2D LoadTextureFromImage(Image image)
    {
        /*|  Image => Image  |*/
        return Raylib.LoadTextureFromImage(image);
        /*|  return Texture2D => Texture2D  |*/
    }

    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    public static TextureCubemap LoadTextureCubemap(Image image, int layout)
    {
        /*|  Image => Image  |*/
        /*|  int => int  |*/
        return Raylib.LoadTextureCubemap(image, layout);
        /*|  return TextureCubemap => TextureCubemap  |*/
    }

    /// <summary>
    /// Load texture for rendering (framebuffer)
    /// </summary>
    public static RenderTexture2D LoadRenderTexture(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.LoadRenderTexture(width, height);
        /*|  return RenderTexture2D => RenderTexture2D  |*/
    }

    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadTexture(Texture2D texture)
    {
        /*|  Texture2D => Texture2D  |*/
        Raylib.UnloadTexture(texture);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload render texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadRenderTexture(RenderTexture2D target)
    {
        /*|  RenderTexture2D => RenderTexture2D  |*/
        Raylib.UnloadRenderTexture(target);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public static void UpdateTexture(Texture2D texture, IntPtr pixels)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  const void * => IntPtr  |*/
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTexture(texture, pixelsLocal);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    public static void UpdateTextureRec(Texture2D texture, Rectangle rec, IntPtr pixels)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  const void * => IntPtr  |*/
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTextureRec(texture, rec, pixelsLocal);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    public static void GenTextureMipmaps(Texture2D* texture)
    {
        /*|  Texture2D * => Texture2D*  |*/
        Raylib.GenTextureMipmaps(texture);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    public static void SetTextureFilter(Texture2D texture, int filter)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        Raylib.SetTextureFilter(texture, filter);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    public static void SetTextureWrap(Texture2D texture, int wrap)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        Raylib.SetTextureWrap(texture, wrap);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    public static void DrawTexture(Texture2D texture, int posX, int posY, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexture(texture, posX, posY, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    public static void DrawTextureV(Texture2D texture, Vector2 position, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureV(texture, position, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    public static void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    public static void DrawTextureRec(Texture2D texture, Rectangle source, Vector2 position, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureRec(texture, source, position, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw texture quad with tiling and offset parameters
    /// </summary>
    public static void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureQuad(texture, tiling, offset, quad, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.
    /// </summary>
    public static void DrawTextureTiled(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureTiled(texture, source, dest, origin, rotation, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    public static void DrawTexturePro(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    public static void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  NPatchInfo => NPatchInfo  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a textured polygon
    /// </summary>
    public static void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2* points, Vector2* texcoords, int pointCount, Color tint)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 * => Vector2*  |*/
        /*|  Vector2 * => Vector2*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTexturePoly(texture, center, points, texcoords, pointCount, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color Fade(Color color, float alpha)
    {
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        return Raylib.Fade(color, alpha);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get hexadecimal value for a Color
    /// </summary>
    public static int ColorToInt(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorToInt(color);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    public static Vector4 ColorNormalize(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorNormalize(color);
        /*|  return Vector4 => Vector4  |*/
    }

    /// <summary>
    /// Get Color from normalized values [0..1]
    /// </summary>
    public static Color ColorFromNormalized(Vector4 normalized)
    {
        /*|  Vector4 => Vector4  |*/
        return Raylib.ColorFromNormalized(normalized);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Vector3 ColorToHSV(Color color)
    {
        /*|  Color => Color  |*/
        return Raylib.ColorToHSV(color);
        /*|  return Vector3 => Vector3  |*/
    }

    /// <summary>
    /// Get a Color from HSV values, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Color ColorFromHSV(float hue, float saturation, float value)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.ColorFromHSV(hue, saturation, value);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color ColorAlpha(Color color, float alpha)
    {
        /*|  Color => Color  |*/
        /*|  float => float  |*/
        return Raylib.ColorAlpha(color, alpha);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    public static Color ColorAlphaBlend(Color dst, Color src, Color tint)
    {
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        /*|  Color => Color  |*/
        return Raylib.ColorAlphaBlend(dst, src, tint);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get Color structure from hexadecimal value
    /// </summary>
    public static Color GetColor(uint hexValue)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.GetColor(hexValue);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Get Color from a source pixel pointer of certain format
    /// </summary>
    public static Color GetPixelColor(IntPtr srcPtr, int format)
    {
        /*|  void * => IntPtr  |*/
        var srcPtrLocal = (void*)srcPtr;
        /*|  int => int  |*/
        return Raylib.GetPixelColor(srcPtrLocal, format);
        /*|  return Color => Color  |*/
    }

    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    public static void SetPixelColor(IntPtr dstPtr, Color color, int format)
    {
        /*|  void * => IntPtr  |*/
        var dstPtrLocal = (void*)dstPtr;
        /*|  Color => Color  |*/
        /*|  int => int  |*/
        Raylib.SetPixelColor(dstPtrLocal, color, format);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get pixel data size in bytes for certain format
    /// </summary>
    public static int GetPixelDataSize(int width, int height, int format)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetPixelDataSize(width, height, format);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get the default Font
    /// </summary>
    public static Font GetFontDefault()
    {
        return Raylib.GetFontDefault();
        /*|  return Font => Font  |*/
    }

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    public static Font LoadFont(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadFont(fileNameLocal.AsPtr());
        /*|  return Font => Font  |*/
    }

    /// <summary>
    /// Load font from file with extended parameters
    /// </summary>
    public static Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        return Raylib.LoadFontEx(fileNameLocal.AsPtr(), fontSize, fontChars, glyphCount);
        /*|  return Font => Font  |*/
    }

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    public static Font LoadFontFromImage(Image image, Color key, int firstChar)
    {
        /*|  Image => Image  |*/
        /*|  Color => Color  |*/
        /*|  int => int  |*/
        return Raylib.LoadFontFromImage(image, key, firstChar);
        /*|  return Font => Font  |*/
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(string fileType, byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount)
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
        /*|  return Font => Font  |*/
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo[] LoadFontData(byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, int type)
    {
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Helpers.PrtToArray(Raylib.LoadFontData(fileDataLocal, dataSize, fontSize, fontChars, glyphCount, type));
        /*|  return GlyphInfo * => GlyphInfo[]  |*/
    }

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public static Image GenImageFontAtlas(GlyphInfo* chars, Rectangle[] recs, int glyphCount, int fontSize, int padding, int packMethod)
    {
        /*|  const GlyphInfo * => GlyphInfo*  |*/
        /*|  Rectangle ** => Rectangle[]  |*/
        var recsLocal = Helpers.ArrayToPtr(recs);
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenImageFontAtlas(chars, &recsLocal, glyphCount, fontSize, padding, packMethod);
        /*|  return Image => Image  |*/
    }

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    public static void UnloadFontData(GlyphInfo* chars, int glyphCount)
    {
        /*|  GlyphInfo * => GlyphInfo*  |*/
        /*|  int => int  |*/
        Raylib.UnloadFontData(chars, glyphCount);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload Font from GPU memory (VRAM)
    /// </summary>
    public static void UnloadFont(Font font)
    {
        /*|  Font => Font  |*/
        Raylib.UnloadFont(font);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw current FPS
    /// </summary>
    public static void DrawFPS(int posX, int posY)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.DrawFPS(posX, posY);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawText(textLocal.AsPtr(), posX, posY, fontSize, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextEx(font, textLocal.AsPtr(), position, fontSize, spacing, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
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
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    public static void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public static int MeasureText(string text, int fontSize)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        return Raylib.MeasureText(textLocal.AsPtr(), fontSize);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        /*|  Font => Font  |*/
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.MeasureTextEx(font, textLocal.AsPtr(), fontSize, spacing);
        /*|  return Vector2 => Vector2  |*/
    }

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static int GetGlyphIndex(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphIndex(font, codepoint);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static GlyphInfo GetGlyphInfo(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphInfo(font, codepoint);
        /*|  return GlyphInfo => GlyphInfo  |*/
    }

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static Rectangle GetGlyphAtlasRec(Font font, int codepoint)
    {
        /*|  Font => Font  |*/
        /*|  int => int  |*/
        return Raylib.GetGlyphAtlasRec(font, codepoint);
        /*|  return Rectangle => Rectangle  |*/
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public static int[] LoadCodepoints(string text, int* count)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadCodepoints(textLocal.AsPtr(), count));
        /*|  return int * => int[]  |*/
    }

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    public static void UnloadCodepoints(int* codepoints)
    {
        /*|  int * => int*  |*/
        Raylib.UnloadCodepoints(codepoints);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public static int GetCodepointCount(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.GetCodepointCount(textLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(string text, int* bytesProcessed)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int * => int*  |*/
        return Raylib.GetCodepoint(textLocal.AsPtr(), bytesProcessed);
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public static string CodepointToUTF8(int codepoint, int* byteSize)
    {
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.Utf8ToString(Raylib.CodepointToUTF8(codepoint, byteSize));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextCodepointsToUTF8(int* codepoints, int length)
    {
        /*|  int * => int*  |*/
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.TextCodepointsToUTF8(codepoints, length));
        /*|  return char * => string  |*/
    }

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    public static int TextCopy(string dst, string src)
    {
        /*|  char * => string  |*/
        using var dstLocal = dst.MarshalUtf8();
        /*|  const char * => string  |*/
        using var srcLocal = src.MarshalUtf8();
        return Raylib.TextCopy(dstLocal.AsPtr(), srcLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    public static bool TextIsEqual(string text1, string text2)
    {
        /*|  const char * => string  |*/
        using var text1Local = text1.MarshalUtf8();
        /*|  const char * => string  |*/
        using var text2Local = text2.MarshalUtf8();
        return Raylib.TextIsEqual(text1Local.AsPtr(), text2Local.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get text length, checks for ' 0' ending
    /// </summary>
    public static uint TextLength(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return (uint)Raylib.TextLength(textLocal.AsPtr());
        /*|  return unsigned int => uint  |*/
    }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    public static string TextSubtext(string text, int position, int length)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.TextSubtext(textLocal.AsPtr(), position, length));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextReplace(string text, string replace, string by)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var replaceLocal = replace.MarshalUtf8();
        /*|  const char * => string  |*/
        using var byLocal = by.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextReplace(textLocal.AsPtr(), replaceLocal.AsPtr(), byLocal.AsPtr()));
        /*|  return char * => string  |*/
    }

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    public static string TextInsert(string text, string insert, int position)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var insertLocal = insert.MarshalUtf8();
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.TextInsert(textLocal.AsPtr(), insertLocal.AsPtr(), position));
        /*|  return char * => string  |*/
    }

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    public static void TextAppend(string text, string append, int* position)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var appendLocal = append.MarshalUtf8();
        /*|  int * => int*  |*/
        Raylib.TextAppend(textLocal.AsPtr(), appendLocal.AsPtr(), position);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    public static int TextFindIndex(string text, string find)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        /*|  const char * => string  |*/
        using var findLocal = find.MarshalUtf8();
        return Raylib.TextFindIndex(textLocal.AsPtr(), findLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    public static string TextToUpper(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToUpper(textLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    public static string TextToLower(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToLower(textLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public static string TextToPascal(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.TextToPascal(textLocal.AsPtr()));
        /*|  return const char * => string  |*/
    }

    /// <summary>
    /// Get integer value from text (negative values not supported)
    /// </summary>
    public static int TextToInteger(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.TextToInteger(textLocal.AsPtr());
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    public static void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawLine3D(startPos, endPos, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    public static void DrawPoint3D(Vector3 position, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPoint3D(position, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    public static void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangle3D(v1, v2, v3, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip3D(Vector3* points, int pointCount, Color color)
    {
        /*|  Vector3 * => Vector3*  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawTriangleStrip3D(points, pointCount, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube
    /// </summary>
    public static void DrawCube(Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCube(position, width, height, length, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    public static void DrawCubeV(Vector3 position, Vector3 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeV(position, size, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube wires
    /// </summary>
    public static void DrawCubeWires(Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeWires(position, width, height, length, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    public static void DrawCubeWiresV(Vector3 position, Vector3 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeWiresV(position, size, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube textured
    /// </summary>
    public static void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeTexture(texture, position, width, height, length, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw cube with a region of a texture
    /// </summary>
    public static void DrawCubeTextureRec(Texture2D texture, Rectangle source, Vector3 position, float width, float height, float length, Color color)
    {
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCubeTextureRec(texture, source, position, width, height, length, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw sphere
    /// </summary>
    public static void DrawSphere(Vector3 centerPos, float radius, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphere(centerPos, radius, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    public static void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphereEx(centerPos, radius, rings, slices, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    public static void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawSphereWires(centerPos, radius, rings, slices, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    public static void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderEx(startPos, endPos, startRadius, endRadius, sides, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    public static void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  Color => Color  |*/
        Raylib.DrawCylinderWiresEx(startPos, endPos, startRadius, endRadius, sides, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    public static void DrawPlane(Vector3 centerPos, Vector2 size, Color color)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawPlane(centerPos, size, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a ray line
    /// </summary>
    public static void DrawRay(Ray ray, Color color)
    {
        /*|  Ray => Ray  |*/
        /*|  Color => Color  |*/
        Raylib.DrawRay(ray, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a grid (centered at (0, 0, 0))
    /// </summary>
    public static void DrawGrid(int slices, float spacing)
    {
        /*|  int => int  |*/
        /*|  float => float  |*/
        Raylib.DrawGrid(slices, spacing);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    public static Model LoadModel(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadModel(fileNameLocal.AsPtr());
        /*|  return Model => Model  |*/
    }

    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    public static Model LoadModelFromMesh(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        return Raylib.LoadModelFromMesh(mesh);
        /*|  return Model => Model  |*/
    }

    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModel(Model model)
    {
        /*|  Model => Model  |*/
        Raylib.UnloadModel(model);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload model (but not meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModelKeepMeshes(Model model)
    {
        /*|  Model => Model  |*/
        Raylib.UnloadModelKeepMeshes(model);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    public static BoundingBox GetModelBoundingBox(Model model)
    {
        /*|  Model => Model  |*/
        return Raylib.GetModelBoundingBox(model);
        /*|  return BoundingBox => BoundingBox  |*/
    }

    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    public static void DrawModel(Model model, Vector3 position, float scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModel(model, position, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    public static void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    public static void DrawModelWires(Model model, Vector3 position, float scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelWires(model, position, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    public static void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        /*|  Model => Model  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Color => Color  |*/
        Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    public static void DrawBoundingBox(BoundingBox box, Color color)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBoundingBox(box, color);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    public static void DrawBillboard(Camera camera, Texture2D texture, Vector3 position, float size, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboard(camera, texture, position, size, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    public static void DrawBillboardRec(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector2 size, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    public static void DrawBillboardPro(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
    {
        /*|  Camera => Camera  |*/
        /*|  Texture2D => Texture2D  |*/
        /*|  Rectangle => Rectangle  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  Vector2 => Vector2  |*/
        /*|  float => float  |*/
        /*|  Color => Color  |*/
        Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public static void UploadMesh(Mesh* mesh, bool dynamic)
    {
        /*|  Mesh * => Mesh*  |*/
        /*|  bool => bool  |*/
        Raylib.UploadMesh(mesh, dynamic);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public static void UpdateMeshBuffer(Mesh mesh, int index, IntPtr data, int dataSize, int offset)
    {
        /*|  Mesh => Mesh  |*/
        /*|  int => int  |*/
        /*|  void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.UpdateMeshBuffer(mesh, index, dataLocal, dataSize, offset);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    public static void UnloadMesh(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        Raylib.UnloadMesh(mesh);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    public static void DrawMesh(Mesh mesh, Material material, Matrix transform)
    {
        /*|  Mesh => Mesh  |*/
        /*|  Material => Material  |*/
        /*|  Matrix => Matrix  |*/
        Raylib.DrawMesh(mesh, material, transform);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    public static void DrawMeshInstanced(Mesh mesh, Material material, Matrix* transforms, int instances)
    {
        /*|  Mesh => Mesh  |*/
        /*|  Material => Material  |*/
        /*|  Matrix * => Matrix*  |*/
        /*|  int => int  |*/
        Raylib.DrawMeshInstanced(mesh, material, transforms, instances);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    public static bool ExportMesh(Mesh mesh, string fileName)
    {
        /*|  Mesh => Mesh  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportMesh(mesh, fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    public static BoundingBox GetMeshBoundingBox(Mesh mesh)
    {
        /*|  Mesh => Mesh  |*/
        return Raylib.GetMeshBoundingBox(mesh);
        /*|  return BoundingBox => BoundingBox  |*/
    }

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    public static void GenMeshTangents(Mesh* mesh)
    {
        /*|  Mesh * => Mesh*  |*/
        Raylib.GenMeshTangents(mesh);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Compute mesh binormals
    /// </summary>
    public static void GenMeshBinormals(Mesh* mesh)
    {
        /*|  Mesh * => Mesh*  |*/
        Raylib.GenMeshBinormals(mesh);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Generate polygonal mesh
    /// </summary>
    public static Mesh GenMeshPoly(int sides, float radius)
    {
        /*|  int => int  |*/
        /*|  float => float  |*/
        return Raylib.GenMeshPoly(sides, radius);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate plane mesh (with subdivisions)
    /// </summary>
    public static Mesh GenMeshPlane(float width, float length, int resX, int resZ)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshPlane(width, length, resX, resZ);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate cuboid mesh
    /// </summary>
    public static Mesh GenMeshCube(float width, float height, float length)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  float => float  |*/
        return Raylib.GenMeshCube(width, height, length);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate sphere mesh (standard sphere)
    /// </summary>
    public static Mesh GenMeshSphere(float radius, int rings, int slices)
    {
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshSphere(radius, rings, slices);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate half-sphere mesh (no bottom cap)
    /// </summary>
    public static Mesh GenMeshHemiSphere(float radius, int rings, int slices)
    {
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshHemiSphere(radius, rings, slices);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate cylinder mesh
    /// </summary>
    public static Mesh GenMeshCylinder(float radius, float height, int slices)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshCylinder(radius, height, slices);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate cone/pyramid mesh
    /// </summary>
    public static Mesh GenMeshCone(float radius, float height, int slices)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshCone(radius, height, slices);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate torus mesh
    /// </summary>
    public static Mesh GenMeshTorus(float radius, float size, int radSeg, int sides)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshTorus(radius, size, radSeg, sides);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate trefoil knot mesh
    /// </summary>
    public static Mesh GenMeshKnot(float radius, float size, int radSeg, int sides)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GenMeshKnot(radius, size, radSeg, sides);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate heightmap mesh from image data
    /// </summary>
    public static Mesh GenMeshHeightmap(Image heightmap, Vector3 size)
    {
        /*|  Image => Image  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GenMeshHeightmap(heightmap, size);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Generate cubes-based map mesh from image data
    /// </summary>
    public static Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize)
    {
        /*|  Image => Image  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GenMeshCubicmap(cubicmap, cubeSize);
        /*|  return Mesh => Mesh  |*/
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public static Material[] LoadMaterials(string fileName, int* materialCount)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.LoadMaterials(fileNameLocal.AsPtr(), materialCount));
        /*|  return Material * => Material[]  |*/
    }

    /// <summary>
    /// Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
    /// </summary>
    public static Material LoadMaterialDefault()
    {
        return Raylib.LoadMaterialDefault();
        /*|  return Material => Material  |*/
    }

    /// <summary>
    /// Unload material from GPU memory (VRAM)
    /// </summary>
    public static void UnloadMaterial(Material material)
    {
        /*|  Material => Material  |*/
        Raylib.UnloadMaterial(material);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    public static void SetMaterialTexture(Material* material, int mapType, Texture2D texture)
    {
        /*|  Material * => Material*  |*/
        /*|  int => int  |*/
        /*|  Texture2D => Texture2D  |*/
        Raylib.SetMaterialTexture(material, mapType, texture);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    public static void SetModelMeshMaterial(Model* model, int meshId, int materialId)
    {
        /*|  Model * => Model*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetModelMeshMaterial(model, meshId, materialId);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update model animation pose
    /// </summary>
    public static void UpdateModelAnimation(Model model, ModelAnimation anim, int frame)
    {
        /*|  Model => Model  |*/
        /*|  ModelAnimation => ModelAnimation  |*/
        /*|  int => int  |*/
        Raylib.UpdateModelAnimation(model, anim, frame);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload animation data
    /// </summary>
    public static void UnloadModelAnimation(ModelAnimation anim)
    {
        /*|  ModelAnimation => ModelAnimation  |*/
        Raylib.UnloadModelAnimation(anim);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload animation array data
    /// </summary>
    public static void UnloadModelAnimations(ModelAnimation* animations, uint count)
    {
        /*|  ModelAnimation* => ModelAnimation*  |*/
        /*|  unsigned int => uint  |*/
        Raylib.UnloadModelAnimations(animations, count);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    public static bool IsModelAnimationValid(Model model, ModelAnimation anim)
    {
        /*|  Model => Model  |*/
        /*|  ModelAnimation => ModelAnimation  |*/
        return Raylib.IsModelAnimationValid(model, anim);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check collision between two spheres
    /// </summary>
    public static bool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionSpheres(center1, radius1, center2, radius2);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    public static bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  BoundingBox => BoundingBox  |*/
        return Raylib.CheckCollisionBoxes(box1, box2);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    public static bool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius)
    {
        /*|  BoundingBox => BoundingBox  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.CheckCollisionBoxSphere(box, center, radius);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    public static RayCollision GetRayCollisionSphere(Ray ray, Vector3 center, float radius)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  float => float  |*/
        return Raylib.GetRayCollisionSphere(ray, center, radius);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    public static RayCollision GetRayCollisionBox(Ray ray, BoundingBox box)
    {
        /*|  Ray => Ray  |*/
        /*|  BoundingBox => BoundingBox  |*/
        return Raylib.GetRayCollisionBox(ray, box);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Get collision info between ray and model
    /// </summary>
    public static RayCollision GetRayCollisionModel(Ray ray, Model model)
    {
        /*|  Ray => Ray  |*/
        /*|  Model => Model  |*/
        return Raylib.GetRayCollisionModel(ray, model);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    public static RayCollision GetRayCollisionMesh(Ray ray, Mesh mesh, Matrix transform)
    {
        /*|  Ray => Ray  |*/
        /*|  Mesh => Mesh  |*/
        /*|  Matrix => Matrix  |*/
        return Raylib.GetRayCollisionMesh(ray, mesh, transform);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    public static RayCollision GetRayCollisionTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GetRayCollisionTriangle(ray, p1, p2, p3);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    public static RayCollision GetRayCollisionQuad(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        /*|  Ray => Ray  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        /*|  Vector3 => Vector3  |*/
        return Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
        /*|  return RayCollision => RayCollision  |*/
    }

    /// <summary>
    /// Initialize audio device and context
    /// </summary>
    public static void InitAudioDevice()
    {
        Raylib.InitAudioDevice();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Close the audio device and context
    /// </summary>
    public static void CloseAudioDevice()
    {
        Raylib.CloseAudioDevice();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if audio device has been initialized successfully
    /// </summary>
    public static bool IsAudioDeviceReady()
    {
        return Raylib.IsAudioDeviceReady();
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Set master volume (listener)
    /// </summary>
    public static void SetMasterVolume(float volume)
    {
        /*|  float => float  |*/
        Raylib.SetMasterVolume(volume);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public static Wave LoadWave(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadWave(fileNameLocal.AsPtr());
        /*|  return Wave => Wave  |*/
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public static Wave LoadWaveFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        return Raylib.LoadWaveFromMemory(fileTypeLocal.AsPtr(), fileDataLocal, dataSize);
        /*|  return Wave => Wave  |*/
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public static Sound LoadSound(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadSound(fileNameLocal.AsPtr());
        /*|  return Sound => Sound  |*/
    }

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public static Sound LoadSoundFromWave(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Raylib.LoadSoundFromWave(wave);
        /*|  return Sound => Sound  |*/
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public static void UpdateSound(Sound sound, IntPtr data, int sampleCount)
    {
        /*|  Sound => Sound  |*/
        /*|  const void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        Raylib.UpdateSound(sound, dataLocal, sampleCount);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload wave data
    /// </summary>
    public static void UnloadWave(Wave wave)
    {
        /*|  Wave => Wave  |*/
        Raylib.UnloadWave(wave);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Unload sound
    /// </summary>
    public static void UnloadSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.UnloadSound(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public static bool ExportWave(Wave wave, string fileName)
    {
        /*|  Wave => Wave  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportWave(wave, fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static bool ExportWaveAsCode(Wave wave, string fileName)
    {
        /*|  Wave => Wave  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportWaveAsCode(wave, fileNameLocal.AsPtr());
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public static void PlaySound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.PlaySound(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public static void StopSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.StopSound(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    public static void PauseSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.PauseSound(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public static void ResumeSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.ResumeSound(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Play a sound (using multichannel buffer pool)
    /// </summary>
    public static void PlaySoundMulti(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.PlaySoundMulti(sound);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Stop any sound playing (using multichannel buffer pool)
    /// </summary>
    public static void StopSoundMulti()
    {
        Raylib.StopSoundMulti();
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get number of sounds playing in the multichannel
    /// </summary>
    public static int GetSoundsPlaying()
    {
        return Raylib.GetSoundsPlaying();
        /*|  return int => int  |*/
    }

    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    public static bool IsSoundPlaying(Sound sound)
    {
        /*|  Sound => Sound  |*/
        return Raylib.IsSoundPlaying(sound);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public static void SetSoundVolume(Sound sound, float volume)
    {
        /*|  Sound => Sound  |*/
        /*|  float => float  |*/
        Raylib.SetSoundVolume(sound, volume);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public static void SetSoundPitch(Sound sound, float pitch)
    {
        /*|  Sound => Sound  |*/
        /*|  float => float  |*/
        Raylib.SetSoundPitch(sound, pitch);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public static void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels)
    {
        /*|  Wave * => Wave*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.WaveFormat(wave, sampleRate, sampleSize, channels);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public static Wave WaveCopy(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Raylib.WaveCopy(wave);
        /*|  return Wave => Wave  |*/
    }

    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public static void WaveCrop(Wave* wave, int initSample, int finalSample)
    {
        /*|  Wave * => Wave*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.WaveCrop(wave, initSample, finalSample);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load samples data from wave as a floats array
    /// </summary>
    public static float[] LoadWaveSamples(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Helpers.PrtToArray(Raylib.LoadWaveSamples(wave));
        /*|  return float * => float[]  |*/
    }

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    public static void UnloadWaveSamples(float* samples)
    {
        /*|  float * => float*  |*/
        Raylib.UnloadWaveSamples(samples);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public static Music LoadMusicStream(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadMusicStream(fileNameLocal.AsPtr());
        /*|  return Music => Music  |*/
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public static Music LoadMusicStreamFromMemory(string fileType, byte[] data, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        return Raylib.LoadMusicStreamFromMemory(fileTypeLocal.AsPtr(), dataLocal, dataSize);
        /*|  return Music => Music  |*/
    }

    /// <summary>
    /// Unload music stream
    /// </summary>
    public static void UnloadMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.UnloadMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Start music playing
    /// </summary>
    public static void PlayMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.PlayMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if music is playing
    /// </summary>
    public static bool IsMusicStreamPlaying(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.IsMusicStreamPlaying(music);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    public static void UpdateMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.UpdateMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Stop music playing
    /// </summary>
    public static void StopMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.StopMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Pause music playing
    /// </summary>
    public static void PauseMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.PauseMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    public static void ResumeMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.ResumeMusicStream(music);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    public static void SeekMusicStream(Music music, float position)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SeekMusicStream(music, position);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    public static void SetMusicVolume(Music music, float volume)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SetMusicVolume(music, volume);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    public static void SetMusicPitch(Music music, float pitch)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SetMusicPitch(music, pitch);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    public static float GetMusicTimeLength(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.GetMusicTimeLength(music);
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    public static float GetMusicTimePlayed(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.GetMusicTimePlayed(music);
        /*|  return float => float  |*/
    }

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    public static AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels)
    {
        /*|  unsigned int => uint  |*/
        /*|  unsigned int => uint  |*/
        /*|  unsigned int => uint  |*/
        return Raylib.LoadAudioStream(sampleRate, sampleSize, channels);
        /*|  return AudioStream => AudioStream  |*/
    }

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    public static void UnloadAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.UnloadAudioStream(stream);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream(AudioStream stream, IntPtr data, int frameCount)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  const void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        Raylib.UpdateAudioStream(stream, dataLocal, frameCount);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    public static bool IsAudioStreamProcessed(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        return Raylib.IsAudioStreamProcessed(stream);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Play audio stream
    /// </summary>
    public static void PlayAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.PlayAudioStream(stream);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Pause audio stream
    /// </summary>
    public static void PauseAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.PauseAudioStream(stream);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Resume audio stream
    /// </summary>
    public static void ResumeAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.ResumeAudioStream(stream);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    public static bool IsAudioStreamPlaying(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        return Raylib.IsAudioStreamPlaying(stream);
        /*|  return bool => bool  |*/
    }

    /// <summary>
    /// Stop audio stream
    /// </summary>
    public static void StopAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.StopAudioStream(stream);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    public static void SetAudioStreamVolume(AudioStream stream, float volume)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  float => float  |*/
        Raylib.SetAudioStreamVolume(stream, volume);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public static void SetAudioStreamPitch(AudioStream stream, float pitch)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  float => float  |*/
        Raylib.SetAudioStreamPitch(stream, pitch);
        /*|  return void => void  |*/
    }

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    public static void SetAudioStreamBufferSizeDefault(int size)
    {
        /*|  int => int  |*/
        Raylib.SetAudioStreamBufferSizeDefault(size);
        /*|  return void => void  |*/
    }

}
#pragma warning restore
