// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Texture source and destination rectangles
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static unsafe class TextureSourceAndDestinationRectangles
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] examples - texture source and destination rectangles");

        // NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

        Texture2D scarfy = LoadTexture("resources/scarfy.png");        // Texture loading

        int frameWidth = scarfy.width / 6;
        int frameHeight = scarfy.height;

        // Source rectangle (part of the texture to use for drawing)
        Rectangle sourceRec = new(0.0f, 0.0f, frameWidth, frameHeight);

        // Destination rectangle (screen rectangle where drawing part of texture)
        Rectangle destRec = new(screenWidth / 2.0f, screenHeight / 2.0f, frameWidth * 2.0f, frameHeight * 2.0f);

        // Origin of the texture (rotation/scale point), it's relative to destination rectangle size
        Vector2 origin = new(frameWidth, frameHeight);

        int rotation = 0;

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            rotation++;


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            // NOTE: Using DrawTexturePro() we can easily rotate and scale the part of the texture we draw
            // sourceRec defines the part of the texture we use for drawing
            // destRec defines the rectangle where our texture part will fit (scaling it to fit)
            // origin defines the point of the texture used as reference for rotation and scaling
            // rotation defines the texture rotation (using origin as rotation point)
            DrawTexturePro(scarfy, sourceRec, destRec, origin, rotation, White);

            DrawLine((int)destRec.X, 0, (int)destRec.X, screenHeight, Gray);
            DrawLine(0, (int)destRec.Y, screenWidth, (int)destRec.Y, Gray);

            DrawText("(c) Scarfy sprite by Eiden Marsal", screenWidth - 200, screenHeight - 20, 10, Gray);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(scarfy);        // Texture unloading

        CloseWindow();                // Close window and OpenGL context



    }
}
