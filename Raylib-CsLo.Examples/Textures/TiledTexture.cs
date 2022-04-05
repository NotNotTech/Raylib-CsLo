// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Draw part of the texture tiled
*
*   This example has been created using raylib 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public static class TiledTexture
{

    //#define SIZEOF(A) (sizeof(A)/sizeof(A[0]))
    const int OPT_WIDTH = 220;       // Max width for the options container
    const int MARGIN_SIZE = 8;       // Size for the margins
    const int COLOR_SIZE = 16;       // Size of the color select buttons

    public static void Example()//int argc, char** argv)
    {
        // Initialization

        int screenWidth = 800;
        int screenHeight = 450;

        SetConfigFlags(FlagWindowResizable); // Make the window resizable
        InitWindow(screenWidth, screenHeight, "raylib [textures] example - Draw part of a texture tiled");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
        Texture2D texPattern = LoadTexture("resources/patterns.png");
        SetTextureFilter(texPattern, TextureFilterTrilinear); // Makes the texture smoother when upscaled

        // Coordinates for all patterns inside the texture
        Rectangle[] recPattern = new Rectangle[]{
        new Rectangle( 3, 3, 66, 66 ),
        new Rectangle( 75, 3, 100, 100 ),
        new Rectangle( 3, 75, 66, 66 ),
        new Rectangle( 7, 156, 50, 50 ),
        new Rectangle( 85, 106, 90, 45 ),
        new Rectangle( 75, 154, 100, 60)
    };

        // Setup colors
        Color[] colors = new Color[] { Black, Maroon, Orange, Blue, Purple, Beige, Lime, Red, Darkgray, Skyblue };

        Rectangle[] colorRec = new Rectangle[colors.Length];

        // Calculate rectangle for each color
        for (int i = 0, x = 0, y = 0; i < colors.Length; i++)
        {
            colorRec[i].X = 2.0f + MARGIN_SIZE + x;
            colorRec[i].Y = 22.0f + 256.0f + MARGIN_SIZE + y;
            colorRec[i].Width = COLOR_SIZE * 2.0f;
            colorRec[i].Height = COLOR_SIZE;

            if (i == ((colors.Length / 2) - 1))
            {
                x = 0;
                y += COLOR_SIZE + MARGIN_SIZE;
            }
            else
            {
                x += (COLOR_SIZE * 2) + MARGIN_SIZE;
            }
        }

        int activePattern = 0, activeCol = 0;
        float scale = 1.0f, rotation = 0.0f;

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            screenWidth = GetScreenWidth();
            screenHeight = GetScreenHeight();

            // Handle mouse
            if (IsMouseButtonPressed(MouseButtonLeft))
            {
                Vector2 mouse = GetMousePosition();

                // Check which pattern was clicked and set it as the active pattern
                //for (int i = 0; i < SIZEOF(recPattern); i++)
                for (int i = 0; i < recPattern.Length; i++)
                {
                    if (CheckCollisionPointRec(mouse, new Rectangle(2 + MARGIN_SIZE + recPattern[i].X, 40 + MARGIN_SIZE + recPattern[i].Y, recPattern[i].Width, recPattern[i].Height)))
                    {
                        activePattern = i;
                        break;
                    }
                }

                // Check to see which color was clicked and set it as the active color
                for (int i = 0; i < colors.Length; ++i)
                {
                    if (CheckCollisionPointRec(mouse, colorRec[i]))
                    {
                        activeCol = i;
                        break;
                    }
                }
            }

            // Handle keys

            // Change scale
            if (IsKeyPressed(KeyUp))
            {
                scale += 0.25f;
            }

            if (IsKeyPressed(KeyDown))
            {
                scale -= 0.25f;
            }

            if (scale > 10.0f)
            {
                scale = 10.0f;
            }
            else if (scale <= 0.0f)
            {
                scale = 0.25f;
            }

            // Change rotation
            if (IsKeyPressed(KeyLeft))
            {
                rotation -= 25.0f;
            }

            if (IsKeyPressed(KeyRight))
            {
                rotation += 25.0f;
            }

            // Reset
            if (IsKeyPressed(KeySpace))
            { rotation = 0.0f; scale = 1.0f; }


            // Draw

            BeginDrawing();
            ClearBackground(Raywhite);

            // Draw the tiled area
            DrawTextureTiled(texPattern, recPattern[activePattern], new Rectangle((float)OPT_WIDTH + MARGIN_SIZE, MARGIN_SIZE, screenWidth - OPT_WIDTH - (2.0f * MARGIN_SIZE), screenHeight - (2.0f * MARGIN_SIZE)),
                new Vector2(0.0f, 0.0f), rotation, scale, colors[activeCol]);

            // Draw options
            DrawRectangle(MARGIN_SIZE, MARGIN_SIZE, OPT_WIDTH - MARGIN_SIZE, screenHeight - (2 * MARGIN_SIZE), ColorAlpha(Lightgray, 0.5f));

            DrawText("Select Pattern", 2 + MARGIN_SIZE, 30 + MARGIN_SIZE, 10, Black);
            DrawTexture(texPattern, 2 + MARGIN_SIZE, 40 + MARGIN_SIZE, Black);
            DrawRectangle(2 + MARGIN_SIZE + (int)recPattern[activePattern].X, 40 + MARGIN_SIZE + (int)recPattern[activePattern].Y, (int)recPattern[activePattern].Width, (int)recPattern[activePattern].Height, ColorAlpha(Darkblue, 0.3f));

            DrawText("Select Color", 2 + MARGIN_SIZE, 10 + 256 + MARGIN_SIZE, 10, Black);
            for (int i = 0; i < colors.Length; i++)
            {
                DrawRectangleRec(colorRec[i], colors[i]);
                if (activeCol == i)
                {
                    DrawRectangleLinesEx(colorRec[i], 3, ColorAlpha(White, 0.5f));
                }
            }

            DrawText("Scale (UP/DOWN to change)", 2 + MARGIN_SIZE, 80 + 256 + MARGIN_SIZE, 10, Black);
            DrawText(string.Format("{0}", scale.ToString("0.00")), 2 + MARGIN_SIZE, 92 + 256 + MARGIN_SIZE, 20, Black);

            DrawText("Rotation (LEFT/RIGHT to change)", 2 + MARGIN_SIZE, 122 + 256 + MARGIN_SIZE, 10, Black);
            DrawText(string.Format("{0} degrees", rotation.ToString("0.")), 2 + MARGIN_SIZE, 134 + 256 + MARGIN_SIZE, 20, Black);

            DrawText("Press [SPACE] to reset", 2 + MARGIN_SIZE, 164 + 256 + MARGIN_SIZE, 10, Darkblue);

            // Draw FPS
            DrawText(string.Format("{0} FPS", GetFPS()), 2 + MARGIN_SIZE, 2 + MARGIN_SIZE, 20, Black);
            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texPattern);        // Unload texture

        CloseWindow();              // Close window and OpenGL context



    }
}
