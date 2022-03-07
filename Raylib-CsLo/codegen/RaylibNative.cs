#pragma warning disable
namespace Raylib_CsLo;

using System.Runtime.InteropServices;

public unsafe partial class RaylibN
{
    // 0 InitWindow
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void InitWindow();
    // 1 WindowShouldClose
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WindowShouldClose();
    // 2 CloseWindow
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CloseWindow();
    // 3 IsWindowReady
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowReady();
    // 4 IsWindowFullscreen
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowFullscreen();
    // 5 IsWindowHidden
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowHidden();
    // 6 IsWindowMinimized
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowMinimized();
    // 7 IsWindowMaximized
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowMaximized();
    // 8 IsWindowFocused
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowFocused();
    // 9 IsWindowResized
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowResized();
    // 10 IsWindowState
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsWindowState();
    // 11 SetWindowState
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowState();
    // 12 ClearWindowState
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearWindowState();
    // 13 ToggleFullscreen
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ToggleFullscreen();
    // 14 MaximizeWindow
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MaximizeWindow();
    // 15 MinimizeWindow
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MinimizeWindow();
    // 16 RestoreWindow
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void RestoreWindow();
    // 17 SetWindowIcon
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowIcon();
    // 18 SetWindowTitle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowTitle();
    // 19 SetWindowPosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowPosition();
    // 20 SetWindowMonitor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowMonitor();
    // 21 SetWindowMinSize
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowMinSize();
    // 22 SetWindowSize
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetWindowSize();
    // 23 GetWindowHandle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowHandle();
    // 24 GetScreenWidth
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenWidth();
    // 25 GetScreenHeight
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenHeight();
    // 26 GetMonitorCount
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorCount();
    // 27 GetCurrentMonitor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCurrentMonitor();
    // 28 GetMonitorPosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPosition();
    // 29 GetMonitorWidth
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorWidth();
    // 30 GetMonitorHeight
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorHeight();
    // 31 GetMonitorPhysicalWidth
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPhysicalWidth();
    // 32 GetMonitorPhysicalHeight
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorPhysicalHeight();
    // 33 GetMonitorRefreshRate
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorRefreshRate();
    // 34 GetWindowPosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowPosition();
    // 35 GetWindowScaleDPI
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWindowScaleDPI();
    // 36 GetMonitorName
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMonitorName();
    // 37 SetClipboardText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetClipboardText();
    // 38 GetClipboardText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetClipboardText();
    // 39 SwapScreenBuffer
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SwapScreenBuffer();
    // 40 PollInputEvents
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PollInputEvents();
    // 41 WaitTime
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaitTime();
    // 42 ShowCursor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ShowCursor();
    // 43 HideCursor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void HideCursor();
    // 44 IsCursorHidden
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsCursorHidden();
    // 45 EnableCursor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EnableCursor();
    // 46 DisableCursor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DisableCursor();
    // 47 IsCursorOnScreen
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsCursorOnScreen();
    // 48 ClearBackground
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearBackground();
    // 49 BeginDrawing
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginDrawing();
    // 50 EndDrawing
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndDrawing();
    // 51 BeginMode2D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginMode2D();
    // 52 EndMode2D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndMode2D();
    // 53 BeginMode3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginMode3D();
    // 54 EndMode3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndMode3D();
    // 55 BeginTextureMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginTextureMode();
    // 56 EndTextureMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndTextureMode();
    // 57 BeginShaderMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginShaderMode();
    // 58 EndShaderMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndShaderMode();
    // 59 BeginBlendMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginBlendMode();
    // 60 EndBlendMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndBlendMode();
    // 61 BeginScissorMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginScissorMode();
    // 62 EndScissorMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndScissorMode();
    // 63 BeginVrStereoMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void BeginVrStereoMode();
    // 64 EndVrStereoMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EndVrStereoMode();
    // 65 LoadVrStereoConfig
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadVrStereoConfig();
    // 66 UnloadVrStereoConfig
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadVrStereoConfig();
    // 67 LoadShader
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadShader();
    // 68 LoadShaderFromMemory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadShaderFromMemory();
    // 69 GetShaderLocation
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetShaderLocation();
    // 70 GetShaderLocationAttrib
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetShaderLocationAttrib();
    // 71 SetShaderValue
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValue();
    // 72 SetShaderValueV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueV();
    // 73 SetShaderValueMatrix
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueMatrix();
    // 74 SetShaderValueTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShaderValueTexture();
    // 75 UnloadShader
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadShader();
    // 76 GetMouseRay
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseRay();
    // 77 GetCameraMatrix
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCameraMatrix();
    // 78 GetCameraMatrix2D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCameraMatrix2D();
    // 79 GetWorldToScreen
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreen();
    // 80 GetWorldToScreenEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreenEx();
    // 81 GetWorldToScreen2D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorldToScreen2D();
    // 82 GetScreenToWorld2D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetScreenToWorld2D();
    // 83 SetTargetFPS
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTargetFPS();
    // 84 GetFPS
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFPS();
    // 85 GetFrameTime
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFrameTime();
    // 86 GetTime
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTime();
    // 87 GetRandomValue
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRandomValue();
    // 88 SetRandomSeed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetRandomSeed();
    // 89 TakeScreenshot
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TakeScreenshot();
    // 90 SetConfigFlags
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetConfigFlags();
    // 91 TraceLog
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TraceLog();
    // 92 SetTraceLogLevel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTraceLogLevel();
    // 93 MemAlloc
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemAlloc();
    // 94 MemRealloc
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemRealloc();
    // 95 MemFree
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MemFree();
    // 96 SetTraceLogCallback
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTraceLogCallback();
    // 97 SetLoadFileDataCallback
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoadFileDataCallback();
    // 98 SetSaveFileDataCallback
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSaveFileDataCallback();
    // 99 SetLoadFileTextCallback
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetLoadFileTextCallback();
    // 100 SetSaveFileTextCallback
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSaveFileTextCallback();
    // 101 LoadFileData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFileData();
    // 102 UnloadFileData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFileData();
    // 103 SaveFileData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveFileData();
    // 104 LoadFileText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFileText();
    // 105 UnloadFileText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFileText();
    // 106 SaveFileText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveFileText();
    // 107 FileExists
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void FileExists();
    // 108 DirectoryExists
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DirectoryExists();
    // 109 IsFileExtension
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsFileExtension();
    // 110 GetFileExtension
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileExtension();
    // 111 GetFileName
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileName();
    // 112 GetFileNameWithoutExt
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileNameWithoutExt();
    // 113 GetDirectoryPath
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDirectoryPath();
    // 114 GetPrevDirectoryPath
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPrevDirectoryPath();
    // 115 GetWorkingDirectory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetWorkingDirectory();
    // 116 GetDirectoryFiles
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDirectoryFiles();
    // 117 ClearDirectoryFiles
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearDirectoryFiles();
    // 118 ChangeDirectory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ChangeDirectory();
    // 119 IsFileDropped
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsFileDropped();
    // 120 GetDroppedFiles
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetDroppedFiles();
    // 121 ClearDroppedFiles
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ClearDroppedFiles();
    // 122 GetFileModTime
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFileModTime();
    // 123 CompressData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CompressData();
    // 124 DecompressData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DecompressData();
    // 125 EncodeDataBase64
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void EncodeDataBase64();
    // 126 DecodeDataBase64
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DecodeDataBase64();
    // 127 SaveStorageValue
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SaveStorageValue();
    // 128 LoadStorageValue
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadStorageValue();
    // 129 OpenURL
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void OpenURL();
    // 130 IsKeyPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyPressed();
    // 131 IsKeyDown
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyDown();
    // 132 IsKeyReleased
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyReleased();
    // 133 IsKeyUp
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsKeyUp();
    // 134 SetExitKey
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetExitKey();
    // 135 GetKeyPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetKeyPressed();
    // 136 GetCharPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCharPressed();
    // 137 IsGamepadAvailable
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadAvailable();
    // 138 GetGamepadName
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadName();
    // 139 IsGamepadButtonPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonPressed();
    // 140 IsGamepadButtonDown
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonDown();
    // 141 IsGamepadButtonReleased
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonReleased();
    // 142 IsGamepadButtonUp
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGamepadButtonUp();
    // 143 GetGamepadButtonPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadButtonPressed();
    // 144 GetGamepadAxisCount
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadAxisCount();
    // 145 GetGamepadAxisMovement
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGamepadAxisMovement();
    // 146 SetGamepadMappings
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetGamepadMappings();
    // 147 IsMouseButtonPressed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonPressed();
    // 148 IsMouseButtonDown
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonDown();
    // 149 IsMouseButtonReleased
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonReleased();
    // 150 IsMouseButtonUp
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMouseButtonUp();
    // 151 GetMouseX
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseX();
    // 152 GetMouseY
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseY();
    // 153 GetMousePosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMousePosition();
    // 154 GetMouseDelta
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseDelta();
    // 155 SetMousePosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMousePosition();
    // 156 SetMouseOffset
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseOffset();
    // 157 SetMouseScale
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseScale();
    // 158 GetMouseWheelMove
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMouseWheelMove();
    // 159 SetMouseCursor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMouseCursor();
    // 160 GetTouchX
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchX();
    // 161 GetTouchY
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchY();
    // 162 GetTouchPosition
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPosition();
    // 163 GetTouchPointId
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPointId();
    // 164 GetTouchPointCount
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetTouchPointCount();
    // 165 SetGesturesEnabled
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetGesturesEnabled();
    // 166 IsGestureDetected
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsGestureDetected();
    // 167 GetGestureDetected
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDetected();
    // 168 GetGestureHoldDuration
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureHoldDuration();
    // 169 GetGestureDragVector
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDragVector();
    // 170 GetGestureDragAngle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGestureDragAngle();
    // 171 GetGesturePinchVector
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGesturePinchVector();
    // 172 GetGesturePinchAngle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGesturePinchAngle();
    // 173 SetCameraMode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraMode();
    // 174 UpdateCamera
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateCamera();
    // 175 SetCameraPanControl
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraPanControl();
    // 176 SetCameraAltControl
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraAltControl();
    // 177 SetCameraSmoothZoomControl
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraSmoothZoomControl();
    // 178 SetCameraMoveControls
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetCameraMoveControls();
    // 179 SetShapesTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetShapesTexture();
    // 180 DrawPixel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPixel();
    // 181 DrawPixelV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPixelV();
    // 182 DrawLine
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLine();
    // 183 DrawLineV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineV();
    // 184 DrawLineEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineEx();
    // 185 DrawLineBezier
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezier();
    // 186 DrawLineBezierQuad
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezierQuad();
    // 187 DrawLineBezierCubic
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineBezierCubic();
    // 188 DrawLineStrip
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLineStrip();
    // 189 DrawCircle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircle();
    // 190 DrawCircleSector
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleSector();
    // 191 DrawCircleSectorLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleSectorLines();
    // 192 DrawCircleGradient
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleGradient();
    // 193 DrawCircleV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleV();
    // 194 DrawCircleLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircleLines();
    // 195 DrawEllipse
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawEllipse();
    // 196 DrawEllipseLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawEllipseLines();
    // 197 DrawRing
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRing();
    // 198 DrawRingLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRingLines();
    // 199 DrawRectangle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangle();
    // 200 DrawRectangleV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleV();
    // 201 DrawRectangleRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRec();
    // 202 DrawRectanglePro
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectanglePro();
    // 203 DrawRectangleGradientV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientV();
    // 204 DrawRectangleGradientH
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientH();
    // 205 DrawRectangleGradientEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleGradientEx();
    // 206 DrawRectangleLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleLines();
    // 207 DrawRectangleLinesEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleLinesEx();
    // 208 DrawRectangleRounded
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRounded();
    // 209 DrawRectangleRoundedLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRectangleRoundedLines();
    // 210 DrawTriangle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangle();
    // 211 DrawTriangleLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleLines();
    // 212 DrawTriangleFan
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleFan();
    // 213 DrawTriangleStrip
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleStrip();
    // 214 DrawPoly
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPoly();
    // 215 DrawPolyLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPolyLines();
    // 216 DrawPolyLinesEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPolyLinesEx();
    // 217 CheckCollisionRecs
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionRecs();
    // 218 CheckCollisionCircles
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionCircles();
    // 219 CheckCollisionCircleRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionCircleRec();
    // 220 CheckCollisionPointRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointRec();
    // 221 CheckCollisionPointCircle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointCircle();
    // 222 CheckCollisionPointTriangle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointTriangle();
    // 223 CheckCollisionLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionLines();
    // 224 CheckCollisionPointLine
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionPointLine();
    // 225 GetCollisionRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCollisionRec();
    // 226 LoadImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImage();
    // 227 LoadImageRaw
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageRaw();
    // 228 LoadImageAnim
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageAnim();
    // 229 LoadImageFromMemory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromMemory();
    // 230 LoadImageFromTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromTexture();
    // 231 LoadImageFromScreen
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageFromScreen();
    // 232 UnloadImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImage();
    // 233 ExportImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportImage();
    // 234 ExportImageAsCode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportImageAsCode();
    // 235 GenImageColor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageColor();
    // 236 GenImageGradientV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientV();
    // 237 GenImageGradientH
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientH();
    // 238 GenImageGradientRadial
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageGradientRadial();
    // 239 GenImageChecked
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageChecked();
    // 240 GenImageWhiteNoise
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageWhiteNoise();
    // 241 GenImageCellular
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageCellular();
    // 242 ImageCopy
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageCopy();
    // 243 ImageFromImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFromImage();
    // 244 ImageText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageText();
    // 245 ImageTextEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageTextEx();
    // 246 ImageFormat
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFormat();
    // 247 ImageToPOT
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageToPOT();
    // 248 ImageCrop
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageCrop();
    // 249 ImageAlphaCrop
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaCrop();
    // 250 ImageAlphaClear
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaClear();
    // 251 ImageAlphaMask
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaMask();
    // 252 ImageAlphaPremultiply
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageAlphaPremultiply();
    // 253 ImageResize
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResize();
    // 254 ImageResizeNN
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResizeNN();
    // 255 ImageResizeCanvas
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageResizeCanvas();
    // 256 ImageMipmaps
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageMipmaps();
    // 257 ImageDither
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDither();
    // 258 ImageFlipVertical
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFlipVertical();
    // 259 ImageFlipHorizontal
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageFlipHorizontal();
    // 260 ImageRotateCW
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageRotateCW();
    // 261 ImageRotateCCW
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageRotateCCW();
    // 262 ImageColorTint
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorTint();
    // 263 ImageColorInvert
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorInvert();
    // 264 ImageColorGrayscale
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorGrayscale();
    // 265 ImageColorContrast
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorContrast();
    // 266 ImageColorBrightness
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorBrightness();
    // 267 ImageColorReplace
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageColorReplace();
    // 268 LoadImageColors
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImageColors();
    // 269 LoadImagePalette
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadImagePalette();
    // 270 UnloadImageColors
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImageColors();
    // 271 UnloadImagePalette
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadImagePalette();
    // 272 GetImageAlphaBorder
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetImageAlphaBorder();
    // 273 GetImageColor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetImageColor();
    // 274 ImageClearBackground
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageClearBackground();
    // 275 ImageDrawPixel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawPixel();
    // 276 ImageDrawPixelV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawPixelV();
    // 277 ImageDrawLine
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawLine();
    // 278 ImageDrawLineV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawLineV();
    // 279 ImageDrawCircle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawCircle();
    // 280 ImageDrawCircleV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawCircleV();
    // 281 ImageDrawRectangle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangle();
    // 282 ImageDrawRectangleV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleV();
    // 283 ImageDrawRectangleRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleRec();
    // 284 ImageDrawRectangleLines
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawRectangleLines();
    // 285 ImageDraw
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDraw();
    // 286 ImageDrawText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawText();
    // 287 ImageDrawTextEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ImageDrawTextEx();
    // 288 LoadTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTexture();
    // 289 LoadTextureFromImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTextureFromImage();
    // 290 LoadTextureCubemap
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadTextureCubemap();
    // 291 LoadRenderTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadRenderTexture();
    // 292 UnloadTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadTexture();
    // 293 UnloadRenderTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadRenderTexture();
    // 294 UpdateTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateTexture();
    // 295 UpdateTextureRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateTextureRec();
    // 296 GenTextureMipmaps
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenTextureMipmaps();
    // 297 SetTextureFilter
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTextureFilter();
    // 298 SetTextureWrap
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetTextureWrap();
    // 299 DrawTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexture();
    // 300 DrawTextureV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureV();
    // 301 DrawTextureEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureEx();
    // 302 DrawTextureRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureRec();
    // 303 DrawTextureQuad
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureQuad();
    // 304 DrawTextureTiled
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureTiled();
    // 305 DrawTexturePro
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexturePro();
    // 306 DrawTextureNPatch
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextureNPatch();
    // 307 DrawTexturePoly
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTexturePoly();
    // 308 Fade
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void Fade();
    // 309 ColorToInt
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorToInt();
    // 310 ColorNormalize
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorNormalize();
    // 311 ColorFromNormalized
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorFromNormalized();
    // 312 ColorToHSV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorToHSV();
    // 313 ColorFromHSV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorFromHSV();
    // 314 ColorAlpha
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorAlpha();
    // 315 ColorAlphaBlend
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ColorAlphaBlend();
    // 316 GetColor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetColor();
    // 317 GetPixelColor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPixelColor();
    // 318 SetPixelColor
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetPixelColor();
    // 319 GetPixelDataSize
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetPixelDataSize();
    // 320 GetFontDefault
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetFontDefault();
    // 321 LoadFont
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFont();
    // 322 LoadFontEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontEx();
    // 323 LoadFontFromImage
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontFromImage();
    // 324 LoadFontFromMemory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontFromMemory();
    // 325 LoadFontData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadFontData();
    // 326 GenImageFontAtlas
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenImageFontAtlas();
    // 327 UnloadFontData
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFontData();
    // 328 UnloadFont
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadFont();
    // 329 DrawFPS
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawFPS();
    // 330 DrawText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawText();
    // 331 DrawTextEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextEx();
    // 332 DrawTextPro
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextPro();
    // 333 DrawTextCodepoint
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTextCodepoint();
    // 334 MeasureText
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MeasureText();
    // 335 MeasureTextEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void MeasureTextEx();
    // 336 GetGlyphIndex
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphIndex();
    // 337 GetGlyphInfo
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphInfo();
    // 338 GetGlyphAtlasRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetGlyphAtlasRec();
    // 339 LoadCodepoints
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadCodepoints();
    // 340 UnloadCodepoints
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadCodepoints();
    // 341 GetCodepointCount
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCodepointCount();
    // 342 GetCodepoint
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetCodepoint();
    // 343 CodepointToUTF8
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CodepointToUTF8();
    // 344 TextCodepointsToUTF8
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextCodepointsToUTF8();
    // 345 TextCopy
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextCopy();
    // 346 TextIsEqual
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextIsEqual();
    // 347 TextLength
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextLength();
    // 348 TextFormat
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextFormat();
    // 349 TextSubtext
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextSubtext();
    // 350 TextReplace
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextReplace();
    // 351 TextInsert
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextInsert();
    // 352 TextJoin
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextJoin();
    // 353 TextSplit
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextSplit();
    // 354 TextAppend
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextAppend();
    // 355 TextFindIndex
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextFindIndex();
    // 356 TextToUpper
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToUpper();
    // 357 TextToLower
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToLower();
    // 358 TextToPascal
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToPascal();
    // 359 TextToInteger
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void TextToInteger();
    // 360 DrawLine3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawLine3D();
    // 361 DrawPoint3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPoint3D();
    // 362 DrawCircle3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCircle3D();
    // 363 DrawTriangle3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangle3D();
    // 364 DrawTriangleStrip3D
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawTriangleStrip3D();
    // 365 DrawCube
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCube();
    // 366 DrawCubeV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeV();
    // 367 DrawCubeWires
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeWires();
    // 368 DrawCubeWiresV
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeWiresV();
    // 369 DrawCubeTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeTexture();
    // 370 DrawCubeTextureRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCubeTextureRec();
    // 371 DrawSphere
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphere();
    // 372 DrawSphereEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphereEx();
    // 373 DrawSphereWires
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawSphereWires();
    // 374 DrawCylinder
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinder();
    // 375 DrawCylinderEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderEx();
    // 376 DrawCylinderWires
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderWires();
    // 377 DrawCylinderWiresEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawCylinderWiresEx();
    // 378 DrawPlane
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawPlane();
    // 379 DrawRay
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawRay();
    // 380 DrawGrid
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawGrid();
    // 381 LoadModel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModel();
    // 382 LoadModelFromMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModelFromMesh();
    // 383 UnloadModel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModel();
    // 384 UnloadModelKeepMeshes
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelKeepMeshes();
    // 385 GetModelBoundingBox
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetModelBoundingBox();
    // 386 DrawModel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModel();
    // 387 DrawModelEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelEx();
    // 388 DrawModelWires
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelWires();
    // 389 DrawModelWiresEx
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawModelWiresEx();
    // 390 DrawBoundingBox
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBoundingBox();
    // 391 DrawBillboard
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboard();
    // 392 DrawBillboardRec
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboardRec();
    // 393 DrawBillboardPro
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawBillboardPro();
    // 394 UploadMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UploadMesh();
    // 395 UpdateMeshBuffer
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateMeshBuffer();
    // 396 UnloadMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMesh();
    // 397 DrawMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawMesh();
    // 398 DrawMeshInstanced
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void DrawMeshInstanced();
    // 399 ExportMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportMesh();
    // 400 GetMeshBoundingBox
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMeshBoundingBox();
    // 401 GenMeshTangents
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshTangents();
    // 402 GenMeshBinormals
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshBinormals();
    // 403 GenMeshPoly
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshPoly();
    // 404 GenMeshPlane
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshPlane();
    // 405 GenMeshCube
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCube();
    // 406 GenMeshSphere
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshSphere();
    // 407 GenMeshHemiSphere
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshHemiSphere();
    // 408 GenMeshCylinder
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCylinder();
    // 409 GenMeshCone
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCone();
    // 410 GenMeshTorus
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshTorus();
    // 411 GenMeshKnot
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshKnot();
    // 412 GenMeshHeightmap
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshHeightmap();
    // 413 GenMeshCubicmap
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GenMeshCubicmap();
    // 414 LoadMaterials
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMaterials();
    // 415 LoadMaterialDefault
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMaterialDefault();
    // 416 UnloadMaterial
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMaterial();
    // 417 SetMaterialTexture
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMaterialTexture();
    // 418 SetModelMeshMaterial
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetModelMeshMaterial();
    // 419 LoadModelAnimations
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadModelAnimations();
    // 420 UpdateModelAnimation
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateModelAnimation();
    // 421 UnloadModelAnimation
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelAnimation();
    // 422 UnloadModelAnimations
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadModelAnimations();
    // 423 IsModelAnimationValid
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsModelAnimationValid();
    // 424 CheckCollisionSpheres
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionSpheres();
    // 425 CheckCollisionBoxes
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionBoxes();
    // 426 CheckCollisionBoxSphere
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CheckCollisionBoxSphere();
    // 427 GetRayCollisionSphere
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionSphere();
    // 428 GetRayCollisionBox
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionBox();
    // 429 GetRayCollisionModel
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionModel();
    // 430 GetRayCollisionMesh
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionMesh();
    // 431 GetRayCollisionTriangle
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionTriangle();
    // 432 GetRayCollisionQuad
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetRayCollisionQuad();
    // 433 InitAudioDevice
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void InitAudioDevice();
    // 434 CloseAudioDevice
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void CloseAudioDevice();
    // 435 IsAudioDeviceReady
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioDeviceReady();
    // 436 SetMasterVolume
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMasterVolume();
    // 437 LoadWave
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWave();
    // 438 LoadWaveFromMemory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWaveFromMemory();
    // 439 LoadSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadSound();
    // 440 LoadSoundFromWave
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadSoundFromWave();
    // 441 UpdateSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateSound();
    // 442 UnloadWave
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadWave();
    // 443 UnloadSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadSound();
    // 444 ExportWave
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportWave();
    // 445 ExportWaveAsCode
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ExportWaveAsCode();
    // 446 PlaySound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlaySound();
    // 447 StopSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopSound();
    // 448 PauseSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseSound();
    // 449 ResumeSound
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeSound();
    // 450 PlaySoundMulti
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlaySoundMulti();
    // 451 StopSoundMulti
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopSoundMulti();
    // 452 GetSoundsPlaying
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetSoundsPlaying();
    // 453 IsSoundPlaying
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsSoundPlaying();
    // 454 SetSoundVolume
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSoundVolume();
    // 455 SetSoundPitch
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetSoundPitch();
    // 456 WaveFormat
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveFormat();
    // 457 WaveCopy
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveCopy();
    // 458 WaveCrop
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void WaveCrop();
    // 459 LoadWaveSamples
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadWaveSamples();
    // 460 UnloadWaveSamples
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadWaveSamples();
    // 461 LoadMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMusicStream();
    // 462 LoadMusicStreamFromMemory
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadMusicStreamFromMemory();
    // 463 UnloadMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadMusicStream();
    // 464 PlayMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlayMusicStream();
    // 465 IsMusicStreamPlaying
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsMusicStreamPlaying();
    // 466 UpdateMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateMusicStream();
    // 467 StopMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopMusicStream();
    // 468 PauseMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseMusicStream();
    // 469 ResumeMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeMusicStream();
    // 470 SeekMusicStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SeekMusicStream();
    // 471 SetMusicVolume
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMusicVolume();
    // 472 SetMusicPitch
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetMusicPitch();
    // 473 GetMusicTimeLength
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMusicTimeLength();
    // 474 GetMusicTimePlayed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void GetMusicTimePlayed();
    // 475 LoadAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void LoadAudioStream();
    // 476 UnloadAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UnloadAudioStream();
    // 477 UpdateAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void UpdateAudioStream();
    // 478 IsAudioStreamProcessed
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioStreamProcessed();
    // 479 PlayAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PlayAudioStream();
    // 480 PauseAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void PauseAudioStream();
    // 481 ResumeAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void ResumeAudioStream();
    // 482 IsAudioStreamPlaying
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void IsAudioStreamPlaying();
    // 483 StopAudioStream
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void StopAudioStream();
    // 484 SetAudioStreamVolume
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamVolume();
    // 485 SetAudioStreamPitch
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamPitch();
    // 486 SetAudioStreamBufferSizeDefault
    [DllImport("raylib", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void SetAudioStreamBufferSizeDefault();
}
#pragma warning restore
