// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - 3d camera first person
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class Camera3dFirstPerson
{
    const int MAX_COLUMNS = 20;
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera first person");

        // Define the camera to look into our 3d world (position, target, up vector)
        Camera3D camera = new();
        camera.position = new(4.0f, 2.0f, 4.0f);
        camera.target = new(0.0f, 1.8f, 0.0f);
        camera.up = new(0.0f, 1.0f, 0.0f);
        camera.fovy = 60.0f;
        camera.Projection = CameraPerspective;

        // Generates some random columns
        float[] heights = new float[MAX_COLUMNS];
        Vector3[] positions = new Vector3[MAX_COLUMNS];
        Color[] colors = new Color[MAX_COLUMNS];

        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            heights[i] = GetRandomValue(1, 12);
            positions[i] = new(GetRandomValue(-15, 15), heights[i] / 2.0f, GetRandomValue(-15, 15));
            colors[i] = new(GetRandomValue(20, 255), GetRandomValue(10, 55), 30, 255);
        }

        SetCameraMode(camera, CameraFirstPerson); // Set a first person camera mode

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

            DrawPlane(new(0.0f, 0.0f, 0.0f), new(32.0f, 32.0f), Lightgray); // Draw ground
            DrawCube(new(-16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f, Blue);     // Draw a Blue wall
            DrawCube(new(16.0f, 2.5f, 0.0f), 1.0f, 5.0f, 32.0f, Lime);      // Draw a Green wall
            DrawCube(new(0.0f, 2.5f, 16.0f), 32.0f, 5.0f, 1.0f, Gold);      // Draw a Yellow wall

            // Draw some cubes around
            for (int i = 0; i < MAX_COLUMNS; i++)
            {
                DrawCube(positions[i], 2.0f, heights[i], 2.0f, colors[i]);
                DrawCubeWires(positions[i], 2.0f, heights[i], 2.0f, Maroon);
            }

            EndMode3D();

            DrawRectangle(10, 10, 220, 70, Fade(Skyblue, 0.5f));
            DrawRectangleLines(10, 10, 220, 70, Blue);

            DrawText("First person camera default controls:", 20, 20, 10, Black);
            DrawText("- Move with keys: W, A, S, D", 40, 40, 10, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }
}
