// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Audio;

/*******************************************************************************************
*
*   raylib [audio] example - Music playing (streaming)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class MusicPlayingStreaming
{

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - music playing (streaming)");

        InitAudioDevice();              // Initialize audio device

        Music music = LoadMusicStream("resources/country.mp3");

        PlayMusicStream(music);
        bool pause = false;

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdateMusicStream(music);   // Update music buffer with new stream data

            // Restart music playing (stop and play)
            if (IsKeyPressed(KeySpace))
            {
                StopMusicStream(music);
                PlayMusicStream(music);
            }

            // Pause/Resume music playing
            if (IsKeyPressed(KeyP))
            {
                pause = !pause;

                if (pause)
                {
                    PauseMusicStream(music);
                }
                else
                {
                    ResumeMusicStream(music);
                }
            }

            // Get timePlayed scaled to bar dimensions (400 pixels)
            float timePlayed = GetMusicTimePlayed(music) / GetMusicTimeLength(music) * 400;

            if (timePlayed > 400)
            {
                StopMusicStream(music);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("MUSIC SHOULD BE PLAYING!", 255, 150, 20, Lightgray);

            DrawRectangle(200, 200, 400, 12, Lightgray);
            DrawRectangle(200, 200, (int)timePlayed, 12, Maroon);
            DrawRectangleLines(200, 200, 400, 12, Gray);

            DrawText("PRESS SPACE TO RESTART MUSIC", 215, 250, 20, Lightgray);
            DrawText("PRESS P TO PAUSE/RESUME MUSIC", 208, 280, 20, Lightgray);

            EndDrawing();

        }

        // De-Initialization

        UnloadMusicStream(music);   // Unload music stream buffers from RAM

        CloseAudioDevice();         // Close audio device (music streaming is automatically stopped)

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }
}
