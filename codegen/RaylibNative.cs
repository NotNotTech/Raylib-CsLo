#pragma warning disable
namespace Raylib_CsLo;

using System.Runtime.InteropServices;

public unsafe partial class RaylibN
{
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void InitWindow();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WindowShouldClose();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CloseWindow();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowReady();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowFullscreen();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowHidden();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowMinimized();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowMaximized();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowFocused();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowResized();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowState();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowState();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearWindowState();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ToggleFullscreen();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MaximizeWindow();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MinimizeWindow();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void RestoreWindow();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowIcon();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowTitle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowPosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowMonitor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowMinSize();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowSize();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowHandle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenWidth();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenHeight();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorCount();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCurrentMonitor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorWidth();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorHeight();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPhysicalWidth();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPhysicalHeight();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorRefreshRate();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowPosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowScaleDPI();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorName();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetClipboardText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetClipboardText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SwapScreenBuffer();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PollInputEvents();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaitTime();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ShowCursor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void HideCursor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsCursorHidden();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EnableCursor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DisableCursor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsCursorOnScreen();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearBackground();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginDrawing();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndDrawing();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginMode2D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndMode2D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginMode3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndMode3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginTextureMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndTextureMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginShaderMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndShaderMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginBlendMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndBlendMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginScissorMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndScissorMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginVrStereoMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndVrStereoMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadVrStereoConfig();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadVrStereoConfig();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadShader();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadShaderFromMemory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetShaderLocation();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetShaderLocationAttrib();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValue();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueMatrix();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadShader();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseRay();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCameraMatrix();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCameraMatrix2D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreen();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreenEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreen2D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenToWorld2D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTargetFPS();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFPS();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFrameTime();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTime();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRandomValue();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetRandomSeed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TakeScreenshot();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetConfigFlags();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TraceLog();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTraceLogLevel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemAlloc();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemRealloc();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemFree();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTraceLogCallback();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoadFileDataCallback();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSaveFileDataCallback();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoadFileTextCallback();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSaveFileTextCallback();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFileData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFileData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveFileData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFileText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFileText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveFileText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void FileExists();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DirectoryExists();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsFileExtension();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileExtension();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileName();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileNameWithoutExt();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDirectoryPath();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPrevDirectoryPath();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorkingDirectory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDirectoryFiles();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearDirectoryFiles();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ChangeDirectory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsFileDropped();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDroppedFiles();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearDroppedFiles();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileModTime();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CompressData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DecompressData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EncodeDataBase64();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DecodeDataBase64();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveStorageValue();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadStorageValue();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void OpenURL();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyDown();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyReleased();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyUp();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetExitKey();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetKeyPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCharPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadAvailable();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadName();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonDown();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonReleased();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonUp();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadButtonPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadAxisCount();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadAxisMovement();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetGamepadMappings();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonPressed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonDown();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonReleased();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonUp();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseX();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseY();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMousePosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseDelta();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMousePosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseOffset();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseScale();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseWheelMove();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseCursor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchX();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchY();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPosition();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPointId();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPointCount();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetGesturesEnabled();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGestureDetected();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDetected();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureHoldDuration();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDragVector();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDragAngle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGesturePinchVector();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGesturePinchAngle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraMode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateCamera();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraPanControl();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraAltControl();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraSmoothZoomControl();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraMoveControls();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShapesTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPixel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPixelV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLine();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezier();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezierQuad();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezierCubic();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineStrip();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleSector();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleSectorLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleGradient();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawEllipse();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawEllipseLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRing();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRingLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectanglePro();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientH();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleLinesEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRounded();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRoundedLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleFan();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleStrip();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPoly();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPolyLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPolyLinesEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionRecs();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionCircles();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionCircleRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointCircle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointTriangle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointLine();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCollisionRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageRaw();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageAnim();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromMemory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromScreen();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportImageAsCode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageColor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientH();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientRadial();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageChecked();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageWhiteNoise();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageCellular();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageCopy();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFromImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageTextEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFormat();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageToPOT();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageCrop();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaCrop();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaClear();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaMask();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaPremultiply();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResize();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResizeNN();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResizeCanvas();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageMipmaps();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDither();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFlipVertical();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFlipHorizontal();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageRotateCW();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageRotateCCW();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorTint();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorInvert();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorGrayscale();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorContrast();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorBrightness();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorReplace();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageColors();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImagePalette();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImageColors();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImagePalette();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetImageAlphaBorder();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetImageColor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageClearBackground();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawPixel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawPixelV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawLine();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawLineV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawCircle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawCircleV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleLines();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDraw();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawTextEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTextureFromImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTextureCubemap();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadRenderTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadRenderTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateTextureRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenTextureMipmaps();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTextureFilter();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTextureWrap();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureQuad();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureTiled();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexturePro();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureNPatch();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexturePoly();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void Fade();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorToInt();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorNormalize();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorFromNormalized();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorToHSV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorFromHSV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorAlpha();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorAlphaBlend();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetColor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPixelColor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetPixelColor();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPixelDataSize();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFontDefault();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFont();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontFromImage();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontFromMemory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageFontAtlas();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFontData();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFont();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawFPS();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextPro();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextCodepoint();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MeasureText();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MeasureTextEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphIndex();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphInfo();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphAtlasRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadCodepoints();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadCodepoints();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCodepointCount();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCodepoint();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CodepointToUTF8();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextCodepointsToUTF8();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextCopy();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextIsEqual();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextLength();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextFormat();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextSubtext();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextReplace();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextInsert();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextJoin();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextSplit();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextAppend();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextFindIndex();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToUpper();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToLower();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToPascal();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToInteger();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLine3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPoint3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircle3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangle3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleStrip3D();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCube();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeWires();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeWiresV();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeTextureRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphere();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphereEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphereWires();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinder();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderWires();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderWiresEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPlane();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRay();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawGrid();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModelFromMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelKeepMeshes();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetModelBoundingBox();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelWires();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelWiresEx();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBoundingBox();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboard();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboardRec();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboardPro();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UploadMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateMeshBuffer();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawMeshInstanced();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMeshBoundingBox();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshTangents();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshBinormals();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshPoly();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshPlane();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCube();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshSphere();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshHemiSphere();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCylinder();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCone();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshTorus();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshKnot();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshHeightmap();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCubicmap();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMaterials();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMaterialDefault();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMaterial();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMaterialTexture();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetModelMeshMaterial();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModelAnimations();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateModelAnimation();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelAnimation();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelAnimations();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsModelAnimationValid();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionSpheres();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionBoxes();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionBoxSphere();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionSphere();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionBox();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionModel();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionMesh();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionTriangle();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionQuad();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void InitAudioDevice();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CloseAudioDevice();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioDeviceReady();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMasterVolume();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWave();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWaveFromMemory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadSoundFromWave();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadWave();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportWave();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportWaveAsCode();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlaySound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeSound();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlaySoundMulti();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopSoundMulti();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetSoundsPlaying();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsSoundPlaying();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSoundVolume();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSoundPitch();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveFormat();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveCopy();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveCrop();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWaveSamples();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadWaveSamples();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMusicStreamFromMemory();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlayMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMusicStreamPlaying();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SeekMusicStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMusicVolume();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMusicPitch();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMusicTimeLength();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMusicTimePlayed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioStreamProcessed();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlayAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioStreamPlaying();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopAudioStream();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamVolume();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamPitch();

    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamBufferSizeDefault();

}
#pragma warning restore
