// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - sprite explosion
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Anata and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class SpriteExplosion
{

    const int NUM_FRAMES_PER_LINE = 5;
    const int NUM_LINES = 5;

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - sprite explosion");

        InitAudioDevice();

        // Load explosion sound
        Sound fxBoom = LoadSound("resources/boom.wav");

        // Load explosion texture
        Texture2D explosion = LoadTexture("resources/explosion.png");

        // Init variables for animation
        float frameWidth = explosion.width / NUM_FRAMES_PER_LINE;   // Sprite one frame rectangle width
        float frameHeight = explosion.height / NUM_LINES;           // Sprite one frame rectangle height
        int currentFrame = 0;
        int currentLine = 0;

        Rectangle frameRec = new(0, 0, frameWidth, frameHeight);
        Vector2 position = new(0.0f, 0.0f);

        bool active = false;
        int framesCounter = 0;

        SetTargetFPS(120);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update


            // Check for mouse button pressed and activate explosion (if not active)
            if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT) && !active)
            {
                position = GetMousePosition();
                active = true;

                position.X -= frameWidth / 2.0f;
                position.Y -= frameHeight / 2.0f;

                PlaySound(fxBoom);
            }

            // Compute explosion animation frames
            if (active)
            {
                framesCounter++;

                if (framesCounter > 2)
                {
                    currentFrame++;

                    if (currentFrame >= NUM_FRAMES_PER_LINE)
                    {
                        currentFrame = 0;
                        currentLine++;

                        if (currentLine >= NUM_LINES)
                        {
                            currentLine = 0;
                            active = false;
                        }
                    }

                    framesCounter = 0;
                }
            }

            frameRec.X = frameWidth * currentFrame;
            frameRec.Y = frameHeight * currentLine;


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            // Draw explosion required frame rectangle
            if (active)
            {
                DrawTextureRec(explosion, frameRec, position, WHITE);
            }

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(explosion);   // Unload texture
        UnloadSound(fxBoom);        // Unload sound

        CloseAudioDevice();

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }
}
