// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Keyboard input
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Core;

public static class InputKeys
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - keyboard input");

        Vector2 ballPosition = new((float)screenWidth / 2, (float)screenHeight / 2);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyDown(KeyRight))
            {
                ballPosition.X += 2.0f;
            }

            if (IsKeyDown(KeyLeft))
            {
                ballPosition.X -= 2.0f;
            }

            if (IsKeyDown(KeyUp))
            {
                ballPosition.Y -= 2.0f;
            }

            if (IsKeyDown(KeyDown))
            {
                ballPosition.Y += 2.0f;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("move the ball with arrow keys", 10, 10, 20, Darkgray);

            DrawCircleV(ballPosition, 50, Maroon);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }
}
