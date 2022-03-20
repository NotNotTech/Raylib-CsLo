// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] examples - basic screen manager
*
*   This example illustrates a very simple screen manager based on a states machines
*
*   This test has been created using raylib 1.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2021 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Core;

using static BasicScreenManager.GameScreen;
public static class BasicScreenManager
{

    public enum GameScreen { LOGO = 0, TITLE, GAMEPLAY, ENDING }

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - basic screen manager");


        GameScreen currentScreen = LOGO;

        // TODO: Initialize all required variables and load all required data here!

        int framesCounter = 0; // Useful to count frames

        SetTargetFPS(60); // Set desired framerate (frames-per-second)


        // Main game loop
        while (!WindowShouldClose()) // Detect window close button or ESC key
        {
            // Update

            switch (currentScreen)
            {
                case LOGO:
                {
                    // TODO: Update LOGO screen variables here!

                    framesCounter++; // Count frames

                    // Wait for 2 seconds (120 frames) before jumping to TITLE screen
                    if (framesCounter > 120)
                    {
                        currentScreen = TITLE;
                    }
                }
                break;
                case TITLE:
                {
                    // TODO: Update TITLE screen variables here!

                    // Press enter to change to GAMEPLAY screen
                    if (IsKeyPressed(KeyEnter) || IsGestureDetected(GestureTap))
                    {
                        currentScreen = GAMEPLAY;
                    }
                }
                break;
                case GAMEPLAY:
                {
                    // TODO: Update GAMEPLAY screen variables here!

                    // Press enter to change to ENDING screen
                    if (IsKeyPressed(KeyEnter) || IsGestureDetected(GestureTap))
                    {
                        currentScreen = ENDING;
                    }
                }
                break;
                case ENDING:
                {
                    // TODO: Update ENDING screen variables here!

                    // Press enter to return to TITLE screen
                    if (IsKeyPressed(KeyEnter) || IsGestureDetected(GestureTap))
                    {
                        currentScreen = TITLE;
                    }
                }
                break;
                default:
                    break;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            switch (currentScreen)
            {
                case LOGO:
                {
                    // TODO: Draw LOGO screen here!
                    DrawText("LOGO SCREEN", 20, 20, 40, Lightgray);
                    DrawText("WAIT for 2 SECONDS...", 290, 220, 20, Gray);

                }
                break;
                case TITLE:
                {
                    // TODO: Draw TITLE screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Green);
                    DrawText("TITLE SCREEN", 20, 20, 40, Darkgreen);
                    DrawText("PRESS ENTER or TAP to JUMP to GAMEPLAY SCREEN", 120, 220, 20, Darkgreen);

                }
                break;
                case GAMEPLAY:
                {
                    // TODO: Draw GAMEPLAY screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Purple);
                    DrawText("GAMEPLAY SCREEN", 20, 20, 40, Maroon);
                    DrawText("PRESS ENTER or TAP to JUMP to ENDING SCREEN", 130, 220, 20, Maroon);

                }
                break;
                case ENDING:
                {
                    // TODO: Draw ENDING screen here!
                    DrawRectangle(0, 0, screenWidth, screenHeight, Blue);
                    DrawText("ENDING SCREEN", 20, 20, 40, Darkblue);
                    DrawText("PRESS ENTER or TAP to RETURN to TITLE SCREEN", 120, 220, 20, Darkblue);

                }
                break;
                default:
                    break;
            }

            EndDrawing();

        }

        // De-Initialization


        // TODO: Unload all loaded data (textures, fonts, audio) here!

        CloseWindow(); // Close window and OpenGL context


        return 0;
    }
}
