// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - blend modes
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Karlo Licudine (@accidentalrebel) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020 Karlo Licudine (@accidentalrebel)
*
********************************************************************************************/

public static unsafe class BlendModes
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - blend modes");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Image bgImage = LoadImage("resources/cyberpunk_street_background.png");     // Loaded in CPU memory (RAM)
        Texture2D bgTexture = LoadTextureFromImage(bgImage);          // Image converted to texture, GPU memory (VRAM)

        Image fgImage = LoadImage("resources/cyberpunk_street_foreground.png");     // Loaded in CPU memory (RAM)
        Texture2D fgTexture = LoadTextureFromImage(fgImage);          // Image converted to texture, GPU memory (VRAM)

        // Once image has been converted to texture and uploaded to VRAM, it can be unloaded from RAM
        UnloadImage(bgImage);
        UnloadImage(fgImage);

        const int blendCountMax = 4;
        BlendMode blendMode = 0;

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyPressed(KeySpace))
            {
                if ((int)blendMode >= (blendCountMax - 1))
                {
                    blendMode = 0;
                }
                else
                {
                    blendMode++;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawTexture(bgTexture, (screenWidth / 2) - (bgTexture.width / 2), (screenHeight / 2) - (bgTexture.height / 2), White);

            // Apply the blend mode and then draw the foreground texture
            BeginBlendMode(blendMode);
            DrawTexture(fgTexture, (screenWidth / 2) - (fgTexture.width / 2), (screenHeight / 2) - (fgTexture.height / 2), White);
            EndBlendMode();

            // Draw the texts
            DrawText("Press SPACE to change blend modes.", 310, 350, 10, Gray);

            switch (blendMode)
            {
                case BlendAlpha:
                    DrawText("Current: BLEND_ALPHA", (screenWidth / 2) - 60, 370, 10, Gray);
                    break;
                case BlendAdditive:
                    DrawText("Current: BLEND_ADDITIVE", (screenWidth / 2) - 60, 370, 10, Gray);
                    break;
                case BlendMultiplied:
                    DrawText("Current: BLEND_MULTIPLIED", (screenWidth / 2) - 60, 370, 10, Gray);
                    break;
                case BlendAddColors:
                    DrawText("Current: BLEND_ADD_COLORS", (screenWidth / 2) - 60, 370, 10, Gray);
                    break;
                case BlendSubtractColors:
                    break;
                case BlendCustom:
                    break;
                case BlendAlphaPremul:
                    break;
                default:
                    break;
            }

            DrawText("(c) Cyberpunk Street Environment by Luis Zuno (@ansimuz)", screenWidth - 330, screenHeight - 20, 10, Gray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(fgTexture); // Unload foreground texture
        UnloadTexture(bgTexture); // Unload background texture

        CloseWindow();            // Close window and OpenGL context


        return 0;
    }


}
