// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Image loading and drawing on it
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class ImageDrawing
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - image drawing");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Image cat = LoadImage("resources/cat.png");             // Load image in CPU memory (RAM)
        ImageCrop(ref cat, new Rectangle(100, 10, 280, 380));      // Crop an image piece
        ImageFlipHorizontal(ref cat);                              // Flip cropped image horizontally
        ImageResize(ref cat, 150, 200);                            // Resize flipped-cropped image

        Image parrots = LoadImage("resources/parrots.png");     // Load image in CPU memory (RAM)

        // Draw one image over the other with a scaling of 1.5f
        ImageDraw(ref parrots, cat, new Rectangle(0, 0, cat.width, cat.height), new Rectangle(30, 40, cat.width * 1.5f, cat.height * 1.5f), White);
        ImageCrop(ref parrots, new Rectangle(0, 50, parrots.width, (float)parrots.height - 100)); // Crop resulting image

        // Draw on the image with a few image draw methods
        ImageDrawPixel(ref parrots, 10, 10, Raywhite);
        ImageDrawCircle(ref parrots, 10, 10, 5, Raywhite);
        ImageDrawRectangle(ref parrots, 5, 20, 10, 10, Raywhite);

        UnloadImage(cat);       // Unload image from RAM

        // Load custom font for frawing on image
        Font font = LoadFont("resources/custom_jupiter_crash.png");

        // Draw over image using custom font
        ImageDrawTextEx(ref parrots, font, "PARROTS & CAT", new Vector2(300, 230), font.baseSize, -2, White);

        UnloadFont(font);       // Unload custom font (already drawn used on image)

        Texture2D texture = LoadTextureFromImage(parrots);      // Image converted to texture, uploaded to GPU memory (VRAM)
        UnloadImage(parrots);   // Once image has been converted to texture and uploaded to VRAM, it can be unloaded from RAM

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // TODO: Update your variables here


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawTexture(texture, (screenWidth / 2) - (texture.width / 2), (screenHeight / 2) - (texture.height / 2) - 40, White);
            DrawRectangleLines((screenWidth / 2) - (texture.width / 2), (screenHeight / 2) - (texture.height / 2) - 40, texture.width, texture.height, Darkgray);

            DrawText("We are drawing only one texture from various images composed!", 240, 350, 10, Darkgray);
            DrawText("Source images have been cropped, scaled, flipped and copied one over the other.", 190, 370, 10, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);       // Texture unloading

        CloseWindow();                // Close window and OpenGL context



    }

}
