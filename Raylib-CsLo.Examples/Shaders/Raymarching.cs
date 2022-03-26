// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;
/*******************************************************************************************
*
*   raylib [shaders] example - Raymarching shapes generation
*
*   NOTE: This example requires raylib OpenGL 3.3 for shaders support and only #version 330
*         is currently supported. OpenGL ES 2.0 platforms are not supported at the moment.
*
*   This example has been created using raylib 2.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2018 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class Raymarching
{


#if PLATFORM_DESKTOP
    const int GLSL_VERSION = 330;
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB -> Not supported at this moment
	const int GLSL_VERSION = 100;
#endif

    public static void Example()
    {
        // Initialization

        int screenWidth = 800;
        int screenHeight = 450;

        SetConfigFlags(FlagWindowResizable);
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - raymarching shapes");

        Camera3D camera = new();
        camera.position = new Vector3(2.5f, 2.5f, 3.0f);    // Camera position
        camera.target = new Vector3(0.0f, 0.0f, 0.7f);      // Camera looking at point
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 65.0f;                                // Camera field-of-view Y

        SetCameraMode(camera, CameraFree);                 // Set camera mode

        // Load raymarching shader
        // NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        Shader shader = LoadFShader(string.Format("resources/shaders/glsl{0}/raymarching.fs", GLSL_VERSION));

        // Get shader locations for required uniforms
        int viewEyeLoc = GetShaderLocation(shader, "viewEye");
        int viewCenterLoc = GetShaderLocation(shader, "viewCenter");
        int runTimeLoc = GetShaderLocation(shader, "runTime");
        int resolutionLoc = GetShaderLocation(shader, "resolution");

        Vector2 resolution = new(screenWidth, screenHeight);
        SetShaderValue(shader, resolutionLoc, resolution, ShaderUniformVec2);

        float runTime = 0.0f;

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera

            Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
            Vector3 cameraTarget = new(camera.target.X, camera.target.Y, camera.target.Z);

            float deltaTime = GetFrameTime();
            runTime += deltaTime;

            // Set shader required uniform values
            SetShaderValue(shader, viewEyeLoc, cameraPos, ShaderUniformVec3);
            SetShaderValue(shader, viewCenterLoc, cameraTarget, ShaderUniformVec3);
            SetShaderValue(shader, runTimeLoc, &runTime, ShaderUniformFloat);

            // Check if screen is resized
            if (IsWindowResized())
            {
                screenWidth = GetScreenWidth();
                screenHeight = GetScreenHeight();
                resolution = new(screenWidth, screenHeight);
                SetShaderValue(shader, resolutionLoc, resolution, ShaderUniformVec2);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            // We only draw a White full-screen rectangle,
            // frame is generated in shader using raymarching
            BeginShaderMode(shader);
            DrawRectangle(0, 0, screenWidth, screenHeight, White);
            EndShaderMode();

            DrawText("(c) Raymarching shader by Iñigo Quilez. MIT License.", screenWidth - 280, screenHeight - 20, 10, Black);

            EndDrawing();

        }

        // De-Initialization

        UnloadShader(shader);           // Unload shader

        CloseWindow();                  // Close window and OpenGL context



    }
}
