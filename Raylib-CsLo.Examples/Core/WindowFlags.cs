// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - window flags
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class WindowFlags
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        // Possible window flags
        /*
        FLAG_VSYNC_HINT
        FLAG_FULLSCREEN_MODE    -> not working properly -> wrong scaling!
        FlagWindowResizable
        FLAG_WINDOW_UNDECORATED
        FLAG_WINDOW_TRANSPARENT
        FLAG_WINDOW_HIDDEN
        FLAG_WINDOW_MINIMIZED   -> Not supported on window creation
        FLAG_WINDOW_MAXIMIZED   -> Not supported on window creation
        FLAG_WINDOW_UNFOCUSED
        FLAG_WINDOW_TOPMOST
        FLAG_WINDOW_HIGHDPI     -> errors after minimize-resize, fb size is recalculated
        FLAG_WINDOW_ALWAYS_RUN
        FlagMsaa4xHint
        */

        // Set configuration flags for window creation
        //SetConfigFlags(FLAG_VSYNC_HINT | FlagMsaa4xHint | FLAG_WINDOW_HIGHDPI);
        InitWindow(screenWidth, screenHeight, "raylib [core] example - window flags");

        Vector2 ballPosition = new(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        Vector2 ballSpeed = new(5.0f, 4.0f);
        float ballRadius = 20;

        int framesCounter = 0;

        //SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyPressed(KeyF))
            {
                ToggleFullscreen();  // modifies window size when scaling!
            }

            if (IsKeyPressed(KeyR))
            {
                if (IsWindowState(FlagWindowResizable))
                {
                    ClearWindowState(FlagWindowResizable);
                }
                else
                {
                    SetWindowState(FlagWindowResizable);
                }
            }

            if (IsKeyPressed(KeyD))
            {
                if (IsWindowState(FlagWindowUndecorated))
                {
                    ClearWindowState(FlagWindowUndecorated);
                }
                else
                {
                    SetWindowState(FlagWindowUndecorated);
                }
            }

            if (IsKeyPressed(KeyH))
            {
                if (!IsWindowState(FlagWindowHidden))
                {
                    SetWindowState(FlagWindowHidden);
                }

                framesCounter = 0;
            }

            if (IsWindowState(FlagWindowHidden))
            {
                framesCounter++;
                if (framesCounter >= 240)
                {
                    ClearWindowState(FlagWindowHidden); // Show window after 3 seconds
                }
            }

            if (IsKeyPressed(KeyN))
            {
                if (!IsWindowState(FlagWindowMinimized))
                {
                    MinimizeWindow();
                }

                framesCounter = 0;
            }

            if (IsWindowState(FlagWindowMinimized))
            {
                framesCounter++;
                if (framesCounter >= 240)
                {
                    RestoreWindow(); // Restore window after 3 seconds
                }
            }

            if (IsKeyPressed(KeyM))
            {
                // NOTE: Requires FlagWindowResizable enabled!
                if (IsWindowState(FlagWindowMaximized))
                {
                    RestoreWindow();
                }
                else
                {
                    MaximizeWindow();
                }
            }

            if (IsKeyPressed(KeyU))
            {
                if (IsWindowState(FlagWindowUnfocused))
                {
                    ClearWindowState(FlagWindowUnfocused);
                }
                else
                {
                    SetWindowState(FlagWindowUnfocused);
                }
            }

            if (IsKeyPressed(KeyT))
            {
                if (IsWindowState(FlagWindowTopmost))
                {
                    ClearWindowState(FlagWindowTopmost);
                }
                else
                {
                    SetWindowState(FlagWindowTopmost);
                }
            }

            if (IsKeyPressed(KeyA))
            {
                if (IsWindowState(FlagWindowAlwaysRun))
                {
                    ClearWindowState(FlagWindowAlwaysRun);
                }
                else
                {
                    SetWindowState(FlagWindowAlwaysRun);
                }
            }

            if (IsKeyPressed(KeyV))
            {
                if (IsWindowState(FlagVsyncHint))
                {
                    ClearWindowState(FlagVsyncHint);
                }
                else
                {
                    SetWindowState(FlagVsyncHint);
                }
            }

            // Bouncing ball logic
            ballPosition.X += ballSpeed.X;
            ballPosition.Y += ballSpeed.Y;
            if ((ballPosition.X >= (GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius))
            {
                ballSpeed.X *= -1.0f;
            }

            if ((ballPosition.Y >= (GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius))
            {
                ballSpeed.Y *= -1.0f;
            }


            // Draw

            BeginDrawing();

            if (IsWindowState(FlagWindowTransparent))
            {
                ClearBackground(Blank);
            }
            else
            {
                ClearBackground(Raywhite);
            }

            DrawCircleV(ballPosition, ballRadius, Maroon);
            DrawRectangleLinesEx(new(0, 0, GetScreenWidth(), GetScreenHeight()), 4, Raywhite);

            DrawCircleV(GetMousePosition(), 10, Darkblue);

            DrawFPS(10, 10);

            DrawText(string.Format("Screen Size: [{0}, {1}]", GetScreenWidth(), GetScreenHeight()), 10, 40, 10, Green);

            // Draw window state info
            DrawText("Following flags can be set after window creation:", 10, 60, 10, Gray);
            if (IsWindowState(FlagFullscreenMode))
            {
                DrawText("[F] FLAG_FULLSCREEN_MODE: on", 10, 80, 10, Lime);
            }
            else
            {
                DrawText("[F] FLAG_FULLSCREEN_MODE: off", 10, 80, 10, Maroon);
            }

            if (IsWindowState(FlagWindowResizable))
            {
                DrawText("[R] FlagWindowResizable: on", 10, 100, 10, Lime);
            }
            else
            {
                DrawText("[R] FlagWindowResizable: off", 10, 100, 10, Maroon);
            }

            if (IsWindowState(FlagWindowUndecorated))
            {
                DrawText("[D] FLAG_WINDOW_UNDECORATED: on", 10, 120, 10, Lime);
            }
            else
            {
                DrawText("[D] FLAG_WINDOW_UNDECORATED: off", 10, 120, 10, Maroon);
            }

            if (IsWindowState(FlagWindowHidden))
            {
                DrawText("[H] FLAG_WINDOW_HIDDEN: on", 10, 140, 10, Lime);
            }
            else
            {
                DrawText("[H] FLAG_WINDOW_HIDDEN: off", 10, 140, 10, Maroon);
            }

            if (IsWindowState(FlagWindowMinimized))
            {
                DrawText("[N] FLAG_WINDOW_MINIMIZED: on", 10, 160, 10, Lime);
            }
            else
            {
                DrawText("[N] FLAG_WINDOW_MINIMIZED: off", 10, 160, 10, Maroon);
            }

            if (IsWindowState(FlagWindowMaximized))
            {
                DrawText("[M] FLAG_WINDOW_MAXIMIZED: on", 10, 180, 10, Lime);
            }
            else
            {
                DrawText("[M] FLAG_WINDOW_MAXIMIZED: off", 10, 180, 10, Maroon);
            }

            if (IsWindowState(FlagWindowUnfocused))
            {
                DrawText("[G] FLAG_WINDOW_UNFOCUSED: on", 10, 200, 10, Lime);
            }
            else
            {
                DrawText("[U] FLAG_WINDOW_UNFOCUSED: off", 10, 200, 10, Maroon);
            }

            if (IsWindowState(FlagWindowTopmost))
            {
                DrawText("[T] FLAG_WINDOW_TOPMOST: on", 10, 220, 10, Lime);
            }
            else
            {
                DrawText("[T] FLAG_WINDOW_TOPMOST: off", 10, 220, 10, Maroon);
            }

            if (IsWindowState(FlagWindowAlwaysRun))
            {
                DrawText("[A] FLAG_WINDOW_ALWAYS_RUN: on", 10, 240, 10, Lime);
            }
            else
            {
                DrawText("[A] FLAG_WINDOW_ALWAYS_RUN: off", 10, 240, 10, Maroon);
            }

            if (IsWindowState(FlagVsyncHint))
            {
                DrawText("[V] FLAG_VSYNC_HINT: on", 10, 260, 10, Lime);
            }
            else
            {
                DrawText("[V] FLAG_VSYNC_HINT: off", 10, 260, 10, Maroon);
            }

            DrawText("Following flags can only be set before window creation:", 10, 300, 10, Gray);
            if (IsWindowState(FlagWindowHighdpi))
            {
                DrawText("FLAG_WINDOW_HIGHDPI: on", 10, 320, 10, Lime);
            }
            else
            {
                DrawText("FLAG_WINDOW_HIGHDPI: off", 10, 320, 10, Maroon);
            }

            if (IsWindowState(FlagWindowTransparent))
            {
                DrawText("FLAG_WINDOW_TRANSPARENT: on", 10, 340, 10, Lime);
            }
            else
            {
                DrawText("FLAG_WINDOW_TRANSPARENT: off", 10, 340, 10, Maroon);
            }

            if (IsWindowState(FlagMsaa4xHint))
            {
                DrawText("FlagMsaa4xHint: on", 10, 360, 10, Lime);
            }
            else
            {
                DrawText("FlagMsaa4xHint: off", 10, 360, 10, Maroon);
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }


}
