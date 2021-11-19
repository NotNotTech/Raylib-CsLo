
namespace Raylib_CsLo.Examples.Models;

/*******************************************************************************************
*
*   raylib [models] example - Waving cubes
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Codecat (@codecat) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Codecat (@codecat) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class WavingCubes
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - waving cubes");

		// Initialize the camera
		Camera3D camera = new();
		camera.position = new(30.0f, 20.0f, 30.0f);
		camera.target = new(0.0f, 0.0f, 0.0f);
		camera.up = new(0.0f, 1.0f, 0.0f);
		camera.fovy = 70.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		// Specify the amount of blocks in each direction
		const int numBlocks = 15;

		SetTargetFPS(60);
		//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			double time = GetTime();

			// Calculate time scale for cube position and size
			float scale = (2.0f + (float)Math.Sin(time)) * 0.7f;

			// Move camera around the scene
			double cameraTime = time * 0.3;
			camera.position.X = (float)Math.Cos(cameraTime) * 40.0f;
			camera.position.Z = (float)Math.Sin(cameraTime) * 40.0f;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawGrid(10, 5.0f);

			for (int x = 0; x < numBlocks; x++)
			{
				for (int y = 0; y < numBlocks; y++)
				{
					for (int z = 0; z < numBlocks; z++)
					{
						// Scale of the blocks depends on x/y/z positions
						float blockScale = (x + y + z) / 30.0f;

						// Scatter makes the waving effect by adding blockScale over time
						float scatter = MathF.Sin(blockScale * 20.0f + (float)(time * 4.0f));

						// Calculate the cube position
						Vector3 cubePos = new(
									(float)(x - numBlocks / 2) * (scale * 3.0f) + scatter,
									(float)(y - numBlocks / 2) * (scale * 2.0f) + scatter,
									(float)(z - numBlocks / 2) * (scale * 3.0f) + scatter
								);

						// Pick a color with a hue depending on cube position for the rainbow color effect
						Color cubeColor = ColorFromHSV((float)(((x + y + z) * 18) % 360), 0.75f, 0.9f);

						// Calculate cube size
						float cubeSize = (2.4f - scale) * blockScale;

						// And finally, draw the cube!
						DrawCube(cubePos, cubeSize, cubeSize, cubeSize, cubeColor);
					}
				}
			}

			EndMode3D();

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
/*******************************************************************************************
*
*   raylib [models] example - Plane rotations (yaw, pitch, roll)
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Berni (@Berni8k) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2017-2021 Berni (@Berni8k) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class YawPitchRoll
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		//SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_WINDOW_HIGHDPI);
		InitWindow(screenWidth, screenHeight, "raylib [models] example - plane rotations (yaw, pitch, roll)");

		Camera camera = new();
		camera.position = new(0.0f, 50.0f, -120.0f);// Camera position perspective
		camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
		camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 30.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera type

		Model model = LoadModel("resources/models/obj/plane.obj");                  // Load model
		Texture2D texture = LoadTexture("resources/models/obj/plane_diffuse.png");  // Load model texture
		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;            // Set map diffuse texture

		float pitch = 0.0f;
		float roll = 0.0f;
		float yaw = 0.0f;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// Plane pitch (x-axis) controls
			if (IsKeyDown(KEY_DOWN)) pitch += 0.6f;
			else if (IsKeyDown(KEY_UP)) pitch -= 0.6f;
			else
			{
				if (pitch > 0.3f) pitch -= 0.3f;
				else if (pitch < -0.3f) pitch += 0.3f;
			}

			// Plane yaw (y-axis) controls
			if (IsKeyDown(KEY_S)) yaw += 1.0f;
			else if (IsKeyDown(KEY_A)) yaw -= 1.0f;
			else
			{
				if (yaw > 0.0f) yaw -= 0.5f;
				else if (yaw < 0.0f) yaw += 0.5f;
			}

			// Plane roll (z-axis) controls
			if (IsKeyDown(KEY_LEFT)) roll -= 1.0f;
			else if (IsKeyDown(KEY_RIGHT)) roll += 1.0f;
			else
			{
				if (roll > 0.0f) roll -= 0.5f;
				else if (roll < 0.0f) roll += 0.5f;
			}

			// Tranformation matrix for rotations
			model.transform = Matrix.Transpose(Matrix4x4.CreateFromYawPitchRoll(DEG2RAD * yaw,DEG2RAD * pitch, DEG2RAD * roll));
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			// Draw 3D model (recomended to draw 3D always before 2D)
			BeginMode3D(camera);

			DrawModel(model, new(0.0f, -8.0f, 0.0f), 1.0f, WHITE);   // Draw 3d model with texture
			DrawGrid(10, 10.0f);

			EndMode3D();

			// Draw controls info
			DrawRectangle(30, 370, 260, 70, Fade(GREEN, 0.5f));
			DrawRectangleLines(30, 370, 260, 70, Fade(DARKGREEN, 0.5f));
			DrawText("Pitch controlled with: KEY_UP / KEY_DOWN", 40, 380, 10, DARKGRAY);
			DrawText("Roll controlled with: KEY_LEFT / KEY_RIGHT", 40, 400, 10, DARKGRAY);
			DrawText("Yaw controlled with: KEY_A / KEY_S", 40, 420, 10, DARKGRAY);

			DrawText("(c) WWI Plane Model created by GiaHanLam", screenWidth - 240, screenHeight - 20, 10, DARKGRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadModel(model);     // Unload model data

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}
}

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
//}
//Light;

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
//	Light light = new();

//	if (lightsCount < MAX_LIGHTS)
//	{
//		light.enabled = true;
//		light.type = type;
//		light.position = position;
//		light.target = target;
//		light.color = color;

//		// TODO: Below code doesn't look good to me, 
//		// it assumes a specific shader naming and structure
//		// Probably this implementation could be improved
//		char enabledName[32] = "lights[x].enabled\0";
//		char typeName[32] = "lights[x].type\0";
//		char posName[32] = "lights[x].position\0";
//		char targetName[32] = "lights[x].target\0";
//		char colorName[32] = "lights[x].color\0";
		
//		// Set location name [x] depending on lights count
//		enabledName[7] = '0' + lightsCount;
//		typeName[7] = '0' + lightsCount;
//		posName[7] = '0' + lightsCount;
//		targetName[7] = '0' + lightsCount;
//		colorName[7] = '0' + lightsCount;

//		light.enabledLoc = GetShaderLocation(shader, enabledName);
//		light.typeLoc = GetShaderLocation(shader, typeName);
//		light.posLoc = GetShaderLocation(shader, posName);
//		light.targetLoc = GetShaderLocation(shader, targetName);
//		light.colorLoc = GetShaderLocation(shader, colorName);

//		UpdateLightValues(shader, light);
		
//		lightsCount++;
//	}

//	return light;
//}

//// Send light properties to shader
//// NOTE: Light shader locations should be available 
//void UpdateLightValues(Shader shader, Light light)
//{
//	// Send to shader light enabled state and type
//	SetShaderValue(shader, light.enabledLoc, &light.enabled, SHADER_UNIFORM_INT);
//	SetShaderValue(shader, light.typeLoc, &light.type, SHADER_UNIFORM_INT);

//	// Send to shader light position values
//	float position[3] =new( light.position.X, light.position.Y, light.position.Z );
//	SetShaderValue(shader, light.posLoc, position, SHADER_UNIFORM_VEC3);

//	// Send to shader light target position values
//	float target[3] =new( light.target.X, light.target.Y, light.target.Z );
//	SetShaderValue(shader, light.targetLoc, target, SHADER_UNIFORM_VEC3);

//	// Send to shader light color values
//	float color[4] =new( (float)light.color.r/(float)255, (float)light.color.g/(float)255, 
//					   (float)light.color.b/(float)255, (float)light.color.a/(float)255 );
//	SetShaderValue(shader, light.colorLoc, color, SHADER_UNIFORM_VEC4);
//}

//#endif // RLIGHTS_IMPLEMENTATION

