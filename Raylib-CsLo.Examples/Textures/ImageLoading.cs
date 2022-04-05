// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Image loading and texture creation
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class ImageLoading
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - image loading");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Image image = LoadImage("resources/raylib_logo.png");     // Loaded in CPU memory (RAM)
        Texture2D texture = LoadTextureFromImage(image);          // Image converted to texture, GPU memory (VRAM)
        UnloadImage(image);   // Once image has been converted to texture and uploaded to VRAM, it can be unloaded from RAM

        SetTargetFPS(60);     // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // TODO: Update your variables here


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawTexture(texture, (screenWidth / 2) - (texture.width / 2), (screenHeight / 2) - (texture.height / 2), White);

            DrawText("this IS a texture loaded from an image!", 300, 370, 10, Gray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);       // Texture unloading

        CloseWindow();                // Close window and OpenGL context



    }
}
