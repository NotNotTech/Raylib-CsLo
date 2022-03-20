// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - Gamepad input
*
*   NOTE: This example requires a Gamepad connected to the system
*         raylib is configured to work with the following gamepads:
*                - Xbox 360 Controller (Xbox 360, Xbox One)
*                - PLAYSTATION(R)3 Controller
*         Check raylib.h for buttons configuration
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

//# include "raylib.h"

//// NOTE: Gamepad name ID depends on drivers and OS
//#define XBOX360_LEGACY_NAME_ID  "Xbox Controller"
//#if defined(PLATFORM_RPI)
//#define XBOX360_NAME_ID     "Microsoft X-Box 360 pad"
//#define PS3_NAME_ID         "PLAYSTATION(R)3 Controller"
//#else
//#define XBOX360_NAME_ID     "Xbox 360 Controller"
//#define PS3_NAME_ID         "PLAYSTATION(R)3 Controller"
//#endif
namespace Raylib_CsLo.Examples.Core;
using static Consts;
public static class Consts
{
    public static readonly string XBOX360_LEGACY_NAME_ID = "Xbox Controller";
    //public static string XBOX360_NAME_ID = "Microsoft X-Box 360 pad";
    //public static string PS3_NAME_ID = "PLAYSTATION(R)3 Controller";
    public static readonly string XBOX360_NAME_ID = "Xbox 360 Controller";
    public static readonly string PS3_NAME_ID = "PLAYSTATION(R)3 Controller";
}


public static class GamepadInput
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);  // Set MSAA 4X hint before windows creation

        InitWindow(screenWidth, screenHeight, "raylib [core] example - gamepad input");

        Texture2D texPs3Pad = LoadTexture("resources/ps3.png");
        Texture2D texXboxPad = LoadTexture("resources/xbox.png");

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // ...


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            if (IsGamepadAvailable(0))
            {
                DrawText(TextFormat("GP1: %s", GetGamepadName(0)), 10, 10, 10, Black);

                if (TextIsEqual(GetGamepadName(0), XBOX360_NAME_ID) || TextIsEqual(GetGamepadName(0), XBOX360_LEGACY_NAME_ID))
                {
                    DrawTexture(texXboxPad, 0, 0, Darkgray);

                    // Draw buttons: xbox home
                    if (IsGamepadButtonDown(0, GamepadButtonMiddle))
                    {
                        DrawCircle(394, 89, 19, Red);
                    }

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(0, GamepadButtonMiddleRight))
                    {
                        DrawCircle(436, 150, 9, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonMiddleLeft))
                    {
                        DrawCircle(352, 150, 9, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceLeft))
                    {
                        DrawCircle(501, 151, 15, Blue);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceDown))
                    {
                        DrawCircle(536, 187, 15, Lime);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceRight))
                    {
                        DrawCircle(572, 151, 15, Maroon);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceUp))
                    {
                        DrawCircle(536, 115, 15, Gold);
                    }

                    // Draw buttons: d-pad
                    DrawRectangle(317, 202, 19, 71, Black);
                    DrawRectangle(293, 228, 69, 19, Black);
                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceUp))
                    {
                        DrawRectangle(317, 202, 19, 26, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceDown))
                    {
                        DrawRectangle(317, 202 + 45, 19, 26, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceLeft))
                    {
                        DrawRectangle(292, 228, 25, 19, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceRight))
                    {
                        DrawRectangle(292 + 44, 228, 26, 19, Red);
                    }

                    // Draw buttons: left-right back
                    if (IsGamepadButtonDown(0, GamepadButtonLeftTrigger1))
                    {
                        DrawCircle(259, 61, 20, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightTrigger1))
                    {
                        DrawCircle(536, 61, 20, Red);
                    }

                    // Draw axis: left joystick
                    DrawCircle(259, 152, 39, Black);
                    DrawCircle(259, 152, 34, Lightgray);
                    DrawCircle(259 + ((int)GetGamepadAxisMovement(0, GamepadAxisLeftX) * 20),
                               152 + ((int)GetGamepadAxisMovement(0, GamepadAxisLeftY) * 20), 25, Black);

                    // Draw axis: right joystick
                    DrawCircle(461, 237, 38, Black);
                    DrawCircle(461, 237, 33, Lightgray);
                    DrawCircle(461 + ((int)GetGamepadAxisMovement(0, GamepadAxisRightX) * 20),
                               237 + ((int)GetGamepadAxisMovement(0, GamepadAxisRightY) * 20), 25, Black);

                    // Draw axis: left-right triggers
                    DrawRectangle(170, 30, 15, 70, Gray);
                    DrawRectangle(604, 30, 15, 70, Gray);
                    DrawRectangle(170, 30, 15, (1 + (int)GetGamepadAxisMovement(0, GamepadAxisLeftTrigger)) / 2 * 70, Red);
                    DrawRectangle(604, 30, 15, (1 + (int)GetGamepadAxisMovement(0, GamepadAxisRightTrigger)) / 2 * 70, Red);

                    //DrawText(TextFormat("Xbox axis LT: %02.02f", GetGamepadAxisMovement(0, GAMEPAD_AXIS_LEFT_TRIGGER)), 10, 40, 10, Black);
                    //DrawText(TextFormat("Xbox axis RT: %02.02f", GetGamepadAxisMovement(0, GAMEPAD_AXIS_RIGHT_TRIGGER)), 10, 60, 10, Black);
                }
                else if (TextIsEqual(GetGamepadName(0), PS3_NAME_ID))
                {
                    DrawTexture(texPs3Pad, 0, 0, Darkgray);

                    // Draw buttons: ps
                    if (IsGamepadButtonDown(0, GamepadButtonMiddle))
                    {
                        DrawCircle(396, 222, 13, Red);
                    }

                    // Draw buttons: basic
                    if (IsGamepadButtonDown(0, GamepadButtonMiddleLeft))
                    {
                        DrawRectangle(328, 170, 32, 13, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonMiddleRight))
                    {
                        DrawTriangle(new(436, 168), new(436, 185), new(464, 177), Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceUp))
                    {
                        DrawCircle(557, 144, 13, Lime);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceRight))
                    {
                        DrawCircle(586, 173, 13, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceDown))
                    {
                        DrawCircle(557, 203, 13, Violet);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightFaceLeft))
                    {
                        DrawCircle(527, 173, 13, Pink);
                    }

                    // Draw buttons: d-pad
                    DrawRectangle(225, 132, 24, 84, Black);
                    DrawRectangle(195, 161, 84, 25, Black);
                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceUp))
                    {
                        DrawRectangle(225, 132, 24, 29, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceDown))
                    {
                        DrawRectangle(225, 132 + 54, 24, 30, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceLeft))
                    {
                        DrawRectangle(195, 161, 30, 25, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonLeftFaceRight))
                    {
                        DrawRectangle(195 + 54, 161, 30, 25, Red);
                    }

                    // Draw buttons: left-right back buttons
                    if (IsGamepadButtonDown(0, GamepadButtonLeftTrigger1))
                    {
                        DrawCircle(239, 82, 20, Red);
                    }

                    if (IsGamepadButtonDown(0, GamepadButtonRightTrigger1))
                    {
                        DrawCircle(557, 82, 20, Red);
                    }

                    // Draw axis: left joystick
                    DrawCircle(319, 255, 35, Black);
                    DrawCircle(319, 255, 31, Lightgray);
                    DrawCircle(319 + ((int)GetGamepadAxisMovement(0, GamepadAxisLeftX) * 20),
                               255 + ((int)GetGamepadAxisMovement(0, GamepadAxisLeftY) * 20), 25, Black);

                    // Draw axis: right joystick
                    DrawCircle(475, 255, 35, Black);
                    DrawCircle(475, 255, 31, Lightgray);
                    DrawCircle(475 + ((int)GetGamepadAxisMovement(0, GamepadAxisRightX) * 20),
                               255 + ((int)GetGamepadAxisMovement(0, GamepadAxisRightY) * 20), 25, Black);

                    // Draw axis: left-right triggers
                    DrawRectangle(169, 48, 15, 70, Gray);
                    DrawRectangle(611, 48, 15, 70, Gray);
                    DrawRectangle(169, 48, 15, (1 - (int)GetGamepadAxisMovement(0, GamepadAxisLeftTrigger)) / 2 * 70, Red);
                    DrawRectangle(611, 48, 15, (1 - (int)GetGamepadAxisMovement(0, GamepadAxisRightTrigger)) / 2 * 70, Red);
                }
                else
                {
                    DrawText("- GENERIC GAMEPAD -", 280, 180, 20, Gray);

                    // TODO: Draw generic gamepad
                }

                DrawText(TextFormat("DETECTED AXIS [%i]:", GetGamepadAxisCount(0)), 10, 50, 10, Maroon);

                for (int i = 0; i < GetGamepadAxisCount(0); i++)
                {
                    DrawText(TextFormat("AXIS %i: %.02f", i, GetGamepadAxisMovement(0, (GamepadAxis)i)), 20, 70 + (20 * i), 10, Darkgray);
                }

                if (GetGamepadButtonPressed() != -1)
                {
                    DrawText(TextFormat("DETECTED BUTTON: %i", GetGamepadButtonPressed()), 10, 430, 10, Red);
                }
                else
                {
                    DrawText("DETECTED BUTTON: NONE", 10, 430, 10, Gray);
                }
            }
            else
            {
                DrawText("GP1: NOT DETECTED", 10, 10, 10, Gray);

                DrawTexture(texXboxPad, 0, 0, Lightgray);
            }

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texPs3Pad);
        UnloadTexture(texXboxPad);

        CloseWindow();        // Close window and OpenGL context


        return 0;
    }


}
