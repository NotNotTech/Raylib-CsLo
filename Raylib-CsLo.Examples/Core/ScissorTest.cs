// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Scissor test
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Dill (@MysteriousSpace) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Dill (@MysteriousSpace)
*
********************************************************************************************/


namespace Raylib_CsLo.Examples.Core;

public static class ScissorTest
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - scissor test");

        Rectangle scissorArea = new(0, 0, 300, 300);
        bool scissorMode = true;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            if (IsKeyPressed(KeyS))
            {
                scissorMode = !scissorMode;
            }

            // Centre the scissor area around the mouse position
            scissorArea.X = GetMouseX() - (scissorArea.Width / 2);
            scissorArea.Y = GetMouseY() - (scissorArea.Height / 2);


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            if (scissorMode)
            {
                BeginScissorMode((int)scissorArea.X, (int)scissorArea.Y, (int)scissorArea.Width, (int)scissorArea.Height);
            }

            // Draw full screen rectangle and some text
            // NOTE: Only part defined by scissor area will be rendered
            DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Red);
            DrawText("Move the mouse around to reveal this text!", 190, 200, 20, Lightgray);

            if (scissorMode)
            {
                EndScissorMode();
            }

            DrawRectangleLinesEx(scissorArea, 1, Black);
            DrawText("Press S to toggle scissor test", 10, 10, 20, Black);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


    }
}
