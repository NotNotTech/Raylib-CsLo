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
        Camera3D camera = new(new(1.0f, 1.0f, 1.0f), new(4.0f, 1.0f, 4.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        // Load skybox model
        Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);
        Model skybox = LoadModelFromMesh(cube);

        bool useHDR = true;

        // Load skybox shader and set required locations
        // NOTE: Some locations are automatically set at shader loading
        skybox.materials[0].shader = LoadShader(TextFormat("resources/shaders/glsl%i/skybox.vs", GLSL_VERSION), TextFormat("resources/shaders/glsl%i/skybox.fs", GLSL_VERSION));

        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "environmentMap"), MaterialMapCubemap, ShaderUniformInt);
        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "doGamma"), useHDR ? 1 : 0, ShaderUniformInt);
        SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "vflipped"), useHDR ? 1 : 0, ShaderUniformInt);

        // Load cubemap shader and setup required shader locations
        Shader shdrCubemap = LoadShader(TextFormat("resources/shaders/glsl%i/cubemap.vs", GLSL_VERSION), TextFormat("resources/shaders/glsl%i/cubemap.fs", GLSL_VERSION));

        SetShaderValue(shdrCubemap, GetShaderLocation(shdrCubemap, "equirectangularMap"), 0, ShaderUniformInt);

        //char skyboxFileName[256];
        string skyboxFileName = null;

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
            skybox.materials[0].maps[(int)MaterialMapCubemap].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PixelformatUncompressedR8g8b8a8);

            //UnloadTexture(panorama);    // Texture not required anymore, cubemap already generated
        }
        else
        {
            Image img = LoadImage("resources/skybox.png");
            panorama = LoadTextureCubemap(img, CubemapLayoutAutoDetect);    // CUBEMAP_LAYOUT_PANORAMA
            skybox.materials[0].maps[(int)MaterialMapCubemap].texture = panorama;
            UnloadImage(img);
        }

        SetCameraMode(camera, CameraFirstPerson);  // Set a first person camera mode

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
                        UnloadTexture(skybox.materials[0].maps[(int)MaterialMapCubemap].texture);
                        if (useHDR)
                        {
                            //unload prior texture
                            UnloadTexture(panorama);
                            panorama = LoadTexture(droppedFiles[0]);

                            // Generate cubemap from panorama texture
                            skybox.materials[0].maps[(int)MaterialMapCubemap].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PixelformatUncompressedR8g8b8a8);

                        }
                        else
                        {
                            Image img = LoadImage(droppedFiles[0]);
                            skybox.materials[0].maps[(int)MaterialMapCubemap].texture = LoadTextureCubemap(img, CubemapLayoutAutoDetect);
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

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            // We are inside the cube, we need to disable backface culling!
            rlDisableBackfaceCulling();
            rlDisableDepthMask();
            DrawModel(skybox, new(0, 0, 0), 1.0f, White);
            rlEnableBackfaceCulling();
            rlEnableDepthMask();

            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawTextureEx(panorama, new(0, 0), 0.0f, 0.5f, White);

            if (skyboxFileName != null)
            {
                if (useHDR)
                {
                    DrawText(TextFormat("Panorama image from hdrihaven.com: %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, Black);
                }
                else
                {
                    DrawText(TextFormat(": %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, Black);
                }
            }

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadShader(skybox.materials[0].shader);
        UnloadTexture(skybox.materials[0].maps[(int)MaterialMapCubemap].texture);

        UnloadModel(skybox);        // Unload skybox model

        CloseWindow();              // Close window and OpenGL context


        return 0;
    }

    public static bool EndsWith(this string text, params string[] endings)
    {
        foreach (string end in endings)
        {
            if (text.EndsWith(end))
            {
                return true;
            }
        }
        return false;
    }


    // Generate cubemap texture from HDR texture
    static Texture2D GenTextureCubemap(Shader shader, Texture2D panorama, int size, PixelFormat format)
    {
        Texture2D cubemap = new();

        rlDisableBackfaceCulling();     // Disable backface culling to render inside the cube

        // STEP 1: Setup framebuffer

        uint rbo = rlLoadTextureDepth(size, size, true);
        cubemap.id = rlLoadTextureCubemap(IntPtr.Zero, size, (int)format);

        uint fbo = rlLoadFramebuffer(size, size);
        rlFramebufferAttach(fbo, rbo, (int)RlAttachmentDepth, (int)RlAttachmentRenderbuffer, 0);
        rlFramebufferAttach(fbo, cubemap.id, (int)RlAttachmentColorChannel0, (int)RlAttachmentCubemapPositiveX, 0);

        // Check if framebuffer is complete with attachments (valid)
        if (rlFramebufferComplete(fbo))
        {
            TraceLog(LogInfo, "FBO: [ID %i] Framebuffer object created successfully", fbo);
        }


        // STEP 2: Draw to framebuffer

        // NOTE: Shader is used to convert HDR equirectangular environment map to cubemap equivalent (6 faces)
        rlEnableShader(shader.id);

        // Define projection matrix and send it to shader
        Matrix4x4 matFboProjection = MatrixPerspective(90.0 * MathF.PI / 180, 1.0, RlCullDistanceNear, RlCullDistanceFar);
        rlSetUniformMatrix(shader.locs[(int)RlShaderLocMatrixProjection], Matrix4x4.Transpose(matFboProjection));

        // Define view matrix for every side of the cubemap
        Matrix4x4[] fboViews = new Matrix4x4[6] {
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
            rlSetUniformMatrix(shader.locs[(int)RlShaderLocMatrixView], Matrix4x4.Transpose(fboViews[i]));

            // Select the current cubemap face attachment for the fbo
            // WARNING: This function by default enables->attach->disables fbo!!!
            rlFramebufferAttach(fbo, cubemap.id, (int)RlAttachmentColorChannel0, (int)(RlAttachmentCubemapPositiveX + i), 0);
            rlEnableFramebuffer(fbo);

            // Load and draw a cube, it uses the current enabled texture
            rlClearScreenBuffers();
            rlLoadDrawCube();

            // ALTERNATIVE: Try to use internal batch system to draw the cube instead of rlLoadDrawCube
            // for some reason this method does not work, maybe due to cube triangles definition? normals pointing out?
            // TODO: Investigate this issue...
            //rlSetTexture(panorama.id); // WARNING: It must be called after enabling current framebuffer if using internal batch system!
            //rlClearScreenBuffers();
            //DrawCubeV(Vector3Zero(), Vector3One(), White);
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
        cubemap.format = (int)format;

        return cubemap;
    }


}
