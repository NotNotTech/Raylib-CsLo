// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Heightmap loading and drawing
//*
//* This example has been created using raylib 1.8 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2015 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static unsafe class Heightmap
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - heightmap loading and drawing");

        // Define our custom camera to look into our 3d world
        Camera camera = new(new(18.0f, 18.0f, 18.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        Image image = LoadImage("resources/heightmap.png");             // Load heightmap image (RAM)
        Texture2D texture = LoadTextureFromImage(image);                // Convert image to texture (VRAM)

        Mesh mesh = GenMeshHeightmap(image, new(16, 8, 16));    // Generate heightmap mesh (RAM and VRAM)
        Model model = LoadModelFromMesh(mesh);                          // Load model from generated mesh

        model.materials[0].maps[(int)MATERIAL_MAP_ALBEDO].texture = texture;         // Set map diffuse texture
        Vector3 mapPosition = new(-8.0f, 0.0f, -8.0f);                   // Define model position

        UnloadImage(image);                     // Unload heightmap image from RAM, already uploaded to VRAM

        SetCameraMode(ref camera, CAMERA_ORBITAL);  // Set an orbital camera mode

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            BeginMode3D(ref camera);

            DrawModel(model, mapPosition, 1.0f, RED);

            DrawGrid(20, 1.0f);

            EndMode3D();

            DrawTexture(texture, screenWidth - texture.width - 20, 20, WHITE);
            DrawRectangleLines(screenWidth - texture.width - 20, 20, texture.width, texture.height, GREEN);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);     // Unload texture
        UnloadModel(model);         // Unload model

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }
}
