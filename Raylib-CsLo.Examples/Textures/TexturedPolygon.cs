// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [shapes] example - Draw Textured Polygon
*
*   This example has been created using raylib 3.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies - bedroomcoders.co.uk) and
*   reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class TexturedPolygon
{
    //# include "raymath.h"

    const int MAX_POINTS = 11;      // 10 points and back to the start

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - textured polygon");

        // Define texture coordinates to map our texture to poly
        Vector2[] texcoords = new Vector2[MAX_POINTS] {
        new Vector2( 0.75f, 0.0f ),
        new Vector2( 0.25f, 0.0f ),
        new Vector2( 0.0f, 0.5f ),
        new Vector2( 0.0f, 0.75f ),
        new Vector2( 0.25f, 1.0f),
        new Vector2( 0.375f, 0.875f),
        new Vector2( 0.625f, 0.875f),
        new Vector2( 0.75f, 1.0f),
        new Vector2( 1.0f, 0.75f),
        new Vector2( 1.0f, 0.5f),
        new Vector2( 0.75f, 0.0f)  // Close the poly
	};

        // Define the base poly vertices from the UV's
        // NOTE: They can be specified in any other way
        Vector2[] points = new Vector2[MAX_POINTS];
        for (int i = 0; i < MAX_POINTS; i++)
        {
            points[i].X = (texcoords[i].X - 0.5f) * 256.0f;
            points[i].Y = (texcoords[i].Y - 0.5f) * 256.0f;
        }

        // Define the vertices drawing position
        // NOTE: Initially same as points but updated every frame
        Vector2[] positions = new Vector2[MAX_POINTS];
        for (int i = 0; i < MAX_POINTS; i++)
        {
            positions[i] = points[i];
        }

        // Load texture to be mapped to poly
        Texture2D texture = LoadTexture("resources/cat.png");

        float angle = 0.0f;             // Rotation angle (in degrees)

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            // Update points rotation with an angle transform
            // NOTE: Base points position are not modified
            angle++;
            for (int i = 0; i < MAX_POINTS; i++)
            {
                positions[i] = Vector2Rotate(points[i], angle * MathF.PI / 180);
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            DrawText("textured polygon", 20, 20, 20, Darkgray);

            DrawTexturePoly(texture, new Vector2(GetScreenWidth() / 2, GetScreenHeight() / 2), positions, texcoords, MAX_POINTS, White);

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture); // Unload texture

        CloseWindow();          // Close window and OpenGL context



    }


}
