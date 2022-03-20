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

        Gesture currentGesture = GestureNone;

        //SetGesturesEnabled(0b0000000000001001);   // Enable only some gestures to be detected

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Gesture lastGesture = currentGesture;
            currentGesture = GetGestureDetected();
            Vector2 touchPosition = GetTouchPosition(0);

            if (CheckCollisionPointRec(touchPosition, touchArea) && (currentGesture != GestureNone))
            {
                if (currentGesture != lastGesture)
                {
                    // Store gesture string
                    switch (currentGesture)
                    {
                        case GestureTap:
                            gestureStrings[gesturesCount] = "GESTURE TAP";
                            break;
                        case GestureDoubletap:
                            gestureStrings[gesturesCount] = "GESTURE DOUBLETAP";
                            break;
                        case GestureHold:
                            gestureStrings[gesturesCount] = "GESTURE HOLD";
                            break;
                        case GestureDrag:
                            gestureStrings[gesturesCount] = "GESTURE DRAG";
                            break;
                        case GestureSwipeRight:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE RIGHT";
                            break;
                        case GestureSwipeLeft:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE LEFT";
                            break;
                        case GestureSwipeUp:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE UP";
                            break;
                        case GestureSwipeDown:
                            gestureStrings[gesturesCount] = "GESTURE SWIPE DOWN";
                            break;
                        case GesturePinchIn:
                            gestureStrings[gesturesCount] = "GESTURE PINCH IN";
                            break;
                        case GesturePinchOut:
                            gestureStrings[gesturesCount] = "GESTURE PINCH OUT";
                            break;
                        case GestureNone:
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

            ClearBackground(Raywhite);

            DrawRectangleRec(touchArea, Gray);
            DrawRectangle(225, 15, screenWidth - 240, screenHeight - 30, Raywhite);

            DrawText("GESTURES TEST AREA", screenWidth - 270, screenHeight - 40, 20, Fade(Gray, 0.5f));

            for (int i = 0; i < gesturesCount; i++)
            {
                if (i % 2 == 0)
                {
                    DrawRectangle(10, 30 + (20 * i), 200, 20, Fade(Lightgray, 0.5f));
                }
                else
                {
                    DrawRectangle(10, 30 + (20 * i), 200, 20, Fade(Lightgray, 0.3f));
                }

                if (i < gesturesCount - 1)
                {
                    DrawText(gestureStrings[i], 35, 36 + (20 * i), 10, Darkgray);
                }
                else
                {
                    DrawText(gestureStrings[i], 35, 36 + (20 * i), 10, Maroon);
                }
            }

            DrawRectangleLines(10, 29, 200, screenHeight - 50, Gray);
            DrawText("DETECTED GESTURES", 50, 15, 10, Gray);

            if (currentGesture != GestureNone)
            {
                DrawCircleV(touchPosition, 30, Maroon);
            }

            EndDrawing();

        }

        // De-Initialization

        CloseWindow();        // Close window and OpenGL context

        return 0;
    }
}
