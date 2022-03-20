// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Mouse input
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Core;

public static class InputMouse
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - mouse input");
        Color ballColor = Darkblue;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector2 ballPosition = GetMousePosition();

            if (IsMouseButtonPressed(MouseButtonLeft))
            {
                ballColor = Maroon;
            }
            else if (IsMouseButtonPressed(MouseButtonMiddle))
            {
                ballColor = Lime;
            }
            else if (IsMouseButtonPressed(MouseButtonRight))
            {
                ballColor = Darkblue;
            }
            else if (IsMouseButtonPressed(MouseButtonSide))
            {
                ballColor = Purple;
            }
            else if (IsMouseButtonPressed(MouseButtonExtra))
            {
                ballColor = Yellow;
            }
            else if (IsMouseButtonPressed(MouseButtonForward))
            {
                ballColor = Orange;
            }
            else if (IsMouseButtonPressed(MouseButtonBack))
            {
                ballColor = Beige;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawCircleV(ballPosition, 40, ballColor);

            DrawText("move ball with mouse and click mouse button to change color", 10, 10, 20, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
