// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Mouse painting
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Dill (@MysteriousSpace) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Dill (@MysteriousSpace) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class MousePainting
{

    const int MAX_COLORS_COUNT = 23;          // Number of colors available

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - mouse painting");

        // Colours to choose from
        Color[] colors = new Color[MAX_COLORS_COUNT] {
        Raywhite, Yellow, Gold, Orange, Pink, Red, Maroon, Green, Lime, Darkgreen,
        Skyblue, Blue, Darkblue, Purple, Violet, Darkpurple, Beige, Brown, Darkbrown,
        Lightgray, Gray, Darkgray, Black };

        // Define colorsRecs data (for every rectangle)
        Rectangle[] colorsRecs = new Rectangle[MAX_COLORS_COUNT];

        for (int i = 0; i < MAX_COLORS_COUNT; i++)
        {
            colorsRecs[i].X = 10 + (30.0f * i) + (2 * i);
            colorsRecs[i].Y = 10;
            colorsRecs[i].Width = 30;
            colorsRecs[i].Height = 30;
        }

        int colorSelected = 0;
        int colorSelectedPrev = colorSelected;
        int colorMouseHover = 0;
        float brushSize = 20.0f;
        bool mouseWasPressed = false;

        Rectangle btnSaveRec = new(750, 10, 40, 30);
        bool showSaveMessage = false;
        int saveMessageCounter = 0;

        // Create a RenderTexture2D to use as a canvas
        RenderTexture target = LoadRenderTexture(screenWidth, screenHeight);

        // Clear render texture before entering the game loop
        BeginTextureMode(target);
        ClearBackground(colors[0]);
        EndTextureMode();

        SetTargetFPS(120);              // Set our game to run at 120 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            Vector2 mousePos = GetMousePosition();

            // Move between colors with keys
            if (IsKeyPressed(KeyRight))
            {
                colorSelected++;
            }
            else if (IsKeyPressed(KeyLeft))
            {
                colorSelected--;
            }

            if (colorSelected >= MAX_COLORS_COUNT)
            {
                colorSelected = MAX_COLORS_COUNT - 1;
            }
            else if (colorSelected < 0)
            {
                colorSelected = 0;
            }

            // Choose color with mouse
            for (int i = 0; i < MAX_COLORS_COUNT; i++)
            {
                if (CheckCollisionPointRec(mousePos, colorsRecs[i]))
                {
                    colorMouseHover = i;
                    break;
                }
                else
                {
                    colorMouseHover = -1;
                }
            }

            if ((colorMouseHover >= 0) && IsMouseButtonPressed(MouseButtonLeft))
            {
                colorSelected = colorMouseHover;
                colorSelectedPrev = colorSelected;
            }

            // Change brush size
            brushSize += GetMouseWheelMove() * 5;
            if (brushSize < 2)
            {
                brushSize = 2;
            }

            if (brushSize > 50)
            {
                brushSize = 50;
            }

            if (IsKeyPressed(KeyC))
            {
                // Clear render texture to clear color
                BeginTextureMode(target);
                ClearBackground(colors[0]);
                EndTextureMode();
            }

            if (IsMouseButtonDown(MouseButtonLeft) || (GetGestureDetected() == GestureDrag))
            {
                // Paint circle into render texture
                // NOTE: To avoid discontinuous circles, we could store
                // previous-next mouse points and just draw a line using brush size
                BeginTextureMode(target);
                if (mousePos.Y > 50)
                {
                    DrawCircle((int)mousePos.X, (int)mousePos.Y, brushSize, colors[colorSelected]);
                }

                EndTextureMode();
            }

            if (IsMouseButtonDown(MouseButtonRight))
            {
                if (!mouseWasPressed)
                {
                    colorSelectedPrev = colorSelected;
                    colorSelected = 0;
                }

                mouseWasPressed = true;

                // Erase circle from render texture
                BeginTextureMode(target);
                if (mousePos.Y > 50)
                {
                    DrawCircle((int)mousePos.X, (int)mousePos.Y, brushSize, colors[0]);
                }

                EndTextureMode();
            }
            else if (IsMouseButtonReleased(MouseButtonRight) && mouseWasPressed)
            {
                colorSelected = colorSelectedPrev;
                mouseWasPressed = false;
            }

            bool btnSaveMouseHover;
            // Check mouse hover save button
            if (CheckCollisionPointRec(mousePos, btnSaveRec))
            {
                btnSaveMouseHover = true;
            }
            else
            {
                btnSaveMouseHover = false;
            }

            // Image saving logic
            // NOTE: Saving painted texture to a default named image
            if ((btnSaveMouseHover && IsMouseButtonReleased(MouseButtonLeft)) || IsKeyPressed(KeyS))
            {
                Image image = LoadImageFromTexture(target.texture);
                ImageFlipVertical(ref image);
                ExportImage(image, "my_amazing_texture_painting.png");
                UnloadImage(image);
                showSaveMessage = true;
            }

            if (showSaveMessage)
            {
                // On saving, show a full screen message for 2 seconds
                saveMessageCounter++;
                if (saveMessageCounter > 240)
                {
                    showSaveMessage = false;
                    saveMessageCounter = 0;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
            DrawTextureRec(target.texture, new Rectangle(0, 0, target.texture.width, -target.texture.height), new Vector2(0, 0), White);

            // Draw drawing circle for reference
            if (mousePos.Y > 50)
            {
                if (IsMouseButtonDown(MouseButtonRight))
                {
                    DrawCircleLines((int)mousePos.X, (int)mousePos.Y, brushSize, Gray);
                }
                else
                {
                    DrawCircle(GetMouseX(), GetMouseY(), brushSize, colors[colorSelected]);
                }
            }

            // Draw top panel
            DrawRectangle(0, 0, GetScreenWidth(), 50, Raywhite);
            DrawLine(0, 50, GetScreenWidth(), 50, Lightgray);

            // Draw color selection rectangles
            for (int i = 0; i < MAX_COLORS_COUNT; i++)
            {
                DrawRectangleRec(colorsRecs[i], colors[i]);
            }

            DrawRectangleLines(10, 10, 30, 30, Lightgray);

            if (colorMouseHover >= 0)
            {
                DrawRectangleRec(colorsRecs[colorMouseHover], Fade(White, 0.6f));
            }

            DrawRectangleLinesEx(new Rectangle(colorsRecs[colorSelected].X - 2, colorsRecs[colorSelected].Y - 2,
                                 colorsRecs[colorSelected].Width + 4, colorsRecs[colorSelected].Height + 4), 2, Black);

            // Draw save image button
            DrawRectangleLinesEx(btnSaveRec, 2, btnSaveMouseHover ? Red : Black);
            DrawText("SAVE!", 755, 20, 10, btnSaveMouseHover ? Red : Black);

            // Draw save image message
            if (showSaveMessage)
            {
                DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), Fade(Raywhite, 0.8f));
                DrawRectangle(0, 150, GetScreenWidth(), 80, Black);
                DrawText("IMAGE SAVED:  my_amazing_texture_painting.png", 150, 180, 20, Raywhite);
            }

            EndDrawing();

        }

        // De-Initialization

        UnloadRenderTexture(target);    // Unload render texture

        CloseWindow();                  // Close window and OpenGL context



    }
}
