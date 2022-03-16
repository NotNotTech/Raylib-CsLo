// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - mesh instancing
*
*   This example has been created using raylib 3.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by @seanpringle and reviewed by Max (@moliad) and Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020-2021 @seanpringle, Max (@moliad) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class MeshInstancing
{

    const int GLSL_VERSION = 330;
    const int MAX_INSTANCES = 10000;
    public static int Example()
    {
        RLights? rLights = new();
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;
        const int fps = 60;

        SetConfigFlags(FLAG_MSAA_4X_HINT);  // Enable Multi Sampling Anti Aliasing 4x (if available)
        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - mesh instancing");

        int speed = 30;                 // Speed of jump animation
        int groups = 2;                 // Count of separate groups jumping around
        float amp = 10;                 // Maximum amplitude of jump
        float variance = 0.8f;          // Global variance in jump height
        float loop = 0.0f;              // Individual cube's computed loop timer
        float x = 0.0f, y = 0.0f, z = 0.0f; // Used for various 3D coordinate & vector ops

        // Define the camera to look into our 3d world
        Camera camera = new();
        camera.position = new Vector3(-125.0f, 125.0f, -125.0f);
        camera.target = new Vector3(0.0f, 0.0f, 0.0f);
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.fovy = 45.0f;
        camera.Projection = CAMERA_PERSPECTIVE;

        Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);

        Matrix[] rotations = new Matrix[MAX_INSTANCES];    // Rotation state of instances
        Matrix[] rotationsInc = new Matrix[MAX_INSTANCES]; // Per-frame rotation animation of instances
        Matrix[] translations = new Matrix[MAX_INSTANCES]; // Locations of instances

        // Scatter random cubes around
        for (int i = 0; i < MAX_INSTANCES; i++)
        {
            x = GetRandomValue(-50, 50);
            y = GetRandomValue(-50, 50);
            z = GetRandomValue(-50, 50);
            translations[i] = MatrixTranslate(x, y, z);

            x = GetRandomValue(0, 360);
            y = GetRandomValue(0, 360);
            z = GetRandomValue(0, 360);
            Vector3 axis = Vector3Normalize(new Vector3(x, y, z));
            float angle = GetRandomValue(0, 10) * DEG2RAD;

            rotationsInc[i] = MatrixRotate(axis, angle);
            rotations[i] = MatrixIdentity();
        }

        Matrix[] transforms = new Matrix[MAX_INSTANCES];   // Pre-multiplied transformations passed to rlgl

        Shader shader = LoadShader(TextFormat("resources/shaders/glsl%i/base_lighting_instanced.vs", GLSL_VERSION), TextFormat("resources/shaders/glsl%i/lighting.fs", GLSL_VERSION));

        // Get some shader loactions
        shader.locs[(int)SHADER_LOC_MATRIX_MVP] = GetShaderLocation(shader, "mvp");
        shader.locs[(int)SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(shader, "viewPos");
        shader.locs[(int)SHADER_LOC_MATRIX_MODEL] = GetShaderLocationAttrib(shader, "instanceTransform");

        // Ambient light level
        int ambientLoc = GetShaderLocation(shader, "ambient");
        SetShaderValue(shader, ambientLoc, new Vector4(0.2f, 0.2f, 0.2f, 1.0f), SHADER_UNIFORM_VEC4);

        rLights.CreateLight(LIGHT_DIRECTIONAL, new Vector3(50.0f, 50.0f, 0.0f), Vector3Zero(), WHITE, shader);

        // NOTE: We are assigning the intancing shader to material.shader
        // to be used on mesh drawing with DrawMeshInstanced()
        Material material = LoadMaterialDefault();
        material.shader = shader;
        material.maps[(int)MATERIAL_MAP_ALBEDO].color = RED;

        SetCameraMode(ref camera, CAMERA_ORBITAL);  // Set an orbital camera mode

        int textPositionY = 300;
        int framesCounter = 0;                  // Simple frames counter to manage animation

        SetTargetFPS(fps);                      // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {

            // Update

            textPositionY = 300;
            framesCounter++;

            if (IsKeyDown(KEY_UP))
            {
                amp += 0.5f;
            }

            if (IsKeyDown(KEY_DOWN))
            {
                amp = (amp <= 1) ? 1.0f : (amp - 1.0f);
            }

            if (IsKeyDown(KEY_LEFT))
            {
                variance = (variance <= 0.0f) ? 0.0f : (variance - 0.01f);
            }

            if (IsKeyDown(KEY_RIGHT))
            {
                variance = (variance >= 1.0f) ? 1.0f : (variance + 0.01f);
            }

            if (IsKeyDown(KEY_ONE))
            {
                groups = 1;
            }

            if (IsKeyDown(KEY_TWO))
            {
                groups = 2;
            }

            if (IsKeyDown(KEY_THREE))
            {
                groups = 3;
            }

            if (IsKeyDown(KEY_FOUR))
            {
                groups = 4;
            }

            if (IsKeyDown(KEY_FIVE))
            {
                groups = 5;
            }

            if (IsKeyDown(KEY_SIX))
            {
                groups = 6;
            }

            if (IsKeyDown(KEY_SEVEN))
            {
                groups = 7;
            }

            if (IsKeyDown(KEY_EIGHT))
            {
                groups = 8;
            }

            if (IsKeyDown(KEY_NINE))
            {
                groups = 9;
            }

            if (IsKeyDown(KEY_W))
            { groups = 7; amp = 25; speed = 18; variance = 0.70f; }

            if (IsKeyDown(KEY_EQUAL))
            {
                speed = (speed <= (fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);
            }

            if (IsKeyDown(KEY_KP_ADD))
            {
                speed = (speed <= (fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);
            }

            if (IsKeyDown(KEY_MINUS))
            {
                speed = (int)MathF.Max(speed * 1.02f, speed + 1);
            }

            if (IsKeyDown(KEY_KP_SUBTRACT))
            {
                speed = (int)MathF.Max(speed * 1.02f, speed + 1);
            }

            // Update the light shader with the camera view position
            Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
            SetShaderValue(shader, shader.locs[(int)SHADER_LOC_VECTOR_VIEW], cameraPos, SHADER_UNIFORM_VEC3);

            // Apply per-instance transformations
            for (int i = 0; i < MAX_INSTANCES; i++)
            {
                rotations[i] = MatrixMultiply(rotations[i], rotationsInc[i]);
                transforms[i] = MatrixMultiply(rotations[i], translations[i]);

                // Get the animation cycle's framesCounter for this instance
                loop = (float)((framesCounter + (int)((float)(i % groups) / groups * speed)) % speed) / speed;

                // Calculate the y according to loop cycle
                y = MathF.Sin(loop * MathF.PI * 2) * amp * (1 - variance + (variance * (i % (groups * 10)) / (groups * 10)));

                // Clamp to floor
                y = (y < 0) ? 0.0f : y;

                transforms[i] = MatrixMultiply(transforms[i], MatrixTranslate(0.0f, y, 0.0f));
            }

            UpdateCamera(ref camera);


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            BeginMode3D(ref camera);
            //DrawMesh(cube, material, MatrixIdentity());
            for (int i = 0; i < transforms.Length; i++)
            {
                //flip for opengl column major
                transforms[i] = Matrix.Transpose(transforms[i]);
            }
            DrawMeshInstanced(cube, material, transforms, MAX_INSTANCES);
            EndMode3D();

            DrawText("A CUBE OF DANCING CUBES!", 490, 10, 20, MAROON);
            DrawText("PRESS KEYS:", 10, textPositionY, 20, BLACK);

            DrawText("1 - 9", 10, textPositionY += 25, 10, BLACK);
            DrawText(": Number of groups", 50, textPositionY, 10, BLACK);
            DrawText(TextFormat(": %d", groups), 160, textPositionY, 10, BLACK);

            DrawText("UP", 10, textPositionY += 15, 10, BLACK);
            DrawText(": increase amplitude", 50, textPositionY, 10, BLACK);
            DrawText(TextFormat(": %.2f", amp), 160, textPositionY, 10, BLACK);

            DrawText("DOWN", 10, textPositionY += 15, 10, BLACK);
            DrawText(": decrease amplitude", 50, textPositionY, 10, BLACK);

            DrawText("LEFT", 10, textPositionY += 15, 10, BLACK);
            DrawText(": decrease variance", 50, textPositionY, 10, BLACK);
            DrawText(TextFormat(": %.2f", variance), 160, textPositionY, 10, BLACK);

            DrawText("RIGHT", 10, textPositionY += 15, 10, BLACK);
            DrawText(": increase variance", 50, textPositionY, 10, BLACK);

            DrawText("+/=", 10, textPositionY += 15, 10, BLACK);
            DrawText(": increase speed", 50, textPositionY, 10, BLACK);
            DrawText(TextFormat(": %d = %f loops/sec", speed, (float)fps / speed), 160, textPositionY, 10, BLACK);

            DrawText("-", 10, textPositionY += 15, 10, BLACK);
            DrawText(": decrease speed", 50, textPositionY, 10, BLACK);

            DrawText("W", 10, textPositionY += 15, 10, BLACK);
            DrawText(": Wild setup!", 50, textPositionY, 10, BLACK);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
