// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Load models vox(MagicaVoxel)
//*
//* This example has been created using raylib 4.0 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Example contributed by Johann Nadalutti(@procfxgen) and reviewed by Ramon Santamaria(@raysan5)
//*
//* Copyright(c) 2021 Johann Nadalutti(@procfxgen) and Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static unsafe class LoadingVox
{
    const int MAX_VOX_FILES = 3;
    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        string[] voxFileNames = new string[MAX_VOX_FILES] {
        "resources/models/vox/chr_knight.vox",
        "resources/models/vox/chr_sword.vox",
        "resources/models/vox/monu9.vox"
    };
        InitWindow(screenWidth, screenHeight, "raylib [models] example - magicavoxel loading");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
        camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
        camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;             // Camera mode type

        // Load MagicaVoxel files
        Model[] models = new Model[MAX_VOX_FILES];

        for (int i = 0; i < MAX_VOX_FILES; i++)
        {
            // Load VOX file and measure time
            double t0 = GetTime() * 1000.0;
            models[i] = LoadModel(voxFileNames[i]);
            double t1 = GetTime() * 1000.0;

            Console.WriteLine("[{0}] File loaded in {1} ms", voxFileNames[i], t1 - t0);

            // Compute model translation matrix to center model on draw position (0, 0 , 0)
            BoundingBox bb = GetModelBoundingBox(models[i]);
            Vector3 center = new();
            center.X = bb.min.X + ((bb.max.X - bb.min.X) / 2);
            center.Z = bb.min.Z + ((bb.max.Z - bb.min.Z) / 2);

            Matrix4x4 matTranslate = Matrix4x4.CreateTranslation(-center.X, 0, -center.Z);
            models[i].transform = Matrix4x4.Transpose(matTranslate);
        }

        int currentModel = 0;

        SetCameraMode(camera, CameraOrbital);  // Set a orbital camera mode

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);      // Update our camera to orbit

            // Cycle between models on mouse click
            if (IsMouseButtonPressed(MouseButtonLeft))
            {
                currentModel = (currentModel + 1) % MAX_VOX_FILES;
            }

            // Cycle between models on key pressed
            if (IsKeyPressed(KeyRight))
            {
                currentModel++;
                if (currentModel >= MAX_VOX_FILES)
                {
                    currentModel = 0;
                }
            }
            else if (IsKeyPressed(KeyLeft))
            {
                currentModel--;
                if (currentModel < 0)
                {
                    currentModel = MAX_VOX_FILES - 1;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            // Draw 3D model
            BeginMode3D(camera);

            DrawModel(models[currentModel], new(0, 0, 0), 1.0f, White);
            DrawGrid(10, 1.0f);

            EndMode3D();

            // Display info
            DrawRectangle(10, 400, 310, 30, Fade(Skyblue, 0.5f));
            DrawRectangleLines(10, 400, 310, 30, Fade(Darkblue, 0.5f));
            DrawText("MOUSE LEFT BUTTON to CYCLE VOX MODELS", 40, 410, 10, Blue);
            DrawText(TextFormat("File: %s", GetFileName(voxFileNames[currentModel])), 10, 10, 20, Gray);

            EndDrawing();

        }

        // De-Initialization

        // Unload models data (GPU VRAM)
        for (int i = 0; i < MAX_VOX_FILES; i++)
        {
            UnloadModel(models[i]);
        }

        CloseWindow();          // Close window and OpenGL context


        return 0;
    }


}
