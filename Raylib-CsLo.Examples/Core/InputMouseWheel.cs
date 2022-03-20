// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] examples - Mouse wheel input
*
*   This test has been created using raylib 1.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class InputMouseWheel
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input mouse wheel");

        int boxPositionY = (screenHeight / 2) - 40;
        int scrollSpeed = 4;            // Scrolling speed in pixels

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            boxPositionY -= (int)GetMouseWheelMove() * scrollSpeed;



            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawRectangle((screenWidth / 2) - 40, boxPositionY, 80, 80, Maroon);

            DrawText("Use mouse wheel to move the cube up and down!", 10, 10, 20, Gray);
            DrawText(TextFormat("Box position Y: %03i", boxPositionY), 10, 40, 20, Lightgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
