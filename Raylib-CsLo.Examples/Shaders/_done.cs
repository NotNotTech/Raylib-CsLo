// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylib_CsLo.Examples.Shaders;




/*******************************************************************************************
*
*   raylib [shaders] example - basic lighting
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 3.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@codifies, http://bedroomcoders.co.uk/) and 
*   reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019-2021 Chris Camacho (@codifies) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class BasicLighting
{

	const int GLSL_VERSION = 330;
	public static int main()
	{
		var rLights = new Examples.RLights();
		

		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		SetConfigFlags(FLAG_MSAA_4X_HINT);  // Enable Multi Sampling Anti Aliasing 4x (if available)
		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - basic lighting");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new Vector3(2.0f, 4.0f, 6.0f);    // Camera position
		camera.target = new Vector3(0.0f, 0.5f, 0.0f);      // Camera looking at point
		camera.up = new Vector3(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		// Load plane model from a generated mesh
		Model model = LoadModelFromMesh(GenMeshPlane(10.0f, 10.0f, 3, 3));
		Model cube = LoadModelFromMesh(GenMeshCube(2.0f, 4.0f, 2.0f));

		Shader shader = LoadShader(TextFormat("resources/shaders/glsl%i/base_lighting.vs", GLSL_VERSION),
								   TextFormat("resources/shaders/glsl%i/lighting.fs", GLSL_VERSION));

		// Get some required shader loactions
		shader.locs[(int)SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(shader, "viewPos");
		// NOTE: "matModel" location name is automatically assigned on shader loading, 
		// no need to get the location again if using that uniform name
		//shader.locs[SHADER_LOC_MATRIX_MODEL] = GetShaderLocation(shader, "matModel");

		// Ambient light level (some basic lighting)
		int ambientLoc = GetShaderLocation(shader, "ambient");
		SetShaderValue(shader, ambientLoc, new Vector4(0.1f, 0.1f, 0.1f, 1.0f), SHADER_UNIFORM_VEC4);

		// Assign out lighting shader to model
		model.materials[0].shader = shader;
		cube.materials[0].shader = shader;

		// Using 4 point lights: gold, red, green and blue
		Light[] lights = new Light[MAX_LIGHTS];
		lights[0] = rLights.CreateLight(LIGHT_POINT, new Vector3(-2, 1, -2), Vector3Zero(), YELLOW, shader);
		lights[1] = rLights.CreateLight(LIGHT_POINT, new Vector3(2, 1, 2), Vector3Zero(), RED, shader);
		lights[2] = rLights.CreateLight(LIGHT_POINT, new Vector3(-2, 1, 2), Vector3Zero(), GREEN, shader);
		lights[3] = rLights.CreateLight(LIGHT_POINT, new Vector3(2, 1, -2), Vector3Zero(), BLUE, shader);

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(&camera);              // Update camera

			// Check key inputs to enable/disable lights
			if (IsKeyPressed(KEY_Y)) { lights[0].enabled = !lights[0].enabled; }
			if (IsKeyPressed(KEY_R)) { lights[1].enabled = !lights[1].enabled; }
			if (IsKeyPressed(KEY_G)) { lights[2].enabled = !lights[2].enabled; }
			if (IsKeyPressed(KEY_B)) { lights[3].enabled = !lights[3].enabled; }

			// Update light values (actually, only enable/disable them)
			rLights.UpdateLightValues(shader, lights[0]);
			rLights.UpdateLightValues(shader, lights[1]);
			rLights.UpdateLightValues(shader, lights[2]);
			rLights.UpdateLightValues(shader, lights[3]);

			// Update the shader with the camera view vector (points towards { 0.0f, 0.0f, 0.0f })
			Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
			SetShaderValue(shader, shader.locs[(int)SHADER_LOC_VECTOR_VIEW], cameraPos, SHADER_UNIFORM_VEC3);
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModel(model, Vector3Zero(), 1.0f, WHITE);
			DrawModel(cube, Vector3Zero(), 1.0f, WHITE);

			// Draw markers to show where the lights are
			if (lights[0].enabled) DrawSphereEx(lights[0].position, 0.2f, 8, 8, YELLOW);
			else DrawSphereWires(lights[0].position, 0.2f, 8, 8, ColorAlpha(YELLOW, 0.3f));
			if (lights[1].enabled) DrawSphereEx(lights[1].position, 0.2f, 8, 8, RED);
			else DrawSphereWires(lights[1].position, 0.2f, 8, 8, ColorAlpha(RED, 0.3f));
			if (lights[2].enabled) DrawSphereEx(lights[2].position, 0.2f, 8, 8, GREEN);
			else DrawSphereWires(lights[2].position, 0.2f, 8, 8, ColorAlpha(GREEN, 0.3f));
			if (lights[3].enabled) DrawSphereEx(lights[3].position, 0.2f, 8, 8, BLUE);
			else DrawSphereWires(lights[3].position, 0.2f, 8, 8, ColorAlpha(BLUE, 0.3f));

			DrawGrid(10, 1.0f);

			EndMode3D();

			DrawFPS(10, 10);

			DrawText("Use keys [Y][R][G][B] to toggle lights", 10, 40, 20, DARKGRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadModel(model);     // Unload the model
		UnloadModel(cube);      // Unload the model
		UnloadShader(shader);   // Unload shader

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}
}

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

public unsafe static class CustomUniform
{

	const int GLSL_VERSION = 330;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		SetConfigFlags(FLAG_MSAA_4X_HINT);      // Enable Multi Sampling Anti Aliasing 4x (if available)

		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - custom uniform variable");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new Vector3(8.0f, 8.0f, 8.0f);
		camera.target = new Vector3(0.0f, 1.5f, 0.0f);
		camera.up = new Vector3(0.0f, 1.0f, 0.0f);
		camera.fovy = 45.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		Model model = LoadModel("resources/models/barracks.obj");                   // Load OBJ model
		Texture2D texture = LoadTexture("resources/models/barracks_diffuse.png");   // Load model texture (diffuse map)
		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;                     // Set model diffuse texture

		Vector3 position = new(0.0f, 0.0f, 0.0f);                                    // Set model position

		// Load postprocessing shader
		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/swirl.fs", GLSL_VERSION));

		// Get variable (uniform) location on the shader to connect with the program
		// NOTE: If uniform variable could not be found in the shader, function returns -1
		int swirlCenterLoc = GetShaderLocation(shader, "center");

		Vector2 swirlCenter = new((float)screenWidth / 2, (float)screenHeight / 2);

		// Create a RenderTexture2D to be used for render to texture
		RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

		// Setup orbital camera
		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			Vector2 mousePosition = GetMousePosition();

			swirlCenter.X = mousePosition.X;
			swirlCenter.Y = screenHeight - mousePosition.Y;

			// Send new value to the shader to be used on drawing
			SetShaderValue(shader, swirlCenterLoc, swirlCenter, SHADER_UNIFORM_VEC2);

			UpdateCamera(&camera);          // Update camera
											//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginTextureMode(target);       // Enable drawing to texture
			ClearBackground(RAYWHITE);  // Clear texture background

			BeginMode3D(camera);        // Begin 3d mode drawing
			DrawModel(model, position, 0.5f, WHITE);   // Draw 3d model with texture
			DrawGrid(10, 1.0f);     // Draw a grid
			EndMode3D();                // End 3d mode drawing, returns to orthographic 2d mode

			DrawText("TEXT DRAWN IN RENDER TEXTURE", 200, 10, 30, RED);
			EndTextureMode();               // End drawing to texture (now we have a texture available for next passes)

			BeginDrawing();
			ClearBackground(RAYWHITE);  // Clear screen background

			// Enable shader using the custom uniform
			BeginShaderMode(shader);
			// NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
			DrawTextureRec(target.texture, new Rectangle(0, 0, (float)target.texture.width, (float)-target.texture.height), new Vector2(
				0, 0), WHITE);
			EndShaderMode();

			// Draw some 2d text over drawn texture
			DrawText("(c) Barracks 3D model by Alberto Cano", screenWidth - 220, screenHeight - 20, 10, GRAY);
			DrawFPS(10, 10);
			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadShader(shader);               // Unload shader
		UnloadTexture(texture);             // Unload texture
		UnloadModel(model);                 // Unload model
		UnloadRenderTexture(target);        // Unload render texture

		CloseWindow();                      // Close window and OpenGL context
											//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [shaders] example - Sieve of Eratosthenes
*
*   Sieve of Eratosthenes, the earliest known (ancient Greek) prime number sieve.
*
*   "Sift the twos and sift the threes,
*    The Sieve of Eratosthenes.
*    When the multiples sublime,
*    the numbers that are left are prime."
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by ProfJski and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 ProfJski and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class Eratosthenes
{

	const int GLSL_VERSION = 330;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - Sieve of Eratosthenes");

		RenderTexture2D target = LoadRenderTexture(screenWidth, screenHeight);

		// Load Eratosthenes shader
		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/eratosthenes.fs", GLSL_VERSION));

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// Nothing to do here, everything is happening in the shader
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginTextureMode(target);       // Enable drawing to texture
			ClearBackground(BLACK);     // Clear the render texture

			// Draw a rectangle in shader mode to be used as shader canvas
			// NOTE: Rectangle uses font white character texture coordinates,
			// so shader can not be applied here directly because input vertexTexCoord
			// do not represent full screen coordinates (space where want to apply shader)
			DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), BLACK);
			EndTextureMode();               // End drawing to texture (now we have a blank texture available for the shader)

			BeginDrawing();
			ClearBackground(RAYWHITE);  // Clear screen background

			BeginShaderMode(shader);
			// NOTE: Render texture must be y-flipped due to default OpenGL coordinates (left-bottom)
			DrawTextureRec(target.texture, new Rectangle(0, 0, (float)target.texture.width, (float)-target.texture.height), new Vector2(0.0f, 0.0f), WHITE);
			EndShaderMode();
			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadShader(shader);               // Unload shader
		UnloadRenderTexture(target);        // Unload render texture

		CloseWindow();                      // Close window and OpenGL context
											//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [shaders] example - fog
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@chriscamacho) and reviewed by Ramon Santamaria (@raysan5)
*
*   Chris Camacho (@chriscamacho -  http://bedroomcoders.co.uk/) notes:
*
*   This is based on the PBR lighting example, but greatly simplified to aid learning...
*   actually there is very little of the PBR example left!
*   When I first looked at the bewildering complexity of the PBR example I feared
*   I would never understand how I could do simple lighting with raylib however its
*   a testement to the authors of raylib (including rlights.h) that the example
*   came together fairly quickly.
*
*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/
public unsafe static class Fog
{

	const int GLSL_VERSION = 330;
	public static int main()
	{
		var rLights = new Examples.RLights();
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		SetConfigFlags(FLAG_MSAA_4X_HINT);  // Enable Multi Sampling Anti Aliasing 4x (if available)
		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - fog");

		// Define the camera to look into our 3d world
		Camera camera = new(
			new Vector3(2.0f, 2.0f, 6.0f),      // position
			new Vector3(0.0f, 0.5f, 0.0f),      // target
			new Vector3(0.0f, 1.0f, 0.0f),      // up
			45.0f, CAMERA_PERSPECTIVE);        // fov, type

		// Load models and texture
		Model modelA = LoadModelFromMesh(GenMeshTorus(0.4f, 1.0f, 16, 32));
		Model modelB = LoadModelFromMesh(GenMeshCube(1.0f, 1.0f, 1.0f));
		Model modelC = LoadModelFromMesh(GenMeshSphere(0.5f, 32, 32));
		Texture texture = LoadTexture("resources/texel_checker.png");

		// Assign texture to default model material
		modelA.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;
		modelB.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;
		modelC.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;

		// Load shader and set up some uniforms
		Shader shader = LoadShader(TextFormat("resources/shaders/glsl%i/base_lighting.vs", GLSL_VERSION),
								   TextFormat("resources/shaders/glsl%i/fog.fs", GLSL_VERSION));
		shader.locs[(int)SHADER_LOC_MATRIX_MODEL] = GetShaderLocation(shader, "matModel");
		shader.locs[(int)SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(shader, "viewPos");

		// Ambient light level
		int ambientLoc = GetShaderLocation(shader, "ambient");
		SetShaderValue(shader, ambientLoc, new Vector4(0.2f, 0.2f, 0.2f, 1.0f), SHADER_UNIFORM_VEC4);

		float fogDensity = 0.15f;
		int fogDensityLoc = GetShaderLocation(shader, "fogDensity");
		SetShaderValue(shader, fogDensityLoc, &fogDensity, SHADER_UNIFORM_FLOAT);

		// NOTE: All models share the same shader
		modelA.materials[0].shader = shader;
		modelB.materials[0].shader = shader;
		modelC.materials[0].shader = shader;

		// Using just 1 point lights
		rLights.CreateLight(LIGHT_POINT, new Vector3(0, 2, 6), Vector3Zero(), WHITE, shader);

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(&camera);              // Update camera

			if (IsKeyDown(KEY_UP))
			{
				fogDensity += 0.001f;
				if (fogDensity > 1.0f) fogDensity = 1.0f;
			}

			if (IsKeyDown(KEY_DOWN))
			{
				fogDensity -= 0.001f;
				if (fogDensity < 0.0f) fogDensity = 0.0f;
			}

			SetShaderValue(shader, fogDensityLoc, &fogDensity, SHADER_UNIFORM_FLOAT);

			// Rotate the torus
			modelA.transform = MatrixMultiply(modelA.transform, MatrixRotateX(-0.025f));
			modelA.transform = MatrixMultiply(modelA.transform, MatrixRotateZ(0.012f));

			// Update the light shader with the camera view position
			SetShaderValue(shader, shader.locs[(int)SHADER_LOC_VECTOR_VIEW], &camera.position.X, SHADER_UNIFORM_VEC3);
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(GRAY);

			BeginMode3D(camera);

			// Draw the three models
			DrawModel(modelA, Vector3Zero(), 1.0f, WHITE);
			DrawModel(modelB, new Vector3(-2.6f, 0, 0), 1.0f, WHITE);
			DrawModel(modelC, new Vector3(2.6f, 0, 0), 1.0f, WHITE);

			for (int i = -20; i < 20; i += 2) DrawModel(modelA, new Vector3((float)i, 0, 2), 1.0f, WHITE);

			EndMode3D();

			DrawText(TextFormat("Use KEY_UP/KEY_DOWN to change fog density [%.2f]", fogDensity), 10, 10, 20, RAYWHITE);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadModel(modelA);        // Unload the model A
		UnloadModel(modelB);        // Unload the model B
		UnloadModel(modelC);        // Unload the model C
		UnloadTexture(texture);     // Unload the texture
		UnloadShader(shader);       // Unload shader

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}





/*******************************************************************************************
*
*   raylib [shaders] example - Hot reloading
*
*   NOTE: This example requires raylib OpenGL 3.3 for shaders support and only #version 330
*         is currently supported. OpenGL ES 2.0 platforms are not supported at the moment.
*
*   This example has been created using raylib 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class HotReloading
{

	const int GLSL_VERSION = 330;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		int screenWidth = 800;
		int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - hot reloading");

		string fragShaderFileName = "resources/shaders/glsl%i/reload.fs";

		//System.IO.File.GetLastWriteTime(TextFormat(fragShaderFileName, GLSL_VERSION)).Ticks;
		long fragShaderFileModTime = GetFileModTime(TextFormat(fragShaderFileName, GLSL_VERSION));

		// Load raymarching shader
		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
		Shader shader = LoadShader(null, TextFormat(fragShaderFileName, GLSL_VERSION));

		// Get shader locations for required uniforms
		int resolutionLoc = GetShaderLocation(shader, "resolution");
		int mouseLoc = GetShaderLocation(shader, "mouse");
		int timeLoc = GetShaderLocation(shader, "time");

		Vector2 resolution = new((float)screenWidth, (float)screenHeight);
		SetShaderValue(shader, resolutionLoc, resolution, SHADER_UNIFORM_VEC2);

		float totalTime = 0.0f;
		bool shaderAutoReloading = false;

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			totalTime += GetFrameTime();
			Vector2 mouse = GetMousePosition();
			Vector2 mousePos = new(mouse.X, mouse.Y);

			// Set shader required uniform values
			SetShaderValue(shader, timeLoc, &totalTime, SHADER_UNIFORM_FLOAT);
			SetShaderValue(shader, mouseLoc, mousePos, SHADER_UNIFORM_VEC2);

			// Hot shader reloading
			if (shaderAutoReloading || (IsMouseButtonPressed(MOUSE_BUTTON_LEFT)))
			{
				long currentFragShaderModTime = GetFileModTime(TextFormat(fragShaderFileName, GLSL_VERSION));

				// Check if shader file has been modified
				if (currentFragShaderModTime != fragShaderFileModTime)
				{
					// Try reloading updated shader
					Shader updatedShader = LoadShader(null, TextFormat(fragShaderFileName, GLSL_VERSION));

					if (updatedShader.id != rlGetShaderIdDefault())      // It was correctly loaded
					{
						UnloadShader(shader);
						shader = updatedShader;

						// Get shader locations for required uniforms
						resolutionLoc = GetShaderLocation(shader, "resolution");
						mouseLoc = GetShaderLocation(shader, "mouse");
						timeLoc = GetShaderLocation(shader, "time");

						// Reset required uniforms
						SetShaderValue(shader, resolutionLoc, resolution, SHADER_UNIFORM_VEC2);
					}

					fragShaderFileModTime = currentFragShaderModTime;
				}
			}

			if (IsKeyPressed(KEY_A)) shaderAutoReloading = !shaderAutoReloading;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			// We only draw a white full-screen rectangle, frame is generated in shader
			BeginShaderMode(shader);
			DrawRectangle(0, 0, screenWidth, screenHeight, WHITE);
			EndShaderMode();

			DrawText(TextFormat("PRESS [A] to TOGGLE SHADER AUTOLOADING: %s",
					 shaderAutoReloading ? "AUTO" : "MANUAL"), 10, 10, 10, shaderAutoReloading ? RED : BLACK);
			if (!shaderAutoReloading) DrawText("MOUSE CLICK to SHADER RE-LOADING", 10, 30, 10, BLACK);

			DrawText(TextFormat("Shader last modification: %s", DateTime.FromFileTime(fragShaderFileModTime).ToString()), 10, 430, 10, BLACK);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadShader(shader);           // Unload shader

		CloseWindow();                  // Close window and OpenGL context
										//--------------------------------------------------------------------------------------

		return 0;
	}


}

/*******************************************************************************************
*
*   raylib [shaders] example - julia sets
*
*   NOTE: This example requires raylib OpenGL 3.3 or ES2 versions for shaders support,
*         OpenGL 1.1 does not support shaders, recompile raylib to OpenGL 3.3 version.
*
*   NOTE: Shaders used in this example are #version 330 (OpenGL 3.3).
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by eggmund (@eggmund) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 eggmund (@eggmund) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class JuliaSet
{

	const int GLSL_VERSION = 330;


	// A few good julia sets
	static Vector2[] pointsOfInterest = new Vector2[6]
{
	new Vector2( -0.348827f, 0.607167f ),
	new Vector2( -0.786268f, 0.169728f ),
	new Vector2( -0.8f, 0.156f ),
	new Vector2( 0.285f, 0.0f ),
	new Vector2( -0.835f, -0.2321f ),
	new Vector2( -0.70176f, -0.3842f ),
};
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		//SetConfigFlags(FLAG_WINDOW_HIGHDPI);
		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - julia sets");

		// Load julia set shader
		// NOTE: Defining 0 (NULL) for vertex shader forces usage of internal default vertex shader
		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/julia_set.fs", GLSL_VERSION));

		// Create a RenderTexture2D to be used for render to texture
		RenderTexture2D target = LoadRenderTexture(GetScreenWidth(), GetScreenHeight());

		// c constant to use in z^2 + c
		Vector2 c = pointsOfInterest[0];// new(pointsOfInterest[0][0], pointsOfInterest[0][1]);

		// Offset and zoom to draw the julia set at. (centered on screen and default size)
		Vector2 offset = new(-(float)GetScreenWidth() / 2, -(float)GetScreenHeight() / 2);
		float zoom = 1.0f;

		Vector2 offsetSpeed = new(0.0f, 0.0f);

		// Get variable (uniform) locations on the shader to connect with the program
		// NOTE: If uniform variable could not be found in the shader, function returns -1
		int cLoc = GetShaderLocation(shader, "c");
		int zoomLoc = GetShaderLocation(shader, "zoom");
		int offsetLoc = GetShaderLocation(shader, "offset");

		// Tell the shader what the screen dimensions, zoom, offset and c are
		Vector2 screenDims = new((float)GetScreenWidth(), (float)GetScreenHeight());
		SetShaderValue(shader, GetShaderLocation(shader, "screenDims"), screenDims, SHADER_UNIFORM_VEC2);

		SetShaderValue(shader, cLoc, c, SHADER_UNIFORM_VEC2);
		SetShaderValue(shader, zoomLoc, &zoom, SHADER_UNIFORM_FLOAT);
		SetShaderValue(shader, offsetLoc, offset, SHADER_UNIFORM_VEC2);

		int incrementSpeed = 0;             // Multiplier of speed to change c value
		bool showControls = true;           // Show controls
		bool pause = false;                 // Pause animation

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// Press [1 - 6] to reset c to a point of interest
			if (IsKeyPressed(KEY_ONE) ||
				IsKeyPressed(KEY_TWO) ||
				IsKeyPressed(KEY_THREE) ||
				IsKeyPressed(KEY_FOUR) ||
				IsKeyPressed(KEY_FIVE) ||
				IsKeyPressed(KEY_SIX))
			{
				if (IsKeyPressed(KEY_ONE)) c = pointsOfInterest[0];//c[0] = pointsOfInterest[0][0], c[1] = pointsOfInterest[0][1];

				else if (IsKeyPressed(KEY_TWO)) c = pointsOfInterest[1];//c[0] = pointsOfInterest[1][0], c[1] = pointsOfInterest[1][1];

				else if (IsKeyPressed(KEY_THREE)) c = pointsOfInterest[2];//c[0] = pointsOfInterest[2][0], c[1] = pointsOfInterest[2][1];

				else if (IsKeyPressed(KEY_FOUR)) c = pointsOfInterest[3];//c[0] = pointsOfInterest[3][0], c[1] = pointsOfInterest[3][1];

				else if (IsKeyPressed(KEY_FIVE)) c = pointsOfInterest[4];//c[0] = pointsOfInterest[4][0], c[1] = pointsOfInterest[4][1];

				else if (IsKeyPressed(KEY_SIX)) c = pointsOfInterest[5];//c[0] = pointsOfInterest[5][0], c[1] = pointsOfInterest[5][1];

				SetShaderValue(shader, cLoc, c, SHADER_UNIFORM_VEC2);
			}

			if (IsKeyPressed(KEY_SPACE)) pause = !pause;                 // Pause animation (c change)
			if (IsKeyPressed(KEY_F1)) showControls = !showControls;  // Toggle whether or not to show controls

			if (!pause)
			{
				if (IsKeyPressed(KEY_RIGHT)) incrementSpeed++;
				else if (IsKeyPressed(KEY_LEFT)) incrementSpeed--;

				// TODO: The idea is to zoom and move around with mouse
				// Probably offset movement should be proportional to zoom level
				if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) || IsMouseButtonDown(MOUSE_BUTTON_RIGHT))
				{
					if (IsMouseButtonDown(MOUSE_BUTTON_LEFT)) zoom += zoom * 0.003f;
					if (IsMouseButtonDown(MOUSE_BUTTON_RIGHT)) zoom -= zoom * 0.003f;

					Vector2 mousePos = GetMousePosition();

					offsetSpeed.X = mousePos.X - (float)screenWidth / 2;
					offsetSpeed.Y = mousePos.Y - (float)screenHeight / 2;

					// Slowly move camera to targetOffset
					offset.X += GetFrameTime() * offsetSpeed.X * 0.8f;
					offset.Y += GetFrameTime() * offsetSpeed.Y * 0.8f;
				}
				else offsetSpeed = new Vector2(0.0f, 0.0f);

				SetShaderValue(shader, zoomLoc, &zoom, SHADER_UNIFORM_FLOAT);
				SetShaderValue(shader, offsetLoc, offset, SHADER_UNIFORM_VEC2);

				// Increment c value with time
				float amount = GetFrameTime() * incrementSpeed * 0.0005f;
				c.X += amount;
				c.Y += amount;

				SetShaderValue(shader, cLoc, c, SHADER_UNIFORM_VEC2);
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			// Using a render texture to draw Julia set
			BeginTextureMode(target);       // Enable drawing to texture
			ClearBackground(BLACK);     // Clear the render texture

			// Draw a rectangle in shader mode to be used as shader canvas
			// NOTE: Rectangle uses font white character texture coordinates,
			// so shader can not be applied here directly because input vertexTexCoord
			// do not represent full screen coordinates (space where want to apply shader)
			DrawRectangle(0, 0, GetScreenWidth(), GetScreenHeight(), BLACK);
			EndTextureMode();

			BeginDrawing();
			ClearBackground(BLACK);     // Clear screen background

			// Draw the saved texture and rendered julia set with shader
			// NOTE: We do not invert texture on Y, already considered inside shader
			BeginShaderMode(shader);
			// WARNING: If FLAG_WINDOW_HIGHDPI is enabled, HighDPI monitor scaling should be considered
			// when rendering the RenderTexture2D to fit in the HighDPI scaled Window
			DrawTextureEx(target.texture, new Vector2(
				0.0f, 0.0f), 0.0f, 1.0f, WHITE);
			EndShaderMode();

			if (showControls)
			{
				DrawText("Press Mouse buttons right/left to zoom in/out and move", 10, 15, 10, RAYWHITE);
				DrawText("Press KEY_F1 to toggle these controls", 10, 30, 10, RAYWHITE);
				DrawText("Press KEYS [1 - 6] to change point of interest", 10, 45, 10, RAYWHITE);
				DrawText("Press KEY_LEFT | KEY_RIGHT to change speed", 10, 60, 10, RAYWHITE);
				DrawText("Press KEY_SPACE to pause movement animation", 10, 75, 10, RAYWHITE);
			}
			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadShader(shader);               // Unload shader
		UnloadRenderTexture(target);        // Unload render texture

		CloseWindow();                      // Close window and OpenGL context
											//--------------------------------------------------------------------------------------

		return 0;
	}
}




/*******************************************************************************************
*
*   raylib [shaders] example - mesh instancing
*
*   This example has been created using raylib 3.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by @seanpringle and reviewed by Max (@moliad) and Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020-2021 @seanpringle, Max (@moliad) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class MeshInstancing
{

	const int GLSL_VERSION = 330;
	const int MAX_INSTANCES = 10000;
	public static int main()
	{
		var rLights = new Examples.RLights();
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;
		const int fps = 60;

		SetConfigFlags(FLAG_MSAA_4X_HINT);  // Enable Multi Sampling Anti Aliasing 4x (if available)
		InitWindow(screenWidth, screenHeight, "raylib [shaders] example - mesh instancing");

		int speed = 30;                 // Speed of jump animation
		int groups = 2;                 // Count of separate groups jumping around
		float amp = 10;                 // Maximum amplitude of jump
		float variance = 0.8f;          // Global variance in jump height
		float loop = 0.0f;              // Individual cube's computed loop timer
		float x = 0.0f, y = 0.0f, z = 0.0f; // Used for various 3D coordinate & vector ops

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new Vector3(-125.0f, 125.0f, -125.0f);
		camera.target = new Vector3(0.0f, 0.0f, 0.0f);
		camera.up = new Vector3(0.0f, 1.0f, 0.0f);
		camera.fovy = 45.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);

		Matrix[] rotations = new Matrix[MAX_INSTANCES];    // Rotation state of instances
		Matrix[] rotationsInc = new Matrix[MAX_INSTANCES]; // Per-frame rotation animation of instances
		Matrix[] translations = new Matrix[MAX_INSTANCES]; // Locations of instances

		// Scatter random cubes around
		for (int i = 0; i < MAX_INSTANCES; i++)
		{
			x = (float)GetRandomValue(-50, 50);
			y = (float)GetRandomValue(-50, 50);
			z = (float)GetRandomValue(-50, 50);
			translations[i] = MatrixTranslate(x, y, z);

			x = (float)GetRandomValue(0, 360);
			y = (float)GetRandomValue(0, 360);
			z = (float)GetRandomValue(0, 360);
			Vector3 axis = Vector3Normalize(new Vector3(x, y, z));
			float angle = (float)GetRandomValue(0, 10) * DEG2RAD;

			rotationsInc[i] = MatrixRotate(axis, angle);
			rotations[i] = MatrixIdentity();
		}

		Matrix[] transforms = new Matrix[MAX_INSTANCES];   // Pre-multiplied transformations passed to rlgl

		Shader shader = LoadShader(TextFormat("resources/shaders/glsl%i/base_lighting_instanced.vs", GLSL_VERSION),
								   TextFormat("resources/shaders/glsl%i/lighting.fs", GLSL_VERSION));

		// Get some shader loactions
		shader.locs[(int)SHADER_LOC_MATRIX_MVP] = GetShaderLocation(shader, "mvp");
		shader.locs[(int)SHADER_LOC_VECTOR_VIEW] = GetShaderLocation(shader, "viewPos");
		shader.locs[(int)SHADER_LOC_MATRIX_MODEL] = GetShaderLocationAttrib(shader, "instanceTransform");

		// Ambient light level
		int ambientLoc = GetShaderLocation(shader, "ambient");
		SetShaderValue(shader, ambientLoc, new Vector4(0.2f, 0.2f, 0.2f, 1.0f), SHADER_UNIFORM_VEC4);

		rLights.CreateLight(LIGHT_DIRECTIONAL, new Vector3(50.0f, 50.0f, 0.0f), Vector3Zero(), WHITE, shader);

		// NOTE: We are assigning the intancing shader to material.shader
		// to be used on mesh drawing with DrawMeshInstanced()
		Material material = LoadMaterialDefault();
		material.shader = shader;
		material.maps[(int)MATERIAL_MAP_DIFFUSE].color = RED;

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		int textPositionY = 300;
		int framesCounter = 0;                  // Simple frames counter to manage animation

		SetTargetFPS(fps);                      // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{

			// Update
			//----------------------------------------------------------------------------------
			textPositionY = 300;
			framesCounter++;

			if (IsKeyDown(KEY_UP)) amp += 0.5f;
			if (IsKeyDown(KEY_DOWN)) amp = (amp <= 1) ? 1.0f : (amp - 1.0f);
			if (IsKeyDown(KEY_LEFT)) variance = (variance <= 0.0f) ? 0.0f : (variance - 0.01f);
			if (IsKeyDown(KEY_RIGHT)) variance = (variance >= 1.0f) ? 1.0f : (variance + 0.01f);
			if (IsKeyDown(KEY_ONE)) groups = 1;
			if (IsKeyDown(KEY_TWO)) groups = 2;
			if (IsKeyDown(KEY_THREE)) groups = 3;
			if (IsKeyDown(KEY_FOUR)) groups = 4;
			if (IsKeyDown(KEY_FIVE)) groups = 5;
			if (IsKeyDown(KEY_SIX)) groups = 6;
			if (IsKeyDown(KEY_SEVEN)) groups = 7;
			if (IsKeyDown(KEY_EIGHT)) groups = 8;
			if (IsKeyDown(KEY_NINE)) groups = 9;
			if (IsKeyDown(KEY_W)) { groups = 7; amp = 25; speed = 18; variance = 0.70f; }

			if (IsKeyDown(KEY_EQUAL)) speed = (speed <= (fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);
			if (IsKeyDown(KEY_KP_ADD)) speed = (speed <= (fps * 0.25f)) ? (int)(fps * 0.25f) : (int)(speed * 0.95f);

			if (IsKeyDown(KEY_MINUS)) speed = (int)MathF.Max(speed * 1.02f, speed + 1);
			if (IsKeyDown(KEY_KP_SUBTRACT)) speed = (int)MathF.Max(speed * 1.02f, speed + 1);

			// Update the light shader with the camera view position
			Vector3 cameraPos = new(camera.position.X, camera.position.Y, camera.position.Z);
			SetShaderValue(shader, shader.locs[(int)SHADER_LOC_VECTOR_VIEW], cameraPos, SHADER_UNIFORM_VEC3);

			// Apply per-instance transformations
			for (int i = 0; i < MAX_INSTANCES; i++)
			{
				rotations[i] = MatrixMultiply(rotations[i], rotationsInc[i]);
				transforms[i] = MatrixMultiply(rotations[i], translations[i]);

				// Get the animation cycle's framesCounter for this instance
				loop = (float)((framesCounter + (int)(((float)(i % groups) / groups) * speed)) % speed) / speed;

				// Calculate the y according to loop cycle
				y = (MathF.Sin(loop * PI * 2)) * amp * ((1 - variance) + (variance * (float)(i % (groups * 10)) / (groups * 10)));

				// Clamp to floor
				y = (y < 0) ? 0.0f : y;

				transforms[i] = MatrixMultiply(transforms[i], MatrixTranslate(0.0f, y, 0.0f));
			}

			UpdateCamera(&camera);
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);
			//DrawMesh(cube, material, MatrixIdentity());
			for (var i = 0; i < transforms.Length; i++)
			{
				//flip for opengl column major
				transforms[i] = Matrix.Transpose(transforms[i]);
			}
			DrawMeshInstanced(cube, material, transforms, MAX_INSTANCES);
			EndMode3D();

			DrawText("A CUBE OF DANCING CUBES!", 490, 10, 20, MAROON);
			DrawText("PRESS KEYS:", 10, textPositionY, 20, BLACK);

			DrawText("1 - 9", 10, textPositionY += 25, 10, BLACK);
			DrawText(": Number of groups", 50, textPositionY, 10, BLACK);
			DrawText(TextFormat(": %d", groups), 160, textPositionY, 10, BLACK);

			DrawText("UP", 10, textPositionY += 15, 10, BLACK);
			DrawText(": increase amplitude", 50, textPositionY, 10, BLACK);
			DrawText(TextFormat(": %.2f", amp), 160, textPositionY, 10, BLACK);

			DrawText("DOWN", 10, textPositionY += 15, 10, BLACK);
			DrawText(": decrease amplitude", 50, textPositionY, 10, BLACK);

			DrawText("LEFT", 10, textPositionY += 15, 10, BLACK);
			DrawText(": decrease variance", 50, textPositionY, 10, BLACK);
			DrawText(TextFormat(": %.2f", variance), 160, textPositionY, 10, BLACK);

			DrawText("RIGHT", 10, textPositionY += 15, 10, BLACK);
			DrawText(": increase variance", 50, textPositionY, 10, BLACK);

			DrawText("+/=", 10, textPositionY += 15, 10, BLACK);
			DrawText(": increase speed", 50, textPositionY, 10, BLACK);
			DrawText(TextFormat(": %d = %f loops/sec", speed, ((float)fps / speed)), 160, textPositionY, 10, BLACK);

			DrawText("-", 10, textPositionY += 15, 10, BLACK);
			DrawText(": decrease speed", 50, textPositionY, 10, BLACK);

			DrawText("W", 10, textPositionY += 15, 10, BLACK);
			DrawText(": Wild setup!", 50, textPositionY, 10, BLACK);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		CloseWindow();        // Close window and OpenGL context
							  //--------------------------------------------------------------------------------------

		return 0;
	}
}
