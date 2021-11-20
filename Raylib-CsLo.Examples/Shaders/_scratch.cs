//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
//// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
//// [!!] This file is licensed to you under the LGPL-2.1.
//// [!!] See the LICENSE file in the project root for more info. 
//// [!!] ------------------------------------------------- 
//// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]


//namespace Raylib_CsLo.Examples.Shaders;

///*******************************************************************************************
//*
//*   raylib [shaders] example - Apply a shader to a 3d model
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//*
//*   This example has been created using raylib 1.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//    #define GLSL_VERSION            100
//#endif

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	SetConfigFlags(FLAG_MSAA_4X_HINT);      // Enable Multi Sampling Anti Aliasing 4x (if available)

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - model shader");

//	// Define the camera to look into our 3d world
//	Camera camera = new();
//	camera.position = new Vector3(4.0f, 4.0f, 4.0f);
//	camera.target = new Vector3(0.0f, 1.0f, -1.0f);
//	camera.up = new Vector3(0.0f, 1.0f, 0.0f);
//	camera.fovy = 45.0f;
//	camera.projection_ = CAMERA_PERSPECTIVE;

//	Model model = LoadModel("resources/models/watermill.obj");                   // Load OBJ model
//	Texture2D texture = LoadTexture("resources/models/watermill_diffuse.png");   // Load model texture

//	// Load shader for model
//	// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
//	Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/grayscale.fs", GLSL_VERSION));

//	model.materials[0].shader = shader;                     // Set shader effect to 3d model
//	model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture; // Bind texture to model

//	Vector3 position = new(0.0f, 0.0f, 0.0f);    // Set model position

//	SetCameraMode(camera, CAMERA_FREE);         // Set an orbital camera mode

//	SetTargetFPS(60);                           // Set our game to run at 60 frames-per-second
//												//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())                // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);                  // Update camera
//												//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawModel(model, position, 0.2f, WHITE);   // Draw 3d model with texture

//		DrawGrid(10, 1.0f);     // Draw a grid

//		EndMode3D();

//		DrawText("(c) Watermill 3D model by Alberto Cano", screenWidth - 210, screenHeight - 20, 10, GRAY);

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadShader(shader);       // Unload shader
//	UnloadTexture(texture);     // Unload texture
//	UnloadModel(model);         // Unload model

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}
///*******************************************************************************************
//*
//*   raylib [shaders] example - Multiple sample2D with default batch system
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//*
//*   This example has been created using raylib 3.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2020 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib - multiple sample2D");

//	Image imRed = GenImageColor(800, 450, (Color){ 255, 0, 0, 255 ));
//Texture texRed = LoadTextureFromImage(imRed);
//UnloadImage(imRed);

//Image imBlue = GenImageColor(800, 450, (Color){ 0, 0, 255, 255 ));
//Texture texBlue = LoadTextureFromImage(imBlue);
//UnloadImage(imBlue);

//Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/color_mix.fs", GLSL_VERSION));

//// Get an additional sampler2D location to be enabled on drawing
//int texBlueLoc = GetShaderLocation(shader, "texture1");

//// Get shader uniform for divider
//int dividerLoc = GetShaderLocation(shader, "divider");
//float dividerValue = 0.5f;

//SetTargetFPS(60);                           // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------

//// Main game loop
//while (!WindowShouldClose())                // Detect window close button or ESC key
//{
//	// Update
//	//----------------------------------------------------------------------------------
//	if (IsKeyDown(KEY_RIGHT)) dividerValue += 0.01f;
//	else if (IsKeyDown(KEY_LEFT)) dividerValue -= 0.01f;

//	if (dividerValue < 0.0f) dividerValue = 0.0f;
//	else if (dividerValue > 1.0f) dividerValue = 1.0f;

//	SetShaderValue(shader, dividerLoc, &dividerValue, SHADER_UNIFORM_FLOAT);
//	//----------------------------------------------------------------------------------

//	// Draw
//	//----------------------------------------------------------------------------------
//	BeginDrawing();

//	ClearBackground(RAYWHITE);

//	BeginShaderMode(shader);

//	// WARNING: Additional samplers are enabled for all draw calls in the batch,
//	// EndShaderMode() forces batch drawing and consequently resets active textures
//	// to let other sampler2D to be activated on consequent drawings (if required)
//	SetShaderValueTexture(shader, texBlueLoc, texBlue);

//	// We are drawing texRed using default sampler2D texture0 but
//	// an additional texture units is enabled for texBlue (sampler2D texture1)
//	DrawTexture(texRed, 0, 0, WHITE);

//	EndShaderMode();

//	DrawText("Use KEY_LEFT/KEY_RIGHT to move texture mixing in shader!", 80, GetScreenHeight() - 40, 20, RAYWHITE);

//	EndDrawing();
//	//----------------------------------------------------------------------------------
//}

//// De-Initialization
////--------------------------------------------------------------------------------------
//UnloadShader(shader);       // Unload shader
//UnloadTexture(texRed);      // Unload texture
//UnloadTexture(texBlue);     // Unload texture

//CloseWindow();              // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//return 0;
//}

///*******************************************************************************************
//*
//*   raylib [shaders] example - Color palette switch
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//*
//*   This example has been created using raylib 2.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Marco Lizza (@MarcoLizza) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Marco Lizza (@MarcoLizza) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//    #define GLSL_VERSION            100
//#endif

//#define MAX_PALETTES            3
//#define COLORS_PER_PALETTE      8
//#define VALUES_PER_COLOR        3

//static const int palettes[MAX_PALETTES][COLORS_PER_PALETTE*VALUES_PER_COLOR] = new(
//	{   // 3-BIT RGB
//	0,
//	0,
//	0,
//	255,
//	0,
//	0,
//	0,
//	255,
//	0,
//	0,
//	0,
//	255,
//	0,
//	255,
//	255,
//	255,
//	0,
//	255,
//	255,
//	255,
//	0,
//	255,
//	255,
//	255,
//),
//	{   // AMMO-8 (GameBoy-like)
//		4,
//		12,
//		6,
//		17,
//		35,
//		24,
//		30,
//		58,
//		41,
//		48,
//		93,
//		66,
//		77,
//		128,
//		97,
//		137,
//		162,
//		87,
//		190,
//		220,
//		127,
//		238,
//		255,
//		204,
//    ),

//	{   // RKBV (2-strip film)
//		21,
//		25,
//		26,
//		138,
//		76,
//		88,
//		217,
//		98,
//		117,
//		230,
//		184,
//		193,
//		69,
//		107,
//		115,
//		75,
//		151,
//		166,
//		165,
//		189,
//		194,
//		255,
//		245,
//		247,
//	}
//};

//static string paletteText[] = new(
//	"3-BIT RGB",
//	"AMMO-8 (GameBoy-like)",
//	"RKBV (2-strip film)"
//};

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - color palette switch");

//	// Load shader to be used on some parts drawing
//	// NOTE 1: Using GLSL 330 shader version, on OpenGL ES 2.0 use GLSL 100 shader version
//	// NOTE 2: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
//	Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/palette_switch.fs", GLSL_VERSION));

//	// Get variable (uniform) location on the shader to connect with the program
//	// NOTE: If uniform variable could not be found in the shader, function returns -1
//	int paletteLoc = GetShaderLocation(shader, "palette");

//	int currentPalette = 0;
//	int lineHeight = screenHeight / COLORS_PER_PALETTE;

//	SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())            // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		if (IsKeyPressed(KEY_RIGHT)) currentPalette++;
//		else if (IsKeyPressed(KEY_LEFT)) currentPalette--;

//		if (currentPalette >= MAX_PALETTES) currentPalette = 0;
//		else if (currentPalette < 0) currentPalette = MAX_PALETTES - 1;

//		// Send new value to the shader to be used on drawing.
//		// NOTE: We are sending RGB triplets w/o the alpha channel
//		SetShaderValueV(shader, paletteLoc, palettes[currentPalette], SHADER_UNIFORM_IVEC3, COLORS_PER_PALETTE);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginShaderMode(shader);

//		for (int i = 0; i < COLORS_PER_PALETTE; i++)
//		{
//			// Draw horizontal screen-wide rectangles with increasing "palette index"
//			// The used palette index is encoded in the RGB components of the pixel
//			DrawRectangle(0, lineHeight * i, GetScreenWidth(), lineHeight, (Color){ i, i, i, 255 ));
//                }

//            EndShaderMode();

//DrawText("< >", 10, 10, 30, DARKBLUE);
//DrawText("CURRENT PALETTE:", 60, 15, 20, RAYWHITE);
//DrawText(paletteText[currentPalette], 300, 15, 20, RED);

//DrawFPS(700, 15);

//EndDrawing();
//        //----------------------------------------------------------------------------------
//    }

//    // De-Initialization
//    //--------------------------------------------------------------------------------------
//    UnloadShader(shader);       // Unload shader

//CloseWindow();              // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//return 0;
//}

///*******************************************************************************************
//*
//*   raylib [shaders] example - Apply a postprocessing shader to a scene
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//*
//*   This example has been created using raylib 1.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//    #define GLSL_VERSION            100
//#endif

//#define MAX_POSTPRO_SHADERS         12

//typedef enum {
//	FX_GRAYSCALE = 0,
//	FX_POSTERIZATION,
//	FX_DREAM_VISION,
//	FX_PIXELIZER,
//	FX_CROSS_HATCHING,
//	FX_CROSS_STITCHING,
//	FX_PREDATOR_VIEW,
//	FX_SCANLINES,
//	FX_FISHEYE,
//	FX_SOBEL,
//	FX_BLOOM,
//	FX_BLUR,
//	//FX_FXAA
//}
//PostproShader;

//static string postproShaderText[] = new(
//	"GRAYSCALE",
//	"POSTERIZATION",
//	"DREAM_VISION",
//	"PIXELIZER",
//	"CROSS_HATCHING",
//	"CROSS_STITCHING",
//	"PREDATOR_VIEW",
//	"SCANLINES",
//	"FISHEYE",
//	"SOBEL",
//	"BLOOM",
//	"BLUR",
//    //"FXAA"
//};

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	SetConfigFlags(FLAG_MSAA_4X_HINT);      // Enable Multi Sampling Anti Aliasing 4x (if available)

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - postprocessing shader");

//	// Define the camera to look into our 3d world
//	Camera camera = new( { 2.0f, 3.0f, 2.0f ), {
//	0.0f, 1.0f, 0.0f ), {
//		0.0f, 1.0f, 0.0f ), 45.0f, 0 );

//		Model model = LoadModel("resources/models/church.obj");                 // Load OBJ model
//		Texture2D texture = LoadTexture("resources/models/church_diffuse.png"); // Load model texture (diffuse map)
//		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;                     // Set model diffuse texture

//		Vector3 position = new(0.0f, 0.0f, 0.0f);                             // Set model position

//		// Load all postpro shaders
//		// NOTE 1: All postpro shader use the base vertex shader (DEFAULT_VERTEX_SHADER)
//		// NOTE 2: We load the correct shader depending on GLSL version
//		Shader shaders[MAX_POSTPRO_SHADERS] = new(0);

//		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
//		shaders[FX_GRAYSCALE] = LoadShader(null, TextFormat("resources/shaders/glsl%i/grayscale.fs", GLSL_VERSION));
//		shaders[FX_POSTERIZATION] = LoadShader(null, TextFormat("resources/shaders/glsl%i/posterization.fs", GLSL_VERSION));
//		shaders[FX_DREAM_VISION] = LoadShader(null, TextFormat("resources/shaders/glsl%i/dream_vision.fs", GLSL_VERSION));
//		shaders[FX_PIXELIZER] = LoadShader(null, TextFormat("resources/shaders/glsl%i/pixelizer.fs", GLSL_VERSION));
//		shaders[FX_CROSS_HATCHING] = LoadShader(null, TextFormat("resources/shaders/glsl%i/cross_hatching.fs", GLSL_VERSION));
//		shaders[FX_CROSS_STITCHING] = LoadShader(null, TextFormat("resources/shaders/glsl%i/cross_stitching.fs", GLSL_VERSION));
//		shaders[FX_PREDATOR_VIEW] = LoadShader(null, TextFormat("resources/shaders/glsl%i/predator.fs", GLSL_VERSION));
//		shaders[FX_SCANLINES] = LoadShader(null, TextFormat("resources/shaders/glsl%i/scanlines.fs", GLSL_VERSION));
//		shaders[FX_FISHEYE] = LoadShader(null, TextFormat("resources/shaders/glsl%i/fisheye.fs", GLSL_VERSION));
//		shaders[FX_SOBEL] = LoadShader(null, TextFormat("resources/shaders/glsl%i/sobel.fs", GLSL_VERSION));
//		shaders[FX_BLOOM] = LoadShader(null, TextFormat("resources/shaders/glsl%i/bloom.fs", GLSL_VERSION));
//		shaders[FX_BLUR] = LoadShader(null, TextFormat("resources/shaders/glsl%i/blur.fs", GLSL_VERSION));

//		int currentShader = FX_GRAYSCALE;

//		// Create a RenderTexture2D to be used for render to texture
//		RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

//		// Setup orbital camera
//		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

//		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//												//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())            // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			UpdateCamera(&camera);              // Update camera

//			if (IsKeyPressed(KEY_RIGHT)) currentShader++;
//			else if (IsKeyPressed(KEY_LEFT)) currentShader--;

//			if (currentShader >= MAX_POSTPRO_SHADERS) currentShader = 0;
//			else if (currentShader < 0) currentShader = MAX_POSTPRO_SHADERS - 1;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginTextureMode(target);       // Enable drawing to texture
//			ClearBackground(RAYWHITE);  // Clear texture background

//			BeginMode3D(camera);        // Begin 3d mode drawing
//			DrawModel(model, position, 0.1f, WHITE);   // Draw 3d model with texture
//			DrawGrid(10, 1.0f);     // Draw a grid
//			EndMode3D();                // End 3d mode drawing, returns to orthographic 2d mode
//			EndTextureMode();               // End drawing to texture (now we have a texture available for next passes)

//			BeginDrawing();
//			ClearBackground(RAYWHITE);  // Clear screen background

//			// Render generated texture using selected postprocessing shader
//			BeginShaderMode(shaders[currentShader]);
//			// NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
//			DrawTextureRec(target.texture, new Rectangle(0, 0, (float)target.texture.width, (float)-target.texture.height), new Vector2(
//				0, 0), WHITE);
//			EndShaderMode();

//			// Draw 2d shapes and text over drawn texture
//			DrawRectangle(0, 9, 580, 30, Fade(LIGHTGRAY, 0.7f));

//			DrawText("(c) Church 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);
//			DrawText("CURRENT POSTPRO SHADER:", 10, 15, 20, BLACK);
//			DrawText(postproShaderText[currentShader], 330, 15, 20, RED);
//			DrawText("< >", 540, 10, 30, DARKBLUE);
//			DrawFPS(700, 15);
//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		// Unload all postpro shaders
//		for (int i = 0; i < MAX_POSTPRO_SHADERS; i++) UnloadShader(shaders[i]);

//		UnloadTexture(texture);         // Unload texture
//		UnloadModel(model);             // Unload model
//		UnloadRenderTexture(target);    // Unload render texture

//		CloseWindow();                  // Close window and OpenGL context
//										//--------------------------------------------------------------------------------------

//		return 0;
//	}

//	/*******************************************************************************************
//	*
//	*   raylib [shaders] example - Raymarching shapes generation
//	*
//	*   NOTE: This example requires raylib OpenGL 3.3 for shaders support and only #version 330
//	*         is currently supported. OpenGL ES 2.0 platforms are not supported at the moment.
//	*
//	*   This example has been created using raylib 2.0 (www.raylib.com)
//	*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//	*
//	*   Copyright (c) 2018 Ramon Santamaria (@raysan5)
//	*
//	********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB -> Not supported at this moment
//#define GLSL_VERSION            100
//#endif

//	int main(void)
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		int screenWidth = 800;
//		int screenHeight = 450;

//		SetConfigFlags(FLAG_WINDOW_RESIZABLE);
//		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - raymarching shapes");

//		Camera camera = new();
//		camera.position = new Vector3(2.5f, 2.5f, 3.0f);    // Camera position
//		camera.target = new Vector3(0.0f, 0.0f, 0.7f);      // Camera looking at point
//		camera.up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
//		camera.fovy = 65.0f;                                // Camera field-of-view Y

//		SetCameraMode(camera, CAMERA_FREE);                 // Set camera mode

//		// Load raymarching shader
//		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
//		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/raymarching.fs", GLSL_VERSION));

//		// Get shader locations for required uniforms
//		int viewEyeLoc = GetShaderLocation(shader, "viewEye");
//		int viewCenterLoc = GetShaderLocation(shader, "viewCenter");
//		int runTimeLoc = GetShaderLocation(shader, "runTime");
//		int resolutionLoc = GetShaderLocation(shader, "resolution");

//		Vector2 resolution = new((float)screenWidth, (float)screenHeight);
//		SetShaderValue(shader, resolutionLoc, resolution, SHADER_UNIFORM_VEC2);

//		float runTime = 0.0f;

//		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//												//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())            // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			UpdateCamera(&camera);              // Update camera

//			Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
//			Vector3 cameraTarget = new(camera.target.X, camera.target.Y, camera.target.Z);

//			float deltaTime = GetFrameTime();
//			runTime += deltaTime;

//			// Set shader required uniform values
//			SetShaderValue(shader, viewEyeLoc, cameraPos, SHADER_UNIFORM_VEC3);
//			SetShaderValue(shader, viewCenterLoc, cameraTarget, SHADER_UNIFORM_VEC3);
//			SetShaderValue(shader, runTimeLoc, &runTime, SHADER_UNIFORM_FLOAT);

//			// Check if screen is resized
//			if (IsWindowResized())
//			{
//				screenWidth = GetScreenWidth();
//				screenHeight = GetScreenHeight();
//				Vector2 resolution = new((float)screenWidth, (float)screenHeight);
//				SetShaderValue(shader, resolutionLoc, resolution, SHADER_UNIFORM_VEC2);
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			// We only draw a white full-screen rectangle,
//			// frame is generated in shader using raymarching
//			BeginShaderMode(shader);
//			DrawRectangle(0, 0, screenWidth, screenHeight, WHITE);
//			EndShaderMode();

//			DrawText("(c) Raymarching shader by Iñigo Quilez. MIT License.", screenWidth - 280, screenHeight - 20, 10, BLACK);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadShader(shader);           // Unload shader

//		CloseWindow();                  // Close window and OpenGL context
//										//--------------------------------------------------------------------------------------

//		return 0;
//	}

//	/*******************************************************************************************
//	*
//	*   raylib [shaders] example - Apply a shader to some shape or texture
//	*
//	*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//	*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//	*
//	*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//	*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//	*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//	*
//	*   This example has been created using raylib 1.7 (www.raylib.com)
//	*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//	*
//	*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//	*
//	********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//	int main(void)
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - shapes and texture shaders");

//		Texture2D fudesumi = LoadTexture("resources/fudesumi.png");

//		// Load shader to be used on some parts drawing
//		// NOTE 1: Using GLSL 330 shader version, on OpenGL ES 2.0 use GLSL 100 shader version
//		// NOTE 2: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
//		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/grayscale.fs", GLSL_VERSION));

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			// TODO: Update your variables here
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			// Start drawing with default shader

//			DrawText("USING DEFAULT SHADER", 20, 40, 10, RED);

//			DrawCircle(80, 120, 35, DARKBLUE);
//			DrawCircleGradient(80, 220, 60, GREEN, SKYBLUE);
//			DrawCircleLines(80, 340, 80, DARKBLUE);


//			// Activate our custom shader to be applied on next shapes/textures drawings
//			BeginShaderMode(shader);

//			DrawText("USING CUSTOM SHADER", 190, 40, 10, RED);

//			DrawRectangle(250 - 60, 90, 120, 60, RED);
//			DrawRectangleGradientH(250 - 90, 170, 180, 130, MAROON, GOLD);
//			DrawRectangleLines(250 - 40, 320, 80, 60, ORANGE);

//			// Activate our default shader for next drawings
//			EndShaderMode();

//			DrawText("USING DEFAULT SHADER", 370, 40, 10, RED);

//			DrawTriangle(new Vector2(430, 80),
//					 new Vector2(430 - 60, 150),
//					 new Vector2(430 + 60, 150), VIOLET);

//			DrawTriangleLines(new Vector2(430, 160),
//								  new Vector2(430 - 20, 230),
//								  new Vector2(
//				430 + 20, 230), DARKBLUE);

//			DrawPoly(new Vector2(
//				430, 320), 6, 80, 0, BROWN);

//			// Activate our custom shader to be applied on next shapes/textures drawings
//			BeginShaderMode(shader);

//			DrawTexture(fudesumi, 500, -30, WHITE);    // Using custom shader

//			// Activate our default shader for next drawings
//			EndShaderMode();

//			DrawText("(c) Fudesumi sprite by Eiden Marsal", 380, screenHeight - 20, 10, GRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadShader(shader);       // Unload shader
//		UnloadTexture(fudesumi);    // Unload texture

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}
//	/*******************************************************************************************
//	*
//	*   raylib [shaders] example - Simple shader mask
//	*
//	*   This example has been created using raylib 2.5 (www.raylib.com)
//	*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//	*
//	*   Example contributed by Chris Camacho (@chriscamacho) and reviewed by Ramon Santamaria (@raysan5)
//	*
//	*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
//	*
//	********************************************************************************************
//	*
//	*   After a model is loaded it has a default material, this material can be
//	*   modified in place rather than creating one from scratch...
//	*   While all of the maps have particular names, they can be used for any purpose
//	*   except for three maps that are applied as cubic maps (see below)
//	*
//	********************************************************************************************/

//# include "raylib.h"
//# include "raymath.h"

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//	int main(void)
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib - simple shader mask");

//		// Define the camera to look into our 3d world
//		Camera camera = new();
//		camera.position = new Vector3(0.0f, 1.0f, 2.0f);
//		camera.target = new Vector3(0.0f, 0.0f, 0.0f);
//		camera.up = new Vector3(0.0f, 1.0f, 0.0f);
//		camera.fovy = 45.0f;
//		camera.projection_ = CAMERA_PERSPECTIVE;

//		// Define our three models to show the shader on
//		Mesh torus = GenMeshTorus(0.3f, 1, 16, 32);
//		Model model1 = LoadModelFromMesh(torus);

//		Mesh cube = GenMeshCube(0.8f, 0.8f, 0.8f);
//		Model model2 = LoadModelFromMesh(cube);

//		// Generate model to be shaded just to see the gaps in the other two
//		Mesh sphere = GenMeshSphere(1, 16, 16);
//		Model model3 = LoadModelFromMesh(sphere);

//		// Load the shader
//		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/mask.fs", GLSL_VERSION));

//		// Load and apply the diffuse texture (colour map)
//		Texture texDiffuse = LoadTexture("resources/plasma.png");
//		model1.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texDiffuse;
//		model2.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texDiffuse;

//		// Using MATERIAL_MAP_EMISSION as a spare slot to use for 2nd texture
//		// NOTE: Don't use MATERIAL_MAP_IRRADIANCE, MATERIAL_MAP_PREFILTER or  MATERIAL_MAP_CUBEMAP as they are bound as cube maps
//		Texture texMask = LoadTexture("resources/mask.png");
//		model1.materials[0].maps[(int)MATERIAL_MAP_EMISSION].texture = texMask;
//		model2.materials[0].maps[(int)MATERIAL_MAP_EMISSION].texture = texMask;
//		shader.locs[(int)SHADER_LOC_MAP_EMISSION] = GetShaderLocation(shader, "mask");

//		// Frame is incremented each frame to animate the shader
//		int shaderFrame = GetShaderLocation(shader, "frame");

//		// Apply the shader to the two models
//		model1.materials[0].shader = shader;
//		model2.materials[0].shader = shader;

//		int framesCounter = 0;
//		Vector3 rotation = new(0);       // Model rotation angles

//		SetTargetFPS(60);               // Set  to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			framesCounter++;
//			rotation.X += 0.01f;
//			rotation.Y += 0.005f;
//			rotation.Z -= 0.0025f;

//			// Send frames counter to shader for animation
//			SetShaderValue(shader, shaderFrame, &framesCounter, SHADER_UNIFORM_INT);

//			// Rotate one of the models
//			model1.transform = MatrixRotateXYZ(rotation);

//			UpdateCamera(&camera);
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(DARKBLUE);

//			BeginMode3D(camera);

//			DrawModel(model1, new Vector3(0.5, 0, 0), 1, WHITE);
//			DrawModelEx(model2, new Vector3(-.5, 0, 0), new Vector3(1, 1, 0), 50, new Vector3(1, 1, 1), WHITE);
//			DrawModel(model3, new Vector3(0, 0, -1.5), 1, WHITE);
//			DrawGrid(10, 1.0f);        // Draw a grid

//			EndMode3D();

//			DrawRectangle(16, 698, MeasureText(TextFormat("Frame: %i", framesCounter), 20) + 8, 42, BLUE);
//			DrawText(TextFormat("Frame: %i", framesCounter), 20, 700, 20, WHITE);

//			DrawFPS(10, 10);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadModel(model1);
//		UnloadModel(model2);
//		UnloadModel(model3);

//		UnloadTexture(texDiffuse);  // Unload default diffuse texture
//		UnloadTexture(texMask);     // Unload texture mask

//		UnloadShader(shader);       // Unload shader

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}

//	/*******************************************************************************************
//	*
//	*   raylib [shaders] example - Simple shader mask
//	*
//	*   This example has been created using raylib 2.5 (www.raylib.com)
//	*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//	*
//	*   Example contributed by Chris Camacho (@chriscamacho -  http://bedroomcoders.co.uk/)
//	*   and reviewed by Ramon Santamaria (@raysan5)
//	*
//	*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
//	*
//	********************************************************************************************
//	*
//	*   The shader makes alpha holes in the forground to give the apearance of a top
//	*   down look at a spotlight casting a pool of light...
//	*
//	*   The right hand side of the screen there is just enough light to see whats
//	*   going on without the spot light, great for a stealth type game where you
//	*   have to avoid the spotlights.
//	*
//	*   The left hand side of the screen is in pitch dark except for where the spotlights are.
//	*
//	*   Although this example doesn't scale like the letterbox example, you could integrate
//	*   the two techniques, but by scaling the actual colour of the render texture rather
//	*   than using alpha as a mask.
//	*
//	********************************************************************************************/

//# include "raylib.h"
//# include "raymath.h"

//# include <stddef.h>
//# include <stdint.h>

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//#define MAX_SPOTS         3        // NOTE: It must be the same as define in shader
//#define MAX_STARS       400

//	// Spot data
//	typedef struct {

//	Vector2 pos;
//Vector2 vel;
//float inner;
//float radius;

//// Shader locations
//unsigned int posLoc;
//unsigned int innerLoc;
//unsigned int radiusLoc;
//} Spot;

//// Stars in the star field have a position and velocity
//typedef struct Star
//{
//	Vector2 pos;
//	Vector2 vel;
//}
//Star;

//void UpdateStar(Star* s);
//void ResetStar(Star* s);

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib - shader spotlight");
//	HideCursor();

//	Texture texRay = LoadTexture("resources/raysan.png");

//	Star stars[MAX_STARS] = new(0);

//	for (int n = 0; n < MAX_STARS; n++) ResetStar(&stars[n]);

//	// Progress all the stars on, so they don't all start in the centre
//	for (int m = 0; m < screenWidth / 2.0; m++)
//	{
//		for (int n = 0; n < MAX_STARS; n++) UpdateStar(&stars[n]);
//	}

//	int frameCounter = 0;

//	// Use default vert shader
//	Shader shdrSpot = LoadShader(null, TextFormat("resources/shaders/glsl%i/spotlight.fs", GLSL_VERSION));

//	// Get the locations of spots in the shader
//	Spot spots[MAX_SPOTS];

//	for (int i = 0; i < MAX_SPOTS; i++)
//	{
//		char posName[32] = "spots[x].pos\0";
//		char innerName[32] = "spots[x].inner\0";
//		char radiusName[32] = "spots[x].radius\0";

//		posName[6] = '0' + i;
//		innerName[6] = '0' + i;
//		radiusName[6] = '0' + i;

//		spots[i].posLoc = GetShaderLocation(shdrSpot, posName);
//		spots[i].innerLoc = GetShaderLocation(shdrSpot, innerName);
//		spots[i].radiusLoc = GetShaderLocation(shdrSpot, radiusName);

//	}

//	// Tell the shader how wide the screen is so we can have
//	// a pitch black half and a dimly lit half.
//	unsigned int wLoc = GetShaderLocation(shdrSpot, "screenWidth");
//	float sw = (float)GetScreenWidth();
//	SetShaderValue(shdrSpot, wLoc, &sw, SHADER_UNIFORM_FLOAT);

//	// Randomize the locations and velocities of the spotlights
//	// and initialize the shader locations
//	for (int i = 0; i < MAX_SPOTS; i++)
//	{
//		spots[i].pos.X = (float)GetRandomValue(64, screenWidth - 64);
//		spots[i].pos.Y = (float)GetRandomValue(64, screenHeight - 64);
//		spots[i].vel = new Vector2(0, 0);

//		while ((fabs(spots[i].vel.X) + fabs(spots[i].vel.Y)) < 2)
//		{
//			spots[i].vel.X = GetRandomValue(-400, 40) / 10.0f;
//			spots[i].vel.Y = GetRandomValue(-400, 40) / 10.0f;
//		}

//		spots[i].inner = 28.0f * (i + 1);
//		spots[i].radius = 48.0f * (i + 1);

//		SetShaderValue(shdrSpot, spots[i].posLoc, &spots[i].pos.X, SHADER_UNIFORM_VEC2);
//		SetShaderValue(shdrSpot, spots[i].innerLoc, &spots[i].inner, SHADER_UNIFORM_FLOAT);
//		SetShaderValue(shdrSpot, spots[i].radiusLoc, &spots[i].radius, SHADER_UNIFORM_FLOAT);
//	}

//	SetTargetFPS(60);               // Set  to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		frameCounter++;

//		// Move the stars, resetting them if the go offscreen
//		for (int n = 0; n < MAX_STARS; n++) UpdateStar(&stars[n]);

//		// Update the spots, send them to the shader
//		for (int i = 0; i < MAX_SPOTS; i++)
//		{
//			if (i == 0)
//			{
//				Vector2 mp = GetMousePosition();
//				spots[i].pos.X = mp.X;
//				spots[i].pos.Y = screenHeight - mp.Y;
//			}
//			else
//			{
//				spots[i].pos.X += spots[i].vel.X;
//				spots[i].pos.Y += spots[i].vel.Y;

//				if (spots[i].pos.X < 64) spots[i].vel.X = -spots[i].vel.X;
//				if (spots[i].pos.X > (screenWidth - 64)) spots[i].vel.X = -spots[i].vel.X;
//				if (spots[i].pos.Y < 64) spots[i].vel.Y = -spots[i].vel.Y;
//				if (spots[i].pos.Y > (screenHeight - 64)) spots[i].vel.Y = -spots[i].vel.Y;
//			}

//			SetShaderValue(shdrSpot, spots[i].posLoc, &spots[i].pos.X, SHADER_UNIFORM_VEC2);
//		}

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(DARKBLUE);

//		// Draw stars and bobs
//		for (int n = 0; n < MAX_STARS; n++)
//		{
//			// Single pixel is just too small these days!
//			DrawRectangle((int)stars[n].pos.X, (int)stars[n].pos.Y, 2, 2, WHITE);
//		}

//		for (int i = 0; i < 16; i++)
//		{
//			DrawTexture(texRay,
//				(int)((screenWidth / 2.0f) + cos((frameCounter + i * 8) / 51.45f) * (screenWidth / 2.2f) - 32),
//				(int)((screenHeight / 2.0f) + sin((frameCounter + i * 8) / 17.87f) * (screenHeight / 4.2f)), WHITE);
//		}

//		// Draw spot lights
//		BeginShaderMode(shdrSpot);
//		// Instead of a blank rectangle you could render here
//		// a render texture of the full screen used to do screen
//		// scaling (slight adjustment to shader would be required
//		// to actually pay attention to the colour!)
//		DrawRectangle(0, 0, screenWidth, screenHeight, WHITE);
//		EndShaderMode();

//		DrawFPS(10, 10);

//		DrawText("Move the mouse!", 10, 30, 20, GREEN);
//		DrawText("Pitch Black", (int)(screenWidth * 0.2f), screenHeight / 2, 20, GREEN);
//		DrawText("Dark", (int)(screenWidth * .66f), screenHeight / 2, 20, GREEN);


//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(texRay);
//	UnloadShader(shdrSpot);

//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//	return 0;
//}


//void ResetStar(Star* s)
//{
//	s->pos = new Vector2(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);

//	do
//	{
//		s->vel.X = (float)GetRandomValue(-1000, 1000) / 100.0f;
//		s->vel.Y = (float)GetRandomValue(-1000, 1000) / 100.0f;

//	} while (!(fabs(s->vel.X) + (fabs(s->vel.Y) > 1)));

//	s->pos = Vector2Add(s->pos, Vector2Multiply(s->vel, new Vector2(8.0f, 8.0f )));
//}

//void UpdateStar(Star* s)
//{
//	s->pos = Vector2Add(s->pos, s->vel);

//	if ((s->pos.X < 0) || (s->pos.X > GetScreenWidth()) ||
//		(s->pos.Y < 0) || (s->pos.Y > GetScreenHeight()))
//	{
//		ResetStar(s);
//	}
//}


///*******************************************************************************************
//*
//*   raylib [textures] example - Texture drawing
//*
//*   This example illustrates how to draw on a blank texture using a shader
//*
//*   This example has been created using raylib 2.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Michał Ciesielski and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Michał Ciesielski and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - texture drawing");

//	Image imBlank = GenImageColor(1024, 1024, BLANK);
//	Texture2D texture = LoadTextureFromImage(imBlank);  // Load blank texture to fill on shader
//	UnloadImage(imBlank);

//	// NOTE: Using GLSL 330 shader version, on OpenGL ES 2.0 use GLSL 100 shader version
//	Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/cubes_panning.fs", GLSL_VERSION));

//	float time = 0.0f;
//	int timeLoc = GetShaderLocation(shader, "uTime");
//	SetShaderValue(shader, timeLoc, &time, SHADER_UNIFORM_FLOAT);

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									// -------------------------------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		time = (float)GetTime();
//		SetShaderValue(shader, timeLoc, &time, SHADER_UNIFORM_FLOAT);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginShaderMode(shader);    // Enable our custom shader for next shapes/textures drawings
//		DrawTexture(texture, 0, 0, WHITE);  // Drawing BLANK texture, all magic happens on shader
//		EndShaderMode();            // Disable our custom shader, return to default shader

//		DrawText("BACKGROUND is PAINTED and ANIMATED on SHADER!", 10, 10, 20, MAROON);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadShader(shader);

//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//	return 0;
//}

///*******************************************************************************************
//*
//*   raylib [shaders] example - Apply an shdrOutline to a texture
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   This example has been created using raylib 3.8 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Samuel Skiff (@GoldenThumbs) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2021 Samuel SKiff (@GoldenThumbs) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - Apply an outline to a texture");

//	Texture2D texture = LoadTexture("resources/fudesumi.png");

//	Shader shdrOutline = LoadShader(null, TextFormat("resources/shaders/glsl%i/outline.fs", GLSL_VERSION));

//	float outlineSize = 2.0f;
//	float outlineColor[4] = new(1.0f, 0.0f, 0.0f, 1.0f);     // Normalized RED color 
//	Vector2 textureSize = new((float)texture.width, (float)texture.height);

//	// Get shader locations
//	int outlineSizeLoc = GetShaderLocation(shdrOutline, "outlineSize");
//	int outlineColorLoc = GetShaderLocation(shdrOutline, "outlineColor");
//	int textureSizeLoc = GetShaderLocation(shdrOutline, "textureSize");

//	// Set shader values (they can be changed later)
//	SetShaderValue(shdrOutline, outlineSizeLoc, &outlineSize, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shdrOutline, outlineColorLoc, outlineColor, SHADER_UNIFORM_VEC4);
//	SetShaderValue(shdrOutline, textureSizeLoc, textureSize, SHADER_UNIFORM_VEC2);

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		outlineSize += GetMouseWheelMove();
//		if (outlineSize < 1.0f) outlineSize = 1.0f;

//		SetShaderValue(shdrOutline, outlineSizeLoc, &outlineSize, SHADER_UNIFORM_FLOAT);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginShaderMode(shdrOutline);

//		DrawTexture(texture, GetScreenWidth() / 2 - texture.width / 2, -30, WHITE);

//		EndShaderMode();

//		DrawText("Shader-based\ntexture\noutline", 10, 10, 20, GRAY);

//		DrawText(TextFormat("Outline size: %i px", (int)outlineSize), 10, 120, 20, MAROON);

//		DrawFPS(710, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(texture);
//	UnloadShader(shdrOutline);

//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//	return 0;
//}

///*******************************************************************************************
//*
//*   raylib [shaders] example - Texture Waves
//*
//*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
//*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
//*
//*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3), to test this example
//*         on OpenGL ES 2.0 platforms (Android, Raspberry Pi, HTML5), use #version 100 shaders
//*         raylib comes with shaders ready for both versions, check raylib/shaders install folder
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Anata (@anatagawa) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Anata (@anatagawa) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#if defined(PLATFORM_DESKTOP)
//const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shaders] example - texture waves");

//	// Load texture texture to apply shaders
//	Texture2D texture = LoadTexture("resources/space.png");

//	// Load shader and setup location points and values
//	Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/wave.fs", GLSL_VERSION));

//	int secondsLoc = GetShaderLocation(shader, "secondes");
//	int freqXLoc = GetShaderLocation(shader, "freqX");
//	int freqYLoc = GetShaderLocation(shader, "freqY");
//	int ampXLoc = GetShaderLocation(shader, "ampX");
//	int ampYLoc = GetShaderLocation(shader, "ampY");
//	int speedXLoc = GetShaderLocation(shader, "speedX");
//	int speedYLoc = GetShaderLocation(shader, "speedY");

//	// Shader uniform values that can be updated at any time
//	float freqX = 25.0f;
//	float freqY = 25.0f;
//	float ampX = 5.0f;
//	float ampY = 5.0f;
//	float speedX = 8.0f;
//	float speedY = 8.0f;

//	Vector2 screenSize = new((float)GetScreenWidth(), (float)GetScreenHeight());
//	SetShaderValue(shader, GetShaderLocation(shader, "size"), &screenSize, SHADER_UNIFORM_VEC2);
//	SetShaderValue(shader, freqXLoc, &freqX, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shader, freqYLoc, &freqY, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shader, ampXLoc, &ampX, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shader, ampYLoc, &ampY, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shader, speedXLoc, &speedX, SHADER_UNIFORM_FLOAT);
//	SetShaderValue(shader, speedYLoc, &speedY, SHADER_UNIFORM_FLOAT);

//	float seconds = 0.0f;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									// -------------------------------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		seconds += GetFrameTime();

//		SetShaderValue(shader, secondsLoc, &seconds, SHADER_UNIFORM_FLOAT);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginShaderMode(shader);

//		DrawTexture(texture, 0, 0, WHITE);
//		DrawTexture(texture, texture.width, 0, WHITE);

//		EndShaderMode();

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadShader(shader);         // Unload shader
//	UnloadTexture(texture);       // Unload texture

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}















///**********************************************************************************************
//*
//*   raylib.lights - Some useful functions to deal with lights data
//*
//*   CONFIGURATION:
//*
//*   #define RLIGHTS_IMPLEMENTATION
//*       Generates the implementation of the library into the included file.
//*       If not defined, the library is in header only mode and can be included in other headers 
//*       or source files without problems. But only ONE file should hold the implementation.
//*
//*   LICENSE: zlib/libpng
//*
//*   Copyright (c) 2017-2020 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
//*
//*   This software is provided "as-is", without any express or implied warranty. In no event
//*   will the authors be held liable for any damages arising from the use of this software.
//*
//*   Permission is granted to anyone to use this software for any purpose, including commercial
//*   applications, and to alter it and redistribute it freely, subject to the following restrictions:
//*
//*     1. The origin of this software must not be misrepresented; you must not claim that you
//*     wrote the original software. If you use this software in a product, an acknowledgment
//*     in the product documentation would be appreciated but is not required.
//*
//*     2. Altered source versions must be plainly marked as such, and must not be misrepresented
//*     as being the original software.
//*
//*     3. This notice may not be removed or altered from any source distribution.
//*
//**********************************************************************************************/

//# ifndef RLIGHTS_H
//#define RLIGHTS_H

////----------------------------------------------------------------------------------
//// Defines and Macros
////----------------------------------------------------------------------------------
//#define MAX_LIGHTS            4         // Max dynamic lights supported by shader

////----------------------------------------------------------------------------------
//// Types and Structures Definition
////----------------------------------------------------------------------------------

//// Light data
//typedef struct {

//	int type;
//Vector3 position;
//Vector3 target;
//Color color;
//bool enabled;

//// Shader locations
//int enabledLoc;
//int typeLoc;
//int posLoc;
//int targetLoc;
//int colorLoc;
//} Light;

//// Light type
//typedef enum {
//	LIGHT_DIRECTIONAL,
//	LIGHT_POINT
//}
//LightType;

//# ifdef __cplusplus
//extern "C" {            // Prevents name mangling of functions
//#endif

//	//----------------------------------------------------------------------------------
//	// Module Functions Declaration
//	//----------------------------------------------------------------------------------
//	Light CreateLight(int type, Vector3 position, Vector3 target, Color color, Shader shader);   // Create a light and get shader locations
//	void UpdateLightValues(Shader shader, Light light);         // Send light properties to shader

//# ifdef __cplusplus
//}
//#endif

//#endif // RLIGHTS_H


///***********************************************************************************
//*
//*   RLIGHTS IMPLEMENTATION
//*
//************************************************************************************/

//#if defined(RLIGHTS_IMPLEMENTATION)

//# include "raylib.h"

////----------------------------------------------------------------------------------
//// Defines and Macros
////----------------------------------------------------------------------------------
//// ...

////----------------------------------------------------------------------------------
//// Types and Structures Definition
////----------------------------------------------------------------------------------
//// ...

////----------------------------------------------------------------------------------
//// Global Variables Definition
////----------------------------------------------------------------------------------
//static int lightsCount = 0;    // Current amount of created lights

////----------------------------------------------------------------------------------
//// Module specific Functions Declaration
////----------------------------------------------------------------------------------
//// ...

////----------------------------------------------------------------------------------
//// Module Functions Definition
////----------------------------------------------------------------------------------

//// Create a light and get shader locations
//Light CreateLight(int type, Vector3 position, Vector3 target, Color color, Shader shader)
//{
//    Light light =new( 0 );

//    if (lightsCount < MAX_LIGHTS)
//    {
//        light.enabled = true;
//        light.type = type;
//        light.position = position;
//        light.target = target;
//        light.color = color;

//        // TODO: Below code doesn't look good to me, 
//        // it assumes a specific shader naming and structure
//        // Probably this implementation could be improved
//        char enabledName[32] = "lights[x].enabled\0";
//        char typeName[32] = "lights[x].type\0";
//        char posName[32] = "lights[x].position\0";
//        char targetName[32] = "lights[x].target\0";
//        char colorName[32] = "lights[x].color\0";
        
//        // Set location name [x] depending on lights count
//        enabledName[7] = '0' + lightsCount;
//        typeName[7] = '0' + lightsCount;
//        posName[7] = '0' + lightsCount;
//        targetName[7] = '0' + lightsCount;
//        colorName[7] = '0' + lightsCount;

//        light.enabledLoc = GetShaderLocation(shader, enabledName);
//        light.typeLoc = GetShaderLocation(shader, typeName);
//        light.posLoc = GetShaderLocation(shader, posName);
//        light.targetLoc = GetShaderLocation(shader, targetName);
//        light.colorLoc = GetShaderLocation(shader, colorName);

//        UpdateLightValues(shader, light);
        
//        lightsCount++;
//    }

//    return light;
//}

//// Send light properties to shader
//// NOTE: Light shader locations should be available 
//void UpdateLightValues(Shader shader, Light light)
//{
//    // Send to shader light enabled state and type
//    SetShaderValue(shader, light.enabledLoc, &light.enabled, SHADER_UNIFORM_INT);
//    SetShaderValue(shader, light.typeLoc, &light.type, SHADER_UNIFORM_INT);

//    // Send to shader light position values
//    Vector3 position = new( light.position.X, light.position.Y, light.position.Z );
//    SetShaderValue(shader, light.posLoc, position, SHADER_UNIFORM_VEC3);

//    // Send to shader light target position values
//    Vector3 target = new( light.target.X, light.target.Y, light.target.Z );
//    SetShaderValue(shader, light.targetLoc, target, SHADER_UNIFORM_VEC3);

//    // Send to shader light color values
//    float color[4] =new( (float)light.color.r/(float)255, (float)light.color.g/(float)255, 
//                       (float)light.color.b/(float)255, (float)light.color.a/(float)255 );
//    SetShaderValue(shader, light.colorLoc, color, SHADER_UNIFORM_VEC4);
//}

//#endif // RLIGHTS_IMPLEMENTATION
