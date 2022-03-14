// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Input Gestures Detection
*
*   This example has been created using raylib 1.4 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Core;

public static class InputGesturesDetection
{
    const int MAX_GESTURE_STRINGS = 20;

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - input gestures");
        Rectangle touchArea = new(220, 10, screenWidth - 230.0f, screenHeight - 20.0f);

        int gesturesCount = 0;
        //char gestureStrings[MAX_GESTURE_STRINGS][32];
        string[] gestureStrings = new string[MAX_GESTURE_STRINGS];

        Gesture currentGesture = GESTURE_NONE;

        //SetGesturesEnabled(0b0000000000001001);   // Enable only some gestures to be detected

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Gesture lastGesture = currentGesture;
            currentGesture = GetGestureDetected();
            Vector2 touchPosition = GetTouchPosition(0);

            if (CheckCollisionPointRec(touchPosition, touchArea) && (currentGesture != GESTURE_NONE))
            {
                if (currentGesture != lastGesture)
                {
                    // Store gesture string
                    switch (currentGesture)
                    {
                        case GESTURE_TAP:
                            gestureStrings[gesturesCount] = "GESTURE TAP";
                            break;
                        case GESTURE_DOUBLETAP:
                            gestureStrings[gesturesCount] = "GESTURE DOUBLETAP";
                            break;
                        case GESTURE_HOLD:
                            gestureStrings[gesturesCount] = "GESTURE HOLD";
                            break;
                        case GESTURE_DRAG:
                            gestureStrings[gesturesCount] = "GESTURE DRAG";
                            break;
                        case GESTURE_SWIPE_RIGHT:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE RIGHT";
                            break;
                        case GESTURE_SWIPE_LEFT:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE LEFT";
                            break;
                        case GESTURE_SWIPE_UP:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE UP";
                            break;
                        case GESTURE_SWIPE_DOWN:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE DOWN";
                            break;
                        case GESTURE_PINCH_IN:
                            gestureStrings[gesturesCount] = "GESTURE PINCH IN";
                            break;
                        case GESTURE_PINCH_OUT:
                            gestureStrings[gesturesCount] = "GESTURE PINCH OUT";
                            break;
                        case GESTURE_NONE:
                            break;
                        default:
                            break;
                    }

                    gesturesCount++;

                    // Reset gestures strings
                    if (gesturesCount >= MAX_GESTURE_STRINGS)
                    {
                        for (int i = 0; i < MAX_GESTURE_STRINGS; i++)
                        {
                            gestureStrings[i] = "";
                        }

                        gesturesCount = 0;
                    }
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            DrawRectangleRec(touchArea, GRAY);
            DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30, RAYWHITE);

            DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20, Fade(GRAY, 0.5f));

            for (int i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0)
                {
                    DrawRectangle(10, 30 + (20 * i), 200, 20, Fade(LIGHTGRAY, 0.5f));
                }
                else
                {
                    DrawRectangle(10, 30 + (20 * i), 200, 20, Fade(LIGHTGRAY, 0.3f));
                }

                if (i < gesturesCount - 1)
                {
                    DrawText(gestureStrings[i], 35, 36 + (20 * i), 10, DARKGRAY);
                }
                else
                {
                    DrawText(gestureStrings[i], 35, 36 + (20 * i), 10, MAROON);
                }
            }

            DrawRectangleLines(10, 29, 200, screenHeight - 50, GRAY);
            DrawText("DETECTED GESTURES", 50, 15, 10, GRAY);

            if (currentGesture != GESTURE_NONE)
            {
                DrawCircleV(touchPosition, 30, MAROON);
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context

        return 0;
    }
}
