// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - window scale letterbox (and virtual mouse)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public static class WindowLetterbox
{

    public static void Example()
    {
        const int windowWidth = 800;
        const int windowHeight = 450;

        // Enable config flags for resizable window and vertical synchro
        SetConfigFlags(FlagWindowResizable | FlagVsyncHint);
        InitWindow(windowWidth, windowHeight, "raylib [core] example - window scale letterbox");
        SetWindowMinSize(320, 240);

        int gameScreenWidth = 640;
        int gameScreenHeight = 480;

        // Render texture initialization, used to hold the rendering result so we can easily resize it
        RenderTexture target = LoadRenderTexture(gameScreenWidth, gameScreenHeight);
        SetTextureFilter(target.texture, TextureFilterBilinear);  // Texture scale filter to use

        Color[] colors = new Color[10];
        for (int i = 0; i < 10; i++)
        {
            colors[i] = new(GetRandomValue(100, 250), GetRandomValue(50, 150), GetRandomValue(10, 100), 255);
        }

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            // Compute required framebuffer scaling
            float scale = MathF.Min((float)GetScreenWidth() / gameScreenWidth, (float)GetScreenHeight() / gameScreenHeight);

            if (IsKeyPressed(KeySpace))
            {
                // Recalculate random colors for the bars
                for (int i = 0; i < 10; i++)
                {
                    colors[i] = new(GetRandomValue(100, 250), GetRandomValue(50, 150), GetRandomValue(10, 100), 255);
                }
            }

            // Update virtual mouse (clamped mouse value behind game screen)
            Vector2 mouse = GetMousePosition();
            Vector2 virtualMouse;// = { 0 };
            virtualMouse.X = (mouse.X - ((GetScreenWidth() - (gameScreenWidth * scale)) * 0.5f)) / scale;
            virtualMouse.Y = (mouse.Y - ((GetScreenHeight() - (gameScreenHeight * scale)) * 0.5f)) / scale;
            virtualMouse = Vector2.Clamp(virtualMouse, Vector2.Zero, new(gameScreenWidth, gameScreenHeight));

            // Apply the same transformation as the virtual mouse to the real mouse (i.e. to work with raygui)
            //SetMouseOffset(-(GetScreenWidth() - (gameScreenWidth*scale))*0.5f, -(GetScreenHeight() - (gameScreenHeight*scale))*0.5f);
            //SetMouseScale(1/scale, 1/scale);


            // Draw

            // Draw everything in the render texture, note this will not be rendered on screen, yet
            BeginTextureMode(target);
            ClearBackground(Raywhite);  // Clear render texture background color

            for (int i = 0; i < 10; i++)
            {
                DrawRectangle(0, gameScreenHeight / 10 * i, gameScreenWidth, gameScreenHeight / 10, colors[i]);
            }

            DrawText("If executed inside a window,\nyou can resize the window,\nand see the screen scaling!", 10, 25, 20, White);
            DrawText(string.Format("Default Mouse: [{0} , {1}]", (int)mouse.X, (int)mouse.Y), 350, 25, 20, Green);
            DrawText(string.Format("Virtual Mouse: [{0} , {1}]", (int)virtualMouse.X, (int)virtualMouse.Y), 350, 55, 20, Yellow);
            EndTextureMode();

            BeginDrawing();
            ClearBackground(Black);     // Clear screen background

            // Draw render texture to screen, properly scaled
            DrawTexturePro(target.texture, new(0.0f, 0.0f, target.texture.width, -target.texture.height),
                          new(
                (GetScreenWidth() - (gameScreenWidth * scale)) * 0.5f, (GetScreenHeight() - (gameScreenHeight * scale)) * 0.5f,
                           gameScreenWidth * scale, gameScreenHeight * scale), new(0, 0), 0.0f, White);
            EndDrawing();

        }

        // De-Initialization

        UnloadRenderTexture(target);        // Unload render texture

        CloseWindow();                      // Close window and OpenGL context


    }


}
