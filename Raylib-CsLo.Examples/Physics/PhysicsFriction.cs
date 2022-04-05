// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Physics;

/*******************************************************************************************
*
*   raylib [physac] example - physics friction
*
*   This example has been created using raylib 1.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example uses physac 1.1 (https://github.com/raysan5/raylib/blob/master/src/physac.h)
*
*   Copyright (c) 2016-2021 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class PhysicsFriction
{

    //#define PHYSAC_IMPLEMENTATION
    //# include "extras/physac.h"

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [physac] example - physics friction");

        // Physac logo drawing position
        int logoX = screenWidth - MeasureText("Physac", 30) - 10;
        int logoY = 15;

        // Initialize physics and default physics bodies
        InitPhysics();

        // Create floor rectangle physics body
        PhysicsBodyData floor = CreatePhysicsBodyRectangle(new Vector2(screenWidth / 2.0f, screenHeight), screenWidth, 100, 10);
        floor.enabled = false; // Disable body state to convert it to static (no dynamics, but collisions)
        PhysicsBodyData wall = CreatePhysicsBodyRectangle(new Vector2(screenWidth / 2.0f, screenHeight * 0.8f), 10, 80, 10);
        wall.enabled = false; // Disable body state to convert it to static (no dynamics, but collisions)

        // Create left ramp physics body
        PhysicsBodyData rectLeft = CreatePhysicsBodyRectangle(new Vector2(25, (float)screenHeight - 5), 250, 250, 10);
        rectLeft.enabled = false; // Disable body state to convert it to static (no dynamics, but collisions)
        SetPhysicsBodyRotation(rectLeft, 30 * MathF.PI / 180);

        // Create right ramp  physics body
        PhysicsBodyData rectRight = CreatePhysicsBodyRectangle(new Vector2((float)screenWidth - 25, (float)screenHeight - 5), 250, 250, 10);
        rectRight.enabled = false; // Disable body state to convert it to static (no dynamics, but collisions)
        SetPhysicsBodyRotation(rectRight, 330 * MathF.PI / 180);

        // Create dynamic physics bodies
        PhysicsBodyData bodyA = CreatePhysicsBodyRectangle(new Vector2(35, screenHeight * 0.6f), 40, 40, 10);
        bodyA.staticFriction = 0.1f;
        bodyA.dynamicFriction = 0.1f;
        SetPhysicsBodyRotation(bodyA, 30 * MathF.PI / 180);

        PhysicsBodyData bodyB = CreatePhysicsBodyRectangle(new Vector2((float)screenWidth - 35, screenHeight * 0.6f), 40, 40, 10);
        bodyB.staticFriction = 1.0f;
        bodyB.dynamicFriction = 1.0f;
        SetPhysicsBodyRotation(bodyB, 330 * MathF.PI / 180);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdatePhysics();            // Update physics system

            if (IsKeyPressed(KeyR))    // Reset physics system
            {
                // Reset dynamic physics bodies position, velocity and rotation
                bodyA.position = new Vector2(35, screenHeight * 0.6f);
                bodyA.velocity = new Vector2(0, 0);
                bodyA.angularVelocity = 0;
                SetPhysicsBodyRotation(bodyA, 30 * MathF.PI / 180);

                bodyB.position = new Vector2((float)screenWidth - 35, screenHeight * 0.6f);
                bodyB.velocity = new Vector2(0, 0);
                bodyB.angularVelocity = 0;
                SetPhysicsBodyRotation(bodyB, 330 * MathF.PI / 180);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Black);

            DrawFPS(screenWidth - 90, screenHeight - 30);

            // Draw created physics bodies
            int bodiesCount = GetPhysicsBodiesCount();
            for (int i = 0; i < bodiesCount; i++)
            {
                PhysicsBodyData? body = GetPhysicsBody(i);

                if (body != null)
                {
                    int vertexCount = GetPhysicsShapeVerticesCount(i);
                    for (int j = 0; j < vertexCount; j++)
                    {
                        // Get physics bodies shape vertices to draw lines
                        // Note: GetPhysicsShapeVertex() already calculates rotation transformations
                        Vector2 vertexA = GetPhysicsShapeVertex(body.Value, j);

                        int jj = ((j + 1) < vertexCount) ? (j + 1) : 0;   // Get next vertex or first to close the shape
                        Vector2 vertexB = GetPhysicsShapeVertex(body.Value, jj);

                        DrawLineV(vertexA, vertexB, Green);     // Draw a line between two vertex positions
                    }
                }
            }

            DrawRectangle(0, screenHeight - 49, screenWidth, 49, Black);

            DrawText("Friction amount", (screenWidth - MeasureText("Friction amount", 30)) / 2.0f, 75, 30, White);
            DrawText("0.1", (int)bodyA.position.X - (MeasureText("0.1", 20) / 2), (int)bodyA.position.Y - 7, 20, White);
            DrawText("1", (int)bodyB.position.X - (MeasureText("1", 20) / 2), (int)bodyB.position.Y - 7, 20, White);

            DrawText("Press 'R' to reset example", 10, 10, 10, White);

            DrawText("Physac", logoX, logoY, 30, White);
            DrawText("Powered by", logoX + 50, logoY - 7, 10, White);

            EndDrawing();

        }

        // De-Initialization

        ClosePhysics();       // Unitialize physics

        CloseWindow();        // Close window and OpenGL context



    }
}
