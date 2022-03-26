// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Simple shader mask
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@chriscamacho -  http://bedroomcoders.co.uk/)
*   and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
*
********************************************************************************************
*
*   The shader makes alpha holes in the forground to give the apearance of a top
*   down look at a spotlight casting a pool of light...
*
*   The right hand side of the screen there is just enough light to see whats
*   going on without the spot light, great for a stealth type game where you
*   have to avoid the spotlights.
*
*   The left hand side of the screen is in pitch dark except for where the spotlights are.
*
*   Although this example doesn't scale like the letterbox example, you could integrate
*   the two techniques, but by scaling the actual colour of the render texture rather
*   than using alpha as a mask.
*
********************************************************************************************/

public static unsafe class Spotlight
{

#if PLATFORM_DESKTOP
    const int GLSL_VERSION = 330;
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
	const int GLSL_VERSION = 100;
#endif

    const int MAX_SPOTS = 3;        // NOTE: It must be the same as define in shader
    const int MAX_STARS = 400;
    // Spot data
    struct Spot
    {

        public Vector2 pos;
        public Vector2 vel;
        public float inner;
        public float radius;

        // Shader locations
        public int posLoc;
        public int innerLoc;
        public int radiusLoc;
    }

    // Stars in the star field have a position and velocity
    struct Star
    {
        public Vector2 pos;
        public Vector2 vel;
    }

    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib - shader spotlight");
        HideCursor();

        Texture2D texRay = LoadTexture("resources/raysan.png");

        Star[] stars = new Star[MAX_STARS];

        for (int n = 0; n < MAX_STARS; n++)
        {
            ResetStar(ref stars[n]);
        }

        // Progress all the stars on, so they don't all start in the centre
        for (int m = 0; m < screenWidth / 2.0; m++)
        {
            for (int n = 0; n < MAX_STARS; n++)
            {
                UpdateStar(ref stars[n]);
            }
        }

        int frameCounter = 0;

        // Use default vert shader
        Shader shdrSpot = LoadFShader(string.Format("resources/shaders/glsl{0}/spotlight.fs", GLSL_VERSION));

        // Get the locations of spots in the shader
        Spot[] spots = new Spot[MAX_SPOTS];

        for (int i = 0; i < MAX_SPOTS; i++)
        {
            string posName = $"spots[{i}].pos";
            string innerName = $"spots[{i}].inner";
            string radiusName = $"spots[{i}].radius";

            // posName[6] = '0' + i;
            // innerName[6] = '0' + i;
            // radiusName[6] = '0' + i;

            spots[i].posLoc = GetShaderLocation(shdrSpot, posName);
            spots[i].innerLoc = GetShaderLocation(shdrSpot, innerName);
            spots[i].radiusLoc = GetShaderLocation(shdrSpot, radiusName);

        }

        // Tell the shader how wide the screen is so we can have
        // a pitch Black half and a dimly lit half.
        int wLoc = GetShaderLocation(shdrSpot, "screenWidth");
        float sw = GetScreenWidth();
        SetShaderValue(shdrSpot, wLoc, &sw, ShaderUniformFloat);

        // Randomize the locations and velocities of the spotlights
        // and initialize the shader locations
        for (int i = 0; i < MAX_SPOTS; i++)
        {
            spots[i].pos.X = GetRandomValue(64, screenWidth - 64);
            spots[i].pos.Y = GetRandomValue(64, screenHeight - 64);
            spots[i].vel = new Vector2(0, 0);

            while ((MathF.Abs(spots[i].vel.X) + MathF.Abs(spots[i].vel.Y)) < 2)
            {
                spots[i].vel.X = GetRandomValue(-400, 40) / 10.0f;
                spots[i].vel.Y = GetRandomValue(-400, 40) / 10.0f;
            }

            spots[i].inner = 28.0f * (i + 1);
            spots[i].radius = 48.0f * (i + 1);

            SetShaderValue(shdrSpot, spots[i].posLoc, spots[i].pos.X, ShaderUniformVec2);
            SetShaderValue(shdrSpot, spots[i].innerLoc, spots[i].inner, ShaderUniformFloat);
            SetShaderValue(shdrSpot, spots[i].radiusLoc, spots[i].radius, ShaderUniformFloat);
        }

        SetTargetFPS(60);               // Set  to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            frameCounter++;

            // Move the stars, resetting them if the go offscreen
            for (int n = 0; n < MAX_STARS; n++)
            {
                UpdateStar(ref stars[n]);
            }

            // Update the spots, send them to the shader
            for (int i = 0; i < MAX_SPOTS; i++)
            {
                if (i == 0)
                {
                    Vector2 mp = GetMousePosition();
                    spots[i].pos.X = mp.X;
                    spots[i].pos.Y = screenHeight - mp.Y;
                }
                else
                {
                    spots[i].pos.X += spots[i].vel.X;
                    spots[i].pos.Y += spots[i].vel.Y;

                    if (spots[i].pos.X < 64)
                    {
                        spots[i].vel.X = -spots[i].vel.X;
                    }

                    if (spots[i].pos.X > (screenWidth - 64))
                    {
                        spots[i].vel.X = -spots[i].vel.X;
                    }

                    if (spots[i].pos.Y < 64)
                    {
                        spots[i].vel.Y = -spots[i].vel.Y;
                    }

                    if (spots[i].pos.Y > (screenHeight - 64))
                    {
                        spots[i].vel.Y = -spots[i].vel.Y;
                    }
                }

                SetShaderValue(shdrSpot, spots[i].posLoc, ref spots[i].pos.X, ShaderUniformVec2);
            }

            // Draw

            BeginDrawing();

            ClearBackground(Darkblue);

            // Draw stars and bobs
            for (int n = 0; n < MAX_STARS; n++)
            {
                // Single pixel is just too small these days!
                DrawRectangle((int)stars[n].pos.X, (int)stars[n].pos.Y, 2, 2, White);
            }

            for (int i = 0; i < 16; i++)
            {
                DrawTexture(texRay,
                    (int)((screenWidth / 2.0f) + (Math.Cos((frameCounter + (i * 8)) / 51.45f) * (screenWidth / 2.2f)) - 32),
                    (int)((screenHeight / 2.0f) + (Math.Sin((frameCounter + (i * 8)) / 17.87f) * (screenHeight / 4.2f))), White);
            }

            // Draw spot lights
            BeginShaderMode(shdrSpot);
            // Instead of a blank rectangle you could render here
            // a render texture of the full screen used to do screen
            // scaling (slight adjustment to shader would be required
            // to actually pay attention to the colour!)
            DrawRectangle(0, 0, screenWidth, screenHeight, White);
            EndShaderMode();

            DrawFPS(10, 10);

            DrawText("Move the mouse!", 10, 30, 20, Green);
            DrawText("Pitch Black", (int)(screenWidth * 0.2f), screenHeight / 2, 20, Green);
            DrawText("Dark", (int)(screenWidth * .66f), screenHeight / 2, 20, Green);


            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texRay);
        UnloadShader(shdrSpot);

        CloseWindow();        // Close window and OpenGL context



    }



    static void ResetStar(ref Star s)
    {
        s.pos = new Vector2(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);

        do
        {
            s.vel.X = GetRandomValue(-1000, 1000) / 100.0f;
            s.vel.Y = GetRandomValue(-1000, 1000) / 100.0f;

        } while (MathF.Abs(s.vel.X) + MathF.Abs(s.vel.Y) > 1);

        s.pos = Vector2Add(s.pos, Vector2Multiply(s.vel, new Vector2(8.0f, 8.0f)));
    }

    static void UpdateStar(ref Star s)
    {
        s.pos = Vector2Add(s.pos, s.vel);

        if ((s.pos.X < 0) || (s.pos.X > GetScreenWidth()) ||
            (s.pos.Y < 0) || (s.pos.Y > GetScreenHeight()))
        {
            ResetStar(ref s);
        }
    }

}
