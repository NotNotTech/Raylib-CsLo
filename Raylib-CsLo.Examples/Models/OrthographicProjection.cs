// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Show the difference between perspective and orthographic projection
//*
//* This program is heavily based on the geometric objects example
//*
//* This example has been created using raylib 2.0 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Example contributed by Max Danielsson(@autious) and reviewed by Ramon Santamaria(@raysan5)
//*
//* Copyright(c) 2018 Max Danielsson(@autious) and Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static class OrthographicProjection
{
    const float FOVY_PERSPECTIVE = 45.0f;
    const float WIDTH_ORTHOGRAPHIC = 10.0f;
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

        // Define the camera to look into our 3d world
        Camera3D camera = new(new(0.0f, 10.0f, 10.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), FOVY_PERSPECTIVE, CameraPerspective);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyPressed(KeySpace))
            {
                if (camera.Projection == CameraPerspective)
                {
                    camera.fovy = WIDTH_ORTHOGRAPHIC;
                    camera.Projection = CameraOrthographic;
                }
                else
                {
                    camera.fovy = FOVY_PERSPECTIVE;
                    camera.Projection = CameraPerspective;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawCube(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Red);
            DrawCubeWires(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, Gold);
            DrawCubeWires(new(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, Maroon);

            DrawSphere(new(-1.0f, 0.0f, -2.0f), 1.0f, Green);
            DrawSphereWires(new(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, Lime);

            DrawCylinder(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Skyblue);
            DrawCylinderWires(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, Darkblue);
            DrawCylinderWires(new(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, Brown);

            DrawCylinder(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Gold);
            DrawCylinderWires(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, Pink);

            DrawGrid(10, 1.0f);        // Draw a grid

            EndMode3D();

            DrawText("Press Spacebar to switch camera type", 10, GetScreenHeight() - 30, 20, Darkgray);

            if (camera.Projection == CameraOrthographic)
            {
                DrawText("ORTHOGRAPHIC", 10, 40, 20, Black);
            }
            else if (camera.Projection == CameraPerspective)
            {
                DrawText("PERSPECTIVE", 10, 40, 20, Black);
            }

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
