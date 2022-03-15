// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Simple shader mask
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@chriscamacho) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
*
********************************************************************************************
*
*   After a model is loaded it has a default material, this material can be
*   modified in place rather than creating one from scratch...
*   While all of the maps have particular names, they can be used for any purpose
*   except for three maps that are applied as cubic maps (see below)
*
********************************************************************************************/

public static unsafe class SimpleMask
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

        InitWindow(screenWidth, screenHeight, "raylib - simple shader mask");

        // Define the camera to look into our 3d world
        Camera camera = new();
        camera.position = new Vector3(0.0f, 1.0f, 2.0f);
        camera.target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.fovy = 45.0f;
        camera.Projection = CAMERA_PERSPECTIVE;

        // Define our three models to show the shader on
        Mesh torus = GenMeshTorus(0.3f, 1, 16, 32);
        Model model1 = LoadModelFromMesh(torus);

        Mesh cube = GenMeshCube(0.8f, 0.8f, 0.8f);
        Model model2 = LoadModelFromMesh(cube);

        // Generate model to be shaded just to see the gaps in the other two
        Mesh sphere = GenMeshSphere(1, 16, 16);
        Model model3 = LoadModelFromMesh(sphere);

        // Load the shader
        Shader shader = LoadFShader(TextFormat("resources/shaders/glsl%i/mask.fs", GLSL_VERSION));

        // Load and apply the diffuse texture (colour map)
        Texture texDiffuse = LoadTexture("resources/plasma.png");
        model1.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texDiffuse;
        model2.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texDiffuse;

        // Using MATERIAL_MAP_EMISSION as a spare slot to use for 2nd texture
        // NOTE: Don't use MATERIAL_MAP_IRRADIANCE, MATERIAL_MAP_PREFILTER or  MATERIAL_MAP_CUBEMAP as they are bound as cube maps
        Texture texMask = LoadTexture("resources/mask.png");
        model1.materials[0].maps[(int)MATERIAL_MAP_EMISSION].texture = texMask;
        model2.materials[0].maps[(int)MATERIAL_MAP_EMISSION].texture = texMask;
        shader.locs[(int)SHADER_LOC_MAP_EMISSION] = GetShaderLocation(shader, "mask");

        // Frame is incremented each frame to animate the shader
        int shaderFrame = GetShaderLocation(shader, "frame");

        // Apply the shader to the two models
        model1.materials[0].shader = shader;
        model2.materials[0].shader = shader;

        int framesCounter = 0;
        Vector3 rotation = new(0);       // Model rotation angles

        SetTargetFPS(60);               // Set  to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            framesCounter++;
            rotation.X += 0.01f;
            rotation.Y += 0.005f;
            rotation.Z -= 0.0025f;

            // Send frames counter to shader for animation
            SetShaderValue(shader, shaderFrame, &framesCounter, SHADER_UNIFORM_INT);

            // Rotate one of the models
            model1.transform = MatrixRotateXYZ(rotation);

            UpdateCamera(ref camera);


            // Draw

            BeginDrawing();

            ClearBackground(DARKBLUE);

            BeginMode3D(ref camera);

            DrawModel(model1, new Vector3(0.5f, 0, 0), 1, WHITE);
            DrawModelEx(model2, new Vector3(-.5f, 0, 0), new Vector3(1, 1, 0), 50, new Vector3(1, 1, 1), WHITE);
            DrawModel(model3, new Vector3(0, 0, -1.5f), 1, WHITE);
            DrawGrid(10, 1.0f);        // Draw a grid

            EndMode3D();

            DrawRectangle(16, 698, MeasureText(TextFormat("Frame: %i", framesCounter), 20) + 8, 42, BLUE);
            DrawText(TextFormat("Frame: %i", framesCounter), 20, 700, 20, WHITE);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadModel(model1);
        UnloadModel(model2);
        UnloadModel(model3);

        UnloadTexture(texDiffuse);  // Unload default diffuse texture
        UnloadTexture(texMask);     // Unload texture mask

        UnloadShader(shader);       // Unload shader

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }
}
