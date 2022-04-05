// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - easings ball anim
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class EasingsBallAnim
{

    // # include "extras/easings.h"                // Required for easing functions

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings ball anim");

        // Ball variable value to be animated with easings
        int ballPositionX = -100;
        int ballRadius = 20;
        float ballAlpha = 0.0f;

        int state = 0;
        int framesCounter = 0;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (state == 0)             // Move ball position X with easing
            {
                framesCounter++;
                ballPositionX = (int)EaseElasticOut(framesCounter, -100, (screenWidth / 2.0f) + 100, 120);

                if (framesCounter >= 120)
                {
                    framesCounter = 0;
                    state = 1;
                }
            }
            else if (state == 1)        // Increase ball radius with easing
            {
                framesCounter++;
                ballRadius = (int)EaseElasticIn(framesCounter, 20, 500, 200);

                if (framesCounter >= 200)
                {
                    framesCounter = 0;
                    state = 2;
                }
            }
            else if (state == 2)        // Change ball alpha with easing (background color blending)
            {
                framesCounter++;
                ballAlpha = EaseCubicOut(framesCounter, 0.0f, 1.0f, 200);

                if (framesCounter >= 200)
                {
                    framesCounter = 0;
                    state = 3;
                }
            }
            else if (state == 3)        // Reset state to play again
            {
                if (IsKeyPressed(KeyEnter))
                {
                    // Reset required variables to play again
                    ballPositionX = -100;
                    ballRadius = 20;
                    ballAlpha = 0.0f;
                    state = 0;
                }
            }

            if (IsKeyPressed(KeyR))
            {
                framesCounter = 0;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            if (state >= 2)
            {
                DrawRectangle(0, 0, screenWidth, screenHeight, Green);
            }

            DrawCircle(ballPositionX, 200, ballRadius, Fade(Red, 1.0f - ballAlpha));

            if (state == 3)
            {
                DrawText("PRESS [ENTER] TO PLAY AGAIN!", 240, 200, 20, Black);
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
