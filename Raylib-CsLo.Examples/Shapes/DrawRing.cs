// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - draw ring (with gui options)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class DrawRing
{

    //#define RAYGUI_IMPLEMENTATION
    //# include "extras/raygui.h"                 // Required for GUI controls

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw ring");

        Vector2 center = new((GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f);

        float innerRadius = 80.0f;
        float outerRadius = 190.0f;

        float startAngle = 0.0f;
        float endAngle = 360.0f;
        int segments = 0;

        bool drawRing = true;
        bool drawRingLines = false;
        bool drawCircleLines = false;

        GuiLoadStyleDefault(); //init raygui

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // NOTE: All variables update happens inside GUI control functions


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            DrawLine(500, 0, 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.6f));
            DrawRectangle(500, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.3f));

            if (drawRing)
            {
                DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, Fade(MAROON, 0.3f));
            }

            if (drawRingLines)
            {
                DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, Fade(BLACK, 0.4f));
            }

            if (drawCircleLines)
            {
                DrawCircleSectorLines(center, outerRadius, startAngle, endAngle, segments, Fade(BLACK, 0.4f));
            }

            // Draw GUI controls

            startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", null, startAngle, -450, 450);
            endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", null, endAngle, -450, 450);

            innerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "InnerRadius", null, innerRadius, 0, 100);
            outerRadius = GuiSliderBar(new Rectangle(600, 170, 120, 20), "OuterRadius", null, outerRadius, 0, 200);

            segments = (int)GuiSliderBar(new Rectangle(600, 240, 120, 20), "Segments", null, segments, 0, 100);

            drawRing = GuiCheckBox(new Rectangle(600, 320, 20, 20), "Draw Ring", drawRing);
            drawRingLines = GuiCheckBox(new Rectangle(600, 350, 20, 20), "Draw RingLines", drawRingLines);
            drawCircleLines = GuiCheckBox(new Rectangle(600, 380, 20, 20), "Draw CircleLines", drawCircleLines);


            int minSegments = (int)MathF.Ceiling((endAngle - startAngle) / 90);
            DrawText(TextFormat("MODE: %s", (segments >= minSegments) ? "MANUAL" : "AUTO"), 600, 270, 10, (segments >= minSegments) ? MAROON : DARKGRAY);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }
}
