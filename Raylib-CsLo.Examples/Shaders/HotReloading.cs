﻿// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.Examples.Shaders;

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


