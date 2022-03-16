// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Apply a postprocessing shader to a scene
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
public static unsafe class PostProcessingShader
{
    ////#if PLATFORM_DESKTOP
    ////	const int GLSL_VERSION = 330;
    ////#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
    ////const int GLSL_VERSION =100;
    ////#endif
    const int GLSL_VERSION = 330;


    const int MAX_POSTPRO_SHADERS = 12;


    enum PostproShader
    {
        FX_GRAYSCALE = 0,
        FX_POSTERIZATION,
        FX_DREAM_VISION,
        FX_PIXELIZER,
        FX_CROSS_HATCHING,
        FX_CROSS_STITCHING,
        FX_PREDATOR_VIEW,
        FX_SCANLINES,
        FX_FISHEYE,
        FX_SOBEL,
        FX_BLOOM,
        FX_BLUR,
        //FX_FXAA
    }

    static string[] postproShaderText = new string[]{
    "GRAYSCALE",
    "POSTERIZATION",
    "DREAM_VISION",
    "PIXELIZER",
    "CROSS_HATCHING",
    "CROSS_STITCHING",
    "PREDATOR_VIEW",
    "SCANLINES",
    "FISHEYE",
    "SOBEL",
    "BLOOM",
    "BLUR",
	//"FXAA"
};


    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FLAG_MSAA_4X_HINT);      // Enable Multi Sampling Anti Aliasing 4x (if available)

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - postprocessing shader");

        // Define the camera to look into our 3d world
        Camera camera = new(new(2.0f, 3.0f, 2.0f), new(
        0.0f, 1.0f, 0.0f), new(
            0.0f, 1.0f, 0.0f), 45.0f, 0);

        Model model = LoadModel("resources/models/church.obj");                 // Load OBJ model
        Texture2D texture = LoadTexture("resources/models/church_diffuse.png"); // Load model texture (diffuse map)
        model.materials[0].maps[(int)MATERIAL_MAP_ALBEDO].texture = texture;                     // Set model diffuse texture

        Vector3 position = new(0.0f, 0.0f, 0.0f);                             // Set model position

        // Load all postpro shaders
        // NOTE 1: All postpro shader use the base vertex shader (DEFAULT_VERTEX_SHADER)
        // NOTE 2: We load the correct shader depending on GLSL version
        Shader[] shaders = new Shader[MAX_POSTPRO_SHADERS];

        // NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        shaders[(int)PostproShader.FX_GRAYSCALE] = LoadFShader(TextFormat("resources/shaders/glsl%i/grayscale.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_POSTERIZATION] = LoadFShader(TextFormat("resources/shaders/glsl%i/posterization.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_DREAM_VISION] = LoadFShader(TextFormat("resources/shaders/glsl%i/dream_vision.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_PIXELIZER] = LoadFShader(TextFormat("resources/shaders/glsl%i/pixelizer.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_CROSS_HATCHING] = LoadFShader(TextFormat("resources/shaders/glsl%i/cross_hatching.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_CROSS_STITCHING] = LoadFShader(TextFormat("resources/shaders/glsl%i/cross_stitching.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_PREDATOR_VIEW] = LoadFShader(TextFormat("resources/shaders/glsl%i/predator.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_SCANLINES] = LoadFShader(TextFormat("resources/shaders/glsl%i/scanlines.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_FISHEYE] = LoadFShader(TextFormat("resources/shaders/glsl%i/fisheye.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_SOBEL] = LoadFShader(TextFormat("resources/shaders/glsl%i/sobel.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_BLOOM] = LoadFShader(TextFormat("resources/shaders/glsl%i/bloom.fs", GLSL_VERSION));
        shaders[(int)PostproShader.FX_BLUR] = LoadFShader(TextFormat("resources/shaders/glsl%i/blur.fs", GLSL_VERSION));

        int currentShader = (int)PostproShader.FX_GRAYSCALE;

        // Create a RenderTexture2D to be used for render to texture
        RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

        // Setup orbital camera
        SetCameraMode(ref camera, CAMERA_ORBITAL);  // Set an orbital camera mode

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera

            if (IsKeyPressed(KEY_RIGHT))
            {
                currentShader++;
            }
            else if (IsKeyPressed(KEY_LEFT))
            {
                currentShader--;
            }

            if (currentShader >= MAX_POSTPRO_SHADERS)
            {
                currentShader = 0;
            }
            else if (currentShader < 0)
            {
                currentShader = MAX_POSTPRO_SHADERS - 1;
            }


            // Draw

            BeginTextureMode(target);       // Enable drawing to texture
            ClearBackground(RAYWHITE);  // Clear texture background

            BeginMode3D(ref camera);        // Begin 3d mode drawing
            DrawModel(model, position, 0.1f, WHITE);   // Draw 3d model with texture
            DrawGrid(10, 1.0f);     // Draw a grid
            EndMode3D();                // End 3d mode drawing, returns to orthographic 2d mode
            EndTextureMode();               // End drawing to texture (now we have a texture available for next passes)

            BeginDrawing();
            ClearBackground(RAYWHITE);  // Clear screen background

            // Render generated texture using selected postprocessing shader
            BeginShaderMode(shaders[currentShader]);
            // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
            DrawTextureRec(target.texture, new Rectangle(0, 0, target.texture.width, -target.texture.height), new Vector2(
                0, 0), WHITE);
            EndShaderMode();

            // Draw 2d shapes and text over drawn texture
            DrawRectangle(0, 9, 580, 30, Fade(LIGHTGRAY, 0.7f));

            DrawText("(c) Church 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);
            DrawText("CURRENT POSTPRO SHADER:", 10, 15, 20, BLACK);
            DrawText(postproShaderText[currentShader], 330, 15, 20, RED);
            DrawText("< >", 540, 10, 30, DARKBLUE);
            DrawFPS(700, 15);
            EndDrawing();

        }

        // De-Initialization

        // Unload all postpro shaders
        for (int i = 0; i < MAX_POSTPRO_SHADERS; i++)
        {
            UnloadShader(shaders[i]);
        }

        UnloadTexture(texture);         // Unload texture
        UnloadModel(model);             // Unload model
        UnloadRenderTexture(target);    // Unload render texture

        CloseWindow();                  // Close window and OpenGL context


        return 0;
    }
}
