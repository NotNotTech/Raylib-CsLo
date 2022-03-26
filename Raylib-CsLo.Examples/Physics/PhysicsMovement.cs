// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Physics;

/*******************************************************************************************
*
*   raylib [physac] example - physics movement
*
*   This example has been created using raylib 1.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example uses physac 1.1 (https://github.com/raysan5/raylib/blob/master/src/physac.h)
*
*   Copyright (c) 2016-2021 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class PhysicsMovement
{

    //#define PHYSAC_IMPLEMENTATION
    //# include "extras/physac.h"

    const float VELOCITY = 0.5f;

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [physac] example - physics movement");

        // Physac logo drawing position
        int logoX = screenWidth - MeasureText("Physac", 30) - 10;
        int logoY = 15;

        // Initialize physics and default physics bodies
        InitPhysics();

        // Create floor and walls rectangle physics body
        PhysicsBodyData floor = CreatePhysicsBodyRectangle(new Vector2(screenWidth / 2.0f, screenHeight), screenWidth, 100, 10);
        PhysicsBodyData platformLeft = CreatePhysicsBodyRectangle(new Vector2(screenWidth * 0.25f, screenHeight * 0.6f), screenWidth * 0.25f, 10, 10);
        PhysicsBodyData platformRight = CreatePhysicsBodyRectangle(new Vector2(screenWidth * 0.75f, screenHeight * 0.6f), screenWidth * 0.25f, 10, 10);
        PhysicsBodyData wallLeft = CreatePhysicsBodyRectangle(new Vector2(-5, screenHeight / 2.0f), 10, screenHeight, 10);
        PhysicsBodyData wallRight = CreatePhysicsBodyRectangle(new Vector2((float)screenWidth + 5, screenHeight / 2.0f), 10, screenHeight, 10);

        // Disable dynamics to floor and walls physics bodies
        floor.enabled = false;
        platformLeft.enabled = false;
        platformRight.enabled = false;
        wallLeft.enabled = false;
        wallRight.enabled = false;

        // Create movement physics body
        PhysicsBodyData body = CreatePhysicsBodyRectangle(new Vector2(screenWidth / 2.0f, screenHeight / 2.0f), 50, 50, 1);
        body.freezeOrient = true;      // Constrain body rotation to avoid little collision torque amounts

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdatePhysics();              // Update physics system

            if (IsKeyPressed(KeyR))      // Reset physics input
            {
                // Reset movement physics body position, velocity and rotation
                body.position = new Vector2(screenWidth / 2.0f, screenHeight / 2.0f);
                body.velocity = new Vector2(0, 0);
                SetPhysicsBodyRotation(body, 0);
            }

            // Horizontal movement input
            if (IsKeyDown(KeyRight))
            {
                body.velocity.X = VELOCITY;
            }
            else if (IsKeyDown(KeyLeft))
            {
                body.velocity.X = -VELOCITY;
            }

            // Vertical movement input checking if player physics body is grounded
            if (IsKeyDown(KeyUp) && body.isGrounded)
            {
                body.velocity.Y = -VELOCITY * 4;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Black);

            DrawFPS(screenWidth - 90, screenHeight - 30);

            // Draw created physics bodies
            int bodiesCount = GetPhysicsBodiesCount();
            for (int i = 0; i < bodiesCount; i++)
            {
                body = GetPhysicsBody(i);

                int vertexCount = GetPhysicsShapeVerticesCount(i);
                for (int j = 0; j < vertexCount; j++)
                {
                    // Get physics bodies shape vertices to draw lines
                    // Note: GetPhysicsShapeVertex() already calculates rotation transformations
                    Vector2 vertexA = GetPhysicsShapeVertex(body, j);

                    int jj = ((j + 1) < vertexCount) ? (j + 1) : 0;   // Get next vertex or first to close the shape
                    Vector2 vertexB = GetPhysicsShapeVertex(body, jj);

                    DrawLineV(vertexA, vertexB, Green);     // Draw a line between two vertex positions
                }
            }

            DrawText("Use 'ARROWS' to move player", 10, 10, 10, White);
            DrawText("Press 'R' to reset example", 10, 30, 10, White);

            DrawText("Physac", logoX, logoY, 30, White);
            DrawText("Powered by", logoX + 50, logoY - 7, 10, White);

            EndDrawing();

        }

        // De-Initialization

        ClosePhysics();       // Unitialize physics

        CloseWindow();        // Close window and OpenGL context



    }
}
