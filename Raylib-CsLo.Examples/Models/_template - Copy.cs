//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
//// [!!] Copyright ©? Raylib-CsLo and Contributors. 
//// [!!] This file is licensed to you under the LGPL-2.1.
//// [!!] See the LICENSE file in the project root for more info. 
//// [!!] ------------------------------------------------- 
//// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

//namespace Raylib_CsLo.Examples.Models;

//public unsafe static class _template
//{

//	public static int main()
//	{
//		return 0;
//	}
//}


///*******************************************************************************************
//*
//*   raylib [models] example - Load 3d model with animations and play them
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Culacant (@culacant) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Culacant (@culacant) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************
//*
//* To export a model from blender, make sure it is not posed, the vertices need to be in the
//* same position as they would be in edit mode.
//* and that the scale of your models is set to 0. Scaling can be done from the export menu.
//*
//********************************************************************************************/

//# include "raylib.h"

//# include <stdlib.h>


//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - model animation");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 10.0f, 10.0f, 10.0f }; // Camera position
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };      // Camera looking at point
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };          // Camera up vector (rotation towards target)
//	camera.fovy = 45.0f;                                // Camera field-of-view Y
//	camera.projection = CAMERA_PERSPECTIVE;             // Camera mode type

//	Model model = LoadModel("resources/models/iqm/guy.iqm");                    // Load the animated model mesh and basic data
//	Texture2D texture = LoadTexture("resources/models/iqm/guytex.png");         // Load model texture and set material
//	SetMaterialTexture(&model.materials[0], MATERIAL_MAP_DIFFUSE, texture);     // Set model material map texture

//	Vector3 position = { 0.0f, 0.0f, 0.0f };            // Set model position

//	// Load animation data
//	unsigned int animsCount = 0;
//	ModelAnimation* anims = LoadModelAnimations("resources/models/iqm/guyanim.iqm", &animsCount);
//	int animFrameCounter = 0;

//	SetCameraMode(camera, CAMERA_FREE); // Set free camera mode

//	SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())        // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);

//		// Play animation when spacebar is held down
//		if (IsKeyDown(KEY_SPACE))
//		{
//			animFrameCounter++;
//			UpdateModelAnimation(model, anims[0], animFrameCounter);
//			if (animFrameCounter >= anims[0].frameCount) animFrameCounter = 0;
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawModelEx(model, position, (Vector3){ 1.0f, 0.0f, 0.0f }, -90.0f, (Vector3){ 1.0f, 1.0f, 1.0f }, WHITE);

//		for (int i = 0; i < model.boneCount; i++)
//		{
//			DrawCube(anims[0].framePoses[animFrameCounter][i].translation, 0.2f, 0.2f, 0.2f, RED);
//		}

//		DrawGrid(10, 1.0f);         // Draw a grid

//		EndMode3D();

//		DrawText("PRESS SPACE to PLAY MODEL ANIMATION", 10, 10, 20, MAROON);
//		DrawText("(c) Guy IQM 3D model by @culacant", screenWidth - 200, screenHeight - 20, 10, GRAY);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(texture);     // Unload texture

//	// Unload model animations data
//	for (unsigned int i = 0; i < animsCount; i++) UnloadModelAnimation(anims[i]);
//	RL_FREE(anims);

//	UnloadModel(model);         // Unload model

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}



///*******************************************************************************************
//*
//*   raylib [models] example - Drawing billboards
//*
//*   This example has been created using raylib 1.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - drawing billboards");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 5.0f, 4.0f, 5.0f };
//	camera.target = (Vector3){ 0.0f, 2.0f, 0.0f };
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };
//	camera.fovy = 45.0f;
//	camera.projection = CAMERA_PERSPECTIVE;

//	Texture2D bill = LoadTexture("resources/billboard.png");     // Our texture billboard
//	Vector3 billPosition = { 0.0f, 2.0f, 0.0f };                 // Position where draw billboard

//	SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

//	SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())            // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);              // Update camera
//											//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawGrid(10, 1.0f);        // Draw a grid

//		DrawBillboard(camera, bill, billPosition, 2.0f, WHITE);

//		EndMode3D();

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(bill);        // Unload texture

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}


///*******************************************************************************************
//*
//*   raylib [models] example - Detect basic 3d collisions (box vs sphere vs box)
//*
//*   This example has been created using raylib 1.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - box collisions");

//	// Define the camera to look into our 3d world
//	Camera camera = { { 0.0f, 10.0f, 10.0f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	Vector3 playerPosition = { 0.0f, 1.0f, 2.0f };
//	Vector3 playerSize = { 1.0f, 2.0f, 1.0f };
//	Color playerColor = GREEN;

//	Vector3 enemyBoxPos = { -4.0f, 1.0f, 0.0f };
//	Vector3 enemyBoxSize = { 2.0f, 2.0f, 2.0f };

//	Vector3 enemySpherePos = { 4.0f, 0.0f, 0.0f };
//	float enemySphereSize = 1.5f;

//	bool collision = false;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------

//		// Move player
//		if (IsKeyDown(KEY_RIGHT)) playerPosition.x += 0.2f;
//		else if (IsKeyDown(KEY_LEFT)) playerPosition.x -= 0.2f;
//		else if (IsKeyDown(KEY_DOWN)) playerPosition.z += 0.2f;
//		else if (IsKeyDown(KEY_UP)) playerPosition.z -= 0.2f;

//		collision = false;

//		// Check collisions player vs enemy-box
//		if (CheckCollisionBoxes(
//			(BoundingBox){
//			(Vector3){
//				playerPosition.x - playerSize.x / 2,
//									 playerPosition.y - playerSize.y / 2,
//									 playerPosition.z - playerSize.z / 2 },
//						  (Vector3){
//				playerPosition.x + playerSize.x / 2,
//									 playerPosition.y + playerSize.y / 2,
//									 playerPosition.z + playerSize.z / 2 }
//		},
//			(BoundingBox){
//			(Vector3){
//				enemyBoxPos.x - enemyBoxSize.x / 2,
//									 enemyBoxPos.y - enemyBoxSize.y / 2,
//									 enemyBoxPos.z - enemyBoxSize.z / 2 },
//						  (Vector3){
//				enemyBoxPos.x + enemyBoxSize.x / 2,
//									 enemyBoxPos.y + enemyBoxSize.y / 2,
//									 enemyBoxPos.z + enemyBoxSize.z / 2 }
//		})) collision = true;

//		// Check collisions player vs enemy-sphere
//		if (CheckCollisionBoxSphere(
//			(BoundingBox){
//			(Vector3){
//				playerPosition.x - playerSize.x / 2,
//									 playerPosition.y - playerSize.y / 2,
//									 playerPosition.z - playerSize.z / 2 },
//						  (Vector3){
//				playerPosition.x + playerSize.x / 2,
//									 playerPosition.y + playerSize.y / 2,
//									 playerPosition.z + playerSize.z / 2 }
//		},
//			enemySpherePos, enemySphereSize)) collision = true;

//		if (collision) playerColor = RED;
//		else playerColor = GREEN;
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		// Draw enemy-box
//		DrawCube(enemyBoxPos, enemyBoxSize.x, enemyBoxSize.y, enemyBoxSize.z, GRAY);
//		DrawCubeWires(enemyBoxPos, enemyBoxSize.x, enemyBoxSize.y, enemyBoxSize.z, DARKGRAY);

//		// Draw enemy-sphere
//		DrawSphere(enemySpherePos, enemySphereSize, GRAY);
//		DrawSphereWires(enemySpherePos, enemySphereSize, 16, 16, DARKGRAY);

//		// Draw player
//		DrawCubeV(playerPosition, playerSize, playerColor);

//		DrawGrid(10, 1.0f);        // Draw a grid

//		EndMode3D();

//		DrawText("Move player with cursors to collide", 220, 40, 20, GRAY);

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//	return 0;
//}
///*******************************************************************************************
//*
//*   raylib [models] example - Cubicmap loading and drawing
//*
//*   This example has been created using raylib 1.8 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - cubesmap loading and drawing");

//	// Define the camera to look into our 3d world
//	Camera camera = { { 16.0f, 14.0f, 16.0f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	Image image = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
//	Texture2D cubicmap = LoadTextureFromImage(image);       // Convert image to texture to display (VRAM)

//	Mesh mesh = GenMeshCubicmap(image, (Vector3){ 1.0f, 1.0f, 1.0f });
//	Model model = LoadModelFromMesh(mesh);

//	// NOTE: By default each cube is mapped to one part of texture atlas
//	Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
//	model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;             // Set map diffuse texture

//	Vector3 mapPosition = { -16.0f, 0.0f, -8.0f };          // Set model position

//	UnloadImage(image);     // Unload cubesmap image from RAM, already uploaded to VRAM

//	SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

//	SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())            // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);              // Update camera
//											//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawModel(model, mapPosition, 1.0f, WHITE);

//		EndMode3D();

//		DrawTextureEx(cubicmap, (Vector2){ screenWidth - cubicmap.width * 4.0f - 20, 20.0f }, 0.0f, 4.0f, WHITE);
//		DrawRectangleLines(screenWidth - cubicmap.width * 4 - 20, 20, cubicmap.width * 4, cubicmap.height * 4, GREEN);

//		DrawText("cubicmap image used to", 658, 90, 10, GRAY);
//		DrawText("generate map 3d model", 658, 104, 10, GRAY);

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(cubicmap);    // Unload cubicmap texture
//	UnloadTexture(texture);     // Unload map texture
//	UnloadModel(model);         // Unload map model

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}
///*******************************************************************************************
//*
//*   raylib [models] example - first person maze
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//# include <stdlib.h>           // Required for: free()

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - first person maze");

//	// Define the camera to look into our 3d world
//	Camera camera = { { 0.2f, 0.4f, 0.2f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	Image imMap = LoadImage("resources/cubicmap.png");      // Load cubicmap image (RAM)
//	Texture2D cubicmap = LoadTextureFromImage(imMap);       // Convert image to texture to display (VRAM)
//	Mesh mesh = GenMeshCubicmap(imMap, (Vector3){ 1.0f, 1.0f, 1.0f });
//	Model model = LoadModelFromMesh(mesh);

//	// NOTE: By default each cube is mapped to one part of texture atlas
//	Texture2D texture = LoadTexture("resources/cubicmap_atlas.png");    // Load map texture
//	model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;             // Set map diffuse texture

//	// Get map image data to be used for collision detection
//	Color* mapPixels = LoadImageColors(imMap);
//	UnloadImage(imMap);             // Unload image from RAM

//	Vector3 mapPosition = { -16.0f, 0.0f, -8.0f };  // Set model position

//	SetCameraMode(camera, CAMERA_FIRST_PERSON);     // Set camera mode

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		Vector3 oldCamPos = camera.position;    // Store old camera position

//		UpdateCamera(&camera);      // Update camera

//		// Check player collision (we simplify to 2D collision detection)
//		Vector2 playerPos = { camera.position.x, camera.position.z };
//		float playerRadius = 0.1f;  // Collision radius (player is modelled as a cilinder for collision)

//		int playerCellX = (int)(playerPos.x - mapPosition.x + 0.5f);
//		int playerCellY = (int)(playerPos.y - mapPosition.z + 0.5f);

//		// Out-of-limits security check
//		if (playerCellX < 0) playerCellX = 0;
//		else if (playerCellX >= cubicmap.width) playerCellX = cubicmap.width - 1;

//		if (playerCellY < 0) playerCellY = 0;
//		else if (playerCellY >= cubicmap.height) playerCellY = cubicmap.height - 1;

//		// Check map collisions using image data and player position
//		// TODO: Improvement: Just check player surrounding cells for collision
//		for (int y = 0; y < cubicmap.height; y++)
//		{
//			for (int x = 0; x < cubicmap.width; x++)
//			{
//				if ((mapPixels[y * cubicmap.width + x].r == 255) &&       // Collision: white pixel, only check R channel
//					(CheckCollisionCircleRec(playerPos, playerRadius,
//					(Rectangle){ mapPosition.x - 0.5f + x * 1.0f, mapPosition.z - 0.5f + y * 1.0f, 1.0f, 1.0f })))
//				{
//			// Collision detected, reset camera position
//			camera.position = oldCamPos;
//		}
//	}
//}
////----------------------------------------------------------------------------------

//// Draw
////----------------------------------------------------------------------------------
//BeginDrawing();

//ClearBackground(RAYWHITE);

//BeginMode3D(camera);
//DrawModel(model, mapPosition, 1.0f, WHITE);                     // Draw maze map
//EndMode3D();

//DrawTextureEx(cubicmap, (Vector2){ GetScreenWidth() - cubicmap.width * 4.0f - 20, 20.0f }, 0.0f, 4.0f, WHITE);
//			DrawRectangleLines(GetScreenWidth() - cubicmap.width*4 - 20, 20, cubicmap.width*4, cubicmap.height*4, GREEN);

//// Draw player position radar
//DrawRectangle(GetScreenWidth() - cubicmap.width*4 - 20 + playerCellX*4, 20 + playerCellY*4, 4, 4, RED);

//DrawFPS(10, 10);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadImageColors(mapPixels);   // Unload color array

//UnloadTexture(cubicmap);        // Unload cubicmap texture
//UnloadTexture(texture);         // Unload map texture
//UnloadModel(model);             // Unload map model

//CloseWindow();                  // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//return 0;
//}
///*******************************************************************************************
//*
//*   raylib [models] example - Draw some basic geometric shapes (cube, sphere, cylinder...)
//*
//*   This example has been created using raylib 1.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 0.0f, 10.0f, 10.0f };
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };
//	camera.fovy = 45.0f;
//	camera.projection = CAMERA_PERSPECTIVE;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		// TODO: Update your variables here
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawCube((Vector3){ -4.0f, 0.0f, 2.0f}, 2.0f, 5.0f, 2.0f, RED);
//DrawCubeWires((Vector3){ -4.0f, 0.0f, 2.0f}, 2.0f, 5.0f, 2.0f, GOLD);
//DrawCubeWires((Vector3){ -4.0f, 0.0f, -2.0f}, 3.0f, 6.0f, 2.0f, MAROON);

//DrawSphere((Vector3){ -1.0f, 0.0f, -2.0f}, 1.0f, GREEN);
//DrawSphereWires((Vector3){ 1.0f, 0.0f, 2.0f}, 2.0f, 16, 16, LIME);

//DrawCylinder((Vector3){ 4.0f, 0.0f, -2.0f}, 1.0f, 2.0f, 3.0f, 4, SKYBLUE);
//DrawCylinderWires((Vector3){ 4.0f, 0.0f, -2.0f}, 1.0f, 2.0f, 3.0f, 4, DARKBLUE);
//DrawCylinderWires((Vector3){ 4.5f, -1.0f, 2.0f}, 1.0f, 1.0f, 2.0f, 6, BROWN);

//DrawCylinder((Vector3){ 1.0f, 0.0f, -4.0f}, 0.0f, 1.5f, 3.0f, 8, GOLD);
//DrawCylinderWires((Vector3){ 1.0f, 0.0f, -4.0f}, 0.0f, 1.5f, 3.0f, 8, PINK);

//DrawGrid(10, 1.0f);        // Draw a grid

//EndMode3D();

//DrawFPS(10, 10);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//return 0;
//}

///*******************************************************************************************
//*
//*   raylib [models] example - Heightmap loading and drawing
//*
//*   This example has been created using raylib 1.8 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - heightmap loading and drawing");

//	// Define our custom camera to look into our 3d world
//	Camera camera = { { 18.0f, 18.0f, 18.0f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	Image image = LoadImage("resources/heightmap.png");             // Load heightmap image (RAM)
//	Texture2D texture = LoadTextureFromImage(image);                // Convert image to texture (VRAM)

//	Mesh mesh = GenMeshHeightmap(image, (Vector3){ 16, 8, 16 });    // Generate heightmap mesh (RAM and VRAM)
//Model model = LoadModelFromMesh(mesh);                          // Load model from generated mesh

//model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;         // Set map diffuse texture
//Vector3 mapPosition = { -8.0f, 0.0f, -8.0f };                   // Define model position

//UnloadImage(image);                     // Unload heightmap image from RAM, already uploaded to VRAM

//SetCameraMode(camera, CAMERA_ORBITAL);  // Set an orbital camera mode

//SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//// Main game loop
//while (!WindowShouldClose())            // Detect window close button or ESC key
//{
//	// Update
//	//----------------------------------------------------------------------------------
//	UpdateCamera(&camera);              // Update camera
//										//----------------------------------------------------------------------------------

//	// Draw
//	//----------------------------------------------------------------------------------
//	BeginDrawing();

//	ClearBackground(RAYWHITE);

//	BeginMode3D(camera);

//	DrawModel(model, mapPosition, 1.0f, RED);

//	DrawGrid(20, 1.0f);

//	EndMode3D();

//	DrawTexture(texture, screenWidth - texture.width - 20, 20, WHITE);
//	DrawRectangleLines(screenWidth - texture.width - 20, 20, texture.width, texture.height, GREEN);

//	DrawFPS(10, 10);

//	EndDrawing();
//	//----------------------------------------------------------------------------------
//}

//// De-Initialization
////--------------------------------------------------------------------------------------
//UnloadTexture(texture);     // Unload texture
//UnloadModel(model);         // Unload model

//CloseWindow();              // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//return 0;
//}
///*******************************************************************************************
//*
//*   raylib [models] example - Models loading
//*
//*   raylib supports multiple models file formats:
//*
//*     - OBJ  > Text file format. Must include vertex position-texcoords-normals information,
//*              if files references some .mtl materials file, it will be loaded (or try to).
//*     - GLTF > Text/binary file format. Includes lot of information and it could
//*              also reference external files, raylib will try loading mesh and materials data.
//*     - IQM  > Binary file format. Includes mesh vertex data but also animation data,
//*              raylib can load .iqm animations.
//*     - VOX  > Binary file format. MagikaVoxel mesh format:
//*              https://github.com/ephtracy/voxel-model/blob/master/MagicaVoxel-file-format-vox.txt
//*
//*   This example has been created using raylib 4.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014-2021 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - models loading");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 50.0f, 50.0f, 50.0f }; // Camera position
//	camera.target = (Vector3){ 0.0f, 10.0f, 0.0f };     // Camera looking at point
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };          // Camera up vector (rotation towards target)
//	camera.fovy = 45.0f;                                // Camera field-of-view Y
//	camera.projection = CAMERA_PERSPECTIVE;                   // Camera mode type

//	Model model = LoadModel("resources/models/obj/castle.obj");                 // Load model
//	Texture2D texture = LoadTexture("resources/models/obj/castle_diffuse.png"); // Load model texture
//	model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;            // Set map diffuse texture

//	Vector3 position = { 0.0f, 0.0f, 0.0f };                    // Set model position

//	BoundingBox bounds = GetMeshBoundingBox(model.meshes[0]);   // Set model bounds

//	// NOTE: bounds are calculated from the original size of the model,
//	// if model is scaled on drawing, bounds must be also scaled

//	SetCameraMode(camera, CAMERA_FREE);     // Set a free camera mode

//	bool selected = false;          // Selected object flag

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);

//		// Load new models/textures on drag&drop
//		if (IsFileDropped())
//		{
//			int count = 0;
//			char** droppedFiles = GetDroppedFiles(&count);

//			if (count == 1) // Only support one file dropped
//			{
//				if (IsFileExtension(droppedFiles[0], ".obj") ||
//					IsFileExtension(droppedFiles[0], ".gltf") ||
//					IsFileExtension(droppedFiles[0], ".glb") ||
//					IsFileExtension(droppedFiles[0], ".vox") ||
//					IsFileExtension(droppedFiles[0], ".iqm"))       // Model file formats supported
//				{
//					UnloadModel(model);                     // Unload previous model
//					model = LoadModel(droppedFiles[0]);     // Load new model
//					model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture; // Set current map diffuse texture

//					bounds = GetMeshBoundingBox(model.meshes[0]);

//					// TODO: Move camera position from target enough distance to visualize model properly
//				}
//				else if (IsFileExtension(droppedFiles[0], ".png"))  // Texture file formats supported
//				{
//					// Unload current model texture and load new one
//					UnloadTexture(texture);
//					texture = LoadTexture(droppedFiles[0]);
//					model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;
//				}
//			}

//			ClearDroppedFiles();    // Clear internal buffers
//		}

//		// Select model on mouse click
//		if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
//		{
//			// Check collision between ray and box
//			if (GetRayCollisionBox(GetMouseRay(GetMousePosition(), camera), bounds).hit) selected = !selected;
//			else selected = false;
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawModel(model, position, 1.0f, WHITE);        // Draw 3d model with texture

//		DrawGrid(20, 10.0f);         // Draw a grid

//		if (selected) DrawBoundingBox(bounds, GREEN);   // Draw selection box

//		EndMode3D();

//		DrawText("Drag & drop model to load mesh/texture.", 10, GetScreenHeight() - 20, 10, DARKGRAY);
//		if (selected) DrawText("MODEL SELECTED", GetScreenWidth() - 110, 10, 10, GREEN);

//		DrawText("(c) Castle 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(texture);     // Unload texture
//	UnloadModel(model);         // Unload model

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}

///*******************************************************************************************
//*
//*   raylib [models] example - Load models gltf
//*
//*   This example has been created using raylib 3.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   NOTE: To export a model from Blender, make sure it is not posed, the vertices need to be
//*   in the same position as they would be in edit mode.
//*   Also make sure the scale parameter of your models is set to 0.0,
//*   scaling can be applied from the export menu.
//*
//*   Example contributed by Hristo Stamenov (@object71) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2021 Hristo Stamenov (@object71) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#define MAX_GLTF_MODELS  8

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - model");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 10.0f, 10.0f, 10.0f }; // Camera position
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };      // Camera looking at point
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };          // Camera up vector (rotation towards target)
//	camera.fovy = 45.0f;                                // Camera field-of-view Y
//	camera.projection = CAMERA_PERSPECTIVE;             // Camera mode type

//	// Load some models
//	Model model[MAX_GLTF_MODELS] = { 0 };
//	model[0] = LoadModel("resources/models/gltf/raylib_32x32.glb");
//	model[1] = LoadModel("resources/models/gltf/rigged_figure.glb");
//	model[2] = LoadModel("resources/models/gltf/GearboxAssy.glb");
//	model[3] = LoadModel("resources/models/gltf/BoxAnimated.glb");
//	model[4] = LoadModel("resources/models/gltf/AnimatedTriangle.gltf");
//	model[5] = LoadModel("resources/models/gltf/AnimatedMorphCube.glb");
//	model[6] = LoadModel("resources/models/gltf/vertex_colored_object.glb");
//	model[7] = LoadModel("resources/models/gltf/girl.glb");

//	int currentModel = 0;

//	Vector3 position = { 0.0f, 0.0f, 0.0f };    // Set model position

//	SetCameraMode(camera, CAMERA_FREE); // Set free camera mode

//	SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())        // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);          // Update our camera with inputs

//		if (IsKeyReleased(KEY_RIGHT))
//		{
//			currentModel++;
//			if (currentModel == MAX_GLTF_MODELS) currentModel = 0;
//		}

//		if (IsKeyReleased(KEY_LEFT))
//		{
//			currentModel--;
//			if (currentModel < 0) currentModel = MAX_GLTF_MODELS - 1;
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(SKYBLUE);

//		BeginMode3D(camera);

//		DrawModel(model[currentModel], position, 1.0f, WHITE);
//		DrawGrid(10, 1.0f);         // Draw a grid

//		EndMode3D();

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	for (int i = 0; i < MAX_GLTF_MODELS; i++) UnloadModel(model[i]);  // Unload models

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}



///*******************************************************************************************
//*
//*   raylib [models] example - Load models vox (MagicaVoxel)
//*
//*   This example has been created using raylib 4.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Johann Nadalutti (@procfxgen) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2021 Johann Nadalutti (@procfxgen) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//# include "raymath.h"        // Required for: MatrixTranslate()

//#define MAX_VOX_FILES  3

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	const char* voxFileNames[] = {
//		"resources/models/vox/chr_knight.vox",
//		"resources/models/vox/chr_sword.vox",
//		"resources/models/vox/monu9.vox"
//	};

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - magicavoxel loading");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 10.0f, 10.0f, 10.0f }; // Camera position
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };      // Camera looking at point
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };          // Camera up vector (rotation towards target)
//	camera.fovy = 45.0f;                                // Camera field-of-view Y
//	camera.projection = CAMERA_PERSPECTIVE;             // Camera mode type

//	// Load MagicaVoxel files
//	Model models[MAX_VOX_FILES] = { 0 };

//	for (int i = 0; i < MAX_VOX_FILES; i++)
//	{
//		// Load VOX file and measure time
//		double t0 = GetTime() * 1000.0;
//		models[i] = LoadModel(voxFileNames[i]);
//		double t1 = GetTime() * 1000.0;

//		TraceLog(LOG_WARNING, TextFormat("[%s] File loaded in %.3f ms", voxFileNames[i], t1 - t0));

//		// Compute model translation matrix to center model on draw position (0, 0 , 0)
//		BoundingBox bb = GetModelBoundingBox(models[i]);
//		Vector3 center = { 0 };
//		center.x = bb.min.x + (((bb.max.x - bb.min.x) / 2));
//		center.z = bb.min.z + (((bb.max.z - bb.min.z) / 2));

//		Matrix matTranslate = MatrixTranslate(-center.x, 0, -center.z);
//		models[i].transform = matTranslate;
//	}

//	int currentModel = 0;

//	SetCameraMode(camera, CAMERA_ORBITAL);  // Set a orbital camera mode

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);      // Update our camera to orbit

//		// Cycle between models on mouse click
//		if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT)) currentModel = (currentModel + 1) % MAX_VOX_FILES;

//		// Cycle between models on key pressed
//		if (IsKeyPressed(KEY_RIGHT))
//		{
//			currentModel++;
//			if (currentModel >= MAX_VOX_FILES) currentModel = 0;
//		}
//		else if (IsKeyPressed(KEY_LEFT))
//		{
//			currentModel--;
//			if (currentModel < 0) currentModel = MAX_VOX_FILES - 1;
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		// Draw 3D model
//		BeginMode3D(camera);

//		DrawModel(models[currentModel], (Vector3){ 0, 0, 0 }, 1.0f, WHITE);
//DrawGrid(10, 1.0);

//EndMode3D();

//// Display info
//DrawRectangle(10, 400, 310, 30, Fade(SKYBLUE, 0.5f));
//DrawRectangleLines(10, 400, 310, 30, Fade(DARKBLUE, 0.5f));
//DrawText("MOUSE LEFT BUTTON to CYCLE VOX MODELS", 40, 410, 10, BLUE);
//DrawText(TextFormat("File: %s", GetFileName(voxFileNames[currentModel])), 10, 10, 20, GRAY);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	// Unload models data (GPU VRAM)
//	for (int i = 0; i < MAX_VOX_FILES; i++) UnloadModel(models[i]);

//CloseWindow();          // Close window and OpenGL context
//						//--------------------------------------------------------------------------------------

//return 0;
//}



///*******************************************************************************************
//*
//*   raylib example - procedural mesh generation
//*
//*   This example has been created using raylib 1.8 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2017 Ramon Santamaria (Ray San)
//*
//********************************************************************************************/

//#include "raylib.h"

//#define NUM_MODELS  9      // Parametric 3d shapes to generate

//void AllocateMeshData(Mesh* mesh, int triangleCount)
//{
//	mesh->vertexCount = triangleCount * 3;
//	mesh->triangleCount = triangleCount;

//	mesh->vertices = (float*)MemAlloc(mesh->vertexCount * 3 * sizeof(float));
//	mesh->texcoords = (float*)MemAlloc(mesh->vertexCount * 2 * sizeof(float));
//	mesh->normals = (float*)MemAlloc(mesh->vertexCount * 3 * sizeof(float));
//}

//// generate a simple triangle mesh from code
//Mesh MakeMesh()
//{
//	Mesh mesh = { 0 };
//	AllocateMeshData(&mesh, 1);

//	// vertex at the origin
//	mesh.vertices[0] = 0;
//	mesh.vertices[1] = 0;
//	mesh.vertices[2] = 0;
//	mesh.normals[0] = 0;
//	mesh.normals[1] = 1;
//	mesh.normals[2] = 0;
//	mesh.texcoords[0] = 0;
//	mesh.texcoords[1] = 0;

//	// vertex at 1,0,2
//	mesh.vertices[3] = 1;
//	mesh.vertices[4] = 0;
//	mesh.vertices[5] = 2;
//	mesh.normals[3] = 0;
//	mesh.normals[4] = 1;
//	mesh.normals[5] = 0;
//	mesh.texcoords[2] = 0.5f;
//	mesh.texcoords[3] = 1.0f;

//	// vertex at 2,0,0
//	mesh.vertices[6] = 2;
//	mesh.vertices[7] = 0;
//	mesh.vertices[8] = 0;
//	mesh.normals[6] = 0;
//	mesh.normals[7] = 1;
//	mesh.normals[8] = 0;
//	mesh.texcoords[4] = 1;
//	mesh.texcoords[5] = 0;

//	UploadMesh(&mesh, false);

//	return mesh;
//}

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh generation");

//	// We generate a checked image for texturing
//	Image checked = GenImageChecked(2, 2, 1, 1, RED, GREEN);
//	Texture2D texture = LoadTextureFromImage(checked);
//	UnloadImage(checked);

//	Model models[NUM_MODELS] = { 0 };

//	models[0] = LoadModelFromMesh(GenMeshPlane(2, 2, 5, 5));
//	models[1] = LoadModelFromMesh(GenMeshCube(2.0f, 1.0f, 2.0f));
//	models[2] = LoadModelFromMesh(GenMeshSphere(2, 32, 32));
//	models[3] = LoadModelFromMesh(GenMeshHemiSphere(2, 16, 16));
//	models[4] = LoadModelFromMesh(GenMeshCylinder(1, 2, 16));
//	models[5] = LoadModelFromMesh(GenMeshTorus(0.25f, 4.0f, 16, 32));
//	models[6] = LoadModelFromMesh(GenMeshKnot(1.0f, 2.0f, 16, 128));
//	models[7] = LoadModelFromMesh(GenMeshPoly(5, 2.0f));
//	models[8] = LoadModelFromMesh(MakeMesh());

//	// Set checked texture as default diffuse component for all models material
//	for (int i = 0; i < NUM_MODELS; i++) models[i].materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;

//	// Define the camera to look into our 3d world
//	Camera camera = { { 5.0f, 5.0f, 5.0f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	// Model drawing position
//	Vector3 position = { 0.0f, 0.0f, 0.0f };

//	int currentModel = 0;

//	SetCameraMode(camera, CAMERA_ORBITAL);  // Set a orbital camera mode

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);      // Update internal camera and our camera

//		if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
//		{
//			currentModel = (currentModel + 1) % NUM_MODELS; // Cycle between the textures
//		}

//		if (IsKeyPressed(KEY_RIGHT))
//		{
//			currentModel++;
//			if (currentModel >= NUM_MODELS) currentModel = 0;
//		}
//		else if (IsKeyPressed(KEY_LEFT))
//		{
//			currentModel--;
//			if (currentModel < 0) currentModel = NUM_MODELS - 1;
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawModel(models[currentModel], position, 1.0f, WHITE);
//		DrawGrid(10, 1.0);

//		EndMode3D();

//		DrawRectangle(30, 400, 310, 30, Fade(SKYBLUE, 0.5f));
//		DrawRectangleLines(30, 400, 310, 30, Fade(DARKBLUE, 0.5f));
//		DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL MODELS", 40, 410, 10, BLUE);

//		switch (currentModel)
//		{
//			case 0: DrawText("PLANE", 680, 10, 20, DARKBLUE); break;
//			case 1: DrawText("CUBE", 680, 10, 20, DARKBLUE); break;
//			case 2: DrawText("SPHERE", 680, 10, 20, DARKBLUE); break;
//			case 3: DrawText("HEMISPHERE", 640, 10, 20, DARKBLUE); break;
//			case 4: DrawText("CYLINDER", 680, 10, 20, DARKBLUE); break;
//			case 5: DrawText("TORUS", 680, 10, 20, DARKBLUE); break;
//			case 6: DrawText("KNOT", 680, 10, 20, DARKBLUE); break;
//			case 7: DrawText("POLY", 680, 10, 20, DARKBLUE); break;
//			case 8: DrawText("Parametric(custom)", 580, 10, 20, DARKBLUE); break;
//			default: break;
//		}

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadTexture(texture); // Unload texture

//	// Unload models data (GPU VRAM)
//	for (int i = 0; i < NUM_MODELS; i++) UnloadModel(models[i]);

//	CloseWindow();          // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//	return 0;
//	}

//	/*******************************************************************************************
//*
//*   raylib [models] example - Mesh picking in 3d mode, ground plane, triangle, mesh
//*
//*   This example has been created using raylib 1.7 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Joel Davis (@joeld42) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2017 Joel Davis (@joeld42) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"
//# include "raymath.h"

//#define FLT_MAX     340282346638528859811704183484516925440.0f     // Maximum value of a float, from bit pattern 01111111011111111111111111111111

//	int main(void)
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh picking");

//		// Define the camera to look into our 3d world
//		Camera camera = { 0 };
//		camera.position = (Vector3){ 20.0f, 20.0f, 20.0f }; // Camera position
//		camera.target = (Vector3){ 0.0f, 8.0f, 0.0f };      // Camera looking at point
//		camera.up = (Vector3){ 0.0f, 1.6f, 0.0f };          // Camera up vector (rotation towards target)
//		camera.fovy = 45.0f;                                // Camera field-of-view Y
//		camera.projection = CAMERA_PERSPECTIVE;             // Camera mode type

//		Ray ray = { 0 };        // Picking ray

//		Model tower = LoadModel("resources/models/obj/turret.obj");                 // Load OBJ model
//		Texture2D texture = LoadTexture("resources/models/obj/turret_diffuse.png"); // Load model texture
//		tower.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;            // Set model diffuse texture

//		Vector3 towerPos = { 0.0f, 0.0f, 0.0f };                        // Set model position
//		BoundingBox towerBBox = GetMeshBoundingBox(tower.meshes[0]);    // Get mesh bounding box

//		// Ground quad
//		Vector3 g0 = (Vector3){ -50.0f, 0.0f, -50.0f };
//		Vector3 g1 = (Vector3){ -50.0f, 0.0f,  50.0f };
//		Vector3 g2 = (Vector3){ 50.0f, 0.0f,  50.0f };
//		Vector3 g3 = (Vector3){ 50.0f, 0.0f, -50.0f };

//		// Test triangle
//		Vector3 ta = (Vector3){ -25.0f, 0.5f, 0.0f };
//		Vector3 tb = (Vector3){ -4.0f, 2.5f, 1.0f };
//		Vector3 tc = (Vector3){ -8.0f, 6.5f, 0.0f };

//		Vector3 bary = { 0.0f, 0.0f, 0.0f };

//		// Test sphere
//		Vector3 sp = (Vector3){ -30.0f, 5.0f, 5.0f };
//		float sr = 4.0f;

//		SetCameraMode(camera, CAMERA_FREE); // Set a free camera mode

//		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------
//											// Main game loop
//		while (!WindowShouldClose())        // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			UpdateCamera(&camera);          // Update camera

//			// Display information about closest hit
//			RayCollision collision = { 0 };
//			char* hitObjectName = "None";
//			collision.distance = FLT_MAX;
//			collision.hit = false;
//			Color cursorColor = WHITE;

//			// Get ray and test against objects
//			ray = GetMouseRay(GetMousePosition(), camera);

//			// Check ray collision against ground quad
//			RayCollision groundHitInfo = GetRayCollisionQuad(ray, g0, g1, g2, g3);

//			if ((groundHitInfo.hit) && (groundHitInfo.distance < collision.distance))
//			{
//				collision = groundHitInfo;
//				cursorColor = GREEN;
//				hitObjectName = "Ground";
//			}

//			// Check ray collision against test triangle
//			RayCollision triHitInfo = GetRayCollisionTriangle(ray, ta, tb, tc);

//			if ((triHitInfo.hit) && (triHitInfo.distance < collision.distance))
//			{
//				collision = triHitInfo;
//				cursorColor = PURPLE;
//				hitObjectName = "Triangle";

//				bary = Vector3Barycenter(collision.point, ta, tb, tc);
//			}

//			// Check ray collision against test sphere
//			RayCollision sphereHitInfo = GetRayCollisionSphere(ray, sp, sr);

//			if ((sphereHitInfo.hit) && (sphereHitInfo.distance < collision.distance))
//			{
//				collision = sphereHitInfo;
//				cursorColor = ORANGE;
//				hitObjectName = "Sphere";
//			}

//			// Check ray collision against bounding box first, before trying the full ray-mesh test
//			RayCollision boxHitInfo = GetRayCollisionBox(ray, towerBBox);

//			if ((boxHitInfo.hit) && (boxHitInfo.distance < collision.distance))
//			{
//				collision = boxHitInfo;
//				cursorColor = ORANGE;
//				hitObjectName = "Box";

//				// Check ray collision against model
//				// NOTE: It considers model.transform matrix!
//				RayCollision meshHitInfo = GetRayCollisionModel(ray, tower);

//				if (meshHitInfo.hit)
//				{
//					collision = meshHitInfo;
//					cursorColor = ORANGE;
//					hitObjectName = "Mesh";
//				}
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			BeginMode3D(camera);

//			// Draw the tower
//			// WARNING: If scale is different than 1.0f,
//			// not considered by GetRayCollisionModel()
//			DrawModel(tower, towerPos, 1.0f, WHITE);

//			// Draw the test triangle
//			DrawLine3D(ta, tb, PURPLE);
//			DrawLine3D(tb, tc, PURPLE);
//			DrawLine3D(tc, ta, PURPLE);

//			// Draw the test sphere
//			DrawSphereWires(sp, sr, 8, 8, PURPLE);

//			// Draw the mesh bbox if we hit it
//			if (boxHitInfo.hit) DrawBoundingBox(towerBBox, LIME);

//			// If we hit something, draw the cursor at the hit point
//			if (collision.hit)
//			{
//				DrawCube(collision.point, 0.3f, 0.3f, 0.3f, cursorColor);
//				DrawCubeWires(collision.point, 0.3f, 0.3f, 0.3f, RED);

//				Vector3 normalEnd;
//				normalEnd.x = collision.point.x + collision.normal.x;
//				normalEnd.y = collision.point.y + collision.normal.y;
//				normalEnd.z = collision.point.z + collision.normal.z;

//				DrawLine3D(collision.point, normalEnd, RED);
//			}

//			DrawRay(ray, MAROON);

//			DrawGrid(10, 10.0f);

//			EndMode3D();

//			// Draw some debug GUI text
//			DrawText(TextFormat("Hit Object: %s", hitObjectName), 10, 50, 10, BLACK);

//			if (collision.hit)
//			{
//				int ypos = 70;

//				DrawText(TextFormat("Distance: %3.2f", collision.distance), 10, ypos, 10, BLACK);

//				DrawText(TextFormat("Hit Pos: %3.2f %3.2f %3.2f",
//									collision.point.x,
//									collision.point.y,
//									collision.point.z), 10, ypos + 15, 10, BLACK);

//				DrawText(TextFormat("Hit Norm: %3.2f %3.2f %3.2f",
//									collision.normal.x,
//									collision.normal.y,
//									collision.normal.z), 10, ypos + 30, 10, BLACK);

//				if (triHitInfo.hit && TextIsEqual(hitObjectName, "Triangle"))
//					DrawText(TextFormat("Barycenter: %3.2f %3.2f %3.2f", bary.x, bary.y, bary.z), 10, ypos + 45, 10, BLACK);
//			}

//			DrawText("Use Mouse to Move Camera", 10, 430, 10, GRAY);

//			DrawText("(c) Turret 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, GRAY);

//			DrawFPS(10, 10);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadModel(tower);         // Unload model
//		UnloadTexture(texture);     // Unload texture

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}

//	/*******************************************************************************************
//*
//*   raylib [models] example - Show the difference between perspective and orthographic projection
//*
//*   This program is heavily based on the geometric objects example
//*
//*   This example has been created using raylib 2.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Max Danielsson (@autious) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Max Danielsson (@autious) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//#define FOVY_PERSPECTIVE    45.0f
//#define WIDTH_ORTHOGRAPHIC  10.0f

//	int main(void)
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [models] example - geometric shapes");

//		// Define the camera to look into our 3d world
//		Camera camera = { { 0.0f, 10.0f, 10.0f }, { 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, FOVY_PERSPECTIVE, CAMERA_PERSPECTIVE };

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyPressed(KEY_SPACE))
//			{
//				if (camera.projection == CAMERA_PERSPECTIVE)
//				{
//					camera.fovy = WIDTH_ORTHOGRAPHIC;
//					camera.projection = CAMERA_ORTHOGRAPHIC;
//				}
//				else
//				{
//					camera.fovy = FOVY_PERSPECTIVE;
//					camera.projection = CAMERA_PERSPECTIVE;
//				}
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			BeginMode3D(camera);

//			DrawCube((Vector3){ -4.0f, 0.0f, 2.0f}, 2.0f, 5.0f, 2.0f, RED);
//DrawCubeWires((Vector3){ -4.0f, 0.0f, 2.0f}, 2.0f, 5.0f, 2.0f, GOLD);
//DrawCubeWires((Vector3){ -4.0f, 0.0f, -2.0f}, 3.0f, 6.0f, 2.0f, MAROON);

//DrawSphere((Vector3){ -1.0f, 0.0f, -2.0f}, 1.0f, GREEN);
//DrawSphereWires((Vector3){ 1.0f, 0.0f, 2.0f}, 2.0f, 16, 16, LIME);

//DrawCylinder((Vector3){ 4.0f, 0.0f, -2.0f}, 1.0f, 2.0f, 3.0f, 4, SKYBLUE);
//DrawCylinderWires((Vector3){ 4.0f, 0.0f, -2.0f}, 1.0f, 2.0f, 3.0f, 4, DARKBLUE);
//DrawCylinderWires((Vector3){ 4.5f, -1.0f, 2.0f}, 1.0f, 1.0f, 2.0f, 6, BROWN);

//DrawCylinder((Vector3){ 1.0f, 0.0f, -4.0f}, 0.0f, 1.5f, 3.0f, 8, GOLD);
//DrawCylinderWires((Vector3){ 1.0f, 0.0f, -4.0f}, 0.0f, 1.5f, 3.0f, 8, PINK);

//DrawGrid(10, 1.0f);        // Draw a grid

//EndMode3D();

//DrawText("Press Spacebar to switch camera type", 10, GetScreenHeight() - 30, 20, DARKGRAY);

//if (camera.projection == CAMERA_ORTHOGRAPHIC) DrawText("ORTHOGRAPHIC", 10, 40, 20, BLACK);
//else if (camera.projection == CAMERA_PERSPECTIVE) DrawText("PERSPECTIVE", 10, 40, 20, BLACK);

//DrawFPS(10, 10);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//return 0;
//}


///*******************************************************************************************
//*
//*   raylib [models] example - rlgl module usage with push/pop matrix transformations
//*
//*   This example uses [rlgl] module funtionality (pseudo-OpenGL 1.1 style coding)
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2018 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"
//#include "rlgl.h"

//#include <math.h>           // Required for: cosf(), sinf()

////------------------------------------------------------------------------------------
//// Module Functions Declaration
////------------------------------------------------------------------------------------
//void DrawSphereBasic(Color color);      // Draw sphere without any matrix transformation

////------------------------------------------------------------------------------------
//// Program main entry point
////------------------------------------------------------------------------------------
//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	const float sunRadius = 4.0f;
//	const float earthRadius = 0.6f;
//	const float earthOrbitRadius = 8.0f;
//	const float moonRadius = 0.16f;
//	const float moonOrbitRadius = 1.5f;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - rlgl module usage with push/pop matrix transformations");

//	// Define the camera to look into our 3d world
//	Camera camera = { 0 };
//	camera.position = (Vector3){ 16.0f, 16.0f, 16.0f };
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };
//	camera.fovy = 45.0f;
//	camera.projection = CAMERA_PERSPECTIVE;

//	SetCameraMode(camera, CAMERA_FREE);

//	float rotationSpeed = 0.2f;         // General system rotation speed

//	float earthRotation = 0.0f;         // Rotation of earth around itself (days) in degrees
//	float earthOrbitRotation = 0.0f;    // Rotation of earth around the Sun (years) in degrees
//	float moonRotation = 0.0f;          // Rotation of moon around itself
//	float moonOrbitRotation = 0.0f;     // Rotation of moon around earth in degrees

//	SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())        // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateCamera(&camera);

//		earthRotation += (5.0f * rotationSpeed);
//		earthOrbitRotation += (365 / 360.0f * (5.0f * rotationSpeed) * rotationSpeed);
//		moonRotation += (2.0f * rotationSpeed);
//		moonOrbitRotation += (8.0f * rotationSpeed);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		rlPushMatrix();
//		rlScalef(sunRadius, sunRadius, sunRadius);          // Scale Sun
//		DrawSphereBasic(GOLD);                              // Draw the Sun
//		rlPopMatrix();

//		rlPushMatrix();
//		rlRotatef(earthOrbitRotation, 0.0f, 1.0f, 0.0f);    // Rotation for Earth orbit around Sun
//		rlTranslatef(earthOrbitRadius, 0.0f, 0.0f);         // Translation for Earth orbit

//		rlPushMatrix();
//		rlRotatef(earthRotation, 0.25, 1.0, 0.0);       // Rotation for Earth itself
//		rlScalef(earthRadius, earthRadius, earthRadius);// Scale Earth

//		DrawSphereBasic(BLUE);                          // Draw the Earth
//		rlPopMatrix();

//		rlRotatef(moonOrbitRotation, 0.0f, 1.0f, 0.0f);     // Rotation for Moon orbit around Earth
//		rlTranslatef(moonOrbitRadius, 0.0f, 0.0f);          // Translation for Moon orbit
//		rlRotatef(moonRotation, 0.0f, 1.0f, 0.0f);          // Rotation for Moon itself
//		rlScalef(moonRadius, moonRadius, moonRadius);       // Scale Moon

//		DrawSphereBasic(LIGHTGRAY);                         // Draw the Moon
//		rlPopMatrix();

//		// Some reference elements (not affected by previous matrix transformations)
//		DrawCircle3D((Vector3){ 0.0f, 0.0f, 0.0f }, earthOrbitRadius, (Vector3){ 1, 0, 0 }, 90.0f, Fade(RED, 0.5f));
//DrawGrid(20, 1.0f);

//EndMode3D();

//DrawText("EARTH ORBITING AROUND THE SUN!", 400, 10, 20, MAROON);
//DrawFPS(10, 10);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//return 0;
//}

////--------------------------------------------------------------------------------------------
//// Module Functions Definitions (local)
////--------------------------------------------------------------------------------------------

//// Draw sphere without any matrix transformation
//// NOTE: Sphere is drawn in world position ( 0, 0, 0 ) with radius 1.0f
//void DrawSphereBasic(Color color)
//{
//	int rings = 16;
//	int slices = 16;

//	// Make sure there is enough space in the internal render batch
//	// buffer to store all required vertex, batch is reseted if required
//	rlCheckRenderBatchLimit((rings + 2) * slices * 6);

//	rlBegin(RL_TRIANGLES);
//	rlColor4ub(color.r, color.g, color.b, color.a);

//	for (int i = 0; i < (rings + 2); i++)
//	{
//		for (int j = 0; j < slices; j++)
//		{
//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * sinf(DEG2RAD * (j * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * cosf(DEG2RAD * (j * 360 / slices)));
//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * (j * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * (j * 360 / slices)));

//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * sinf(DEG2RAD * (j * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * cosf(DEG2RAD * (j * 360 / slices)));
//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
//			rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
//					   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
//					   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
//		}
//	}
//	rlEnd();
//}


///*******************************************************************************************
//*
//*   raylib [models] example - Skybox loading and drawing
//*
//*   This example has been created using raylib 3.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2017-2020 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//# include "rlgl.h"
//# include "raymath.h"      // Required for: MatrixPerspective(), MatrixLookAt()

//#if defined(PLATFORM_DESKTOP)
//#define GLSL_VERSION            330
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//#define GLSL_VERSION            100
//#endif

//// Generate cubemap (6 faces) from equirectangular (panorama) texture
//static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format);

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - skybox loading and drawing");

//	// Define the camera to look into our 3d world
//	Camera camera = { { 1.0f, 1.0f, 1.0f }, { 4.0f, 1.0f, 4.0f }, { 0.0f, 1.0f, 0.0f }, 45.0f, 0 };

//	// Load skybox model
//	Mesh cube = GenMeshCube(1.0f, 1.0f, 1.0f);
//	Model skybox = LoadModelFromMesh(cube);

//	bool useHDR = true;

//	// Load skybox shader and set required locations
//	// NOTE: Some locations are automatically set at shader loading
//	skybox.materials[0].shader = LoadShader(TextFormat("resources/shaders/glsl%i/skybox.vs", GLSL_VERSION),
//											TextFormat("resources/shaders/glsl%i/skybox.fs", GLSL_VERSION));

//	SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "environmentMap"), (int[1]){ MATERIAL_MAP_CUBEMAP }, SHADER_UNIFORM_INT);
//SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "doGamma"), (int[1]) { useHDR ? 1 : 0 }, SHADER_UNIFORM_INT);
//SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "vflipped"), (int[1]){ useHDR ? 1 : 0 }, SHADER_UNIFORM_INT);

//// Load cubemap shader and setup required shader locations
//Shader shdrCubemap = LoadShader(TextFormat("resources/shaders/glsl%i/cubemap.vs", GLSL_VERSION),
//								TextFormat("resources/shaders/glsl%i/cubemap.fs", GLSL_VERSION));

//SetShaderValue(shdrCubemap, GetShaderLocation(shdrCubemap, "equirectangularMap"), (int[1]){ 0 }, SHADER_UNIFORM_INT);

//char skyboxFileName[256] = { 0 };

//Texture2D panorama;

//if (useHDR)
//{
//	TextCopy(skyboxFileName, "resources/dresden_square_2k.hdr");

//	// Load HDR panorama (sphere) texture
//	panorama = LoadTexture(skyboxFileName);

//	// Generate cubemap (texture with 6 quads-cube-mapping) from panorama HDR texture
//	// NOTE 1: New texture is generated rendering to texture, shader calculates the sphere->cube coordinates mapping
//	// NOTE 2: It seems on some Android devices WebGL, fbo does not properly support a FLOAT-based attachment,
//	// despite texture can be successfully created.. so using PIXELFORMAT_UNCOMPRESSED_R8G8B8A8 instead of PIXELFORMAT_UNCOMPRESSED_R32G32B32A32
//	skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

//	//UnloadTexture(panorama);    // Texture not required anymore, cubemap already generated
//}
//else
//{
//	Image img = LoadImage("resources/skybox.png");
//	skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);    // CUBEMAP_LAYOUT_PANORAMA
//	UnloadImage(img);
//}

//SetCameraMode(camera, CAMERA_FIRST_PERSON);  // Set a first person camera mode

//SetTargetFPS(60);                       // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//// Main game loop
//while (!WindowShouldClose())            // Detect window close button or ESC key
//{
//	// Update
//	//----------------------------------------------------------------------------------
//	UpdateCamera(&camera);              // Update camera

//	// Load new cubemap texture on drag&drop
//	if (IsFileDropped())
//	{
//		int count = 0;
//		char** droppedFiles = GetDroppedFiles(&count);

//		if (count == 1)         // Only support one file dropped
//		{
//			if (IsFileExtension(droppedFiles[0], ".png;.jpg;.hdr;.bmp;.tga"))
//			{
//				// Unload current cubemap texture and load new one
//				UnloadTexture(skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture);
//				if (useHDR)
//				{
//					Texture2D panorama = LoadTexture(droppedFiles[0]);

//					// Generate cubemap from panorama texture
//					skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);
//					UnloadTexture(panorama);
//				}
//				else
//				{
//					Image img = LoadImage(droppedFiles[0]);
//					skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);
//					UnloadImage(img);
//				}

//				TextCopy(skyboxFileName, droppedFiles[0]);
//			}
//		}

//		ClearDroppedFiles();    // Clear internal buffers
//	}
//	//----------------------------------------------------------------------------------

//	// Draw
//	//----------------------------------------------------------------------------------
//	BeginDrawing();

//	ClearBackground(RAYWHITE);

//	BeginMode3D(camera);

//	// We are inside the cube, we need to disable backface culling!
//	rlDisableBackfaceCulling();
//	rlDisableDepthMask();
//	DrawModel(skybox, (Vector3){ 0, 0, 0}, 1.0f, WHITE);
//	rlEnableBackfaceCulling();
//	rlEnableDepthMask();

//	DrawGrid(10, 1.0f);

//	EndMode3D();

//	//DrawTextureEx(panorama, (Vector2){ 0, 0 }, 0.0f, 0.5f, WHITE);

//	if (useHDR) DrawText(TextFormat("Panorama image from hdrihaven.com: %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);
//	else DrawText(TextFormat(": %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);

//	DrawFPS(10, 10);

//	EndDrawing();
//	//----------------------------------------------------------------------------------
//}

//// De-Initialization
////--------------------------------------------------------------------------------------
//UnloadShader(skybox.materials[0].shader);
//UnloadTexture(skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture);

//UnloadModel(skybox);        // Unload skybox model

//CloseWindow();              // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//return 0;
//}

//// Generate cubemap texture from HDR texture
//static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format)
//{
//	TextureCubemap cubemap = { 0 };

//	rlDisableBackfaceCulling();     // Disable backface culling to render inside the cube

//	// STEP 1: Setup framebuffer
//	//------------------------------------------------------------------------------------------
//	unsigned int rbo = rlLoadTextureDepth(size, size, true);
//	cubemap.id = rlLoadTextureCubemap(0, size, format);

//	unsigned int fbo = rlLoadFramebuffer(size, size);
//	rlFramebufferAttach(fbo, rbo, RL_ATTACHMENT_DEPTH, RL_ATTACHMENT_RENDERBUFFER, 0);
//	rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X, 0);

//	// Check if framebuffer is complete with attachments (valid)
//	if (rlFramebufferComplete(fbo)) TraceLog(LOG_INFO, "FBO: [ID %i] Framebuffer object created successfully", fbo);
//	//------------------------------------------------------------------------------------------

//	// STEP 2: Draw to framebuffer
//	//------------------------------------------------------------------------------------------
//	// NOTE: Shader is used to convert HDR equirectangular environment map to cubemap equivalent (6 faces)
//	rlEnableShader(shader.id);

//	// Define projection matrix and send it to shader
//	Matrix matFboProjection = MatrixPerspective(90.0 * DEG2RAD, 1.0, RL_CULL_DISTANCE_NEAR, RL_CULL_DISTANCE_FAR);
//	rlSetUniformMatrix(shader.locs[SHADER_LOC_MATRIX_PROJECTION], matFboProjection);

//	// Define view matrix for every side of the cubemap
//	Matrix fboViews[6] = {
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){  1.0f,  0.0f,  0.0f }, (Vector3){ 0.0f, -1.0f,  0.0f }),
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){ -1.0f,  0.0f,  0.0f }, (Vector3){ 0.0f, -1.0f,  0.0f }),
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){ 0.0f,  1.0f,  0.0f }, (Vector3){ 0.0f,  0.0f,  1.0f }),
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){ 0.0f, -1.0f,  0.0f }, (Vector3){ 0.0f,  0.0f, -1.0f }),
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){ 0.0f,  0.0f,  1.0f }, (Vector3){ 0.0f, -1.0f,  0.0f }),
//		MatrixLookAt((Vector3){ 0.0f, 0.0f, 0.0f }, (Vector3){ 0.0f,  0.0f, -1.0f }, (Vector3){ 0.0f, -1.0f,  0.0f })
//	};

//rlViewport(0, 0, size, size);   // Set viewport to current fbo dimensions

//// Activate and enable texture for drawing to cubemap faces
//rlActiveTextureSlot(0);
//rlEnableTexture(panorama.id);

//for (int i = 0; i < 6; i++)
//{
//	// Set the view matrix for the current cube face
//	rlSetUniformMatrix(shader.locs[SHADER_LOC_MATRIX_VIEW], fboViews[i]);

//	// Select the current cubemap face attachment for the fbo
//	// WARNING: This function by default enables->attach->disables fbo!!!
//	rlFramebufferAttach(fbo, cubemap.id, RL_ATTACHMENT_COLOR_CHANNEL0, RL_ATTACHMENT_CUBEMAP_POSITIVE_X + i, 0);
//	rlEnableFramebuffer(fbo);

//	// Load and draw a cube, it uses the current enabled texture
//	rlClearScreenBuffers();
//	rlLoadDrawCube();

//	// ALTERNATIVE: Try to use internal batch system to draw the cube instead of rlLoadDrawCube
//	// for some reason this method does not work, maybe due to cube triangles definition? normals pointing out?
//	// TODO: Investigate this issue...
//	//rlSetTexture(panorama.id); // WARNING: It must be called after enabling current framebuffer if using internal batch system!
//	//rlClearScreenBuffers();
//	//DrawCubeV(Vector3Zero(), Vector3One(), WHITE);
//	//rlDrawRenderBatchActive();
//}
////------------------------------------------------------------------------------------------

//// STEP 3: Unload framebuffer and reset state
////------------------------------------------------------------------------------------------
//rlDisableShader();          // Unbind shader
//rlDisableTexture();         // Unbind texture
//rlDisableFramebuffer();     // Unbind framebuffer
//rlUnloadFramebuffer(fbo);   // Unload framebuffer (and automatically attached depth texture/renderbuffer)

//// Reset viewport dimensions to default
//rlViewport(0, 0, rlGetFramebufferWidth(), rlGetFramebufferHeight());
//rlEnableBackfaceCulling();
////------------------------------------------------------------------------------------------

//cubemap.width = size;
//cubemap.height = size;
//cubemap.mipmaps = 1;
//cubemap.format = format;

//return cubemap;
//}

///*******************************************************************************************
//*
//*   raylib [models] example - Waving cubes
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Codecat (@codecat) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Codecat (@codecat) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//#include "raylib.h"

//#include <math.h>

//int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [models] example - waving cubes");

//	// Initialize the camera
//	Camera3D camera = { 0 };
//	camera.position = (Vector3){ 30.0f, 20.0f, 30.0f };
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };
//	camera.fovy = 70.0f;
//	camera.projection = CAMERA_PERSPECTIVE;

//	// Specify the amount of blocks in each direction
//	const int numBlocks = 15;

//	SetTargetFPS(60);
//	//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		double time = GetTime();

//		// Calculate time scale for cube position and size
//		float scale = (2.0f + (float)sin(time)) * 0.7f;

//		// Move camera around the scene
//		double cameraTime = time * 0.3;
//		camera.position.x = (float)cos(cameraTime) * 40.0f;
//		camera.position.z = (float)sin(cameraTime) * 40.0f;
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);

//		DrawGrid(10, 5.0f);

//		for (int x = 0; x < numBlocks; x++)
//		{
//			for (int y = 0; y < numBlocks; y++)
//			{
//				for (int z = 0; z < numBlocks; z++)
//				{
//					// Scale of the blocks depends on x/y/z positions
//					float blockScale = (x + y + z) / 30.0f;

//					// Scatter makes the waving effect by adding blockScale over time
//					float scatter = sinf(blockScale * 20.0f + (float)(time * 4.0f));

//					// Calculate the cube position
//					Vector3 cubePos = {
//								(float)(x - numBlocks/2)*(scale*3.0f) + scatter,
//								(float)(y - numBlocks/2)*(scale*2.0f) + scatter,
//								(float)(z - numBlocks/2)*(scale*3.0f) + scatter
//							};

//					// Pick a color with a hue depending on cube position for the rainbow color effect
//					Color cubeColor = ColorFromHSV((float)(((x + y + z) * 18) % 360), 0.75f, 0.9f);

//					// Calculate cube size
//					float cubeSize = (2.4f - scale) * blockScale;

//					// And finally, draw the cube!
//					DrawCube(cubePos, cubeSize, cubeSize, cubeSize, cubeColor);
//				}
//			}
//		}

//		EndMode3D();

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	CloseWindow();        // Close window and OpenGL context
//						  //--------------------------------------------------------------------------------------

//	return 0;
//}

///*******************************************************************************************
//*
//*   raylib [models] example - Plane rotations (yaw, pitch, roll)
//*
//*   This example has been created using raylib 1.8 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Berni (@Berni8k) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2017-2021 Berni (@Berni8k) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//# include "raylib.h"

//# include "raymath.h"        // Required for: MatrixRotateXYZ()

//int main(void)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	//SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_WINDOW_HIGHDPI);
//	InitWindow(screenWidth, screenHeight, "raylib [models] example - plane rotations (yaw, pitch, roll)");

//	Camera camera = { 0 };
//	camera.position = (Vector3){ 0.0f, 50.0f, -120.0f };// Camera position perspective
//	camera.target = (Vector3){ 0.0f, 0.0f, 0.0f };      // Camera looking at point
//	camera.up = (Vector3){ 0.0f, 1.0f, 0.0f };          // Camera up vector (rotation towards target)
//	camera.fovy = 30.0f;                                // Camera field-of-view Y
//	camera.projection = CAMERA_PERSPECTIVE;             // Camera type

//	Model model = LoadModel("resources/models/obj/plane.obj");                  // Load model
//	Texture2D texture = LoadTexture("resources/models/obj/plane_diffuse.png");  // Load model texture
//	model.materials[0].maps[MATERIAL_MAP_DIFFUSE].texture = texture;            // Set map diffuse texture

//	float pitch = 0.0f;
//	float roll = 0.0f;
//	float yaw = 0.0f;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		// Plane pitch (x-axis) controls
//		if (IsKeyDown(KEY_DOWN)) pitch += 0.6f;
//		else if (IsKeyDown(KEY_UP)) pitch -= 0.6f;
//		else
//		{
//			if (pitch > 0.3f) pitch -= 0.3f;
//			else if (pitch < -0.3f) pitch += 0.3f;
//		}

//		// Plane yaw (y-axis) controls
//		if (IsKeyDown(KEY_S)) yaw += 1.0f;
//		else if (IsKeyDown(KEY_A)) yaw -= 1.0f;
//		else
//		{
//			if (yaw > 0.0f) yaw -= 0.5f;
//			else if (yaw < 0.0f) yaw += 0.5f;
//		}

//		// Plane roll (z-axis) controls
//		if (IsKeyDown(KEY_LEFT)) roll += 1.0f;
//		else if (IsKeyDown(KEY_RIGHT)) roll -= 1.0f;
//		else
//		{
//			if (roll > 0.0f) roll -= 0.5f;
//			else if (roll < 0.0f) roll += 0.5f;
//		}

//		// Tranformation matrix for rotations
//		model.transform = MatrixRotateXYZ((Vector3){ DEG2RAD* pitch, DEG2RAD*yaw, DEG2RAD* roll });
////----------------------------------------------------------------------------------

//// Draw
////----------------------------------------------------------------------------------
//BeginDrawing();

//ClearBackground(RAYWHITE);

//// Draw 3D model (recomended to draw 3D always before 2D)
//BeginMode3D(camera);

//DrawModel(model, (Vector3){ 0.0f, -8.0f, 0.0f }, 1.0f, WHITE);   // Draw 3d model with texture
//DrawGrid(10, 10.0f);

//EndMode3D();

//// Draw controls info
//DrawRectangle(30, 370, 260, 70, Fade(GREEN, 0.5f));
//DrawRectangleLines(30, 370, 260, 70, Fade(DARKGREEN, 0.5f));
//DrawText("Pitch controlled with: KEY_UP / KEY_DOWN", 40, 380, 10, DARKGRAY);
//DrawText("Roll controlled with: KEY_LEFT / KEY_RIGHT", 40, 400, 10, DARKGRAY);
//DrawText("Yaw controlled with: KEY_A / KEY_S", 40, 420, 10, DARKGRAY);

//DrawText("(c) WWI Plane Model created by GiaHanLam", screenWidth - 240, screenHeight - 20, 10, DARKGRAY);

//EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadModel(model);     // Unload model data

//CloseWindow();          // Close window and OpenGL context
//						//--------------------------------------------------------------------------------------

//return 0;
//}


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

//#ifndef RLIGHTS_H
//#define RLIGHTS_H

////----------------------------------------------------------------------------------
//// Defines and Macros
////----------------------------------------------------------------------------------
//#define         MAX_LIGHTS            4         // Max dynamic lights supported by shader

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
//} Light;

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
//	Light light = { 0 };

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
//	float position[3] = { light.position.x, light.position.y, light.position.z };
//	SetShaderValue(shader, light.posLoc, position, SHADER_UNIFORM_VEC3);

//	// Send to shader light target position values
//	float target[3] = { light.target.x, light.target.y, light.target.z };
//	SetShaderValue(shader, light.targetLoc, target, SHADER_UNIFORM_VEC3);

//	// Send to shader light color values
//	float color[4] = { (float)light.color.r/(float)255, (float)light.color.g/(float)255, 
//					   (float)light.color.b/(float)255, (float)light.color.a/(float)255 };
//	SetShaderValue(shader, light.colorLoc, color, SHADER_UNIFORM_VEC4);
//}

//#endif // RLIGHTS_IMPLEMENTATION

