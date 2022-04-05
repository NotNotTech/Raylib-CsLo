// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Text;

/*******************************************************************************************
*
*   raylib [text] example - TTF loading and usage
*
*   This example has been created using raylib 1.3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class SdfFonts
{

#if PLATFORM_DESKTOP
    const int GLSL_VERSION = 330;
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
	const int GLSL_VERSION = 100;
#endif

    // #include <stdlib.h>

    public static unsafe void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [text] example - SDF fonts");

        // NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

        string msg = "Signed Distance Fields";

        // Loading file to memory
        byte[] fileData = File.ReadAllBytes("resources/anonymous_pro_bold.ttf");

        // Default font generation from TTF font
        Font fontDefault = new();
        fontDefault.baseSize = 16;
        fontDefault.glyphCount = 95;

        // Loading font data from memory data
        // Parameters > font size: 16, no glyphs array provided (0), glyphs count: 95 (autogenerate chars array)
        fontDefault.glyphs = LoadFontData(fileData, fileData.Length, 16, IntPtr.Zero, 95, (int)FontDefault);
        // Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 4 px, pack method: 0 (default)
        Image atlas = GenImageFontAtlas(fontDefault.glyphs, &fontDefault.recs, 95, 16, 4, 0);
        fontDefault.texture = LoadTextureFromImage(atlas);
        UnloadImage(atlas);

        // SDF font generation from TTF font
        Font fontSDF = new();
        fontSDF.baseSize = 16;
        fontSDF.glyphCount = 95;
        // Parameters > font size: 16, no glyphs array provided (0), glyphs count: 0 (defaults to 95)
        fontSDF.glyphs = LoadFontData(fileData, fileData.Length, 16, IntPtr.Zero, 0, (int)FontSdf);
        // Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 0 px, pack method: 1 (Skyline algorythm)
        atlas = GenImageFontAtlas(fontSDF.glyphs, &fontSDF.recs, 95, 16, 0, 1);
        fontSDF.texture = LoadTextureFromImage(atlas);
        UnloadImage(atlas);

        // Load SDF required shader (we use default vertex shader)
        Shader shader = LoadFShader(string.Format("resources/shaders/glsl{0}/sdf.fs", GLSL_VERSION));
        SetTextureFilter(fontSDF.texture, TextureFilterBilinear);    // Required for SDF font

        Vector2 fontPosition = new(40, (screenHeight / 2.0f) - 50);

        float fontSize = 16.0f;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            fontSize += GetMouseWheelMove() * 8.0f;

            if (fontSize < 6)
            {
                fontSize = 6;
            }

            int currentFont;
            if (IsKeyDown(KeySpace))
            {
                currentFont = 1;
            }
            else
            {
                currentFont = 0;
            }

            Vector2 textSize;
            if (currentFont == 0)
            {
                textSize = MeasureTextEx(fontDefault, msg, fontSize, 0);
            }
            else
            {
                textSize = MeasureTextEx(fontSDF, msg, fontSize, 0);
            }

            fontPosition.X = (GetScreenWidth() / 2) - (textSize.X / 2);
            fontPosition.Y = (GetScreenHeight() / 2) - (textSize.Y / 2) + 80;


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            if (currentFont == 1)
            {
                // NOTE: SDF fonts require a custom SDf shader to compute fragment color
                BeginShaderMode(shader);    // Activate SDF font shader
                DrawTextEx(fontSDF, msg, fontPosition, fontSize, 0, Black);
                EndShaderMode();            // Activate our default shader for next drawings

                DrawTexture(fontSDF.texture, 10, 10, Black);
            }
            else
            {
                DrawTextEx(fontDefault, msg, fontPosition, fontSize, 0, Black);
                DrawTexture(fontDefault.texture, 10, 10, Black);
            }

            if (currentFont == 1)
            {
                DrawText("SDF!", 320, 20, 80, Red);
            }
            else
            {
                DrawText("default font", 315, 40, 30, Gray);
            }

            DrawText("FONT SIZE: 16.0", GetScreenWidth() - 240, 20, 20, Darkgray);
            DrawText(string.Format("RENDER SIZE: {0}", fontSize.ToString("00.00")), GetScreenWidth() - 240, 50, 20, Darkgray);
            DrawText("Use MOUSE WHEEL to SCALE TEXT!", GetScreenWidth() - 240, 90, 10, Darkgray);

            DrawText("HOLD SPACE to USE SDF FONT VERSION!", 340, GetScreenHeight() - 30, 20, Maroon);

            EndDrawing();

        }

        // De-Initialization

        UnloadFont(fontDefault);    // Default font unloading
        UnloadFont(fontSDF);        // SDF font unloading

        UnloadShader(shader);       // Unload SDF shader

        CloseWindow();              // Close window and OpenGL context



    }

}
