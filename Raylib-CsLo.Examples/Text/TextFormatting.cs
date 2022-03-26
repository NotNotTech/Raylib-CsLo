// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Text;

/*******************************************************************************************
*
*   raylib [text] example - Text formatting
*
*   This example has been created using raylib 1.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class TextFormatting
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - text formatting");

        int score = 100020;
        int hiscore = 200450;
        int lives = 5;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // TODO: Update your variables here


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText(string.Format("Score: {0:8}", score), 200, 80, 20, Red);

            DrawText(string.Format("HiScore: {0:8}", hiscore), 200, 120, 20, Green);

            DrawText(string.Format("Lives: {0:2}", lives), 200, 160, 40, Blue);

            DrawText(string.Format("Elapsed Time: {0} ms", (GetFrameTime() * 1000).ToString("00.00")), 200, 220, 20, Black);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
