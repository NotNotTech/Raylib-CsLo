// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Retrieve image data from texture: LoadImageFromTexture()
*
*   NOTE: Images are loaded in CPU memory (RAM); textures are loaded in GPU memory (VRAM)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class TextureToImage
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [textures] example - texture to image");

		// NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)

		Image image = LoadImage("resources/raylib_logo.png");  // Load image data into CPU memory (RAM)
		Texture2D texture = LoadTextureFromImage(image);       // Image converted to texture, GPU memory (RAM -> VRAM)
		UnloadImage(image);                                    // Unload image data from CPU memory (RAM)

		image = LoadImageFromTexture(texture);                 // Load image from GPU texture (VRAM -> RAM)
		UnloadTexture(texture);                                // Unload texture from GPU memory (VRAM)

		texture = LoadTextureFromImage(image);                 // Recreate texture from retrieved image data (RAM -> VRAM)
		UnloadImage(image);                                    // Unload retrieved image data from CPU memory (RAM)
															   //---------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// TODO: Update your variables here
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawTexture(texture, screenWidth / 2 - texture.width / 2, screenHeight / 2 - texture.height / 2, WHITE);

			DrawText("this IS a texture loaded from an image!", 300, 370, 10, GRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texture);       // Texture unloading

		CloseWindow();                // Close window and OpenGL context
									  //--------------------------------------------------------------------------------------

		return 0;
	}
}
