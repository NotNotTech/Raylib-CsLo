// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;
/*******************************************************************************************
*
*   raylib [shapes] example - rectangle scaling by mouse
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class RectangleScalingMouse
{

    const int MOUSE_SCALE_MARK_SIZE = 12;

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - rectangle scaling mouse");

        Rectangle rec = new(100, 100, 200, 80);

        bool mouseScaleMode = false;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector2 mousePosition = GetMousePosition();


            bool mouseScaleReady;
            if (CheckCollisionPointRec(mousePosition, rec) &&
                CheckCollisionPointRec(mousePosition, new Rectangle(rec.X + rec.Width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.Height - MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE)))
            {
                mouseScaleReady = true;
                if (IsMouseButtonPressed(MouseButtonLeft))
                {
                    mouseScaleMode = true;
                }
            }
            else
            {
                mouseScaleReady = false;
            }

            if (mouseScaleMode)
            {
                mouseScaleReady = true;

                rec.Width = mousePosition.X - rec.X;
                rec.Height = mousePosition.Y - rec.Y;

                if (rec.Width < MOUSE_SCALE_MARK_SIZE)
                {
                    rec.Width = MOUSE_SCALE_MARK_SIZE;
                }

                if (rec.Height < MOUSE_SCALE_MARK_SIZE)
                {
                    rec.Height = MOUSE_SCALE_MARK_SIZE;
                }

                if (IsMouseButtonReleased(MouseButtonLeft))
                {
                    mouseScaleMode = false;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("Scale rectangle dragging from bottom-right corner!", 10, 10, 20, Gray);

            DrawRectangleRec(rec, Fade(Green, 0.5f));

            if (mouseScaleReady)
            {
                DrawRectangleLinesEx(rec, 1, Red);
                DrawTriangle(new Vector2(rec.X + rec.Width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.Height),
                             new Vector2(rec.X + rec.Width, rec.Y + rec.Height),
                             new Vector2(rec.X + rec.Width, rec.Y + rec.Height - MOUSE_SCALE_MARK_SIZE), Red);
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
