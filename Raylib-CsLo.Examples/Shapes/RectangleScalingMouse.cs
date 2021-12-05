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

namespace Raylib_CsLo.Examples.Shapes;

/*******************************************************************************************
*
*   raylib [shapes] example - rectangle scaling by mouse
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class RectangleScalingMouse
{

	const int MOUSE_SCALE_MARK_SIZE = 12;

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - rectangle scaling mouse");

		Rectangle rec = new Rectangle(100, 100, 200, 80);

		Vector2 mousePosition = new Vector2(0);

		bool mouseScaleReady = false;
		bool mouseScaleMode = false;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			mousePosition = GetMousePosition();

			if (CheckCollisionPointRec(mousePosition, rec) &&
				CheckCollisionPointRec(mousePosition, new Rectangle(rec.X + rec.width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.height - MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE)))
			{
				mouseScaleReady = true;
				if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT)) mouseScaleMode = true;
			}
			else mouseScaleReady = false;

			if (mouseScaleMode)
			{
				mouseScaleReady = true;

				rec.width = (mousePosition.X - rec.X);
				rec.height = (mousePosition.Y - rec.Y);

				if (rec.width < MOUSE_SCALE_MARK_SIZE) rec.width = MOUSE_SCALE_MARK_SIZE;
				if (rec.height < MOUSE_SCALE_MARK_SIZE) rec.height = MOUSE_SCALE_MARK_SIZE;

				if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT)) mouseScaleMode = false;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawText("Scale rectangle dragging from bottom-right corner!", 10, 10, 20, GRAY);

			DrawRectangleRec(rec, Fade(GREEN, 0.5f));

			if (mouseScaleReady)
			{
				DrawRectangleLinesEx(rec, 1, RED);
				DrawTriangle(new Vector2(rec.X + rec.width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.height),
							 new Vector2(rec.X + rec.width, rec.Y + rec.height),
							 new Vector2(rec.X + rec.width, rec.Y + rec.height - MOUSE_SCALE_MARK_SIZE), RED);
			}

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
