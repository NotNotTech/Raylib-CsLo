// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [texture] example - Image text drawing using TTF generated font
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class ImageText
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [texture] example - image text drawing");

        Image parrots = LoadImage("resources/parrots.png"); // Load image in CPU memory (RAM)

        // TTF Font loading with custom generation parameters
        Font font = LoadFontEx("resources/KAISG.ttf", 64, IntPtr.Zero, 0);

        // Draw over image using custom font
        ImageDrawTextEx(ref parrots, font, "[Parrots font drawing]", new Vector2(20.0f, 20.0f), font.baseSize, 0.0f, Red);

        Texture2D texture = LoadTextureFromImage(parrots);  // Image converted to texture, uploaded to GPU memory (VRAM)
        UnloadImage(parrots);   // Once image has been converted to texture and uploaded to VRAM, it can be unloaded from RAM

        Vector2 position = new((screenWidth / 2) - (texture.width / 2), (screenHeight / 2) - (texture.height / 2) - 20);


        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {

            bool showFont;
            // Update

            if (IsKeyDown(KeySpace))
            {
                showFont = true;
            }
            else
            {
                showFont = false;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            if (!showFont)
            {
                // Draw texture with text already drawn inside
                DrawTextureV(texture, position, White);

                // Draw text directly using sprite font
                DrawTextEx(font, "[Parrots font drawing]", new Vector2(position.X + 20,
                           position.Y + 20 + 280), font.baseSize, 0.0f, White);
            }

            else
            {
                DrawTexture(font.texture, (screenWidth / 2) - (font.texture.width / 2), 50, Black);
            }

            DrawText("PRESS SPACE to SHOW FONT ATLAS USED", 290, 420, 10, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);     // Texture unloading

        UnloadFont(font);           // Unload custom font

        CloseWindow();              // Close window and OpenGL context



    }

}
