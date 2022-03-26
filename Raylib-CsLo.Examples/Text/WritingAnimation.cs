// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Text;
/*******************************************************************************************
*
*   raylib [text] example - Text Writing Animation
*
*   This example has been created using raylib 2.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class WritingAnimation
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - text writing anim");

        string message = "This sample illustrates a text writing\nanimation effect! Check it out! ;)";

        int framesCounter = 0;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyDown(KeySpace))
            {
                framesCounter += 8;
            }
            else
            {
                framesCounter++;
            }

            if (IsKeyPressed(KeyEnter))
            {
                framesCounter = 0;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText(TextSubtext(message, 0, framesCounter / 10), 210, 160, 20, Maroon);

            DrawText("PRESS [ENTER] to RESTART!", 240, 260, 20, Lightgray);
            DrawText("PRESS [SPACE] to SPEED UP!", 239, 300, 20, Lightgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }


}
