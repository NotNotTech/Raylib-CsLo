// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

/*******************************************************************************************
*
*   raylib [core] example - quat conversions
*
*   Generally you should really stick to eulers OR quats...
*   This tests that various conversions are equivalent.
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Chris Camacho (@chriscamacho) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2020-2021 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

namespace Raylib_CsLo.Examples.Core;

public unsafe static class QuatConversions
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [core] example - quat conversions");

		Camera3D camera = new();
		camera.position = new( 0.0f, 10.0f, 10.0f );  // Camera position
		camera.target = new( 0.0f, 0.0f, 0.0f );      // Camera looking at point
		camera.up = new( 0.0f, 1.0f, 0.0f );          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		// Load a cylinder model for testing
		Model model = LoadModelFromMesh(GenMeshCylinder(0.2f, 1.0f, 32));

		// Generic quaternion for operations
		Quaternion q1 = new();// = { 0 };

		// Transform matrices required to draw 4 cylinders
		Matrix m1 = new();// = { 0 };
		Matrix m2 = new();// = { 0 };
		Matrix m3 = new();// = { 0 };
		Matrix m4 = new();// = { 0 };

		// Generic vectors for rotations
		Vector3 v1=new();// = { 0 };
		Vector3 v2 = new();// = { 0 };

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//--------------------------------------------------------------------------------------
			if (v2.X < 0) v2.X += PI * 2;
			if (v2.Y < 0) v2.Y += PI * 2;
			if (v2.Z < 0) v2.Z += PI * 2;

			if (!IsKeyDown(KEY_SPACE))
			{
				v1.X += 0.01f;
				v1.Y += 0.03f;
				v1.Z += 0.05f;
			}

			if (v1.X > PI * 2) v1.X -= PI * 2;
			if (v1.Y > PI * 2) v1.Y -= PI * 2;
			if (v1.Z > PI * 2) v1.Z -= PI * 2;


			//q1 = QuaternionFromEuler(v1.X, v1.Y, v1.Z);
			q1 = Quaternion.CreateFromYawPitchRoll(v1.X, v1.Y, v1.Z);
			//m1 = MatrixRotateZYX(v1);
			m1 = Matrix.CreateFromYawPitchRoll(v1.X,v1.Y,v1.Z);
			//m2 = QuaternionToMatrix(q1);
			m2 = Matrix.CreateFromQuaternion(q1);

			//q1 = QuaternionFromMatrix(m1);
			q1 = Quaternion.CreateFromRotationMatrix(m1);

			//m3 = QuaternionToMatrix(q1);
			m3 = Matrix.CreateFromQuaternion(q1);


			//v2 = QuaternionToEuler(q1);     // Angles returned in radians
			v2 = q1.CreateYawPitchRoll();

			//m4 = MatrixRotateZYX(v2);
			m4 = Matrix.CreateFromYawPitchRoll(v2.X, v2.Y, v2.Z);

			//--------------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			model.transform = Matrix.Transpose(m1);
			DrawModel(model, new( -1, 0, 0 ), 1.0f, RED);

			model.transform = Matrix.Transpose(m2);
			DrawModel(model, new( 1, 0, 0 ), 1.0f, RED);

			model.transform = Matrix.Transpose(m3);
			DrawModel(model, new( 0, 0, 0 ), 1.0f, RED);

			model.transform = Matrix.Transpose(m4);
			DrawModel(model, new( 0, 0, -1 ), 1.0f, RED);

			DrawGrid(10, 1.0f);

			EndMode3D();

			DrawText(TextFormat("%2.3f", v1.X), 20, 20, 20, (v1.X == v2.X) ? GREEN : BLACK);
			DrawText(TextFormat("%2.3f", v1.Y), 20, 40, 20, (v1.Y == v2.Y) ? GREEN : BLACK);
			DrawText(TextFormat("%2.3f", v1.Z), 20, 60, 20, (v1.Z == v2.Z) ? GREEN : BLACK);

			DrawText(TextFormat("%2.3f", v2.X), 200, 20, 20, (v1.X == v2.X) ? GREEN : BLACK);
			DrawText(TextFormat("%2.3f", v2.Y), 200, 40, 20, (v1.Y == v2.Y) ? GREEN : BLACK);
			DrawText(TextFormat("%2.3f", v2.Z), 200, 60, 20, (v1.Z == v2.Z) ? GREEN : BLACK);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadModel(model);   // Unload model data (mesh and materials)

		CloseWindow();        // Close window and OpenGL context
							  //--------------------------------------------------------------------------------------

		return 0;
	}
}

