// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Apply a shader to a 3d model
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public static unsafe class ModelShader
{

    const int GLSL_VERSION = 330;
    public static void Example()
    {
        //var rLights = new Examples.RLights();

        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);      // Enable Multi Sampling Anti Aliasing 4x (if available)

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - model shader");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new Vector3(4.0f, 4.0f, 4.0f);
        camera.target = new Vector3(0.0f, 1.0f, -1.0f);
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.fovy = 45.0f;
        camera.Projection = CameraPerspective;

        Model model = LoadModel("resources/models/watermill.obj");                   // Load OBJ model
        Texture2D texture = LoadTexture("resources/models/watermill_diffuse.png");   // Load model texture

        // Load shader for model
        // NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        Shader shader = LoadFShader(string.Format("resources/shaders/glsl{0}/grayscale.fs", GLSL_VERSION));

        model.materials[0].shader = shader;                     // Set shader effect to 3d model
        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture; // Bind texture to model

        Vector3 position = new(0.0f, 0.0f, 0.0f);    // Set model position

        SetCameraMode(camera, CameraFree);         // Set an orbital camera mode

        SetTargetFPS(60);                           // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())                // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);                  // Update camera


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModel(model, position, 0.2f, White);   // Draw 3d model with texture

            DrawGrid(10, 1.0f);     // Draw a grid

            EndMode3D();

            DrawText("(c) Watermill 3D model by Alberto Cano", screenWidth - 210, screenHeight - 20, 10, Gray);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadShader(shader);       // Unload shader
        UnloadTexture(texture);     // Unload texture
        UnloadModel(model);         // Unload model

        CloseWindow();              // Close window and OpenGL context



    }
}
