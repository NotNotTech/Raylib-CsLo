// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - Colors palette
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class ColorsPalette
{

    const int MAX_COLORS_COUNT = 21;          // Number of colors available

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [shapes] example - colors palette");

        Color[] colors = new Color[MAX_COLORS_COUNT] {
        Darkgray, Maroon, Orange, Darkgreen, Darkblue, Darkpurple, Darkbrown,
        Gray, Red, Gold, Lime, Blue, Violet, Brown, Lightgray, Pink, Yellow,
        Green, Skyblue, Purple, Beige };

        string[] colorNames = new string[MAX_COLORS_COUNT] {
        "Darkgray", "Maroon", "Orange", "Darkgreen", "Darkblue", "Darkpurple",
        "Darkbrown", "Gray", "Red", "Gold", "Lime", "Blue", "Violet", "Brown",
        "Lightgray", "Pink", "Yellow", "Green", "Skyblue", "Purple", "Beige" };

        Rectangle[] colorsRecs = new Rectangle[MAX_COLORS_COUNT];     // Rectangles array

        // Fills colorsRecs data (for every rectangle)
        for (int i = 0; i < MAX_COLORS_COUNT; i++)
        {
            colorsRecs[i].X = 20.0f + (100.0f * (i % 7)) + (10.0f * (i % 7));
            colorsRecs[i].Y = 80.0f + (100.0f * (i / 7)) + (10.0f * (i / 7));
            colorsRecs[i].Width = 100.0f;
            colorsRecs[i].Height = 100.0f;
        }

        int[] colorState = new int[MAX_COLORS_COUNT];           // Color state: 0-DEFAULT, 1-MOUSE_HOVER

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector2 mousePoint = GetMousePosition();

            for (int i = 0; i < MAX_COLORS_COUNT; i++)
            {
                if (CheckCollisionPointRec(mousePoint, colorsRecs[i]))
                {
                    colorState[i] = 1;
                }
                else
                {
                    colorState[i] = 0;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("raylib colors palette", 28, 42, 20, Black);
            DrawText("press SPACE to see all colors", GetScreenWidth() - 180, GetScreenHeight() - 40, 10, Gray);

            for (int i = 0; i < MAX_COLORS_COUNT; i++)    // Draw all rectangles
            {
                DrawRectangleRec(colorsRecs[i], Fade(colors[i], colorState[i] == 1 ? 0.6f : 1.0f));

                if (IsKeyDown(KeySpace) || colorState[i] == 1)
                {
                    DrawRectangle((int)colorsRecs[i].X, (int)(colorsRecs[i].Y + colorsRecs[i].Height - 26), (int)colorsRecs[i].Width, 20, Black);
                    DrawRectangleLinesEx(colorsRecs[i], 6, Fade(Black, 0.3f));
                    DrawText(colorNames[i], (int)(colorsRecs[i].X + colorsRecs[i].Width - MeasureText(colorNames[i], 10) - 12),
                        (int)(colorsRecs[i].Y + colorsRecs[i].Height - 20), 10, colors[i]);
                }
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();                // Close window and OpenGL context


        return 0;
    }
}
