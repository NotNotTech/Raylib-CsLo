// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.Examples.Textures;

/*******************************************************************************************
*
*   raylib [textures] example - Draw part of the texture tiled
*
*   This example has been created using raylib 3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2020 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class TiledExture
{

	//#define SIZEOF(A) (sizeof(A)/sizeof(A[0]))
	const int OPT_WIDTH = 220;       // Max width for the options container
	const int MARGIN_SIZE = 8;       // Size for the margins
	const int COLOR_SIZE = 16;       // Size of the color select buttons

	public static int main()//int argc, char** argv)
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		int screenWidth = 800;
		int screenHeight = 450;

		SetConfigFlags(FLAG_WINDOW_RESIZABLE); // Make the window resizable
		InitWindow(screenWidth, screenHeight, "raylib [textures] example - Draw part of a texture tiled");

		// NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
		Texture texPattern = LoadTexture("resources/patterns.png");
		SetTextureFilter(texPattern, TEXTURE_FILTER_TRILINEAR); // Makes the texture smoother when upscaled

		// Coordinates for all patterns inside the texture
		Rectangle[] recPattern = new Rectangle[]{
		new Rectangle( 3, 3, 66, 66 ),
		new Rectangle( 75, 3, 100, 100 ),
		new Rectangle( 3, 75, 66, 66 ),
		new Rectangle( 7, 156, 50, 50 ),
		new Rectangle( 85, 106, 90, 45 ),
		new Rectangle( 75, 154, 100, 60)
	};

		// Setup colors
		Color[] colors = new Color[] { BLACK, MAROON, ORANGE, BLUE, PURPLE, BEIGE, LIME, RED, DARKGRAY, SKYBLUE };

		//enum { MAX_COLORS = SIZEOF(colors) };
		var MAX_COLORS = colors.Length;//  sizeof(Color);
		Rectangle[] colorRec = new Rectangle[MAX_COLORS];

		// Calculate rectangle for each color
		for (int i = 0, x = 0, y = 0; i < MAX_COLORS; i++)
		{
			colorRec[i].x = 2.0f + MARGIN_SIZE + x;
			colorRec[i].y = 22.0f + 256.0f + MARGIN_SIZE + y;
			colorRec[i].width = COLOR_SIZE * 2.0f;
			colorRec[i].height = (float)COLOR_SIZE;

			if (i == (MAX_COLORS / 2 - 1))
			{
				x = 0;
				y += COLOR_SIZE + MARGIN_SIZE;
			}
			else x += (COLOR_SIZE * 2 + MARGIN_SIZE);
		}

		int activePattern = 0, activeCol = 0;
		float scale = 1.0f, rotation = 0.0f;

		SetTargetFPS(60);
		//---------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			screenWidth = GetScreenWidth();
			screenHeight = GetScreenHeight();

			// Handle mouse
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
			{
				Vector2 mouse = GetMousePosition();

				// Check which pattern was clicked and set it as the active pattern
				//for (int i = 0; i < SIZEOF(recPattern); i++)
				for (int i = 0; i < recPattern.Length; i++)
				{
					if (CheckCollisionPointRec(mouse, new Rectangle(2 + MARGIN_SIZE + recPattern[i].X, 40 + MARGIN_SIZE + recPattern[i].Y, recPattern[i].width, recPattern[i].height)))
					{
						activePattern = i;
						break;
					}
				}

				// Check to see which color was clicked and set it as the active color
				for (int i = 0; i < MAX_COLORS; ++i)
				{
					if (CheckCollisionPointRec(mouse, colorRec[i]))
					{
						activeCol = i;
						break;
					}
				}
			}

			// Handle keys

			// Change scale
			if (IsKeyPressed(KEY_UP)) scale += 0.25f;
			if (IsKeyPressed(KEY_DOWN)) scale -= 0.25f;
			if (scale > 10.0f) scale = 10.0f;
			else if (scale <= 0.0f) scale = 0.25f;

			// Change rotation
			if (IsKeyPressed(KEY_LEFT)) rotation -= 25.0f;
			if (IsKeyPressed(KEY_RIGHT)) rotation += 25.0f;

			// Reset
			if (IsKeyPressed(KEY_SPACE)) { rotation = 0.0f; scale = 1.0f; }
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();
			ClearBackground(RAYWHITE);

			// Draw the tiled area
			DrawTextureTiled(texPattern, recPattern[activePattern], new Rectangle((float)OPT_WIDTH + MARGIN_SIZE, (float)MARGIN_SIZE, screenWidth - OPT_WIDTH - 2.0f * MARGIN_SIZE, screenHeight - 2.0f * MARGIN_SIZE),
				new Vector2(0.0f, 0.0f), rotation, scale, colors[activeCol]);

			// Draw options
			DrawRectangle(MARGIN_SIZE, MARGIN_SIZE, OPT_WIDTH - MARGIN_SIZE, screenHeight - 2 * MARGIN_SIZE, ColorAlpha(LIGHTGRAY, 0.5f));

			DrawText("Select Pattern", 2 + MARGIN_SIZE, 30 + MARGIN_SIZE, 10, BLACK);
			DrawTexture(texPattern, 2 + MARGIN_SIZE, 40 + MARGIN_SIZE, BLACK);
			DrawRectangle(2 + MARGIN_SIZE + (int)recPattern[activePattern].x, 40 + MARGIN_SIZE + (int)recPattern[activePattern].y, (int)recPattern[activePattern].width, (int)recPattern[activePattern].height, ColorAlpha(DARKBLUE, 0.3f));

			DrawText("Select Color", 2 + MARGIN_SIZE, 10 + 256 + MARGIN_SIZE, 10, BLACK);
			for (int i = 0; i < MAX_COLORS; i++)
			{
				DrawRectangleRec(colorRec[i], colors[i]);
				if (activeCol == i) DrawRectangleLinesEx(colorRec[i], 3, ColorAlpha(WHITE, 0.5f));
			}

			DrawText("Scale (UP/DOWN to change)", 2 + MARGIN_SIZE, 80 + 256 + MARGIN_SIZE, 10, BLACK);
			DrawText(TextFormat("%.2fx", scale), 2 + MARGIN_SIZE, 92 + 256 + MARGIN_SIZE, 20, BLACK);

			DrawText("Rotation (LEFT/RIGHT to change)", 2 + MARGIN_SIZE, 122 + 256 + MARGIN_SIZE, 10, BLACK);
			DrawText(TextFormat("%.0f degrees", rotation), 2 + MARGIN_SIZE, 134 + 256 + MARGIN_SIZE, 20, BLACK);

			DrawText("Press [SPACE] to reset", 2 + MARGIN_SIZE, 164 + 256 + MARGIN_SIZE, 10, DARKBLUE);

			// Draw FPS
			DrawText(TextFormat("%i FPS", GetFPS()), 2 + MARGIN_SIZE, 2 + MARGIN_SIZE, 20, BLACK);
			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texPattern);        // Unload texture

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}
