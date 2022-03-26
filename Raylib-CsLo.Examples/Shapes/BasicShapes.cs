// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - Draw basic shapes 2d (rectangle, circle, line...)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class BasicShapes
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - basic shapes drawing");

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // TODO: Update your variables here


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("some basic shapes available on raylib", 20, 20, 20, Darkgray);

            // Circle shapes and lines
            DrawCircle(screenWidth / 5, 120, 35, Darkblue);
            DrawCircleGradient(screenWidth / 5, 220, 60, Green, Skyblue);
            DrawCircleLines(screenWidth / 5, 340, 80, Darkblue);

            // Rectangle shapes and ines
            DrawRectangle((screenWidth / 4 * 2) - 60, 100, 120, 60, Red);
            DrawRectangleGradientH((screenWidth / 4 * 2) - 90, 170, 180, 130, Maroon, Gold);
            DrawRectangleLines((screenWidth / 4 * 2) - 40, 320, 80, 60, Orange);  // NOTE: Uses QUADS internally, not lines

            // Triangle shapes and lines
            DrawTriangle(new Vector2(screenWidth / 4.0f * 3.0f, 80.0f),
                         new Vector2((screenWidth / 4.0f * 3.0f) - 60.0f, 150.0f),
                         new Vector2((screenWidth / 4.0f * 3.0f) + 60.0f, 150.0f), Violet);

            DrawTriangleLines(new Vector2(screenWidth / 4.0f * 3.0f, 160.0f),
                              new Vector2((screenWidth / 4.0f * 3.0f) - 20.0f, 230.0f),
                              new Vector2((screenWidth / 4.0f * 3.0f) + 20.0f, 230.0f), Darkblue);

            // Polygon shapes and lines
            DrawPoly(new Vector2(screenWidth / 4.0f * 3, 320), 6, 80, 0, Brown);
            DrawPolyLinesEx(new Vector2(screenWidth / 4.0f * 3, 320), 6, 80, 0, 6, Beige);

            // NOTE: We draw all LINES based shapes together to optimize internal drawing,
            // this way, all LINES are rendered in a single draw pass
            DrawLine(18, 42, screenWidth - 18, 42, Black);
            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
