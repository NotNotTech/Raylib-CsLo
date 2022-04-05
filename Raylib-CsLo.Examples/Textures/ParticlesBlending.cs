// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib example - particles blending
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public static class ParticlesBlending
{

    const int MAX_PARTICLES = 200;

    // Particle structure with basic data
    struct Particle
    {

        public Vector2 position;
        public Color color;
        public float alpha;
        public float size;
        public float rotation;
        public bool active;        // NOTE: Use it to activate/deactive particle
    }

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [textures] example - particles blending");

        // Particles pool, reuse them!
        Particle[] mouseTail = new Particle[MAX_PARTICLES];

        // Initialize particles
        for (int i = 0; i < MAX_PARTICLES; i++)
        {
            mouseTail[i].position = new Vector2(0, 0);
            mouseTail[i].color = new Color(GetRandomValue(0, 255), GetRandomValue(0, 255), GetRandomValue(0, 255), 255);
            mouseTail[i].alpha = 1.0f;
            mouseTail[i].size = GetRandomValue(1, 30) / 20.0f;
            mouseTail[i].rotation = GetRandomValue(0, 360);
            mouseTail[i].active = false;
        }

        float gravity = 3.0f;

        Texture2D smoke = LoadTexture("resources/spark_flame.png");

        BlendMode blending = BlendAlpha;

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update


            // Activate one particle every frame and Update active particles
            // NOTE: Particles initial position should be mouse position when activated
            // NOTE: Particles fall down with gravity and rotation... and disappear after 2 seconds (alpha = 0)
            // NOTE: When a particle disappears, active = false and it can be reused.
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                if (!mouseTail[i].active)
                {
                    mouseTail[i].active = true;
                    mouseTail[i].alpha = 1.0f;
                    mouseTail[i].position = GetMousePosition();
                    i = MAX_PARTICLES;
                }
            }

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                if (mouseTail[i].active)
                {
                    mouseTail[i].position.Y += gravity / 2;
                    mouseTail[i].alpha -= 0.005f;

                    if (mouseTail[i].alpha <= 0.0f)
                    {
                        mouseTail[i].active = false;
                    }

                    mouseTail[i].rotation += 2.0f;
                }
            }

            if (IsKeyPressed(KeySpace))
            {
                if (blending == BlendAlpha)
                {
                    blending = BlendAdditive;
                }
                else
                {
                    blending = BlendAlpha;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Darkgray);

            BeginBlendMode(blending);

            // Draw active particles
            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                if (mouseTail[i].active)
                {
                    DrawTexturePro(smoke, new Rectangle(0.0f, 0.0f, smoke.width, smoke.height),
                                  new Rectangle(mouseTail[i].position.X, mouseTail[i].position.Y, smoke.width * mouseTail[i].size, smoke.height * mouseTail[i].size),
                                  new Vector2((float)(smoke.width * mouseTail[i].size / 2.0f), (float)(smoke.height * mouseTail[i].size / 2.0f)), mouseTail[i].rotation,
                                  Fade(mouseTail[i].color, mouseTail[i].alpha));
                }
            }

            EndBlendMode();

            DrawText("PRESS SPACE to CHANGE BLENDING MODE", 180, 20, 20, Black);

            if (blending == BlendAlpha)
            {
                DrawText("ALPHA BLENDING", 290, screenHeight - 40, 20, Black);
            }
            else
            {
                DrawText("ADDITIVE BLENDING", 280, screenHeight - 40, 20, Raywhite);
            }

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(smoke);

        CloseWindow();        // Close window and OpenGL context



    }
}
