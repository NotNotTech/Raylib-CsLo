// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Apply an shdrOutline to a texture
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   This example has been created using raylib 3.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Samuel Skiff (@GoldenThumbs) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Samuel SKiff (@GoldenThumbs) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class TextureOutline
{

#if PLATFORM_DESKTOP
    const int GLSL_VERSION = 330;
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
	const int GLSL_VERSION = 100;
#endif

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - Apply an outline to a texture");

        Texture2D texture = LoadTexture("resources/fudesumi.png");

        Shader shdrOutline = LoadFShader(TextFormat("resources/shaders/glsl%i/outline.fs", GLSL_VERSION));

        float outlineSize = 2.0f;
        Vector4 outlineColor = new(1.0f, 0.0f, 0.0f, 1.0f);     // Normalized RED color
        Vector2 textureSize = new(texture.width, texture.height);

        // Get shader locations
        int outlineSizeLoc = GetShaderLocation(shdrOutline, "outlineSize");
        int outlineColorLoc = GetShaderLocation(shdrOutline, "outlineColor");
        int textureSizeLoc = GetShaderLocation(shdrOutline, "textureSize");

        // Set shader values (they can be changed later)
        SetShaderValue(shdrOutline, outlineSizeLoc, &outlineSize, SHADER_UNIFORM_FLOAT);
        SetShaderValue(shdrOutline, outlineColorLoc, outlineColor, SHADER_UNIFORM_VEC4);
        SetShaderValue(shdrOutline, textureSizeLoc, textureSize, SHADER_UNIFORM_VEC2);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            outlineSize += GetMouseWheelMove();
            if (outlineSize < 1.0f)
            {
                outlineSize = 1.0f;
            }

            SetShaderValue(shdrOutline, outlineSizeLoc, &outlineSize, SHADER_UNIFORM_FLOAT);


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            BeginShaderMode(shdrOutline);

            DrawTexture(texture, (GetScreenWidth() / 2) - (texture.width / 2), -30, WHITE);

            EndShaderMode();

            DrawText("Shader-based\ntexture\noutline", 10, 10, 20, GRAY);

            DrawText(TextFormat("Outline size: %i px", (int)outlineSize), 10, 120, 20, MAROON);

            DrawFPS(710, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);
        UnloadShader(shdrOutline);

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
