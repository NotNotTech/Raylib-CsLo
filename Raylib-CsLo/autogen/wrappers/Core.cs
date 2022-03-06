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
    public void InitWindow(int width, int height, string title)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  const char * => string  |*/
        using var titleLocal = title.MarshalUtf8();
        Raylib.InitWindow(width, height, titleLocal.AsPtr());
    }

    /// <summary>
    /// Check if KEY_ESCAPE pressed or Close icon pressed
    /// </summary>
    public bool WindowShouldClose()
    {
        return Raylib.WindowShouldClose();
    }

    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    public void CloseWindow()
    {
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    public bool IsWindowReady()
    {
        return Raylib.IsWindowReady();
    }

    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    public bool IsWindowFullscreen()
    {
        return Raylib.IsWindowFullscreen();
    }

    /// <summary>
    /// Check if window is currently hidden (only PLATFORM_DESKTOP)
    /// </summary>
    public bool IsWindowHidden()
    {
        return Raylib.IsWindowHidden();
    }

    /// <summary>
    /// Check if window is currently minimized (only PLATFORM_DESKTOP)
    /// </summary>
    public bool IsWindowMinimized()
    {
        return Raylib.IsWindowMinimized();
    }

    /// <summary>
    /// Check if window is currently maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public bool IsWindowMaximized()
    {
        return Raylib.IsWindowMaximized();
    }

    /// <summary>
    /// Check if window is currently focused (only PLATFORM_DESKTOP)
    /// </summary>
    public bool IsWindowFocused()
    {
        return Raylib.IsWindowFocused();
    }

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    public bool IsWindowResized()
    {
        return Raylib.IsWindowResized();
    }

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    public bool IsWindowState(uint flag)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.IsWindowState(flag);
    }

    /// <summary>
    /// Set window configuration state using flags
    /// </summary>
    public void SetWindowState(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetWindowState(flags);
    }

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    public void ClearWindowState(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.ClearWindowState(flags);
    }

    /// <summary>
    /// Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)
    /// </summary>
    public void ToggleFullscreen()
    {
        Raylib.ToggleFullscreen();
    }

    /// <summary>
    /// Set window state: maximized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public void MaximizeWindow()
    {
        Raylib.MaximizeWindow();
    }

    /// <summary>
    /// Set window state: minimized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public void MinimizeWindow()
    {
        Raylib.MinimizeWindow();
    }

    /// <summary>
    /// Set window state: not minimized/maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public void RestoreWindow()
    {
        Raylib.RestoreWindow();
    }

    /// <summary>
    /// Set icon for window (only PLATFORM_DESKTOP)
    /// </summary>
    public void SetWindowIcon(Image image)
    {
        /*|  Image => Image  |*/
        Raylib.SetWindowIcon(image);
    }

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP)
    /// </summary>
    public void SetWindowTitle(string title)
    {
        /*|  const char * => string  |*/
        using var titleLocal = title.MarshalUtf8();
        Raylib.SetWindowTitle(titleLocal.AsPtr());
    }

    /// <summary>
    /// Set window position on screen (only PLATFORM_DESKTOP)
    /// </summary>
    public void SetWindowPosition(int x, int y)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowPosition(x, y);
    }

    /// <summary>
    /// Set monitor for the current window (fullscreen mode)
    /// </summary>
    public void SetWindowMonitor(int monitor)
    {
        /*|  int => int  |*/
        Raylib.SetWindowMonitor(monitor);
    }

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    public void SetWindowMinSize(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowMinSize(width, height);
    }

    /// <summary>
    /// Set window dimensions
    /// </summary>
    public void SetWindowSize(int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetWindowSize(width, height);
    }

    /// <summary>
    /// Get native window handle
    /// </summary>
    public IntPtr GetWindowHandle()
    {
        return (IntPtr)Raylib.GetWindowHandle();
    }

    /// <summary>
    /// Get current screen width
    /// </summary>
    public int GetScreenWidth()
    {
        return Raylib.GetScreenWidth();
    }

    /// <summary>
    /// Get current screen height
    /// </summary>
    public int GetScreenHeight()
    {
        return Raylib.GetScreenHeight();
    }

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    public int GetMonitorCount()
    {
        return Raylib.GetMonitorCount();
    }

    /// <summary>
    /// Get current connected monitor
    /// </summary>
    public int GetCurrentMonitor()
    {
        return Raylib.GetCurrentMonitor();
    }

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    public Vector2 GetMonitorPosition(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPosition(monitor);
    }

    /// <summary>
    /// Get specified monitor width (max available by monitor)
    /// </summary>
    public int GetMonitorWidth(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor height (max available by monitor)
    /// </summary>
    public int GetMonitorHeight(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    public int GetMonitorPhysicalWidth(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPhysicalWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    public int GetMonitorPhysicalHeight(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorPhysicalHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    public int GetMonitorRefreshRate(int monitor)
    {
        /*|  int => int  |*/
        return Raylib.GetMonitorRefreshRate(monitor);
    }

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    public Vector2 GetWindowPosition()
    {
        return Raylib.GetWindowPosition();
    }

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    public Vector2 GetWindowScaleDPI()
    {
        return Raylib.GetWindowScaleDPI();
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the primary monitor
    /// </summary>
    public string GetMonitorName(int monitor)
    {
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.GetMonitorName(monitor));
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public void SetClipboardText(string text)
    {
        /*|  const char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        Raylib.SetClipboardText(textLocal.AsPtr());
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public string GetClipboardText()
    {
        return Helpers.Utf8ToString(Raylib.GetClipboardText());
    }

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    public void SwapScreenBuffer()
    {
        Raylib.SwapScreenBuffer();
    }

    /// <summary>
    /// Register all input events
    /// </summary>
    public void PollInputEvents()
    {
        Raylib.PollInputEvents();
    }

    /// <summary>
    /// Wait for some milliseconds (halt program execution)
    /// </summary>
    public void WaitTime(float ms)
    {
        /*|  float => float  |*/
        Raylib.WaitTime(ms);
    }

    /// <summary>
    /// Shows cursor
    /// </summary>
    public void ShowCursor()
    {
        Raylib.ShowCursor();
    }

    /// <summary>
    /// Hides cursor
    /// </summary>
    public void HideCursor()
    {
        Raylib.HideCursor();
    }

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    public bool IsCursorHidden()
    {
        return Raylib.IsCursorHidden();
    }

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    public void EnableCursor()
    {
        Raylib.EnableCursor();
    }

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    public void DisableCursor()
    {
        Raylib.DisableCursor();
    }

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    public bool IsCursorOnScreen()
    {
        return Raylib.IsCursorOnScreen();
    }

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    public void ClearBackground(Color color)
    {
        /*|  Color => Color  |*/
        Raylib.ClearBackground(color);
    }

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    public void BeginDrawing()
    {
        Raylib.BeginDrawing();
    }

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    public void EndDrawing()
    {
        Raylib.EndDrawing();
    }

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    public void BeginMode2D(Camera2D camera)
    {
        /*|  Camera2D => Camera2D  |*/
        Raylib.BeginMode2D(camera);
    }

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    public void EndMode2D()
    {
        Raylib.EndMode2D();
    }

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public void BeginMode3D(Camera3D camera)
    {
        /*|  Camera3D => Camera3D  |*/
        Raylib.BeginMode3D(camera);
    }

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public void EndMode3D()
    {
        Raylib.EndMode3D();
    }

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    public void BeginTextureMode(RenderTexture2D target)
    {
        /*|  RenderTexture2D => RenderTexture2D  |*/
        Raylib.BeginTextureMode(target);
    }

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    public void EndTextureMode()
    {
        Raylib.EndTextureMode();
    }

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    public void BeginShaderMode(Shader shader)
    {
        /*|  Shader => Shader  |*/
        Raylib.BeginShaderMode(shader);
    }

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    public void EndShaderMode()
    {
        Raylib.EndShaderMode();
    }

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    public void BeginBlendMode(int mode)
    {
        /*|  int => int  |*/
        Raylib.BeginBlendMode(mode);
    }

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    public void EndBlendMode()
    {
        Raylib.EndBlendMode();
    }

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    public void BeginScissorMode(int x, int y, int width, int height)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.BeginScissorMode(x, y, width, height);
    }

    /// <summary>
    /// End scissor mode
    /// </summary>
    public void EndScissorMode()
    {
        Raylib.EndScissorMode();
    }

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    public void BeginVrStereoMode(VrStereoConfig config)
    {
        /*|  VrStereoConfig => VrStereoConfig  |*/
        Raylib.BeginVrStereoMode(config);
    }

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    public void EndVrStereoMode()
    {
        Raylib.EndVrStereoMode();
    }

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    public VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device)
    {
        /*|  VrDeviceInfo => VrDeviceInfo  |*/
        return Raylib.LoadVrStereoConfig(device);
    }

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    public void UnloadVrStereoConfig(VrStereoConfig config)
    {
        /*|  VrStereoConfig => VrStereoConfig  |*/
        Raylib.UnloadVrStereoConfig(config);
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public Shader LoadShader(string vsFileName, string fsFileName)
    {
        /*|  const char * => string  |*/
        using var vsFileNameLocal = vsFileName.MarshalUtf8();
        /*|  const char * => string  |*/
        using var fsFileNameLocal = fsFileName.MarshalUtf8();
        return Raylib.LoadShader(vsFileNameLocal.AsPtr(), fsFileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public Shader LoadShaderFromMemory(string vsCode, string fsCode)
    {
        /*|  const char * => string  |*/
        using var vsCodeLocal = vsCode.MarshalUtf8();
        /*|  const char * => string  |*/
        using var fsCodeLocal = fsCode.MarshalUtf8();
        return Raylib.LoadShaderFromMemory(vsCodeLocal.AsPtr(), fsCodeLocal.AsPtr());
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public int GetShaderLocation(Shader shader, string uniformName)
    {
        /*|  Shader => Shader  |*/
        /*|  const char * => string  |*/
        using var uniformNameLocal = uniformName.MarshalUtf8();
        return Raylib.GetShaderLocation(shader, uniformNameLocal.AsPtr());
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public int GetShaderLocationAttrib(Shader shader, string attribName)
    {
        /*|  Shader => Shader  |*/
        /*|  const char * => string  |*/
        using var attribNameLocal = attribName.MarshalUtf8();
        return Raylib.GetShaderLocationAttrib(shader, attribNameLocal.AsPtr());
    }

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public void SetShaderValue(Shader shader, int locIndex, IntPtr value, int uniformType)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  const void * => IntPtr  |*/
        var valueLocal = (void*)value;
        /*|  int => int  |*/
        Raylib.SetShaderValue(shader, locIndex, valueLocal, uniformType);
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public void SetShaderValueV(Shader shader, int locIndex, IntPtr value, int uniformType, int count)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  const void * => IntPtr  |*/
        var valueLocal = (void*)value;
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetShaderValueV(shader, locIndex, valueLocal, uniformType, count);
    }

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public void SetShaderValueMatrix(Shader shader, int locIndex, Matrix mat)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  Matrix => Matrix  |*/
        Raylib.SetShaderValueMatrix(shader, locIndex, mat);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public void SetShaderValueTexture(Shader shader, int locIndex, Texture2D texture)
    {
        /*|  Shader => Shader  |*/
        /*|  int => int  |*/
        /*|  Texture2D => Texture2D  |*/
        Raylib.SetShaderValueTexture(shader, locIndex, texture);
    }

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    public void UnloadShader(Shader shader)
    {
        /*|  Shader => Shader  |*/
        Raylib.UnloadShader(shader);
    }

    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public Ray GetMouseRay(Vector2 mousePosition, Camera camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera => Camera  |*/
        return Raylib.GetMouseRay(mousePosition, camera);
    }

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public Matrix GetCameraMatrix(Camera camera)
    {
        /*|  Camera => Camera  |*/
        return Raylib.GetCameraMatrix(camera);
    }

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    public Matrix GetCameraMatrix2D(Camera2D camera)
    {
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetCameraMatrix2D(camera);
    }

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public Vector2 GetWorldToScreen(Vector3 position, Camera camera)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Camera => Camera  |*/
        return Raylib.GetWorldToScreen(position, camera);
    }

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public Vector2 GetWorldToScreenEx(Vector3 position, Camera camera, int width, int height)
    {
        /*|  Vector3 => Vector3  |*/
        /*|  Camera => Camera  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetWorldToScreenEx(position, camera, width, height);
    }

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    public Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetWorldToScreen2D(position, camera);
    }

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    public Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera)
    {
        /*|  Vector2 => Vector2  |*/
        /*|  Camera2D => Camera2D  |*/
        return Raylib.GetScreenToWorld2D(position, camera);
    }

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    public void SetTargetFPS(int fps)
    {
        /*|  int => int  |*/
        Raylib.SetTargetFPS(fps);
    }

    /// <summary>
    /// Get current FPS
    /// </summary>
    public int GetFPS()
    {
        return Raylib.GetFPS();
    }

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    public float GetFrameTime()
    {
        return Raylib.GetFrameTime();
    }

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    public double GetTime()
    {
        return Raylib.GetTime();
    }

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    public int GetRandomValue(int min, int max)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetRandomValue(min, max);
    }

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    public void SetRandomSeed(uint seed)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetRandomSeed(seed);
    }

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    public void TakeScreenshot(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        Raylib.TakeScreenshot(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Setup init configuration flags (view FLAGS)
    /// </summary>
    public void SetConfigFlags(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetConfigFlags(flags);
    }

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    public void SetTraceLogLevel(int logLevel)
    {
        /*|  int => int  |*/
        Raylib.SetTraceLogLevel(logLevel);
    }

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    public IntPtr MemAlloc(int size)
    {
        /*|  int => int  |*/
        return (IntPtr)Raylib.MemAlloc(size);
    }

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    public IntPtr MemRealloc(IntPtr ptr, int size)
    {
        /*|  void * => IntPtr  |*/
        var ptrLocal = (void*)ptr;
        /*|  int => int  |*/
        return (IntPtr)Raylib.MemRealloc(ptrLocal, size);
    }

    /// <summary>
    /// Internal memory free
    /// </summary>
    public void MemFree(IntPtr ptr)
    {
        /*|  void * => IntPtr  |*/
        var ptrLocal = (void*)ptr;
        Raylib.MemFree(ptrLocal);
    }

    /// <summary>
    /// Load file data as byte array (read)
    /// </summary>
    public byte[] LoadFileData(string fileName, out uint bytesRead)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  unsigned int * => out uint  |*/
        return Helpers.PrtToArray(Raylib.LoadFileData(fileNameLocal.AsPtr(), bytesRead));
    }

    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    public void UnloadFileData(byte[] data)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        Raylib.UnloadFileData(dataLocal);
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public bool SaveFileData(string fileName, IntPtr data, uint bytesToWrite)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  unsigned int => uint  |*/
        return Raylib.SaveFileData(fileNameLocal.AsPtr(), dataLocal, bytesToWrite);
    }

    /// <summary>
    /// Load text data from file (read), returns a ' 0' terminated string
    /// </summary>
    public string LoadFileText(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return (string)Raylib.LoadFileText(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    public void UnloadFileText(string text)
    {
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        Raylib.UnloadFileText(textLocal.AsPtr());
    }

    /// <summary>
    /// Save text data to file (write), string must be ' 0' terminated, returns true on success
    /// </summary>
    public bool SaveFileText(string fileName, string text)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  char * => string  |*/
        using var textLocal = text.MarshalUtf8();
        return Raylib.SaveFileText(fileNameLocal.AsPtr(), textLocal.AsPtr());
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public bool FileExists(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.FileExists(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public bool DirectoryExists(string dirPath)
    {
        /*|  const char * => string  |*/
        using var dirPathLocal = dirPath.MarshalUtf8();
        return Raylib.DirectoryExists(dirPathLocal.AsPtr());
    }

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    public bool IsFileExtension(string fileName, string ext)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        /*|  const char * => string  |*/
        using var extLocal = ext.MarshalUtf8();
        return Raylib.IsFileExtension(fileNameLocal.AsPtr(), extLocal.AsPtr());
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public string GetFileExtension(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileExtension(fileNameLocal.AsPtr()));
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public string GetFileName(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileName(filePathLocal.AsPtr()));
    }

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    public string GetFileNameWithoutExt(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetFileNameWithoutExt(filePathLocal.AsPtr()));
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public string GetDirectoryPath(string filePath)
    {
        /*|  const char * => string  |*/
        using var filePathLocal = filePath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetDirectoryPath(filePathLocal.AsPtr()));
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public string GetPrevDirectoryPath(string dirPath)
    {
        /*|  const char * => string  |*/
        using var dirPathLocal = dirPath.MarshalUtf8();
        return Helpers.Utf8ToString(Raylib.GetPrevDirectoryPath(dirPathLocal.AsPtr()));
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public string GetWorkingDirectory()
    {
        return Helpers.Utf8ToString(Raylib.GetWorkingDirectory());
    }

    /// <summary>
    /// Get filenames in a directory path (memory should be freed)
    /// </summary>
    public string[] GetDirectoryFiles(string dirPath, int* count)
    {
        /*|  const char * => string  |*/
        using var dirPathLocal = dirPath.MarshalUtf8();
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.GetDirectoryFiles(dirPathLocal.AsPtr(), count));
    }

    /// <summary>
    /// Clear directory files paths buffers (free memory)
    /// </summary>
    public void ClearDirectoryFiles()
    {
        Raylib.ClearDirectoryFiles();
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public bool ChangeDirectory(string dir)
    {
        /*|  const char * => string  |*/
        using var dirLocal = dir.MarshalUtf8();
        return Raylib.ChangeDirectory(dirLocal.AsPtr());
    }

    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    public bool IsFileDropped()
    {
        return Raylib.IsFileDropped();
    }

    /// <summary>
    /// Get dropped files names (memory should be freed)
    /// </summary>
    public string[] GetDroppedFiles(int* count)
    {
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.GetDroppedFiles(count));
    }

    /// <summary>
    /// Clear dropped files paths buffer (free memory)
    /// </summary>
    public void ClearDroppedFiles()
    {
        Raylib.ClearDroppedFiles();
    }

    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    public long GetFileModTime(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.GetFileModTime(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Compress data (DEFLATE algorithm)
    /// </summary>
    public byte[] CompressData(byte[] data, int dataLength, int* compDataLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.CompressData(dataLocal, dataLength, compDataLength));
    }

    /// <summary>
    /// Decompress data (DEFLATE algorithm)
    /// </summary>
    public byte[] DecompressData(byte[] compData, int compDataLength, int* dataLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var compDataLocal = Helpers.ArrayToPtr(compData);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.DecompressData(compDataLocal, compDataLength, dataLength));
    }

    /// <summary>
    /// Encode data to Base64 string
    /// </summary>
    public string EncodeDataBase64(byte[] data, int dataLength, int* outputLength)
    {
        /*|  const unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        /*|  int * => int*  |*/
        return (string)Raylib.EncodeDataBase64(dataLocal, dataLength, outputLength);
    }

    /// <summary>
    /// Decode Base64 string data
    /// </summary>
    public byte[] DecodeDataBase64(byte[] data, int* outputLength)
    {
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int * => int*  |*/
        return Helpers.PrtToArray(Raylib.DecodeDataBase64(dataLocal, outputLength));
    }

    /// <summary>
    /// Save integer value to storage file (to defined position), returns true on success
    /// </summary>
    public bool SaveStorageValue(uint position, int value)
    {
        /*|  unsigned int => uint  |*/
        /*|  int => int  |*/
        return Raylib.SaveStorageValue(position, value);
    }

    /// <summary>
    /// Load integer value from storage file (from defined position)
    /// </summary>
    public int LoadStorageValue(uint position)
    {
        /*|  unsigned int => uint  |*/
        return Raylib.LoadStorageValue(position);
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public void OpenURL(string url)
    {
        /*|  const char * => string  |*/
        using var urlLocal = url.MarshalUtf8();
        Raylib.OpenURL(urlLocal.AsPtr());
    }

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    public bool IsKeyPressed(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyPressed(key);
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public bool IsKeyDown(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyDown(key);
    }

    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    public bool IsKeyReleased(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyReleased(key);
    }

    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    public bool IsKeyUp(int key)
    {
        /*|  int => int  |*/
        return Raylib.IsKeyUp(key);
    }

    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    public void SetExitKey(int key)
    {
        /*|  int => int  |*/
        Raylib.SetExitKey(key);
    }

    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    public int GetKeyPressed()
    {
        return Raylib.GetKeyPressed();
    }

    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    public int GetCharPressed()
    {
        return Raylib.GetCharPressed();
    }

    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    public bool IsGamepadAvailable(int gamepad)
    {
        /*|  int => int  |*/
        return Raylib.IsGamepadAvailable(gamepad);
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public string GetGamepadName(int gamepad)
    {
        /*|  int => int  |*/
        return Helpers.Utf8ToString(Raylib.GetGamepadName(gamepad));
    }

    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    public bool IsGamepadButtonPressed(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonPressed(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    public bool IsGamepadButtonDown(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonDown(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    public bool IsGamepadButtonReleased(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonReleased(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    public bool IsGamepadButtonUp(int gamepad, int button)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.IsGamepadButtonUp(gamepad, button);
    }

    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    public int GetGamepadButtonPressed()
    {
        return Raylib.GetGamepadButtonPressed();
    }

    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    public int GetGamepadAxisCount(int gamepad)
    {
        /*|  int => int  |*/
        return Raylib.GetGamepadAxisCount(gamepad);
    }

    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    public float GetGamepadAxisMovement(int gamepad, int axis)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        return Raylib.GetGamepadAxisMovement(gamepad, axis);
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public int SetGamepadMappings(string mappings)
    {
        /*|  const char * => string  |*/
        using var mappingsLocal = mappings.MarshalUtf8();
        return Raylib.SetGamepadMappings(mappingsLocal.AsPtr());
    }

    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    public bool IsMouseButtonPressed(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonPressed(button);
    }

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    public bool IsMouseButtonDown(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonDown(button);
    }

    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    public bool IsMouseButtonReleased(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonReleased(button);
    }

    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    public bool IsMouseButtonUp(int button)
    {
        /*|  int => int  |*/
        return Raylib.IsMouseButtonUp(button);
    }

    /// <summary>
    /// Get mouse position X
    /// </summary>
    public int GetMouseX()
    {
        return Raylib.GetMouseX();
    }

    /// <summary>
    /// Get mouse position Y
    /// </summary>
    public int GetMouseY()
    {
        return Raylib.GetMouseY();
    }

    /// <summary>
    /// Get mouse position XY
    /// </summary>
    public Vector2 GetMousePosition()
    {
        return Raylib.GetMousePosition();
    }

    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    public Vector2 GetMouseDelta()
    {
        return Raylib.GetMouseDelta();
    }

    /// <summary>
    /// Set mouse position XY
    /// </summary>
    public void SetMousePosition(int x, int y)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetMousePosition(x, y);
    }

    /// <summary>
    /// Set mouse offset
    /// </summary>
    public void SetMouseOffset(int offsetX, int offsetY)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetMouseOffset(offsetX, offsetY);
    }

    /// <summary>
    /// Set mouse scaling
    /// </summary>
    public void SetMouseScale(float scaleX, float scaleY)
    {
        /*|  float => float  |*/
        /*|  float => float  |*/
        Raylib.SetMouseScale(scaleX, scaleY);
    }

    /// <summary>
    /// Get mouse wheel movement Y
    /// </summary>
    public float GetMouseWheelMove()
    {
        return Raylib.GetMouseWheelMove();
    }

    /// <summary>
    /// Set mouse cursor
    /// </summary>
    public void SetMouseCursor(int cursor)
    {
        /*|  int => int  |*/
        Raylib.SetMouseCursor(cursor);
    }

    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    public int GetTouchX()
    {
        return Raylib.GetTouchX();
    }

    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    public int GetTouchY()
    {
        return Raylib.GetTouchY();
    }

    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    public Vector2 GetTouchPosition(int index)
    {
        /*|  int => int  |*/
        return Raylib.GetTouchPosition(index);
    }

    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    public int GetTouchPointId(int index)
    {
        /*|  int => int  |*/
        return Raylib.GetTouchPointId(index);
    }

    /// <summary>
    /// Get number of touch points
    /// </summary>
    public int GetTouchPointCount()
    {
        return Raylib.GetTouchPointCount();
    }

    /// <summary>
    /// Enable a set of gestures using flags
    /// </summary>
    public void SetGesturesEnabled(uint flags)
    {
        /*|  unsigned int => uint  |*/
        Raylib.SetGesturesEnabled(flags);
    }

    /// <summary>
    /// Check if a gesture have been detected
    /// </summary>
    public bool IsGestureDetected(int gesture)
    {
        /*|  int => int  |*/
        return Raylib.IsGestureDetected(gesture);
    }

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    public int GetGestureDetected()
    {
        return Raylib.GetGestureDetected();
    }

    /// <summary>
    /// Get gesture hold time in milliseconds
    /// </summary>
    public float GetGestureHoldDuration()
    {
        return Raylib.GetGestureHoldDuration();
    }

    /// <summary>
    /// Get gesture drag vector
    /// </summary>
    public Vector2 GetGestureDragVector()
    {
        return Raylib.GetGestureDragVector();
    }

    /// <summary>
    /// Get gesture drag angle
    /// </summary>
    public float GetGestureDragAngle()
    {
        return Raylib.GetGestureDragAngle();
    }

    /// <summary>
    /// Get gesture pinch delta
    /// </summary>
    public Vector2 GetGesturePinchVector()
    {
        return Raylib.GetGesturePinchVector();
    }

    /// <summary>
    /// Get gesture pinch angle
    /// </summary>
    public float GetGesturePinchAngle()
    {
        return Raylib.GetGesturePinchAngle();
    }

    /// <summary>
    /// Set camera mode (multiple camera modes available)
    /// </summary>
    public void SetCameraMode(Camera camera, int mode)
    {
        /*|  Camera => Camera  |*/
        /*|  int => int  |*/
        Raylib.SetCameraMode(camera, mode);
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public void UpdateCamera(Camera* camera)
    {
        /*|  Camera * => Camera*  |*/
        Raylib.UpdateCamera(camera);
    }

    /// <summary>
    /// Set camera pan key to combine with mouse movement (free camera)
    /// </summary>
    public void SetCameraPanControl(int keyPan)
    {
        /*|  int => int  |*/
        Raylib.SetCameraPanControl(keyPan);
    }

    /// <summary>
    /// Set camera alt key to combine with mouse movement (free camera)
    /// </summary>
    public void SetCameraAltControl(int keyAlt)
    {
        /*|  int => int  |*/
        Raylib.SetCameraAltControl(keyAlt);
    }

    /// <summary>
    /// Set camera smooth zoom key to combine with mouse (free camera)
    /// </summary>
    public void SetCameraSmoothZoomControl(int keySmoothZoom)
    {
        /*|  int => int  |*/
        Raylib.SetCameraSmoothZoomControl(keySmoothZoom);
    }

    /// <summary>
    /// Set camera move controls (1st person and 3rd person cameras)
    /// </summary>
    public void SetCameraMoveControls(int keyFront, int keyBack, int keyRight, int keyLeft, int keyUp, int keyDown)
    {
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.SetCameraMoveControls(keyFront, keyBack, keyRight, keyLeft, keyUp, keyDown);
    }

}
#pragma warning restore
