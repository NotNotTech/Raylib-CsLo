// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

/*******************************************************************************************
*
*   raylib [shaders] example - Apply a postprocessing shader and connect a custom uniform variable
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

public static unsafe class CustomUniform
{

    const int GLSL_VERSION = 330;
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        SetConfigFlags(FlagMsaa4xHint);      // Enable Multi Sampling Anti Aliasing 4x (if available)

        InitWindow(screenWidth, screenHeight, "raylib [shaders] example - custom uniform variable");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new Vector3(8.0f, 8.0f, 8.0f);
        camera.target = new Vector3(0.0f, 1.5f, 0.0f);
        camera.up = new Vector3(0.0f, 1.0f, 0.0f);
        camera.fovy = 45.0f;
        camera.Projection = CameraPerspective;

        Model model = LoadModel("resources/models/barracks.obj");                   // Load OBJ model
        Texture2D texture = LoadTexture("resources/models/barracks_diffuse.png");   // Load model texture (diffuse map)
        model.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;                     // Set model diffuse texture

        Vector3 position = new(0.0f, 0.0f, 0.0f);                                    // Set model position

        // Load postprocessing shader
        // NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
        Shader shader = LoadFShader(string.Format("resources/shaders/glsl{0}/swirl.fs", GLSL_VERSION));

        // Get variable (uniform) location on the shader to connect with the program
        // NOTE: If uniform variable could not be found in the shader, function returns -1
        int swirlCenterLoc = GetShaderLocation(shader, "center");

        Vector2 swirlCenter = new((float)screenWidth / 2, (float)screenHeight / 2);

        // Create a RenderTexture2D to be used for render to texture
        RenderTexture target = LoadRenderTexture(screenWidth, screenHeight);

        // Setup orbital camera
        SetCameraMode(camera, CameraOrbital);  // Set an orbital camera mode

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            Vector2 mousePosition = GetMousePosition();

            swirlCenter.X = mousePosition.X;
            swirlCenter.Y = screenHeight - mousePosition.Y;

            // Send new value to the shader to be used on drawing
            SetShaderValue(shader, swirlCenterLoc, swirlCenter, ShaderUniformVec2);

            UpdateCamera(ref camera);          // Update camera


            // Draw

            BeginTextureMode(target);       // Enable drawing to texture
            ClearBackground(Raywhite);  // Clear texture background

            BeginMode3D(camera);        // Begin 3d mode drawing
            DrawModel(model, position, 0.5f, White);   // Draw 3d model with texture
            DrawGrid(10, 1.0f);     // Draw a grid
            EndMode3D();                // End 3d mode drawing, returns to orthographic 2d mode

            DrawText("TEXT DRAWN IN RENDER TEXTURE", 200, 10, 30, Red);
            EndTextureMode();               // End drawing to texture (now we have a texture available for next passes)

            BeginDrawing();
            ClearBackground(Raywhite);  // Clear screen background

            // Enable shader using the custom uniform
            BeginShaderMode(shader);
            // NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
            DrawTextureRec(target.texture, new Rectangle(0, 0, target.texture.width, -target.texture.height), new Vector2(0, 0), White);
            EndShaderMode();

            // Draw some 2d text over drawn texture
            DrawText("(c) Barracks 3D model by Alberto Cano", screenWidth - 220, screenHeight - 20, 10, Gray);
            DrawFPS(10, 10);
            EndDrawing();

        }

        // De-Initialization

        UnloadShader(shader);               // Unload shader
        UnloadTexture(texture);             // Unload texture
        UnloadModel(model);                 // Unload model
        UnloadRenderTexture(target);        // Unload render texture

        CloseWindow();                      // Close window and OpenGL context



    }
}
