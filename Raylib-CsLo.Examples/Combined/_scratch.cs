// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright (c) Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

namespace Raylib_CsLo.Examples.Combined;


//	/*******************************************************************************************
//	*
//	*   raylib [text] example - Draw 2D text in 3D
//	*
//	*   Draw a 2D text in 3D space, each letter is drawn in a quad (or 2 quads if backface is set)
//	*   where the texture coodinates of each quad map to the texture coordinates of the glyphs
//	*   inside the font texture.
//	*    A more efficient approach, i believe, would be to render the text in a render texture and
//	*    map that texture to a plane and render that, or maybe a shader but my method allows more
//	*    flexibility...for example to change position of each letter individually to make somethink
//	*    like a wavy text effect.
//	*    
//	*    Special thanks to:
//	*        @Nighten for the DrawTextStyle() code https://github.com/NightenDushi/Raylib_DrawTextStyle
//	*        Chris Camacho (codifies - http://bedroomcoders.co.uk/) for the alpha discard shader
//	*
//	*   This example has been created using raylib 3.5 (www.raylib.com)
//	*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//	*
//	*   Example contributed by Vlad Adrian (@Demizdor) and reviewed by Ramon Santamaria (@raysan5)
//	*
//	*   Copyright (C) 2021 Vlad Adrian (@Demizdor - https://github.com/Demizdor)
//	*
//	********************************************************************************************/

//	public unsafe static class TEMPLATE
//	{
//# include "rlgl.h"

//# include <stddef.h>     // Required for: NULL
//# include <math.h>       // Required for: sinf()

//		// To make it work with the older RLGL module just comment the line below
//#define RAYLIB_NEW_RLGL

//		//--------------------------------------------------------------------------------------
//		// Globals
//		//--------------------------------------------------------------------------------------
//		const int LETTER_BOUNDRY_SIZE = 0;.25f
//const int TEXT_MAX_LAYERS = 32;
//		const int LETTER_BOUNDRY_COLOR = VIOLET;

//		bool SHOW_LETTER_BOUNDRY = false;
//		bool SHOW_TEXT_BOUNDRY = false;

//		//--------------------------------------------------------------------------------------
//		// Data Types definition
//		//--------------------------------------------------------------------------------------

//		// Configuration structure for waving the text
//		typedef struct {

//	Vector3 waveRange;
//		Vector3 waveSpeed;
//		Vector3 waveOffset;
//	}
//	WaveTextConfig;

////--------------------------------------------------------------------------------------
//// Module Functions Declaration
////--------------------------------------------------------------------------------------
//// Draw a codepoint in 3D space
//void DrawTextCodepoint3D(Font font, int codepoint, Vector3 position, float fontSize, bool backface, Color tint);
//	// Draw a 2D text in 3D space
//	void DrawText3D(Font font, const char* text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, Color tint);
//// Measure a text in 3D. For some reason `MeasureTextEx()` just doesn't seem to work so i had to use this instead.
//Vector3 MeasureText3D(Font font, const char* text, float fontSize, float fontSpacing, float lineSpacing);

//	// Draw a 2D text in 3D space and wave the parts that start with `~~` and end with `~~`.
//	// This is a modified version of the original code by @Nighten found here https://github.com/NightenDushi/Raylib_DrawTextStyle
//	void DrawTextWave3D(Font font, const char* text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, WaveTextConfig* config, float time, Color tint);
//// Measure a text in 3D ignoring the `~~` chars.
//Vector3 MeasureTextWave3D(Font font, const char* text, float fontSize, float fontSpacing, float lineSpacing);
//	// Generates a nice color with a random hue
//	Color GenerateRandomColor(float s, float v);

//	//------------------------------------------------------------------------------------
//	// Program main entry point
//	//------------------------------------------------------------------------------------
//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_VSYNC_HINT);
//		InitWindow(screenWidth, screenHeight, "raylib [text] example - draw 2D text in 3D");

//		bool spin = true;        // Spin the camera?
//		bool multicolor = false; // Multicolor mode

//		// Define the camera to look into our 3d world
//		Camera3D camera = new Camera3D( 0 );
//		camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
//		camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
//		camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
//		camera.fovy = 45.0f;                                    // Camera field-of-view Y
//		camera.projection = CAMERA_PERSPECTIVE;                 // Camera mode type

//		SetCameraMode(camera, CAMERA_ORBITAL);

//		Vector3 cubePosition = new Vector3( 0.0f, 1.0f, 0.0f );
//		Vector3 cubeSize = new Vector3( 2.0f, 2.0f, 2.0f );

//		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second

//		// Use the default font
//		Font font = GetFontDefault();
//		float fontSize = 8.0f;
//		float fontSpacing = 0.5f;
//		float lineSpacing = -1.0f;

//		// Set the text (using markdown!)
//		char[] text = new char[64] "Hello ~~World~~ in 3D!";
//		Vector3 tbox = new Vector3( 0 );
//		int layers = 1;
//		int quads = 0;
//		float layerDistance = 0.01f;

//		WaveTextConfig wcfg;
//		wcfg.waveSpeed.X = wcfg.waveSpeed.Y = 3.0f; wcfg.waveSpeed.z = 0.5f;
//		wcfg.waveOffset.X = wcfg.waveOffset.Y = wcfg.waveOffset.z = 0.35f;
//		wcfg.waveRange.X = wcfg.waveRange.Y = wcfg.waveRange.z = 0.45f;

//		float time = 0.0f;

//		// Setup a light and dark color
//		Color light = MAROON;
//		Color dark = RED;

//		// Load the alpha discard shader
//		Shader alphaDiscard = LoadShader(NULL, "resources/shaders/glsl330/alpha_discard.fs");

//		// Array filled with multiple random colors (when multicolor mode is set)
//		Color[] multi = new Color[TEXT_MAX_LAYERS] { 0 };
//		//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())        // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			// Handle font files dropped
//			if (IsFileDropped())
//			{
//				int count = 0;
//				char** droppedFiles = GetDroppedFiles(&count);

//				// NOTE: We only support first ttf file dropped
//				if (IsFileExtension(droppedFiles[0], ".ttf"))
//				{
//					UnloadFont(font);
//					font = LoadFontEx(droppedFiles[0], fontSize, 0, 0);
//				}
//				else if (IsFileExtension(droppedFiles[0], ".fnt"))
//				{
//					UnloadFont(font);
//					font = LoadFont(droppedFiles[0]);
//					fontSize = font.baseSize;
//				}
//				ClearDroppedFiles();
//			}

//			// Handle Events
//			if (IsKeyPressed(KEY_F1)) SHOW_LETTER_BOUNDRY = !SHOW_LETTER_BOUNDRY;
//			if (IsKeyPressed(KEY_F2)) SHOW_TEXT_BOUNDRY = !SHOW_TEXT_BOUNDRY;
//			if (IsKeyPressed(KEY_F3))
//			{
//				// Handle camera change
//				spin = !spin;
//				// we need to reset the camera when changing modes
//				camera = new Camera3D(0);
//				camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
//				camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
//				camera.fovy = 45.0f;                                    // Camera field-of-view Y
//				camera.projection = CAMERA_PERSPECTIVE;                 // Camera mode type

//				if (spin)
//				{
//					camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
//					SetCameraMode(camera, CAMERA_ORBITAL);
//				}
//				else
//				{
//					camera.position = new Vector3(10.0f, 10.0f, -10.0f);   // Camera position
//					SetCameraMode(camera, CAMERA_FREE);
//				}
//			}

//			// Handle clicking the cube
//			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
//			{
//				Ray ray = GetMouseRay(GetMousePosition(), camera);

//				// Check collision between ray and box
//				RayCollision collision = GetRayCollisionBox(ray,
//								new BoundingBox(new Vector3(cubePosition.X - cubeSize.X / 2, cubePosition.Y - cubeSize.Y / 2, cubePosition.z - cubeSize.z / 2),
//											  new Vector3(cubePosition.X + cubeSize.X / 2, cubePosition.Y + cubeSize.Y / 2, cubePosition.z + cubeSize.z / 2)});
//			if (collision.hit)
//			{
//				// Generate new random colors
//				light = GenerateRandomColor(0.5f, 0.78f);
//				dark = GenerateRandomColor(0.4f, 0.58f);
//			}
//		}

//		// Handle text layers changes
//		if (IsKeyPressed(KEY_HOME)) { if (layers > 1) --layers; }
//		else if (IsKeyPressed(KEY_END)) { if (layers < TEXT_MAX_LAYERS) ++layers; }

//		// Handle text changes
//		if (IsKeyPressed(KEY_LEFT)) fontSize -= 0.5f;
//		else if (IsKeyPressed(KEY_RIGHT)) fontSize += 0.5f;
//		else if (IsKeyPressed(KEY_UP)) fontSpacing -= 0.1f;
//		else if (IsKeyPressed(KEY_DOWN)) fontSpacing += 0.1f;
//		else if (IsKeyPressed(KEY_PAGE_UP)) lineSpacing -= 0.1f;
//		else if (IsKeyPressed(KEY_PAGE_DOWN)) lineSpacing += 0.1f;
//		else if (IsKeyDown(KEY_INSERT)) layerDistance -= 0.001f;
//		else if (IsKeyDown(KEY_DELETE)) layerDistance += 0.001f;
//		else if (IsKeyPressed(KEY_TAB))
//		{
//			multicolor = !multicolor;   // Enable /disable multicolor mode

//			if (multicolor)
//			{
//				// Fill color array with random colors
//				for (int i = 0; i < TEXT_MAX_LAYERS; ++i)
//				{
//					multi[i] = GenerateRandomColor(0.5f, 0.8f);
//					multi[i].a = GetRandomValue(0, 255);
//				}
//			}
//		}

//		// Handle text input
//		int ch = GetCharPressed();
//		if (IsKeyPressed(KEY_BACKSPACE))
//		{
//			// Remove last char
//			int len = TextLength(text);
//			if (len > 0) text[len - 1] = '\0';
//		}
//		else if (IsKeyPressed(KEY_ENTER))
//		{
//			// handle newline
//			int len = TextLength(text);
//			if (len < sizeof(text) - 1)
//			{
//				text[len] = '\n';
//				text[len + 1] = '\0';
//			}
//		}
//		else
//		{
//			// append only printable chars
//			int len = TextLength(text);
//			if (len < sizeof(text) - 1)
//			{
//				text[len] = ch;
//				text[len + 1] = '\0';
//			}
//		}

//		// Measure 3D text so we can center it
//		tbox = MeasureTextWave3D(font, text, fontSize, fontSpacing, lineSpacing);

//		UpdateCamera(&camera);          // Update camera
//		quads = 0;                      // Reset quad counter
//		time += GetFrameTime();         // Update timer needed by `DrawTextWave3D()`
//										//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		BeginMode3D(camera);
//		DrawCubeV(cubePosition, cubeSize, dark);
//		DrawCubeWires(cubePosition, 2.1f, 2.1f, 2.1f, light);

//		DrawGrid(10, 2.0f);

//		// Use a shader to handle the depth buffer issue with transparent textures
//		// NOTE: more info at https://bedroomcoders.co.uk/raylib-billboards-advanced-use/
//		BeginShaderMode(alphaDiscard);

//		// Draw the 3D text above the red cube
//		rlPushMatrix();
//		rlRotatef(90.0f, 1.0f, 0.0f, 0.0f);
//		rlRotatef(90.0f, 0.0f, 0.0f, -1.0f);

//		for (int i = 0; i < layers; ++i)
//		{
//			Color clr = light;
//			if (multicolor) clr = multi[i];
//			DrawTextWave3D(font, text, new Vector3(-tbox.X / 2.0f, layerDistance * i, -4.5f), fontSize, fontSpacing, lineSpacing, true, &wcfg, time, clr);
//		}

//		// Draw the text boundry if set
//		if (SHOW_TEXT_BOUNDRY) DrawCubeWiresV(new Vector3(0.0f, 0.0f, -4.5f + tbox.z / 2), tbox, dark);
//		rlPopMatrix();

//		// Don't draw the letter boundries for the 3D text below
//		bool slb = SHOW_LETTER_BOUNDRY;
//		SHOW_LETTER_BOUNDRY = false;

//		// Draw 3D options (use default font)
//		//-------------------------------------------------------------------------
//		rlPushMatrix();
//		rlRotatef(180.0f, 0.0f, 1.0f, 0.0f);
//		char* opt = (char*)TextFormat("< SIZE: %2.1f >", fontSize);
//		quads += TextLength(opt);
//		Vector3 m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		Vector3 pos = new Vector3( -m.X / 2.0f, 0.01f, 2.0f );
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
//		pos.z += 0.5f + m.z;

//		opt = (char*)TextFormat("< SPACING: %2.1f >", fontSpacing);
//		quads += TextLength(opt);
//		m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
//		pos.z += 0.5f + m.z;

//		opt = (char*)TextFormat("< LINE: %2.1f >", lineSpacing);
//		quads += TextLength(opt);
//		m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
//		pos.z += 1.0f + m.z;

//		opt = (char*)TextFormat("< LBOX: %3s >", slb ? "ON" : "OFF");
//		quads += TextLength(opt);
//		m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
//		pos.z += 0.5f + m.z;

//		opt = (char*)TextFormat("< TBOX: %3s >", SHOW_TEXT_BOUNDRY ? "ON" : "OFF");
//		quads += TextLength(opt);
//		m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
//		pos.z += 0.5f + m.z;

//		opt = (char*)TextFormat("< LAYER DISTANCE: %.3f >", layerDistance);
//		quads += TextLength(opt);
//		m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, DARKPURPLE);
//		rlPopMatrix();
//		//-------------------------------------------------------------------------

//		// Draw 3D info text (use default font)
//		//-------------------------------------------------------------------------
//		opt = "All the text displayed here is in 3D";
//		quads += 36;
//		m = MeasureText3D(GetFontDefault(), opt, 10.0f, 0.5f, 0.0f);
//		pos = new Vector3(-m.X / 2.0f, 0.01f, 2.0f);
//		DrawText3D(GetFontDefault(), opt, pos, 10.0f, 0.5f, 0.0f, false, DARKBLUE);
//		pos.z += 1.5f + m.z;

//		opt = "press [Left]/[Right] to change the font size";
//		quads += 44;
//		m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
//		pos.z += 0.5f + m.z;

//		opt = "press [Up]/[Down] to change the font spacing";
//		quads += 44;
//		m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
//		pos.z += 0.5f + m.z;

//		opt = "press [PgUp]/[PgDown] to change the line spacing";
//		quads += 48;
//		m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
//		pos.z += 0.5f + m.z;

//		opt = "press [F1] to toggle the letter boundry";
//		quads += 39;
//		m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
//		pos.z += 0.5f + m.z;

//		opt = "press [F2] to toggle the text boundry";
//		quads += 37;
//		m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
//		pos.X = -m.X / 2.0f;
//		DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
//		//-------------------------------------------------------------------------

//		SHOW_LETTER_BOUNDRY = slb;
//		EndShaderMode();

//		EndMode3D();

//		// Draw 2D info text & stats
//		//-------------------------------------------------------------------------
//		DrawText("Drag & drop a font file to change the font!\nType something, see what happens!\n\n"

//		"Press [F3] to toggle the camera", 10, 35, 10, BLACK);

//		quads += TextLength(text) * 2 * layers;
//		char* tmp = (char*)TextFormat("%2i layer(s) | %s camera | %4i quads (%4i verts)", layers, spin ? "ORBITAL" : "FREE", quads, quads * 4);
//		int width = MeasureText(tmp, 10);
//		DrawText(tmp, screenWidth - 20 - width, 10, 10, DARKGREEN);

//		tmp = "[Home]/[End] to add/remove 3D text layers";
//		width = MeasureText(tmp, 10);
//		DrawText(tmp, screenWidth - 20 - width, 25, 10, DARKGRAY);

//		tmp = "[Insert]/[Delete] to increase/decrease distance between layers";
//		width = MeasureText(tmp, 10);
//		DrawText(tmp, screenWidth - 20 - width, 40, 10, DARKGRAY);

//		tmp = "click the [CUBE] for a random color";
//		width = MeasureText(tmp, 10);
//		DrawText(tmp, screenWidth - 20 - width, 55, 10, DARKGRAY);

//		tmp = "[Tab] to toggle multicolor mode";
//		width = MeasureText(tmp, 10);
//		DrawText(tmp, screenWidth - 20 - width, 70, 10, DARKGRAY);
//		//-------------------------------------------------------------------------

//		DrawFPS(10, 10);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadFont(font);
//	CloseWindow();        // Close window and OpenGL context
//    //--------------------------------------------------------------------------------------

//    return 0; }
//}

////--------------------------------------------------------------------------------------
//// Module Functions Definitions
////--------------------------------------------------------------------------------------
//// Draw codepoint at specified position in 3D space
//void DrawTextCodepoint3D(Font font, int codepoint, Vector3 position, float fontSize, bool backface, Color tint)
//{
//	// Character index position in sprite font
//	// NOTE: In case a codepoint is not available in the font, index returned points to '?'
//	int index = GetGlyphIndex(font, codepoint);
//	float scale = fontSize / (float)font.baseSize;

//	// Character destination rectangle on screen
//	// NOTE: We consider charsPadding on drawing
//	position.X += (float)(font.glyphs[index].offsetX - font.glyphPadding) / (float)font.baseSize * scale;
//	position.z += (float)(font.glyphs[index].offsetY - font.glyphPadding) / (float)font.baseSize * scale;

//	// Character source rectangle from font texture atlas
//	// NOTE: We consider chars padding when drawing, it could be required for outline/glow shader effects
//	Rectangle srcRec = { font.recs[index].X - (float)font.glyphPadding, font.recs[index].Y - (float)font.glyphPadding,
//						 font.recs[index].width + 2.0f*font.glyphPadding, font.recs[index].height + 2.0f*font.glyphPadding };

//	float width = (float)(font.recs[index].width + 2.0f * font.glyphPadding) / (float)font.baseSize * scale;
//	float height = (float)(font.recs[index].height + 2.0f * font.glyphPadding) / (float)font.baseSize * scale;

//	if (font.texture.id > 0)
//	{
//		const float x = 0.0f;
//		const float y = 0.0f;
//		const float z = 0.0f;

//		// normalized texture coordinates of the glyph inside the font texture (0.0f -> 1.0f)
//		const float tx = srcRec.X / font.texture.width;
//		const float ty = srcRec.Y / font.texture.height;
//		const float tw = (srcRec.X + srcRec.width) / font.texture.width;
//		const float th = (srcRec.Y + srcRec.height) / font.texture.height;

//		if (SHOW_LETTER_BOUNDRY) DrawCubeWiresV(new Vector3(position.X + width / 2, position.Y, position.z + height / 2), new Vector3(width, LETTER_BOUNDRY_SIZE, height), LETTER_BOUNDRY_COLOR);

//		rlCheckRenderBatchLimit(4 + 4 * backface);
//		rlSetTexture(font.texture.id);

//		rlPushMatrix();
//		rlTranslatef(position.X, position.Y, position.z);

//		rlBegin(RL_QUADS);
//		rlColor4ub(tint.r, tint.g, tint.b, tint.a);

//		// Front Face
//		rlNormal3f(0.0f, 1.0f, 0.0f);                                   // Normal Pointing Up
//		rlTexCoord2f(tx, ty); rlVertex3f(x, y, z);              // Top Left Of The Texture and Quad
//		rlTexCoord2f(tx, th); rlVertex3f(x, y, z + height);     // Bottom Left Of The Texture and Quad
//		rlTexCoord2f(tw, th); rlVertex3f(x + width, y, z + height);     // Bottom Right Of The Texture and Quad
//		rlTexCoord2f(tw, ty); rlVertex3f(x + width, y, z);              // Top Right Of The Texture and Quad

//		if (backface)
//		{
//			// Back Face
//			rlNormal3f(0.0f, -1.0f, 0.0f);                              // Normal Pointing Down
//			rlTexCoord2f(tx, ty); rlVertex3f(x, y, z);          // Top Right Of The Texture and Quad
//			rlTexCoord2f(tw, ty); rlVertex3f(x + width, y, z);          // Top Left Of The Texture and Quad
//			rlTexCoord2f(tw, th); rlVertex3f(x + width, y, z + height); // Bottom Left Of The Texture and Quad
//			rlTexCoord2f(tx, th); rlVertex3f(x, y, z + height); // Bottom Right Of The Texture and Quad
//		}
//		rlEnd();
//		rlPopMatrix();

//		rlSetTexture(0);
//	}
//}

//void DrawText3D(Font font, const char* text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, Color tint)
//{
//	int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

//	float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
//	float textOffsetX = 0.0f;               // Offset X to next character to draw

//	float scale = fontSize / (float)font.baseSize;

//	for (int i = 0; i < length;)
//	{
//		// Get next codepoint from byte string and glyph index in font
//		int codepointByteCount = 0;
//		int codepoint = GetCodepoint(&text[i], &codepointByteCount);
//		int index = GetGlyphIndex(font, codepoint);

//		// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//		// but we need to draw all of the bad bytes using the '?' symbol moving one byte
//		if (codepoint == 0x3f) codepointByteCount = 1;

//		if (codepoint == '\n')
//		{
//			// NOTE: Fixed line spacing of 1.5 line-height
//			// TODO: Support custom line spacing defined by user
//			textOffsetY += scale + lineSpacing / (float)font.baseSize * scale;
//			textOffsetX = 0.0f;
//		}
//		else
//		{
//			if ((codepoint != ' ') && (codepoint != '\t'))
//			{
//				DrawTextCodepoint3D(font, codepoint, new Vector3(position.X + textOffsetX, position.Y, position.z + textOffsetY), fontSize, backface, tint);
//			}

//			if (font.glyphs[index].advanceX == 0) textOffsetX += (float)(font.recs[index].width + fontSpacing) / (float)font.baseSize * scale;
//			else textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
//		}

//		i += codepointByteCount;   // Move text bytes counter to next codepoint
//	}
//}

//Vector3 MeasureText3D(Font font, const char* text, float fontSize, float fontSpacing, float lineSpacing)
//{
//	int len = TextLength(text);
//	int tempLen = 0;                // Used to count longer text line num chars
//	int lenCounter = 0;

//	float tempTextWidth = 0.0f;     // Used to count longer text line width

//	float scale = fontSize / (float)font.baseSize;
//	float textHeight = scale;
//	float textWidth = 0.0f;

//	int letter = 0;                 // Current character
//	int index = 0;                  // Index position in sprite font

//	for (int i = 0; i < len; i++)
//	{
//		lenCounter++;

//		int next = 0;
//		letter = GetCodepoint(&text[i], &next);
//		index = GetGlyphIndex(font, letter);

//		// NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//		// but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
//		if (letter == 0x3f) next = 1;
//		i += next - 1;

//		if (letter != '\n')
//		{
//			if (font.glyphs[index].advanceX != 0) textWidth += (font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
//			else textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / (float)font.baseSize * scale;
//		}
//		else
//		{
//			if (tempTextWidth < textWidth) tempTextWidth = textWidth;
//			lenCounter = 0;
//			textWidth = 0.0f;
//			textHeight += scale + lineSpacing / (float)font.baseSize * scale;
//		}

//		if (tempLen < lenCounter) tempLen = lenCounter;
//	}

//	if (tempTextWidth < textWidth) tempTextWidth = textWidth;

//	Vector3 vec = new Vector3( 0 );
//	vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / (float)font.baseSize * scale); // Adds chars spacing to measure
//	vec.Y = 0.25f;
//	vec.z = textHeight;

//	return vec;
//}


//void DrawTextWave3D(Font font, const char* text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, WaveTextConfig* config, float time, Color tint)
//{
//	int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

//	float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
//	float textOffsetX = 0.0f;               // Offset X to next character to draw

//	float scale = fontSize / (float)font.baseSize;

//	bool wave = false;

//	for (int i = 0, k = 0; i < length; ++k)
//	{
//		// Get next codepoint from byte string and glyph index in font
//		int codepointByteCount = 0;
//		int codepoint = GetCodepoint(&text[i], &codepointByteCount);
//		int index = GetGlyphIndex(font, codepoint);

//		// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//		// but we need to draw all of the bad bytes using the '?' symbol moving one byte
//		if (codepoint == 0x3f) codepointByteCount = 1;

//		if (codepoint == '\n')
//		{
//			// NOTE: Fixed line spacing of 1.5 line-height
//			// TODO: Support custom line spacing defined by user
//			textOffsetY += scale + lineSpacing / (float)font.baseSize * scale;
//			textOffsetX = 0.0f;
//			k = 0;
//		}
//		else if (codepoint == '~')
//		{
//			if (GetCodepoint(&text[i + 1], &codepointByteCount) == '~')
//			{
//				codepointByteCount += 1;
//				wave = !wave;
//			}
//		}
//		else
//		{
//			if ((codepoint != ' ') && (codepoint != '\t'))
//			{
//				Vector3 pos = position;
//				if (wave) // Apply the wave effect
//				{
//					pos.X += sinf(time * config->waveSpeed.X - k * config->waveOffset.X) * config->waveRange.X;
//					pos.Y += sinf(time * config->waveSpeed.Y - k * config->waveOffset.Y) * config->waveRange.Y;
//					pos.z += sinf(time * config->waveSpeed.z - k * config->waveOffset.z) * config->waveRange.z;
//				}

//				DrawTextCodepoint3D(font, codepoint, new Vector3(pos.X + textOffsetX, pos.Y, pos.z + textOffsetY), fontSize, backface, tint);
//			}

//			if (font.glyphs[index].advanceX == 0) textOffsetX += (float)(font.recs[index].width + fontSpacing) / (float)font.baseSize * scale;
//			else textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
//		}

//		i += codepointByteCount;   // Move text bytes counter to next codepoint
//	}
//}

//Vector3 MeasureTextWave3D(Font font, const char* text, float fontSize, float fontSpacing, float lineSpacing)
//{
//	int len = TextLength(text);
//	int tempLen = 0;                // Used to count longer text line num chars
//	int lenCounter = 0;

//	float tempTextWidth = 0.0f;     // Used to count longer text line width

//	float scale = fontSize / (float)font.baseSize;
//	float textHeight = scale;
//	float textWidth = 0.0f;

//	int letter = 0;                 // Current character
//	int index = 0;                  // Index position in sprite font

//	for (int i = 0; i < len; i++)
//	{
//		lenCounter++;

//		int next = 0;
//		letter = GetCodepoint(&text[i], &next);
//		index = GetGlyphIndex(font, letter);

//		// NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//		// but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
//		if (letter == 0x3f) next = 1;
//		i += next - 1;

//		if (letter != '\n')
//		{
//			if (letter == '~' && GetCodepoint(&text[i + 1], &next) == '~')
//			{
//				i++;
//			}
//			else
//			{
//				if (font.glyphs[index].advanceX != 0) textWidth += (font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
//				else textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / (float)font.baseSize * scale;
//			}
//		}
//		else
//		{
//			if (tempTextWidth < textWidth) tempTextWidth = textWidth;
//			lenCounter = 0;
//			textWidth = 0.0f;
//			textHeight += scale + lineSpacing / (float)font.baseSize * scale;
//		}

//		if (tempLen < lenCounter) tempLen = lenCounter;
//	}

//	if (tempTextWidth < textWidth) tempTextWidth = textWidth;

//	Vector3 vec = new Vector3( 0 );
//	vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / (float)font.baseSize * scale); // Adds chars spacing to measure
//	vec.Y = 0.25f;
//	vec.z = textHeight;

//	return vec;
//}

//Color GenerateRandomColor(float s, float v)
//{
//	const float Phi = 0.618033988749895f; // Golden ratio conjugate
//	float h = GetRandomValue(0, 360);
//	h = fmodf((h + h * Phi), 360.0f);
//	return ColorFromHSV(h, s, v);
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Font filters
//*
//*   After font loading, font texture atlas filter could be configured for a softer
//*   display of the font when scaling it to different sizes, that way, it's not required
//*   to generate multiple fonts at multiple sizes (as long as the scaling is not very different)
//*
//*   This example has been created using raylib 1.3.0 (www.raylib.com)
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

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - font filters");

//		const char[] msg = new char[50] "Loaded Font";

//		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

//		// TTF Font loading with custom generation parameters
//		Font font = LoadFontEx("resources/KAISG.ttf", 96, 0, 0);

//		// Generate mipmap levels to use trilinear filtering
//		// NOTE: On 2D drawing it won't be noticeable, it looks like FILTER_BILINEAR
//		GenTextureMipmaps(&font.texture);

//		float fontSize = (float)font.baseSize;
//		Vector2 fontPosition = new Vector2( 40.0f, screenHeight / 2.0f - 80.0f );
//		Vector2 textSize = new Vector2( 0.0f, 0.0f );

//		// Setup texture scaling filter
//		SetTextureFilter(font.texture, TEXTURE_FILTER_POINT);
//		int currentFontFilter = 0;      // TEXTURE_FILTER_POINT

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			fontSize += GetMouseWheelMove() * 4.0f;

//			// Choose font texture filter method
//			if (IsKeyPressed(KEY_ONE))
//			{
//				SetTextureFilter(font.texture, TEXTURE_FILTER_POINT);
//				currentFontFilter = 0;
//			}
//			else if (IsKeyPressed(KEY_TWO))
//			{
//				SetTextureFilter(font.texture, TEXTURE_FILTER_BILINEAR);
//				currentFontFilter = 1;
//			}
//			else if (IsKeyPressed(KEY_THREE))
//			{
//				// NOTE: Trilinear filter won't be noticed on 2D drawing
//				SetTextureFilter(font.texture, TEXTURE_FILTER_TRILINEAR);
//				currentFontFilter = 2;
//			}

//			textSize = MeasureTextEx(font, msg, fontSize, 0);

//			if (IsKeyDown(KEY_LEFT)) fontPosition.X -= 10;
//			else if (IsKeyDown(KEY_RIGHT)) fontPosition.X += 10;

//			// Load a dropped TTF file dynamically (at current fontSize)
//			if (IsFileDropped())
//			{
//				int count = 0;
//				char** droppedFiles = GetDroppedFiles(&count);

//				// NOTE: We only support first ttf file dropped
//				if (IsFileExtension(droppedFiles[0], ".ttf"))
//				{
//					UnloadFont(font);
//					font = LoadFontEx(droppedFiles[0], (int)fontSize, 0, 0);
//					ClearDroppedFiles();
//				}
//			}
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("Use mouse wheel to change font size", 20, 20, 10, GRAY);
//			DrawText("Use KEY_RIGHT and KEY_LEFT to move text", 20, 40, 10, GRAY);
//			DrawText("Use 1, 2, 3 to change texture filter", 20, 60, 10, GRAY);
//			DrawText("Drop a new TTF font for dynamic loading", 20, 80, 10, DARKGRAY);

//			DrawTextEx(font, msg, fontPosition, fontSize, 0, BLACK);

//			// TODO: It seems texSize measurement is not accurate due to chars offsets...
//			//DrawRectangleLines(fontPosition.X, fontPosition.Y, textSize.X, textSize.Y, RED);

//			DrawRectangle(0, screenHeight - 80, screenWidth, 80, LIGHTGRAY);
//			DrawText(TextFormat("Font size: %02.02f", fontSize), 20, screenHeight - 50, 10, DARKGRAY);
//			DrawText(TextFormat("Text size: [%02.02f, %02.02f]", textSize.X, textSize.Y), 20, screenHeight - 30, 10, DARKGRAY);
//			DrawText("CURRENT TEXTURE FILTER:", 250, 400, 20, GRAY);

//			if (currentFontFilter == 0) DrawText("POINT", 570, 400, 20, BLACK);
//			else if (currentFontFilter == 1) DrawText("BILINEAR", 570, 400, 20, BLACK);
//			else if (currentFontFilter == 2) DrawText("TRILINEAR", 570, 400, 20, BLACK);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		ClearDroppedFiles();        // Clear internal buffers

//		UnloadFont(font);           // Font unloading

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Font loading
//*
//*   raylib can load fonts from multiple file formats:
//*
//*     - TTF/OTF > Sprite font atlas is generated on loading, user can configure
//*                 some of the generation parameters (size, characters to include)
//*     - BMFonts > Angel code font fileformat, sprite font image must be provided
//*                 together with the .fnt file, font generation cna not be configured
//*     - XNA Spritefont > Sprite font image, following XNA Spritefont conventions,
//*                 Characters in image must follow some spacing and order rules
//*
//*   This example has been created using raylib 2.6 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2016-2019 Ramon Santamaria (@raysan5)
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

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - font loading");

//		// Define characters to draw
//		// NOTE: raylib supports UTF-8 encoding, following list is actually codified as UTF8 internally
//		const char[] msg = new char[256] "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHI\nJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmn\nopqrstuvwxyz{|}~¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓ\nÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷\nøùúûüýþÿ";

//		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

//		// BMFont (AngelCode) : Font data and image atlas have been generated using external program
//		Font fontBm = LoadFont("resources/pixantiqua.fnt");

//		// TTF font : Font data and atlas are generated directly from TTF
//		// NOTE: We define a font base size of 32 pixels tall and up-to 250 characters
//		Font fontTtf = LoadFontEx("resources/pixantiqua.ttf", 32, 0, 250);

//		bool useTtf = false;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyDown(KEY_SPACE)) useTtf = true;
//			else useTtf = false;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("Hold SPACE to use TTF generated font", 20, 20, 20, LIGHTGRAY);

//			if (!useTtf)
//			{
//				DrawTextEx(fontBm, msg, new Vector2(20.0f, 100.0f), (float)fontBm.baseSize, 2, MAROON);
//				DrawText("Using BMFont (Angelcode) imported", 20, GetScreenHeight() - 30, 20, GRAY);
//			}
//			else
//			{
//				DrawTextEx(fontTtf, msg, new Vector2(20.0f, 100.0f), (float)fontTtf.baseSize, 2, LIME);
//				DrawText("Using TTF font generated", 20, GetScreenHeight() - 30, 20, GRAY);
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadFont(fontBm);     // AngelCode Font unloading
//		UnloadFont(fontTtf);    // TTF Font unloading

//		CloseWindow();          // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}


///*******************************************************************************************
//*
//*   raylib [text] example - TTF loading and usage
//*
//*   This example has been created using raylib 1.3.0 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//#if defined(PLATFORM_DESKTOP)
//    const int GLSL_VERSION = 330;
//#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
//	const int GLSL_VERSION = 100;
//#endif

//	// #include <stdlib.h>

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - SDF fonts");

//		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

//		const char[] msg = new char[50] "Signed Distance Fields";

//		// Loading file to memory
//		unsigned int fileSize = 0;
//		unsigned char* fileData = LoadFileData("resources/anonymous_pro_bold.ttf", &fileSize);

//		// Default font generation from TTF font
//		Font fontDefault = new Font( 0 );
//		fontDefault.baseSize = 16;
//		fontDefault.glyphCount = 95;

//		// Loading font data from memory data
//		// Parameters > font size: 16, no glyphs array provided (0), glyphs count: 95 (autogenerate chars array)
//		fontDefault.glyphs = LoadFontData(fileData, fileSize, 16, 0, 95, FONT_DEFAULT);
//		// Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 4 px, pack method: 0 (default)
//		Image atlas = GenImageFontAtlas(fontDefault.glyphs, &fontDefault.recs, 95, 16, 4, 0);
//		fontDefault.texture = LoadTextureFromImage(atlas);
//		UnloadImage(atlas);

//		// SDF font generation from TTF font
//		Font fontSDF = new Font( 0 );
//		fontSDF.baseSize = 16;
//		fontSDF.glyphCount = 95;
//		// Parameters > font size: 16, no glyphs array provided (0), glyphs count: 0 (defaults to 95)
//		fontSDF.glyphs = LoadFontData(fileData, fileSize, 16, 0, 0, FONT_SDF);
//		// Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 0 px, pack method: 1 (Skyline algorythm)
//		atlas = GenImageFontAtlas(fontSDF.glyphs, &fontSDF.recs, 95, 16, 0, 1);
//		fontSDF.texture = LoadTextureFromImage(atlas);
//		UnloadImage(atlas);

//		UnloadFileData(fileData);      // Free memory from loaded file

//		// Load SDF required shader (we use default vertex shader)
//		Shader shader = LoadShader(0, TextFormat("resources/shaders/glsl%i/sdf.fs", GLSL_VERSION));
//		SetTextureFilter(fontSDF.texture, TEXTURE_FILTER_BILINEAR);    // Required for SDF font

//		Vector2 fontPosition = new Vector2( 40, screenHeight / 2.0f - 50 );
//		Vector2 textSize = new Vector2( 0.0f, 0.0f );
//		float fontSize = 16.0f;
//		int currentFont = 0;            // 0 - fontDefault, 1 - fontSDF

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			fontSize += GetMouseWheelMove() * 8.0f;

//			if (fontSize < 6) fontSize = 6;

//			if (IsKeyDown(KEY_SPACE)) currentFont = 1;
//			else currentFont = 0;

//			if (currentFont == 0) textSize = MeasureTextEx(fontDefault, msg, fontSize, 0);
//			else textSize = MeasureTextEx(fontSDF, msg, fontSize, 0);

//			fontPosition.X = GetScreenWidth() / 2 - textSize.X / 2;
//			fontPosition.Y = GetScreenHeight() / 2 - textSize.Y / 2 + 80;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			if (currentFont == 1)
//			{
//				// NOTE: SDF fonts require a custom SDf shader to compute fragment color
//				BeginShaderMode(shader);    // Activate SDF font shader
//				DrawTextEx(fontSDF, msg, fontPosition, fontSize, 0, BLACK);
//				EndShaderMode();            // Activate our default shader for next drawings

//				DrawTexture(fontSDF.texture, 10, 10, BLACK);
//			}
//			else
//			{
//				DrawTextEx(fontDefault, msg, fontPosition, fontSize, 0, BLACK);
//				DrawTexture(fontDefault.texture, 10, 10, BLACK);
//			}

//			if (currentFont == 1) DrawText("SDF!", 320, 20, 80, RED);
//			else DrawText("default font", 315, 40, 30, GRAY);

//			DrawText("FONT SIZE: 16.0", GetScreenWidth() - 240, 20, 20, DARKGRAY);
//			DrawText(TextFormat("RENDER SIZE: %02.02f", fontSize), GetScreenWidth() - 240, 50, 20, DARKGRAY);
//			DrawText("Use MOUSE WHEEL to SCALE TEXT!", GetScreenWidth() - 240, 90, 10, DARKGRAY);

//			DrawText("HOLD SPACE to USE SDF FONT VERSION!", 340, GetScreenHeight() - 30, 20, MAROON);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadFont(fontDefault);    // Default font unloading
//		UnloadFont(fontSDF);        // SDF font unloading

//		UnloadShader(shader);       // Unload SDF shader

//		CloseWindow();              // Close window and OpenGL context
//									//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Sprite font loading
//*
//*   Loaded sprite fonts have been generated following XNA SpriteFont conventions:
//*     - Characters must be ordered starting with character 32 (Space)
//*     - Every character must be contained within the same Rectangle height
//*     - Every character and every line must be separated by the same distance (margin/padding)
//*     - Rectangles must be defined by a MAGENTA color background
//*
//*   If following this constraints, a font can be provided just by an image,
//*   this is quite handy to avoid additional information files (like BMFonts use).
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

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - sprite font loading");

//		const char[] msg1 = new char[50] "THIS IS A custom SPRITE FONT...";
//		const char[] msg2 = new char[50] "...and this is ANOTHER CUSTOM font...";
//		const char[] msg3 = new char[50] "...and a THIRD one! GREAT! :D";

//		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)
//		Font font1 = LoadFont("resources/custom_mecha.png");          // Font loading
//		Font font2 = LoadFont("resources/custom_alagard.png");        // Font loading
//		Font font3 = LoadFont("resources/custom_jupiter_crash.png");  // Font loading

//		Vector2 fontPosition1 = { screenWidth/2.0f - MeasureTextEx(font1, msg1, (float)font1.baseSize, -3).X/2,
//							  screenHeight/2.0f - font1.baseSize/2.0f - 80.0f };

//		Vector2 fontPosition2 = { screenWidth/2.0f - MeasureTextEx(font2, msg2, (float)font2.baseSize, -2.0f).X/2.0f,
//							  screenHeight/2.0f - font2.baseSize/2.0f - 10.0f };

//		Vector2 fontPosition3 = { screenWidth/2.0f - MeasureTextEx(font3, msg3, (float)font3.baseSize, 2.0f).X/2.0f,
//							  screenHeight/2.0f - font3.baseSize/2.0f + 50.0f };

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			// TODO: Update variables here...
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawTextEx(font1, msg1, fontPosition1, (float)font1.baseSize, -3, WHITE);
//			DrawTextEx(font2, msg2, fontPosition2, (float)font2.baseSize, -2, WHITE);
//			DrawTextEx(font3, msg3, fontPosition3, (float)font3.baseSize, 2, WHITE);

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------
//		UnloadFont(font1);      // Font unloading
//		UnloadFont(font2);      // Font unloading
//		UnloadFont(font3);      // Font unloading

//		CloseWindow();          // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Text formatting
//*
//*   This example has been created using raylib 1.1 (www.raylib.com)
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

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - text formatting");

//		int score = 100020;
//		int hiscore = 200450;
//		int lives = 5;

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

//			DrawText(TextFormat("Score: %08i", score), 200, 80, 20, RED);

//			DrawText(TextFormat("HiScore: %08i", hiscore), 200, 120, 20, GREEN);

//			DrawText(TextFormat("Lives: %02i", lives), 200, 160, 40, BLUE);

//			DrawText(TextFormat("Elapsed Time: %02.02f ms", GetFrameTime() * 1000), 200, 220, 20, BLACK);

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
//*   raylib [text] example - Input Box
//*
//*   This example has been created using raylib 3.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	const int MAX_INPUT_CHARS = 9;

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - input box");

//		char name[MAX_INPUT_CHARS + 1] = "\0";      // NOTE: One extra space required for null terminator char '\0'
//		int letterCount = 0;

//		Rectangle textBox = new Rectangle( screenWidth / 2.0f - 100, 180, 225, 50 );
//		bool mouseOnText = false;

//		int framesCounter = 0;

//		SetTargetFPS(10);               // Set our game to run at 10 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (CheckCollisionPointRec(GetMousePosition(), textBox)) mouseOnText = true;
//			else mouseOnText = false;

//			if (mouseOnText)
//			{
//				// Set the window's cursor to the I-Beam
//				SetMouseCursor(MOUSE_CURSOR_IBEAM);

//				// Get char pressed (unicode character) on the queue
//				int key = GetCharPressed();

//				// Check if more characters have been pressed on the same frame
//				while (key > 0)
//				{
//					// NOTE: Only allow keys in range [32..125]
//					if ((key >= 32) && (key <= 125) && (letterCount < MAX_INPUT_CHARS))
//					{
//						name[letterCount] = (char)key;
//						name[letterCount + 1] = '\0'; // Add null terminator at the end of the string.
//						letterCount++;
//					}

//					key = GetCharPressed();  // Check next character in the queue
//				}

//				if (IsKeyPressed(KEY_BACKSPACE))
//				{
//					letterCount--;
//					if (letterCount < 0) letterCount = 0;
//					name[letterCount] = '\0';
//				}
//			}
//			else SetMouseCursor(MOUSE_CURSOR_DEFAULT);

//			if (mouseOnText) framesCounter++;
//			else framesCounter = 0;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText("PLACE MOUSE OVER INPUT BOX!", 240, 140, 20, GRAY);

//			DrawRectangleRec(textBox, LIGHTGRAY);
//			if (mouseOnText) DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.width, (int)textBox.height, RED);
//			else DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.width, (int)textBox.height, DARKGRAY);

//			DrawText(name, (int)textBox.X + 5, (int)textBox.Y + 8, 40, MAROON);

//			DrawText(TextFormat("INPUT CHARS: %i/%i", letterCount, MAX_INPUT_CHARS), 315, 250, 20, DARKGRAY);

//			if (mouseOnText)
//			{
//				if (letterCount < MAX_INPUT_CHARS)
//				{
//					// Draw blinking underscore char
//					if (((framesCounter / 20) % 2) == 0) DrawText("_", (int)textBox.X + 8 + MeasureText(name, 40), (int)textBox.Y + 12, 40, MAROON);
//				}
//				else DrawText("Press BACKSPACE to delete chars...", 230, 300, 20, GRAY);
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

//// Check if any key is pressed
//// NOTE: We limit keys check to keys between 32 (KEY_SPACE) and 126
//bool IsAnyKeyPressed()
//{
//	bool keyPressed = false;
//	int key = GetKeyPressed();

//	if ((key >= 32) && (key <= 126)) keyPressed = true;

//	return keyPressed;
//}

///*******************************************************************************************
//*
//*   raylib [text] example - raylib font loading and usage
//*
//*   NOTE: raylib is distributed with some free to use fonts (even for commercial pourposes!)
//*         To view details and credits for those fonts, check raylib license file
//*
//*   This example has been created using raylib 1.7 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	const int MAX_FONTS = 8;

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - raylib fonts");

//		// NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
//		Font[] fonts = new Font[MAX_FONTS];

//		fonts[0] = LoadFont("resources/fonts/alagard.png");
//		fonts[1] = LoadFont("resources/fonts/pixelplay.png");
//		fonts[2] = LoadFont("resources/fonts/mecha.png");
//		fonts[3] = LoadFont("resources/fonts/setback.png");
//		fonts[4] = LoadFont("resources/fonts/romulus.png");
//		fonts[5] = LoadFont("resources/fonts/pixantiqua.png");
//		fonts[6] = LoadFont("resources/fonts/alpha_beta.png");
//		fonts[7] = LoadFont("resources/fonts/jupiter_crash.png");

//		const char* messages[MAX_FONTS] = { "ALAGARD FONT designed by Hewett Tsoi",
//								"PIXELPLAY FONT designed by Aleksander Shevchuk",
//								"MECHA FONT designed by Captain Falcon",
//								"SETBACK FONT designed by Brian Kent (AEnigma)",
//								"ROMULUS FONT designed by Hewett Tsoi",
//								"PIXANTIQUA FONT designed by Gerhard Grossmann",
//								"ALPHA_BETA FONT designed by Brian Kent (AEnigma)",
//								"JUPITER_CRASH FONT designed by Brian Kent (AEnigma)" };

//		const int[] spacings = new int[MAX_FONTS] { 2, 4, 8, 4, 3, 4, 4, 1 };

//		Vector2[] positions = new Vector2[MAX_FONTS];

//		for (int i = 0; i < MAX_FONTS; i++)
//		{
//			positions[i].X = screenWidth / 2.0f - MeasureTextEx(fonts[i], messages[i], fonts[i].baseSize * 2.0f, (float)spacings[i]).X / 2.0f;
//			positions[i].Y = 60.0f + fonts[i].baseSize + 45.0f * i;
//		}

//		// Small Y position corrections
//		positions[3].Y += 8;
//		positions[4].Y += 2;
//		positions[7].Y -= 8;

//		Color[] colors = new Color[MAX_FONTS] { MAROON, ORANGE, DARKGREEN, DARKBLUE, DARKPURPLE, LIME, GOLD, RED };

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

//			DrawText("free fonts included with raylib", 250, 20, 20, DARKGRAY);
//			DrawLine(220, 50, 590, 50, DARKGRAY);

//			for (int i = 0; i < MAX_FONTS; i++)
//			{
//				DrawTextEx(fonts[i], messages[i], positions[i], fonts[i].baseSize * 2.0f, (float)spacings[i], colors[i]);
//			}

//			EndDrawing();
//			//----------------------------------------------------------------------------------
//		}

//		// De-Initialization
//		//--------------------------------------------------------------------------------------

//		// Fonts unloading
//		for (int i = 0; i < MAX_FONTS; i++) UnloadFont(fonts[i]);

//		CloseWindow();                 // Close window and OpenGL context
//									   //--------------------------------------------------------------------------------------

//		return 0;
//	}
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Draw text inside a rectangle
//*
//*   This example has been created using raylib 2.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//	static void DrawTextBoxed(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint);   // Draw text using font inside rectangle limits
//static void DrawTextBoxedSelectable(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint);    // Draw text using font inside rectangle limits with support for text selection

//	// Main entry point
//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - draw text inside a rectangle");

//		char[] text = new char[] "Text cannot escape\tthis container\t...word wrap also works when active so here's \
//a long text for testing.\n\nLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod \
//tempor incididunt ut labore et dolore magna aliqua. Nec ullamcorper sit amet risus nullam eget felis eget.";

//		bool resizing = false;
//		bool wordWrap = true;

//		Rectangle container = new Rectangle( 25.0f, 25.0f, screenWidth - 50.0f, screenHeight - 250.0f );
//		Rectangle resizer = new Rectangle( container.X + container.width - 17, container.Y + container.height - 17, 14, 14 );

//		// Minimum width and heigh for the container rectangle
//		const float minWidth = 60;
//		const float minHeight = 60;
//		const float maxWidth = screenWidth - 50.0f;
//		const float maxHeight = screenHeight - 160.0f;

//		Vector2 lastMouse = new Vector2( 0.0f, 0.0f ); // Stores last mouse coordinates
//		Color borderColor = MAROON;         // Container border color
//		Font font = GetFontDefault();       // Get default system font

//		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
//											//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())        // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyPressed(KEY_SPACE)) wordWrap = !wordWrap;

//			Vector2 mouse = GetMousePosition();

//			// Check if the mouse is inside the container and toggle border color
//			if (CheckCollisionPointRec(mouse, container)) borderColor = Fade(MAROON, 0.4f);
//			else if (!resizing) borderColor = MAROON;

//			// Container resizing logic
//			if (resizing)
//			{
//				if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT)) resizing = false;

//				float width = container.width + (mouse.X - lastMouse.X);
//				container.width = (width > minWidth) ? ((width < maxWidth) ? width : maxWidth) : minWidth;

//				float height = container.height + (mouse.Y - lastMouse.Y);
//				container.height = (height > minHeight) ? ((height < maxHeight) ? height : maxHeight) : minHeight;
//			}
//			else
//			{
//				// Check if we're resizing
//				if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) && CheckCollisionPointRec(mouse, resizer)) resizing = true;
//			}

//			// Move resizer rectangle properly
//			resizer.X = container.X + container.width - 17;
//			resizer.Y = container.Y + container.height - 17;

//			lastMouse = mouse; // Update mouse
//							   //----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawRectangleLinesEx(container, 3, borderColor);    // Draw container border

//			// Draw text in container (add some padding)
//			DrawTextBoxed(font, text, new Rectangle(container.X + 4, container.Y + 4, container.width - 4, container.height - 4), 20.0f, 2.0f, wordWrap, GRAY);

//			DrawRectangleRec(resizer, borderColor);             // Draw the resize box

//			// Draw bottom info
//			DrawRectangle(0, screenHeight - 54, screenWidth, 54, GRAY);
//			DrawRectangleRec(new Rectangle(382.0f, screenHeight - 34.0f, 12.0f, 12.0f), MAROON);

//			DrawText("Word Wrap: ", 313, screenHeight - 115, 20, BLACK);
//			if (wordWrap) DrawText("ON", 447, screenHeight - 115, 20, RED);
//			else DrawText("OFF", 447, screenHeight - 115, 20, BLACK);

//			DrawText("Press [SPACE] to toggle word wrap", 218, screenHeight - 86, 20, GRAY);

//			DrawText("Click hold & drag the    to resize the container", 155, screenHeight - 38, 20, RAYWHITE);

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

////--------------------------------------------------------------------------------------
//// Module functions definition
////--------------------------------------------------------------------------------------

//// Draw text using font inside rectangle limits
//static void DrawTextBoxed(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint)
//{
//	DrawTextBoxedSelectable(font, text, rec, fontSize, spacing, wordWrap, tint, 0, 0, WHITE, WHITE);
//}

//// Draw text using font inside rectangle limits with support for text selection
//static void DrawTextBoxedSelectable(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint)
//{
//	int length = TextLength(text);  // Total length in bytes of the text, scanned by codepoints in loop

//	float textOffsetY = 0;          // Offset between lines (on line break '\n')
//	float textOffsetX = 0.0f;       // Offset X to next character to draw

//	float scaleFactor = fontSize / (float)font.baseSize;     // Character rectangle scaling factor

//	// Word/character wrapping mechanism variables
//enum { MEASURE_STATE = 0, DRAW_STATE = 1 };
//int state = wordWrap ? MEASURE_STATE : DRAW_STATE;

//int startLine = -1;         // Index where to begin drawing (where a line begins)
//int endLine = -1;           // Index where to stop drawing (where a line ends)
//int lastk = -1;             // Holds last value of the character position

//for (int i = 0, k = 0; i < length; i++, k++)
//{
//	// Get next codepoint from byte string and glyph index in font
//	int codepointByteCount = 0;
//	int codepoint = GetCodepoint(&text[i], &codepointByteCount);
//	int index = GetGlyphIndex(font, codepoint);

//	// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//	// but we need to draw all of the bad bytes using the '?' symbol moving one byte
//	if (codepoint == 0x3f) codepointByteCount = 1;
//	i += (codepointByteCount - 1);

//	float glyphWidth = 0;
//	if (codepoint != '\n')
//	{
//		glyphWidth = (font.glyphs[index].advanceX == 0) ? font.recs[index].width * scaleFactor : font.glyphs[index].advanceX * scaleFactor;

//		if (i + 1 < length) glyphWidth = glyphWidth + spacing;
//	}

//	// NOTE: When wordWrap is ON we first measure how much of the text we can draw before going outside of the rec container
//	// We store this info in startLine and endLine, then we change states, draw the text between those two variables
//	// and change states again and again recursively until the end of the text (or until we get outside of the container).
//	// When wordWrap is OFF we don't need the measure state so we go to the drawing state immediately
//	// and begin drawing on the next line before we can get outside the container.
//	if (state == MEASURE_STATE)
//	{
//		// TODO: There are multiple types of spaces in UNICODE, maybe it's a good idea to add support for more
//		// Ref: http://jkorpela.fi/chars/spaces.html
//		if ((codepoint == ' ') || (codepoint == '\t') || (codepoint == '\n')) endLine = i;

//		if ((textOffsetX + glyphWidth) > rec.width)
//		{
//			endLine = (endLine < 1) ? i : endLine;
//			if (i == endLine) endLine -= codepointByteCount;
//			if ((startLine + codepointByteCount) == endLine) endLine = (i - codepointByteCount);

//			state = !state;
//		}
//		else if ((i + 1) == length)
//		{
//			endLine = i;
//			state = !state;
//		}
//		else if (codepoint == '\n') state = !state;

//		if (state == DRAW_STATE)
//		{
//			textOffsetX = 0;
//			i = startLine;
//			glyphWidth = 0;

//			// Save character position when we switch states
//			int tmp = lastk;
//			lastk = k - 1;
//			k = tmp;
//		}
//	}
//	else
//	{
//		if (codepoint == '\n')
//		{
//			if (!wordWrap)
//			{
//				textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//				textOffsetX = 0;
//			}
//		}
//		else
//		{
//			if (!wordWrap && ((textOffsetX + glyphWidth) > rec.width))
//			{
//				textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//				textOffsetX = 0;
//			}

//			// When text overflows rectangle height limit, just stop drawing
//			if ((textOffsetY + font.baseSize * scaleFactor) > rec.height) break;

//			// Draw selection background
//			bool isGlyphSelected = false;
//			if ((selectStart >= 0) && (k >= selectStart) && (k < (selectStart + selectLength)))
//			{
//				DrawRectangleRec(new Rectangle(rec.X + textOffsetX - 1, rec.Y + textOffsetY, glyphWidth, (float)font.baseSize * scaleFactor), selectBackTint);
//				isGlyphSelected = true;
//			}

//			// Draw current character glyph
//			if ((codepoint != ' ') && (codepoint != '\t'))
//			{
//				DrawTextCodepoint(font, codepoint, new Vector2(rec.X + textOffsetX, rec.Y + textOffsetY), fontSize, isGlyphSelected ? selectTint : tint);
//			}
//		}

//		if (wordWrap && (i == endLine))
//		{
//			textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//			textOffsetX = 0;
//			startLine = endLine;
//			endLine = -1;
//			glyphWidth = 0;
//			selectStart += lastk - k;
//			k = lastk;

//			state = !state;
//		}
//	}

//	textOffsetX += glyphWidth;
//}
//}

///*******************************************************************************************
//*
//*   raylib [text] example - Using unicode with raylib
//*
//*   This example has been created using raylib 2.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
//*
//*   Copyright (c) 2019 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class TEMPLATE
//{

//# include <stdio.h>
//# include <string.h>

//#define SIZEOF(A) (sizeof(A)/sizeof(A[0]))
//	const int EMOJI_PER_WIDTH = 8;
//	const int EMOJI_PER_HEIGHT = 4;

//	// String containing 180 emoji codepoints separated by a '\0' char
//	const char*const emojiCodepoints = "\xF0\x9F\x8C\x80\x00\xF0\x9F\x98\x80\x00\xF0\x9F\x98\x82\x00\xF0\x9F\xA4\xA3\x00\xF0\x9F\x98\x83\x00\xF0\x9F\x98\x86\x00\xF0\x9F\x98\x89\x00"
//    "\xF0\x9F\x98\x8B\x00\xF0\x9F\x98\x8E\x00\xF0\x9F\x98\x8D\x00\xF0\x9F\x98\x98\x00\xF0\x9F\x98\x97\x00\xF0\x9F\x98\x99\x00\xF0\x9F\x98\x9A\x00\xF0\x9F\x99\x82\x00"
//    "\xF0\x9F\xA4\x97\x00\xF0\x9F\xA4\xA9\x00\xF0\x9F\xA4\x94\x00\xF0\x9F\xA4\xA8\x00\xF0\x9F\x98\x90\x00\xF0\x9F\x98\x91\x00\xF0\x9F\x98\xB6\x00\xF0\x9F\x99\x84\x00"
//    "\xF0\x9F\x98\x8F\x00\xF0\x9F\x98\xA3\x00\xF0\x9F\x98\xA5\x00\xF0\x9F\x98\xAE\x00\xF0\x9F\xA4\x90\x00\xF0\x9F\x98\xAF\x00\xF0\x9F\x98\xAA\x00\xF0\x9F\x98\xAB\x00"
//    "\xF0\x9F\x98\xB4\x00\xF0\x9F\x98\x8C\x00\xF0\x9F\x98\x9B\x00\xF0\x9F\x98\x9D\x00\xF0\x9F\xA4\xA4\x00\xF0\x9F\x98\x92\x00\xF0\x9F\x98\x95\x00\xF0\x9F\x99\x83\x00"
//    "\xF0\x9F\xA4\x91\x00\xF0\x9F\x98\xB2\x00\xF0\x9F\x99\x81\x00\xF0\x9F\x98\x96\x00\xF0\x9F\x98\x9E\x00\xF0\x9F\x98\x9F\x00\xF0\x9F\x98\xA4\x00\xF0\x9F\x98\xA2\x00"
//    "\xF0\x9F\x98\xAD\x00\xF0\x9F\x98\xA6\x00\xF0\x9F\x98\xA9\x00\xF0\x9F\xA4\xAF\x00\xF0\x9F\x98\xAC\x00\xF0\x9F\x98\xB0\x00\xF0\x9F\x98\xB1\x00\xF0\x9F\x98\xB3\x00"
//    "\xF0\x9F\xA4\xAA\x00\xF0\x9F\x98\xB5\x00\xF0\x9F\x98\xA1\x00\xF0\x9F\x98\xA0\x00\xF0\x9F\xA4\xAC\x00\xF0\x9F\x98\xB7\x00\xF0\x9F\xA4\x92\x00\xF0\x9F\xA4\x95\x00"
//    "\xF0\x9F\xA4\xA2\x00\xF0\x9F\xA4\xAE\x00\xF0\x9F\xA4\xA7\x00\xF0\x9F\x98\x87\x00\xF0\x9F\xA4\xA0\x00\xF0\x9F\xA4\xAB\x00\xF0\x9F\xA4\xAD\x00\xF0\x9F\xA7\x90\x00"
//    "\xF0\x9F\xA4\x93\x00\xF0\x9F\x98\x88\x00\xF0\x9F\x91\xBF\x00\xF0\x9F\x91\xB9\x00\xF0\x9F\x91\xBA\x00\xF0\x9F\x92\x80\x00\xF0\x9F\x91\xBB\x00\xF0\x9F\x91\xBD\x00"
//    "\xF0\x9F\x91\xBE\x00\xF0\x9F\xA4\x96\x00\xF0\x9F\x92\xA9\x00\xF0\x9F\x98\xBA\x00\xF0\x9F\x98\xB8\x00\xF0\x9F\x98\xB9\x00\xF0\x9F\x98\xBB\x00\xF0\x9F\x98\xBD\x00"
//    "\xF0\x9F\x99\x80\x00\xF0\x9F\x98\xBF\x00\xF0\x9F\x8C\xBE\x00\xF0\x9F\x8C\xBF\x00\xF0\x9F\x8D\x80\x00\xF0\x9F\x8D\x83\x00\xF0\x9F\x8D\x87\x00\xF0\x9F\x8D\x93\x00"
//    "\xF0\x9F\xA5\x9D\x00\xF0\x9F\x8D\x85\x00\xF0\x9F\xA5\xA5\x00\xF0\x9F\xA5\x91\x00\xF0\x9F\x8D\x86\x00\xF0\x9F\xA5\x94\x00\xF0\x9F\xA5\x95\x00\xF0\x9F\x8C\xBD\x00"
//    "\xF0\x9F\x8C\xB6\x00\xF0\x9F\xA5\x92\x00\xF0\x9F\xA5\xA6\x00\xF0\x9F\x8D\x84\x00\xF0\x9F\xA5\x9C\x00\xF0\x9F\x8C\xB0\x00\xF0\x9F\x8D\x9E\x00\xF0\x9F\xA5\x90\x00"
//    "\xF0\x9F\xA5\x96\x00\xF0\x9F\xA5\xA8\x00\xF0\x9F\xA5\x9E\x00\xF0\x9F\xA7\x80\x00\xF0\x9F\x8D\x96\x00\xF0\x9F\x8D\x97\x00\xF0\x9F\xA5\xA9\x00\xF0\x9F\xA5\x93\x00"
//    "\xF0\x9F\x8D\x94\x00\xF0\x9F\x8D\x9F\x00\xF0\x9F\x8D\x95\x00\xF0\x9F\x8C\xAD\x00\xF0\x9F\xA5\xAA\x00\xF0\x9F\x8C\xAE\x00\xF0\x9F\x8C\xAF\x00\xF0\x9F\xA5\x99\x00"
//    "\xF0\x9F\xA5\x9A\x00\xF0\x9F\x8D\xB3\x00\xF0\x9F\xA5\x98\x00\xF0\x9F\x8D\xB2\x00\xF0\x9F\xA5\xA3\x00\xF0\x9F\xA5\x97\x00\xF0\x9F\x8D\xBF\x00\xF0\x9F\xA5\xAB\x00"
//    "\xF0\x9F\x8D\xB1\x00\xF0\x9F\x8D\x98\x00\xF0\x9F\x8D\x9D\x00\xF0\x9F\x8D\xA0\x00\xF0\x9F\x8D\xA2\x00\xF0\x9F\x8D\xA5\x00\xF0\x9F\x8D\xA1\x00\xF0\x9F\xA5\x9F\x00"
//    "\xF0\x9F\xA5\xA1\x00\xF0\x9F\x8D\xA6\x00\xF0\x9F\x8D\xAA\x00\xF0\x9F\x8E\x82\x00\xF0\x9F\x8D\xB0\x00\xF0\x9F\xA5\xA7\x00\xF0\x9F\x8D\xAB\x00\xF0\x9F\x8D\xAF\x00"
//    "\xF0\x9F\x8D\xBC\x00\xF0\x9F\xA5\x9B\x00\xF0\x9F\x8D\xB5\x00\xF0\x9F\x8D\xB6\x00\xF0\x9F\x8D\xBE\x00\xF0\x9F\x8D\xB7\x00\xF0\x9F\x8D\xBB\x00\xF0\x9F\xA5\x82\x00"
//    "\xF0\x9F\xA5\x83\x00\xF0\x9F\xA5\xA4\x00\xF0\x9F\xA5\xA2\x00\xF0\x9F\x91\x81\x00\xF0\x9F\x91\x85\x00\xF0\x9F\x91\x84\x00\xF0\x9F\x92\x8B\x00\xF0\x9F\x92\x98\x00"
//    "\xF0\x9F\x92\x93\x00\xF0\x9F\x92\x97\x00\xF0\x9F\x92\x99\x00\xF0\x9F\x92\x9B\x00\xF0\x9F\xA7\xA1\x00\xF0\x9F\x92\x9C\x00\xF0\x9F\x96\xA4\x00\xF0\x9F\x92\x9D\x00"
//    "\xF0\x9F\x92\x9F\x00\xF0\x9F\x92\x8C\x00\xF0\x9F\x92\xA4\x00\xF0\x9F\x92\xA2\x00\xF0\x9F\x92\xA3\x00";

//	struct {

//	char* text;
//	char* language;
//}
//const messages[] = { // Array containing all of the emojis messages
//    {"\x46\x61\x6C\x73\x63\x68\x65\x73\x20\xC3\x9C\x62\x65\x6E\x20\x76\x6F\x6E\x20\x58\x79\x6C\x6F\x70\x68\x6F\x6E\x6D\x75\x73\x69\x6B\x20\x71\x75\xC3\xA4\x6C"

//	"\x74\x20\x6A\x65\x64\x65\x6E\x20\x67\x72\xC3\xB6\xC3\x9F\x65\x72\x65\x6E\x20\x5A\x77\x65\x72\x67", "German"),
//	{"\x42\x65\x69\xC3\x9F\x20\x6E\x69\x63\x68\x74\x20\x69\x6E\x20\x64\x69\x65\x20\x48\x61\x6E\x64\x2C\x20\x64\x69\x65\x20\x64\x69\x63\x68\x20\x66\xC3\xBC\x74"

//	"\x74\x65\x72\x74\x2E", "German"),
//	{"\x41\x75\xC3\x9F\x65\x72\x6F\x72\x64\x65\x6E\x74\x6C\x69\x63\x68\x65\x20\xC3\x9C\x62\x65\x6C\x20\x65\x72\x66\x6F\x72\x64\x65\x72\x6E\x20\x61\x75\xC3\x9F"

//	"\x65\x72\x6F\x72\x64\x65\x6E\x74\x6C\x69\x63\x68\x65\x20\x4D\x69\x74\x74\x65\x6C\x2E", "German"),
//	{"\xD4\xBF\xD6\x80\xD5\xB6\xD5\xA1\xD5\xB4\x20\xD5\xA1\xD5\xBA\xD5\xA1\xD5\xAF\xD5\xAB\x20\xD5\xB8\xD6\x82\xD5\xBF\xD5\xA5\xD5\xAC\x20\xD6\x87\x20\xD5\xAB"

//	"\xD5\xB6\xD5\xAE\xD5\xAB\x20\xD5\xA1\xD5\xB6\xD5\xB0\xD5\xA1\xD5\xB6\xD5\xA3\xD5\xAB\xD5\xBD\xD5\xBF\x20\xD5\xB9\xD5\xA8\xD5\xB6\xD5\xA5\xD6\x80", "Armenian"),
//	{"\xD4\xB5\xD6\x80\xD5\xA2\x20\xD5\xB8\xD6\x80\x20\xD5\xAF\xD5\xA1\xD6\x81\xD5\xAB\xD5\xB6\xD5\xA8\x20\xD5\xA5\xD5\xAF\xD5\xA1\xD6\x82\x20\xD5\xA1\xD5\xB6\xD5"

//	"\xBF\xD5\xA1\xD5\xBC\x2C\x20\xD5\xAE\xD5\xA1\xD5\xBC\xD5\xA5\xD6\x80\xD5\xA8\x20\xD5\xA1\xD5\xBD\xD5\xA1\xD6\x81\xD5\xAB\xD5\xB6\x2E\x2E\x2E\x20\xC2\xAB\xD4\xBF"

//	"\xD5\xB8\xD5\xBF\xD5\xA8\x20\xD5\xB4\xD5\xA5\xD6\x80\xD5\xB8\xD5\xB6\xD6\x81\xD5\xAB\xD6\x81\x20\xD5\xA7\x3A\xC2\xBB", "Armenian"),
//	{"\xD4\xB3\xD5\xA1\xD5\xBC\xD5\xA8\xD5\x9D\x20\xD5\xA3\xD5\xA1\xD6\x80\xD5\xB6\xD5\xA1\xD5\xB6\x2C\x20\xD5\xB1\xD5\xAB\xD6\x82\xD5\xB6\xD5\xA8\xD5\x9D\x20\xD5"

//	"\xB1\xD5\xB4\xD5\xBC\xD5\xA1\xD5\xB6", "Armenian"),
//	{"\x4A\x65\xC5\xBC\x75\x20\x6B\x6C\xC4\x85\x74\x77\x2C\x20\x73\x70\xC5\x82\xC3\xB3\x64\xC5\xBA\x20\x46\x69\x6E\x6F\x6D\x20\x63\x7A\xC4\x99\xC5\x9B\xC4\x87"

//	"\x20\x67\x72\x79\x20\x68\x61\xC5\x84\x62\x21", "Polish"),
//	{"\x44\x6F\x62\x72\x79\x6D\x69\x20\x63\x68\xC4\x99\x63\x69\x61\x6D\x69\x20\x6A\x65\x73\x74\x20\x70\x69\x65\x6B\xC5\x82\x6F\x20\x77\x79\x62\x72\x75\x6B\x6F"

//	"\x77\x61\x6E\x65\x2E", "Polish"),
//	{"\xC3\x8E\xC8\x9B\x69\x20\x6D\x75\x6C\xC8\x9B\x75\x6D\x65\x73\x63\x20\x63\xC4\x83\x20\x61\x69\x20\x61\x6C\x65\x73\x20\x72\x61\x79\x6C\x69\x62\x2E\x0A\xC8\x98"

//	"\x69\x20\x73\x70\x65\x72\x20\x73\xC4\x83\x20\x61\x69\x20\x6F\x20\x7A\x69\x20\x62\x75\x6E\xC4\x83\x21", "Romanian"),
//	{"\xD0\xAD\xD1\x85\x2C\x20\xD1\x87\xD1\x83\xD0\xB6\xD0\xB0\xD0\xBA\x2C\x20\xD0\xBE\xD0\xB1\xD1\x89\xD0\xB8\xD0\xB9\x20\xD1\x81\xD1\x8A\xD1\x91\xD0\xBC\x20"

//	"\xD1\x86\xD0\xB5\xD0\xBD\x20\xD1\x88\xD0\xBB\xD1\x8F\xD0\xBF\x20\x28\xD1\x8E\xD1\x84\xD1\x82\xD1\x8C\x29\x20\xD0\xB2\xD0\xB4\xD1\x80\xD1\x8B\xD0\xB7\xD0\xB3\x21", "Russian"),
//	{"\xD0\xAF\x20\xD0\xBB\xD1\x8E\xD0\xB1\xD0\xBB\xD1\x8E\x20\x72\x61\x79\x6C\x69\x62\x21", "Russian"),
//	{"\xD0\x9C\xD0\xBE\xD0\xBB\xD1\x87\xD0\xB8\x2C\x20\xD1\x81\xD0\xBA\xD1\x80\xD1\x8B\xD0\xB2\xD0\xB0\xD0\xB9\xD1\x81\xD1\x8F\x20\xD0\xB8\x20\xD1\x82\xD0\xB0\xD0\xB8"

//	"\x0A\xD0\x98\x20\xD1\x87\xD1\x83\xD0\xB2\xD1\x81\xD1\x82\xD0\xB2\xD0\xB0\x20\xD0\xB8\x20\xD0\xBC\xD0\xB5\xD1\x87\xD1\x82\xD1\x8B\x20\xD1\x81\xD0\xB2\xD0\xBE\xD0\xB8\x20"

//	"\xE2\x80\x93\x0A\xD0\x9F\xD1\x83\xD1\x81\xD0\xBA\xD0\xB0\xD0\xB9\x20\xD0\xB2\x20\xD0\xB4\xD1\x83\xD1\x88\xD0\xB5\xD0\xB2\xD0\xBD\xD0\xBE\xD0\xB9\x20\xD0\xB3\xD0\xBB\xD1"

//	"\x83\xD0\xB1\xD0\xB8\xD0\xBD\xD0\xB5\x0A\xD0\x98\x20\xD0\xB2\xD1\x81\xD1\x85\xD0\xBE\xD0\xB4\xD1\x8F\xD1\x82\x20\xD0\xB8\x20\xD0\xB7\xD0\xB0\xD0\xB9\xD0\xB4\xD1\x83\xD1"

//	"\x82\x20\xD0\xBE\xD0\xBD\xD0\xB5\x0A\xD0\x9A\xD0\xB0\xD0\xBA\x20\xD0\xB7\xD0\xB2\xD0\xB5\xD0\xB7\xD0\xB4\xD1\x8B\x20\xD1\x8F\xD1\x81\xD0\xBD\xD1\x8B\xD0\xB5\x20\xD0\xB2"

//	"\x20\xD0\xBD\xD0\xBE\xD1\x87\xD0\xB8\x2D\x0A\xD0\x9B\xD1\x8E\xD0\xB1\xD1\x83\xD0\xB9\xD1\x81\xD1\x8F\x20\xD0\xB8\xD0\xBC\xD0\xB8\x20\xE2\x80\x93\x20\xD0\xB8\x20\xD0\xBC"

//	"\xD0\xBE\xD0\xBB\xD1\x87\xD0\xB8\x2E", "Russian"),
//	{"\x56\x6F\x69\x78\x20\x61\x6D\x62\x69\x67\x75\xC3\xAB\x20\x64\xE2\x80\x99\x75\x6E\x20\x63\xC5\x93\x75\x72\x20\x71\x75\x69\x20\x61\x75\x20\x7A\xC3\xA9\x70"

//	"\x68\x79\x72\x20\x70\x72\xC3\xA9\x66\xC3\xA8\x72\x65\x20\x6C\x65\x73\x20\x6A\x61\x74\x74\x65\x73\x20\x64\x65\x20\x6B\x69\x77\x69", "French"),
//	{"\x42\x65\x6E\x6A\x61\x6D\xC3\xAD\x6E\x20\x70\x69\x64\x69\xC3\xB3\x20\x75\x6E\x61\x20\x62\x65\x62\x69\x64\x61\x20\x64\x65\x20\x6B\x69\x77\x69\x20\x79\x20"

//	"\x66\x72\x65\x73\x61\x3B\x20\x4E\x6F\xC3\xA9\x2C\x20\x73\x69\x6E\x20\x76\x65\x72\x67\xC3\xBC\x65\x6E\x7A\x61\x2C\x20\x6C\x61\x20\x6D\xC3\xA1\x73\x20\x65\x78"

//	"\x71\x75\x69\x73\x69\x74\x61\x20\x63\x68\x61\x6D\x70\x61\xC3\xB1\x61\x20\x64\x65\x6C\x20\x6D\x65\x6E\xC3\xBA\x2E", "Spanish"),
//	{"\xCE\xA4\xCE\xB1\xCF\x87\xCE\xAF\xCF\x83\xCF\x84\xCE\xB7\x20\xCE\xB1\xCE\xBB\xCF\x8E\xCF\x80\xCE\xB7\xCE\xBE\x20\xCE\xB2\xCE\xB1\xCF\x86\xCE\xAE\xCF\x82\x20"

//	"\xCF\x88\xCE\xB7\xCE\xBC\xCE\xAD\xCE\xBD\xCE\xB7\x20\xCE\xB3\xCE\xB7\x2C\x20\xCE\xB4\xCF\x81\xCE\xB1\xCF\x83\xCE\xBA\xCE\xB5\xCE\xBB\xCE\xAF\xCE\xB6\xCE\xB5\xCE"

//	"\xB9\x20\xCF\x85\xCF\x80\xCE\xAD\xCF\x81\x20\xCE\xBD\xCF\x89\xCE\xB8\xCF\x81\xCE\xBF\xCF\x8D\x20\xCE\xBA\xCF\x85\xCE\xBD\xCF\x8C\xCF\x82", "Greek"),
//	{"\xCE\x97\x20\xCE\xBA\xCE\xB1\xCE\xBB\xCF\x8D\xCF\x84\xCE\xB5\xCF\x81\xCE\xB7\x20\xCE\xAC\xCE\xBC\xCF\x85\xCE\xBD\xCE\xB1\x20\xCE\xB5\xCE\xAF\xCE\xBD"

//	"\xCE\xB1\xCE\xB9\x20\xCE\xB7\x20\xCE\xB5\xCF\x80\xCE\xAF\xCE\xB8\xCE\xB5\xCF\x83\xCE\xB7\x2E", "Greek"),
//	{"\xCE\xA7\xCF\x81\xCF\x8C\xCE\xBD\xCE\xB9\xCE\xB1\x20\xCE\xBA\xCE\xB1\xCE\xB9\x20\xCE\xB6\xCE\xB1\xCE\xBC\xCE\xAC\xCE\xBD\xCE\xB9\xCE\xB1\x21", "Greek"),
//	{"\xCE\xA0\xCF\x8E\xCF\x82\x20\xCF\x84\xCE\xB1\x20\xCF\x80\xCE\xB1\xCF\x82\x20\xCF\x83\xCE\xAE\xCE\xBC\xCE\xB5\xCF\x81\xCE\xB1\x3B", "Greek"),

//	{"\xE6\x88\x91\xE8\x83\xBD\xE5\x90\x9E\xE4\xB8\x8B\xE7\x8E\xBB\xE7\x92\x83\xE8\x80\x8C\xE4\xB8\x8D\xE4\xBC\xA4\xE8\xBA\xAB\xE4\xBD\x93\xE3\x80\x82", "Chinese"),
//	{"\xE4\xBD\xA0\xE5\x90\x83\xE4\xBA\x86\xE5\x90\x97\xEF\xBC\x9F", "Chinese"),
//	{"\xE4\xB8\x8D\xE4\xBD\x9C\xE4\xB8\x8D\xE6\xAD\xBB\xE3\x80\x82", "Chinese"),
//	{"\xE6\x9C\x80\xE8\xBF\x91\xE5\xA5\xBD\xE5\x90\x97\xEF\xBC\x9F", "Chinese"),
//	{"\xE5\xA1\x9E\xE7\xBF\x81\xE5\xA4\xB1\xE9\xA9\xAC\xEF\xBC\x8C\xE7\x84\x89\xE7\x9F\xA5\xE9\x9D\x9E\xE7\xA6\x8F\xE3\x80\x82", "Chinese"),
//	{"\xE5\x8D\x83\xE5\x86\x9B\xE6\x98\x93\xE5\xBE\x97\x2C\x20\xE4\xB8\x80\xE5\xB0\x86\xE9\x9A\xBE\xE6\xB1\x82", "Chinese"),
//	{"\xE4\xB8\x87\xE4\xBA\x8B\xE5\xBC\x80\xE5\xA4\xB4\xE9\x9A\xBE\xE3\x80\x82", "Chinese"),
//	{"\xE9\xA3\x8E\xE6\x97\xA0\xE5\xB8\xB8\xE9\xA1\xBA\xEF\xBC\x8C\xE5\x85\xB5\xE6\x97\xA0\xE5\xB8\xB8\xE8\x83\x9C\xE3\x80\x82", "Chinese"),
//	{"\xE6\xB4\xBB\xE5\x88\xB0\xE8\x80\x81\xEF\xBC\x8C\xE5\xAD\xA6\xE5\x88\xB0\xE8\x80\x81\xE3\x80\x82", "Chinese"),
//	{"\xE4\xB8\x80\xE8\xA8\x80\xE6\x97\xA2\xE5\x87\xBA\xEF\xBC\x8C\xE9\xA9\xB7\xE9\xA9\xAC\xE9\x9A\xBE\xE8\xBF\xBD\xE3\x80\x82", "Chinese"),
//	{"\xE8\xB7\xAF\xE9\x81\xA5\xE7\x9F\xA5\xE9\xA9\xAC\xE5\x8A\x9B\xEF\xBC\x8C\xE6\x97\xA5\xE4\xB9\x85\xE8\xA7\x81\xE4\xBA\xBA\xE5\xBF\x83", "Chinese"),
//	{"\xE6\x9C\x89\xE7\x90\x86\xE8\xB5\xB0\xE9\x81\x8D\xE5\xA4\xA9\xE4\xB8\x8B\xEF\xBC\x8C\xE6\x97\xA0\xE7\x90\x86\xE5\xAF\xB8\xE6\xAD\xA5\xE9\x9A\xBE\xE8\xA1\x8C\xE3\x80\x82", "Chinese"),

//	{"\xE7\x8C\xBF\xE3\x82\x82\xE6\x9C\xA8\xE3\x81\x8B\xE3\x82\x89\xE8\x90\xBD\xE3\x81\xA1\xE3\x82\x8B", "Japanese"),
//	{"\xE4\xBA\x80\xE3\x81\xAE\xE7\x94\xB2\xE3\x82\x88\xE3\x82\x8A\xE5\xB9\xB4\xE3\x81\xAE\xE5\x8A\x9F", "Japanese"),
//	{"\xE3\x81\x86\xE3\x82\x89\xE3\x82\x84\xE3\x81\xBE\xE3\x81\x97\x20\x20\xE6\x80\x9D\xE3\x81\xB2\xE5\x88\x87\xE3\x82\x8B\xE6\x99\x82\x20\x20\xE7\x8C\xAB\xE3\x81\xAE\xE6\x81\x8B", "Japanese"),
//	{"\xE8\x99\x8E\xE7\xA9\xB4\xE3\x81\xAB\xE5\x85\xA5\xE3\x82\x89\xE3\x81\x9A\xE3\x82\x93\xE3\x81\xB0\xE8\x99\x8E\xE5\xAD\x90\xE3\x82\x92\xE5\xBE\x97\xE3\x81\x9A\xE3\x80\x82", "Japanese"),
//	{"\xE4\xBA\x8C\xE5\x85\x8E\xE3\x82\x92\xE8\xBF\xBD\xE3\x81\x86\xE8\x80\x85\xE3\x81\xAF\xE4\xB8\x80\xE5\x85\x8E\xE3\x82\x92\xE3\x82\x82\xE5\xBE\x97\xE3\x81\x9A\xE3\x80\x82", "Japanese"),
//	{"\xE9\xA6\xAC\xE9\xB9\xBF\xE3\x81\xAF\xE6\xAD\xBB\xE3\x81\xAA\xE3\x81\xAA\xE3\x81\x8D\xE3\x82\x83\xE6\xB2\xBB\xE3\x82\x89\xE3\x81\xAA\xE3\x81\x84\xE3\x80\x82", "Japanese"),
//	{"\xE6\x9E\xAF\xE9\x87\x8E\xE8\xB7\xAF\xE3\x81\xAB\xE3\x80\x80\xE5\xBD\xB1\xE3\x81\x8B\xE3\x81\x95\xE3\x81\xAA\xE3\x82\x8A\xE3\x81\xA6\xE3\x80\x80\xE3\x82\x8F\xE3\x81\x8B\xE3\x82\x8C\xE3\x81\x91\xE3\x82\x8A", "Japanese"),
//	{"\xE7\xB9\xB0\xE3\x82\x8A\xE8\xBF\x94\xE3\x81\x97\xE9\xBA\xA6\xE3\x81\xAE\xE7\x95\x9D\xE7\xB8\xAB\xE3\x81\xB5\xE8\x83\xA1\xE8\x9D\xB6\xE5\x93\x89", "Japanese"),

//	{"\xEC\x95\x84\xEB\x93\x9D\xED\x95\x9C\x20\xEB\xB0\x94\xEB\x8B\xA4\x20\xEC\x9C\x84\xEC\x97\x90\x20\xEA\xB0\x88\xEB\xA7\xA4\xEA\xB8\xB0\x20\xEB\x91\x90\xEC\x97\x87\x20"

//	"\xEB\x82\xA0\xEC\x95\x84\x20\xEB\x8F\x88\xEB\x8B\xA4\x2E\x0A\xEB\x84\x88\xED\x9B\x8C\xEB\x84\x88\xED\x9B\x8C\x20\xEC\x8B\x9C\xEB\xA5\xBC\x20\xEC\x93\xB4\xEB\x8B\xA4\x2E"

//	"\x20\xEB\xAA\xA8\xEB\xA5\xB4\xEB\x8A\x94\x20\xEB\x82\x98\xEB\x9D\xBC\x20\xEA\xB8\x80\xEC\x9E\x90\xEB\x8B\xA4\x2E\x0A\xEB\x84\x90\xEB\x94\xB0\xEB\x9E\x80\x20\xED\x95\x98"

//	"\xEB\x8A\x98\x20\xEB\xB3\xB5\xED\x8C\x90\xEC\x97\x90\x20\xEB\x82\x98\xEB\x8F\x84\x20\xEA\xB0\x99\xEC\x9D\xB4\x20\xEC\x8B\x9C\xEB\xA5\xBC\x20\xEC\x93\xB4\xEB\x8B\xA4\x2E", "Korean"),
//	{"\xEC\xA0\x9C\x20\xEB\x88\x88\xEC\x97\x90\x20\xEC\x95\x88\xEA\xB2\xBD\xEC\x9D\xB4\xEB\x8B\xA4", "Korean"),
//	{"\xEA\xBF\xA9\x20\xEB\xA8\xB9\xEA\xB3\xA0\x20\xEC\x95\x8C\x20\xEB\xA8\xB9\xEB\x8A\x94\xEB\x8B\xA4", "Korean"),
//	{"\xEB\xA1\x9C\xEB\xA7\x88\xEB\x8A\x94\x20\xED\x95\x98\xEB\xA3\xA8\xEC\x95\x84\xEC\xB9\xA8\xEC\x97\x90\x20\xEC\x9D\xB4\xEB\xA3\xA8\xEC\x96\xB4\xEC\xA7\x84\x20\xEA\xB2\x83\xEC\x9D\xB4"

//	"\x20\xEC\x95\x84\xEB\x8B\x88\xEB\x8B\xA4", "Korean"),
//	{"\xEA\xB3\xA0\xEC\x83\x9D\x20\xEB\x81\x9D\xEC\x97\x90\x20\xEB\x82\x99\xEC\x9D\xB4\x20\xEC\x98\xA8\xEB\x8B\xA4", "Korean"),
//	{"\xEA\xB0\x9C\xEC\xB2\x9C\xEC\x97\x90\xEC\x84\x9C\x20\xEC\x9A\xA9\x20\xEB\x82\x9C\xEB\x8B\xA4", "Korean"),
//	{"\xEC\x95\x88\xEB\x85\x95\xED\x95\x98\xEC\x84\xB8\xEC\x9A\x94\x3F", "Korean"),
//	{"\xEB\xA7\x8C\xEB\x82\x98\xEC\x84\x9C\x20\xEB\xB0\x98\xEA\xB0\x91\xEC\x8A\xB5\xEB\x8B\x88\xEB\x8B\xA4", "Korean"),
//	{"\xED\x95\x9C\xEA\xB5\xAD\xEB\xA7\x90\x20\xED\x95\x98\xEC\x8B\xA4\x20\xEC\xA4\x84\x20\xEC\x95\x84\xEC\x84\xB8\xEC\x9A\x94\x3F", "Korean"),
//};

////--------------------------------------------------------------------------------------
//// Module functions declaration
////--------------------------------------------------------------------------------------
//static void RandomizeEmoji(void);    // Fills the emoji array with random emojis

//static void DrawTextBoxed(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint);   // Draw text using font inside rectangle limits
//static void DrawTextBoxedSelectable(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint);    // Draw text using font inside rectangle limits with support for text selection

////--------------------------------------------------------------------------------------
//// Global variables
////--------------------------------------------------------------------------------------
//// Arrays that holds the random emojis
//struct {

//	int index;      // Index inside `emojiCodepoints`
//int message;    // Message index
//Color color;    // Emoji color
//} emoji[EMOJI_PER_WIDTH * EMOJI_PER_HEIGHT] = { 0 };

//static int hovered = -1, selected = -1;

////--------------------------------------------------------------------------------------
//// Main entry point
////--------------------------------------------------------------------------------------
//int main(int argc, char** argv)
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_VSYNC_HINT);
//	InitWindow(screenWidth, screenHeight, "raylib [text] example - unicode");

//	// Load the font resources
//	// NOTE: fontAsian is for asian languages,
//	// fontEmoji is the emojis and fontDefault is used for everything else
//	Font fontDefault = LoadFont("resources/dejavu.fnt");
//	Font fontAsian = LoadFont("resources/noto_cjk.fnt");
//	Font fontEmoji = LoadFont("resources/symbola.fnt");

//	Vector2 hoveredPos = new Vector2( 0.0f, 0.0f );
//	Vector2 selectedPos = new Vector2( 0.0f, 0.0f );

//	// Set a random set of emojis when starting up
//	RandomizeEmoji();

//	SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//									//--------------------------------------------------------------------------------------

//	// Main loop
//	while (!WindowShouldClose())    // Detect window close button or ESC key
//	{
//		// Update
//		//----------------------------------------------------------------------------------
//		// Add a new set of emojis when SPACE is pressed
//		if (IsKeyPressed(KEY_SPACE)) RandomizeEmoji();

//		// Set the selected emoji and copy its text to clipboard
//		if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT) && (hovered != -1) && (hovered != selected))
//		{
//			selected = hovered;
//			selectedPos = hoveredPos;
//			SetClipboardText(messages[emoji[selected].message].text);
//		}

//		Vector2 mouse = GetMousePosition();
//		Vector2 pos = new Vector2( 28.8f, 10.0f );
//		hovered = -1;
//		//----------------------------------------------------------------------------------

//		// Draw
//		//----------------------------------------------------------------------------------
//		BeginDrawing();

//		ClearBackground(RAYWHITE);

//		// Draw random emojis in the background
//		//------------------------------------------------------------------------------
//		for (int i = 0; i < SIZEOF(emoji); ++i)
//		{
//			const char* txt = &emojiCodepoints[emoji[i].index];
//			Rectangle emojiRect = new Rectangle( pos.X, pos.Y, (float)fontEmoji.baseSize, (float)fontEmoji.baseSize );

//			if (!CheckCollisionPointRec(mouse, emojiRect))
//			{
//				DrawTextEx(fontEmoji, txt, pos, (float)fontEmoji.baseSize, 1.0f, selected == i ? emoji[i].color : Fade(LIGHTGRAY, 0.4f));
//			}
//			else
//			{
//				DrawTextEx(fontEmoji, txt, pos, (float)fontEmoji.baseSize, 1.0f, emoji[i].color);
//				hovered = i;
//				hoveredPos = pos;
//			}

//			if ((i != 0) && (i % EMOJI_PER_WIDTH == 0)) { pos.Y += fontEmoji.baseSize + 24.25f; pos.X = 28.8f; }
//			else pos.X += fontEmoji.baseSize + 28.8f;
//		}
//		//------------------------------------------------------------------------------

//		// Draw the message when a emoji is selected
//		//------------------------------------------------------------------------------
//		if (selected != -1)
//		{
//			const int message = emoji[selected].message;
//			const int horizontalPadding = 20, verticalPadding = 30;
//			Font* font = &fontDefault;

//			// Set correct font for asian languages
//			if (TextIsEqual(messages[message].language, "Chinese") ||
//				TextIsEqual(messages[message].language, "Korean") ||
//				TextIsEqual(messages[message].language, "Japanese")) font = &fontAsian;

//			// Calculate size for the message box (approximate the height and width)
//			Vector2 sz = MeasureTextEx(*font, messages[message].text, (float)font->baseSize, 1.0f);
//			if (sz.X > 300) { sz.Y *= sz.X / 300; sz.X = 300; }
//			else if (sz.X < 160) sz.X = 160;

//			Rectangle msgRect = new Rectangle( selectedPos.X - 38.8f, selectedPos.Y, 2 * horizontalPadding + sz.X, 2 * verticalPadding + sz.Y );
//			msgRect.Y -= msgRect.height;

//			// Coordinates for the chat bubble triangle
//			Vector2 a = new Vector2( selectedPos.X, msgRect.Y + msgRect.height ), b = { a.X + 8, a.Y + 10 ), c = { a.X + 10, a.Y );

//			// Don't go outside the screen
//			if (msgRect.X < 10) msgRect.X += 28;
//			if (msgRect.Y < 10)
//			{
//				msgRect.Y = selectedPos.Y + 84;
//				a.Y = msgRect.Y;
//				c.Y = a.Y;
//				b.Y = a.Y - 10;

//				// Swap values so we can actually render the triangle :(
//				Vector2 tmp = a;
//				a = b;
//				b = tmp;
//			}
//			if (msgRect.X + msgRect.width > screenWidth) msgRect.X -= (msgRect.X + msgRect.width) - screenWidth + 10;

//			// Draw chat bubble
//			DrawRectangleRec(msgRect, emoji[selected].color);
//			DrawTriangle(a, b, c, emoji[selected].color);

//			// Draw the main text message
//			Rectangle textRect = new Rectangle( msgRect.X + horizontalPadding / 2, msgRect.Y + verticalPadding / 2, msgRect.width - horizontalPadding, msgRect.height );
//			DrawTextBoxed(*font, messages[message].text, textRect, (float)font->baseSize, 1.0f, true, WHITE);

//			// Draw the info text below the main message
//			int size = (int)strlen(messages[message].text);
//			int length = GetCodepointCount(messages[message].text);
//			const char* info = TextFormat("%s %u characters %i bytes", messages[message].language, length, size);
//			sz = MeasureTextEx(GetFontDefault(), info, 10, 1.0f);
//			Vector2 pos = new Vector2( textRect.X + textRect.width - sz.X, msgRect.Y + msgRect.height - sz.Y - 2 );
//			DrawText(info, (int)pos.X, (int)pos.Y, 10, RAYWHITE);
//		}
//		//------------------------------------------------------------------------------

//		// Draw the info text
//		DrawText("These emojis have something to tell you, click each to find out!", (screenWidth - 650) / 2, screenHeight - 40, 20, GRAY);
//		DrawText("Each emoji is a unicode character from a font, not a texture... Press [SPACEBAR] to refresh", (screenWidth - 484) / 2, screenHeight - 16, 10, GRAY);

//		EndDrawing();
//		//----------------------------------------------------------------------------------
//	}

//	// De-Initialization
//	//--------------------------------------------------------------------------------------
//	UnloadFont(fontDefault);    // Unload font resource
//	UnloadFont(fontAsian);      // Unload font resource
//	UnloadFont(fontEmoji);      // Unload font resource

//	CloseWindow();              // Close window and OpenGL context
//								//--------------------------------------------------------------------------------------

//	return 0;
//}
//}

//// Fills the emoji array with random emoji (only those emojis present in fontEmoji)
//static void RandomizeEmoji(void)
//{
//	hovered = selected = -1;
//	int start = GetRandomValue(45, 360);

//	for (int i = 0; i < SIZEOF(emoji); ++i)
//	{
//		// 0-179 emoji codepoints (from emoji char array) each 4bytes + null char
//		emoji[i].index = GetRandomValue(0, 179) * 5;

//		// Generate a random color for this emoji
//		emoji[i].color = Fade(ColorFromHSV((float)((start * (i + 1)) % 360), 0.6f, 0.85f), 0.8f);

//		// Set a random message for this emoji
//		emoji[i].message = GetRandomValue(0, SIZEOF(messages) - 1);
//	}
//}

////--------------------------------------------------------------------------------------
//// Module functions definition
////--------------------------------------------------------------------------------------

//// Draw text using font inside rectangle limits
//static void DrawTextBoxed(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint)
//{
//	DrawTextBoxedSelectable(font, text, rec, fontSize, spacing, wordWrap, tint, 0, 0, WHITE, WHITE);
//}

//// Draw text using font inside rectangle limits with support for text selection
//static void DrawTextBoxedSelectable(Font font, const char* text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint)
//{
//	int length = TextLength(text);  // Total length in bytes of the text, scanned by codepoints in loop

//	float textOffsetY = 0;          // Offset between lines (on line break '\n')
//	float textOffsetX = 0.0f;       // Offset X to next character to draw

//	float scaleFactor = fontSize / (float)font.baseSize;     // Character rectangle scaling factor

//	// Word/character wrapping mechanism variables
//enum { MEASURE_STATE = 0, DRAW_STATE = 1 };
//int state = wordWrap ? MEASURE_STATE : DRAW_STATE;

//int startLine = -1;         // Index where to begin drawing (where a line begins)
//int endLine = -1;           // Index where to stop drawing (where a line ends)
//int lastk = -1;             // Holds last value of the character position

//for (int i = 0, k = 0; i < length; i++, k++)
//{
//	// Get next codepoint from byte string and glyph index in font
//	int codepointByteCount = 0;
//	int codepoint = GetCodepoint(&text[i], &codepointByteCount);
//	int index = GetGlyphIndex(font, codepoint);

//	// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
//	// but we need to draw all of the bad bytes using the '?' symbol moving one byte
//	if (codepoint == 0x3f) codepointByteCount = 1;
//	i += (codepointByteCount - 1);

//	float glyphWidth = 0;
//	if (codepoint != '\n')
//	{
//		glyphWidth = (font.glyphs[index].advanceX == 0) ? font.recs[index].width * scaleFactor : font.glyphs[index].advanceX * scaleFactor;

//		if (i + 1 < length) glyphWidth = glyphWidth + spacing;
//	}

//	// NOTE: When wordWrap is ON we first measure how much of the text we can draw before going outside of the rec container
//	// We store this info in startLine and endLine, then we change states, draw the text between those two variables
//	// and change states again and again recursively until the end of the text (or until we get outside of the container).
//	// When wordWrap is OFF we don't need the measure state so we go to the drawing state immediately
//	// and begin drawing on the next line before we can get outside the container.
//	if (state == MEASURE_STATE)
//	{
//		// TODO: There are multiple types of spaces in UNICODE, maybe it's a good idea to add support for more
//		// Ref: http://jkorpela.fi/chars/spaces.html
//		if ((codepoint == ' ') || (codepoint == '\t') || (codepoint == '\n')) endLine = i;

//		if ((textOffsetX + glyphWidth) > rec.width)
//		{
//			endLine = (endLine < 1) ? i : endLine;
//			if (i == endLine) endLine -= codepointByteCount;
//			if ((startLine + codepointByteCount) == endLine) endLine = (i - codepointByteCount);

//			state = !state;
//		}
//		else if ((i + 1) == length)
//		{
//			endLine = i;
//			state = !state;
//		}
//		else if (codepoint == '\n') state = !state;

//		if (state == DRAW_STATE)
//		{
//			textOffsetX = 0;
//			i = startLine;
//			glyphWidth = 0;

//			// Save character position when we switch states
//			int tmp = lastk;
//			lastk = k - 1;
//			k = tmp;
//		}
//	}
//	else
//	{
//		if (codepoint == '\n')
//		{
//			if (!wordWrap)
//			{
//				textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//				textOffsetX = 0;
//			}
//		}
//		else
//		{
//			if (!wordWrap && ((textOffsetX + glyphWidth) > rec.width))
//			{
//				textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//				textOffsetX = 0;
//			}

//			// When text overflows rectangle height limit, just stop drawing
//			if ((textOffsetY + font.baseSize * scaleFactor) > rec.height) break;

//			// Draw selection background
//			bool isGlyphSelected = false;
//			if ((selectStart >= 0) && (k >= selectStart) && (k < (selectStart + selectLength)))
//			{
//				DrawRectangleRec(new Rectangle(rec.X + textOffsetX - 1, rec.Y + textOffsetY, glyphWidth, (float)font.baseSize * scaleFactor), selectBackTint);
//				isGlyphSelected = true;
//			}

//			// Draw current character glyph
//			if ((codepoint != ' ') && (codepoint != '\t'))
//			{
//				DrawTextCodepoint(font, codepoint, new Vector2(rec.X + textOffsetX, rec.Y + textOffsetY), fontSize, isGlyphSelected ? selectTint : tint);
//			}
//		}

//		if (wordWrap && (i == endLine))
//		{
//			textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
//			textOffsetX = 0;
//			startLine = endLine;
//			endLine = -1;
//			glyphWidth = 0;
//			selectStart += lastk - k;
//			k = lastk;

//			state = !state;
//		}
//	}

//	textOffsetX += glyphWidth;
//}
//}


///*******************************************************************************************
//*
//*   raylib [text] example - Text Writing Animation
//*
//*   This example has been created using raylib 2.3 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
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

//		InitWindow(screenWidth, screenHeight, "raylib [text] example - text writing anim");

//		const char[] message = new char[128] "This sample illustrates a text writing\nanimation effect! Check it out! ;)";

//		int framesCounter = 0;

//		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
//										//--------------------------------------------------------------------------------------

//		// Main game loop
//		while (!WindowShouldClose())    // Detect window close button or ESC key
//		{
//			// Update
//			//----------------------------------------------------------------------------------
//			if (IsKeyDown(KEY_SPACE)) framesCounter += 8;
//			else framesCounter++;

//			if (IsKeyPressed(KEY_ENTER)) framesCounter = 0;
//			//----------------------------------------------------------------------------------

//			// Draw
//			//----------------------------------------------------------------------------------
//			BeginDrawing();

//			ClearBackground(RAYWHITE);

//			DrawText(TextSubtext(message, 0, framesCounter / 10), 210, 160, 20, MAROON);

//			DrawText("PRESS [ENTER] to RESTART!", 240, 260, 20, LIGHTGRAY);
//			DrawText("PRESS [SPACE] to SPEED UP!", 239, 300, 20, LIGHTGRAY);

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
//*   raylib [shapes] example - Draw basic shapes 2d (rectangle, circle, line...)
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

//public unsafe static class TEMPLATE
//{

//	public static int main()
//	{
//		// Initialization
//		//---------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - bouncing ball");

//		Vector2 ballPosition = new Vector2( GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f );
//		Vector2 ballSpeed = new Vector2( 5.0f, 4.0f );
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
//			if (pause && ((framesCounter / 30) % 2)) DrawText("PAUSED", 350, 200, 30, GRAY);

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

//public unsafe static class TEMPLATE
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
//		Rectangle boxA = new Rectangle( 10, GetScreenHeight() / 2.0f - 50, 200, 100 );
//		int boxASpeedX = 4;

//		// Box B: Mouse moved box
//		Rectangle boxB = new Rectangle( GetScreenWidth() / 2.0f - 30, GetScreenHeight() / 2.0f - 30, 60, 60 );

//		Rectangle boxCollision = new Rectangle( 0 ); // Collision rectangle

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

//public unsafe static class TEMPLATE
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

//		const char* colorNames[MAX_COLORS_COUNT] = {
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

//		Vector2 mousePoint = new Vector2( 0.0f, 0.0f );

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
//				else[] colorState = new else[i] 0;
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
//				DrawRectangleRec(colorsRecs[i], Fade(colors[i], colorState[i] ? 0.6f : 1.0f));

//				if (IsKeyDown(KEY_SPACE) || colorState[i])
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

//# include <raylib.h>

//#define RAYGUI_IMPLEMENTATION
//# include "extras/raygui.h"                 // Required for GUI controls

//public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw circle sector");

//	Vector2 center = new Vector2( (GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f );

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
//		startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", NULL, startAngle, 0, 720);
//		endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", NULL, endAngle, 0, 720);

//		outerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "Radius", NULL, outerRadius, 0, 200);
//		segments = (int)GuiSliderBar(new Rectangle(600, 170, 120, 20), "Segments", NULL, (float)segments, 0, 100);
//		//------------------------------------------------------------------------------

//		minSegments = (int)ceilf((endAngle - startAngle) / 90);
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

//#include <raylib.h>

//#define RAYGUI_IMPLEMENTATION
//#include "extras/raygui.h"                 // Required for GUI controls

//public static int main()
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
//		Rectangle rec = new Rectangle( ((float)GetScreenWidth() - width - 250) / 2, (GetScreenHeight() - height) / 2.0f, (float)width, (float)height );
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
//		width = (int)GuiSliderBar(new Rectangle(640, 40, 105, 20), "Width", NULL, (float)width, 0, (float)GetScreenWidth() - 300);
//		height = (int)GuiSliderBar(new Rectangle(640, 70, 105, 20), "Height", NULL, (float)height, 0, (float)GetScreenHeight() - 50);
//		roundness = GuiSliderBar(new Rectangle(640, 140, 105, 20), "Roundness", NULL, roundness, 0.0f, 1.0f);
//		lineThick = (int)GuiSliderBar(new Rectangle(640, 170, 105, 20), "Thickness", NULL, (float)lineThick, 0, 20);
//		segments = (int)GuiSliderBar(new Rectangle(640, 240, 105, 20), "Segments", NULL, (float)segments, 0, 60);

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

//#include <raylib.h>

//#define RAYGUI_IMPLEMENTATION
//#include "extras/raygui.h"                 // Required for GUI controls

//public static int main()
//{
//	// Initialization
//	//--------------------------------------------------------------------------------------
//	const int screenWidth = 800;
//	const int screenHeight = 450;

//	InitWindow(screenWidth, screenHeight, "raylib [shapes] example - draw ring");

//	Vector2 center = new Vector2( (GetScreenWidth() - 300) / 2.0f, GetScreenHeight() / 2.0f );

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
//		startAngle = GuiSliderBar(new Rectangle(600, 40, 120, 20), "StartAngle", NULL, startAngle, -450, 450);
//		endAngle = GuiSliderBar(new Rectangle(600, 70, 120, 20), "EndAngle", NULL, endAngle, -450, 450);

//		innerRadius = GuiSliderBar(new Rectangle(600, 140, 120, 20), "InnerRadius", NULL, innerRadius, 0, 100);
//		outerRadius = GuiSliderBar(new Rectangle(600, 170, 120, 20), "OuterRadius", NULL, outerRadius, 0, 200);

//		segments = (int)GuiSliderBar(new Rectangle(600, 240, 120, 20), "Segments", NULL, (float)segments, 0, 100);

//		drawRing = GuiCheckBox(new Rectangle(600, 320, 20, 20), "Draw Ring", drawRing);
//		drawRingLines = GuiCheckBox(new Rectangle(600, 350, 20, 20), "Draw RingLines", drawRingLines);
//		drawCircleLines = GuiCheckBox(new Rectangle(600, 380, 20, 20), "Draw CircleLines", drawCircleLines);
//		//------------------------------------------------------------------------------

//		int minSegments = (int)ceilf((endAngle - startAngle) / 90);
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

//# include "extras/easings.h"                // Required for easing functions

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

//# include "extras/easings.h"            // Required for easing functions

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - easings box anim");

//		// Box variables to be animated with easings
//		Rectangle rec = new Rectangle( GetScreenWidth() / 2.0f, -100, 100, 100 );
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

//# include "extras/easings.h"            // Required for easing functions

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

//# include <math.h>       // Required for: atan2f()

//	public static int main()
//	{
//		// Initialization
//		//--------------------------------------------------------------------------------------
//		const int screenWidth = 800;
//		const int screenHeight = 450;

//		InitWindow(screenWidth, screenHeight, "raylib [shapes] example - following eyes");

//		Vector2 scleraLeftPosition = new Vector2( GetScreenWidth() / 2.0f - 100.0f, GetScreenHeight() / 2.0f );
//		Vector2 scleraRightPosition = new Vector2( GetScreenWidth() / 2.0f + 100.0f, GetScreenHeight() / 2.0f );
//		float scleraRadius = 80;

//		Vector2 irisLeftPosition = new Vector2( GetScreenWidth() / 2.0f - 100.0f, GetScreenHeight() / 2.0f );
//		Vector2 irisRightPosition = new Vector2( GetScreenWidth() / 2.0f + 100.0f, GetScreenHeight() / 2.0f );
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

//				dxx = (scleraRadius - irisRadius) * cosf(angle);
//				dyy = (scleraRadius - irisRadius) * sinf(angle);

//				irisLeftPosition.X = scleraLeftPosition.X + dxx;
//				irisLeftPosition.Y = scleraLeftPosition.Y + dyy;
//			}

//			// Check not inside the right eye sclera
//			if (!CheckCollisionPointCircle(irisRightPosition, scleraRightPosition, scleraRadius - 20))
//			{
//				dx = irisRightPosition.X - scleraRightPosition.X;
//				dy = irisRightPosition.Y - scleraRightPosition.Y;

//				angle = atan2f(dy, dx);

//				dxx = (scleraRadius - irisRadius) * cosf(angle);
//				dyy = (scleraRadius - irisRadius) * sinf(angle);

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

//		Vector2 start = new Vector2( 0, 0 );
//		Vector2 end = new Vector2( (float)screenWidth, (float)screenHeight );

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

//		Rectangle rec = new Rectangle( 100, 100, 200, 80 );

//		Vector2 mousePosition = new Vector2( 0 );

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
//# include <math.h>           // Required for: sinf()
//# include <string.h>         // Required for: memcpy()

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
//		short* data = (short*)malloc(sizeof(short) * MAX_SAMPLES);

//		// Frame buffer, describing the waveform when repeated over the course of a frame
//		short* writeBuf = (short*)malloc(sizeof(short) * MAX_SAMPLES_PER_UPDATE);

//		PlayAudioStream(stream);        // Start processing stream buffer (no data loaded currently)

//		// Position read in to determine next frequency
//		Vector2 mousePosition = new Vector2( -100.0f, -100.0f );

//		// Cycles per second (hz)
//		float frequency = 440.0f;

//		// Previous value, used to test if sine needs to be rewritten, and to smoothly modulate frequency
//		float oldFrequency = 1.0f;

//		// Cursor to read and copy the samples of the sine wave buffer
//		int readCursor = 0;

//		// Computed size in samples of the sine wave
//		int waveLength = 1;

//		Vector2 position = new Vector2( 0, 0 );

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
//					data[i] = (short)(sinf(((2 * PI * (float)i / waveLength))) * 32000);
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
//					memcpy(writeBuf + writeCursor, data + readCursor, writeLength * sizeof(short));

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







