// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>*******************************************************************************************
//*
//* raylib[models] example - Cubicmap loading and drawing
//*
//* This example has been created using raylib 1.8 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2015 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************
///</summary>
public static unsafe class Cubicmap
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - cubesmap loading and drawing");

        // Define the camera to look into our 3d world
        Camera3D camera = new(new(16.0f, 14.0f, 16.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        Image image = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
        Texture2D cubicmap = LoadTextureFromImage(image);       // Convert image to texture to display (VRAM)

        Mesh mesh = GenMeshCubicmap(image, new(1.0f, 1.0f, 1.0f));
        Model model = LoadModelFromMesh(mesh);

        // NOTE: By default each cube is mapped to one part of texture atlas
        Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;             // Set map diffuse texture

        Vector3 mapPosition = new(-16.0f, 0.0f, -8.0f);          // Set model position

        UnloadImage(image);     // Unload cubesmap image from RAM, already uploaded to VRAM

        SetCameraMode(camera, CameraOrbital);  // Set an orbital camera mode

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModel(model, mapPosition, 1.0f, White);

            EndMode3D();

            DrawTextureEx(cubicmap, new(
                screenWidth - (cubicmap.width * 4.0f) - 20, 20.0f), 0.0f, 4.0f, White);
            DrawRectangleLines(screenWidth - (cubicmap.width * 4) - 20, 20, cubicmap.width * 4, cubicmap.height * 4, Green);

            DrawText("cubicmap image used to", 658, 90, 10, Gray);
            DrawText("generate map 3d model", 658, 104, 10, Gray);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(cubicmap);    // Unload cubicmap texture
        UnloadTexture(texture);     // Unload map texture
        UnloadModel(model);         // Unload map model

        CloseWindow();              // Close window and OpenGL context


    }

}
