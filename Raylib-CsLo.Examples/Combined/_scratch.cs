//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
//// [!!] Copyright (c) Raylib-CsLo and Contributors. 
//// [!!] This file is licensed to you under the LGPL-2.1.
//// [!!] See the LICENSE file in the project root for more info. 
//// [!!] ------------------------------------------------- 
//// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
//// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

//namespace Raylib_CsLo.Examples.Combined;

///*******************************************************************************************
//*
//*   raylib [shapes] example - Draw basic shapes 2d (rectangle, circle, line...)
//*
//*   This example has been created using raylib 1.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class BasicShapesDrawing
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - basic shapes drawing");

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			// TODO: Update your variables here
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("some basic shapes available on raylib", 20, 20, 20, DARKGRAY);

//			// Circle shapes and lines
//			DrawCircle(screenWidth / 5, 120, 35, DARKBLUE);
//			DrawCircleGradient(screenWidth / 5, 220, 60, GREEN, SKYBLUE);
//			DrawCircleLines(screenWidth / 5, 340, 80, DARKBLUE);

//			// Rectangle shapes and ines
//			DrawRectangle(screenWidth / 4 * 2 - 60, 100, 120, 60, RED);
//			DrawRectangleGradientH(screenWidth / 4 * 2 - 90, 170, 180, 130, MAROON, GOLD);
//			DrawRectangleLines(screenWidth / 4 * 2 - 40, 320, 80, 60, ORANGE);  // NOTE: Uses QUADS internally, not lines

//			// Triangle shapes and lines
//			DrawTriangle(new Vector2(screenWidth / 4.0f * 3.0f, 80.0f),
//						 new Vector2(screenWidth / 4.0f * 3.0f - 60.0f, 150.0f),
//						 new Vector2(screenWidth / 4.0f * 3.0f + 60.0f, 150.0f), VIOLET);

//			DrawTriangleLines(new Vector2(screenWidth / 4.0f * 3.0f, 160.0f),
//							  new Vector2(screenWidth / 4.0f * 3.0f - 20.0f, 230.0f),
//							  new Vector2(screenWidth / 4.0f * 3.0f + 20.0f, 230.0f), DARKBLUE);

//			// Polygon shapes and lines
//			DrawPoly(new Vector2(screenWidth / 4.0f * 3, 320), 6, 80, 0, BROWN);
//			DrawPolyLinesEx(new Vector2(screenWidth / 4.0f * 3, 320), 6, 80, 0, 6, BEIGE);

//			// NOTE: We draw all LINES based shapes together to optimize internal drawing,
//			// this way, all LINES are rendered in a single draw pass
//			DrawLine(18, 42, screenWidth - 18, 42, BLACK);
//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - bouncing ball
//*
//*   This example has been created using raylib 1.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2013 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class BoundingBall
//{

//	public static int main()
//	{
//		// Initialization
//		//---------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - bouncing ball");

//		Vector2 ballPosition = new Vector2(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
//		Vector2 ballSpeed = new Vector2(5.0f, 4.0f);
//		int ballRadius = 20;

//		bool pause = 0;
//		int framesCounter = 0;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//----------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//-----------------------------------------------------
//			if (IsKeyPressed(KEY_SPACE)) pause = !pause;

//			if (!pause)
//			{
//				ballPosition.X += ballSpeed.X;
//				ballPosition.Y += ballSpeed.Y;

//				// Check walls collision for bouncing
//				if ((ballPosition.X >= (GetScreenWidth() - ballRadius)) || (ballPosition.X <= ballRadius)) ballSpeed.X *= -1.0f;
//				if ((ballPosition.Y >= (GetScreenHeight() - ballRadius)) || (ballPosition.Y <= ballRadius)) ballSpeed.Y *= -1.0f;
//			}
//			else framesCounter++;
//			//-----------------------------------------------------

//			// Draw
//			//-----------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawCircleV(ballPosition, (float)ballRadius, MAROON);
//			DrawText("PRESS SPACE to PAUSE BALL MOVEMENT", 10, GetScreenHeight() - 25, 20, LIGHTGRAY);

//			// On pause, we draw a blinking message
//			if (pause && ((framesCounter / 30) % 2)!=0) DrawText("PAUSED", 350, 200, 30, GRAY);

//			DrawFPS(10, 10);

//			EndDrawing();
//			//-----------------------------------------------------
//		}

//		// De-Initialization
//		//---------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //----------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - collision area
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2013-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class CollisionArea
//{
//	// #include <stdlib.h>     // Required for abs()

//	public static int main()
//	{
//		// Initialization
//		//---------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - collision area");

//		// Box A: Moving box
//		Rectangle boxA = new Rectangle(10, GetScreenHeight() / 2.0f - 50, 200, 100);
//		int boxASpeedX = 4;

//		// Box B: Mouse moved box
//		Rectangle boxB = new Rectangle(GetScreenWidth() / 2.0f - 30, GetScreenHeight() / 2.0f - 30, 60, 60);

//		Rectangle boxCollision = new Rectangle(); // Collision rectangle

//		int screenUpperLimit = 40;      // Top menu limits

//		bool pause = false;             // Movement pause
//		bool collision = false;         // Collision detection

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//----------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//-----------------------------------------------------
//			// Move box if not paused
//			if (!pause) boxA.X += boxASpeedX;

//			// Bounce box on x screen limits
//			if (((boxA.X + boxA.width) >= GetScreenWidth()) || (boxA.X <= 0)) boxASpeedX *= -1;

//			// Update player-controlled-box (box02)
//			boxB.X = GetMouseX() - boxB.width / 2;
//			boxB.Y = GetMouseY() - boxB.height / 2;

//			// Make sure Box B does not go out of move area limits
//			if ((boxB.X + boxB.width) >= GetScreenWidth()) boxB.X = GetScreenWidth() - boxB.width;
//			else if (boxB.X <= 0) boxB.X = 0;

//			if ((boxB.Y + boxB.height) >= GetScreenHeight()) boxB.Y = GetScreenHeight() - boxB.height;
//			else if (boxB.Y <= screenUpperLimit) boxB.Y = (float)screenUpperLimit;

//			// Check boxes collision
//			collision = CheckCollisionRecs(boxA, boxB);

//			// Get collision rectangle (only on collision)
//			if (collision) boxCollision = GetCollisionRec(boxA, boxB);

//			// Pause Box A movement
//			if (IsKeyPressed(KEY_SPACE)) pause = !pause;
//			//-----------------------------------------------------

//			// Draw
//			//-----------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawRectangle(0, 0, screenWidth, screenUpperLimit, collision ? RED : BLACK);

//			DrawRectangleRec(boxA, GOLD);
//			DrawRectangleRec(boxB, BLUE);

//			if (collision)
//			{
//				// Draw collision area
//				DrawRectangleRec(boxCollision, LIME);

//				// Draw collision message
//				DrawText("COLLISION!", GetScreenWidth() / 2 - MeasureText("COLLISION!", 20) / 2, screenUpperLimit / 2 - 10, 20, BLACK);

//				// Draw collision area
//				DrawText(TextFormat("Collision Area: %i", (int)boxCollision.width * (int)boxCollision.height), GetScreenWidth() / 2 - 100, screenUpperLimit + 10, 20, BLACK);
//			}

//			DrawFPS(10, 10);

//			EndDrawing();
//			//-----------------------------------------------------
//		}

//		// De-Initialization
//		//---------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //----------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - Colors palette
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class ColorsPalette
//{

//	const int MAX_COLORS_COUNT = 21;          // Number of colors available

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - colors palette");

//		Color[] colors = new Color[MAX_COLORS_COUNT] {
//		DARKGRAY, MAROON, ORANGE, DARKGREEN, DARKBLUE, DARKPURPLE, DARKBROWN,
//		GRAY, RED, GOLD, LIME, BLUE, VIOLET, BROWN, LIGHTGRAY, PINK, YELLOW,
//		GREEN, SKYBLUE, PURPLE, BEIGE };

//		string[] colorNames = new string[MAX_COLORS_COUNT] {
//		"DARKGRAY", "MAROON", "ORANGE", "DARKGREEN", "DARKBLUE", "DARKPURPLE",
//		"DARKBROWN", "GRAY", "RED", "GOLD", "LIME", "BLUE", "VIOLET", "BROWN",
//		"LIGHTGRAY", "PINK", "YELLOW", "GREEN", "SKYBLUE", "PURPLE", "BEIGE" };

//		Rectangle[] colorsRecs = new Rectangle[MAX_COLORS_COUNT];     // Rectangles array

//		// Fills colorsRecs data (for every rectangle)
//		for (int i = 0; i < MAX_COLORS_COUNT; i++)
//		{
//			colorsRecs[i].X = 20.0f + 100.0f * (i % 7) + 10.0f * (i % 7);
//			colorsRecs[i].Y = 80.0f + 100.0f * (i / 7) + 10.0f * (i / 7);
//			colorsRecs[i].width = 100.0f;
//			colorsRecs[i].height = 100.0f;
//		}

//		int[] colorState = new int[MAX_COLORS_COUNT];           // Color state: 0-DEFAULT, 1-MOUSE_HOVER

//		Vector2 mousePoint = new Vector2(0.0f, 0.0f);

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			mousePoint = GetMousePosition();

//			for (int i = 0; i < MAX_COLORS_COUNT; i++)
//			{
//				if (CheckCollisionPointRec(mousePoint, colorsRecs[i])) colorState[i] = 1;
//				else colorState[i] = 0;
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("raylib colors palette", 28, 42, 20, BLACK);
//			DrawText("press SPACE to see all colors", GetScreenWidth() - 180, GetScreenHeight() - 40, 10, GRAY);

//			for (int i = 0; i < MAX_COLORS_COUNT; i++)    // Draw all rectangles
//			{
//				DrawRectangleRec(colorsRecs[i], Fade(colors[i], colorState[i]==1 ? 0.6f : 1.0f));

//				if (IsKeyDown(KEY_SPACE) || colorState[i] == 1)
//				{
//					DrawRectangle((int)colorsRecs[i].X, (int)(colorsRecs[i].Y + colorsRecs[i].height - 26), (int)colorsRecs[i].width, 20, BLACK);
//					DrawRectangleLinesEx(colorsRecs[i], 6, Fade(BLACK, 0.3f));
//					DrawText(colorNames[i], (int)(colorsRecs[i].X + colorsRecs[i].width - MeasureText(colorNames[i], 10) - 12),
//						(int)(colorsRecs[i].Y + colorsRecs[i].height - 20), 10, colors[i]);
//				}
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();                // Close window and OpenGL context
//									  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - draw circle sector (with gui options)
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class DrawCircleSector {

////#define RAYGUI_IMPLEMENTATION
//// # include "extras/raygui.h"                 // Required for GUI controls

//public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw circle sector");

//	Vector2 center = new Vector2((GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f);

//	float outerRadius = 180.0f;
//	float startAngle = 0.0f;
//	float endAngle = 180.0f;
//	int segments = 0;
//	int minSegments = 4;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		// NOTE: All variables update happens inside GUI control functions
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		DrawLine(500, 0, 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.6f));
//		DrawRectangle(500, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.3f));

//		DrawCircleSector(center, outerRadius, startAngle, endAngle, segments, Fade(MAROON, 0.3f));
//		DrawCircleSectorLines(center, outerRadius, startAngle, endAngle, segments, Fade(MAROON, 0.6f));

//		// Draw GUI controls
//		//------------------------------------------------------------------------------
//		startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", null, startAngle, 0, 720);
//		endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", null, endAngle, 0, 720);

//		outerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "Radius", null, outerRadius, 0, 200);
//		segments = (int)GuiSliderBar(new Rectangle(600, 170, 120, 20), "Segments", null, (float)segments, 0, 100);
//		//------------------------------------------------------------------------------

//		minSegments = (int)MathF.Ceiling((endAngle - startAngle) / 90);
//		DrawText(TextFormat("MODE: %s", (segments >= minSegments) ? "MANUAL" : "AUTO"), 600, 200, 10, (segments >= minSegments) ? MAROON : DARKGRAY);

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
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - draw rectangle rounded (with gui options)
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class DrawRectangleRounded {

//	//#define RAYGUI_IMPLEMENTATION
//	//# include "extras/raygui.h"                 // Required for GUI controls

//	public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw rectangle rounded");

//	float roundness = 0.2f;
//	int width = 200;
//	int height = 100;
//	int segments = 0;
//	int lineThick = 1;

//	bool drawRect = false;
//	bool drawRoundedRect = true;
//	bool drawRoundedLines = false;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		Rectangle rec = new Rectangle(((float)GetScreenWidth() - width - 250) / 2, (GetScreenHeight() - height) / 2.0f, (float)width, (float)height);
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		DrawLine(560, 0, 560, GetScreenHeight(), Fade(LIGHTGRAY, 0.6f));
//		DrawRectangle(560, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.3f));

//		if (drawRect) DrawRectangleRec(rec, Fade(GOLD, 0.6f));
//		if (drawRoundedRect) DrawRectangleRounded(rec, roundness, segments, Fade(MAROON, 0.2f));
//		if (drawRoundedLines) DrawRectangleRoundedLines(rec, roundness, segments, (float)lineThick, Fade(MAROON, 0.4f));

//		// Draw GUI controls
//		//------------------------------------------------------------------------------
//		width = (int)GuiSliderBar(new Rectangle(640, 40, 105, 20), "Width", null, (float)width, 0, (float)GetScreenWidth() - 300);
//		height = (int)GuiSliderBar(new Rectangle(640, 70, 105, 20), "Height", null, (float)height, 0, (float)GetScreenHeight() - 50);
//		roundness = GuiSliderBar(new Rectangle(640, 140, 105, 20), "Roundness", null, roundness, 0.0f, 1.0f);
//		lineThick = (int)GuiSliderBar(new Rectangle(640, 170, 105, 20), "Thickness", null, (float)lineThick, 0, 20);
//		segments = (int)GuiSliderBar(new Rectangle(640, 240, 105, 20), "Segments", null, (float)segments, 0, 60);

//		drawRoundedRect = GuiCheckBox(new Rectangle(640, 320, 20, 20), "DrawRoundedRect", drawRoundedRect);
//		drawRoundedLines = GuiCheckBox(new Rectangle(640, 350, 20, 20), "DrawRoundedLines", drawRoundedLines);
//		drawRect = GuiCheckBox(new Rectangle(640, 380, 20, 20), "DrawRect", drawRect);
//		//------------------------------------------------------------------------------

//		DrawText(TextFormat("MODE: %s", (segments >= 4) ? "MANUAL" : "AUTO"), 640, 280, 10, (segments >= 4) ? MAROON : DARKGRAY);

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
//}


///*******************************************************************************************
//*
//*   raylib [shapes] example - draw ring (with gui options)
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE {

//#define RAYGUI_IMPLEMENTATION
//# include "extras/raygui.h"                 // Required for GUI controls

//public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw ring");

//	Vector2 center = new Vector2((GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f);

//	float innerRadius = 80.0f;
//	float outerRadius = 190.0f;

//	float startAngle = 0.0f;
//	float endAngle = 360.0f;
//	int segments = 0;
//	int minSegments = 4;

//	bool drawRing = true;
//	bool drawRingLines = false;
//	bool drawCircleLines = false;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		// NOTE: All variables update happens inside GUI control functions
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		DrawLine(500, 0, 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.6f));
//		DrawRectangle(500, 0, GetScreenWidth() - 500, GetScreenHeight(), Fade(LIGHTGRAY, 0.3f));

//		if (drawRing) DrawRing(center, innerRadius, outerRadius, startAngle, endAngle, segments, Fade(MAROON, 0.3f));
//		if (drawRingLines) DrawRingLines(center, innerRadius, outerRadius, startAngle, endAngle, segments, Fade(BLACK, 0.4f));
//		if (drawCircleLines) DrawCircleSectorLines(center, outerRadius, startAngle, endAngle, segments, Fade(BLACK, 0.4f));

//		// Draw GUI controls
//		//------------------------------------------------------------------------------
//		startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", null, startAngle, -450, 450);
//		endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", null, endAngle, -450, 450);

//		innerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "InnerRadius", null, innerRadius, 0, 100);
//		outerRadius = GuiSliderBar(new Rectangle(600, 170, 120, 20), "OuterRadius", null, outerRadius, 0, 200);

//		segments = (int)GuiSliderBar(new Rectangle(600, 240, 120, 20), "Segments", null, (float)segments, 0, 100);

//		drawRing = GuiCheckBox(new Rectangle(600, 320, 20, 20), "Draw Ring", drawRing);
//		drawRingLines = GuiCheckBox(new Rectangle(600, 350, 20, 20), "Draw RingLines", drawRingLines);
//		drawCircleLines = GuiCheckBox(new Rectangle(600, 380, 20, 20), "Draw CircleLines", drawCircleLines);
//		//------------------------------------------------------------------------------

//		minSegments = (int)MathF.Ceiling((endAngle - startAngle) / 90);
//		DrawText(TextFormat("MODE: %s", (segments >= minSegments) ? "MANUAL" : "AUTO"), 600, 270, 10, (segments >= minSegments) ? MAROON : DARKGRAY);

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
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - easings ball anim
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	// # include "extras/easings.h"                // Required for easing functions

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings ball anim");

//		// Ball variable value to be animated with easings
//		int ballPositionX = -100;
//		int ballRadius = 20;
//		float ballAlpha = 0.0f;

//		int state = 0;
//		int framesCounter = 0;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (state == 0)             // Move ball position X with easing
//			{
//				framesCounter++;
//				ballPositionX = (int)EaseElasticOut((float)framesCounter, -100, screenWidth / 2.0f + 100, 120);

//				if (framesCounter >= 120)
//				{
//					framesCounter = 0;
//					state = 1;
//				}
//			}
//			else if (state == 1)        // Increase ball radius with easing
//			{
//				framesCounter++;
//				ballRadius = (int)EaseElasticIn((float)framesCounter, 20, 500, 200);

//				if (framesCounter >= 200)
//				{
//					framesCounter = 0;
//					state = 2;
//				}
//			}
//			else if (state == 2)        // Change ball alpha with easing (background color blending)
//			{
//				framesCounter++;
//				ballAlpha = EaseCubicOut((float)framesCounter, 0.0f, 1.0f, 200);

//				if (framesCounter >= 200)
//				{
//					framesCounter = 0;
//					state = 3;
//				}
//			}
//			else if (state == 3)        // Reset state to play again
//			{
//				if (IsKeyPressed(KEY_ENTER))
//				{
//					// Reset required variables to play again
//					ballPositionX = -100;
//					ballRadius = 20;
//					ballAlpha = 0.0f;
//					state = 0;
//				}
//			}

//			if (IsKeyPressed(KEY_R)) framesCounter = 0;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			if (state >= 2) DrawRectangle(0, 0, screenWidth, screenHeight, GREEN);
//			DrawCircle(ballPositionX, 200, (float)ballRadius, Fade(RED, 1.0f - ballAlpha));

//			if (state == 3) DrawText("PRESS [ENTER] TO PLAY AGAIN!", 240, 200, 20, BLACK);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - easings box anim
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	// # include "extras/easings.h"            // Required for easing functions

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings box anim");

//		// Box variables to be animated with easings
//		Rectangle rec = new Rectangle(GetScreenWidth() / 2.0f, -100, 100, 100);
//		float rotation = 0.0f;
//		float alpha = 1.0f;

//		int state = 0;
//		int framesCounter = 0;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			switch (state)
//			{
//				case 0:     // Move box down to center of screen
//					{
//						framesCounter++;

//						// NOTE: Remember that 3rd parameter of easing function refers to
//						// desired value variation, do not confuse it with expected final value!
//						rec.Y = EaseElasticOut((float)framesCounter, -100, GetScreenHeight() / 2.0f + 100, 120);

//						if (framesCounter >= 120)
//						{
//							framesCounter = 0;
//							state = 1;
//						}
//					}
//					break;
//				case 1:     // Scale box to an horizontal bar
//					{
//						framesCounter++;
//						rec.height = EaseBounceOut((float)framesCounter, 100, -90, 120);
//						rec.width = EaseBounceOut((float)framesCounter, 100, (float)GetScreenWidth(), 120);

//						if (framesCounter >= 120)
//						{
//							framesCounter = 0;
//							state = 2;
//						}
//					}
//					break;
//				case 2:     // Rotate horizontal bar rectangle
//					{
//						framesCounter++;
//						rotation = EaseQuadOut((float)framesCounter, 0.0f, 270.0f, 240);

//						if (framesCounter >= 240)
//						{
//							framesCounter = 0;
//							state = 3;
//						}
//					}
//					break;
//				case 3:     // Increase bar size to fill all screen
//					{
//						framesCounter++;
//						rec.height = EaseCircOut((float)framesCounter, 10, (float)GetScreenWidth(), 120);

//						if (framesCounter >= 120)
//						{
//							framesCounter = 0;
//							state = 4;
//						}
//					}
//					break;
//				case 4:     // Fade out animation
//					{
//						framesCounter++;
//						alpha = EaseSineOut((float)framesCounter, 1.0f, -1.0f, 160);

//						if (framesCounter >= 160)
//						{
//							framesCounter = 0;
//							state = 5;
//						}
//					}
//					break;
//				default: break;
//			}

//			// Reset animation at any moment
//			if (IsKeyPressed(KEY_SPACE))
//			{
//				rec = new Rectangle(GetScreenWidth() / 2.0f, -100, 100, 100);
//				rotation = 0.0f;
//				alpha = 1.0f;
//				state = 0;
//				framesCounter = 0;
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawRectanglePro(rec, new Vector2(rec.width / 2, rec.height / 2), rotation, Fade(BLACK, alpha));

//			DrawText("PRESS [SPACE] TO RESET BOX ANIMATION!", 10, GetScreenHeight() - 25, 20, LIGHTGRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}


///*******************************************************************************************
//*
//*   raylib [shapes] example - easings rectangle array
//*
//*   NOTE: This example requires 'easings.h' library, provided on raylib/src. Just copy
//*   the library to same directory as example or make sure it's available on include path.
//*
//*   This example has been created using raylib 2.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	// # include "extras/easings.h"            // Required for easing functions

//	const int RECS_WIDTH = 50;
//	const int RECS_HEIGHT = 50;

//	const int MAX_RECS_X = 800;/RECS_WIDTH
//const int MAX_RECS_Y = 450;/RECS_HEIGHT

//const int PLAY_TIME_IN_FRAMES = 240;                 // At 60 fps = 4 seconds

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings rectangle array");

//		Rectangle recs[MAX_RECS_X * MAX_RECS_Y] = { 0 };

//		for (int y = 0; y < MAX_RECS_Y; y++)
//		{
//			for (int x = 0; x < MAX_RECS_X; x++)
//			{
//				recs[y * MAX_RECS_X + x].X = RECS_WIDTH / 2.0f + RECS_WIDTH * x;
//				recs[y * MAX_RECS_X + x].Y = RECS_HEIGHT / 2.0f + RECS_HEIGHT * y;
//				recs[y * MAX_RECS_X + x].width = RECS_WIDTH;
//				recs[y * MAX_RECS_X + x].height = RECS_HEIGHT;
//			}
//		}

//		float rotation = 0.0f;
//		int framesCounter = 0;
//		int state = 0;                  // Rectangles animation state: 0-Playing, 1-Finished

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (state == 0)
//			{
//				framesCounter++;

//				for (int i = 0; i < MAX_RECS_X * MAX_RECS_Y; i++)
//				{
//					recs[i].height = EaseCircOut((float)framesCounter, RECS_HEIGHT, -RECS_HEIGHT, PLAY_TIME_IN_FRAMES);
//					recs[i].width = EaseCircOut((float)framesCounter, RECS_WIDTH, -RECS_WIDTH, PLAY_TIME_IN_FRAMES);

//					if (recs[i].height < 0) recs[i].height = 0;
//					if (recs[i].width < 0) recs[i].width = 0;

//					if ((recs[i].height == 0) && (recs[i].width == 0)) state = 1;   // Finish playing

//					rotation = EaseLinearIn((float)framesCounter, 0.0f, 360.0f, PLAY_TIME_IN_FRAMES);
//				}
//			}
//			else if ((state == 1) && IsKeyPressed(KEY_SPACE))
//			{
//				// When animation has finished, press space to restart
//				framesCounter = 0;

//				for (int i = 0; i < MAX_RECS_X * MAX_RECS_Y; i++)
//				{
//					recs[i].height = RECS_HEIGHT;
//					recs[i].width = RECS_WIDTH;
//				}

//				state = 0;
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			if (state == 0)
//			{
//				for (int i = 0; i < MAX_RECS_X * MAX_RECS_Y; i++)
//				{
//					DrawRectanglePro(recs[i], new Vector2(recs[i].width / 2, recs[i].height / 2), rotation, RED);
//				}
//			}
//			else if (state == 1) DrawText("PRESS [SPACE] TO PLAY AGAIN!", 240, 200, 20, GRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - following eyes
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2013-2019 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	// # include <math.h>       // Required for: atan2f()

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - following eyes");

//		Vector2 scleraLeftPosition = new Vector2(GetScreenWidth() / 2.0f - 100.0f, GetScreenHeight() / 2.0f);
//		Vector2 scleraRightPosition = new Vector2(GetScreenWidth() / 2.0f + 100.0f, GetScreenHeight() / 2.0f);
//		float scleraRadius = 80;

//		Vector2 irisLeftPosition = new Vector2(GetScreenWidth() / 2.0f - 100.0f, GetScreenHeight() / 2.0f);
//		Vector2 irisRightPosition = new Vector2(GetScreenWidth() / 2.0f + 100.0f, GetScreenHeight() / 2.0f);
//		float irisRadius = 24;

//		float angle = 0.0f;
//		float dx = 0.0f, dy = 0.0f, dxx = 0.0f, dyy = 0.0f;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			irisLeftPosition = GetMousePosition();
//			irisRightPosition = GetMousePosition();

//			// Check not inside the left eye sclera
//			if (!CheckCollisionPointCircle(irisLeftPosition, scleraLeftPosition, scleraRadius - 20))
//			{
//				dx = irisLeftPosition.X - scleraLeftPosition.X;
//				dy = irisLeftPosition.Y - scleraLeftPosition.Y;

//				angle = atan2f(dy, dx);

//				dxx = (scleraRadius - irisRadius) * MathF.Cos(angle);
//				dyy = (scleraRadius - irisRadius) * MathF.Sin(angle);

//				irisLeftPosition.X = scleraLeftPosition.X + dxx;
//				irisLeftPosition.Y = scleraLeftPosition.Y + dyy;
//			}

//			// Check not inside the right eye sclera
//			if (!CheckCollisionPointCircle(irisRightPosition, scleraRightPosition, scleraRadius - 20))
//			{
//				dx = irisRightPosition.X - scleraRightPosition.X;
//				dy = irisRightPosition.Y - scleraRightPosition.Y;

//				angle = atan2f(dy, dx);

//				dxx = (scleraRadius - irisRadius) * MathF.Cos(angle);
//				dyy = (scleraRadius - irisRadius) * MathF.Sin(angle);

//				irisRightPosition.X = scleraRightPosition.X + dxx;
//				irisRightPosition.Y = scleraRightPosition.Y + dyy;
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawCircleV(scleraLeftPosition, scleraRadius, LIGHTGRAY);
//			DrawCircleV(irisLeftPosition, irisRadius, BROWN);
//			DrawCircleV(irisLeftPosition, 10, BLACK);

//			DrawCircleV(scleraRightPosition, scleraRadius, LIGHTGRAY);
//			DrawCircleV(irisRightPosition, irisRadius, DARKGREEN);
//			DrawCircleV(irisRightPosition, 10, BLACK);

//			DrawFPS(10, 10);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - Cubic-bezier lines
//*
//*   This example has been created using raylib 1.7 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		SetConfigFlags(FLAG_MSAA_4X_HINT);
//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - cubic-bezier lines");

//		Vector2 start = new Vector2(0, 0);
//		Vector2 end = new Vector2((float)screenWidth, (float)screenHeight);

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsMouseButtonDown(MOUSE_BUTTON_LEFT)) start = GetMousePosition();
//			else if (IsMouseButtonDown(MOUSE_BUTTON_RIGHT)) end = GetMousePosition();
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("USE MOUSE LEFT-RIGHT CLICK to DEFINE LINE START and END POINTS", 15, 20, 20, GRAY);

//			DrawLineBezier(start, end, 2.0f, RED);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - Draw raylib logo using basic shapes
//*
//*   This example has been created using raylib 1.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo using shapes");

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			// TODO: Update your variables here
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawRectangle(screenWidth / 2 - 128, screenHeight / 2 - 128, 256, 256, BLACK);
//			DrawRectangle(screenWidth / 2 - 112, screenHeight / 2 - 112, 224, 224, RAYWHITE);
//			DrawText("raylib", screenWidth / 2 - 44, screenHeight / 2 + 48, 50, BLACK);

//			DrawText("this is NOT a texture!", 350, 370, 10, GRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - raylib logo animation
//*
//*   This example has been created using raylib 2.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - raylib logo animation");

//		int logoPositionX = screenWidth / 2 - 128;
//		int logoPositionY = screenHeight / 2 - 128;

//		int framesCounter = 0;
//		int lettersCount = 0;

//		int topSideRecWidth = 16;
//		int leftSideRecHeight = 16;

//		int bottomSideRecWidth = 16;
//		int rightSideRecHeight = 16;

//		int state = 0;                  // Tracking animation states (State Machine)
//		float alpha = 1.0f;             // Useful for fading

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (state == 0)                 // State 0: Small box blinking
//			{
//				framesCounter++;

//				if (framesCounter == 120)
//				{
//					state = 1;
//					framesCounter = 0;      // Reset counter... will be used later...
//				}
//			}
//			else if (state == 1)            // State 1: Top and left bars growing
//			{
//				topSideRecWidth += 4;
//				leftSideRecHeight += 4;

//				if (topSideRecWidth == 256) state = 2;
//			}
//			else if (state == 2)            // State 2: Bottom and right bars growing
//			{
//				bottomSideRecWidth += 4;
//				rightSideRecHeight += 4;

//				if (bottomSideRecWidth == 256) state = 3;
//			}
//			else if (state == 3)            // State 3: Letters appearing (one by one)
//			{
//				framesCounter++;

//				if (framesCounter / 12)       // Every 12 frames, one more letter!
//				{
//					lettersCount++;
//					framesCounter = 0;
//				}

//				if (lettersCount >= 10)     // When all letters have appeared, just fade out everything
//				{
//					alpha -= 0.02f;

//					if (alpha <= 0.0f)
//					{
//						alpha = 0.0f;
//						state = 4;
//					}
//				}
//			}
//			else if (state == 4)            // State 4: Reset and Replay
//			{
//				if (IsKeyPressed(KEY_R))
//				{
//					framesCounter = 0;
//					lettersCount = 0;

//					topSideRecWidth = 16;
//					leftSideRecHeight = 16;

//					bottomSideRecWidth = 16;
//					rightSideRecHeight = 16;

//					alpha = 1.0f;
//					state = 0;          // Return to State 0
//				}
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			if (state == 0)
//			{
//				if ((framesCounter / 15) % 2) DrawRectangle(logoPositionX, logoPositionY, 16, 16, BLACK);
//			}
//			else if (state == 1)
//			{
//				DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, BLACK);
//				DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, BLACK);
//			}
//			else if (state == 2)
//			{
//				DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, BLACK);
//				DrawRectangle(logoPositionX, logoPositionY, 16, leftSideRecHeight, BLACK);

//				DrawRectangle(logoPositionX + 240, logoPositionY, 16, rightSideRecHeight, BLACK);
//				DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWidth, 16, BLACK);
//			}
//			else if (state == 3)
//			{
//				DrawRectangle(logoPositionX, logoPositionY, topSideRecWidth, 16, Fade(BLACK, alpha));
//				DrawRectangle(logoPositionX, logoPositionY + 16, 16, leftSideRecHeight - 32, Fade(BLACK, alpha));

//				DrawRectangle(logoPositionX + 240, logoPositionY + 16, 16, rightSideRecHeight - 32, Fade(BLACK, alpha));
//				DrawRectangle(logoPositionX, logoPositionY + 240, bottomSideRecWidth, 16, Fade(BLACK, alpha));

//				DrawRectangle(GetScreenWidth() / 2 - 112, GetScreenHeight() / 2 - 112, 224, 224, Fade(RAYWHITE, alpha));

//				DrawText(TextSubtext("raylib", 0, lettersCount), GetScreenWidth() / 2 - 44, GetScreenHeight() / 2 + 48, 50, Fade(BLACK, alpha));
//			}
//			else if (state == 4)
//			{
//				DrawText("[R] REPLAY", 340, 200, 20, GRAY);
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [shapes] example - rectangle scaling by mouse
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	const int MOUSE_SCALE_MARK_SIZE = 12;

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - rectangle scaling mouse");

//		Rectangle rec = new Rectangle(100, 100, 200, 80);

//		Vector2 mousePosition = new Vector2(0);

//		bool mouseScaleReady = false;
//		bool mouseScaleMode = false;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			mousePosition = GetMousePosition();

//			if (CheckCollisionPointRec(mousePosition, rec) &&
//				CheckCollisionPointRec(mousePosition, new Rectangle(rec.X + rec.width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.height - MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE, MOUSE_SCALE_MARK_SIZE)))
//			{
//				mouseScaleReady = true;
//				if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT)) mouseScaleMode = true;
//			}
//			else mouseScaleReady = false;

//			if (mouseScaleMode)
//			{
//				mouseScaleReady = true;

//				rec.width = (mousePosition.X - rec.X);
//				rec.height = (mousePosition.Y - rec.Y);

//				if (rec.width < MOUSE_SCALE_MARK_SIZE) rec.width = MOUSE_SCALE_MARK_SIZE;
//				if (rec.height < MOUSE_SCALE_MARK_SIZE) rec.height = MOUSE_SCALE_MARK_SIZE;

//				if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT)) mouseScaleMode = false;
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("Scale rectangle dragging from bottom-right corner!", 10, 10, 20, GRAY);

//			DrawRectangleRec(rec, Fade(GREEN, 0.5f));

//			if (mouseScaleReady)
//			{
//				DrawRectangleLinesEx(rec, 1, RED);
//				DrawTriangle(new Vector2(rec.X + rec.width - MOUSE_SCALE_MARK_SIZE, rec.Y + rec.height),
//							 new Vector2(rec.X + rec.width, rec.Y + rec.height),
//							 new Vector2(rec.X + rec.width, rec.Y + rec.height - MOUSE_SCALE_MARK_SIZE), RED);
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		CloseWindow();        // Close window and OpenGL context
//							  //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [audio] example - Module playing (streaming)
//*
//*   This example has been created using raylib 1.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	const int MAX_CIRCLES = 64;

//	typedef struct {

//	Vector2 position;
//	float radius;
//	float alpha;
//	float speed;
//	Color color;
//}
//CircleWave;

//public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	SetConfigFlags(FLAG_MSAA_4X_HINT);  // NOTE: Try to enable MSAA 4X

//	InitWindow(screenWidth, screenHeight, "raylib [audio] example - module playing (streaming)");

//	InitAudioDevice();                  // Initialize audio device

//	Color[] colors = new Color[14] { ORANGE, RED, GOLD, LIME, BLUE, VIOLET, BROWN, LIGHTGRAY, PINK,
//						 YELLOW, GREEN, SKYBLUE, PURPLE, BEIGE };

//	// Creates ome circles for visual effect
//	CircleWave[] circles = new CircleWave[MAX_CIRCLES];

//	for (int i = MAX_CIRCLES - 1; i >= 0; i--)
//	{
//		circles[i].alpha = 0.0f;
//		circles[i].radius = (float)GetRandomValue(10, 40);
//		circles[i].position.X = (float)GetRandomValue((int)circles[i].radius, (int)(screenWidth - circles[i].radius));
//		circles[i].position.Y = (float)GetRandomValue((int)circles[i].radius, (int)(screenHeight - circles[i].radius));
//		circles[i].speed = (float)GetRandomValue(1, 100) / 2000.0f;
//		circles[i].color = colors[GetRandomValue(0, 13)];
//	}

//	Music music = LoadMusicStream("resources/mini1111.xm");
//	music.looping = false;
//	float pitch = 1.0f;

//	PlayMusicStream(music);

//	float timePlayed = 0.0f;
//	bool pause = false;

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main game loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		UpdateMusicStream(music);      // Update music buffer with new stream data

//		// Restart music playing (stop and play)
//		if (IsKeyPressed(KEY_SPACE))
//		{
//			StopMusicStream(music);
//			PlayMusicStream(music);
//		}

//		// Pause/Resume music playing
//		if (IsKeyPressed(KEY_P))
//		{
//			pause = !pause;

//			if (pause) PauseMusicStream(music);
//			else ResumeMusicStream(music);
//		}

//		if (IsKeyDown(KEY_DOWN)) pitch -= 0.01f;
//		else if (IsKeyDown(KEY_UP)) pitch += 0.01f;

//		SetMusicPitch(music, pitch);

//		// Get timePlayed scaled to bar dimensions
//		timePlayed = GetMusicTimePlayed(music) / GetMusicTimeLength(music) * (screenWidth - 40);

//		// Color circles animation
//		for (int i = MAX_CIRCLES - 1; (i >= 0) && !pause; i--)
//		{
//			circles[i].alpha += circles[i].speed;
//			circles[i].radius += circles[i].speed * 10.0f;

//			if (circles[i].alpha > 1.0f) circles[i].speed *= -1;

//			if (circles[i].alpha <= 0.0f)
//			{
//				circles[i].alpha = 0.0f;
//				circles[i].radius = (float)GetRandomValue(10, 40);
//				circles[i].position.X = (float)GetRandomValue((int)circles[i].radius, (int)(screenWidth - circles[i].radius));
//				circles[i].position.Y = (float)GetRandomValue((int)circles[i].radius, (int)(screenHeight - circles[i].radius));
//				circles[i].color = colors[GetRandomValue(0, 13)];
//				circles[i].speed = (float)GetRandomValue(1, 100) / 2000.0f;
//			}
//		}
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		for (int i = MAX_CIRCLES - 1; i >= 0; i--)
//		{
//			DrawCircleV(circles[i].position, circles[i].radius, Fade(circles[i].color, circles[i].alpha));
//		}

//		// Draw time bar
//		DrawRectangle(20, screenHeight - 20 - 12, screenWidth - 40, 12, LIGHTGRAY);
//		DrawRectangle(20, screenHeight - 20 - 12, (int)timePlayed, 12, MAROON);
//		DrawRectangleLines(20, screenHeight - 20 - 12, screenWidth - 40, 12, GRAY);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadMusicStream(music);          // Unload music stream buffers from RAM

//	CloseAudioDevice();     // Close audio device (music streaming is automatically stopped)

//	CloseWindow();          // Close window and OpenGL context
//							//--------------------------------------------------------------------------------------

//	return 0;
//}
//}


///*******************************************************************************************
//*
//*   raylib [audio] example - Multichannel sound playing
//*
//*   This example has been created using raylib 2.6 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Chris Camacho (@chriscamacho) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Chris Camacho (@chriscamacho) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [audio] example - Multichannel sound playing");

//		InitAudioDevice();      // Initialize audio device

//		Sound fxWav = LoadSound("resources/sound.wav");         // Load WAV audio file
//		Sound fxOgg = LoadSound("resources/target.ogg");        // Load OGG audio file

//		SetSoundVolume(fxWav, 0.2f);

//		SetTargetFPS(60);       // Set our game to run at 60 frames-per-second
//								//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyPressed(KEY_ENTER)) PlaySoundMulti(fxWav);     // Play a new wav sound instance
//			if (IsKeyPressed(KEY_SPACE)) PlaySoundMulti(fxOgg);     // Play a new ogg sound instance
//																	//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("MULTICHANNEL SOUND PLAYING", 20, 20, 20, GRAY);
//			DrawText("Press SPACE to play new ogg instance!", 200, 120, 20, LIGHTGRAY);
//			DrawText("Press ENTER to play new wav instance!", 200, 180, 20, LIGHTGRAY);

//			DrawText(TextFormat("CONCURRENT SOUNDS PLAYING: %02i", GetSoundsPlaying()), 220, 280, 20, RED);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		StopSoundMulti();       // We must stop the buffer pool before unloading

//		UnloadSound(fxWav);     // Unload sound data
//		UnloadSound(fxOgg);     // Unload sound data

//		CloseAudioDevice();     // Close audio device

//		CloseWindow();          // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}
///*******************************************************************************************
//*
//*   raylib [audio] example - Music playing (streaming)
//*
//*   This example has been created using raylib 1.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [audio] example - music playing (streaming)");

//		InitAudioDevice();              // Initialize audio device

//		Music music = LoadMusicStream("resources/country.mp3");

//		PlayMusicStream(music);

//		float timePlayed = 0.0f;
//		bool pause = false;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			UpdateMusicStream(music);   // Update music buffer with new stream data

//			// Restart music playing (stop and play)
//			if (IsKeyPressed(KEY_SPACE))
//			{
//				StopMusicStream(music);
//				PlayMusicStream(music);
//			}

//			// Pause/Resume music playing
//			if (IsKeyPressed(KEY_P))
//			{
//				pause = !pause;

//				if (pause) PauseMusicStream(music);
//				else ResumeMusicStream(music);
//			}

//			// Get timePlayed scaled to bar dimensions (400 pixels)
//			timePlayed = GetMusicTimePlayed(music) / GetMusicTimeLength(music) * 400;

//			if (timePlayed > 400) StopMusicStream(music);
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("MUSIC SHOULD BE PLAYING!", 255, 150, 20, LIGHTGRAY);

//			DrawRectangle(200, 200, 400, 12, LIGHTGRAY);
//			DrawRectangle(200, 200, (int)timePlayed, 12, MAROON);
//			DrawRectangleLines(200, 200, 400, 12, GRAY);

//			DrawText("PRESS SPACE TO RESTART MUSIC", 215, 250, 20, LIGHTGRAY);
//			DrawText("PRESS P TO PAUSE/RESUME MUSIC", 208, 280, 20, LIGHTGRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadMusicStream(music);   // Unload music stream buffers from RAM

//		CloseAudioDevice();         // Close audio device (music streaming is automatically stopped)

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [audio] example - Raw audio streaming
//*
//*   This example has been created using raylib 1.6 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example created by Ramon Santamaria (@raysan5) and reviewed by James Hofmann (@triplefox)
//*
//*   Copyright (c) 2015-2019 Ramon Santamaria (@raysan5) and James Hofmann (@triplefox)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	// #include <stdlib.h>         // Required for: malloc(), free()
//	// # include <math.h>           // Required for: MathF.Sin()
//	// # include <string.h>         // Required for: memcpy()

//	const int MAX_SAMPLES = 512;
//	const int MAX_SAMPLES_PER_UPDATE = 4096;

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [audio] example - raw audio streaming");

//		InitAudioDevice();              // Initialize audio device

//		SetAudioStreamBufferSizeDefault(MAX_SAMPLES_PER_UPDATE);

//		// Init raw audio stream (sample rate: 22050, sample size: 16bit-short, channels: 1-mono)
//		AudioStream stream = LoadAudioStream(44100, 16, 1);

//		// Buffer for the single cycle waveform we are synthesizing
//		short* data = (short*)malloc(short.Length * MAX_SAMPLES);

//		// Frame buffer, describing the waveform when repeated over the course of a frame
//		short* writeBuf = (short*)malloc(short.Length * MAX_SAMPLES_PER_UPDATE);

//		PlayAudioStream(stream);        // Start processing stream buffer (no data loaded currently)

//		// Position read in to determine next frequency
//		Vector2 mousePosition = new Vector2(-100.0f, -100.0f);

//		// Cycles per second (hz)
//		float frequency = 440.0f;

//		// Previous value, used to test if sine needs to be rewritten, and to smoothly modulate frequency
//		float oldFrequency = 1.0f;

//		// Cursor to read and copy the samples of the sine wave buffer
//		int readCursor = 0;

//		// Computed size in samples of the sine wave
//		int waveLength = 1;

//		Vector2 position = new Vector2(0, 0);

//		SetTargetFPS(30);               // Set our game to run at 30 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------

//			// Sample mouse input.
//			mousePosition = GetMousePosition();

//			if (IsMouseButtonDown(MOUSE_BUTTON_LEFT))
//			{
//				float fp = (float)(mousePosition.Y);
//				frequency = 40.0f + (float)(fp);
//			}

//			// Rewrite the sine wave.
//			// Compute two cycles to allow the buffer padding, simplifying any modulation, resampling, etc.
//			if (frequency != oldFrequency)
//			{
//				// Compute wavelength. Limit size in both directions.
//				int oldWavelength = waveLength;
//				waveLength = (int)(22050 / frequency);
//				if (waveLength > MAX_SAMPLES / 2) waveLength = MAX_SAMPLES / 2;
//				if (waveLength < 1) waveLength = 1;

//				// Write sine wave.
//				for (int i = 0; i < waveLength * 2; i++)
//				{
//					data[i] = (short)(MathF.Sin(((2 * PI * (float)i / waveLength))) * 32000);
//				}

//				// Scale read cursor's position to minimize transition artifacts
//				readCursor = (int)(readCursor * ((float)waveLength / (float)oldWavelength));
//				oldFrequency = frequency;
//			}

//			// Refill audio stream if required
//			if (IsAudioStreamProcessed(stream))
//			{
//				// Synthesize a buffer that is exactly the requested size
//				int writeCursor = 0;

//				while (writeCursor < MAX_SAMPLES_PER_UPDATE)
//				{
//					// Start by trying to write the whole chunk at once
//					int writeLength = MAX_SAMPLES_PER_UPDATE - writeCursor;

//					// Limit to the maximum readable size
//					int readLength = waveLength - readCursor;

//					if (writeLength > readLength) writeLength = readLength;

//					// Write the slice
//					memcpy(writeBuf + writeCursor, data + readCursor, writeLength * short.Length);

//					// Update cursors and loop audio
//					readCursor = (readCursor + writeLength) % waveLength;

//					writeCursor += writeLength;
//				}

//				// Copy finished frame to audio stream
//				UpdateAudioStream(stream, writeBuf, MAX_SAMPLES_PER_UPDATE);
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText(TextFormat("sine frequency: %i", (int)frequency), GetScreenWidth() - 220, 10, 20, RED);
//			DrawText("click mouse button to change frequency", 10, 10, 20, DARKGRAY);

//			// Draw the current buffer state proportionate to the screen
//			for (int i = 0; i < screenWidth; i++)
//			{
//				position.X = (float)i;
//				position.Y = 250 + 50 * data[i * MAX_SAMPLES / screenWidth] / 32000.0f;

//				DrawPixelV(position, RED);
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		free(data);                 // Unload sine wave data
//		free(writeBuf);             // Unload write buffer

//		UnloadAudioStream(stream);   // Close raw audio stream and delete buffers from RAM
//		CloseAudioDevice();         // Close audio device (music streaming is automatically stopped)

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}
///*******************************************************************************************
//*
//*   raylib [audio] example - Sound loading and playing
//*
//*   This example has been created using raylib 1.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [audio] example - sound loading and playing");

//		InitAudioDevice();      // Initialize audio device

//		Sound fxWav = LoadSound("resources/sound.wav");         // Load WAV audio file
//		Sound fxOgg = LoadSound("resources/target.ogg");        // Load OGG audio file

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyPressed(KEY_SPACE)) PlaySound(fxWav);      // Play WAV sound
//			if (IsKeyPressed(KEY_ENTER)) PlaySound(fxOgg);      // Play OGG sound
//																//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("Press SPACE to PLAY the WAV sound!", 200, 180, 20, LIGHTGRAY);
//			DrawText("Press ENTER to PLAY the OGG sound!", 200, 220, 20, LIGHTGRAY);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadSound(fxWav);     // Unload sound data
//		UnloadSound(fxOgg);     // Unload sound data

//		CloseAudioDevice();     // Close audio device

//		CloseWindow();          // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}







