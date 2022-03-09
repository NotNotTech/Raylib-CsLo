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
        Raylib.InitWindow(width, height, title);
    }

    /// <summary>
    /// Check if KEY_ESCAPE pressed or Close icon pressed
    /// </summary>
    public static bool WindowShouldClose()
    {
        return Raylib.WindowShouldClose();
    }

    /// <summary>
    /// Close window and unload OpenGL context
    /// </summary>
    public static void CloseWindow()
    {
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Check if window has been initialized successfully
    /// </summary>
    public static bool IsWindowReady()
    {
        return Raylib.IsWindowReady();
    }

    /// <summary>
    /// Check if window is currently fullscreen
    /// </summary>
    public static bool IsWindowFullscreen()
    {
        return Raylib.IsWindowFullscreen();
    }

    /// <summary>
    /// Check if window is currently hidden (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowHidden()
    {
        return Raylib.IsWindowHidden();
    }

    /// <summary>
    /// Check if window is currently minimized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMinimized()
    {
        return Raylib.IsWindowMinimized();
    }

    /// <summary>
    /// Check if window is currently maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowMaximized()
    {
        return Raylib.IsWindowMaximized();
    }

    /// <summary>
    /// Check if window is currently focused (only PLATFORM_DESKTOP)
    /// </summary>
    public static bool IsWindowFocused()
    {
        return Raylib.IsWindowFocused();
    }

    /// <summary>
    /// Check if window has been resized last frame
    /// </summary>
    public static bool IsWindowResized()
    {
        return Raylib.IsWindowResized();
    }

    /// <summary>
    /// Check if one specific window flag is enabled
    /// </summary>
    public static bool IsWindowState(uint flag)
    {
        return Raylib.IsWindowState(flag);
    }

    /// <summary>
    /// Set window configuration state using flags (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowState(uint flags)
    {
        Raylib.SetWindowState(flags);
    }

    /// <summary>
    /// Clear window configuration state flags
    /// </summary>
    public static void ClearWindowState(uint flags)
    {
        Raylib.ClearWindowState(flags);
    }

    /// <summary>
    /// Toggle window state: fullscreen/windowed (only PLATFORM_DESKTOP)
    /// </summary>
    public static void ToggleFullscreen()
    {
        Raylib.ToggleFullscreen();
    }

    /// <summary>
    /// Set window state: maximized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MaximizeWindow()
    {
        Raylib.MaximizeWindow();
    }

    /// <summary>
    /// Set window state: minimized, if resizable (only PLATFORM_DESKTOP)
    /// </summary>
    public static void MinimizeWindow()
    {
        Raylib.MinimizeWindow();
    }

    /// <summary>
    /// Set window state: not minimized/maximized (only PLATFORM_DESKTOP)
    /// </summary>
    public static void RestoreWindow()
    {
        Raylib.RestoreWindow();
    }

    /// <summary>
    /// Set icon for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowIcon(Image image)
    {
        Raylib.SetWindowIcon(image);
    }

    /// <summary>
    /// Set title for window (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowTitle(string title)
    {
        Raylib.SetWindowTitle(title);
    }

    /// <summary>
    /// Set window position on screen (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowPosition(int x, int y)
    {
        Raylib.SetWindowPosition(x, y);
    }

    /// <summary>
    /// Set monitor for the current window (fullscreen mode)
    /// </summary>
    public static void SetWindowMonitor(int monitor)
    {
        Raylib.SetWindowMonitor(monitor);
    }

    /// <summary>
    /// Set window minimum dimensions (for FLAG_WINDOW_RESIZABLE)
    /// </summary>
    public static void SetWindowMinSize(int width, int height)
    {
        Raylib.SetWindowMinSize(width, height);
    }

    /// <summary>
    /// Set window dimensions
    /// </summary>
    public static void SetWindowSize(int width, int height)
    {
        Raylib.SetWindowSize(width, height);
    }

    /// <summary>
    /// Set window opacity [0.0f..1.0f] (only PLATFORM_DESKTOP)
    /// </summary>
    public static void SetWindowOpacity(float opacity)
    {
        Raylib.SetWindowOpacity(opacity);
    }

    /// <summary>
    /// Get native window handle
    /// </summary>
    public static IntPtr GetWindowHandle()
    {
        return (IntPtr)Raylib.GetWindowHandle();
    }

    /// <summary>
    /// Get current screen width
    /// </summary>
    public static int GetScreenWidth()
    {
        return Raylib.GetScreenWidth();
    }

    /// <summary>
    /// Get current screen height
    /// </summary>
    public static int GetScreenHeight()
    {
        return Raylib.GetScreenHeight();
    }

    /// <summary>
    /// Get current render width (it considers HiDPI)
    /// </summary>
    public static int GetRenderWidth()
    {
        return Raylib.GetRenderWidth();
    }

    /// <summary>
    /// Get current render height (it considers HiDPI)
    /// </summary>
    public static int GetRenderHeight()
    {
        return Raylib.GetRenderHeight();
    }

    /// <summary>
    /// Get number of connected monitors
    /// </summary>
    public static int GetMonitorCount()
    {
        return Raylib.GetMonitorCount();
    }

    /// <summary>
    /// Get current connected monitor
    /// </summary>
    public static int GetCurrentMonitor()
    {
        return Raylib.GetCurrentMonitor();
    }

    /// <summary>
    /// Get specified monitor position
    /// </summary>
    public static Vector2 GetMonitorPosition(int monitor)
    {
        return Raylib.GetMonitorPosition(monitor);
    }

    /// <summary>
    /// Get specified monitor width (max available by monitor)
    /// </summary>
    public static int GetMonitorWidth(int monitor)
    {
        return Raylib.GetMonitorWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor height (max available by monitor)
    /// </summary>
    public static int GetMonitorHeight(int monitor)
    {
        return Raylib.GetMonitorHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor physical width in millimetres
    /// </summary>
    public static int GetMonitorPhysicalWidth(int monitor)
    {
        return Raylib.GetMonitorPhysicalWidth(monitor);
    }

    /// <summary>
    /// Get specified monitor physical height in millimetres
    /// </summary>
    public static int GetMonitorPhysicalHeight(int monitor)
    {
        return Raylib.GetMonitorPhysicalHeight(monitor);
    }

    /// <summary>
    /// Get specified monitor refresh rate
    /// </summary>
    public static int GetMonitorRefreshRate(int monitor)
    {
        return Raylib.GetMonitorRefreshRate(monitor);
    }

    /// <summary>
    /// Get window position XY on monitor
    /// </summary>
    public static Vector2 GetWindowPosition()
    {
        return Raylib.GetWindowPosition();
    }

    /// <summary>
    /// Get window scale DPI factor
    /// </summary>
    public static Vector2 GetWindowScaleDPI()
    {
        return Raylib.GetWindowScaleDPI();
    }

    /// <summary>
    /// Get the human-readable, UTF-8 encoded name of the primary monitor
    /// </summary>
    public static string GetMonitorName(int monitor)
    {
        return Helpers.Utf8ToString(Raylib.GetMonitorName(monitor));
    }

    /// <summary>
    /// Set clipboard text content
    /// </summary>
    public static void SetClipboardText(string text)
    {
        Raylib.SetClipboardText(text);
    }

    /// <summary>
    /// Get clipboard text content
    /// </summary>
    public static string GetClipboardText()
    {
        return Helpers.Utf8ToString(Raylib.GetClipboardText());
    }

    /// <summary>
    /// Swap back buffer with front buffer (screen drawing)
    /// </summary>
    public static void SwapScreenBuffer()
    {
        Raylib.SwapScreenBuffer();
    }

    /// <summary>
    /// Register all input events
    /// </summary>
    public static void PollInputEvents()
    {
        Raylib.PollInputEvents();
    }

    /// <summary>
    /// Wait for some milliseconds (halt program execution)
    /// </summary>
    public static void WaitTime(float ms)
    {
        Raylib.WaitTime(ms);
    }

    /// <summary>
    /// Shows cursor
    /// </summary>
    public static void ShowCursor()
    {
        Raylib.ShowCursor();
    }

    /// <summary>
    /// Hides cursor
    /// </summary>
    public static void HideCursor()
    {
        Raylib.HideCursor();
    }

    /// <summary>
    /// Check if cursor is not visible
    /// </summary>
    public static bool IsCursorHidden()
    {
        return Raylib.IsCursorHidden();
    }

    /// <summary>
    /// Enables cursor (unlock cursor)
    /// </summary>
    public static void EnableCursor()
    {
        Raylib.EnableCursor();
    }

    /// <summary>
    /// Disables cursor (lock cursor)
    /// </summary>
    public static void DisableCursor()
    {
        Raylib.DisableCursor();
    }

    /// <summary>
    /// Check if cursor is on the screen
    /// </summary>
    public static bool IsCursorOnScreen()
    {
        return Raylib.IsCursorOnScreen();
    }

    /// <summary>
    /// Set background color (framebuffer clear color)
    /// </summary>
    public static void ClearBackground(Color color)
    {
        Raylib.ClearBackground(color);
    }

    /// <summary>
    /// Setup canvas (framebuffer) to start drawing
    /// </summary>
    public static void BeginDrawing()
    {
        Raylib.BeginDrawing();
    }

    /// <summary>
    /// End canvas drawing and swap buffers (double buffering)
    /// </summary>
    public static void EndDrawing()
    {
        Raylib.EndDrawing();
    }

    /// <summary>
    /// Begin 2D mode with custom camera (2D)
    /// </summary>
    public static void BeginMode2D(Camera2D camera)
    {
        Raylib.BeginMode2D(camera);
    }

    /// <summary>
    /// Ends 2D mode with custom camera
    /// </summary>
    public static void EndMode2D()
    {
        Raylib.EndMode2D();
    }

    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public static void BeginMode3D(Camera3D camera)
    {
        Raylib.BeginMode3D(camera);
    }

    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public static void EndMode3D()
    {
        Raylib.EndMode3D();
    }

    /// <summary>
    /// Begin drawing to render texture
    /// </summary>
    public static void BeginTextureMode(RenderTexture2D target)
    {
        Raylib.BeginTextureMode(target);
    }

    /// <summary>
    /// Ends drawing to render texture
    /// </summary>
    public static void EndTextureMode()
    {
        Raylib.EndTextureMode();
    }

    /// <summary>
    /// Begin custom shader drawing
    /// </summary>
    public static void BeginShaderMode(Shader shader)
    {
        Raylib.BeginShaderMode(shader);
    }

    /// <summary>
    /// End custom shader drawing (use default shader)
    /// </summary>
    public static void EndShaderMode()
    {
        Raylib.EndShaderMode();
    }

    /// <summary>
    /// Begin blending mode (alpha, additive, multiplied, subtract, custom)
    /// </summary>
    public static void BeginBlendMode(int mode)
    {
        Raylib.BeginBlendMode(mode);
    }

    /// <summary>
    /// End blending mode (reset to default: alpha blending)
    /// </summary>
    public static void EndBlendMode()
    {
        Raylib.EndBlendMode();
    }

    /// <summary>
    /// Begin scissor mode (define screen area for following drawing)
    /// </summary>
    public static void BeginScissorMode(int x, int y, int width, int height)
    {
        Raylib.BeginScissorMode(x, y, width, height);
    }

    /// <summary>
    /// End scissor mode
    /// </summary>
    public static void EndScissorMode()
    {
        Raylib.EndScissorMode();
    }

    /// <summary>
    /// Begin stereo rendering (requires VR simulator)
    /// </summary>
    public static void BeginVrStereoMode(VrStereoConfig config)
    {
        Raylib.BeginVrStereoMode(config);
    }

    /// <summary>
    /// End stereo rendering (requires VR simulator)
    /// </summary>
    public static void EndVrStereoMode()
    {
        Raylib.EndVrStereoMode();
    }

    /// <summary>
    /// Load VR stereo config for VR simulator device parameters
    /// </summary>
    public static VrStereoConfig LoadVrStereoConfig(VrDeviceInfo device)
    {
        return Raylib.LoadVrStereoConfig(device);
    }

    /// <summary>
    /// Unload VR stereo config
    /// </summary>
    public static void UnloadVrStereoConfig(VrStereoConfig config)
    {
        Raylib.UnloadVrStereoConfig(config);
    }

    /// <summary>
    /// Load shader from files and bind default locations
    /// </summary>
    public static Shader LoadShader(string vsFileName, string fsFileName)
    {
        return Raylib.LoadShader(vsFileName, fsFileName);
    }

    /// <summary>
    /// Load shader from code strings and bind default locations
    /// </summary>
    public static Shader LoadShaderFromMemory(string vsCode, string fsCode)
    {
        return Raylib.LoadShaderFromMemory(vsCode, fsCode);
    }

    /// <summary>
    /// Get shader uniform location
    /// </summary>
    public static int GetShaderLocation(Shader shader, string uniformName)
    {
        return Raylib.GetShaderLocation(shader, uniformName);
    }

    /// <summary>
    /// Get shader attribute location
    /// </summary>
    public static int GetShaderLocationAttrib(Shader shader, string attribName)
    {
        return Raylib.GetShaderLocationAttrib(shader, attribName);
    }

    /// <summary>
    /// Set shader uniform value
    /// </summary>
    public static void SetShaderValue(Shader shader, int locIndex, IntPtr value, int uniformType)
    {
        var valueLocal = (void*)value;
        Raylib.SetShaderValue(shader, locIndex, valueLocal, uniformType);
    }

    /// <summary>
    /// Set shader uniform value vector
    /// </summary>
    public static void SetShaderValueV(Shader shader, int locIndex, IntPtr value, int uniformType, int count)
    {
        var valueLocal = (void*)value;
        Raylib.SetShaderValueV(shader, locIndex, valueLocal, uniformType, count);
    }

    /// <summary>
    /// Set shader uniform value (matrix 4x4)
    /// </summary>
    public static void SetShaderValueMatrix(Shader shader, int locIndex, Matrix mat)
    {
        Raylib.SetShaderValueMatrix(shader, locIndex, mat);
    }

    /// <summary>
    /// Set shader uniform value for texture (sampler2d)
    /// </summary>
    public static void SetShaderValueTexture(Shader shader, int locIndex, Texture2D texture)
    {
        Raylib.SetShaderValueTexture(shader, locIndex, texture);
    }

    /// <summary>
    /// Unload shader from GPU memory (VRAM)
    /// </summary>
    public static void UnloadShader(Shader shader)
    {
        Raylib.UnloadShader(shader);
    }

    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public static Ray GetMouseRay(Vector2 mousePosition, Camera camera)
    {
        return Raylib.GetMouseRay(mousePosition, camera);
    }

    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public static Matrix GetCameraMatrix(Camera camera)
    {
        return Raylib.GetCameraMatrix(camera);
    }

    /// <summary>
    /// Get camera 2d transform matrix
    /// </summary>
    public static Matrix GetCameraMatrix2D(Camera2D camera)
    {
        return Raylib.GetCameraMatrix2D(camera);
    }

    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(Vector3 position, Camera camera)
    {
        return Raylib.GetWorldToScreen(position, camera);
    }

    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreenEx(Vector3 position, Camera camera, int width, int height)
    {
        return Raylib.GetWorldToScreenEx(position, camera, width, height);
    }

    /// <summary>
    /// Get the screen space position for a 2d camera world space position
    /// </summary>
    public static Vector2 GetWorldToScreen2D(Vector2 position, Camera2D camera)
    {
        return Raylib.GetWorldToScreen2D(position, camera);
    }

    /// <summary>
    /// Get the world space position for a 2d camera screen space position
    /// </summary>
    public static Vector2 GetScreenToWorld2D(Vector2 position, Camera2D camera)
    {
        return Raylib.GetScreenToWorld2D(position, camera);
    }

    /// <summary>
    /// Set target FPS (maximum)
    /// </summary>
    public static void SetTargetFPS(int fps)
    {
        Raylib.SetTargetFPS(fps);
    }

    /// <summary>
    /// Get current FPS
    /// </summary>
    public static int GetFPS()
    {
        return Raylib.GetFPS();
    }

    /// <summary>
    /// Get time in seconds for last frame drawn (delta time)
    /// </summary>
    public static float GetFrameTime()
    {
        return Raylib.GetFrameTime();
    }

    /// <summary>
    /// Get elapsed time in seconds since InitWindow()
    /// </summary>
    public static double GetTime()
    {
        return Raylib.GetTime();
    }

    /// <summary>
    /// Get a random value between min and max (both included)
    /// </summary>
    public static int GetRandomValue(int min, int max)
    {
        return Raylib.GetRandomValue(min, max);
    }

    /// <summary>
    /// Set the seed for the random number generator
    /// </summary>
    public static void SetRandomSeed(uint seed)
    {
        Raylib.SetRandomSeed(seed);
    }

    /// <summary>
    /// Takes a screenshot of current screen (filename extension defines format)
    /// </summary>
    public static void TakeScreenshot(string fileName)
    {
        Raylib.TakeScreenshot(fileName);
    }

    /// <summary>
    /// Setup init configuration flags (view FLAGS)
    /// </summary>
    public static void SetConfigFlags(uint flags)
    {
        Raylib.SetConfigFlags(flags);
    }

    /// <summary>
    /// Set the current threshold (minimum) log level
    /// </summary>
    public static void SetTraceLogLevel(int logLevel)
    {
        Raylib.SetTraceLogLevel(logLevel);
    }

    /// <summary>
    /// Internal memory allocator
    /// </summary>
    public static IntPtr MemAlloc(int size)
    {
        return (IntPtr)Raylib.MemAlloc(size);
    }

    /// <summary>
    /// Internal memory reallocator
    /// </summary>
    public static IntPtr MemRealloc(IntPtr ptr, int size)
    {
        var ptrLocal = (void*)ptr;
        return (IntPtr)Raylib.MemRealloc(ptrLocal, size);
    }

    /// <summary>
    /// Internal memory free
    /// </summary>
    public static void MemFree(IntPtr ptr)
    {
        var ptrLocal = (void*)ptr;
        Raylib.MemFree(ptrLocal);
    }

    /// <summary>
    /// Unload file data allocated by LoadFileData()
    /// </summary>
    public static void UnloadFileData(byte[] data)
    {
        var dataLocal = Helpers.ArrayToPtr(data);
        Raylib.UnloadFileData(dataLocal);
    }

    /// <summary>
    /// Save data to file from byte array (write), returns true on success
    /// </summary>
    public static bool SaveFileData(string fileName, IntPtr data, uint bytesToWrite)
    {
        var dataLocal = (void*)data;
        return Raylib.SaveFileData(fileName, dataLocal, bytesToWrite);
    }

    /// <summary>
    /// Load text data from file (read), returns a '\0' terminated string
    /// </summary>
    public static string LoadFileText(string fileName)
    {
        return Helpers.Utf8ToString(Raylib.LoadFileText(fileName));
    }

    /// <summary>
    /// Unload file text data allocated by LoadFileText()
    /// </summary>
    public static void UnloadFileText(string text)
    {
        Raylib.UnloadFileText(text);
    }

    /// <summary>
    /// Save text data to file (write), string must be '\0' terminated, returns true on success
    /// </summary>
    public static bool SaveFileText(string fileName, string text)
    {
        return Raylib.SaveFileText(fileName, text);
    }

    /// <summary>
    /// Check if file exists
    /// </summary>
    public static bool FileExists(string fileName)
    {
        return Raylib.FileExists(fileName);
    }

    /// <summary>
    /// Check if a directory path exists
    /// </summary>
    public static bool DirectoryExists(string dirPath)
    {
        return Raylib.DirectoryExists(dirPath);
    }

    /// <summary>
    /// Check file extension (including point: .png, .wav)
    /// </summary>
    public static bool IsFileExtension(string fileName, string ext)
    {
        return Raylib.IsFileExtension(fileName, ext);
    }

    /// <summary>
    /// Get file length in bytes (NOTE: GetFileSize() conflicts with windows.h)
    /// </summary>
    public static int GetFileLength(string fileName)
    {
        return Raylib.GetFileLength(fileName);
    }

    /// <summary>
    /// Get pointer to extension for a filename string (includes dot: '.png')
    /// </summary>
    public static string GetFileExtension(string fileName)
    {
        return Helpers.Utf8ToString(Raylib.GetFileExtension(fileName));
    }

    /// <summary>
    /// Get pointer to filename for a path string
    /// </summary>
    public static string GetFileName(string filePath)
    {
        return Helpers.Utf8ToString(Raylib.GetFileName(filePath));
    }

    /// <summary>
    /// Get filename string without extension (uses static string)
    /// </summary>
    public static string GetFileNameWithoutExt(string filePath)
    {
        return Helpers.Utf8ToString(Raylib.GetFileNameWithoutExt(filePath));
    }

    /// <summary>
    /// Get full path for a given fileName with path (uses static string)
    /// </summary>
    public static string GetDirectoryPath(string filePath)
    {
        return Helpers.Utf8ToString(Raylib.GetDirectoryPath(filePath));
    }

    /// <summary>
    /// Get previous directory path for a given path (uses static string)
    /// </summary>
    public static string GetPrevDirectoryPath(string dirPath)
    {
        return Helpers.Utf8ToString(Raylib.GetPrevDirectoryPath(dirPath));
    }

    /// <summary>
    /// Get current working directory (uses static string)
    /// </summary>
    public static string GetWorkingDirectory()
    {
        return Helpers.Utf8ToString(Raylib.GetWorkingDirectory());
    }

    /// <summary>
    /// Get the directory if the running application (uses static string)
    /// </summary>
    public static string GetApplicationDirectory()
    {
        return Helpers.Utf8ToString(Raylib.GetApplicationDirectory());
    }

    /// <summary>
    /// Clear directory files paths buffers (free memory)
    /// </summary>
    public static void ClearDirectoryFiles()
    {
        Raylib.ClearDirectoryFiles();
    }

    /// <summary>
    /// Change working directory, return true on success
    /// </summary>
    public static bool ChangeDirectory(string dir)
    {
        return Raylib.ChangeDirectory(dir);
    }

    /// <summary>
    /// Check if a file has been dropped into window
    /// </summary>
    public static bool IsFileDropped()
    {
        return Raylib.IsFileDropped();
    }

    /// <summary>
    /// Clear dropped files paths buffer (free memory)
    /// </summary>
    public static void ClearDroppedFiles()
    {
        Raylib.ClearDroppedFiles();
    }

    /// <summary>
    /// Get file modification time (last write time)
    /// </summary>
    public static long GetFileModTime(string fileName)
    {
        return Raylib.GetFileModTime(fileName);
    }

    /// <summary>
    /// Compress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] CompressData(byte[] data, int dataLength, int* compDataLength)
    {
        var dataLocal = Helpers.ArrayToPtr(data);
        return Helpers.PrtToArray(Raylib.CompressData(dataLocal, dataLength, compDataLength));
    }

    /// <summary>
    /// Decompress data (DEFLATE algorithm)
    /// </summary>
    public static byte[] DecompressData(byte[] compData, int compDataLength, int* dataLength)
    {
        var compDataLocal = Helpers.ArrayToPtr(compData);
        return Helpers.PrtToArray(Raylib.DecompressData(compDataLocal, compDataLength, dataLength));
    }

    /// <summary>
    /// Encode data to Base64 string
    /// </summary>
    public static string EncodeDataBase64(byte[] data, int dataLength, int* outputLength)
    {
        var dataLocal = Helpers.ArrayToPtr(data);
        return Helpers.Utf8ToString(Raylib.EncodeDataBase64(dataLocal, dataLength, outputLength));
    }

    /// <summary>
    /// Decode Base64 string data
    /// </summary>
    public static byte[] DecodeDataBase64(byte[] data, int* outputLength)
    {
        var dataLocal = Helpers.ArrayToPtr(data);
        return Helpers.PrtToArray(Raylib.DecodeDataBase64(dataLocal, outputLength));
    }

    /// <summary>
    /// Save integer value to storage file (to defined position), returns true on success
    /// </summary>
    public static bool SaveStorageValue(uint position, int value)
    {
        return Raylib.SaveStorageValue(position, value);
    }

    /// <summary>
    /// Load integer value from storage file (from defined position)
    /// </summary>
    public static int LoadStorageValue(uint position)
    {
        return Raylib.LoadStorageValue(position);
    }

    /// <summary>
    /// Open URL with default system browser (if available)
    /// </summary>
    public static void OpenURL(string url)
    {
        Raylib.OpenURL(url);
    }

    /// <summary>
    /// Check if a key has been pressed once
    /// </summary>
    public static bool IsKeyPressed(int key)
    {
        return Raylib.IsKeyPressed(key);
    }

    /// <summary>
    /// Check if a key is being pressed
    /// </summary>
    public static bool IsKeyDown(int key)
    {
        return Raylib.IsKeyDown(key);
    }

    /// <summary>
    /// Check if a key has been released once
    /// </summary>
    public static bool IsKeyReleased(int key)
    {
        return Raylib.IsKeyReleased(key);
    }

    /// <summary>
    /// Check if a key is NOT being pressed
    /// </summary>
    public static bool IsKeyUp(int key)
    {
        return Raylib.IsKeyUp(key);
    }

    /// <summary>
    /// Set a custom key to exit program (default is ESC)
    /// </summary>
    public static void SetExitKey(int key)
    {
        Raylib.SetExitKey(key);
    }

    /// <summary>
    /// Get key pressed (keycode), call it multiple times for keys queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetKeyPressed()
    {
        return Raylib.GetKeyPressed();
    }

    /// <summary>
    /// Get char pressed (unicode), call it multiple times for chars queued, returns 0 when the queue is empty
    /// </summary>
    public static int GetCharPressed()
    {
        return Raylib.GetCharPressed();
    }

    /// <summary>
    /// Check if a gamepad is available
    /// </summary>
    public static bool IsGamepadAvailable(int gamepad)
    {
        return Raylib.IsGamepadAvailable(gamepad);
    }

    /// <summary>
    /// Get gamepad internal name id
    /// </summary>
    public static string GetGamepadName(int gamepad)
    {
        return Helpers.Utf8ToString(Raylib.GetGamepadName(gamepad));
    }

    /// <summary>
    /// Check if a gamepad button has been pressed once
    /// </summary>
    public static bool IsGamepadButtonPressed(int gamepad, int button)
    {
        return Raylib.IsGamepadButtonPressed(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is being pressed
    /// </summary>
    public static bool IsGamepadButtonDown(int gamepad, int button)
    {
        return Raylib.IsGamepadButtonDown(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button has been released once
    /// </summary>
    public static bool IsGamepadButtonReleased(int gamepad, int button)
    {
        return Raylib.IsGamepadButtonReleased(gamepad, button);
    }

    /// <summary>
    /// Check if a gamepad button is NOT being pressed
    /// </summary>
    public static bool IsGamepadButtonUp(int gamepad, int button)
    {
        return Raylib.IsGamepadButtonUp(gamepad, button);
    }

    /// <summary>
    /// Get the last gamepad button pressed
    /// </summary>
    public static int GetGamepadButtonPressed()
    {
        return Raylib.GetGamepadButtonPressed();
    }

    /// <summary>
    /// Get gamepad axis count for a gamepad
    /// </summary>
    public static int GetGamepadAxisCount(int gamepad)
    {
        return Raylib.GetGamepadAxisCount(gamepad);
    }

    /// <summary>
    /// Get axis movement value for a gamepad axis
    /// </summary>
    public static float GetGamepadAxisMovement(int gamepad, int axis)
    {
        return Raylib.GetGamepadAxisMovement(gamepad, axis);
    }

    /// <summary>
    /// Set internal gamepad mappings (SDL_GameControllerDB)
    /// </summary>
    public static int SetGamepadMappings(string mappings)
    {
        return Raylib.SetGamepadMappings(mappings);
    }

    /// <summary>
    /// Check if a mouse button has been pressed once
    /// </summary>
    public static bool IsMouseButtonPressed(int button)
    {
        return Raylib.IsMouseButtonPressed(button);
    }

    /// <summary>
    /// Check if a mouse button is being pressed
    /// </summary>
    public static bool IsMouseButtonDown(int button)
    {
        return Raylib.IsMouseButtonDown(button);
    }

    /// <summary>
    /// Check if a mouse button has been released once
    /// </summary>
    public static bool IsMouseButtonReleased(int button)
    {
        return Raylib.IsMouseButtonReleased(button);
    }

    /// <summary>
    /// Check if a mouse button is NOT being pressed
    /// </summary>
    public static bool IsMouseButtonUp(int button)
    {
        return Raylib.IsMouseButtonUp(button);
    }

    /// <summary>
    /// Get mouse position X
    /// </summary>
    public static int GetMouseX()
    {
        return Raylib.GetMouseX();
    }

    /// <summary>
    /// Get mouse position Y
    /// </summary>
    public static int GetMouseY()
    {
        return Raylib.GetMouseY();
    }

    /// <summary>
    /// Get mouse position XY
    /// </summary>
    public static Vector2 GetMousePosition()
    {
        return Raylib.GetMousePosition();
    }

    /// <summary>
    /// Get mouse delta between frames
    /// </summary>
    public static Vector2 GetMouseDelta()
    {
        return Raylib.GetMouseDelta();
    }

    /// <summary>
    /// Set mouse position XY
    /// </summary>
    public static void SetMousePosition(int x, int y)
    {
        Raylib.SetMousePosition(x, y);
    }

    /// <summary>
    /// Set mouse offset
    /// </summary>
    public static void SetMouseOffset(int offsetX, int offsetY)
    {
        Raylib.SetMouseOffset(offsetX, offsetY);
    }

    /// <summary>
    /// Set mouse scaling
    /// </summary>
    public static void SetMouseScale(float scaleX, float scaleY)
    {
        Raylib.SetMouseScale(scaleX, scaleY);
    }

    /// <summary>
    /// Get mouse wheel movement Y
    /// </summary>
    public static float GetMouseWheelMove()
    {
        return Raylib.GetMouseWheelMove();
    }

    /// <summary>
    /// Set mouse cursor
    /// </summary>
    public static void SetMouseCursor(int cursor)
    {
        Raylib.SetMouseCursor(cursor);
    }

    /// <summary>
    /// Get touch position X for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchX()
    {
        return Raylib.GetTouchX();
    }

    /// <summary>
    /// Get touch position Y for touch point 0 (relative to screen size)
    /// </summary>
    public static int GetTouchY()
    {
        return Raylib.GetTouchY();
    }

    /// <summary>
    /// Get touch position XY for a touch point index (relative to screen size)
    /// </summary>
    public static Vector2 GetTouchPosition(int index)
    {
        return Raylib.GetTouchPosition(index);
    }

    /// <summary>
    /// Get touch point identifier for given index
    /// </summary>
    public static int GetTouchPointId(int index)
    {
        return Raylib.GetTouchPointId(index);
    }

    /// <summary>
    /// Get number of touch points
    /// </summary>
    public static int GetTouchPointCount()
    {
        return Raylib.GetTouchPointCount();
    }

    /// <summary>
    /// Enable a set of gestures using flags
    /// </summary>
    public static void SetGesturesEnabled(uint flags)
    {
        Raylib.SetGesturesEnabled(flags);
    }

    /// <summary>
    /// Check if a gesture have been detected
    /// </summary>
    public static bool IsGestureDetected(int gesture)
    {
        return Raylib.IsGestureDetected(gesture);
    }

    /// <summary>
    /// Get latest detected gesture
    /// </summary>
    public static int GetGestureDetected()
    {
        return Raylib.GetGestureDetected();
    }

    /// <summary>
    /// Get gesture hold time in milliseconds
    /// </summary>
    public static float GetGestureHoldDuration()
    {
        return Raylib.GetGestureHoldDuration();
    }

    /// <summary>
    /// Get gesture drag vector
    /// </summary>
    public static Vector2 GetGestureDragVector()
    {
        return Raylib.GetGestureDragVector();
    }

    /// <summary>
    /// Get gesture drag angle
    /// </summary>
    public static float GetGestureDragAngle()
    {
        return Raylib.GetGestureDragAngle();
    }

    /// <summary>
    /// Get gesture pinch delta
    /// </summary>
    public static Vector2 GetGesturePinchVector()
    {
        return Raylib.GetGesturePinchVector();
    }

    /// <summary>
    /// Get gesture pinch angle
    /// </summary>
    public static float GetGesturePinchAngle()
    {
        return Raylib.GetGesturePinchAngle();
    }

    /// <summary>
    /// Set camera mode (multiple camera modes available)
    /// </summary>
    public static void SetCameraMode(Camera camera, int mode)
    {
        Raylib.SetCameraMode(camera, mode);
    }

    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void UpdateCamera(Camera* camera)
    {
        var cameraLocal = Helpers.ArrayToPtr(camera);
        Raylib.UpdateCamera(&cameraLocal);
    }

    /// <summary>
    /// Set camera pan key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraPanControl(int keyPan)
    {
        Raylib.SetCameraPanControl(keyPan);
    }

    /// <summary>
    /// Set camera alt key to combine with mouse movement (free camera)
    /// </summary>
    public static void SetCameraAltControl(int keyAlt)
    {
        Raylib.SetCameraAltControl(keyAlt);
    }

    /// <summary>
    /// Set camera smooth zoom key to combine with mouse (free camera)
    /// </summary>
    public static void SetCameraSmoothZoomControl(int keySmoothZoom)
    {
        Raylib.SetCameraSmoothZoomControl(keySmoothZoom);
    }

    /// <summary>
    /// Set camera move controls (1st person and 3rd person cameras)
    /// </summary>
    public static void SetCameraMoveControls(int keyFront, int keyBack, int keyRight, int keyLeft, int keyUp, int keyDown)
    {
        Raylib.SetCameraMoveControls(keyFront, keyBack, keyRight, keyLeft, keyUp, keyDown);
    }

    /// <summary>
    /// Set texture and rectangle to be used on shapes drawing
    /// </summary>
    public static void SetShapesTexture(Texture2D texture, Rectangle source)
    {
        Raylib.SetShapesTexture(texture, source);
    }

    /// <summary>
    /// Draw a pixel
    /// </summary>
    public static void DrawPixel(int posX, int posY, Color color)
    {
        Raylib.DrawPixel(posX, posY, color);
    }

    /// <summary>
    /// Draw a pixel (Vector version)
    /// </summary>
    public static void DrawPixelV(Vector2 position, Color color)
    {
        Raylib.DrawPixelV(position, color);
    }

    /// <summary>
    /// Draw a line
    /// </summary>
    public static void DrawLine(int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        Raylib.DrawLine(startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw a line (Vector version)
    /// </summary>
    public static void DrawLineV(Vector2 startPos, Vector2 endPos, Color color)
    {
        Raylib.DrawLineV(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a line defining thickness
    /// </summary>
    public static void DrawLineEx(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineEx(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw a line using cubic-bezier curves in-out
    /// </summary>
    public static void DrawLineBezier(Vector2 startPos, Vector2 endPos, float thick, Color color)
    {
        Raylib.DrawLineBezier(startPos, endPos, thick, color);
    }

    /// <summary>
    /// Draw line using quadratic bezier curves with a control point
    /// </summary>
    public static void DrawLineBezierQuad(Vector2 startPos, Vector2 endPos, Vector2 controlPos, float thick, Color color)
    {
        Raylib.DrawLineBezierQuad(startPos, endPos, controlPos, thick, color);
    }

    /// <summary>
    /// Draw line using cubic bezier curves with 2 control points
    /// </summary>
    public static void DrawLineBezierCubic(Vector2 startPos, Vector2 endPos, Vector2 startControlPos, Vector2 endControlPos, float thick, Color color)
    {
        Raylib.DrawLineBezierCubic(startPos, endPos, startControlPos, endControlPos, thick, color);
    }

    /// <summary>
    /// Draw lines sequence
    /// </summary>
    public static void DrawLineStrip(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawLineStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a color-filled circle
    /// </summary>
    public static void DrawCircle(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircle(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw a piece of a circle
    /// </summary>
    public static void DrawCircleSector(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSector(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw circle sector outline
    /// </summary>
    public static void DrawCircleSectorLines(Vector2 center, float radius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawCircleSectorLines(center, radius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a gradient-filled circle
    /// </summary>
    public static void DrawCircleGradient(int centerX, int centerY, float radius, Color color1, Color color2)
    {
        Raylib.DrawCircleGradient(centerX, centerY, radius, color1, color2);
    }

    /// <summary>
    /// Draw a color-filled circle (Vector version)
    /// </summary>
    public static void DrawCircleV(Vector2 center, float radius, Color color)
    {
        Raylib.DrawCircleV(center, radius, color);
    }

    /// <summary>
    /// Draw circle outline
    /// </summary>
    public static void DrawCircleLines(int centerX, int centerY, float radius, Color color)
    {
        Raylib.DrawCircleLines(centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw ellipse
    /// </summary>
    public static void DrawEllipse(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipse(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ellipse outline
    /// </summary>
    public static void DrawEllipseLines(int centerX, int centerY, float radiusH, float radiusV, Color color)
    {
        Raylib.DrawEllipseLines(centerX, centerY, radiusH, radiusV, color);
    }

    /// <summary>
    /// Draw ring
    /// </summary>
    public static void DrawRing(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw ring outline
    /// </summary>
    public static void DrawRingLines(Vector2 center, float innerRadius, float outerRadius, float startAngle, float endAngle, int segments, Color color)
    {
        Raylib.DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangle(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangle(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle (Vector version)
    /// </summary>
    public static void DrawRectangleV(Vector2 position, Vector2 size, Color color)
    {
        Raylib.DrawRectangleV(position, size, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle
    /// </summary>
    public static void DrawRectangleRec(Rectangle rec, Color color)
    {
        Raylib.DrawRectangleRec(rec, color);
    }

    /// <summary>
    /// Draw a color-filled rectangle with pro parameters
    /// </summary>
    public static void DrawRectanglePro(Rectangle rec, Vector2 origin, float rotation, Color color)
    {
        Raylib.DrawRectanglePro(rec, origin, rotation, color);
    }

    /// <summary>
    /// Draw a vertical-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientV(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientV(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a horizontal-gradient-filled rectangle
    /// </summary>
    public static void DrawRectangleGradientH(int posX, int posY, int width, int height, Color color1, Color color2)
    {
        Raylib.DrawRectangleGradientH(posX, posY, width, height, color1, color2);
    }

    /// <summary>
    /// Draw a gradient-filled rectangle with custom vertex colors
    /// </summary>
    public static void DrawRectangleGradientEx(Rectangle rec, Color col1, Color col2, Color col3, Color col4)
    {
        Raylib.DrawRectangleGradientEx(rec, col1, col2, col3, col4);
    }

    /// <summary>
    /// Draw rectangle outline
    /// </summary>
    public static void DrawRectangleLines(int posX, int posY, int width, int height, Color color)
    {
        Raylib.DrawRectangleLines(posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle outline with extended parameters
    /// </summary>
    public static void DrawRectangleLinesEx(Rectangle rec, float lineThick, Color color)
    {
        Raylib.DrawRectangleLinesEx(rec, lineThick, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges
    /// </summary>
    public static void DrawRectangleRounded(Rectangle rec, float roundness, int segments, Color color)
    {
        Raylib.DrawRectangleRounded(rec, roundness, segments, color);
    }

    /// <summary>
    /// Draw rectangle with rounded edges outline
    /// </summary>
    public static void DrawRectangleRoundedLines(Rectangle rec, float roundness, int segments, float lineThick, Color color)
    {
        Raylib.DrawRectangleRoundedLines(rec, roundness, segments, lineThick, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangle(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw triangle outline (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangleLines(Vector2 v1, Vector2 v2, Vector2 v3, Color color)
    {
        Raylib.DrawTriangleLines(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle fan defined by points (first vertex is the center)
    /// </summary>
    public static void DrawTriangleFan(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawTriangleFan(points, pointCount, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip(Vector2* points, int pointCount, Color color)
    {
        Raylib.DrawTriangleStrip(points, pointCount, color);
    }

    /// <summary>
    /// Draw a regular polygon (Vector version)
    /// </summary>
    public static void DrawPoly(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPoly(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides
    /// </summary>
    public static void DrawPolyLines(Vector2 center, int sides, float radius, float rotation, Color color)
    {
        Raylib.DrawPolyLines(center, sides, radius, rotation, color);
    }

    /// <summary>
    /// Draw a polygon outline of n sides with extended parameters
    /// </summary>
    public static void DrawPolyLinesEx(Vector2 center, int sides, float radius, float rotation, float lineThick, Color color)
    {
        Raylib.DrawPolyLinesEx(center, sides, radius, rotation, lineThick, color);
    }

    /// <summary>
    /// Check collision between two rectangles
    /// </summary>
    public static bool CheckCollisionRecs(Rectangle rec1, Rectangle rec2)
    {
        return Raylib.CheckCollisionRecs(rec1, rec2);
    }

    /// <summary>
    /// Check collision between two circles
    /// </summary>
    public static bool CheckCollisionCircles(Vector2 center1, float radius1, Vector2 center2, float radius2)
    {
        return Raylib.CheckCollisionCircles(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between circle and rectangle
    /// </summary>
    public static bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec)
    {
        return Raylib.CheckCollisionCircleRec(center, radius, rec);
    }

    /// <summary>
    /// Check if point is inside rectangle
    /// </summary>
    public static bool CheckCollisionPointRec(Vector2 point, Rectangle rec)
    {
        return Raylib.CheckCollisionPointRec(point, rec);
    }

    /// <summary>
    /// Check if point is inside circle
    /// </summary>
    public static bool CheckCollisionPointCircle(Vector2 point, Vector2 center, float radius)
    {
        return Raylib.CheckCollisionPointCircle(point, center, radius);
    }

    /// <summary>
    /// Check if point is inside a triangle
    /// </summary>
    public static bool CheckCollisionPointTriangle(Vector2 point, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        return Raylib.CheckCollisionPointTriangle(point, p1, p2, p3);
    }

    /// <summary>
    /// Check the collision between two lines defined by two points each, returns collision point by reference
    /// </summary>
    public static bool CheckCollisionLines(Vector2 startPos1, Vector2 endPos1, Vector2 startPos2, Vector2 endPos2, Vector2* collisionPoint)
    {
        return Raylib.CheckCollisionLines(startPos1, endPos1, startPos2, endPos2, collisionPoint);
    }

    /// <summary>
    /// Check if point belongs to line created between two points [p1] and [p2] with defined margin in pixels [threshold]
    /// </summary>
    public static bool CheckCollisionPointLine(Vector2 point, Vector2 p1, Vector2 p2, int threshold)
    {
        return Raylib.CheckCollisionPointLine(point, p1, p2, threshold);
    }

    /// <summary>
    /// Get collision rectangle for two rectangles collision
    /// </summary>
    public static Rectangle GetCollisionRec(Rectangle rec1, Rectangle rec2)
    {
        return Raylib.GetCollisionRec(rec1, rec2);
    }

    /// <summary>
    /// Load image from file into CPU memory (RAM)
    /// </summary>
    public static Image LoadImage(string fileName)
    {
        return Raylib.LoadImage(fileName);
    }

    /// <summary>
    /// Load image from RAW file data
    /// </summary>
    public static Image LoadImageRaw(string fileName, int width, int height, int format, int headerSize)
    {
        return Raylib.LoadImageRaw(fileName, width, height, format, headerSize);
    }

    /// <summary>
    /// Load image sequence from file (frames appended to image.data)
    /// </summary>
    public static Image LoadImageAnim(string fileName, int* frames)
    {
        return Raylib.LoadImageAnim(fileName, frames);
    }

    /// <summary>
    /// Load image from memory buffer, fileType refers to extension: i.e. '.png'
    /// </summary>
    public static Image LoadImageFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        return Raylib.LoadImageFromMemory(fileType, fileDataLocal, dataSize);
    }

    /// <summary>
    /// Load image from GPU texture data
    /// </summary>
    public static Image LoadImageFromTexture(Texture2D texture)
    {
        return Raylib.LoadImageFromTexture(texture);
    }

    /// <summary>
    /// Load image from screen buffer and (screenshot)
    /// </summary>
    public static Image LoadImageFromScreen()
    {
        return Raylib.LoadImageFromScreen();
    }

    /// <summary>
    /// Unload image from CPU memory (RAM)
    /// </summary>
    public static void UnloadImage(Image image)
    {
        Raylib.UnloadImage(image);
    }

    /// <summary>
    /// Export image data to file, returns true on success
    /// </summary>
    public static bool ExportImage(Image image, string fileName)
    {
        return Raylib.ExportImage(image, fileName);
    }

    /// <summary>
    /// Export image as code file defining an array of bytes, returns true on success
    /// </summary>
    public static bool ExportImageAsCode(Image image, string fileName)
    {
        return Raylib.ExportImageAsCode(image, fileName);
    }

    /// <summary>
    /// Generate image: plain color
    /// </summary>
    public static Image GenImageColor(int width, int height, Color color)
    {
        return Raylib.GenImageColor(width, height, color);
    }

    /// <summary>
    /// Generate image: vertical gradient
    /// </summary>
    public static Image GenImageGradientV(int width, int height, Color top, Color bottom)
    {
        return Raylib.GenImageGradientV(width, height, top, bottom);
    }

    /// <summary>
    /// Generate image: horizontal gradient
    /// </summary>
    public static Image GenImageGradientH(int width, int height, Color left, Color right)
    {
        return Raylib.GenImageGradientH(width, height, left, right);
    }

    /// <summary>
    /// Generate image: radial gradient
    /// </summary>
    public static Image GenImageGradientRadial(int width, int height, float density, Color inner, Color outer)
    {
        return Raylib.GenImageGradientRadial(width, height, density, inner, outer);
    }

    /// <summary>
    /// Generate image: checked
    /// </summary>
    public static Image GenImageChecked(int width, int height, int checksX, int checksY, Color col1, Color col2)
    {
        return Raylib.GenImageChecked(width, height, checksX, checksY, col1, col2);
    }

    /// <summary>
    /// Generate image: white noise
    /// </summary>
    public static Image GenImageWhiteNoise(int width, int height, float factor)
    {
        return Raylib.GenImageWhiteNoise(width, height, factor);
    }

    /// <summary>
    /// Generate image: cellular algorithm, bigger tileSize means bigger cells
    /// </summary>
    public static Image GenImageCellular(int width, int height, int tileSize)
    {
        return Raylib.GenImageCellular(width, height, tileSize);
    }

    /// <summary>
    /// Create an image duplicate (useful for transformations)
    /// </summary>
    public static Image ImageCopy(Image image)
    {
        return Raylib.ImageCopy(image);
    }

    /// <summary>
    /// Create an image from another image piece
    /// </summary>
    public static Image ImageFromImage(Image image, Rectangle rec)
    {
        return Raylib.ImageFromImage(image, rec);
    }

    /// <summary>
    /// Create an image from text (default font)
    /// </summary>
    public static Image ImageText(string text, int fontSize, Color color)
    {
        return Raylib.ImageText(text, fontSize, color);
    }

    /// <summary>
    /// Create an image from text (custom sprite font)
    /// </summary>
    public static Image ImageTextEx(Font font, string text, float fontSize, float spacing, Color tint)
    {
        return Raylib.ImageTextEx(font, text, fontSize, spacing, tint);
    }

    /// <summary>
    /// Convert image data to desired format
    /// </summary>
    public static void ImageFormat(Image* image, int newFormat)
    {
        Raylib.ImageFormat(image, newFormat);
    }

    /// <summary>
    /// Convert image to POT (power-of-two)
    /// </summary>
    public static void ImageToPOT(Image* image, Color fill)
    {
        Raylib.ImageToPOT(image, fill);
    }

    /// <summary>
    /// Crop an image to a defined rectangle
    /// </summary>
    public static void ImageCrop(Image* image, Rectangle crop)
    {
        Raylib.ImageCrop(image, crop);
    }

    /// <summary>
    /// Crop image depending on alpha value
    /// </summary>
    public static void ImageAlphaCrop(Image* image, float threshold)
    {
        Raylib.ImageAlphaCrop(image, threshold);
    }

    /// <summary>
    /// Clear alpha channel to desired color
    /// </summary>
    public static void ImageAlphaClear(Image* image, Color color, float threshold)
    {
        Raylib.ImageAlphaClear(image, color, threshold);
    }

    /// <summary>
    /// Apply alpha mask to image
    /// </summary>
    public static void ImageAlphaMask(Image* image, Image alphaMask)
    {
        Raylib.ImageAlphaMask(image, alphaMask);
    }

    /// <summary>
    /// Premultiply alpha channel
    /// </summary>
    public static void ImageAlphaPremultiply(Image* image)
    {
        Raylib.ImageAlphaPremultiply(image);
    }

    /// <summary>
    /// Resize image (Bicubic scaling algorithm)
    /// </summary>
    public static void ImageResize(Image* image, int newWidth, int newHeight)
    {
        Raylib.ImageResize(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize image (Nearest-Neighbor scaling algorithm)
    /// </summary>
    public static void ImageResizeNN(Image* image, int newWidth, int newHeight)
    {
        Raylib.ImageResizeNN(image, newWidth, newHeight);
    }

    /// <summary>
    /// Resize canvas and fill with color
    /// </summary>
    public static void ImageResizeCanvas(Image* image, int newWidth, int newHeight, int offsetX, int offsetY, Color fill)
    {
        Raylib.ImageResizeCanvas(image, newWidth, newHeight, offsetX, offsetY, fill);
    }

    /// <summary>
    /// Compute all mipmap levels for a provided image
    /// </summary>
    public static void ImageMipmaps(Image* image)
    {
        Raylib.ImageMipmaps(image);
    }

    /// <summary>
    /// Dither image data to 16bpp or lower (Floyd-Steinberg dithering)
    /// </summary>
    public static void ImageDither(Image* image, int rBpp, int gBpp, int bBpp, int aBpp)
    {
        Raylib.ImageDither(image, rBpp, gBpp, bBpp, aBpp);
    }

    /// <summary>
    /// Flip image vertically
    /// </summary>
    public static void ImageFlipVertical(Image* image)
    {
        Raylib.ImageFlipVertical(image);
    }

    /// <summary>
    /// Flip image horizontally
    /// </summary>
    public static void ImageFlipHorizontal(Image* image)
    {
        Raylib.ImageFlipHorizontal(image);
    }

    /// <summary>
    /// Rotate image clockwise 90deg
    /// </summary>
    public static void ImageRotateCW(Image* image)
    {
        Raylib.ImageRotateCW(image);
    }

    /// <summary>
    /// Rotate image counter-clockwise 90deg
    /// </summary>
    public static void ImageRotateCCW(Image* image)
    {
        Raylib.ImageRotateCCW(image);
    }

    /// <summary>
    /// Modify image color: tint
    /// </summary>
    public static void ImageColorTint(Image* image, Color color)
    {
        Raylib.ImageColorTint(image, color);
    }

    /// <summary>
    /// Modify image color: invert
    /// </summary>
    public static void ImageColorInvert(Image* image)
    {
        Raylib.ImageColorInvert(image);
    }

    /// <summary>
    /// Modify image color: grayscale
    /// </summary>
    public static void ImageColorGrayscale(Image* image)
    {
        Raylib.ImageColorGrayscale(image);
    }

    /// <summary>
    /// Modify image color: contrast (-100 to 100)
    /// </summary>
    public static void ImageColorContrast(Image* image, float contrast)
    {
        Raylib.ImageColorContrast(image, contrast);
    }

    /// <summary>
    /// Modify image color: brightness (-255 to 255)
    /// </summary>
    public static void ImageColorBrightness(Image* image, int brightness)
    {
        Raylib.ImageColorBrightness(image, brightness);
    }

    /// <summary>
    /// Modify image color: replace color
    /// </summary>
    public static void ImageColorReplace(Image* image, Color color, Color replace)
    {
        Raylib.ImageColorReplace(image, color, replace);
    }

    /// <summary>
    /// Load color data from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color* LoadImageColors(Image image)
    {
        return Raylib.LoadImageColors(image);
    }

    /// <summary>
    /// Load colors palette from image as a Color array (RGBA - 32bit)
    /// </summary>
    public static Color* LoadImagePalette(Image image, int maxPaletteSize, int* colorCount)
    {
        return Raylib.LoadImagePalette(image, maxPaletteSize, colorCount);
    }

    /// <summary>
    /// Unload color data loaded with LoadImageColors()
    /// </summary>
    public static void UnloadImageColors(Color* colors)
    {
        Raylib.UnloadImageColors(colors);
    }

    /// <summary>
    /// Unload colors palette loaded with LoadImagePalette()
    /// </summary>
    public static void UnloadImagePalette(Color* colors)
    {
        Raylib.UnloadImagePalette(colors);
    }

    /// <summary>
    /// Get image alpha border rectangle
    /// </summary>
    public static Rectangle GetImageAlphaBorder(Image image, float threshold)
    {
        return Raylib.GetImageAlphaBorder(image, threshold);
    }

    /// <summary>
    /// Get image pixel color at (x, y) position
    /// </summary>
    public static Color GetImageColor(Image image, int x, int y)
    {
        return Raylib.GetImageColor(image, x, y);
    }

    /// <summary>
    /// Clear image background with given color
    /// </summary>
    public static void ImageClearBackground(Image* dst, Color color)
    {
        Raylib.ImageClearBackground(dst, color);
    }

    /// <summary>
    /// Draw pixel within an image
    /// </summary>
    public static void ImageDrawPixel(Image* dst, int posX, int posY, Color color)
    {
        Raylib.ImageDrawPixel(dst, posX, posY, color);
    }

    /// <summary>
    /// Draw pixel within an image (Vector version)
    /// </summary>
    public static void ImageDrawPixelV(Image* dst, Vector2 position, Color color)
    {
        Raylib.ImageDrawPixelV(dst, position, color);
    }

    /// <summary>
    /// Draw line within an image
    /// </summary>
    public static void ImageDrawLine(Image* dst, int startPosX, int startPosY, int endPosX, int endPosY, Color color)
    {
        Raylib.ImageDrawLine(dst, startPosX, startPosY, endPosX, endPosY, color);
    }

    /// <summary>
    /// Draw line within an image (Vector version)
    /// </summary>
    public static void ImageDrawLineV(Image* dst, Vector2 start, Vector2 end, Color color)
    {
        Raylib.ImageDrawLineV(dst, start, end, color);
    }

    /// <summary>
    /// Draw circle within an image
    /// </summary>
    public static void ImageDrawCircle(Image* dst, int centerX, int centerY, int radius, Color color)
    {
        Raylib.ImageDrawCircle(dst, centerX, centerY, radius, color);
    }

    /// <summary>
    /// Draw circle within an image (Vector version)
    /// </summary>
    public static void ImageDrawCircleV(Image* dst, Vector2 center, int radius, Color color)
    {
        Raylib.ImageDrawCircleV(dst, center, radius, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangle(Image* dst, int posX, int posY, int width, int height, Color color)
    {
        Raylib.ImageDrawRectangle(dst, posX, posY, width, height, color);
    }

    /// <summary>
    /// Draw rectangle within an image (Vector version)
    /// </summary>
    public static void ImageDrawRectangleV(Image* dst, Vector2 position, Vector2 size, Color color)
    {
        Raylib.ImageDrawRectangleV(dst, position, size, color);
    }

    /// <summary>
    /// Draw rectangle within an image
    /// </summary>
    public static void ImageDrawRectangleRec(Image* dst, Rectangle rec, Color color)
    {
        Raylib.ImageDrawRectangleRec(dst, rec, color);
    }

    /// <summary>
    /// Draw rectangle lines within an image
    /// </summary>
    public static void ImageDrawRectangleLines(Image* dst, Rectangle rec, int thick, Color color)
    {
        Raylib.ImageDrawRectangleLines(dst, rec, thick, color);
    }

    /// <summary>
    /// Draw a source image within a destination image (tint applied to source)
    /// </summary>
    public static void ImageDraw(Image* dst, Image src, Rectangle srcRec, Rectangle dstRec, Color tint)
    {
        Raylib.ImageDraw(dst, src, srcRec, dstRec, tint);
    }

    /// <summary>
    /// Draw text (using default font) within an image (destination)
    /// </summary>
    public static void ImageDrawText(Image* dst, string text, int posX, int posY, int fontSize, Color color)
    {
        Raylib.ImageDrawText(dst, text, posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text (custom sprite font) within an image (destination)
    /// </summary>
    public static void ImageDrawTextEx(Image* dst, Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        Raylib.ImageDrawTextEx(dst, font, text, position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Load texture from file into GPU memory (VRAM)
    /// </summary>
    public static Texture2D LoadTexture(string fileName)
    {
        return Raylib.LoadTexture(fileName);
    }

    /// <summary>
    /// Load texture from image data
    /// </summary>
    public static Texture2D LoadTextureFromImage(Image image)
    {
        return Raylib.LoadTextureFromImage(image);
    }

    /// <summary>
    /// Load cubemap from image, multiple image cubemap layouts supported
    /// </summary>
    public static TextureCubemap LoadTextureCubemap(Image image, int layout)
    {
        return Raylib.LoadTextureCubemap(image, layout);
    }

    /// <summary>
    /// Load texture for rendering (framebuffer)
    /// </summary>
    public static RenderTexture2D LoadRenderTexture(int width, int height)
    {
        return Raylib.LoadRenderTexture(width, height);
    }

    /// <summary>
    /// Unload texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadTexture(Texture2D texture)
    {
        Raylib.UnloadTexture(texture);
    }

    /// <summary>
    /// Unload render texture from GPU memory (VRAM)
    /// </summary>
    public static void UnloadRenderTexture(RenderTexture2D target)
    {
        Raylib.UnloadRenderTexture(target);
    }

    /// <summary>
    /// Update GPU texture with new data
    /// </summary>
    public static void UpdateTexture(Texture2D texture, IntPtr pixels)
    {
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTexture(texture, pixelsLocal);
    }

    /// <summary>
    /// Update GPU texture rectangle with new data
    /// </summary>
    public static void UpdateTextureRec(Texture2D texture, Rectangle rec, IntPtr pixels)
    {
        var pixelsLocal = (void*)pixels;
        Raylib.UpdateTextureRec(texture, rec, pixelsLocal);
    }

    /// <summary>
    /// Generate GPU mipmaps for a texture
    /// </summary>
    public static void GenTextureMipmaps(Texture2D* texture)
    {
        Raylib.GenTextureMipmaps(texture);
    }

    /// <summary>
    /// Set texture scaling filter mode
    /// </summary>
    public static void SetTextureFilter(Texture2D texture, int filter)
    {
        Raylib.SetTextureFilter(texture, filter);
    }

    /// <summary>
    /// Set texture wrapping mode
    /// </summary>
    public static void SetTextureWrap(Texture2D texture, int wrap)
    {
        Raylib.SetTextureWrap(texture, wrap);
    }

    /// <summary>
    /// Draw a Texture2D
    /// </summary>
    public static void DrawTexture(Texture2D texture, int posX, int posY, Color tint)
    {
        Raylib.DrawTexture(texture, posX, posY, tint);
    }

    /// <summary>
    /// Draw a Texture2D with position defined as Vector2
    /// </summary>
    public static void DrawTextureV(Texture2D texture, Vector2 position, Color tint)
    {
        Raylib.DrawTextureV(texture, position, tint);
    }

    /// <summary>
    /// Draw a Texture2D with extended parameters
    /// </summary>
    public static void DrawTextureEx(Texture2D texture, Vector2 position, float rotation, float scale, Color tint)
    {
        Raylib.DrawTextureEx(texture, position, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle
    /// </summary>
    public static void DrawTextureRec(Texture2D texture, Rectangle source, Vector2 position, Color tint)
    {
        Raylib.DrawTextureRec(texture, source, position, tint);
    }

    /// <summary>
    /// Draw texture quad with tiling and offset parameters
    /// </summary>
    public static void DrawTextureQuad(Texture2D texture, Vector2 tiling, Vector2 offset, Rectangle quad, Color tint)
    {
        Raylib.DrawTextureQuad(texture, tiling, offset, quad, tint);
    }

    /// <summary>
    /// Draw part of a texture (defined by a rectangle) with rotation and scale tiled into dest.
    /// </summary>
    public static void DrawTextureTiled(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, float scale, Color tint)
    {
        Raylib.DrawTextureTiled(texture, source, dest, origin, rotation, scale, tint);
    }

    /// <summary>
    /// Draw a part of a texture defined by a rectangle with 'pro' parameters
    /// </summary>
    public static void DrawTexturePro(Texture2D texture, Rectangle source, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawTexturePro(texture, source, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draws a texture (or part of it) that stretches or shrinks nicely
    /// </summary>
    public static void DrawTextureNPatch(Texture2D texture, NPatchInfo nPatchInfo, Rectangle dest, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawTextureNPatch(texture, nPatchInfo, dest, origin, rotation, tint);
    }

    /// <summary>
    /// Draw a textured polygon
    /// </summary>
    public static void DrawTexturePoly(Texture2D texture, Vector2 center, Vector2* points, Vector2* texcoords, int pointCount, Color tint)
    {
        Raylib.DrawTexturePoly(texture, center, points, texcoords, pointCount, tint);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color Fade(Color color, float alpha)
    {
        return Raylib.Fade(color, alpha);
    }

    /// <summary>
    /// Get hexadecimal value for a Color
    /// </summary>
    public static int ColorToInt(Color color)
    {
        return Raylib.ColorToInt(color);
    }

    /// <summary>
    /// Get Color normalized as float [0..1]
    /// </summary>
    public static Vector4 ColorNormalize(Color color)
    {
        return Raylib.ColorNormalize(color);
    }

    /// <summary>
    /// Get Color from normalized values [0..1]
    /// </summary>
    public static Color ColorFromNormalized(Vector4 normalized)
    {
        return Raylib.ColorFromNormalized(normalized);
    }

    /// <summary>
    /// Get HSV values for a Color, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Vector3 ColorToHSV(Color color)
    {
        return Raylib.ColorToHSV(color);
    }

    /// <summary>
    /// Get a Color from HSV values, hue [0..360], saturation/value [0..1]
    /// </summary>
    public static Color ColorFromHSV(float hue, float saturation, float value)
    {
        return Raylib.ColorFromHSV(hue, saturation, value);
    }

    /// <summary>
    /// Get color with alpha applied, alpha goes from 0.0f to 1.0f
    /// </summary>
    public static Color ColorAlpha(Color color, float alpha)
    {
        return Raylib.ColorAlpha(color, alpha);
    }

    /// <summary>
    /// Get src alpha-blended into dst color with tint
    /// </summary>
    public static Color ColorAlphaBlend(Color dst, Color src, Color tint)
    {
        return Raylib.ColorAlphaBlend(dst, src, tint);
    }

    /// <summary>
    /// Get Color structure from hexadecimal value
    /// </summary>
    public static Color GetColor(uint hexValue)
    {
        return Raylib.GetColor(hexValue);
    }

    /// <summary>
    /// Get Color from a source pixel pointer of certain format
    /// </summary>
    public static Color GetPixelColor(IntPtr srcPtr, int format)
    {
        var srcPtrLocal = (void*)srcPtr;
        return Raylib.GetPixelColor(srcPtrLocal, format);
    }

    /// <summary>
    /// Set color formatted into destination pixel pointer
    /// </summary>
    public static void SetPixelColor(IntPtr dstPtr, Color color, int format)
    {
        var dstPtrLocal = (void*)dstPtr;
        Raylib.SetPixelColor(dstPtrLocal, color, format);
    }

    /// <summary>
    /// Get pixel data size in bytes for certain format
    /// </summary>
    public static int GetPixelDataSize(int width, int height, int format)
    {
        return Raylib.GetPixelDataSize(width, height, format);
    }

    /// <summary>
    /// Get the default Font
    /// </summary>
    public static Font GetFontDefault()
    {
        return Raylib.GetFontDefault();
    }

    /// <summary>
    /// Load font from file into GPU memory (VRAM)
    /// </summary>
    public static Font LoadFont(string fileName)
    {
        return Raylib.LoadFont(fileName);
    }

    /// <summary>
    /// Load font from file with extended parameters, use NULL for fontChars and 0 for glyphCount to load the default character set
    /// </summary>
    public static Font LoadFontEx(string fileName, int fontSize, int* fontChars, int glyphCount)
    {
        return Raylib.LoadFontEx(fileName, fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font from Image (XNA style)
    /// </summary>
    public static Font LoadFontFromImage(Image image, Color key, int firstChar)
    {
        return Raylib.LoadFontFromImage(image, key, firstChar);
    }

    /// <summary>
    /// Load font from memory buffer, fileType refers to extension: i.e. '.ttf'
    /// </summary>
    public static Font LoadFontFromMemory(string fileType, byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount)
    {
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        return Raylib.LoadFontFromMemory(fileType, fileDataLocal, dataSize, fontSize, fontChars, glyphCount);
    }

    /// <summary>
    /// Load font data for further use
    /// </summary>
    public static GlyphInfo* LoadFontData(byte[] fileData, int dataSize, int fontSize, int* fontChars, int glyphCount, int type)
    {
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        return Raylib.LoadFontData(fileDataLocal, dataSize, fontSize, fontChars, glyphCount, type);
    }

    /// <summary>
    /// Generate image font atlas using chars info
    /// </summary>
    public static Image GenImageFontAtlas(GlyphInfo* chars, Rectangle** recs, int glyphCount, int fontSize, int padding, int packMethod)
    {
        return Raylib.GenImageFontAtlas(chars, recs, glyphCount, fontSize, padding, packMethod);
    }

    /// <summary>
    /// Unload font chars info data (RAM)
    /// </summary>
    public static void UnloadFontData(GlyphInfo* chars, int glyphCount)
    {
        Raylib.UnloadFontData(chars, glyphCount);
    }

    /// <summary>
    /// Unload font from GPU memory (VRAM)
    /// </summary>
    public static void UnloadFont(Font font)
    {
        Raylib.UnloadFont(font);
    }

    /// <summary>
    /// Export font as code file, returns true on success
    /// </summary>
    public static bool ExportFontAsCode(Font font, string fileName)
    {
        return Raylib.ExportFontAsCode(font, fileName);
    }

    /// <summary>
    /// Draw current FPS
    /// </summary>
    public static void DrawFPS(int posX, int posY)
    {
        Raylib.DrawFPS(posX, posY);
    }

    /// <summary>
    /// Draw text (using default font)
    /// </summary>
    public static void DrawText(string text, int posX, int posY, int fontSize, Color color)
    {
        Raylib.DrawText(text, posX, posY, fontSize, color);
    }

    /// <summary>
    /// Draw text using font and additional parameters
    /// </summary>
    public static void DrawTextEx(Font font, string text, Vector2 position, float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextEx(font, text, position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw text using Font and pro parameters (rotation)
    /// </summary>
    public static void DrawTextPro(Font font, string text, Vector2 position, Vector2 origin, float rotation, float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextPro(font, text, position, origin, rotation, fontSize, spacing, tint);
    }

    /// <summary>
    /// Draw one character (codepoint)
    /// </summary>
    public static void DrawTextCodepoint(Font font, int codepoint, Vector2 position, float fontSize, Color tint)
    {
        Raylib.DrawTextCodepoint(font, codepoint, position, fontSize, tint);
    }

    /// <summary>
    /// Draw multiple character (codepoint)
    /// </summary>
    public static void DrawTextCodepoints(Font font, int* codepoints, int count, Vector2 position, float fontSize, float spacing, Color tint)
    {
        Raylib.DrawTextCodepoints(font, codepoints, count, position, fontSize, spacing, tint);
    }

    /// <summary>
    /// Measure string width for default font
    /// </summary>
    public static int MeasureText(string text, int fontSize)
    {
        return Raylib.MeasureText(text, fontSize);
    }

    /// <summary>
    /// Measure string size for Font
    /// </summary>
    public static Vector2 MeasureTextEx(Font font, string text, float fontSize, float spacing)
    {
        return Raylib.MeasureTextEx(font, text, fontSize, spacing);
    }

    /// <summary>
    /// Get glyph index position in font for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static int GetGlyphIndex(Font font, int codepoint)
    {
        return Raylib.GetGlyphIndex(font, codepoint);
    }

    /// <summary>
    /// Get glyph font info data for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static GlyphInfo GetGlyphInfo(Font font, int codepoint)
    {
        return Raylib.GetGlyphInfo(font, codepoint);
    }

    /// <summary>
    /// Get glyph rectangle in font atlas for a codepoint (unicode character), fallback to '?' if not found
    /// </summary>
    public static Rectangle GetGlyphAtlasRec(Font font, int codepoint)
    {
        return Raylib.GetGlyphAtlasRec(font, codepoint);
    }

    /// <summary>
    /// Load all codepoints from a UTF-8 text string, codepoints count returned by parameter
    /// </summary>
    public static int* LoadCodepoints(string text, int* count)
    {
        return Raylib.LoadCodepoints(text, count);
    }

    /// <summary>
    /// Unload codepoints data from memory
    /// </summary>
    public static void UnloadCodepoints(int* codepoints)
    {
        Raylib.UnloadCodepoints(codepoints);
    }

    /// <summary>
    /// Get total number of codepoints in a UTF-8 encoded string
    /// </summary>
    public static int GetCodepointCount(string text)
    {
        return Raylib.GetCodepointCount(text);
    }

    /// <summary>
    /// Get next codepoint in a UTF-8 encoded string, 0x3f('?') is returned on failure
    /// </summary>
    public static int GetCodepoint(string text, int* bytesProcessed)
    {
        return Raylib.GetCodepoint(text, bytesProcessed);
    }

    /// <summary>
    /// Encode one codepoint into UTF-8 byte array (array length returned as parameter)
    /// </summary>
    public static string CodepointToUTF8(int codepoint, int* byteSize)
    {
        return Helpers.Utf8ToString(Raylib.CodepointToUTF8(codepoint, byteSize));
    }

    /// <summary>
    /// Encode text as codepoints array into UTF-8 text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextCodepointsToUTF8(int* codepoints, int length)
    {
        return Helpers.Utf8ToString(Raylib.TextCodepointsToUTF8(codepoints, length));
    }

    /// <summary>
    /// Copy one string to another, returns bytes copied
    /// </summary>
    public static int TextCopy(string dst, string src)
    {
        return Raylib.TextCopy(dst, src);
    }

    /// <summary>
    /// Check if two text string are equal
    /// </summary>
    public static bool TextIsEqual(string text1, string text2)
    {
        return Raylib.TextIsEqual(text1, text2);
    }

    /// <summary>
    /// Get text length, checks for '\0' ending
    /// </summary>
    public static uint TextLength(string text)
    {
        return (uint)Raylib.TextLength(text);
    }

    /// <summary>
    /// Get a piece of a text string
    /// </summary>
    public static string TextSubtext(string text, int position, int length)
    {
        return Helpers.Utf8ToString(Raylib.TextSubtext(text, position, length));
    }

    /// <summary>
    /// Replace text string (WARNING: memory must be freed!)
    /// </summary>
    public static string TextReplace(string text, string replace, string by)
    {
        return Helpers.Utf8ToString(Raylib.TextReplace(text, replace, by));
    }

    /// <summary>
    /// Insert text in a position (WARNING: memory must be freed!)
    /// </summary>
    public static string TextInsert(string text, string insert, int position)
    {
        return Helpers.Utf8ToString(Raylib.TextInsert(text, insert, position));
    }

    /// <summary>
    /// Append text at specific position and move cursor!
    /// </summary>
    public static void TextAppend(string text, string append, int* position)
    {
        Raylib.TextAppend(text, append, position);
    }

    /// <summary>
    /// Find first text occurrence within a string
    /// </summary>
    public static int TextFindIndex(string text, string find)
    {
        return Raylib.TextFindIndex(text, find);
    }

    /// <summary>
    /// Get upper case version of provided string
    /// </summary>
    public static string TextToUpper(string text)
    {
        return Helpers.Utf8ToString(Raylib.TextToUpper(text));
    }

    /// <summary>
    /// Get lower case version of provided string
    /// </summary>
    public static string TextToLower(string text)
    {
        return Helpers.Utf8ToString(Raylib.TextToLower(text));
    }

    /// <summary>
    /// Get Pascal case notation version of provided string
    /// </summary>
    public static string TextToPascal(string text)
    {
        return Helpers.Utf8ToString(Raylib.TextToPascal(text));
    }

    /// <summary>
    /// Get integer value from text (negative values not supported)
    /// </summary>
    public static int TextToInteger(string text)
    {
        return Raylib.TextToInteger(text);
    }

    /// <summary>
    /// Draw a line in 3D world space
    /// </summary>
    public static void DrawLine3D(Vector3 startPos, Vector3 endPos, Color color)
    {
        Raylib.DrawLine3D(startPos, endPos, color);
    }

    /// <summary>
    /// Draw a point in 3D space, actually a small line
    /// </summary>
    public static void DrawPoint3D(Vector3 position, Color color)
    {
        Raylib.DrawPoint3D(position, color);
    }

    /// <summary>
    /// Draw a circle in 3D world space
    /// </summary>
    public static void DrawCircle3D(Vector3 center, float radius, Vector3 rotationAxis, float rotationAngle, Color color)
    {
        Raylib.DrawCircle3D(center, radius, rotationAxis, rotationAngle, color);
    }

    /// <summary>
    /// Draw a color-filled triangle (vertex in counter-clockwise order!)
    /// </summary>
    public static void DrawTriangle3D(Vector3 v1, Vector3 v2, Vector3 v3, Color color)
    {
        Raylib.DrawTriangle3D(v1, v2, v3, color);
    }

    /// <summary>
    /// Draw a triangle strip defined by points
    /// </summary>
    public static void DrawTriangleStrip3D(Vector3* points, int pointCount, Color color)
    {
        Raylib.DrawTriangleStrip3D(points, pointCount, color);
    }

    /// <summary>
    /// Draw cube
    /// </summary>
    public static void DrawCube(Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCube(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube (Vector version)
    /// </summary>
    public static void DrawCubeV(Vector3 position, Vector3 size, Color color)
    {
        Raylib.DrawCubeV(position, size, color);
    }

    /// <summary>
    /// Draw cube wires
    /// </summary>
    public static void DrawCubeWires(Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCubeWires(position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube wires (Vector version)
    /// </summary>
    public static void DrawCubeWiresV(Vector3 position, Vector3 size, Color color)
    {
        Raylib.DrawCubeWiresV(position, size, color);
    }

    /// <summary>
    /// Draw cube textured
    /// </summary>
    public static void DrawCubeTexture(Texture2D texture, Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCubeTexture(texture, position, width, height, length, color);
    }

    /// <summary>
    /// Draw cube with a region of a texture
    /// </summary>
    public static void DrawCubeTextureRec(Texture2D texture, Rectangle source, Vector3 position, float width, float height, float length, Color color)
    {
        Raylib.DrawCubeTextureRec(texture, source, position, width, height, length, color);
    }

    /// <summary>
    /// Draw sphere
    /// </summary>
    public static void DrawSphere(Vector3 centerPos, float radius, Color color)
    {
        Raylib.DrawSphere(centerPos, radius, color);
    }

    /// <summary>
    /// Draw sphere with extended parameters
    /// </summary>
    public static void DrawSphereEx(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        Raylib.DrawSphereEx(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw sphere wires
    /// </summary>
    public static void DrawSphereWires(Vector3 centerPos, float radius, int rings, int slices, Color color)
    {
        Raylib.DrawSphereWires(centerPos, radius, rings, slices, color);
    }

    /// <summary>
    /// Draw a cylinder/cone
    /// </summary>
    public static void DrawCylinder(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        Raylib.DrawCylinder(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        Raylib.DrawCylinderEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a cylinder/cone wires
    /// </summary>
    public static void DrawCylinderWires(Vector3 position, float radiusTop, float radiusBottom, float height, int slices, Color color)
    {
        Raylib.DrawCylinderWires(position, radiusTop, radiusBottom, height, slices, color);
    }

    /// <summary>
    /// Draw a cylinder wires with base at startPos and top at endPos
    /// </summary>
    public static void DrawCylinderWiresEx(Vector3 startPos, Vector3 endPos, float startRadius, float endRadius, int sides, Color color)
    {
        Raylib.DrawCylinderWiresEx(startPos, endPos, startRadius, endRadius, sides, color);
    }

    /// <summary>
    /// Draw a plane XZ
    /// </summary>
    public static void DrawPlane(Vector3 centerPos, Vector2 size, Color color)
    {
        Raylib.DrawPlane(centerPos, size, color);
    }

    /// <summary>
    /// Draw a ray line
    /// </summary>
    public static void DrawRay(Ray ray, Color color)
    {
        Raylib.DrawRay(ray, color);
    }

    /// <summary>
    /// Draw a grid (centered at (0, 0, 0))
    /// </summary>
    public static void DrawGrid(int slices, float spacing)
    {
        Raylib.DrawGrid(slices, spacing);
    }

    /// <summary>
    /// Load model from files (meshes and materials)
    /// </summary>
    public static Model LoadModel(string fileName)
    {
        return Raylib.LoadModel(fileName);
    }

    /// <summary>
    /// Load model from generated mesh (default material)
    /// </summary>
    public static Model LoadModelFromMesh(Mesh mesh)
    {
        return Raylib.LoadModelFromMesh(mesh);
    }

    /// <summary>
    /// Unload model (including meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModel(Model model)
    {
        Raylib.UnloadModel(model);
    }

    /// <summary>
    /// Unload model (but not meshes) from memory (RAM and/or VRAM)
    /// </summary>
    public static void UnloadModelKeepMeshes(Model model)
    {
        Raylib.UnloadModelKeepMeshes(model);
    }

    /// <summary>
    /// Compute model bounding box limits (considers all meshes)
    /// </summary>
    public static BoundingBox GetModelBoundingBox(Model model)
    {
        return Raylib.GetModelBoundingBox(model);
    }

    /// <summary>
    /// Draw a model (with texture if set)
    /// </summary>
    public static void DrawModel(Model model, Vector3 position, float scale, Color tint)
    {
        Raylib.DrawModel(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model with extended parameters
    /// </summary>
    public static void DrawModelEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        Raylib.DrawModelEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set)
    /// </summary>
    public static void DrawModelWires(Model model, Vector3 position, float scale, Color tint)
    {
        Raylib.DrawModelWires(model, position, scale, tint);
    }

    /// <summary>
    /// Draw a model wires (with texture if set) with extended parameters
    /// </summary>
    public static void DrawModelWiresEx(Model model, Vector3 position, Vector3 rotationAxis, float rotationAngle, Vector3 scale, Color tint)
    {
        Raylib.DrawModelWiresEx(model, position, rotationAxis, rotationAngle, scale, tint);
    }

    /// <summary>
    /// Draw bounding box (wires)
    /// </summary>
    public static void DrawBoundingBox(BoundingBox box, Color color)
    {
        Raylib.DrawBoundingBox(box, color);
    }

    /// <summary>
    /// Draw a billboard texture
    /// </summary>
    public static void DrawBillboard(Camera camera, Texture2D texture, Vector3 position, float size, Color tint)
    {
        Raylib.DrawBillboard(camera, texture, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source
    /// </summary>
    public static void DrawBillboardRec(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector2 size, Color tint)
    {
        Raylib.DrawBillboardRec(camera, texture, source, position, size, tint);
    }

    /// <summary>
    /// Draw a billboard texture defined by source and rotation
    /// </summary>
    public static void DrawBillboardPro(Camera camera, Texture2D texture, Rectangle source, Vector3 position, Vector3 up, Vector2 size, Vector2 origin, float rotation, Color tint)
    {
        Raylib.DrawBillboardPro(camera, texture, source, position, up, size, origin, rotation, tint);
    }

    /// <summary>
    /// Upload mesh vertex data in GPU and provide VAO/VBO ids
    /// </summary>
    public static void UploadMesh(Mesh* mesh, bool dynamic)
    {
        Raylib.UploadMesh(mesh, dynamic);
    }

    /// <summary>
    /// Update mesh vertex data in GPU for a specific buffer index
    /// </summary>
    public static void UpdateMeshBuffer(Mesh mesh, int index, IntPtr data, int dataSize, int offset)
    {
        var dataLocal = (void*)data;
        Raylib.UpdateMeshBuffer(mesh, index, dataLocal, dataSize, offset);
    }

    /// <summary>
    /// Unload mesh data from CPU and GPU
    /// </summary>
    public static void UnloadMesh(Mesh mesh)
    {
        Raylib.UnloadMesh(mesh);
    }

    /// <summary>
    /// Draw a 3d mesh with material and transform
    /// </summary>
    public static void DrawMesh(Mesh mesh, Material material, Matrix transform)
    {
        Raylib.DrawMesh(mesh, material, transform);
    }

    /// <summary>
    /// Draw multiple mesh instances with material and different transforms
    /// </summary>
    public static void DrawMeshInstanced(Mesh mesh, Material material, Matrix* transforms, int instances)
    {
        Raylib.DrawMeshInstanced(mesh, material, transforms, instances);
    }

    /// <summary>
    /// Export mesh data to file, returns true on success
    /// </summary>
    public static bool ExportMesh(Mesh mesh, string fileName)
    {
        return Raylib.ExportMesh(mesh, fileName);
    }

    /// <summary>
    /// Compute mesh bounding box limits
    /// </summary>
    public static BoundingBox GetMeshBoundingBox(Mesh mesh)
    {
        return Raylib.GetMeshBoundingBox(mesh);
    }

    /// <summary>
    /// Compute mesh tangents
    /// </summary>
    public static void GenMeshTangents(Mesh* mesh)
    {
        Raylib.GenMeshTangents(mesh);
    }

    /// <summary>
    /// Compute mesh binormals
    /// </summary>
    public static void GenMeshBinormals(Mesh* mesh)
    {
        Raylib.GenMeshBinormals(mesh);
    }

    /// <summary>
    /// Generate polygonal mesh
    /// </summary>
    public static Mesh GenMeshPoly(int sides, float radius)
    {
        return Raylib.GenMeshPoly(sides, radius);
    }

    /// <summary>
    /// Generate plane mesh (with subdivisions)
    /// </summary>
    public static Mesh GenMeshPlane(float width, float length, int resX, int resZ)
    {
        return Raylib.GenMeshPlane(width, length, resX, resZ);
    }

    /// <summary>
    /// Generate cuboid mesh
    /// </summary>
    public static Mesh GenMeshCube(float width, float height, float length)
    {
        return Raylib.GenMeshCube(width, height, length);
    }

    /// <summary>
    /// Generate sphere mesh (standard sphere)
    /// </summary>
    public static Mesh GenMeshSphere(float radius, int rings, int slices)
    {
        return Raylib.GenMeshSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate half-sphere mesh (no bottom cap)
    /// </summary>
    public static Mesh GenMeshHemiSphere(float radius, int rings, int slices)
    {
        return Raylib.GenMeshHemiSphere(radius, rings, slices);
    }

    /// <summary>
    /// Generate cylinder mesh
    /// </summary>
    public static Mesh GenMeshCylinder(float radius, float height, int slices)
    {
        return Raylib.GenMeshCylinder(radius, height, slices);
    }

    /// <summary>
    /// Generate cone/pyramid mesh
    /// </summary>
    public static Mesh GenMeshCone(float radius, float height, int slices)
    {
        return Raylib.GenMeshCone(radius, height, slices);
    }

    /// <summary>
    /// Generate torus mesh
    /// </summary>
    public static Mesh GenMeshTorus(float radius, float size, int radSeg, int sides)
    {
        return Raylib.GenMeshTorus(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate trefoil knot mesh
    /// </summary>
    public static Mesh GenMeshKnot(float radius, float size, int radSeg, int sides)
    {
        return Raylib.GenMeshKnot(radius, size, radSeg, sides);
    }

    /// <summary>
    /// Generate heightmap mesh from image data
    /// </summary>
    public static Mesh GenMeshHeightmap(Image heightmap, Vector3 size)
    {
        return Raylib.GenMeshHeightmap(heightmap, size);
    }

    /// <summary>
    /// Generate cubes-based map mesh from image data
    /// </summary>
    public static Mesh GenMeshCubicmap(Image cubicmap, Vector3 cubeSize)
    {
        return Raylib.GenMeshCubicmap(cubicmap, cubeSize);
    }

    /// <summary>
    /// Load materials from model file
    /// </summary>
    public static Material* LoadMaterials(string fileName, int* materialCount)
    {
        return Raylib.LoadMaterials(fileName, materialCount);
    }

    /// <summary>
    /// Load default material (Supports: DIFFUSE, SPECULAR, NORMAL maps)
    /// </summary>
    public static Material LoadMaterialDefault()
    {
        return Raylib.LoadMaterialDefault();
    }

    /// <summary>
    /// Unload material from GPU memory (VRAM)
    /// </summary>
    public static void UnloadMaterial(Material material)
    {
        Raylib.UnloadMaterial(material);
    }

    /// <summary>
    /// Set texture for a material map type (MATERIAL_MAP_DIFFUSE, MATERIAL_MAP_SPECULAR...)
    /// </summary>
    public static void SetMaterialTexture(Material* material, int mapType, Texture2D texture)
    {
        Raylib.SetMaterialTexture(material, mapType, texture);
    }

    /// <summary>
    /// Set material for a mesh
    /// </summary>
    public static void SetModelMeshMaterial(Model* model, int meshId, int materialId)
    {
        Raylib.SetModelMeshMaterial(model, meshId, materialId);
    }

    /// <summary>
    /// Update model animation pose
    /// </summary>
    public static void UpdateModelAnimation(Model model, ModelAnimation anim, int frame)
    {
        Raylib.UpdateModelAnimation(model, anim, frame);
    }

    /// <summary>
    /// Unload animation data
    /// </summary>
    public static void UnloadModelAnimation(ModelAnimation anim)
    {
        Raylib.UnloadModelAnimation(anim);
    }

    /// <summary>
    /// Unload animation array data
    /// </summary>
    public static void UnloadModelAnimations(ModelAnimation* animations, uint count)
    {
        Raylib.UnloadModelAnimations(animations, count);
    }

    /// <summary>
    /// Check model animation skeleton match
    /// </summary>
    public static bool IsModelAnimationValid(Model model, ModelAnimation anim)
    {
        return Raylib.IsModelAnimationValid(model, anim);
    }

    /// <summary>
    /// Check collision between two spheres
    /// </summary>
    public static bool CheckCollisionSpheres(Vector3 center1, float radius1, Vector3 center2, float radius2)
    {
        return Raylib.CheckCollisionSpheres(center1, radius1, center2, radius2);
    }

    /// <summary>
    /// Check collision between two bounding boxes
    /// </summary>
    public static bool CheckCollisionBoxes(BoundingBox box1, BoundingBox box2)
    {
        return Raylib.CheckCollisionBoxes(box1, box2);
    }

    /// <summary>
    /// Check collision between box and sphere
    /// </summary>
    public static bool CheckCollisionBoxSphere(BoundingBox box, Vector3 center, float radius)
    {
        return Raylib.CheckCollisionBoxSphere(box, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and sphere
    /// </summary>
    public static RayCollision GetRayCollisionSphere(Ray ray, Vector3 center, float radius)
    {
        return Raylib.GetRayCollisionSphere(ray, center, radius);
    }

    /// <summary>
    /// Get collision info between ray and box
    /// </summary>
    public static RayCollision GetRayCollisionBox(Ray ray, BoundingBox box)
    {
        return Raylib.GetRayCollisionBox(ray, box);
    }

    /// <summary>
    /// Get collision info between ray and model
    /// </summary>
    public static RayCollision GetRayCollisionModel(Ray ray, Model model)
    {
        return Raylib.GetRayCollisionModel(ray, model);
    }

    /// <summary>
    /// Get collision info between ray and mesh
    /// </summary>
    public static RayCollision GetRayCollisionMesh(Ray ray, Mesh mesh, Matrix transform)
    {
        return Raylib.GetRayCollisionMesh(ray, mesh, transform);
    }

    /// <summary>
    /// Get collision info between ray and triangle
    /// </summary>
    public static RayCollision GetRayCollisionTriangle(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        return Raylib.GetRayCollisionTriangle(ray, p1, p2, p3);
    }

    /// <summary>
    /// Get collision info between ray and quad
    /// </summary>
    public static RayCollision GetRayCollisionQuad(Ray ray, Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        return Raylib.GetRayCollisionQuad(ray, p1, p2, p3, p4);
    }

    /// <summary>
    /// Initialize audio device and context
    /// </summary>
    public static void InitAudioDevice()
    {
        Raylib.InitAudioDevice();
    }

    /// <summary>
    /// Close the audio device and context
    /// </summary>
    public static void CloseAudioDevice()
    {
        Raylib.CloseAudioDevice();
    }

    /// <summary>
    /// Check if audio device has been initialized successfully
    /// </summary>
    public static bool IsAudioDeviceReady()
    {
        return Raylib.IsAudioDeviceReady();
    }

    /// <summary>
    /// Set master volume (listener)
    /// </summary>
    public static void SetMasterVolume(float volume)
    {
        Raylib.SetMasterVolume(volume);
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public static Wave LoadWave(string fileName)
    {
        return Raylib.LoadWave(fileName);
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public static Wave LoadWaveFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        return Raylib.LoadWaveFromMemory(fileType, fileDataLocal, dataSize);
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public static Sound LoadSound(string fileName)
    {
        return Raylib.LoadSound(fileName);
    }

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public static Sound LoadSoundFromWave(Wave wave)
    {
        return Raylib.LoadSoundFromWave(wave);
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public static void UpdateSound(Sound sound, IntPtr data, int sampleCount)
    {
        var dataLocal = (void*)data;
        Raylib.UpdateSound(sound, dataLocal, sampleCount);
    }

    /// <summary>
    /// Unload wave data
    /// </summary>
    public static void UnloadWave(Wave wave)
    {
        Raylib.UnloadWave(wave);
    }

    /// <summary>
    /// Unload sound
    /// </summary>
    public static void UnloadSound(Sound sound)
    {
        Raylib.UnloadSound(sound);
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public static bool ExportWave(Wave wave, string fileName)
    {
        return Raylib.ExportWave(wave, fileName);
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public static bool ExportWaveAsCode(Wave wave, string fileName)
    {
        return Raylib.ExportWaveAsCode(wave, fileName);
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public static void PlaySound(Sound sound)
    {
        Raylib.PlaySound(sound);
    }

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public static void StopSound(Sound sound)
    {
        Raylib.StopSound(sound);
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    public static void PauseSound(Sound sound)
    {
        Raylib.PauseSound(sound);
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public static void ResumeSound(Sound sound)
    {
        Raylib.ResumeSound(sound);
    }

    /// <summary>
    /// Play a sound (using multichannel buffer pool)
    /// </summary>
    public static void PlaySoundMulti(Sound sound)
    {
        Raylib.PlaySoundMulti(sound);
    }

    /// <summary>
    /// Stop any sound playing (using multichannel buffer pool)
    /// </summary>
    public static void StopSoundMulti()
    {
        Raylib.StopSoundMulti();
    }

    /// <summary>
    /// Get number of sounds playing in the multichannel
    /// </summary>
    public static int GetSoundsPlaying()
    {
        return Raylib.GetSoundsPlaying();
    }

    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    public static bool IsSoundPlaying(Sound sound)
    {
        return Raylib.IsSoundPlaying(sound);
    }

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public static void SetSoundVolume(Sound sound, float volume)
    {
        Raylib.SetSoundVolume(sound, volume);
    }

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public static void SetSoundPitch(Sound sound, float pitch)
    {
        Raylib.SetSoundPitch(sound, pitch);
    }

    /// <summary>
    /// Set pan for a sound (0.5 is center)
    /// </summary>
    public static void SetSoundPan(Sound sound, float pan)
    {
        Raylib.SetSoundPan(sound, pan);
    }

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public static Wave WaveCopy(Wave wave)
    {
        return Raylib.WaveCopy(wave);
    }

    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public static void WaveCrop(Wave* wave, int initSample, int finalSample)
    {
        Raylib.WaveCrop(wave, initSample, finalSample);
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public static void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels)
    {
        Raylib.WaveFormat(wave, sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Load samples data from wave as a 32bit float data array
    /// </summary>
    public static float* LoadWaveSamples(Wave wave)
    {
        return Raylib.LoadWaveSamples(wave);
    }

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    public static void UnloadWaveSamples(float* samples)
    {
        Raylib.UnloadWaveSamples(samples);
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public static Music LoadMusicStream(string fileName)
    {
        return Raylib.LoadMusicStream(fileName);
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public static Music LoadMusicStreamFromMemory(string fileType, byte[] data, int dataSize)
    {
        var dataLocal = Helpers.ArrayToPtr(data);
        return Raylib.LoadMusicStreamFromMemory(fileType, dataLocal, dataSize);
    }

    /// <summary>
    /// Unload music stream
    /// </summary>
    public static void UnloadMusicStream(Music music)
    {
        Raylib.UnloadMusicStream(music);
    }

    /// <summary>
    /// Start music playing
    /// </summary>
    public static void PlayMusicStream(Music music)
    {
        Raylib.PlayMusicStream(music);
    }

    /// <summary>
    /// Check if music is playing
    /// </summary>
    public static bool IsMusicStreamPlaying(Music music)
    {
        return Raylib.IsMusicStreamPlaying(music);
    }

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    public static void UpdateMusicStream(Music music)
    {
        Raylib.UpdateMusicStream(music);
    }

    /// <summary>
    /// Stop music playing
    /// </summary>
    public static void StopMusicStream(Music music)
    {
        Raylib.StopMusicStream(music);
    }

    /// <summary>
    /// Pause music playing
    /// </summary>
    public static void PauseMusicStream(Music music)
    {
        Raylib.PauseMusicStream(music);
    }

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    public static void ResumeMusicStream(Music music)
    {
        Raylib.ResumeMusicStream(music);
    }

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    public static void SeekMusicStream(Music music, float position)
    {
        Raylib.SeekMusicStream(music, position);
    }

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    public static void SetMusicVolume(Music music, float volume)
    {
        Raylib.SetMusicVolume(music, volume);
    }

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    public static void SetMusicPitch(Music music, float pitch)
    {
        Raylib.SetMusicPitch(music, pitch);
    }

    /// <summary>
    /// Set pan for a music (0.5 is center)
    /// </summary>
    public static void SetMusicPan(Music music, float pan)
    {
        Raylib.SetMusicPan(music, pan);
    }

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    public static float GetMusicTimeLength(Music music)
    {
        return Raylib.GetMusicTimeLength(music);
    }

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    public static float GetMusicTimePlayed(Music music)
    {
        return Raylib.GetMusicTimePlayed(music);
    }

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    public static AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels)
    {
        return Raylib.LoadAudioStream(sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    public static void UnloadAudioStream(AudioStream stream)
    {
        Raylib.UnloadAudioStream(stream);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public static void UpdateAudioStream(AudioStream stream, IntPtr data, int frameCount)
    {
        var dataLocal = (void*)data;
        Raylib.UpdateAudioStream(stream, dataLocal, frameCount);
    }

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    public static bool IsAudioStreamProcessed(AudioStream stream)
    {
        return Raylib.IsAudioStreamProcessed(stream);
    }

    /// <summary>
    /// Play audio stream
    /// </summary>
    public static void PlayAudioStream(AudioStream stream)
    {
        Raylib.PlayAudioStream(stream);
    }

    /// <summary>
    /// Pause audio stream
    /// </summary>
    public static void PauseAudioStream(AudioStream stream)
    {
        Raylib.PauseAudioStream(stream);
    }

    /// <summary>
    /// Resume audio stream
    /// </summary>
    public static void ResumeAudioStream(AudioStream stream)
    {
        Raylib.ResumeAudioStream(stream);
    }

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    public static bool IsAudioStreamPlaying(AudioStream stream)
    {
        return Raylib.IsAudioStreamPlaying(stream);
    }

    /// <summary>
    /// Stop audio stream
    /// </summary>
    public static void StopAudioStream(AudioStream stream)
    {
        Raylib.StopAudioStream(stream);
    }

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    public static void SetAudioStreamVolume(AudioStream stream, float volume)
    {
        Raylib.SetAudioStreamVolume(stream, volume);
    }

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public static void SetAudioStreamPitch(AudioStream stream, float pitch)
    {
        Raylib.SetAudioStreamPitch(stream, pitch);
    }

    /// <summary>
    /// Set pan for audio stream (0.5 is centered)
    /// </summary>
    public static void SetAudioStreamPan(AudioStream stream, float pan)
    {
        Raylib.SetAudioStreamPan(stream, pan);
    }

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    public static void SetAudioStreamBufferSizeDefault(int size)
    {
        Raylib.SetAudioStreamBufferSizeDefault(size);
    }

}
#pragma warning restore
