// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

/*******************************************************************************************
*
*   raylib [core] example - Picking in 3d mode
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public unsafe static class Picking3d
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [core] example - 3d picking");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new( 10.0f, 10.0f, 10.0f ); // Camera position
		camera.target = new( 0.0f, 0.0f, 0.0f );      // Camera looking at point
		camera.up = new( 0.0f, 1.0f, 0.0f );          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;                   // Camera mode type

		Vector3 cubePosition = new( 0.0f, 1.0f, 0.0f );
		Vector3 cubeSize = new(2.0f, 2.0f, 2.0f );

		Ray ray = new();// { 0 };                    // Picking line ray

		RayCollision collision =new();

		SetCameraMode(camera, CAMERA_FREE); // Set a free camera mode

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(&camera);          // Update camera

			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
			{
				if (!collision.hit)
				{
					ray = GetMouseRay(GetMousePosition(), camera);

					// Check collision between ray and box
					collision = GetRayCollisionBox(ray,
						new BoundingBox(
						new( cubePosition.X - cubeSize.X / 2, cubePosition.Y - cubeSize.Y / 2, cubePosition.Z - cubeSize.Z / 2 ),
										  new( cubePosition.X + cubeSize.X / 2, cubePosition.Y + cubeSize.Y / 2, cubePosition.Z + cubeSize.Z / 2 )
					));
				}
				else collision.hit = false;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			if (collision.hit)
			{
				DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, RED);
				DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, MAROON);

				DrawCubeWires(cubePosition, cubeSize.X + 0.2f, cubeSize.Y + 0.2f, cubeSize.Z + 0.2f, GREEN);
			}
			else
			{
				DrawCube(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, GRAY);
				DrawCubeWires(cubePosition, cubeSize.X, cubeSize.Y, cubeSize.Z, DARKGRAY);
			}

			DrawRay(ray, MAROON);
			DrawGrid(10, 1.0f);

			EndMode3D();

			DrawText("Try selecting the box with mouse!", 240, 10, 20, DARKGRAY);

			if (collision.hit) DrawText("BOX SELECTED", (screenWidth - MeasureText("BOX SELECTED", 30)) / 2, (int)(screenHeight * 0.1f), 30, GREEN);

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

