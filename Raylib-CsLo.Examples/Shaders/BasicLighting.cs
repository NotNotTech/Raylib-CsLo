// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

using System.Numerics;

/*******************************************************************************************
*
*   raylib [shaders] example - basic lighting
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 3.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies, http://bedroomcoders.co.uk/) and
*   reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019-2021 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public static unsafe class BasicLighting
{

    const int GLSL_VERSION = 330;
    public static void Example()
    {
        RLights rLights = new();


        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);  // Enable Multi Sampling Anti Aliasing 4x (if available)
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - basic lighting");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new Vector3(2.0f, 4.0f, 6.0f);    // Camera position
        camera.target = new Vector3(0.0f, 0.5f, 0.0f);      // Camera looking at point
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;             // Camera mode type

        // Load plane model from a generated mesh
        Model model = LoadModelFromMesh(GenMeshPlane(10.0f, 10.0f, 3, 3));
        Model cube = LoadModelFromMesh(GenMeshCube(2.0f, 4.0f, 2.0f));

        Shader shader = LoadShader(string.Format("resources/shaders/glsl{0}/base_lighting.vs", GLSL_VERSION), string.Format("resources/shaders/glsl{0}/lighting.fs", GLSL_VERSION));

        // Get some required shader loactions
        shader.locs[(int)ShaderLocVectorView] = GetShaderLocation(shader, "viewPos");
        // NOTE: "matModel" location name is automatically assigned on shader loading,
        // no need to get the location again if using that uniform name
        //shader.locs[SHADER_LOC_MATRIX_MODEL] = GetShaderLocation(shader, "matModel");

        // Ambient light level (some basic lighting)
        int ambientLoc = GetShaderLocation(shader, "ambient");
        SetShaderValue(shader, ambientLoc, new Vector4(0.1f, 0.1f, 0.1f, 1.0f), ShaderUniformVec4);

        // Assign out lighting shader to model
        model.materials[0].shader = shader;
        cube.materials[0].shader = shader;

        // Using 4 point lights: Gold, Red, Green and Blue
        Light[] lights = new Light[MAX_LIGHTS];
        lights[0] = rLights.CreateLight(LIGHT_POINT, new Vector3(-2, 1, -2), Vector3Zero(), Yellow, shader);
        lights[1] = rLights.CreateLight(LIGHT_POINT, new Vector3(2, 1, 2), Vector3Zero(), Red, shader);
        lights[2] = rLights.CreateLight(LIGHT_POINT, new Vector3(-2, 1, 2), Vector3Zero(), Green, shader);
        lights[3] = rLights.CreateLight(LIGHT_POINT, new Vector3(2, 1, -2), Vector3Zero(), Blue, shader);

        SetCameraMode(camera, CameraOrbital);  // Set an orbital camera mode

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera

            // Check key inputs to enable/disable lights
            if (IsKeyPressed(KeyY))
            {
                lights[0].enabled = !lights[0].enabled;
            }
            if (IsKeyPressed(KeyR))
            {
                lights[1].enabled = !lights[1].enabled;
            }
            if (IsKeyPressed(KeyG))
            {
                lights[2].enabled = !lights[2].enabled;
            }
            if (IsKeyPressed(KeyB))
            {
                lights[3].enabled = !lights[3].enabled;
            }

            // Update light values (actually, only enable/disable them)
            UpdateLightValues(shader, lights[0]);
            UpdateLightValues(shader, lights[1]);
            UpdateLightValues(shader, lights[2]);
            UpdateLightValues(shader, lights[3]);

            // Update the shader with the camera view vector (points towards { 0.0f, 0.0f, 0.0f })
            Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
            SetShaderValue(shader, shader.locs[(int)ShaderLocVectorView], cameraPos, ShaderUniformVec3);


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModel(model, Vector3Zero(), 1.0f, White);
            DrawModel(cube, Vector3Zero(), 1.0f, White);

            // Draw markers to show where the lights are
            if (lights[0].enabled)
            {
                DrawSphereEx(lights[0].position, 0.2f, 8, 8, Yellow);
            }
            else
            {
                DrawSphereWires(lights[0].position, 0.2f, 8, 8, ColorAlpha(Yellow, 0.3f));
            }

            if (lights[1].enabled)
            {
                DrawSphereEx(lights[1].position, 0.2f, 8, 8, Red);
            }
            else
            {
                DrawSphereWires(lights[1].position, 0.2f, 8, 8, ColorAlpha(Red, 0.3f));
            }

            if (lights[2].enabled)
            {
                DrawSphereEx(lights[2].position, 0.2f, 8, 8, Green);
            }
            else
            {
                DrawSphereWires(lights[2].position, 0.2f, 8, 8, ColorAlpha(Green, 0.3f));
            }

            if (lights[3].enabled)
            {
                DrawSphereEx(lights[3].position, 0.2f, 8, 8, Blue);
            }
            else
            {
                DrawSphereWires(lights[3].position, 0.2f, 8, 8, ColorAlpha(Blue, 0.3f));
            }

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawFPS(10, 10);

            DrawText("Use keys [Y][R][G][B] to toggle lights", 10, 40, 20, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        UnloadModel(model);     // Unload the model
        UnloadModel(cube);      // Unload the model
        UnloadShader(shader);   // Unload shader

        CloseWindow();          // Close window and OpenGL context



    }
}
