// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Detect basic 3d collisions(box vs sphere vs box)
//*
//* This example has been created using raylib 1.3 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2015 Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public unsafe static class BoxCollisions
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - box collisions");

		// Define the camera to look into our 3d world
		Camera camera = new(new(0.0f, 10.0f, 10.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		Vector3 playerPosition = new(0.0f, 1.0f, 2.0f);
		Vector3 playerSize = new(1.0f, 2.0f, 1.0f);
		Color playerColor = GREEN;

		Vector3 enemyBoxPos = new(-4.0f, 1.0f, 0.0f);
		Vector3 enemyBoxSize = new(2.0f, 2.0f, 2.0f);

		Vector3 enemySpherePos = new(4.0f, 0.0f, 0.0f);
		float enemySphereSize = 1.5f;

		bool collision = false;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------

			// Move player
			if (IsKeyDown(KEY_RIGHT)) playerPosition.X += 0.2f;
			else if (IsKeyDown(KEY_LEFT)) playerPosition.X -= 0.2f;
			else if (IsKeyDown(KEY_DOWN)) playerPosition.Z += 0.2f;
			else if (IsKeyDown(KEY_UP)) playerPosition.Z -= 0.2f;

			collision = false;

			// Check collisions player vs enemy-box
			if (CheckCollisionBoxes(
				new(
					new(
						playerPosition.X - playerSize.X / 2,
						playerPosition.Y - playerSize.Y / 2,
						playerPosition.Z - playerSize.Z / 2),
					new(
						playerPosition.X + playerSize.X / 2,
						playerPosition.Y + playerSize.Y / 2,
						playerPosition.Z + playerSize.Z / 2)
				),
				new(
					new(
						enemyBoxPos.X - enemyBoxSize.X / 2,
						enemyBoxPos.Y - enemyBoxSize.Y / 2,
						enemyBoxPos.Z - enemyBoxSize.Z / 2),
					new(
						enemyBoxPos.X + enemyBoxSize.X / 2,
						enemyBoxPos.Y + enemyBoxSize.Y / 2,
						enemyBoxPos.Z + enemyBoxSize.Z / 2)
				))) collision = true;

			// Check collisions player vs enemy-sphere
			if (CheckCollisionBoxSphere(
				new(
				new(
					playerPosition.X - playerSize.X / 2,
										 playerPosition.Y - playerSize.Y / 2,
										 playerPosition.Z - playerSize.Z / 2),
							  new(
					playerPosition.X + playerSize.X / 2,
										 playerPosition.Y + playerSize.Y / 2,
										 playerPosition.Z + playerSize.Z / 2)
			),
				enemySpherePos, enemySphereSize)) collision = true;

			if (collision) playerColor = RED;
			else playerColor = GREEN;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			// Draw enemy-box
			DrawCube(enemyBoxPos, enemyBoxSize.X, enemyBoxSize.Y, enemyBoxSize.Z, GRAY);
			DrawCubeWires(enemyBoxPos, enemyBoxSize.X, enemyBoxSize.Y, enemyBoxSize.Z, DARKGRAY);

			// Draw enemy-sphere
			DrawSphere(enemySpherePos, enemySphereSize, GRAY);
			DrawSphereWires(enemySpherePos, enemySphereSize, 16, 16, DARKGRAY);

			// Draw player
			DrawCubeV(playerPosition, playerSize, playerColor);

			DrawGrid(10, 1.0f);        // Draw a grid

			EndMode3D();

			DrawText("Move player with cursors to collide", 220, 40, 20, GRAY);

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
