// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>
/// /*******************************************************************************************
//*
//* raylib[models] example - Load 3d model with animations and play them
//*
//* This example has been created using raylib 2.5 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Example contributed by Culacant(@culacant) and reviewed by Ramon Santamaria(@raysan5)
//*
//* Copyright(c) 2019 Culacant(@culacant) and Ramon Santamaria(@raysan5)
//*
//********************************************************************************************
//*
//* To export a model from blender, make sure it is not posed, the vertices need to be in the
//* same position as they would be in edit mode.
//* and that the scale of your models is set to 0. Scaling can be done from the export menu.
//*
//********************************************************************************************/
///</summary>
public static unsafe class Animation
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - model animation");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
        camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
        camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;             // Camera mode type

        Model model = LoadModel("resources/models/iqm/guy.iqm");                    // Load the animated model mesh and basic data
        Texture2D texture = LoadTexture("resources/models/iqm/guytex.png");         // Load model texture and set material
        SetMaterialTexture(&model.materials[0], MaterialMapAlbedo, texture);     // Set model material map texture

        Vector3 position = new(0.0f, 0.0f, 0.0f);            // Set model position

        // Load animation data
        uint animsCount = 0;
        ModelAnimation[] anims = LoadModelAnimations("resources/models/iqm/guyanim.iqm");
        int animFrameCounter = 0;

        SetCameraMode(camera, CameraFree); // Set free camera mode

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);

            // Play animation when spacebar is held down
            if (IsKeyDown(KeySpace))
            {
                animFrameCounter++;
                UpdateModelAnimation(model, anims[0], animFrameCounter);
                if (animFrameCounter >= anims[0].frameCount)
                {
                    animFrameCounter = 0;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModelEx(model, position, new(1.0f, 0.0f, 0.0f), -90.0f, new(1.0f, 1.0f, 1.0f), White);

            for (int i = 0; i < model.boneCount; i++)
            {
                DrawCube(anims[0].framePoses[animFrameCounter][i].translation, 0.2f, 0.2f, 0.2f, Red);
            }

            DrawGrid(10, 1.0f);         // Draw a grid

            EndMode3D();

            DrawText("PRESS SPACE to PLAY MODEL ANIMATION", 10, 10, 20, Maroon);
            DrawText("(c) Guy IQM 3D model by @culacant", screenWidth - 200, screenHeight - 20, 10, Gray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);     // Unload texture

        // Unload model animations data
        for (uint i = 0; i < animsCount; i++)
        {
            UnloadModelAnimation(anims[i]);
        }
        //MemFree
        //RL_FREE(anims);

        UnloadModel(model);         // Unload model

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }

}
