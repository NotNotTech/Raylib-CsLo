// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Image processing
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class ImageProcessing
{

    // #include <stdlib.h>             // Required for: free()

    const int NUM_PROCESSES = 8;

    enum ImageProcess
    {
        NONE = 0,
        COLOR_GRAYSCALE,
        COLOR_TINT,
        COLOR_INVERT,
        COLOR_CONTRAST,
        COLOR_BRIGHTNESS,
        FLIP_VERTICAL,
        FLIP_HORIZONTAL
    }

    static string[] processText = new string[]
    {
        "NO PROCESSING",
        "COLOR GRAYSCALE",
        "COLOR TINT",
        "COLOR INVERT",
        "COLOR CONTRAST",
        "COLOR BRIGHTNESS",
        "FLIP VERTICAL",
        "FLIP HORIZONTAL"
    };

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - image processing");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Image imOrigin = LoadImage("resources/parrots.png");   // Loaded in CPU memory (RAM)
        ImageFormat(ref imOrigin, PixelformatUncompressedR8g8b8a8);         // Format image to RGBA 32bit (required for texture update) <-- ISSUE
        Texture2D texture = LoadTextureFromImage(imOrigin);    // Image converted to texture, GPU memory (VRAM)

        Image imCopy = ImageCopy(imOrigin);

        int currentProcess = (int)ImageProcess.NONE;
        bool textureReload = false;

        Rectangle[] toggleRecs = new Rectangle[NUM_PROCESSES];
        int mouseHoverRec = -1;

        for (int i = 0; i < NUM_PROCESSES; i++)
        {
            toggleRecs[i] = new Rectangle(40.0f, 50 + (32 * i), 150.0f, 30.0f);
        }

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update


            // Mouse toggle group logic
            for (int i = 0; i < NUM_PROCESSES; i++)
            {
                if (CheckCollisionPointRec(GetMousePosition(), toggleRecs[i]))
                {
                    mouseHoverRec = i;

                    if (IsMouseButtonReleased(MouseButtonLeft))
                    {
                        currentProcess = i;
                        textureReload = true;
                    }
                    break;
                }
                else
                {
                    mouseHoverRec = -1;
                }
            }

            // Keyboard toggle group logic
            if (IsKeyPressed(KeyDown))
            {
                currentProcess++;
                if (currentProcess > (NUM_PROCESSES - 1))
                {
                    currentProcess = 0;
                }

                textureReload = true;
            }
            else if (IsKeyPressed(KeyUp))
            {
                currentProcess--;
                if (currentProcess < 0)
                {
                    currentProcess = 7;
                }

                textureReload = true;
            }

            // Reload texture when required
            if (textureReload)
            {
                UnloadImage(imCopy);                // Unload image-copy data
                imCopy = ImageCopy(imOrigin);     // Restore image-copy from image-origin

                // NOTE: Image processing is a costly CPU process to be done every frame,
                // If image processing is required in a frame-basis, it should be done
                // with a texture and by shaders
                switch ((ImageProcess)currentProcess)
                {
                    case ImageProcess.COLOR_GRAYSCALE:
                        ImageColorGrayscale(ref imCopy);
                        break;
                    case ImageProcess.COLOR_TINT:
                        ImageColorTint(ref imCopy, Green);
                        break;
                    case ImageProcess.COLOR_INVERT:
                        ImageColorInvert(ref imCopy);
                        break;
                    case ImageProcess.COLOR_CONTRAST:
                        ImageColorContrast(ref imCopy, -40);
                        break;
                    case ImageProcess.COLOR_BRIGHTNESS:
                        ImageColorBrightness(ref imCopy, -80);
                        break;
                    case ImageProcess.FLIP_VERTICAL:
                        ImageFlipVertical(ref imCopy);
                        break;
                    case ImageProcess.FLIP_HORIZONTAL:
                        ImageFlipHorizontal(ref imCopy);
                        break;
                    case ImageProcess.NONE:
                        break;
                    default:
                        break;
                }

                Color[] pixels = LoadImageColors(imCopy);    // Load pixel data from image (RGBA 32bit)
                UpdateTexture(texture, pixels);             // Update texture with new image data
                // UnloadImageColors(pixels);                  // Unload pixels data from RAM

                textureReload = false;
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("IMAGE PROCESSING:", 40, 30, 10, Darkgray);

            // Draw rectangles
            for (int i = 0; i < NUM_PROCESSES; i++)
            {
                DrawRectangleRec(toggleRecs[i], ((i == currentProcess) || (i == mouseHoverRec)) ? Skyblue : Lightgray);
                DrawRectangleLines((int)toggleRecs[i].X, (int)toggleRecs[i].Y, (int)toggleRecs[i].Width, (int)toggleRecs[i].Height, ((i == currentProcess) || (i == mouseHoverRec)) ? Blue : Gray);
                DrawText(processText[i], (int)(toggleRecs[i].X + (toggleRecs[i].Width / 2) - (MeasureText(processText[i], 10) / 2)), (int)toggleRecs[i].Y + 11, 10, ((i == currentProcess) || (i == mouseHoverRec)) ? Darkblue : Darkgray);
            }

            DrawTexture(texture, screenWidth - texture.width - 60, (screenHeight / 2) - (texture.height / 2), White);
            DrawRectangleLines(screenWidth - texture.width - 60, (screenHeight / 2) - (texture.height / 2), texture.width, texture.height, Black);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture);       // Unload texture from VRAM
        UnloadImage(imOrigin);        // Unload image-origin from RAM
        UnloadImage(imCopy);          // Unload image-copy from RAM

        CloseWindow();                // Close window and OpenGL context


        return 0;
    }

}
