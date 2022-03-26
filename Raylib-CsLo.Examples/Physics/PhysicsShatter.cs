// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Physics;

/*******************************************************************************************
*
*   raylib [physac] example - physics shatter
*
*   This example has been created using raylib 1.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example uses physac 1.1 (https://github.com/raysan5/raylib/blob/master/src/physac.h)
*
*   Copyright (c) 2016-2021 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class PhysicsShatter
{

    //#define PHYSAC_IMPLEMENTATION
    //# include "extras/physac.h"

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [physac] example - physics shatter");

        // Physac logo drawing position
        int logoX = screenWidth - MeasureText("Physac", 30) - 10;
        int logoY = 15;

        // Initialize physics and default physics bodies
        InitPhysics();
        SetPhysicsGravity(0, 0);

        // Create random polygon physics body to shatter
        CreatePhysicsBodyPolygon(new Vector2(screenWidth / 2.0f, screenHeight / 2.0f), GetRandomValue(80, 200), GetRandomValue(3, 8), 10);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {

            UpdatePhysics();            // Update physics system

            if (IsKeyPressed(KeyR))    // Reset physics input
            {
                ResetPhysics();

                CreatePhysicsBodyPolygon(new Vector2(screenWidth / 2.0f, screenHeight / 2.0f), GetRandomValue(80, 200), GetRandomValue(3, 8), 10);
            }

            if (IsMouseButtonPressed(MouseButtonLeft))    // Physics shatter input
            {
                int count = GetPhysicsBodiesCount();
                for (int i = count - 1; i >= 0; i--)
                {
                    PhysicsBodyData? currentBody = GetPhysicsBody(i);

                    if (currentBody != null)
                    {
                        PhysicsShatter(currentBody.Value, GetMousePosition(), 10 / currentBody.Value.inverseMass);
                    }
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Black);

            // Draw created physics bodies
            int bodiesCount = GetPhysicsBodiesCount();
            for (int i = 0; i < bodiesCount; i++)
            {
                PhysicsBodyData currentBody = GetPhysicsBody(i);

                int vertexCount = GetPhysicsShapeVerticesCount(i);
                for (int j = 0; j < vertexCount; j++)
                {
                    // Get physics bodies shape vertices to draw lines
                    // Note: GetPhysicsShapeVertex() already calculates rotation transformations
                    Vector2 vertexA = GetPhysicsShapeVertex(currentBody, j);

                    int jj = ((j + 1) < vertexCount) ? (j + 1) : 0;   // Get next vertex or first to close the shape
                    Vector2 vertexB = GetPhysicsShapeVertex(currentBody, jj);

                    DrawLineV(vertexA, vertexB, Green);     // Draw a line between two vertex positions
                }
            }

            DrawText("Left mouse button in polygon area to shatter body\nPress 'R' to reset example", 10, 10, 10, White);

            DrawText("Physac", logoX, logoY, 30, White);
            DrawText("Powered by", logoX + 50, logoY - 7, 10, White);

            EndDrawing();

        }

        // De-Initialization

        ClosePhysics();       // Unitialize physics

        CloseWindow();        // Close window and OpenGL context



    }
}
