// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Initialize 3d camera free
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static unsafe class Camera3dFree
{

    public static int Example()
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

        Vector3 cubePosition = new(0.0f, 0.0f, 0.0f);

        SetCameraMode(camera, CameraFree); // Set a free camera mode

        SetCameraPanControl((int)MouseButtonRight);

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);          // Update camera

            if (IsKeyDown('Z'))
            {
                camera.target = new(0.0f, 0.0f, 0.0f);
            }

            if (IsKeyDown('Z'))
            {
                camera.target = new(0.0f, 0.0f, 0.0f);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawCube(cubePosition, 2.0f, 2.0f, 2.0f, Red);
            DrawCubeWires(cubePosition, 2.0f, 2.0f, 2.0f, Maroon);

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawRectangle(10, 10, 320, 133, Fade(Skyblue, 0.5f));
            DrawRectangleLines(10, 10, 320, 133, Blue);

            DrawText("Free camera default controls:", 20, 20, 10, Black);
            DrawText("- Mouse Wheel to Zoom in-out", 40, 40, 10, Darkgray);
            DrawText("- Mouse Right Pressed to Pan", 40, 60, 10, Darkgray);
            DrawText("- Alt + Mouse Right Pressed to Rotate", 40, 80, 10, Darkgray);
            DrawText("- Alt + Ctrl + Mouse Right Pressed for Smooth Zoom", 40, 100, 10, Darkgray);
            DrawText("- Z to zoom to (0, 0, 0)", 40, 120, 10, Darkgray);

            EndDrawing();

        }



        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
