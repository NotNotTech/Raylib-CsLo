// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - World to screen
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class WorldScreen
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d camera free");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
        camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
        camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;                   // Camera mode type

        Vector3 cubePosition = new(1.0f, 5.0f, 5.0f);

        SetCameraMode(camera, CameraFree); // Set a free camera mode

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);          // Update camera

            // Calculate cube screen space position (with a little offset to be in top)
            Vector2 cubeScreenPosition = GetWorldToScreen(new(cubePosition.X, cubePosition.Y + 2.5f, cubePosition.Z), camera);


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Red);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Maroon);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawText("Enemy: 100 / 100", (int)cubeScreenPosition.X - (MeasureText("Enemy: 100/100", 20) / 2), (int)cubeScreenPosition.Y, 20, Black);
            DrawText("Text is always on top of the cube", (screenWidth - MeasureText("Text is always on top of the cube", 20)) / 2, 25, 20, Gray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }
}
