// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


namespace Raylib_CsLo.Examples.Core;

/*******************************************************************************************
*
*   raylib [core] example - Windows drop files
*
*   This example only works on platforms that support drag & drop (Windows, Linux, OSX, Html5?)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
public static class DropFiles
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - drop files");

        string[] droppedFiles;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second

        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            BeginDrawing();

            ClearBackground(Raywhite);

            if (IsFileDropped())
            {
                droppedFiles = GetDroppedFiles();

                Console.WriteLine(droppedFiles[0]);

                DrawText("Dropped files:", 100, 40, 20, Darkgray);

                for (int i = 0; i < droppedFiles.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        DrawRectangle(0, 85 + (40 * i), screenWidth, 40, Fade(Lightgray, 0.5f));
                    }
                    else
                    {
                        DrawRectangle(0, 85 + (40 * i), screenWidth, 40, Fade(Lightgray, 0.3f));
                    }
                    if (IsFileDropped())
                    {
                        DrawText(droppedFiles[i], 120, 100 + (40 * i), 10, Gray);
                    }
                }

                DrawText("Drop new files...", 100, 110 + (40 * droppedFiles.Length), 20, Darkgray);
            }
            else
            {
                DrawText("Drop your files to this window!", 100, 40, 20, Darkgray);
            }

            EndDrawing();

        }

        // De-Initialization

        ClearDroppedFiles();    // Clear internal buffers

        CloseWindow();          // Close window and OpenGL context

    }
}
