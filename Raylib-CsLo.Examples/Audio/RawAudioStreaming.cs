// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Audio;

/*******************************************************************************************
*
*   raylib [audio] example - Raw audio streaming
*
*   This example has been created using raylib 1.6 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example created by Ramon Santamaria (@raysan5) and reviewed by James Hofmann (@triplefox)
*
*   Copyright (c) 2015-2019 Ramon Santamaria (@raysan5) and James Hofmann (@triplefox)
*
********************************************************************************************/

public static unsafe class RawAudioStreaming
{

    // #include <stdlib.h>         // Required for: malloc(), free()
    // # include <math.h>           // Required for: MathF.Sin()
    // # include <string.h>         // Required for: memcpy()

    const int MAX_SAMPLES = 512;
    const int MAX_SAMPLES_PER_UPDATE = 4096;

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [audio] example - raw audio streaming");

        InitAudioDevice();              // Initialize audio device

        SetAudioStreamBufferSizeDefault(MAX_SAMPLES_PER_UPDATE);

        // Init raw audio stream (sample rate: 22050, sample size: 16bit-short, channels: 1-mono)
        AudioStream stream = LoadAudioStream(44100, 16, 1);

        // Buffer for the single cycle waveform we are synthesizing
        //short* data = (short*)malloc(short.Length * MAX_SAMPLES);
        Span<short> data = new short[MAX_SAMPLES];

        // Frame buffer, describing the waveform when repeated over the course of a frame
        //short* writeBuf = (short*)malloc(short.Length * MAX_SAMPLES_PER_UPDATE);
        Span<short> writeBuf = new short[MAX_SAMPLES_PER_UPDATE];

        PlayAudioStream(stream);        // Start processing stream buffer (no data loaded currently)

        // Cycles per second (hz)
        float frequency = 440.0f;

        // Previous value, used to test if sine needs to be rewritten, and to smoothly modulate frequency
        float oldFrequency = 1.0f;

        // Cursor to read and copy the samples of the sine wave buffer
        int readCursor = 0;

        // Computed size in samples of the sine wave
        int waveLength = 1;

        Vector2 position = new(0, 0);

        SetTargetFPS(30);               // Set our game to run at 30 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update


            // Sample mouse input.
            Vector2 mousePosition = GetMousePosition();

            if (IsMouseButtonDown(MouseButtonLeft))
            {
                float fp = mousePosition.Y;
                frequency = 40.0f + (float)fp;
            }

            // Rewrite the sine wave.
            // Compute two cycles to allow the buffer padding, simplifying any modulation, resampling, etc.
            if (frequency != oldFrequency)
            {
                // Compute wavelength. Limit size in both directions.
                int oldWavelength = waveLength;
                waveLength = (int)(22050 / frequency);
                if (waveLength > MAX_SAMPLES / 2)
                {
                    waveLength = MAX_SAMPLES / 2;
                }

                if (waveLength < 1)
                {
                    waveLength = 1;
                }

                // Write sine wave.
                for (int i = 0; i < waveLength * 2; i++)
                {
                    data[i] = (short)(MathF.Sin(2 * MathF.PI * i / waveLength) * 32000);
                }

                // Scale read cursor's position to minimize transition artifacts
                readCursor = (int)(readCursor * (waveLength / (float)oldWavelength));
                oldFrequency = frequency;
            }

            // Refill audio stream if required
            if (IsAudioStreamProcessed(stream))
            {
                // Synthesize a buffer that is exactly the requested size
                int writeCursor = 0;

                while (writeCursor < MAX_SAMPLES_PER_UPDATE)
                {
                    // Start by trying to write the whole chunk at once
                    int writeLength = MAX_SAMPLES_PER_UPDATE - writeCursor;

                    // Limit to the maximum readable size
                    int readLength = waveLength - readCursor;

                    if (writeLength > readLength)
                    {
                        writeLength = readLength;
                    }

                    // Write the slice
                    //memcpy(writeBuf + writeCursor, data + readCursor, writeLength * short.Length);
                    data.Slice(readCursor, writeLength).CopyTo(writeBuf.Slice(writeCursor, writeLength));

                    // Update cursors and loop audio
                    readCursor = (readCursor + writeLength) % waveLength;

                    writeCursor += writeLength;
                }

                // Copy finished frame to audio stream
                UpdateAudioStream(stream, writeBuf, MAX_SAMPLES_PER_UPDATE);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText(string.Format("sine frequency: {0}", (int)frequency), GetScreenWidth() - 220, 10, 20, Red);
            DrawText("click mouse button to change frequency", 10, 10, 20, Darkgray);

            // Draw the current buffer state proportionate to the screen
            for (int i = 0; i < screenWidth; i++)
            {
                position.X = i;
                position.Y = 250 + (50 * data[i * MAX_SAMPLES / screenWidth] / 32000.0f);

                DrawPixelV(position, Red);
            }

            EndDrawing();

        }

        // De-Initialization

        //free(data);                 // Unload sine wave data
        //free(writeBuf);             // Unload write buffer

        UnloadAudioStream(stream);   // Close raw audio stream and delete buffers from RAM
        CloseAudioDevice();         // Close audio device (music streaming is automatically stopped)

        CloseWindow();              // Close window and OpenGL context


    }


}
