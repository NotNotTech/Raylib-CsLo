// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Text;

/*******************************************************************************************
*
*   raylib [text] example - Font filters
*
*   After font loading, font texture atlas filter could be configured for a softer
*   display of the font when scaling it to different sizes, that way, it's not required
*   to generate multiple fonts at multiple sizes (as long as the scaling is not very different)
*
*   This example has been created using raylib 1.3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class FontFilters
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - font filters");

        string msg = "Loaded Font";

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

        // TTF Font loading with custom generation parameters
        Font font = LoadFontEx("resources/KAISG.ttf", 96, IntPtr.Zero, 0);

        // Generate mipmap levels to use trilinear filtering
        // NOTE: On 2D drawing it won't be noticeable, it looks like FILTER_BILINEAR
        GenTextureMipmaps(ref font.texture);

        float fontSize = font.baseSize;
        Vector2 fontPosition = new(40.0f, (screenHeight / 2.0f) - 80.0f);

        // Setup texture scaling filter
        SetTextureFilter(font.texture, TextureFilterPoint);
        int currentFontFilter = 0;      // TEXTURE_FILTER_POINT

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            fontSize += GetMouseWheelMove() * 4.0f;

            // Choose font texture filter method
            if (IsKeyPressed(KeyOne))
            {
                SetTextureFilter(font.texture, TextureFilterPoint);
                currentFontFilter = 0;
            }
            else if (IsKeyPressed(KeyTwo))
            {
                SetTextureFilter(font.texture, TextureFilterBilinear);
                currentFontFilter = 1;
            }
            else if (IsKeyPressed(KeyThree))
            {
                // NOTE: Trilinear filter won't be noticed on 2D drawing
                SetTextureFilter(font.texture, TextureFilterTrilinear);
                currentFontFilter = 2;
            }

            Vector2 textSize = MeasureTextEx(font, msg, fontSize, 0);

            if (IsKeyDown(KeyLeft))
            {
                fontPosition.X -= 10;
            }
            else if (IsKeyDown(KeyRight))
            {
                fontPosition.X += 10;
            }

            // Load a dropped TTF file dynamically (at current fontSize)
            if (IsFileDropped())
            {
                //int count = 0;
                //char** droppedFiles = GetDroppedFiles(&count);
                string[] droppedFiles = GetDroppedFiles();

                _ = droppedFiles.Length;

                // NOTE: We only support first ttf file dropped
                if (IsFileExtension(droppedFiles[0], ".ttf"))
                {
                    UnloadFont(font);
                    font = LoadFontEx(droppedFiles[0], (int)fontSize, IntPtr.Zero, 0);
                    ClearDroppedFiles();
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("Use mouse wheel to change font size", 20, 20, 10, Gray);
            DrawText("Use KEY_RIGHT and KeyLeft to move text", 20, 40, 10, Gray);
            DrawText("Use 1, 2, 3 to change texture filter", 20, 60, 10, Gray);
            DrawText("Drop a new TTF font for dynamic loading", 20, 80, 10, Darkgray);

            DrawTextEx(font, msg, fontPosition, fontSize, 0, Black);

            // TODO: It seems texSize measurement is not accurate due to chars offsets...
            //DrawRectangleLines(fontPosition.X, fontPosition.Y, textSize.X, textSize.Y, Red);

            DrawRectangle(0, screenHeight - 80, screenWidth, 80, Lightgray);
            DrawText(string.Format("Font size: {0}", fontSize.ToString("00.00")), 20, screenHeight - 50, 10, Darkgray);
            DrawText(string.Format("Text size: [{0}, {1}]", textSize.X.ToString("00.00"), textSize.Y.ToString("00.00")), 20, screenHeight - 30, 10, Darkgray);
            DrawText("CURRENT TEXTURE FILTER:", 250, 400, 20, Gray);

            if (currentFontFilter == 0)
            {
                DrawText("POINT", 570, 400, 20, Black);
            }
            else if (currentFontFilter == 1)
            {
                DrawText("BILINEAR", 570, 400, 20, Black);
            }
            else if (currentFontFilter == 2)
            {
                DrawText("TRILINEAR", 570, 400, 20, Black);
            }

            EndDrawing();

        }

        // De-Initialization

        ClearDroppedFiles();        // Clear internal buffers

        UnloadFont(font);           // Font unloading

        CloseWindow();              // Close window and OpenGL context



    }
}
