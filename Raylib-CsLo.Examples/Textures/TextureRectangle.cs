// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Texture loading and drawing a part defined by a rectangle
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class TextureRectangle
{

    const int MAX_FRAME_SPEED = 15;
    const int MIN_FRAME_SPEED = 1;

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [texture] example - texture rectangle");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D scarfy = LoadTexture("resources/scarfy.png");        // Texture loading

        Vector2 position = new(350.0f, 280.0f);
        Rectangle frameRec = new(0.0f, 0.0f, (float)scarfy.width / 6, scarfy.height);
        int currentFrame = 0;

        int framesCounter = 0;
        int framesSpeed = 8;            // Number of spritesheet frames shown by second

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            framesCounter++;

            if (framesCounter >= (60 / framesSpeed))
            {
                framesCounter = 0;
                currentFrame++;

                if (currentFrame > 5)
                {
                    currentFrame = 0;
                }

                frameRec.X = currentFrame * (float)scarfy.width / 6;
            }

            if (IsKeyPressed(KeyRight))
            {
                framesSpeed++;
            }
            else if (IsKeyPressed(KeyLeft))
            {
                framesSpeed--;
            }

            if (framesSpeed > MAX_FRAME_SPEED)
            {
                framesSpeed = MAX_FRAME_SPEED;
            }
            else if (framesSpeed < MIN_FRAME_SPEED)
            {
                framesSpeed = MIN_FRAME_SPEED;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawTexture(scarfy, 15, 40, White);
            DrawRectangleLines(15, 40, scarfy.width, scarfy.height, Lime);
            DrawRectangleLines(15 + (int)frameRec.X, 40 + (int)frameRec.Y, (int)frameRec.Width, (int)frameRec.Height, Red);

            DrawText("FRAME SPEED: ", 165, 210, 10, Darkgray);
            DrawText(string.Format("{0:2} FPS", framesSpeed), 575, 210, 10, Darkgray);
            DrawText("PRESS RIGHT/LEFT KEYS to CHANGE SPEED!", 290, 240, 10, Darkgray);

            for (int i = 0; i < MAX_FRAME_SPEED; i++)
            {
                if (i < framesSpeed)
                {
                    DrawRectangle(250 + (21 * i), 205, 20, 20, Red);
                }

                DrawRectangleLines(250 + (21 * i), 205, 20, 20, Maroon);
            }

            DrawTextureRec(scarfy, frameRec, position, White);  // Draw part of the texture

            DrawText("(c) Scarfy sprite by Eiden Marsal", screenWidth - 200, screenHeight - 20, 10, Gray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(scarfy);       // Texture unloading

        CloseWindow();                // Close window and OpenGL context



    }
}
