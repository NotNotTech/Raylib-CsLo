// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Text;

/*******************************************************************************************
*
*   raylib [text] example - Draw 2D text in 3D
*
*   Draw a 2D text in 3D space, each letter is drawn in a quad (or 2 quads if backface is set)
*   where the texture coodinates of each quad map to the texture coordinates of the glyphs
*   inside the font texture.
*    A more efficient approach, i believe, would be to render the text in a render texture and
*    map that texture to a plane and render that, or maybe a shader but my method allows more
*    flexibility...for example to change position of each letter individually to make somethink
*    like a wavy text effect.
*
*    Special thanks to:
*        @Nighten for the DrawTextStyle() code https://github.com/NightenDushi/Raylib_DrawTextStyle
*        Chris Camacho (codifies - http://bedroomcoders.co.uk/) for the alpha discard shader
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@Demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (C) 2021 Vlad Adrian (@Demizdor - https://github.com/Demizdor)
*
********************************************************************************************/

public static unsafe class Draw2dIn3d
{
    // # include "rlgl.h"

    // # include <stddef.h>     // Required for: null
    // # include <math.h>       // Required for: MathF.Sin()

    // To make it work with the older RLGL module just comment the line below
    //#define RAYLIB_NEW_RLGL


    // Globals

    const float LETTER_BOUNDRY_SIZE = 0.25f;
    const int TEXT_MAX_LAYERS = 32;
    static readonly Color LETTER_BOUNDRY_COLOR = VIOLET;

    static bool showLetterBoundary;
    static bool showTextBoundary;


    // Data Types definition


    // Configuration structure for waving the text
    struct WaveTextConfig
    {

        public Vector3 waveRange;
        public Vector3 waveSpeed;
        public Vector3 waveOffset;
    }


    // Program main entry point

    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_VSYNC_HINT);
        InitWindow(screenWidth, screenHeight, "raylib [text] example - draw 2D text in 3D");

        bool spin = true;        // Spin the camera?
        bool multicolor = false; // Multicolor mode

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
        camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                    // Camera field-of-view Y
        camera.Projection = CAMERA_PERSPECTIVE;                 // Camera mode type

        SetCameraMode(ref camera, CAMERA_ORBITAL);

        Vector3 cubePosition = new(0.0f, 1.0f, 0.0f);
        Vector3 cubeSize = new(2.0f, 2.0f, 2.0f);

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second

        // Use the default font
        Font font = GetFontDefault();
        float fontSize = 8.0f;
        float fontSpacing = 0.5f;
        float lineSpacing = -1.0f;

        // Set the text (using markdown!)
        string text = "Hello ~~World~~ in 3D!";
        int layers = 1;
        float layerDistance = 0.01f;

        WaveTextConfig wcfg = new();
        wcfg.waveSpeed.X = wcfg.waveSpeed.Y = 3.0f;
        wcfg.waveSpeed.Z = 0.5f;
        wcfg.waveOffset.X = wcfg.waveOffset.Y = wcfg.waveOffset.Z = 0.35f;
        wcfg.waveRange.X = wcfg.waveRange.Y = wcfg.waveRange.Z = 0.45f;

        float time = 0.0f;

        // Setup a light and dark color
        Color light = MAROON;
        Color dark = RED;

        // Load the alpha discard shader
        Shader alphaDiscard = LoadShader(null, "resources/shaders/glsl330/alpha_discard.fs");

        // Array filled with multiple random colors (when multicolor mode is set)
        Color[] multi = new Color[TEXT_MAX_LAYERS];


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            // Handle font files dropped
            if (IsFileDropped())
            {
                //int count = 0;
                //char** droppedFiles = GetDroppedFiles(&count);
                string[]? droppedFiles = GetDroppedFiles();

                // NOTE: We only support first ttf file dropped
                if (IsFileExtension(droppedFiles[0], ".ttf"))
                {
                    UnloadFont(font);
                    font = LoadFontEx(droppedFiles[0], (int)fontSize, (int*)0, 0);
                }
                else if (IsFileExtension(droppedFiles[0], ".fnt"))
                {
                    UnloadFont(font);
                    font = LoadFont(droppedFiles[0]);
                    fontSize = font.baseSize;
                }
                ClearDroppedFiles();
            }

            // Handle Events
            if (IsKeyPressed(KEY_F1))
            {
                showLetterBoundary = !showLetterBoundary;
            }

            if (IsKeyPressed(KEY_F2))
            {
                showTextBoundary = !showTextBoundary;
            }

            if (IsKeyPressed(KEY_F3))
            {
                // Handle camera change
                spin = !spin;
                // we need to reset the camera when changing modes
                camera = new Camera3D();
                camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
                camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
                camera.fovy = 45.0f;                                    // Camera field-of-view Y
                camera.Projection = CAMERA_PERSPECTIVE;                 // Camera mode type

                if (spin)
                {
                    camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
                    SetCameraMode(ref camera, CAMERA_ORBITAL);
                }
                else
                {
                    camera.position = new Vector3(10.0f, 10.0f, -10.0f);   // Camera position
                    SetCameraMode(ref camera, CAMERA_FREE);
                }
            }

            // Handle clicking the cube
            if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
            {
                Ray ray = GetMouseRay(GetMousePosition(), ref camera);

                // Check collision between ray and box
                RayCollision collision = GetRayCollisionBox(ray,
                                new BoundingBox(new Vector3(cubePosition.X - (cubeSize.X / 2), cubePosition.Y - (cubeSize.Y / 2), cubePosition.Z - (cubeSize.Z / 2)),
                                              new Vector3(cubePosition.X + (cubeSize.X / 2), cubePosition.Y + (cubeSize.Y / 2), cubePosition.Z + (cubeSize.Z / 2))));
                if (collision.hit)
                {
                    // Generate new random colors
                    light = GenerateRandomColor(0.5f, 0.78f);
                    dark = GenerateRandomColor(0.4f, 0.58f);
                }
            }

            // Handle text layers changes
            if (IsKeyPressed(KEY_HOME))
            {
                if (layers > 1)
                {
                    --layers;
                }
            }
            else if (IsKeyPressed(KEY_END))
            {
                if (layers < TEXT_MAX_LAYERS)
                {
                    ++layers;
                }
            }

            // Handle text changes
            if (IsKeyPressed(KEY_LEFT))
            {
                fontSize -= 0.5f;
            }
            else if (IsKeyPressed(KEY_RIGHT))
            {
                fontSize += 0.5f;
            }
            else if (IsKeyPressed(KEY_UP))
            {
                fontSpacing -= 0.1f;
            }
            else if (IsKeyPressed(KEY_DOWN))
            {
                fontSpacing += 0.1f;
            }
            else if (IsKeyPressed(KEY_PAGE_UP))
            {
                lineSpacing -= 0.1f;
            }
            else if (IsKeyPressed(KEY_PAGE_DOWN))
            {
                lineSpacing += 0.1f;
            }
            else if (IsKeyDown(KEY_INSERT))
            {
                layerDistance -= 0.001f;
            }
            else if (IsKeyDown(KEY_DELETE))
            {
                layerDistance += 0.001f;
            }
            else if (IsKeyPressed(KEY_TAB))
            {
                multicolor = !multicolor;   // Enable /disable multicolor mode

                if (multicolor)
                {
                    // Fill color array with random colors
                    for (int i = 0; i < TEXT_MAX_LAYERS; ++i)
                    {
                        multi[i] = GenerateRandomColor(0.5f, 0.8f);
                        multi[i].a = (byte)GetRandomValue(0, 255);
                    }
                }
            }

            // Handle text input
            int ch = GetCharPressed();
            if (IsKeyPressed(KEY_BACKSPACE))
            {
                //// Remove last char
                //int len = TextLength(text);
                //if (len > 0) text[len - 1] = '\0';
                text = text[0..^1];
            }
            else if (IsKeyPressed(KEY_ENTER))
            {
                //// handle newline
                //int len = TextLength(text);
                //if (len < sizeof(text) - 1)
                //{
                //	text[len] = '\n';
                //	text[len + 1] = '\0';
                //}
                text += "\n";
            }
            else if (ch == 0)
            {
                //do nothing
            }
            else
            {
                //// append only printable chars
                //int len = TextLength(text);
                //if (len < sizeof(text) - 1)
                //{
                //	text[len] = ch;
                //	text[len + 1] = '\0';
                //}
                text += (char)ch;
            }

            // Measure 3D text so we can center it
            Vector3 tbox = MeasureTextWave3D(font, text, fontSize, fontSpacing, lineSpacing);

            UpdateCamera(ref camera);          // Update camera
            int quads = 0;
            time += GetFrameTime();         // Update timer needed by `DrawTextWave3D()`


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            BeginMode3D(ref camera);
            DrawCubeV(cubePosition, cubeSize, dark);
            DrawCubeWires(cubePosition, 2.1f, 2.1f, 2.1f, light);

            DrawGrid(10, 2.0f);

            // Use a shader to handle the depth buffer issue with transparent textures
            // NOTE: more info at https://bedroomcoders.co.uk/raylib-billboards-advanced-use/
            BeginShaderMode(alphaDiscard);

            // Draw the 3D text above the red cube
            rlPushMatrix();
            rlRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            rlRotatef(90.0f, 0.0f, 0.0f, -1.0f);

            for (int i = 0; i < layers; ++i)
            {
                Color clr = light;
                if (multicolor)
                {
                    clr = multi[i];
                }

                DrawTextWave3D(font, text, new Vector3(-tbox.X / 2.0f, layerDistance * i, -4.5f), fontSize, fontSpacing, lineSpacing, true, &wcfg, time, clr);
            }

            // Draw the text boundry if set
            if (showTextBoundary)
            {
                DrawCubeWiresV(new Vector3(0.0f, 0.0f, -4.5f + (tbox.Z / 2)), tbox, dark);
            }

            rlPopMatrix();

            // Don't draw the letter boundries for the 3D text below
            bool slb = showLetterBoundary;
            showLetterBoundary = false;

            // Draw 3D options (use default font)

            rlPushMatrix();
            rlRotatef(180.0f, 0.0f, 1.0f, 0.0f);
            string opt = TextFormat("< SIZE: %2.1f >", fontSize);
            quads += TextLength(opt);
            Vector3 m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            Vector3 pos = new(-m.X / 2.0f, 0.01f, 2.0f);
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
            pos.Z += 0.5f + m.Z;

            opt = TextFormat("< SPACING: %2.1f >", fontSpacing);
            quads += TextLength(opt);
            m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
            pos.Z += 0.5f + m.Z;

            opt = TextFormat("< LINE: %2.1f >", lineSpacing);
            quads += TextLength(opt);
            m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
            pos.Z += 1.0f + m.Z;

            opt = TextFormat("< LBOX: %3s >", slb ? "ON" : "OFF");
            quads += TextLength(opt);
            m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
            pos.Z += 0.5f + m.Z;

            opt = TextFormat("< TBOX: %3s >", showTextBoundary ? "ON" : "OFF");
            quads += TextLength(opt);
            m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
            pos.Z += 0.5f + m.Z;

            opt = TextFormat("< LAYER DISTANCE: %.3f >", layerDistance);
            quads += TextLength(opt);
            m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, DARKPURPLE);
            rlPopMatrix();


            // Draw 3D info text (use default font)

            opt = "All the text displayed here is in 3D";
            quads += 36;
            m = MeasureText3D(GetFontDefault(), opt, 10.0f, 0.5f, 0.0f);
            pos = new Vector3(-m.X / 2.0f, 0.01f, 2.0f);
            DrawText3D(GetFontDefault(), opt, pos, 10.0f, 0.5f, 0.0f, false, DARKBLUE);
            pos.Z += 1.5f + m.Z;

            opt = "press [Left]/[Right] to change the font size";
            quads += 44;
            m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
            pos.Z += 0.5f + m.Z;

            opt = "press [Up]/[Down] to change the font spacing";
            quads += 44;
            m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
            pos.Z += 0.5f + m.Z;

            opt = "press [PgUp]/[PgDown] to change the line spacing";
            quads += 48;
            m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
            pos.Z += 0.5f + m.Z;

            opt = "press [F1] to toggle the letter boundry";
            quads += 39;
            m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
            pos.Z += 0.5f + m.Z;

            opt = "press [F2] to toggle the text boundry";
            quads += 37;
            m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
            pos.X = -m.X / 2.0f;
            DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);


            showLetterBoundary = slb;
            EndShaderMode();

            EndMode3D();

            // Draw 2D info text & stats

            DrawText("Drag & drop a font file to change the font!\nType something, see what happens!\n\n Press [F3] to toggle the camera", 10, 35, 10, BLACK);

            quads += TextLength(text) * 2 * layers;
            string tmp = TextFormat("%2i layer(s) | %s camera | %4i quads (%4i verts)", layers, spin ? "ORBITAL" : "FREE", quads, quads * 4);
            int width = MeasureText(tmp, 10);
            DrawText(tmp, screenWidth - 20 - width, 10, 10, DARKGREEN);

            tmp = "[Home]/[End] to add/remove 3D text layers";
            width = MeasureText(tmp, 10);
            DrawText(tmp, screenWidth - 20 - width, 25, 10, DARKGRAY);

            tmp = "[Insert]/[Delete] to increase/decrease distance between layers";
            width = MeasureText(tmp, 10);
            DrawText(tmp, screenWidth - 20 - width, 40, 10, DARKGRAY);

            tmp = "click the [CUBE] for a random color";
            width = MeasureText(tmp, 10);
            DrawText(tmp, screenWidth - 20 - width, 55, 10, DARKGRAY);

            tmp = "[Tab] to toggle multicolor mode";
            width = MeasureText(tmp, 10);
            DrawText(tmp, screenWidth - 20 - width, 70, 10, DARKGRAY);


            DrawFPS(10, 10);

            EndDrawing();

        }


        // De-Initialization

        UnloadFont(font);
        CloseWindow();        // Close window and OpenGL context


        return 0;
    }




    // Module Functions Definitions

    // Draw codepoint at specified position in 3D space
    static void DrawTextCodepoint3D(Font font, int codepoint, Vector3 position, float fontSize, bool backface, Color tint)
    {
        // Character index position in sprite font
        // NOTE: In case a codepoint is not available in the font, index returned points to '?'
        int index = GetGlyphIndex(font, codepoint);
        float scale = fontSize / font.baseSize;

        // Character destination rectangle on screen
        // NOTE: We consider charsPadding on drawing
        position.X += (font.glyphs[index].offsetX - font.glyphPadding) / (float)font.baseSize * scale;
        position.Z += (font.glyphs[index].offsetY - font.glyphPadding) / (float)font.baseSize * scale;

        // Character source rectangle from font texture atlas
        // NOTE: We consider chars padding when drawing, it could be required for outline/glow shader effects
        Rectangle srcRec = new(font.recs[index].X - font.glyphPadding, font.recs[index].Y - font.glyphPadding,
                             font.recs[index].width + (2.0f * font.glyphPadding), font.recs[index].height + (2.0f * font.glyphPadding));

        float width = (float)(font.recs[index].width + (2.0f * font.glyphPadding)) / font.baseSize * scale;
        float height = (float)(font.recs[index].height + (2.0f * font.glyphPadding)) / font.baseSize * scale;

        if (font.texture.id > 0)
        {
            const float x = 0.0f;
            const float y = 0.0f;
            const float z = 0.0f;

            // normalized texture coordinates of the glyph inside the font texture (0.0f -> 1.0f)
            float tx = srcRec.X / font.texture.width;
            float ty = srcRec.Y / font.texture.height;
            float tw = (srcRec.X + srcRec.width) / font.texture.width;
            float th = (srcRec.Y + srcRec.height) / font.texture.height;

            if (showLetterBoundary)
            {
                DrawCubeWiresV(new Vector3(position.X + (width / 2), position.Y, position.Z + (height / 2)), new Vector3(width, LETTER_BOUNDRY_SIZE, height), LETTER_BOUNDRY_COLOR);
            }

            rlCheckRenderBatchLimit(4 + (4 * (backface ? 1 : 0)));
            rlSetTexture(font.texture.id);

            rlPushMatrix();
            rlTranslatef(position.X, position.Y, position.Z);

            rlBegin(RL_QUADS);
            rlColor4ub(tint.r, tint.g, tint.b, tint.a);

            // Front Face
            rlNormal3f(0.0f, 1.0f, 0.0f);                                   // Normal Pointing Up
            rlTexCoord2f(tx, ty);
            rlVertex3f(x, y, z);              // Top Left Of The Texture and Quad
            rlTexCoord2f(tx, th);
            rlVertex3f(x, y, z + height);     // Bottom Left Of The Texture and Quad
            rlTexCoord2f(tw, th);
            rlVertex3f(x + width, y, z + height);     // Bottom Right Of The Texture and Quad
            rlTexCoord2f(tw, ty);
            rlVertex3f(x + width, y, z);              // Top Right Of The Texture and Quad

            if (backface)
            {
                // Back Face
                rlNormal3f(0.0f, -1.0f, 0.0f);                              // Normal Pointing Down
                rlTexCoord2f(tx, ty);
                rlVertex3f(x, y, z);          // Top Right Of The Texture and Quad
                rlTexCoord2f(tw, ty);
                rlVertex3f(x + width, y, z);          // Top Left Of The Texture and Quad
                rlTexCoord2f(tw, th);
                rlVertex3f(x + width, y, z + height); // Bottom Left Of The Texture and Quad
                rlTexCoord2f(tx, th);
                rlVertex3f(x, y, z + height); // Bottom Right Of The Texture and Quad
            }
            rlEnd();
            rlPopMatrix();

            rlSetTexture(0);
        }
    }

    static void DrawText3D(Font font, string text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, Color tint)
    {
        int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

        float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
        float textOffsetX = 0.0f;               // Offset X to next character to draw

        float scale = fontSize / font.baseSize;

        for (int i = 0; i < length;)
        {
            // Get next codepoint from byte string and glyph index in font
            int codepoint = GetCodepoint(text[i], out int codepointByteCount);

            int index = GetGlyphIndex(font, codepoint);

            // NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
            // but we need to draw all of the bad bytes using the '?' symbol moving one byte
            if (codepoint == 0x3f)
            {
                codepointByteCount = 1;
            }

            if (codepoint == '\n')
            {
                // NOTE: Fixed line spacing of 1.5 line-height
                // TODO: Support custom line spacing defined by user
                textOffsetY += scale + (lineSpacing / font.baseSize * scale);
                textOffsetX = 0.0f;
            }
            else
            {
                if ((codepoint != ' ') && (codepoint != '\t'))
                {
                    DrawTextCodepoint3D(font, codepoint, new Vector3(position.X + textOffsetX, position.Y, position.Z + textOffsetY), fontSize, backface, tint);
                }

                if (font.glyphs[index].advanceX == 0)
                {
                    textOffsetX += (float)(font.recs[index].width + fontSpacing) / font.baseSize * scale;
                }
                else
                {
                    textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / font.baseSize * scale;
                }
            }

            i += codepointByteCount;   // Move text bytes counter to next codepoint
        }
    }



    static Vector3 MeasureText3D(Font font, string text, float fontSize, float fontSpacing, float lineSpacing)
    {
        int len = TextLength(text);
        int tempLen = 0;                // Used to count longer text line num chars
        int lenCounter = 0;

        float tempTextWidth = 0.0f;     // Used to count longer text line width

        float scale = fontSize / font.baseSize;
        float textHeight = scale;
        float textWidth = 0.0f;

        int letter = 0;                 // Current character
        int index = 0;                  // Index position in sprite font

        for (int i = 0; i < len; i++)
        {
            lenCounter++;

            letter = GetCodepoint(text[i], out int next);
            index = GetGlyphIndex(font, letter);

            // NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
            // but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
            if (letter == 0x3f)
            {
                next = 1;
            }

            i += next - 1;

            if (letter != '\n')
            {
                if (font.glyphs[index].advanceX != 0)
                {
                    textWidth += (font.glyphs[index].advanceX + fontSpacing) / font.baseSize * scale;
                }
                else
                {
                    textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / font.baseSize * scale;
                }
            }
            else
            {
                if (tempTextWidth < textWidth)
                {
                    tempTextWidth = textWidth;
                }

                lenCounter = 0;
                textWidth = 0.0f;
                textHeight += scale + (lineSpacing / font.baseSize * scale);
            }

            if (tempLen < lenCounter)
            {
                tempLen = lenCounter;
            }
        }

        if (tempTextWidth < textWidth)
        {
            tempTextWidth = textWidth;
        }

        Vector3 vec = new(0);
        vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / font.baseSize * scale); // Adds chars spacing to measure
        vec.Y = 0.25f;
        vec.Z = textHeight;

        return vec;
    }


    static void DrawTextWave3D(Font font, string text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, WaveTextConfig* config, float time, Color tint)
    {
        int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

        float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
        float textOffsetX = 0.0f;               // Offset X to next character to draw

        float scale = fontSize / font.baseSize;

        bool wave = false;

        for (int i = 0, k = 0; i < length; ++k)
        {
            // Get next codepoint from byte string and glyph index in font
            int codepoint = GetCodepoint(text[i], out int codepointByteCount);
            int index = GetGlyphIndex(font, codepoint);

            // NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
            // but we need to draw all of the bad bytes using the '?' symbol moving one byte
            if (codepoint == 0x3f)
            {
                codepointByteCount = 1;
            }

            if (codepoint == '\n')
            {
                // NOTE: Fixed line spacing of 1.5 line-height
                // TODO: Support custom line spacing defined by user
                textOffsetY += scale + (lineSpacing / font.baseSize * scale);
                textOffsetX = 0.0f;
                k = 0;
            }
            else if (codepoint == '~')
            {
                if (GetCodepoint(text[i + 1], out codepointByteCount) == '~')
                {
                    codepointByteCount += 1;
                    wave = !wave;
                }
            }
            else
            {
                if ((codepoint != ' ') && (codepoint != '\t'))
                {
                    Vector3 pos = position;
                    if (wave) // Apply the wave effect
                    {
                        pos.X += MathF.Sin((time * config->waveSpeed.X) - (k * config->waveOffset.X)) * config->waveRange.X;
                        pos.Y += MathF.Sin((time * config->waveSpeed.Y) - (k * config->waveOffset.Y)) * config->waveRange.Y;
                        pos.Z += MathF.Sin((time * config->waveSpeed.Z) - (k * config->waveOffset.Z)) * config->waveRange.Z;
                    }

                    DrawTextCodepoint3D(font, codepoint, new Vector3(pos.X + textOffsetX, pos.Y, pos.Z + textOffsetY), fontSize, backface, tint);
                }

                if (font.glyphs[index].advanceX == 0)
                {
                    textOffsetX += (float)(font.recs[index].width + fontSpacing) / font.baseSize * scale;
                }
                else
                {
                    textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / font.baseSize * scale;
                }
            }

            i += codepointByteCount;   // Move text bytes counter to next codepoint
        }
    }

    static Vector3 MeasureTextWave3D(Font font, string text, float fontSize, float fontSpacing, float lineSpacing)
    {
        int len = TextLength(text);
        int tempLen = 0;                // Used to count longer text line num chars
        int lenCounter = 0;

        float tempTextWidth = 0.0f;     // Used to count longer text line width

        float scale = fontSize / font.baseSize;
        float textHeight = scale;
        float textWidth = 0.0f;

        int letter = 0;                 // Current character
        int index = 0;                  // Index position in sprite font

        for (int i = 0; i < len; i++)
        {
            lenCounter++;

            letter = GetCodepoint(text[i], out int next);
            index = GetGlyphIndex(font, letter);

            // NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
            // but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
            if (letter == 0x3f)
            {
                next = 1;
            }

            i += next - 1;

            if (letter != '\n')
            {
                if (letter == '~' && GetCodepoint(text[i + 1], out next) == '~')
                {
                    i++;
                }
                else
                {
                    if (font.glyphs[index].advanceX != 0)
                    {
                        textWidth += (font.glyphs[index].advanceX + fontSpacing) / font.baseSize * scale;
                    }
                    else
                    {
                        textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / font.baseSize * scale;
                    }
                }
            }
            else
            {
                if (tempTextWidth < textWidth)
                {
                    tempTextWidth = textWidth;
                }

                lenCounter = 0;
                textWidth = 0.0f;
                textHeight += scale + (lineSpacing / font.baseSize * scale);
            }

            if (tempLen < lenCounter)
            {
                tempLen = lenCounter;
            }
        }

        if (tempTextWidth < textWidth)
        {
            tempTextWidth = textWidth;
        }

        Vector3 vec = new(0);
        vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / font.baseSize * scale); // Adds chars spacing to measure
        vec.Y = 0.25f;
        vec.Z = textHeight;

        return vec;
    }

    const float Phi = 0.618033988749895f; // Golden ratio conjugate

    static Color GenerateRandomColor(float s, float v)
    {
        float h = GetRandomValue(0, 360);
        h += h * Phi % 360.0f;
        return ColorFromHSV(h, s, v);
    }
}
