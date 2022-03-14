// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Playground;

using Raylib = Raylib_CsLo.RaylibS;

public static class Program
{
    public static void Main()
    {
        Raylib.InitWindow(1280, 720, "Hello, Raylib-CsLo");
        Raylib.SetTargetFPS(60);
        // Main game loop
        while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib.SKYBLUE);
            Raylib.DrawFPS(10, 10);
            Raylib.DrawText("Raylib is easy!!!", 640, 360, 50, Raylib.RED);
            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();
    }
}
