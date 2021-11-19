// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©? Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

/*******************************************************************************************
*
*   raylib [models] example - Load 3d model with animations and play them
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Culacant (@culacant) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Culacant (@culacant) and Ramon Santamaria (@raysan5)
*
********************************************************************************************
*
* To export a model from blender, make sure it is not posed, the vertices need to be in the
* same position as they would be in edit mode.
* and that the scale of your models is set to 0. Scaling can be done from the export menu.
*
********************************************************************************************/
namespace Raylib_CsLo.Examples.Models;

public unsafe static class Animation
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - model animation");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
		camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
		camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		Model model = LoadModel("resources/models/iqm/guy.iqm");                    // Load the animated model mesh and basic data
		Texture2D texture = LoadTexture("resources/models/iqm/guytex.png");         // Load model texture and set material
		SetMaterialTexture(&model.materials[0], MATERIAL_MAP_DIFFUSE, texture);     // Set model material map texture

		Vector3 position = new(0.0f, 0.0f, 0.0f);            // Set model position

		// Load animation data
		uint animsCount = 0;
		ModelAnimation[] anims = LoadModelAnimations("resources/models/iqm/guyanim.iqm");
		int animFrameCounter = 0;

		SetCameraMode(camera, CAMERA_FREE); // Set free camera mode

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);

			// Play animation when spacebar is held down
			if (IsKeyDown(KEY_SPACE))
			{
				animFrameCounter++;
				UpdateModelAnimation(model, anims[0], animFrameCounter);
				if (animFrameCounter >= anims[0].frameCount) animFrameCounter = 0;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModelEx(model, position, new(1.0f, 0.0f, 0.0f), -90.0f, new(1.0f, 1.0f, 1.0f), WHITE);

			for (int i = 0; i < model.boneCount; i++)
			{
				DrawCube(anims[0].framePoses[animFrameCounter][i].translation, 0.2f, 0.2f, 0.2f, RED);
			}

			DrawGrid(10, 1.0f);         // Draw a grid

			EndMode3D();

			DrawText("PRESS SPACE to PLAY MODEL ANIMATION", 10, 10, 20, MAROON);
			DrawText("(c) Guy IQM 3D model by @culacant", screenWidth - 200, screenHeight - 20, 10, GRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texture);     // Unload texture

		// Unload model animations data
		for (uint i = 0; i < animsCount; i++) UnloadModelAnimation(anims[i]);
		//MemFree
		//RL_FREE(anims);

		UnloadModel(model);         // Unload model

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}

}





/*******************************************************************************************
*
*   raylib [models] example - Drawing billboards
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class Billboard
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - drawing billboards");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(5.0f, 4.0f, 5.0f);
		camera.target = new(0.0f, 2.0f, 0.0f);
		camera.up = new(0.0f, 1.0f, 0.0f);
		camera.fovy = 45.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		Texture2D bill = LoadTexture("resources/billboard.png");     // Our texture billboard
		Vector3 billPosition = new(0.0f, 2.0f, 0.0f);                 // Position where draw billboard

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);              // Update camera
												   //----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawGrid(10, 1.0f);        // Draw a grid

			DrawBillboard(camera, bill, billPosition, 2.0f, WHITE);

			EndMode3D();

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(bill);        // Unload texture

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}

/*******************************************************************************************
*
*   raylib [models] example - Detect basic 3d collisions (box vs sphere vs box)
*
*   This example has been created using raylib 1.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


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


/*******************************************************************************************
*
*   raylib [models] example - Cubicmap loading and drawing
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class Cubicmap
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - cubesmap loading and drawing");

		// Define the camera to look into our 3d world
		Camera camera = new(new(16.0f, 14.0f, 16.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		Image image = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
		Texture2D cubicmap = LoadTextureFromImage(image);       // Convert image to texture to display (VRAM)

		Mesh mesh = GenMeshCubicmap(image, new(1.0f, 1.0f, 1.0f));
		Model model = LoadModelFromMesh(mesh);

		// NOTE: By default each cube is mapped to one part of texture atlas
		Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;             // Set map diffuse texture

		Vector3 mapPosition = new(-16.0f, 0.0f, -8.0f);          // Set model position

		UnloadImage(image);     // Unload cubesmap image from RAM, already uploaded to VRAM

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);              // Update camera
												   //----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModel(model, mapPosition, 1.0f, WHITE);

			EndMode3D();

			DrawTextureEx(cubicmap, new(
				screenWidth - cubicmap.width * 4.0f - 20, 20.0f), 0.0f, 4.0f, WHITE);
			DrawRectangleLines(screenWidth - cubicmap.width * 4 - 20, 20, cubicmap.width * 4, cubicmap.height * 4, GREEN);

			DrawText("cubicmap image used to", 658, 90, 10, GRAY);
			DrawText("generate map 3d model", 658, 104, 10, GRAY);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(cubicmap);    // Unload cubicmap texture
		UnloadTexture(texture);     // Unload map texture
		UnloadModel(model);         // Unload map model

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}

}

/*******************************************************************************************
*
*   raylib [models] example - first person maze
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class FirstPersonMaze
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - first person maze");

		// Define the camera to look into our 3d world
		Camera camera = new(new(0.2f, 0.4f, 0.2f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		Image imMap = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
		Texture2D cubicmap = LoadTextureFromImage(imMap);       // Convert image to texture to display (VRAM)
		Mesh mesh = GenMeshCubicmap(imMap, new(1.0f, 1.0f, 1.0f));
		Model model = LoadModelFromMesh(mesh);

		// NOTE: By default each cube is mapped to one part of texture atlas
		Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;             // Set map diffuse texture

		// Get map image data to be used for collision detection
		Color* mapPixels = LoadImageColors(imMap);
		UnloadImage(imMap);             // Unload image from RAM

		Vector3 mapPosition = new(-16.0f, 0.0f, -8.0f);  // Set model position

		SetCameraMode(camera, CAMERA_FIRST_PERSON);     // Set camera mode

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			Vector3 oldCamPos = camera.position;    // Store old camera position

			UpdateCamera(ref camera);      // Update camera

			// Check player collision (we simplify to 2D collision detection)
			Vector2 playerPos = new(camera.position.X, camera.position.Z);
			float playerRadius = 0.1f;  // Collision radius (player is modelled as a cilinder for collision)

			int playerCellX = (int)(playerPos.X - mapPosition.X + 0.5f);
			int playerCellY = (int)(playerPos.Y - mapPosition.Z + 0.5f);

			// Out-of-limits security check
			if (playerCellX < 0) playerCellX = 0;
			else if (playerCellX >= cubicmap.width) playerCellX = cubicmap.width - 1;

			if (playerCellY < 0) playerCellY = 0;
			else if (playerCellY >= cubicmap.height) playerCellY = cubicmap.height - 1;

			// Check map collisions using image data and player position
			// TODO: Improvement: Just check player surrounding cells for collision
			for (int y = 0; y < cubicmap.height; y++)
			{
				for (int x = 0; x < cubicmap.width; x++)
				{
					if ((mapPixels[y * cubicmap.width + x].r == 255) &&       // Collision: white pixel, only check R channel
						(CheckCollisionCircleRec(playerPos, playerRadius,
						new Rectangle(mapPosition.X - 0.5f + x * 1.0f, mapPosition.Z - 0.5f + y * 1.0f, 1.0f, 1.0f))))
					{
						// Collision detected, reset camera position
						camera.position = oldCamPos;
					}
				}
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);
			DrawModel(model, mapPosition, 1.0f, WHITE);                     // Draw maze map
			EndMode3D();

			DrawTextureEx(cubicmap, new(
				GetScreenWidth() - cubicmap.width * 4.0f - 20, 20.0f), 0.0f, 4.0f, WHITE);
			DrawRectangleLines(GetScreenWidth() - cubicmap.width * 4 - 20, 20, cubicmap.width * 4, cubicmap.height * 4, GREEN);

			// Draw player position radar
			DrawRectangle(GetScreenWidth() - cubicmap.width * 4 - 20 + playerCellX * 4, 20 + playerCellY * 4, 4, 4, RED);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadImageColors(mapPixels);   // Unload color array

		UnloadTexture(cubicmap);        // Unload cubicmap texture
		UnloadTexture(texture);         // Unload map texture
		UnloadModel(model);             // Unload map model

		CloseWindow();                  // Close window and OpenGL context
										//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [models] example - Draw some basic geometric shapes (cube, sphere, cylinder...)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class GeometricShapes
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(0.0f, 10.0f, 10.0f);
		camera.target = new(0.0f, 0.0f, 0.0f);
		camera.up = new(0.0f, 1.0f, 0.0f);
		camera.fovy = 45.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

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

			BeginMode3D(camera);

			DrawCube(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, RED);
			DrawCubeWires(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, GOLD);
			DrawCubeWires(new(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, MAROON);

			DrawSphere(new(-1.0f, 0.0f, -2.0f), 1.0f, GREEN);
			DrawSphereWires(new(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, LIME);

			DrawCylinder(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, SKYBLUE);
			DrawCylinderWires(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, DARKBLUE);
			DrawCylinderWires(new(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, BROWN);

			DrawCylinder(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, GOLD);
			DrawCylinderWires(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, PINK);

			DrawGrid(10, 1.0f);        // Draw a grid

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
*   raylib [models] example - Heightmap loading and drawing
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class Heightmap
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - heightmap loading and drawing");

		// Define our custom camera to look into our 3d world
		Camera camera = new(new(18.0f, 18.0f, 18.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		Image image = LoadImage("resources/heightmap.png");             // Load heightmap image (RAM)
		Texture2D texture = LoadTextureFromImage(image);                // Convert image to texture (VRAM)

		Mesh mesh = GenMeshHeightmap(image, new(16, 8, 16));    // Generate heightmap mesh (RAM and VRAM)
		Model model = LoadModelFromMesh(mesh);                          // Load model from generated mesh

		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;         // Set map diffuse texture
		Vector3 mapPosition = new(-8.0f, 0.0f, -8.0f);                   // Define model position

		UnloadImage(image);                     // Unload heightmap image from RAM, already uploaded to VRAM

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);              // Update camera
												   //----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModel(model, mapPosition, 1.0f, RED);

			DrawGrid(20, 1.0f);

			EndMode3D();

			DrawTexture(texture, screenWidth - texture.width - 20, 20, WHITE);
			DrawRectangleLines(screenWidth - texture.width - 20, 20, texture.width, texture.height, GREEN);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texture);     // Unload texture
		UnloadModel(model);         // Unload model

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [models] example - Models loading
*
*   raylib supports multiple models file formats:
*
*     - OBJ  > Text file format. Must include vertex position-texcoords-normals information,
*              if files references some .mtl materials file, it will be loaded (or try to).
*     - GLTF > Text/binary file format. Includes lot of information and it could
*              also reference external files, raylib will try loading mesh and materials data.
*     - IQM  > Binary file format. Includes mesh vertex data but also animation data,
*              raylib can load .iqm animations.
*     - VOX  > Binary file format. MagikaVoxel mesh format:
*              https://github.com/ephtracy/voxel-model/blob/master/MagicaVoxel-file-format-vox.txt
*
*   This example has been created using raylib 4.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014-2021 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class Loading
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - models loading");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(50.0f, 50.0f, 50.0f); // Camera position
		camera.target = new(0.0f, 10.0f, 0.0f);     // Camera looking at point
		camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;                   // Camera mode type

		Model model = LoadModel("resources/models/obj/castle.obj");                 // Load model
		Texture2D texture = LoadTexture("resources/models/obj/castle_diffuse.png"); // Load model texture
		model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;            // Set map diffuse texture

		Vector3 position = new(0.0f, 0.0f, 0.0f);                    // Set model position

		BoundingBox bounds = GetMeshBoundingBox(model.meshes[0]);   // Set model bounds

		// NOTE: bounds are calculated from the original size of the model,
		// if model is scaled on drawing, bounds must be also scaled

		SetCameraMode(camera, CAMERA_FREE);     // Set a free camera mode

		bool selected = false;          // Selected object flag

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);

			// Load new models/textures on drag&drop
			if (IsFileDropped())
			{
				int count = 0;
				//char** droppedFiles = GetDroppedFiles(&count);
				var droppedFiles = GetDroppedFiles();

				if (count == 1) // Only support one file dropped
				{
					if (droppedFiles[0].EndsWith(".obj") ||
						droppedFiles[0].EndsWith(".gltf") ||
						droppedFiles[0].EndsWith(".glb") ||
						droppedFiles[0].EndsWith(".vox") ||
						droppedFiles[0].EndsWith(".iqm"))       // Model file formats supported
					{
						UnloadModel(model);                     // Unload previous model
						model = LoadModel(droppedFiles[0]);     // Load new model
						model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture; // Set current map diffuse texture

						bounds = GetMeshBoundingBox(model.meshes[0]);

						// TODO: Move camera position from target enough distance to visualize model properly
					}
					else if (droppedFiles[0].EndsWith(".png"))  // Texture file formats supported
					{
						// Unload current model texture and load new one
						UnloadTexture(texture);
						texture = LoadTexture(droppedFiles[0]);
						model.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;
					}
				}

				ClearDroppedFiles();    // Clear internal buffers
			}

			// Select model on mouse click
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
			{
				// Check collision between ray and box
				if (GetRayCollisionBox(GetMouseRay(GetMousePosition(), camera), bounds).hit) selected = !selected;
				else selected = false;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModel(model, position, 1.0f, WHITE);        // Draw 3d model with texture

			DrawGrid(20, 10.0f);         // Draw a grid

			if (selected) DrawBoundingBox(bounds, GREEN);   // Draw selection box

			EndMode3D();

			DrawText("Drag & drop model to load mesh/texture.", 10, GetScreenHeight() - 20, 10, DARKGRAY);
			if (selected) DrawText("MODEL SELECTED", GetScreenWidth() - 110, 10, 10, GREEN);

			DrawText("(c) Castle 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texture);     // Unload texture
		UnloadModel(model);         // Unload model

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [models] example - Load models gltf
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   NOTE: To export a model from Blender, make sure it is not posed, the vertices need to be
*   in the same position as they would be in edit mode.
*   Also make sure the scale parameter of your models is set to 0.0,
*   scaling can be applied from the export menu.
*
*   Example contributed by Hristo Stamenov (@object71) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Hristo Stamenov (@object71) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/



public unsafe static class LoadingGltf
{
	const int MAX_GLTF_MODELS = 8;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - model");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
		camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
		camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		// Load some models
		Model[] model = new Model[MAX_GLTF_MODELS];
		model[0] = LoadModel("resources/models/gltf/raylib_32x32.glb");
		model[1] = LoadModel("resources/models/gltf/rigged_figure.glb");
		model[2] = LoadModel("resources/models/gltf/GearboxAssy.glb");
		model[3] = LoadModel("resources/models/gltf/BoxAnimated.glb");
		model[4] = LoadModel("resources/models/gltf/AnimatedTriangle.gltf");
		model[5] = LoadModel("resources/models/gltf/AnimatedMorphCube.glb");
		model[6] = LoadModel("resources/models/gltf/vertex_colored_object.glb");
		model[7] = LoadModel("resources/models/gltf/girl.glb");

		int currentModel = 0;

		Vector3 position = new(0.0f, 0.0f, 0.0f);    // Set model position

		SetCameraMode(camera, CAMERA_FREE); // Set free camera mode

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);          // Update our camera with inputs

			if (IsKeyReleased(KEY_RIGHT))
			{
				currentModel++;
				if (currentModel == MAX_GLTF_MODELS) currentModel = 0;
			}

			if (IsKeyReleased(KEY_LEFT))
			{
				currentModel--;
				if (currentModel < 0) currentModel = MAX_GLTF_MODELS - 1;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(SKYBLUE);

			BeginMode3D(camera);

			DrawModel(model[currentModel], position, 1.0f, WHITE);
			DrawGrid(10, 1.0f);         // Draw a grid

			EndMode3D();

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		for (int i = 0; i < MAX_GLTF_MODELS; i++) UnloadModel(model[i]);  // Unload models

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}



/*******************************************************************************************
*
*   raylib [models] example - Load models vox (MagicaVoxel)
*
*   This example has been created using raylib 4.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Johann Nadalutti (@procfxgen) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2021 Johann Nadalutti (@procfxgen) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class LoadingVox
{
	const int MAX_VOX_FILES = 3;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		string[] voxFileNames = new string[MAX_VOX_FILES] {
		"resources/models/vox/chr_knight.vox",
		"resources/models/vox/chr_sword.vox",
		"resources/models/vox/monu9.vox"
	};
		InitWindow(screenWidth, screenHeight, "raylib [models] example - magicavoxel loading");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(10.0f, 10.0f, 10.0f); // Camera position
		camera.target = new(0.0f, 0.0f, 0.0f);      // Camera looking at point
		camera.up = new(0.0f, 1.0f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		// Load MagicaVoxel files
		Model[] models = new Model[MAX_VOX_FILES];

		for (int i = 0; i < MAX_VOX_FILES; i++)
		{
			// Load VOX file and measure time
			double t0 = GetTime() * 1000.0;
			models[i] = LoadModel(voxFileNames[i]);
			double t1 = GetTime() * 1000.0;

			TraceLog(LOG_WARNING, TextFormat("[%s] File loaded in %.3f ms", voxFileNames[i], t1 - t0));

			// Compute model translation matrix to center model on draw position (0, 0 , 0)
			BoundingBox bb = GetModelBoundingBox(models[i]);
			Vector3 center = new();
			center.X = bb.min.X + (((bb.max.X - bb.min.X) / 2));
			center.Z = bb.min.Z + (((bb.max.Z - bb.min.Z) / 2));

			Matrix matTranslate = Matrix4x4.CreateTranslation(-center.X, 0, -center.Z);
			models[i].transform =Matrix4x4.Transpose(matTranslate);
		}

		int currentModel = 0;

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set a orbital camera mode

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);      // Update our camera to orbit

			// Cycle between models on mouse click
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT)) currentModel = (currentModel + 1) % MAX_VOX_FILES;

			// Cycle between models on key pressed
			if (IsKeyPressed(KEY_RIGHT))
			{
				currentModel++;
				if (currentModel >= MAX_VOX_FILES) currentModel = 0;
			}
			else if (IsKeyPressed(KEY_LEFT))
			{
				currentModel--;
				if (currentModel < 0) currentModel = MAX_VOX_FILES - 1;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			// Draw 3D model
			BeginMode3D(camera);

			DrawModel(models[currentModel], new(0, 0, 0), 1.0f, WHITE);
			DrawGrid(10, 1.0);

			EndMode3D();

			// Display info
			DrawRectangle(10, 400, 310, 30, Fade(SKYBLUE, 0.5f));
			DrawRectangleLines(10, 400, 310, 30, Fade(DARKBLUE, 0.5f));
			DrawText("MOUSE LEFT BUTTON to CYCLE VOX MODELS", 40, 410, 10, BLUE);
			DrawText(TextFormat("File: %s", GetFileName(voxFileNames[currentModel])), 10, 10, 20, GRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		// Unload models data (GPU VRAM)
		for (int i = 0; i < MAX_VOX_FILES; i++) UnloadModel(models[i]);

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}


}

/*******************************************************************************************
*
*   raylib example - procedural mesh generation
*
*   This example has been created using raylib 1.8 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (Ray San)
*
********************************************************************************************/

public unsafe static class MeshGeneration
{
	const int NUM_MODELS = 9;      // Parametric 3d shapes to generate


	static void AllocateMeshData(Mesh* mesh, int triangleCount)
	{
		mesh->vertexCount = triangleCount * 3;
		mesh->triangleCount = triangleCount;

		mesh->vertices = (float*)MemAlloc(mesh->vertexCount * 3 * sizeof(float));
		mesh->texcoords = (float*)MemAlloc(mesh->vertexCount * 2 * sizeof(float));
		mesh->normals = (float*)MemAlloc(mesh->vertexCount * 3 * sizeof(float));
	}

	// generate a simple triangle mesh from code
	static Mesh MakeMesh()
	{
		Mesh mesh = new();
		AllocateMeshData(&mesh, 1);

		// vertex at the origin
		mesh.vertices[0] = 0;
		mesh.vertices[1] = 0;
		mesh.vertices[2] = 0;
		mesh.normals[0] = 0;
		mesh.normals[1] = 1;
		mesh.normals[2] = 0;
		mesh.texcoords[0] = 0;
		mesh.texcoords[1] = 0;

		// vertex at 1,0,2
		mesh.vertices[3] = 1;
		mesh.vertices[4] = 0;
		mesh.vertices[5] = 2;
		mesh.normals[3] = 0;
		mesh.normals[4] = 1;
		mesh.normals[5] = 0;
		mesh.texcoords[2] = 0.5f;
		mesh.texcoords[3] = 1.0f;

		// vertex at 2,0,0
		mesh.vertices[6] = 2;
		mesh.vertices[7] = 0;
		mesh.vertices[8] = 0;
		mesh.normals[6] = 0;
		mesh.normals[7] = 1;
		mesh.normals[8] = 0;
		mesh.texcoords[4] = 1;
		mesh.texcoords[5] = 0;

		UploadMesh(&mesh, false);

		return mesh;
	}
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh generation");

		// We generate a checked image for texturing
		Image checkedImage = GenImageChecked(2, 2, 1, 1, RED, GREEN);
		Texture2D texture = LoadTextureFromImage(checkedImage);
		UnloadImage(checkedImage);

		Model[] models = new Model[NUM_MODELS];

		models[0] = LoadModelFromMesh(GenMeshPlane(2, 2, 5, 5));
		models[1] = LoadModelFromMesh(GenMeshCube(2.0f, 1.0f, 2.0f));
		models[2] = LoadModelFromMesh(GenMeshSphere(2, 32, 32));
		models[3] = LoadModelFromMesh(GenMeshHemiSphere(2, 16, 16));
		models[4] = LoadModelFromMesh(GenMeshCylinder(1, 2, 16));
		models[5] = LoadModelFromMesh(GenMeshTorus(0.25f, 4.0f, 16, 32));
		models[6] = LoadModelFromMesh(GenMeshKnot(1.0f, 2.0f, 16, 128));
		models[7] = LoadModelFromMesh(GenMeshPoly(5, 2.0f));
		models[8] = LoadModelFromMesh(MakeMesh());

		// Set checkedImage texture as default diffuse component for all models material
		for (int i = 0; i < NUM_MODELS; i++) models[i].materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;

		// Define the camera to look into our 3d world
		Camera camera = new(new(5.0f, 5.0f, 5.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		// Model drawing position
		Vector3 position = new(0.0f, 0.0f, 0.0f);

		int currentModel = 0;

		SetCameraMode(camera, CAMERA_ORBITAL);  // Set a orbital camera mode

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);      // Update internal camera and our camera

			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
			{
				currentModel = (currentModel + 1) % NUM_MODELS; // Cycle between the textures
			}

			if (IsKeyPressed(KEY_RIGHT))
			{
				currentModel++;
				if (currentModel >= NUM_MODELS) currentModel = 0;
			}
			else if (IsKeyPressed(KEY_LEFT))
			{
				currentModel--;
				if (currentModel < 0) currentModel = NUM_MODELS - 1;
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawModel(models[currentModel], position, 1.0f, WHITE);
			DrawGrid(10, 1.0);

			EndMode3D();

			DrawRectangle(30, 400, 310, 30, Fade(SKYBLUE, 0.5f));
			DrawRectangleLines(30, 400, 310, 30, Fade(DARKBLUE, 0.5f));
			DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL MODELS", 40, 410, 10, BLUE);

			switch (currentModel)
			{
				case 0: DrawText("PLANE", 680, 10, 20, DARKBLUE); break;
				case 1: DrawText("CUBE", 680, 10, 20, DARKBLUE); break;
				case 2: DrawText("SPHERE", 680, 10, 20, DARKBLUE); break;
				case 3: DrawText("HEMISPHERE", 640, 10, 20, DARKBLUE); break;
				case 4: DrawText("CYLINDER", 680, 10, 20, DARKBLUE); break;
				case 5: DrawText("TORUS", 680, 10, 20, DARKBLUE); break;
				case 6: DrawText("KNOT", 680, 10, 20, DARKBLUE); break;
				case 7: DrawText("POLY", 680, 10, 20, DARKBLUE); break;
				case 8: DrawText("Parametric(custom)", 580, 10, 20, DARKBLUE); break;
				default: break;
			}

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadTexture(texture); // Unload texture

		// Unload models data (GPU VRAM)
		for (int i = 0; i < NUM_MODELS; i++) UnloadModel(models[i]);

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}
}





/*******************************************************************************************
*
*   raylib [models] example - Mesh picking in 3d mode, ground plane, triangle, mesh
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Joel Davis (@joeld42) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2017 Joel Davis (@joeld42) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class MeshPicking
{
	//#define FLT_MAX     340282346638528859811704183484516925440.0f     // Maximum value of a float, from bit pattern 01111111011111111111111111111111
	const float FLT_MAX = float.MaxValue;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh picking");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(20.0f, 20.0f, 20.0f); // Camera position
		camera.target = new(0.0f, 8.0f, 0.0f);      // Camera looking at point
		camera.up = new(0.0f, 1.6f, 0.0f);          // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;             // Camera mode type

		Ray ray = new();        // Picking ray

		Model tower = LoadModel("resources/models/obj/turret.obj");                 // Load OBJ model
		Texture2D texture = LoadTexture("resources/models/obj/turret_diffuse.png"); // Load model texture
		tower.materials[0].maps[(int)MATERIAL_MAP_DIFFUSE].texture = texture;            // Set model diffuse texture

		Vector3 towerPos = new(0.0f, 0.0f, 0.0f);                        // Set model position
		BoundingBox towerBBox = GetMeshBoundingBox(tower.meshes[0]);    // Get mesh bounding box

		// Ground quad
		Vector3 g0 = new(-50.0f, 0.0f, -50.0f);
		Vector3 g1 = new(-50.0f, 0.0f, 50.0f);
		Vector3 g2 = new(50.0f, 0.0f, 50.0f);
		Vector3 g3 = new(50.0f, 0.0f, -50.0f);

		// Test triangle
		Vector3 ta = new(-25.0f, 0.5f, 0.0f);
		Vector3 tb = new(-4.0f, 2.5f, 1.0f);
		Vector3 tc = new(-8.0f, 6.5f, 0.0f);

		Vector3 bary = new(0.0f, 0.0f, 0.0f);

		// Test sphere
		Vector3 sp = new(-30.0f, 5.0f, 5.0f);
		float sr = 4.0f;

		SetCameraMode(camera, CAMERA_FREE); // Set a free camera mode

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------
											// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);          // Update camera

			// Display information about closest hit
			RayCollision collision = new();
			string hitObjectName = "None";
			collision.distance = FLT_MAX;
			collision.hit = false;
			Color cursorColor = WHITE;

			// Get ray and test against objects
			ray = GetMouseRay(GetMousePosition(), camera);

			// Check ray collision against ground quad
			RayCollision groundHitInfo = GetRayCollisionQuad(ray, g0, g1, g2, g3);

			if ((groundHitInfo.hit) && (groundHitInfo.distance < collision.distance))
			{
				collision = groundHitInfo;
				cursorColor = GREEN;
				hitObjectName = "Ground";
			}

			// Check ray collision against test triangle
			RayCollision triHitInfo = GetRayCollisionTriangle(ray, ta, tb, tc);

			if ((triHitInfo.hit) && (triHitInfo.distance < collision.distance))
			{
				collision = triHitInfo;
				cursorColor = PURPLE;
				hitObjectName = "Triangle";

				bary = Vector3Barycenter(collision.point, ta, tb, tc);
			}

			// Check ray collision against test sphere
			RayCollision sphereHitInfo = GetRayCollisionSphere(ray, sp, sr);

			if ((sphereHitInfo.hit) && (sphereHitInfo.distance < collision.distance))
			{
				collision = sphereHitInfo;
				cursorColor = ORANGE;
				hitObjectName = "Sphere";
			}

			// Check ray collision against bounding box first, before trying the full ray-mesh test
			RayCollision boxHitInfo = GetRayCollisionBox(ray, towerBBox);

			if ((boxHitInfo.hit) && (boxHitInfo.distance < collision.distance))
			{
				collision = boxHitInfo;
				cursorColor = ORANGE;
				hitObjectName = "Box";

				// Check ray collision against model
				// NOTE: It considers model.transform matrix!
				RayCollision meshHitInfo = GetRayCollisionModel(ray, tower);

				if (meshHitInfo.hit)
				{
					collision = meshHitInfo;
					cursorColor = ORANGE;
					hitObjectName = "Mesh";
				}
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			// Draw the tower
			// WARNING: If scale is different than 1.0f,
			// not considered by GetRayCollisionModel()
			DrawModel(tower, towerPos, 1.0f, WHITE);

			// Draw the test triangle
			DrawLine3D(ta, tb, PURPLE);
			DrawLine3D(tb, tc, PURPLE);
			DrawLine3D(tc, ta, PURPLE);

			// Draw the test sphere
			DrawSphereWires(sp, sr, 8, 8, PURPLE);

			// Draw the mesh bbox if we hit it
			if (boxHitInfo.hit) DrawBoundingBox(towerBBox, LIME);

			// If we hit something, draw the cursor at the hit point
			if (collision.hit)
			{
				DrawCube(collision.point, 0.3f, 0.3f, 0.3f, cursorColor);
				DrawCubeWires(collision.point, 0.3f, 0.3f, 0.3f, RED);

				Vector3 normalEnd;
				normalEnd.X = collision.point.X + collision.normal.X;
				normalEnd.Y = collision.point.Y + collision.normal.Y;
				normalEnd.Z = collision.point.Z + collision.normal.Z;

				DrawLine3D(collision.point, normalEnd, RED);
			}

			DrawRay(ray, MAROON);

			DrawGrid(10, 10.0f);

			EndMode3D();

			// Draw some debug GUI text
			DrawText(TextFormat("Hit Object: %s", hitObjectName), 10, 50, 10, BLACK);

			if (collision.hit)
			{
				int ypos = 70;

				DrawText(TextFormat("Distance: %3.2f", collision.distance), 10, ypos, 10, BLACK);

				DrawText(TextFormat("Hit Pos: %3.2f %3.2f %3.2f",
									collision.point.X,
									collision.point.Y,
									collision.point.Z), 10, ypos + 15, 10, BLACK);

				DrawText(TextFormat("Hit Norm: %3.2f %3.2f %3.2f",
									collision.normal.X,
									collision.normal.Y,
									collision.normal.Z), 10, ypos + 30, 10, BLACK);

				if (triHitInfo.hit && TextIsEqual(hitObjectName, "Triangle"))
					DrawText(TextFormat("Barycenter: %3.2f %3.2f %3.2f", bary.X, bary.Y, bary.Z), 10, ypos + 45, 10, BLACK);
			}

			DrawText("Use Mouse to Move Camera", 10, 430, 10, GRAY);

			DrawText("(c) Turret 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadModel(tower);         // Unload model
		UnloadTexture(texture);     // Unload texture

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}
/*******************************************************************************************
*
*   raylib [models] example - Show the difference between perspective and orthographic projection
*
*   This program is heavily based on the geometric objects example
*
*   This example has been created using raylib 2.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Max Danielsson (@autious) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Max Danielsson (@autious) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/


public unsafe static class OrthographicProjection
{
	const float FOVY_PERSPECTIVE = 45.0f;
	const float WIDTH_ORTHOGRAPHIC = 10.0f;
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

		// Define the camera to look into our 3d world
		Camera camera = new(new(0.0f, 10.0f, 10.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), FOVY_PERSPECTIVE, CAMERA_PERSPECTIVE);

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			if (IsKeyPressed(KEY_SPACE))
			{
				if (camera.projection_ == CAMERA_PERSPECTIVE)
				{
					camera.fovy = WIDTH_ORTHOGRAPHIC;
					camera.projection_ = CAMERA_ORTHOGRAPHIC;
				}
				else
				{
					camera.fovy = FOVY_PERSPECTIVE;
					camera.projection_ = CAMERA_PERSPECTIVE;
				}
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			DrawCube(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, RED);
			DrawCubeWires(new(-4.0f, 0.0f, 2.0f), 2.0f, 5.0f, 2.0f, GOLD);
			DrawCubeWires(new(-4.0f, 0.0f, -2.0f), 3.0f, 6.0f, 2.0f, MAROON);

			DrawSphere(new(-1.0f, 0.0f, -2.0f), 1.0f, GREEN);
			DrawSphereWires(new(1.0f, 0.0f, 2.0f), 2.0f, 16, 16, LIME);

			DrawCylinder(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, SKYBLUE);
			DrawCylinderWires(new(4.0f, 0.0f, -2.0f), 1.0f, 2.0f, 3.0f, 4, DARKBLUE);
			DrawCylinderWires(new(4.5f, -1.0f, 2.0f), 1.0f, 1.0f, 2.0f, 6, BROWN);

			DrawCylinder(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, GOLD);
			DrawCylinderWires(new(1.0f, 0.0f, -4.0f), 0.0f, 1.5f, 3.0f, 8, PINK);

			DrawGrid(10, 1.0f);        // Draw a grid

			EndMode3D();

			DrawText("Press Spacebar to switch camera type", 10, GetScreenHeight() - 30, 20, DARKGRAY);

			if (camera.projection_ == CAMERA_ORTHOGRAPHIC) DrawText("ORTHOGRAPHIC", 10, 40, 20, BLACK);
			else if (camera.projection_ == CAMERA_PERSPECTIVE) DrawText("PERSPECTIVE", 10, 40, 20, BLACK);

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
*   raylib [models] example - rlgl module usage with push/pop matrix transformations
*
*   This example uses [rlgl] module funtionality (pseudo-OpenGL 1.1 style coding)
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2018 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class RlglSolarSystem
{
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		const float sunRadius = 4.0f;
		const float earthRadius = 0.6f;
		const float earthOrbitRadius = 8.0f;
		const float moonRadius = 0.16f;
		const float moonOrbitRadius = 1.5f;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - rlgl module usage with push/pop matrix transformations");

		// Define the camera to look into our 3d world
		Camera camera = new();
		camera.position = new(16.0f, 16.0f, 16.0f);
		camera.target = new(0.0f, 0.0f, 0.0f);
		camera.up = new(0.0f, 1.0f, 0.0f);
		camera.fovy = 45.0f;
		camera.projection_ = CAMERA_PERSPECTIVE;

		SetCameraMode(camera, CAMERA_FREE);

		float rotationSpeed = 0.2f;         // General system rotation speed

		float earthRotation = 0.0f;         // Rotation of earth around itself (days) in degrees
		float earthOrbitRotation = 0.0f;    // Rotation of earth around the Sun (years) in degrees
		float moonRotation = 0.0f;          // Rotation of moon around itself
		float moonOrbitRotation = 0.0f;     // Rotation of moon around earth in degrees

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);

			earthRotation += (5.0f * rotationSpeed);
			earthOrbitRotation += (365 / 360.0f * (5.0f * rotationSpeed) * rotationSpeed);
			moonRotation += (2.0f * rotationSpeed);
			moonOrbitRotation += (8.0f * rotationSpeed);
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			rlPushMatrix();
			rlScalef(sunRadius, sunRadius, sunRadius);          // Scale Sun
			DrawSphereBasic(GOLD);                              // Draw the Sun
			rlPopMatrix();

			rlPushMatrix();
			rlRotatef(earthOrbitRotation, 0.0f, 1.0f, 0.0f);    // Rotation for Earth orbit around Sun
			rlTranslatef(earthOrbitRadius, 0.0f, 0.0f);         // Translation for Earth orbit

			rlPushMatrix();
			rlRotatef(earthRotation, 0.25f, 1.0f, 0.0f);       // Rotation for Earth itself
			rlScalef(earthRadius, earthRadius, earthRadius);// Scale Earth

			DrawSphereBasic(BLUE);                          // Draw the Earth
			rlPopMatrix();

			rlRotatef(moonOrbitRotation, 0.0f, 1.0f, 0.0f);     // Rotation for Moon orbit around Earth
			rlTranslatef(moonOrbitRadius, 0.0f, 0.0f);          // Translation for Moon orbit
			rlRotatef(moonRotation, 0.0f, 1.0f, 0.0f);          // Rotation for Moon itself
			rlScalef(moonRadius, moonRadius, moonRadius);       // Scale Moon

			DrawSphereBasic(LIGHTGRAY);                         // Draw the Moon
			rlPopMatrix();

			// Some reference elements (not affected by previous matrix transformations)
			DrawCircle3D(new(0.0f, 0.0f, 0.0f), earthOrbitRadius, new(1, 0, 0), 90.0f, Fade(RED, 0.5f));
			DrawGrid(20, 1.0f);

			EndMode3D();

			DrawText("EARTH ORBITING AROUND THE SUN!", 400, 10, 20, MAROON);
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

	//--------------------------------------------------------------------------------------------
	// Module Functions Definitions (local)
	//--------------------------------------------------------------------------------------------

	// Draw sphere without any matrix transformation
	// NOTE: Sphere is drawn in world position ( 0, 0, 0 ) with radius 1.0f
	static void DrawSphereBasic(Color color)
	{
		int rings = 16;
		int slices = 16;

		// Make sure there is enough space in the internal render batch
		// buffer to store all required vertex, batch is reseted if required
		rlCheckRenderBatchLimit((rings + 2) * slices * 6);

		rlBegin(RL_TRIANGLES);
		rlColor4ub(color.r, color.g, color.b, color.a);

		for (int i = 0; i < (rings + 2); i++)
		{
			for (int j = 0; j < slices; j++)
			{
				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Cos(DEG2RAD * (j * 360 / slices)));
				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices)));
				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * (j * 360 / slices)));

				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Sin(DEG2RAD * (j * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * MathF.Cos(DEG2RAD * (j * 360 / slices)));
				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i))),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices)));
				rlVertex3f(MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Sin(DEG2RAD * ((j + 1) * 360 / slices)),
						   MathF.Sin(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
						   MathF.Cos(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * MathF.Cos(DEG2RAD * ((j + 1) * 360 / slices)));
			}
		}
		rlEnd();
	}
}

/*******************************************************************************************
*
*   raylib [models] example - Skybox loading and drawing
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017-2020 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
public unsafe static class Skybox
{
	//#if defined(PLATFORM_DESKTOP)
	//#define GLSL_VERSION            330
	//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
	//#define GLSL_VERSION            100
	//#endif
	const int GLSL_VERSION = 330;

	public static int main()
	{


		//// Generate cubemap (6 faces) from equirectangular (panorama) texture
		//static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format);

		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [models] example - skybox loading and drawing");

		// Define the camera to look into our 3d world
		Camera camera = new(new(1.0f, 1.0f, 1.0f), new(4.0f, 1.0f, 4.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

		// Load skybox model
		Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);
		Model skybox = LoadModelFromMesh(cube);

		bool useHDR = true;

		// Load skybox shader and set required locations
		// NOTE: Some locations are automatically set at shader loading
		skybox.materials[0].shader = LoadShader(TextFormat("resources/shaders/glsl%i/skybox.vs", GLSL_VERSION),
												TextFormat("resources/shaders/glsl%i/skybox.fs", GLSL_VERSION));

		SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "environmentMap"), MaterialMapIndex.MATERIAL_MAP_CUBEMAP, SHADER_UNIFORM_INT);
		SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "doGamma"), (useHDR ? 1 : 0), SHADER_UNIFORM_INT);
		SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "vflipped"), (useHDR ? 1 : 0), SHADER_UNIFORM_INT);

		// Load cubemap shader and setup required shader locations
		Shader shdrCubemap = LoadShader(TextFormat("resources/shaders/glsl%i/cubemap.vs", GLSL_VERSION),
										TextFormat("resources/shaders/glsl%i/cubemap.fs", GLSL_VERSION));

		SetShaderValue(shdrCubemap, GetShaderLocation(shdrCubemap, "equirectangularMap"), 0, SHADER_UNIFORM_INT);

		//char skyboxFileName[256];
		string skyboxFileName = null;

		Texture2D panorama;

		if (useHDR)
		{
			//TextCopy(skyboxFileName, "resources/dresden_square_2k.hdr");
			skyboxFileName = "resources/dresden_square_2k.hdr";

			// Load HDR panorama (sphere) texture
			panorama = LoadTexture(skyboxFileName);

			// Generate cubemap (texture with 6 quads-cube-mapping) from panorama HDR texture
			// NOTE 1: New texture is generated rendering to texture, shader calculates the sphere->cube coordinates mapping
			// NOTE 2: It seems on some Android devices WebGL, fbo does not properly support a FLOAT-based attachment,
			// despite texture can be successfully created.. so using PIXELFORMAT_UNCOMPRESSED_R8G8B8A8 instead of PIXELFORMAT_UNCOMPRESSED_R32G32B32A32
			skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

			//UnloadTexture(panorama);    // Texture not required anymore, cubemap already generated
		}
		else
		{
			Image img = LoadImage("resources/skybox.png");
			panorama = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);    // CUBEMAP_LAYOUT_PANORAMA
			skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = panorama;
			UnloadImage(img);
		}

		SetCameraMode(camera, CAMERA_FIRST_PERSON);  // Set a first person camera mode

		SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
												//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())            // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			UpdateCamera(ref camera);              // Update camera

			// Load new cubemap texture on drag&drop
			if (IsFileDropped())
			{
				int count = 0;
				//char** droppedFiles = GetDroppedFiles(&count);
				string[] droppedFiles = GetDroppedFiles();
				count = droppedFiles.Length;

				if (count == 1)         // Only support one file dropped
				{
					//if (IsFileExtension(droppedFiles[0], ".png;.jpg;.hdr;.bmp;.tga"))					
					if (droppedFiles[0].EndsWith(".png", ".jpg", ".hdr", ".bmp", ".tga"))
					{
						// Unload current cubemap texture and load new one
						UnloadTexture(skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture);
						if (useHDR)
						{
							//unload prior texture
							UnloadTexture(panorama);
							panorama = LoadTexture(droppedFiles[0]);

							// Generate cubemap from panorama texture
							skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

						}
						else
						{
							Image img = LoadImage(droppedFiles[0]);
							skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);
							UnloadImage(img);
						}

						//TextCopy(skyboxFileName, droppedFiles[0]);
						skyboxFileName = droppedFiles[0];
					}
				}

				ClearDroppedFiles();    // Clear internal buffers
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);

			// We are inside the cube, we need to disable backface culling!
			rlDisableBackfaceCulling();
			rlDisableDepthMask();
			DrawModel(skybox, new(0, 0, 0), 1.0f, WHITE);
			rlEnableBackfaceCulling();
			rlEnableDepthMask();

			DrawGrid(10, 1.0f);

			EndMode3D();

			DrawTextureEx(panorama, new(0, 0), 0.0f, 0.5f, WHITE);

			if (useHDR) DrawText(TextFormat("Panorama image from hdrihaven.com: %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);
			else DrawText(TextFormat(": %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadShader(skybox.materials[0].shader);
		UnloadTexture(skybox.materials[0].maps[(int)MATERIAL_MAP_CUBEMAP].texture);

		UnloadModel(skybox);        // Unload skybox model

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}

	public static bool EndsWith(this string text, params string[] endings)
	{
		foreach (var end in endings)
		{
			if (text.EndsWith(end))
			{
				return true;
			}
		}
		return false;
	}


	// Generate cubemap texture from HDR texture
	static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, PixelFormat format)
	{
		TextureCubemap cubemap = new();

		rlDisableBackfaceCulling();     // Disable backface culling to render inside the cube

		// STEP 1: Setup framebuffer
		//------------------------------------------------------------------------------------------
		uint rbo = rlLoadTextureDepth(size, size, true);
		cubemap.id = rlLoadTextureCubemap((void*)0, size, format);

		uint fbo = rlLoadFramebuffer(size, size);
		rlFramebufferAttach(fbo, rbo, RL_ATTACHMENT_DEPTH, RL_ATTACHMENT_RENDERBUFFER, 0);
		rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X, 0);

		// Check if framebuffer is complete with attachments (valid)
		if (rlFramebufferComplete(fbo)) TraceLog(LOG_INFO, "FBO: [ID %i] Framebuffer object created successfully", fbo);
		//------------------------------------------------------------------------------------------

		// STEP 2: Draw to framebuffer
		//------------------------------------------------------------------------------------------
		// NOTE: Shader is used to convert HDR equirectangular environment map to cubemap equivalent (6 faces)
		rlEnableShader(shader.id);

		// Define projection matrix and send it to shader
		Matrix matFboProjection = MatrixPerspective(90.0 * DEG2RAD, 1.0, RL_CULL_DISTANCE_NEAR, RL_CULL_DISTANCE_FAR);
		rlSetUniformMatrix(shader.locs[(int)RL_SHADER_LOC_MATRIX_PROJECTION], Matrix.Transpose(matFboProjection));

		// Define view matrix for every side of the cubemap
		Matrix[] fboViews = new Matrix[6] {
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(-1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 1.0f)),
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f), new(0.0f, 0.0f, -1.0f)),
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, 1.0f), new(0.0f, -1.0f, 0.0f)),
			MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, -1.0f), new(0.0f, -1.0f, 0.0f))
		};

		rlViewport(0, 0, size, size);   // Set viewport to current fbo dimensions

		// Activate and enable texture for drawing to cubemap faces
		rlActiveTextureSlot(0);
		rlEnableTexture(panorama.id);

		for (int i = 0; i < 6; i++)
		{
			// Set the view matrix for the current cube face
			rlSetUniformMatrix(shader.locs[(int)RL_SHADER_LOC_MATRIX_VIEW], Matrix.Transpose(fboViews[i]));

			// Select the current cubemap face attachment for the fbo
			// WARNING: This function by default enables->attach->disables fbo!!!
			rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X + i, 0);
			rlEnableFramebuffer(fbo);

			// Load and draw a cube, it uses the current enabled texture
			rlClearScreenBuffers();
			rlLoadDrawCube();

			// ALTERNATIVE: Try to use internal batch system to draw the cube instead of rlLoadDrawCube
			// for some reason this method does not work, maybe due to cube triangles definition? normals pointing out?
			// TODO: Investigate this issue...
			//rlSetTexture(panorama.id); // WARNING: It must be called after enabling current framebuffer if using internal batch system!
			//rlClearScreenBuffers();
			//DrawCubeV(Vector3Zero(), Vector3One(), WHITE);
			//rlDrawRenderBatchActive();
		}
		//------------------------------------------------------------------------------------------

		// STEP 3: Unload framebuffer and reset state
		//------------------------------------------------------------------------------------------
		rlDisableShader();          // Unbind shader
		rlDisableTexture();         // Unbind texture
		rlDisableFramebuffer();     // Unbind framebuffer
		rlUnloadFramebuffer(fbo);   // Unload framebuffer (and automatically attached depth texture/renderbuffer)

		// Reset viewport dimensions to default
		rlViewport(0, 0, rlGetFramebufferWidth(), rlGetFramebufferHeight());
		rlEnableBackfaceCulling();
		//------------------------------------------------------------------------------------------

		cubemap.width = size;
		cubemap.height = size;
		cubemap.mipmaps = 1;
		cubemap.format_ = format;

		return cubemap;
	}


}


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
			model.transform = Matrix.Transpose(Matrix4x4.CreateFromYawPitchRoll(DEG2RAD * yaw, DEG2RAD * pitch, DEG2RAD * roll));
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
