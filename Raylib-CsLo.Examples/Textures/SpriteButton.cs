// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - sprite button
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class SpriteButton
{

    const int NUM_FRAMES = 3;       // Number of frames (rectangles) for the button sprite texture

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - sprite button");

        InitAudioDevice();      // Initialize audio device

        Sound fxButton = LoadSound("resources/buttonfx.wav");   // Load button sound
        Texture2D button = LoadTexture("resources/button.png"); // Load button texture

        // Define frame rectangle for drawing
        float frameHeight = (float)button.height / NUM_FRAMES;
        Rectangle sourceRec = new(0, 0, button.width, frameHeight);

        // Define button bounds on screen
        Rectangle btnBounds = new((screenWidth / 2.0f) - (button.width / 2.0f), (screenHeight / 2.0f) - (button.height / NUM_FRAMES / 2.0f), button.width, frameHeight);

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector2 mousePoint = GetMousePosition();
            bool btnAction = false;

            int btnState;
            // Check button state
            if (CheckCollisionPointRec(mousePoint, btnBounds))
            {
                if (IsMouseButtonDown(MouseButtonLeft))
                {
                    btnState = 2;
                }
                else
                {
                    btnState = 1;
                }

                if (IsMouseButtonReleased(MouseButtonLeft))
                {
                    btnAction = true;
                }
            }
            else
            {
                btnState = 0;
            }

            if (btnAction)
            {
                PlaySound(fxButton);

                // TODO: Any desired action
            }

            // Calculate button frame rectangle to draw depending on button state
            sourceRec.Y = btnState * frameHeight;


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawTextureRec(button, sourceRec, new Vector2(btnBounds.X, btnBounds.Y), White); // Draw button frame

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(button);  // Unload button texture
        UnloadSound(fxButton);  // Unload sound

        CloseAudioDevice();     // Close audio device

        CloseWindow();          // Close window and OpenGL context



    }


}
