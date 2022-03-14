// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Skybox loading and drawing
//*
//* This example has been created using raylib 3.5 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2017-2020 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static unsafe class Skybox
{
    //#if defined(PLATFORM_DESKTOP)
    //#define GLSL_VERSION            330
    //#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
    //#define GLSL_VERSION            100
    //#endif
    const int GLSL_VERSION = 330;

    public static int Example()
    {


        //// Generate cubemap (6 faces) from equirectangular (panorama) texture
        //static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format);

        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - skybox loading and drawing");

        // Define the camera to look into our 3d world
        Camera camera = new(new(1.0f, 1.0f, 1.0f), new(4.0f, 1.0f, 4.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        // Load skybox model
        Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);
        Model skybox = LoadModelFromMesh(cube);

        bool useHDR = true;

        // Load skybox shader and set required locations
        // NOTE: Some locations are automatically set at shader loading
        skybox.materials[0].shader = LoadShader(TextFormat("resources/shaders/glsl%i/skybox.vs", GLSL_VERSION),
                                                TextFormat("resources/shaders/glsl%i/skybox.fs", GLSL_VERSION));

        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "environmentMap"), MATERIAL_MAP_CUBEMAP, SHADER_UNIFORM_INT);
        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "doGamma"), useHDR ? 1 : 0, SHADER_UNIFORM_INT);
        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "vflipped"), useHDR ? 1 : 0, SHADER_UNIFORM_INT);

        // Load cubemap shader and setup required shader locations
        Shader shdrCubemap = LoadShader(TextFormat("resources/shaders/glsl%i/cubemap.vs", GLSL_VERSION),
                                        TextFormat("resources/shaders/glsl%i/cubemap.fs", GLSL_VERSION));

        SetShaderValue(shdrCubemap, GetShaderLocation(shdrCubemap, "equirectangularMap"), 0, SHADER_UNIFORM_INT);

        //char skyboxFileName[256];
        string? skyboxFileName = null;

        Texture2D panorama;

        if (useHDR)
        {
            //TextCopy(skyboxFileName, "resources/dresden_square_2k.hdr");
            skyboxFileName = "resources/dresden_square_2k.hdr";

            // Load HDR panorama (sphere) texture
            panorama = LoadTexture(skyboxFileName);

            // Generate cubemap (texture with 6 quads-cube-mapping) from panorama HDR texture
            // NOTE 1: New texture is generated rendering to texture, shader calculates the sphere->cube coordinates mapping
            // NOTE 2: It seems on some Android devices WebGL, fbo does not properly support a FLOAT-based attachment,
            // despite texture can be successfully created.. so using PIXELFORMAT_UNCOMPRESSED_R8G8B8A8 instead of PIXELFORMAT_UNCOMPRESSED_R32G32B32A32
            skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

            //UnloadTexture(panorama);    // Texture not required anymore, cubemap already generated
        }
        else
        {
            Image img = LoadImage("resources/skybox.png");
            panorama = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);    // CUBEMAP_LAYOUT_PANORAMA
            skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = panorama;
            UnloadImage(img);
        }

        SetCameraMode(ref camera, CAMERA_FIRST_PERSON);  // Set a first person camera mode

        SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())            // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);              // Update camera

            // Load new cubemap texture on drag&drop
            if (IsFileDropped())
            {
                int count = 0;
                //char** droppedFiles = GetDroppedFiles(&count);
                string[] droppedFiles = GetDroppedFiles();
                count = droppedFiles.Length;

                if (count == 1)         // Only support one file dropped
                {
                    //if (IsFileExtension(droppedFiles[0], ".png;.jpg;.hdr;.bmp;.tga"))
                    if (droppedFiles[0].EndsWith(".png", ".jpg", ".hdr", ".bmp", ".tga"))
                    {
                        // Unload current cubemap texture and load new one
                        UnloadTexture(skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture);
                        if (useHDR)
                        {
                            //unload prior texture
                            UnloadTexture(panorama);
                            panorama = LoadTexture(droppedFiles[0]);

                            // Generate cubemap from panorama texture
                            skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

                        }
                        else
                        {
                            Image img = LoadImage(droppedFiles[0]);
                            skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);
                            UnloadImage(img);
                        }

                        //TextCopy(skyboxFileName, droppedFiles[0]);
                        skyboxFileName = droppedFiles[0];
                    }
                }

                ClearDroppedFiles();    // Clear internal buffers
            }


            // Draw

            BeginDrawing();

            ClearBackground(RAYWHITE);

            BeginMode3D(ref camera);

            // We are inside the cube, we need to disable backface culling!
            rlDisableBackfaceCulling();
            rlDisableDepthMask();
            DrawModel(skybox, new(0, 0, 0), 1.0f, WHITE);
            rlEnableBackfaceCulling();
            rlEnableDepthMask();

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawTextureEx(panorama, new(0, 0), 0.0f, 0.5f, WHITE);

            if (skyboxFileName != null)
            {
                if (useHDR)
                {
                    DrawText(TextFormat("Panorama image from hdrihaven.com: %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);
                }
                else
                {
                    DrawText(TextFormat(": %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);
                }
            }

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadShader(skybox.materials[0].shader);
        UnloadTexture(skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture);

        UnloadModel(skybox);        // Unload skybox model

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }

    public static bool EndsWith(this string text, params string[] endings)
    {
        foreach (string? end in endings)
        {
            if (text.EndsWith(end))
            {
                return true;
            }
        }
        return false;
    }


    // Generate cubemap texture from HDR texture
    static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, PixelFormat format)
    {
        TextureCubemap cubemap = new();

        rlDisableBackfaceCulling();     // Disable backface culling to render inside the cube

        // STEP 1: Setup framebuffer

        uint rbo = rlLoadTextureDepth(size, size, true);
        cubemap.id = rlLoadTextureCubemap((void*)0, size, format);

        uint fbo = rlLoadFramebuffer(size, size);
        rlFramebufferAttach(fbo, rbo, RL_ATTACHMENT_DEPTH, RL_ATTACHMENT_RENDERBUFFER, 0);
        rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X, 0);

        // Check if framebuffer is complete with attachments (valid)
        if (rlFramebufferComplete(fbo))
        {
            TraceLog(LOG_INFO, "FBO: [ID %i] Framebuffer object created successfully", fbo);
        }


        // STEP 2: Draw to framebuffer

        // NOTE: Shader is used to convert HDR equirectangular environment map to cubemap equivalent (6 faces)
        rlEnableShader(shader.id);

        // Define projection matrix and send it to shader
        Matrix matFboProjection = MatrixPerspective(90.0 * DEG2RAD, 1.0, RL_CULL_DISTANCE_NEAR, RL_CULL_DISTANCE_FAR);
        rlSetUniformMatrix(shader.locs[(int)RL_SHADER_LOC_MATRIX_PROJECTION], Matrix.Transpose(matFboProjection));

        // Define view matrix for every side of the cubemap
        Matrix[] fboViews = new Matrix[6] {
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(-1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 1.0f)),
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f), new(0.0f, 0.0f, -1.0f)),
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, 1.0f), new(0.0f, -1.0f, 0.0f)),
            MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, -1.0f), new(0.0f, -1.0f, 0.0f))
        };

        rlViewport(0, 0, size, size);   // Set viewport to current fbo dimensions

        // Activate and enable texture for drawing to cubemap faces
        rlActiveTextureSlot(0);
        rlEnableTexture(panorama.id);

        for (int i = 0; i < 6; i++)
        {
            // Set the view matrix for the current cube face
            rlSetUniformMatrix(shader.locs[(int)RL_SHADER_LOC_MATRIX_VIEW], Matrix.Transpose(fboViews[i]));

            // Select the current cubemap face attachment for the fbo
            // WARNING: This function by default enables->attach->disables fbo!!!
            rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X + i, 0);
            rlEnableFramebuffer(fbo);

            // Load and draw a cube, it uses the current enabled texture
            rlClearScreenBuffers();
            rlLoadDrawCube();

            // ALTERNATIVE: Try to use internal batch system to draw the cube instead of rlLoadDrawCube
            // for some reason this method does not work, maybe due to cube triangles definition? normals pointing out?
            // TODO: Investigate this issue...
            //rlSetTexture(panorama.id); // WARNING: It must be called after enabling current framebuffer if using internal batch system!
            //rlClearScreenBuffers();
            //DrawCubeV(Vector3Zero(), Vector3One(), WHITE);
            //rlDrawRenderBatchActive();
        }


        // STEP 3: Unload framebuffer and reset state

        rlDisableShader();          // Unbind shader
        rlDisableTexture();         // Unbind texture
        rlDisableFramebuffer();     // Unbind framebuffer
        rlUnloadFramebuffer(fbo);   // Unload framebuffer (and automatically attached depth texture/renderbuffer)

        // Reset viewport dimensions to default
        rlViewport(0, 0, rlGetFramebufferWidth(), rlGetFramebufferHeight());
        rlEnableBackfaceCulling();


        cubemap.width = size;
        cubemap.height = size;
        cubemap.mipmaps = 1;
        cubemap.Format = format;

        return cubemap;
    }


}
