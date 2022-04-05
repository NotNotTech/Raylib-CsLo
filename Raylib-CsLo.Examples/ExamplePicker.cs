// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Shaders;

public static unsafe class ExamplePicker
{
    static int currentExample;

    static readonly string[] Examples =
    {
        // Core
        "CoreBasicWindow",
        "CoreBasicScreenManager",
        "CoreInputKeys",
        "CoreInputMouse",
        "CoreInputMouseWheel",
        "CoreInputGamepad",
        "CoreInputMultitouch",
        "CoreInputGestures",
        "Core2dCamera",
        "Core2dCameraPlatformer",
        "Core3dCameraMode",
        "Core3dCameraFree",
        "Core3dCameraFirstPerson",
        "Core3dPicking",
        "CoreWorldScreen",
        "CoreCustomLogging",
        "CoreWindowLetterbox",
        "CoreDropFiles",
        "CoreScissorTest",
        "CoreVrSimulator",
        "CoreQuatConversion",
        "CoreWindowFlags",
        "CoreSplitScreen",
        "CoreSmoothPixelperfect",
        "CoreCustomFrameControl",

        // Models
        "ModelsAnimation",
        "ModelsBillboard",
        "ModelsBoxCollisions",
        "ModelsCubicmap",
        "ModelsFirstPersonMaze",
        "ModelsGeometricShapes",
        "ModelsHeightmap",
        "ModelsLoading",
        "ModelsLoadingGltf",
        "ModelsLoadingVox",
        "ModelsMeshGeneration",
        "ModelsMeshPicking",
        "ModelsOrthographicProjection",
        "ModelsRlglSolarSystem",
        "ModelsSkybox",
        "ModelsWavingCubes",
        "ModelsYawPitchRoll",

        // Shaders
        "ShadersBasicLighting",
        "ShadersCustomUniform",
        "ShadersEratosthenes",
        "ShadersFog",
        "ShadersHotReloading",
        "ShadersJuliaSet",
        "ShadersMeshInstancing",
        "ShadersModelShader",
        "ShadersMultiSample2d",
        "ShadersPaletteColorSwitch",
        "ShadersPostProcessing",
        "ShadersRaymarching",
        "ShadersShapesTextures",
        "ShadersSimpleMask",
        "ShadersSpotlight",
        "ShadersTextureDrawing",
        "ShadersTextureOutline",
        "ShadersTextureWaves",

        // Textures
        "TexturesBackgroundScrolling",
        "TexturesBlendModes",
        "TexturesBunnymark",
        "TexturesImageDrawing",
        "TexturesImageGeneration",
        "TexturesImageLoading",
        "TexturesImageProcessing",
        "TexturesImageText",
        "TexturesImageLoading",
        "TexturesMousePainting",
        "TexturesNPatchDrawing",
        "TexturesParticlesBlending",
        "TexturesSpriteButton",
        "TexturesSpriteExplosion",
        "TexturesTexturedPolygon",
        "TexturesRawData",
        "TexturesTextureRectangle",
        "TexturesTextureSourceAndDestinationRectangles",
        "TexturesToImage",
        "TexturesTiledTexture",

        // Text
        "TextDraw2dIn3d",
        "TextInsideRectangle",
        "TextFontFilters",
        "TextFontLoading",
        "TextRaylibFonts",
        "TextInputBox",
        "TextSdfFonts",
        "TextSpriteFontLoading",
        "TextTextFormatting",
        "TextWritingAnimation",
        "TextUnicode",

        // Shapes
        "ShapesBasicShapes",
        "ShapesBouncingBall",
        "ShapesCollisionArea",
        "ShapesColorsPalette",
        "ShapesDrawCircleSector",
        "ShapesDrawRectangleRounded",
        "ShapesDrawRing",
        "ShapesEasingsBallAnim",
        "ShapesEasingsBoxAnim",
        "ShapesEasingsRectangleArray",
        "ShapesFollowingEyes",
        "ShapesLogoAnimation",
        "ShapesLogoUsingShapes",
        "ShapesLinesBezier",

        // Audio
        "AudioModulePlaying",
        "AudioMultichannelSound",
        "AudioMusicPlayingStreaming",
        "AudioRawStream",
        "AudioSoundLoading",

        // Physics
        "PhysicsDemo",
        "PhysicsFriction",
        "PhysicsMovement",
        "PhysicsRestitution",
        "PhysicsShatter"
    };

    public static int Example()
    {
        const int screenWidth = 1000;
        const int screenHeight = 650;

        InitWindow(screenWidth, screenHeight, "Raylib-CsLo Example Picker");

        Image icon = LoadImageRaw("./Icon.raw", 128, 128, PixelformatUncompressedR8g8b8a8, 0);

        Raylib.SetWindowIcon(icon);

        GuiLoadStyleDefault();

        SetTargetFPS(60);

        Dictionary<int, Texture2D> previews = new();

        for (int i = 0; i < Examples.Length; i++)
        {
            previews.Add(i, LoadTextureFromImage(LoadImage("resources/previews/" + Examples[i] + ".png")));
        }

        var pickedExampleToRun = false;
        while (!WindowShouldClose())
        {
            if (IsKeyPressed(KeyLeft))
            {
                currentExample--;
            }

            if (IsKeyPressed(KeyRight))
            {
                currentExample++;
            }

            if (currentExample < 0)
            {
                currentExample = Examples.Length - 1;
            }
            else
            {
                currentExample %= Examples.Length;
            }

            if (IsKeyDown(KeyEnter))
            {
                pickedExampleToRun = true;
            }
            else if (pickedExampleToRun) //hack raylib bugfix:  if you exit while the last call to IsKeyDown(KeyEnter) returns true, it will be "stuck" true for the next window call.
            {
                break; //closes window when this breaks out of render loop
            }

            BeginDrawing();
            ClearBackground(White);

            float scale = 1;
            float x = (screenWidth / 2) - (previews[currentExample].width / 2 * scale);
            float y = (screenHeight / 2) - (previews[currentExample].height / 2 * scale) - 20;
            DrawTextureEx(previews[currentExample], new Vector2(x, y), 0, scale, White);

            DrawText("Use Left and Right arrow keys to change Example", 10, 10, 20, Black);
            DrawText("Use Enter to open Example", 10, 30, 20, Black);

            Font font = GetFontDefault();
            DrawTextPro(font, Examples[currentExample], new Vector2(screenWidth / 2, screenHeight - 40), new Vector2(MeasureText(Examples[currentExample], 32) / 2f, 32), 0, 32, 4, Color.Black);

            EndDrawing();

        }
        CloseWindow();
        if (pickedExampleToRun)
        {
            return currentExample;
        }
        return -1;
    }
}

/* How i made Icon.raw
    Color[] colors = LoadImageColors(LoadImage("Icon.png"));

    List<byte> img = new();

    for (int i = 0; i < colors.Length; i++)
    {
        img.Add(colors[i].r);
        img.Add(colors[i].g);
        img.Add(colors[i].b);
        img.Add(colors[i].a);
    }

    File.WriteAllBytes("Icon.raw", img.ToArray());
*/
