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

    public static int Example()
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

            DrawText(TextFormat("Score: %08i", score), 200, 80, 20, Red);

            DrawText(TextFormat("HiScore: %08i", hiscore), 200, 120, 20, Green);

            DrawText(TextFormat("Lives: %02i", lives), 200, 160, 40, Blue);

            DrawText(TextFormat("Elapsed Time: %02.02f ms", GetFrameTime() * 1000), 200, 220, 20, Black);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
