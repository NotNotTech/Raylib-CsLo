// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Input multitouch
*
*   This example has been created using raylib 2.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Berni (@Berni8k) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Berni (@Berni8k) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Core;

public static class InputMultitouch
{
    const int MAX_TOUCH_POINTS = 10;
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input multitouch");

        Vector2[] touchPositions = new Vector2[MAX_TOUCH_POINTS];

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // Get multiple touchpoints
            for (int i = 0; i < MAX_TOUCH_POINTS; ++i)
            {
                touchPositions[i] = GetTouchPosition(i);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            for (int i = 0; i < MAX_TOUCH_POINTS; ++i)
            {
                // Make sure point is not (0, 0) as this means there is no touch for it
                if ((touchPositions[i].X > 0) && (touchPositions[i].Y > 0))
                {
                    // Draw circle and touch index number
                    DrawCircleV(touchPositions[i], 34, Orange);
                    DrawText(i.ToString(), (int)touchPositions[i].X - 10, (int)touchPositions[i].Y - 70, 40, Black);
                }
            }

            DrawText("touch the screen at multiple locations to get multiple balls", 10, 10, 20, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }
}
