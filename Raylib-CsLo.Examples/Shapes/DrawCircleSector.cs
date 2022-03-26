// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - draw circle sector (with gui options)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/
public static unsafe class DrawCircleSector
{

    //#define RAYGUI_IMPLEMENTATION
    // # include "extras/raygui.h"                 // Required for GUI controls

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw circle sector");

        Vector2 center = new((GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f);

        float outerRadius = 180.0f;
        float startAngle = 0.0f;
        float endAngle = 180.0f;
        int segments = 0;

        GuiLoadStyleDefault(); //init raygui

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // NOTE: All variables update happens inside GUI control functions


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawLine(500, 0, 500, GetScreenHeight(), Fade(Lightgray, 0.6f));
            DrawRectangle(500, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(Lightgray, 0.3f));

            DrawCircleSector(center, outerRadius, startAngle, endAngle, segments, Fade(Maroon, 0.3f));
            DrawCircleSectorLines(center, outerRadius, startAngle, endAngle, segments, Fade(Maroon, 0.6f));

            // Draw GUI controls

            startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", "", startAngle, 0, 720);
            endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", "", endAngle, 0, 720);

            outerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "Radius", "", outerRadius, 0, 200);
            segments = (int)GuiSliderBar(new Rectangle(600, 170, 120, 20), "Segments", "", segments, 0, 100);


            int minSegments = (int)MathF.Ceiling((endAngle - startAngle) / 90);
            DrawText(string.Format("MODE: {0}", (segments >= minSegments) ? "MANUAL" : "AUTO"), 600, 200, 10, (segments >= minSegments) ? Maroon : Darkgray);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context



    }
}
