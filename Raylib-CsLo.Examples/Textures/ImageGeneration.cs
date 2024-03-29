﻿// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Procedural images generation
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2O17-2021 Wilhem Barbier (@nounoursheureux) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class ImageGeneration
{

	const int NUM_TEXTURES = 6;      // Currently we have 7 generation algorithms

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [textures] example - procedural images generation");

		Image verticalGradient = GenImageGradientV(screenWidth, screenHeight, RED, BLUE);
		Image horizontalGradient = GenImageGradientH(screenWidth, screenHeight, RED, BLUE);
		Image radialGradient = GenImageGradientRadial(screenWidth, screenHeight, 0.0f, WHITE, BLACK);
		Image checkedImage = GenImageChecked(screenWidth, screenHeight, 32, 32, RED, BLUE);
		Image whiteNoise = GenImageWhiteNoise(screenWidth, screenHeight, 0.5f);
		Image cellular = GenImageCellular(screenWidth, screenHeight, 32);

		Texture2D[] textures = new Texture2D[NUM_TEXTURES];

		textures[0] = LoadTextureFromImage(verticalGradient);
		textures[1] = LoadTextureFromImage(horizontalGradient);
		textures[2] = LoadTextureFromImage(radialGradient);
		textures[3] = LoadTextureFromImage(checkedImage);
		textures[4] = LoadTextureFromImage(whiteNoise);
		textures[5] = LoadTextureFromImage(cellular);

		// Unload image data (CPU RAM)
		UnloadImage(verticalGradient);
		UnloadImage(horizontalGradient);
		UnloadImage(radialGradient);
		UnloadImage(checkedImage);
		UnloadImage(whiteNoise);
		UnloadImage(cellular);

		int currentTexture = 0;

		SetTargetFPS(60);
		//---------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())
		{
			// Update
			//----------------------------------------------------------------------------------
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT) || IsKeyPressed(KEY_RIGHT))
			{
				currentTexture = (currentTexture + 1) % NUM_TEXTURES; // Cycle between the textures
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawTexture(textures[currentTexture], 0, 0, WHITE);

			DrawRectangle(30, 400, 325, 30, Fade(SKYBLUE, 0.5f));
			DrawRectangleLines(30, 400, 325, 30, Fade(WHITE, 0.5f));
			DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL TEXTURES", 40, 410, 10, WHITE);

			switch (currentTexture)
			{
				case 0: DrawText("VERTICAL GRADIENT", 560, 10, 20, RAYWHITE); break;
				case 1: DrawText("HORIZONTAL GRADIENT", 540, 10, 20, RAYWHITE); break;
				case 2: DrawText("RADIAL GRADIENT", 580, 10, 20, LIGHTGRAY); break;
				case 3: DrawText("CHECKED", 680, 10, 20, RAYWHITE); break;
				case 4: DrawText("WHITE NOISE", 640, 10, 20, RED); break;
				case 5: DrawText("CELLULAR", 670, 10, 20, RAYWHITE); break;
				default: break;
			}

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------

		// Unload textures data (GPU VRAM)
		for (int i = 0; i < NUM_TEXTURES; i++) UnloadTexture(textures[i]);

		CloseWindow();                // Close window and OpenGL context
									  //--------------------------------------------------------------------------------------

		return 0;
	}
}
