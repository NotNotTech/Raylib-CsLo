// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - first person maze
//*
//* This example has been created using raylib 2.5 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2019 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
//
///</summary>
public static unsafe class FirstPersonMaze
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - first person maze");

        // Define the camera to look into our 3d world
        Camera3D camera = new(new(0.2f, 0.4f, 0.2f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        Image imMap = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
        Texture2D cubicmap = LoadTextureFromImage(imMap);       // Convert image to texture to display (VRAM)
        Mesh mesh = GenMeshCubicmap(imMap, new(1.0f, 1.0f, 1.0f));
        Model model = LoadModelFromMesh(mesh);

        // NOTE: By default each cube is mapped to one part of texture atlas
        Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;             // Set map diffuse texture

        // Get map image data to be used for collision detection
        Color[] mapPixels = LoadImageColors(imMap);
        UnloadImage(imMap);             // Unload image from RAM

        Vector3 mapPosition = new(-16.0f, 0.0f, -8.0f);  // Set model position

        SetCameraMode(camera, CameraFirstPerson);     // Set camera mode

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector3 oldCamPos = camera.position;    // Store old camera position

            UpdateCamera(ref camera);      // Update camera

            // Check player collision (we simplify to 2D collision detection)
            Vector2 playerPos = new(camera.position.X, camera.position.Z);
            float playerRadius = 0.1f;  // Collision radius (player is modelled as a cilinder for collision)

            int playerCellX = (int)(playerPos.X - mapPosition.X + 0.5f);
            int playerCellY = (int)(playerPos.Y - mapPosition.Z + 0.5f);

            // Out-of-limits security check
            if (playerCellX < 0)
            {
                playerCellX = 0;
            }
            else if (playerCellX >= cubicmap.width)
            {
                playerCellX = cubicmap.width - 1;
            }

            if (playerCellY < 0)
            {
                playerCellY = 0;
            }
            else if (playerCellY >= cubicmap.height)
            {
                playerCellY = cubicmap.height - 1;
            }

            // Check map collisions using image data and player position
            // TODO: Improvement: Just check player surrounding cells for collision
            for (int y = 0; y < cubicmap.height; y++)
            {
                for (int x = 0; x < cubicmap.width; x++)
                {
                    if ((mapPixels[(y * cubicmap.width) + x].r == 255) &&       // Collision: White pixel, only check R channel
                        CheckCollisionCircleRec(playerPos, playerRadius,
                        new Rectangle(mapPosition.X - 0.5f + (x * 1.0f), mapPosition.Z - 0.5f + (y * 1.0f), 1.0f, 1.0f)))
                    {
                        // Collision detected, reset camera position
                        camera.position = oldCamPos;
                    }
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);
            DrawModel(model, mapPosition, 1.0f, White);                     // Draw maze map
            EndMode3D();

            DrawTextureEx(cubicmap, new(
                GetScreenWidth() - (cubicmap.width * 4.0f) - 20, 20.0f), 0.0f, 4.0f, White);
            DrawRectangleLines(GetScreenWidth() - (cubicmap.width * 4) - 20, 20, cubicmap.width * 4, cubicmap.height * 4, Green);

            // Draw player position radar
            DrawRectangle(GetScreenWidth() - (cubicmap.width * 4) - 20 + (playerCellX * 4), 20 + (playerCellY * 4), 4, 4, Red);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadImageColors(mapPixels);   // Unload color array

        UnloadTexture(cubicmap);        // Unload cubicmap texture
        UnloadTexture(texture);         // Unload map texture
        UnloadModel(model);             // Unload map model

        CloseWindow();                  // Close window and OpenGL context


        return 0;
    }
}
