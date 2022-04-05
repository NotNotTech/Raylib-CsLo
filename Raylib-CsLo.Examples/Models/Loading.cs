// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Models loading
//*
//* raylib supports multiple models file formats:
//*
//*     - OBJ  > Text file format.Must include vertex position-texcoords-normals information,
//*              if files references some.mtl materials file, it will be loaded(or try to).
//*     - GLTF > Text/binary file format.Includes lot of information and it could
//* also reference external files, raylib will try loading mesh and materials data.
//*     - IQM  > Binary file format.Includes mesh vertex data but also animation data,
//* raylib can load.iqm animations.
//*     - VOX  > Binary file format.MagikaVoxel mesh format:
//*              https://github.com/ephtracy/voxel-model/blob/master/MagicaVoxel-file-format-vox.txt
//*
//*   This example has been created using raylib 4.0 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2014-2021 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static class Loading
{

    public static unsafe void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - models loading");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new(50.0f, 50.0f, 50.0f); // Camera position
        camera.target = new(0.0f, 10.0f, 0.0f);     // Camera looking at point
        camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;                   // Camera mode type

        Model model = LoadModel("resources/models/obj/castle.obj");                 // Load model
        Texture2D texture = LoadTexture("resources/models/obj/castle_diffuse.png"); // Load model texture
        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;            // Set map diffuse texture

        Vector3 position = new(0.0f, 0.0f, 0.0f);                    // Set model position

        BoundingBox bounds = GetMeshBoundingBox(model.meshes[0]);   // Set model bounds

        // NOTE: bounds are calculated from the original size of the model,
        // if model is scaled on drawing, bounds must be also scaled

        SetCameraMode(camera, CameraFree);     // Set a free camera mode

        bool selected = false;          // Selected object flag

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);

            // Load new models/textures on drag&drop
            if (IsFileDropped())
            {
                //char** droppedFiles = GetDroppedFiles(&count);
                string[] droppedFiles = GetDroppedFiles();

                if (droppedFiles.Length == 1) // Only support one file dropped
                {
                    if (droppedFiles[0].EndsWith(".obj") ||
                        droppedFiles[0].EndsWith(".gltf") ||
                        droppedFiles[0].EndsWith(".glb") ||
                        droppedFiles[0].EndsWith(".vox") ||
                        droppedFiles[0].EndsWith(".iqm"))       // Model file formats supported
                    {
                        UnloadModel(model);                     // Unload previous model
                        model = LoadModel(droppedFiles[0]);     // Load new model
                        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture; // Set current map diffuse texture

                        bounds = GetMeshBoundingBox(model.meshes[0]);

                        // TODO: Move camera position from target enough distance to visualize model properly
                    }
                    else if (droppedFiles[0].EndsWith(".png"))  // Texture file formats supported
                    {
                        // Unload current model texture and load new one
                        UnloadTexture(texture);
                        texture = LoadTexture(droppedFiles[0]);
                        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;
                    }
                }

                ClearDroppedFiles();    // Clear internal buffers
            }

            // Select model on mouse click
            if (IsMouseButtonPressed(MouseButtonLeft))
            {
                // Check collision between ray and box
                if (GetRayCollisionBox(GetMouseRay(GetMousePosition(), camera), bounds).hit)
                {
                    selected = !selected;
                }
                else
                {
                    selected = false;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModel(model, position, 1.0f, White);        // Draw 3d model with texture

            DrawGrid(20, 10.0f);         // Draw a grid

            if (selected)
            {
                DrawBoundingBox(bounds, Green);   // Draw selection box
            }

            EndMode3D();

            DrawText("Drag & drop model to load mesh/texture.", 10, GetScreenHeight() - 20, 10, Darkgray);
            if (selected)
            {
                DrawText("MODEL SELECTED", GetScreenWidth() - 110, 10, 10, Green);
            }

            DrawText("(c) Castle 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, Gray);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);     // Unload texture
        UnloadModel(model);         // Unload model

        CloseWindow();              // Close window and OpenGL context



    }
}
