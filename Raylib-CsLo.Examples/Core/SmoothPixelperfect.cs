// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - smooth pixel-perfect camera
*
*   This example has been created using raylib 3.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Giancamillo Alessandroni (@NotManyIdeasDev) and
*   reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Giancamillo Alessandroni (@NotManyIdeasDev) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class SmoothPixelperfect
{

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        const int virtualScreenWidth = 160;
        const int virtualScreenHeight = 90;

        const float virtualRatio = screenWidth / (float)virtualScreenWidth;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - smooth pixel-perfect camera");

        Camera2D worldSpaceCamera = new();  // Game world camera
        worldSpaceCamera.zoom = 1.0f;

        Camera2D screenSpaceCamera = new(); // Smoothing camera
        screenSpaceCamera.zoom = 1.0f;

        RenderTexture target = LoadRenderTexture(virtualScreenWidth, virtualScreenHeight); // This is where we'll draw all our objects.

        Rectangle rec01 = new(70.0f, 35.0f, 20.0f, 20.0f);
        Rectangle rec02 = new(90.0f, 55.0f, 30.0f, 10.0f);
        Rectangle rec03 = new(80.0f, 65.0f, 15.0f, 25.0f);

        // The target's height is flipped (in the source Rectangle), due to OpenGL reasons
        Rectangle sourceRec = new(0.0f, 0.0f, target.texture.width, -target.texture.height);
        Rectangle destRec = new(-virtualRatio, -virtualRatio, screenWidth + (virtualRatio * 2), screenHeight + (virtualRatio * 2));

        Vector2 origin = new(0.0f, 0.0f);

        float rotation = 0.0f;

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            rotation += 60.0f * GetFrameTime();   // Rotate the rectangles, 60 degrees per second

            // Make the camera move to demonstrate the effect
            float cameraX = (MathF.Sin((float)GetTime()) * 50.0f) - 10.0f;
            float cameraY = MathF.Cos((float)GetTime()) * 30.0f;

            // Set the camera's target to the values computed above
            screenSpaceCamera.target = new(cameraX, cameraY);

            // Round worldSpace coordinates, keep decimals into screenSpace coordinates
            worldSpaceCamera.target.X = (int)screenSpaceCamera.target.X;
            screenSpaceCamera.target.X -= worldSpaceCamera.target.X;
            screenSpaceCamera.target.X *= virtualRatio;

            worldSpaceCamera.target.Y = (int)screenSpaceCamera.target.Y;
            screenSpaceCamera.target.Y -= worldSpaceCamera.target.Y;
            screenSpaceCamera.target.Y *= virtualRatio;


            // Draw

            BeginTextureMode(target);
            ClearBackground(Raywhite);

            BeginMode2D(worldSpaceCamera);
            DrawRectanglePro(rec01, origin, rotation, Black);
            DrawRectanglePro(rec02, origin, -rotation, Red);
            DrawRectanglePro(rec03, origin, rotation + 45.0f, Blue);
            EndMode2D();
            EndTextureMode();

            BeginDrawing();
            ClearBackground(Red);

            BeginMode2D(screenSpaceCamera);
            DrawTexturePro(target.texture, sourceRec, destRec, origin, 0.0f, White);
            EndMode2D();

            DrawText(string.Format("Screen resolution: {0}x{1}", screenWidth, screenHeight), 10, 10, 20, Darkblue);
            DrawText(string.Format("World resolution: {0}x{1}", virtualScreenWidth, virtualScreenHeight), 10, 40, 20, Darkgreen);
            DrawFPS(GetScreenWidth() - 95, 10);
            EndDrawing();

        }

        // De-Initialization

        UnloadRenderTexture(target);    // Unload render texture

        CloseWindow();                  // Close window and OpenGL context


    }
}
