// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Texture Waves
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class TextureWaves
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

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - texture waves");

        // Load texture texture to apply shaders
        Texture2D texture = LoadTexture("resources/space.png");

        // Load shader and setup location points and values
        Shader shader = LoadFShader(TextFormat("resources/shaders/glsl%i/wave.fs", GLSL_VERSION));

        int secondsLoc = GetShaderLocation(shader, "secondes");
        int freqXLoc = GetShaderLocation(shader, "freqX");
        int freqYLoc = GetShaderLocation(shader, "freqY");
        int ampXLoc = GetShaderLocation(shader, "ampX");
        int ampYLoc = GetShaderLocation(shader, "ampY");
        int speedXLoc = GetShaderLocation(shader, "speedX");
        int speedYLoc = GetShaderLocation(shader, "speedY");

        // Shader uniform values that can be updated at any time
        float freqX = 25.0f;
        float freqY = 25.0f;
        float ampX = 5.0f;
        float ampY = 5.0f;
        float speedX = 8.0f;
        float speedY = 8.0f;

        Vector2 screenSize = new(GetScreenWidth(), GetScreenHeight());
        SetShaderValue(shader, GetShaderLocation(shader, "size"), &screenSize, ShaderUniformVec2);
        SetShaderValue(shader, freqXLoc, &freqX, ShaderUniformFloat);
        SetShaderValue(shader, freqYLoc, &freqY, ShaderUniformFloat);
        SetShaderValue(shader, ampXLoc, &ampX, ShaderUniformFloat);
        SetShaderValue(shader, ampYLoc, &ampY, ShaderUniformFloat);
        SetShaderValue(shader, speedXLoc, &speedX, ShaderUniformFloat);
        SetShaderValue(shader, speedYLoc, &speedY, ShaderUniformFloat);

        float seconds = 0.0f;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            seconds += GetFrameTime();

            SetShaderValue(shader, secondsLoc, &seconds, ShaderUniformFloat);


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginShaderMode(shader);

            DrawTexture(texture, 0, 0, White);
            DrawTexture(texture, texture.width, 0, White);

            EndShaderMode();

            EndDrawing();

        }

        // De-Initialization

        UnloadShader(shader);         // Unload shader
        UnloadTexture(texture);       // Unload texture

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }
}
