// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - collision area
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class CollisionArea
{
    // #include <stdlib.h>     // Required for abs()

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - collision area");

        // Box A: Moving box
        Rectangle boxA = new(10, (GetScreenHeight() / 2.0f) - 50, 200, 100);
        int boxASpeedX = 4;

        // Box B: Mouse moved box
        Rectangle boxB = new((GetScreenWidth() / 2.0f) - 30, (GetScreenHeight() / 2.0f) - 30, 60, 60);

        Rectangle boxCollision = new(); // Collision rectangle

        int screenUpperLimit = 40;      // Top menu limits

        bool pause = false;             // Movement pause

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // Move box if not paused
            if (!pause)
            {
                boxA.X += boxASpeedX;
            }

            // Bounce box on x screen limits
            if (((boxA.X + boxA.width) >= GetScreenWidth()) || (boxA.X <= 0))
            {
                boxASpeedX *= -1;
            }

            // Update player-controlled-box (box02)
            boxB.X = GetMouseX() - (boxB.width / 2);
            boxB.Y = GetMouseY() - (boxB.height / 2);

            // Make sure Box B does not go out of move area limits
            if ((boxB.X + boxB.width) >= GetScreenWidth())
            {
                boxB.X = GetScreenWidth() - boxB.width;
            }
            else if (boxB.X <= 0)
            {
                boxB.X = 0;
            }

            if ((boxB.Y + boxB.height) >= GetScreenHeight())
            {
                boxB.Y = GetScreenHeight() - boxB.height;
            }
            else if (boxB.Y <= screenUpperLimit)
            {
                boxB.Y = screenUpperLimit;
            }

            // Check boxes collision
            bool collision = CheckCollisionRecs(boxA, boxB);

            // Get collision rectangle (only on collision)
            if (collision)
            {
                boxCollision = GetCollisionRec(boxA, boxB);
            }

            // Pause Box A movement
            if (IsKeyPressed(KEY_SPACE))
            {
                pause = !pause;
            }


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            DrawRectangle(0, 0, screenWidth, screenUpperLimit, collision ? RED : BLACK);

            DrawRectangleRec(boxA, GOLD);
            DrawRectangleRec(boxB, BLUE);

            if (collision)
            {
                // Draw collision area
                DrawRectangleRec(boxCollision, LIME);

                // Draw collision message
                DrawText("COLLISION!", (GetScreenWidth() / 2) - (MeasureText("COLLISION!", 20) / 2), (screenUpperLimit / 2) - 10, 20, BLACK);

                // Draw collision area
                DrawText(TextFormat("Collision Area: %i", (int)boxCollision.width * (int)boxCollision.height), (GetScreenWidth() / 2) - 100, screenUpperLimit + 10, 20, BLACK);
            }

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
