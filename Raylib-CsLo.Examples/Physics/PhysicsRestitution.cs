// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Physics;

/*******************************************************************************************
*
*   raylib [physac] example - physics restitution
*
*   This example has been created using raylib 1.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   This example uses physac 1.1 (https://github.com/raysan5/raylib/blob/master/src/physac.h)
*
*   Copyright (c) 2016-2021 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class PhysicsRestitution
{

    //#define PHYSAC_IMPLEMENTATION
    //# include "extras/physac.h"

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);
        InitWindow(screenWidth, screenHeight, "raylib [physac] example - physics restitution");

        // Physac logo drawing position
        int logoX = screenWidth - MeasureText("Physac", 30) - 10;
        int logoY = 15;

        // Initialize physics and default physics bodies
        InitPhysics();

        // Create floor rectangle physics body
        PhysicsBodyData floor = CreatePhysicsBodyRectangle(new Vector2(screenWidth / 2.0f, screenHeight), screenWidth, 100, 10);
        floor.enabled = false; // Disable body state to convert it to static (no dynamics, but collisions)
        floor.restitution = 1;

        // Create circles physics body
        PhysicsBodyData circleA = CreatePhysicsBodyCircle(new Vector2(screenWidth * 0.25f, screenHeight / 2.0f), 30, 10);
        circleA.restitution = 0;
        PhysicsBodyData circleB = CreatePhysicsBodyCircle(new Vector2(screenWidth * 0.5f, screenHeight / 2.0f), 30, 10);
        circleB.restitution = 0.5f;
        PhysicsBodyData circleC = CreatePhysicsBodyCircle(new Vector2(screenWidth * 0.75f, screenHeight / 2.0f), 30, 10);
        circleC.restitution = 1;

        // Restitution demo needs a very tiny physics time step for a proper simulation
        SetPhysicsTimeStep(1.0 / 60.0 / 100 * 1000);

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdatePhysics();            // Update physics system

            if (IsKeyPressed(KeyR))    // Reset physics input
            {
                // Reset circles physics bodies position and velocity
                circleA.position = new Vector2(screenWidth * 0.25f, screenHeight / 2.0f);
                circleA.velocity = new Vector2(0, 0);
                circleB.position = new Vector2(screenWidth * 0.5f, screenHeight / 2.0f);
                circleB.velocity = new Vector2(0, 0);
                circleC.position = new Vector2(screenWidth * 0.75f, screenHeight / 2.0f);
                circleC.velocity = new Vector2(0, 0);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Black);

            DrawFPS(screenWidth - 90, screenHeight - 30);

            // Draw created physics bodies
            int bodiesCount = GetPhysicsBodiesCount();
            for (int i = 0; i < bodiesCount; i++)
            {
                PhysicsBodyData body = GetPhysicsBody(i);

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

            DrawText("Restitution amount", (screenWidth - MeasureText("Restitution amount", 30)) / 2, 75, 30, White);
            DrawText("0", (int)circleA.position.X - (MeasureText("0", 20) / 2), circleA.position.Y - 7, 20, White);
            DrawText("0.5", (int)circleB.position.X - (MeasureText("0.5", 20) / 2), circleB.position.Y - 7, 20, White);
            DrawText("1", (int)circleC.position.X - (MeasureText("1", 20) / 2), circleC.position.Y - 7, 20, White);

            DrawText("Press 'R' to reset example", 10, 10, 10, White);

            DrawText("Physac", logoX, logoY, 30, White);
            DrawText("Powered by", logoX + 50, logoY - 7, 10, White);

            EndDrawing();

        }

        // De-Initialization

        DestroyPhysicsBody(circleA);
        DestroyPhysicsBody(circleB);
        DestroyPhysicsBody(circleC);
        DestroyPhysicsBody(floor);

        ClosePhysics();       // Unitialize physics

        CloseWindow();        // Close window and OpenGL context



    }
}
