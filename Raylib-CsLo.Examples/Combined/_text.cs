// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylib_CsLo.Examples.Text;




/*******************************************************************************************
*
*   raylib [text] example - Draw 2D text in 3D
*
*   Draw a 2D text in 3D space, each letter is drawn in a quad (or 2 quads if backface is set)
*   where the texture coodinates of each quad map to the texture coordinates of the glyphs
*   inside the font texture.
*    A more efficient approach, i believe, would be to render the text in a render texture and
*    map that texture to a plane and render that, or maybe a shader but my method allows more
*    flexibility...for example to change position of each letter individually to make somethink
*    like a wavy text effect.
*    
*    Special thanks to:
*        @Nighten for the DrawTextStyle() code https://github.com/NightenDushi/Raylib_DrawTextStyle
*        Chris Camacho (codifies - http://bedroomcoders.co.uk/) for the alpha discard shader
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@Demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (C) 2021 Vlad Adrian (@Demizdor - https://github.com/Demizdor)
*
********************************************************************************************/

public unsafe static class Draw2dIn3d
{
	// # include "rlgl.h"

	// # include <stddef.h>     // Required for: null
	// # include <math.h>       // Required for: MathF.Sin()

	// To make it work with the older RLGL module just comment the line below
	//#define RAYLIB_NEW_RLGL

	//--------------------------------------------------------------------------------------
	// Globals
	//--------------------------------------------------------------------------------------
	const float LETTER_BOUNDRY_SIZE = 0.25f;
	const int TEXT_MAX_LAYERS = 32;
	static Color LETTER_BOUNDRY_COLOR = VIOLET;

	static bool SHOW_LETTER_BOUNDRY = false;
	static bool SHOW_TEXT_BOUNDRY = false;

	//--------------------------------------------------------------------------------------
	// Data Types definition
	//--------------------------------------------------------------------------------------

	// Configuration structure for waving the text
	struct WaveTextConfig
	{

		public Vector3 waveRange;
		public Vector3 waveSpeed;
		public Vector3 waveOffset;
	}

	//------------------------------------------------------------------------------------
	// Program main entry point
	//------------------------------------------------------------------------------------
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_VSYNC_HINT);
		InitWindow(screenWidth, screenHeight, "raylib [text] example - draw 2D text in 3D");

		bool spin = true;        // Spin the camera?
		bool multicolor = false; // Multicolor mode

		// Define the camera to look into our 3d world
		Camera3D camera = new Camera3D();
		camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
		camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
		camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
		camera.fovy = 45.0f;                                    // Camera field-of-view Y
		camera.projection_ = CAMERA_PERSPECTIVE;                 // Camera mode type

		SetCameraMode(camera, CAMERA_ORBITAL);

		Vector3 cubePosition = new Vector3(0.0f, 1.0f, 0.0f);
		Vector3 cubeSize = new Vector3(2.0f, 2.0f, 2.0f);

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second

		// Use the default font
		Font font = GetFontDefault();
		float fontSize = 8.0f;
		float fontSpacing = 0.5f;
		float lineSpacing = -1.0f;

		// Set the text (using markdown!)
		string text = "Hello ~~World~~ in 3D!";
		Vector3 tbox = new Vector3(0);
		int layers = 1;
		int quads = 0;
		float layerDistance = 0.01f;

		WaveTextConfig wcfg = new();
		wcfg.waveSpeed.X = wcfg.waveSpeed.Y = 3.0f; wcfg.waveSpeed.Z = 0.5f;
		wcfg.waveOffset.X = wcfg.waveOffset.Y = wcfg.waveOffset.Z = 0.35f;
		wcfg.waveRange.X = wcfg.waveRange.Y = wcfg.waveRange.Z = 0.45f;

		float time = 0.0f;

		// Setup a light and dark color
		Color light = MAROON;
		Color dark = RED;

		// Load the alpha discard shader
		Shader alphaDiscard = LoadShader(null, "resources/shaders/glsl330/alpha_discard.fs");

		// Array filled with multiple random colors (when multicolor mode is set)
		Color[] multi = new Color[TEXT_MAX_LAYERS];
		//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// Handle font files dropped
			if (IsFileDropped())
			{
				//int count = 0;
				//char** droppedFiles = GetDroppedFiles(&count);
				var droppedFiles = GetDroppedFiles();
				var count = droppedFiles.Length;

				// NOTE: We only support first ttf file dropped
				if (IsFileExtension(droppedFiles[0], ".ttf"))
				{
					UnloadFont(font);
					font = LoadFontEx(droppedFiles[0], (int)fontSize, (int*)0, 0);
				}
				else if (IsFileExtension(droppedFiles[0], ".fnt"))
				{
					UnloadFont(font);
					font = LoadFont(droppedFiles[0]);
					fontSize = font.baseSize;
				}
				ClearDroppedFiles();
			}

			// Handle Events
			if (IsKeyPressed(KEY_F1)) SHOW_LETTER_BOUNDRY = !SHOW_LETTER_BOUNDRY;
			if (IsKeyPressed(KEY_F2)) SHOW_TEXT_BOUNDRY = !SHOW_TEXT_BOUNDRY;
			if (IsKeyPressed(KEY_F3))
			{
				// Handle camera change
				spin = !spin;
				// we need to reset the camera when changing modes
				camera = new Camera3D();
				camera.target = new Vector3(0.0f, 0.0f, 0.0f);          // Camera looking at point
				camera.up = new Vector3(0.0f, 1.0f, 0.0f);              // Camera up vector (rotation towards target)
				camera.fovy = 45.0f;                                    // Camera field-of-view Y
				camera.projection_ = CAMERA_PERSPECTIVE;                 // Camera mode type

				if (spin)
				{
					camera.position = new Vector3(-10.0f, 15.0f, -10.0f);   // Camera position
					SetCameraMode(camera, CAMERA_ORBITAL);
				}
				else
				{
					camera.position = new Vector3(10.0f, 10.0f, -10.0f);   // Camera position
					SetCameraMode(camera, CAMERA_FREE);
				}
			}

			// Handle clicking the cube
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT))
			{
				Ray ray = GetMouseRay(GetMousePosition(), camera);

				// Check collision between ray and box
				RayCollision collision = GetRayCollisionBox(ray,
								new BoundingBox(new Vector3(cubePosition.X - cubeSize.X / 2, cubePosition.Y - cubeSize.Y / 2, cubePosition.Z - cubeSize.Z / 2),
											  new Vector3(cubePosition.X + cubeSize.X / 2, cubePosition.Y + cubeSize.Y / 2, cubePosition.Z + cubeSize.Z / 2)));
				if (collision.hit)
				{
					// Generate new random colors
					light = GenerateRandomColor(0.5f, 0.78f);
					dark = GenerateRandomColor(0.4f, 0.58f);
				}
			}

			// Handle text layers changes
			if (IsKeyPressed(KEY_HOME)) { if (layers > 1) --layers; }
			else if (IsKeyPressed(KEY_END)) { if (layers < TEXT_MAX_LAYERS) ++layers; }

			// Handle text changes
			if (IsKeyPressed(KEY_LEFT)) fontSize -= 0.5f;
			else if (IsKeyPressed(KEY_RIGHT)) fontSize += 0.5f;
			else if (IsKeyPressed(KEY_UP)) fontSpacing -= 0.1f;
			else if (IsKeyPressed(KEY_DOWN)) fontSpacing += 0.1f;
			else if (IsKeyPressed(KEY_PAGE_UP)) lineSpacing -= 0.1f;
			else if (IsKeyPressed(KEY_PAGE_DOWN)) lineSpacing += 0.1f;
			else if (IsKeyDown(KEY_INSERT)) layerDistance -= 0.001f;
			else if (IsKeyDown(KEY_DELETE)) layerDistance += 0.001f;
			else if (IsKeyPressed(KEY_TAB))
			{
				multicolor = !multicolor;   // Enable /disable multicolor mode

				if (multicolor)
				{
					// Fill color array with random colors
					for (int i = 0; i < TEXT_MAX_LAYERS; ++i)
					{
						multi[i] = GenerateRandomColor(0.5f, 0.8f);
						multi[i].a = (byte)GetRandomValue(0, 255);
					}
				}
			}

			// Handle text input
			int ch = GetCharPressed();
			if (IsKeyPressed(KEY_BACKSPACE))
			{
				//// Remove last char
				//int len = TextLength(text);
				//if (len > 0) text[len - 1] = '\0';
				text = text.Substring(0, text.Length - 1);
			}
			else if (IsKeyPressed(KEY_ENTER))
			{
				//// handle newline
				//int len = TextLength(text);
				//if (len < sizeof(text) - 1)
				//{
				//	text[len] = '\n';
				//	text[len + 1] = '\0';
				//}
				text += "\n";
			}
			else if (ch == 0)
			{
				//do nothing				
			}
			else
			{
				//// append only printable chars
				//int len = TextLength(text);
				//if (len < sizeof(text) - 1)
				//{
				//	text[len] = ch;
				//	text[len + 1] = '\0';
				//}
				text += (char)ch;
			}

			// Measure 3D text so we can center it
			tbox = MeasureTextWave3D(font, text, fontSize, fontSpacing, lineSpacing);

			UpdateCamera(&camera);          // Update camera
			quads = 0;                      // Reset quad counter
			time += GetFrameTime();         // Update timer needed by `DrawTextWave3D()`
											//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			BeginMode3D(camera);
			DrawCubeV(cubePosition, cubeSize, dark);
			DrawCubeWires(cubePosition, 2.1f, 2.1f, 2.1f, light);

			DrawGrid(10, 2.0f);

			// Use a shader to handle the depth buffer issue with transparent textures
			// NOTE: more info at https://bedroomcoders.co.uk/raylib-billboards-advanced-use/
			BeginShaderMode(alphaDiscard);

			// Draw the 3D text above the red cube
			rlPushMatrix();
			rlRotatef(90.0f, 1.0f, 0.0f, 0.0f);
			rlRotatef(90.0f, 0.0f, 0.0f, -1.0f);

			for (int i = 0; i < layers; ++i)
			{
				Color clr = light;
				if (multicolor) clr = multi[i];
				DrawTextWave3D(font, text, new Vector3(-tbox.X / 2.0f, layerDistance * i, -4.5f), fontSize, fontSpacing, lineSpacing, true, &wcfg, time, clr);
			}

			// Draw the text boundry if set
			if (SHOW_TEXT_BOUNDRY) DrawCubeWiresV(new Vector3(0.0f, 0.0f, -4.5f + tbox.Z / 2), tbox, dark);
			rlPopMatrix();

			// Don't draw the letter boundries for the 3D text below
			bool slb = SHOW_LETTER_BOUNDRY;
			SHOW_LETTER_BOUNDRY = false;

			// Draw 3D options (use default font)
			//-------------------------------------------------------------------------
			rlPushMatrix();
			rlRotatef(180.0f, 0.0f, 1.0f, 0.0f);
			string opt = TextFormat("< SIZE: %2.1f >", fontSize);
			quads += TextLength(opt);
			Vector3 m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			Vector3 pos = new Vector3(-m.X / 2.0f, 0.01f, 2.0f);
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
			pos.Z += 0.5f + m.Z;

			opt = (string)TextFormat("< SPACING: %2.1f >", fontSpacing);
			quads += TextLength(opt);
			m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
			pos.Z += 0.5f + m.Z;

			opt = (string)TextFormat("< LINE: %2.1f >", lineSpacing);
			quads += TextLength(opt);
			m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, BLUE);
			pos.Z += 1.0f + m.Z;

			opt = (string)TextFormat("< LBOX: %3s >", slb ? "ON" : "OFF");
			quads += TextLength(opt);
			m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
			pos.Z += 0.5f + m.Z;

			opt = (string)TextFormat("< TBOX: %3s >", SHOW_TEXT_BOUNDRY ? "ON" : "OFF");
			quads += TextLength(opt);
			m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, RED);
			pos.Z += 0.5f + m.Z;

			opt = (string)TextFormat("< LAYER DISTANCE: %.3f >", layerDistance);
			quads += TextLength(opt);
			m = MeasureText3D(GetFontDefault(), opt, 8.0f, 1.0f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 8.0f, 1.0f, 0.0f, false, DARKPURPLE);
			rlPopMatrix();
			//-------------------------------------------------------------------------

			// Draw 3D info text (use default font)
			//-------------------------------------------------------------------------
			opt = "All the text displayed here is in 3D";
			quads += 36;
			m = MeasureText3D(GetFontDefault(), opt, 10.0f, 0.5f, 0.0f);
			pos = new Vector3(-m.X / 2.0f, 0.01f, 2.0f);
			DrawText3D(GetFontDefault(), opt, pos, 10.0f, 0.5f, 0.0f, false, DARKBLUE);
			pos.Z += 1.5f + m.Z;

			opt = "press [Left]/[Right] to change the font size";
			quads += 44;
			m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
			pos.Z += 0.5f + m.Z;

			opt = "press [Up]/[Down] to change the font spacing";
			quads += 44;
			m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
			pos.Z += 0.5f + m.Z;

			opt = "press [PgUp]/[PgDown] to change the line spacing";
			quads += 48;
			m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
			pos.Z += 0.5f + m.Z;

			opt = "press [F1] to toggle the letter boundry";
			quads += 39;
			m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
			pos.Z += 0.5f + m.Z;

			opt = "press [F2] to toggle the text boundry";
			quads += 37;
			m = MeasureText3D(GetFontDefault(), opt, 6.0f, 0.5f, 0.0f);
			pos.X = -m.X / 2.0f;
			DrawText3D(GetFontDefault(), opt, pos, 6.0f, 0.5f, 0.0f, false, DARKBLUE);
			//-------------------------------------------------------------------------

			SHOW_LETTER_BOUNDRY = slb;
			EndShaderMode();

			EndMode3D();

			// Draw 2D info text & stats
			//-------------------------------------------------------------------------
			DrawText("Drag & drop a font file to change the font!\nType something, see what happens!\n\n Press [F3] to toggle the camera", 10, 35, 10, BLACK);

			quads += TextLength(text) * 2 * layers;
			string tmp = TextFormat("%2i layer(s) | %s camera | %4i quads (%4i verts)", layers, spin ? "ORBITAL" : "FREE", quads, quads * 4);
			int width = MeasureText(tmp, 10);
			DrawText(tmp, screenWidth - 20 - width, 10, 10, DARKGREEN);

			tmp = "[Home]/[End] to add/remove 3D text layers";
			width = MeasureText(tmp, 10);
			DrawText(tmp, screenWidth - 20 - width, 25, 10, DARKGRAY);

			tmp = "[Insert]/[Delete] to increase/decrease distance between layers";
			width = MeasureText(tmp, 10);
			DrawText(tmp, screenWidth - 20 - width, 40, 10, DARKGRAY);

			tmp = "click the [CUBE] for a random color";
			width = MeasureText(tmp, 10);
			DrawText(tmp, screenWidth - 20 - width, 55, 10, DARKGRAY);

			tmp = "[Tab] to toggle multicolor mode";
			width = MeasureText(tmp, 10);
			DrawText(tmp, screenWidth - 20 - width, 70, 10, DARKGRAY);
			//-------------------------------------------------------------------------

			DrawFPS(10, 10);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}


		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadFont(font);
		CloseWindow();        // Close window and OpenGL context
							  //--------------------------------------------------------------------------------------

		return 0;
	}



	//--------------------------------------------------------------------------------------
	// Module Functions Definitions
	//--------------------------------------------------------------------------------------
	// Draw codepoint at specified position in 3D space
	static void DrawTextCodepoint3D(Font font, int codepoint, Vector3 position, float fontSize, bool backface, Color tint)
	{
		// Character index position in sprite font
		// NOTE: In case a codepoint is not available in the font, index returned points to '?'
		int index = GetGlyphIndex(font, codepoint);
		float scale = fontSize / (float)font.baseSize;

		// Character destination rectangle on screen
		// NOTE: We consider charsPadding on drawing
		position.X += (float)(font.glyphs[index].offsetX - font.glyphPadding) / (float)font.baseSize * scale;
		position.Z += (float)(font.glyphs[index].offsetY - font.glyphPadding) / (float)font.baseSize * scale;

		// Character source rectangle from font texture atlas
		// NOTE: We consider chars padding when drawing, it could be required for outline/glow shader effects
		Rectangle srcRec = new(font.recs[index].X - (float)font.glyphPadding, font.recs[index].Y - (float)font.glyphPadding,
							 font.recs[index].width + 2.0f * font.glyphPadding, font.recs[index].height + 2.0f * font.glyphPadding);

		float width = (float)(font.recs[index].width + 2.0f * font.glyphPadding) / (float)font.baseSize * scale;
		float height = (float)(font.recs[index].height + 2.0f * font.glyphPadding) / (float)font.baseSize * scale;

		if (font.texture.id > 0)
		{
			const float x = 0.0f;
			const float y = 0.0f;
			const float z = 0.0f;

			// normalized texture coordinates of the glyph inside the font texture (0.0f -> 1.0f)
			float tx = srcRec.X / font.texture.width;
			float ty = srcRec.Y / font.texture.height;
			float tw = (srcRec.X + srcRec.width) / font.texture.width;
			float th = (srcRec.Y + srcRec.height) / font.texture.height;

			if (SHOW_LETTER_BOUNDRY) DrawCubeWiresV(new Vector3(position.X + width / 2, position.Y, position.Z + height / 2), new Vector3(width, LETTER_BOUNDRY_SIZE, height), LETTER_BOUNDRY_COLOR);

			rlCheckRenderBatchLimit(4 + (4 * (backface ? 1 : 0)));
			rlSetTexture(font.texture.id);

			rlPushMatrix();
			rlTranslatef(position.X, position.Y, position.Z);

			rlBegin(RL_QUADS);
			rlColor4ub(tint.r, tint.g, tint.b, tint.a);

			// Front Face
			rlNormal3f(0.0f, 1.0f, 0.0f);                                   // Normal Pointing Up
			rlTexCoord2f(tx, ty); rlVertex3f(x, y, z);              // Top Left Of The Texture and Quad
			rlTexCoord2f(tx, th); rlVertex3f(x, y, z + height);     // Bottom Left Of The Texture and Quad
			rlTexCoord2f(tw, th); rlVertex3f(x + width, y, z + height);     // Bottom Right Of The Texture and Quad
			rlTexCoord2f(tw, ty); rlVertex3f(x + width, y, z);              // Top Right Of The Texture and Quad

			if (backface)
			{
				// Back Face
				rlNormal3f(0.0f, -1.0f, 0.0f);                              // Normal Pointing Down
				rlTexCoord2f(tx, ty); rlVertex3f(x, y, z);          // Top Right Of The Texture and Quad
				rlTexCoord2f(tw, ty); rlVertex3f(x + width, y, z);          // Top Left Of The Texture and Quad
				rlTexCoord2f(tw, th); rlVertex3f(x + width, y, z + height); // Bottom Left Of The Texture and Quad
				rlTexCoord2f(tx, th); rlVertex3f(x, y, z + height); // Bottom Right Of The Texture and Quad
			}
			rlEnd();
			rlPopMatrix();

			rlSetTexture(0);
		}
	}

	static void DrawText3D(Font font, string text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, Color tint)
	{
		int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

		float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
		float textOffsetX = 0.0f;               // Offset X to next character to draw

		float scale = fontSize / (float)font.baseSize;

		for (int i = 0; i < length;)
		{
			// Get next codepoint from byte string and glyph index in font
			int codepointByteCount = 0;
			int codepoint = GetCodepoint(text[i], out codepointByteCount);

			int index = GetGlyphIndex(font, codepoint);

			// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol moving one byte
			if (codepoint == 0x3f) codepointByteCount = 1;

			if (codepoint == '\n')
			{
				// NOTE: Fixed line spacing of 1.5 line-height
				// TODO: Support custom line spacing defined by user
				textOffsetY += scale + lineSpacing / (float)font.baseSize * scale;
				textOffsetX = 0.0f;
			}
			else
			{
				if ((codepoint != ' ') && (codepoint != '\t'))
				{
					DrawTextCodepoint3D(font, codepoint, new Vector3(position.X + textOffsetX, position.Y, position.Z + textOffsetY), fontSize, backface, tint);
				}

				if (font.glyphs[index].advanceX == 0) textOffsetX += (float)(font.recs[index].width + fontSpacing) / (float)font.baseSize * scale;
				else textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
			}

			i += codepointByteCount;   // Move text bytes counter to next codepoint
		}
	}



	static Vector3 MeasureText3D(Font font, string text, float fontSize, float fontSpacing, float lineSpacing)
	{
		int len = TextLength(text);
		int tempLen = 0;                // Used to count longer text line num chars
		int lenCounter = 0;

		float tempTextWidth = 0.0f;     // Used to count longer text line width

		float scale = fontSize / (float)font.baseSize;
		float textHeight = scale;
		float textWidth = 0.0f;

		int letter = 0;                 // Current character
		int index = 0;                  // Index position in sprite font

		for (int i = 0; i < len; i++)
		{
			lenCounter++;

			int next = 0;
			letter = GetCodepoint(text[i], out next);
			index = GetGlyphIndex(font, letter);

			// NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
			if (letter == 0x3f) next = 1;
			i += next - 1;

			if (letter != '\n')
			{
				if (font.glyphs[index].advanceX != 0) textWidth += (font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
				else textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / (float)font.baseSize * scale;
			}
			else
			{
				if (tempTextWidth < textWidth) tempTextWidth = textWidth;
				lenCounter = 0;
				textWidth = 0.0f;
				textHeight += scale + lineSpacing / (float)font.baseSize * scale;
			}

			if (tempLen < lenCounter) tempLen = lenCounter;
		}

		if (tempTextWidth < textWidth) tempTextWidth = textWidth;

		Vector3 vec = new Vector3(0);
		vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / (float)font.baseSize * scale); // Adds chars spacing to measure
		vec.Y = 0.25f;
		vec.Z = textHeight;

		return vec;
	}


	static void DrawTextWave3D(Font font, string text, Vector3 position, float fontSize, float fontSpacing, float lineSpacing, bool backface, WaveTextConfig* config, float time, Color tint)
	{
		int length = TextLength(text);          // Total length in bytes of the text, scanned by codepoints in loop

		float textOffsetY = 0.0f;               // Offset between lines (on line break '\n')
		float textOffsetX = 0.0f;               // Offset X to next character to draw

		float scale = fontSize / (float)font.baseSize;

		bool wave = false;

		for (int i = 0, k = 0; i < length; ++k)
		{
			// Get next codepoint from byte string and glyph index in font
			int codepointByteCount = 0;
			int codepoint = GetCodepoint(text[i], out codepointByteCount);
			int index = GetGlyphIndex(font, codepoint);

			// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol moving one byte
			if (codepoint == 0x3f) codepointByteCount = 1;

			if (codepoint == '\n')
			{
				// NOTE: Fixed line spacing of 1.5 line-height
				// TODO: Support custom line spacing defined by user
				textOffsetY += scale + lineSpacing / (float)font.baseSize * scale;
				textOffsetX = 0.0f;
				k = 0;
			}
			else if (codepoint == '~')
			{
				if (GetCodepoint(text[i + 1], out codepointByteCount) == '~')
				{
					codepointByteCount += 1;
					wave = !wave;
				}
			}
			else
			{
				if ((codepoint != ' ') && (codepoint != '\t'))
				{
					Vector3 pos = position;
					if (wave) // Apply the wave effect
					{
						pos.X += MathF.Sin(time * config->waveSpeed.X - k * config->waveOffset.X) * config->waveRange.X;
						pos.Y += MathF.Sin(time * config->waveSpeed.Y - k * config->waveOffset.Y) * config->waveRange.Y;
						pos.Z += MathF.Sin(time * config->waveSpeed.Z - k * config->waveOffset.Z) * config->waveRange.Z;
					}

					DrawTextCodepoint3D(font, codepoint, new Vector3(pos.X + textOffsetX, pos.Y, pos.Z + textOffsetY), fontSize, backface, tint);
				}

				if (font.glyphs[index].advanceX == 0) textOffsetX += (float)(font.recs[index].width + fontSpacing) / (float)font.baseSize * scale;
				else textOffsetX += (float)(font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
			}

			i += codepointByteCount;   // Move text bytes counter to next codepoint
		}
	}

	static Vector3 MeasureTextWave3D(Font font, string text, float fontSize, float fontSpacing, float lineSpacing)
	{
		int len = TextLength(text);
		int tempLen = 0;                // Used to count longer text line num chars
		int lenCounter = 0;

		float tempTextWidth = 0.0f;     // Used to count longer text line width

		float scale = fontSize / (float)font.baseSize;
		float textHeight = scale;
		float textWidth = 0.0f;

		int letter = 0;                 // Current character
		int index = 0;                  // Index position in sprite font

		for (int i = 0; i < len; i++)
		{
			lenCounter++;

			int next = 0;
			letter = GetCodepoint(text[i], out next);
			index = GetGlyphIndex(font, letter);

			// NOTE: normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol so to not skip any we set next = 1
			if (letter == 0x3f) next = 1;
			i += next - 1;

			if (letter != '\n')
			{
				if (letter == '~' && GetCodepoint(text[i + 1], out next) == '~')
				{
					i++;
				}
				else
				{
					if (font.glyphs[index].advanceX != 0) textWidth += (font.glyphs[index].advanceX + fontSpacing) / (float)font.baseSize * scale;
					else textWidth += (font.recs[index].width + font.glyphs[index].offsetX) / (float)font.baseSize * scale;
				}
			}
			else
			{
				if (tempTextWidth < textWidth) tempTextWidth = textWidth;
				lenCounter = 0;
				textWidth = 0.0f;
				textHeight += scale + lineSpacing / (float)font.baseSize * scale;
			}

			if (tempLen < lenCounter) tempLen = lenCounter;
		}

		if (tempTextWidth < textWidth) tempTextWidth = textWidth;

		Vector3 vec = new Vector3(0);
		vec.X = tempTextWidth + (float)((tempLen - 1) * fontSpacing / (float)font.baseSize * scale); // Adds chars spacing to measure
		vec.Y = 0.25f;
		vec.Z = textHeight;

		return vec;
	}

	static Color GenerateRandomColor(float s, float v)
	{
		const float Phi = 0.618033988749895f; // Golden ratio conjugate
		float h = GetRandomValue(0, 360);
		h = h + h * Phi % 360.0f;
		return ColorFromHSV(h, s, v);
	}
}



/*******************************************************************************************
*
*   raylib [text] example - Font filters
*
*   After font loading, font texture atlas filter could be configured for a softer
*   display of the font when scaling it to different sizes, that way, it's not required
*   to generate multiple fonts at multiple sizes (as long as the scaling is not very different)
*
*   This example has been created using raylib 1.3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class FontFilters
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - font filters");

		string msg = "Loaded Font";

		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

		// TTF Font loading with custom generation parameters
		Font font = LoadFontEx("resources/KAISG.ttf", 96, (int*)0, 0);

		// Generate mipmap levels to use trilinear filtering
		// NOTE: On 2D drawing it won't be noticeable, it looks like FILTER_BILINEAR
		GenTextureMipmaps(&font.texture);

		float fontSize = (float)font.baseSize;
		Vector2 fontPosition = new Vector2(40.0f, screenHeight / 2.0f - 80.0f);
		Vector2 textSize = new Vector2(0.0f, 0.0f);

		// Setup texture scaling filter
		SetTextureFilter(font.texture, TEXTURE_FILTER_POINT);
		int currentFontFilter = 0;      // TEXTURE_FILTER_POINT

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			fontSize += GetMouseWheelMove() * 4.0f;

			// Choose font texture filter method
			if (IsKeyPressed(KEY_ONE))
			{
				SetTextureFilter(font.texture, TEXTURE_FILTER_POINT);
				currentFontFilter = 0;
			}
			else if (IsKeyPressed(KEY_TWO))
			{
				SetTextureFilter(font.texture, TEXTURE_FILTER_BILINEAR);
				currentFontFilter = 1;
			}
			else if (IsKeyPressed(KEY_THREE))
			{
				// NOTE: Trilinear filter won't be noticed on 2D drawing
				SetTextureFilter(font.texture, TEXTURE_FILTER_TRILINEAR);
				currentFontFilter = 2;
			}

			textSize = MeasureTextEx(font, msg, fontSize, 0);

			if (IsKeyDown(KEY_LEFT)) fontPosition.X -= 10;
			else if (IsKeyDown(KEY_RIGHT)) fontPosition.X += 10;

			// Load a dropped TTF file dynamically (at current fontSize)
			if (IsFileDropped())
			{
				//int count = 0;
				//char** droppedFiles = GetDroppedFiles(&count);
				var droppedFiles = GetDroppedFiles();
				var count = droppedFiles.Length;

				// NOTE: We only support first ttf file dropped
				if (IsFileExtension(droppedFiles[0], ".ttf"))
				{
					UnloadFont(font);
					font = LoadFontEx(droppedFiles[0], (int)fontSize, (int*)0, 0);
					ClearDroppedFiles();
				}
			}
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawText("Use mouse wheel to change font size", 20, 20, 10, GRAY);
			DrawText("Use KEY_RIGHT and KEY_LEFT to move text", 20, 40, 10, GRAY);
			DrawText("Use 1, 2, 3 to change texture filter", 20, 60, 10, GRAY);
			DrawText("Drop a new TTF font for dynamic loading", 20, 80, 10, DARKGRAY);

			DrawTextEx(font, msg, fontPosition, fontSize, 0, BLACK);

			// TODO: It seems texSize measurement is not accurate due to chars offsets...
			//DrawRectangleLines(fontPosition.X, fontPosition.Y, textSize.X, textSize.Y, RED);

			DrawRectangle(0, screenHeight - 80, screenWidth, 80, LIGHTGRAY);
			DrawText(TextFormat("Font size: %02.02f", fontSize), 20, screenHeight - 50, 10, DARKGRAY);
			DrawText(TextFormat("Text size: [%02.02f, %02.02f]", textSize.X, textSize.Y), 20, screenHeight - 30, 10, DARKGRAY);
			DrawText("CURRENT TEXTURE FILTER:", 250, 400, 20, GRAY);

			if (currentFontFilter == 0) DrawText("POINT", 570, 400, 20, BLACK);
			else if (currentFontFilter == 1) DrawText("BILINEAR", 570, 400, 20, BLACK);
			else if (currentFontFilter == 2) DrawText("TRILINEAR", 570, 400, 20, BLACK);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		ClearDroppedFiles();        // Clear internal buffers

		UnloadFont(font);           // Font unloading

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}
}

/*******************************************************************************************
*
*   raylib [text] example - Font loading
*
*   raylib can load fonts from multiple file formats:
*
*     - TTF/OTF > Sprite font atlas is generated on loading, user can configure
*                 some of the generation parameters (size, characters to include)
*     - BMFonts > Angel code font fileformat, sprite font image must be provided
*                 together with the .fnt file, font generation cna not be configured
*     - XNA Spritefont > Sprite font image, following XNA Spritefont conventions,
*                 Characters in image must follow some spacing and order rules
*
*   This example has been created using raylib 2.6 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016-2019 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class FontLoading
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - font loading");

		// Define characters to draw
		// NOTE: raylib supports UTF-8 encoding, following list is actually codified as UTF8 internally
		string msg = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHI\nJKLMNOPQRSTUVWXYZ[]^_`abcdefghijklmn\nopqrstuvwxyz{|}~¿ÀÁÂÃÄÅÆÇÈÉÊËÌÍÎÏÐÑÒÓ\nÔÕÖ×ØÙÚÛÜÝÞßàáâãäåæçèéêëìíîïðñòóôõö÷\nøùúûüýþÿ";

		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

		// BMFont (AngelCode) : Font data and image atlas have been generated using external program
		Font fontBm = LoadFont("resources/pixantiqua.fnt");

		// TTF font : Font data and atlas are generated directly from TTF
		// NOTE: We define a font base size of 32 pixels tall and up-to 250 characters
		Font fontTtf = LoadFontEx("resources/pixantiqua.ttf", 32, (int*)0, 250);

		bool useTtf = false;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			if (IsKeyDown(KEY_SPACE)) useTtf = true;
			else useTtf = false;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawText("Hold SPACE to use TTF generated font", 20, 20, 20, LIGHTGRAY);

			if (!useTtf)
			{
				DrawTextEx(fontBm, msg, new Vector2(20.0f, 100.0f), (float)fontBm.baseSize, 2, MAROON);
				DrawText("Using BMFont (Angelcode) imported", 20, GetScreenHeight() - 30, 20, GRAY);
			}
			else
			{
				DrawTextEx(fontTtf, msg, new Vector2(20.0f, 100.0f), (float)fontTtf.baseSize, 2, LIME);
				DrawText("Using TTF font generated", 20, GetScreenHeight() - 30, 20, GRAY);
			}

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadFont(fontBm);     // AngelCode Font unloading
		UnloadFont(fontTtf);    // TTF Font unloading

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}
}


/*******************************************************************************************
*
*   raylib [text] example - TTF loading and usage
*
*   This example has been created using raylib 1.3.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2015 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class SdfFonts
{

#if PLATFORM_DESKTOP
	const int GLSL_VERSION = 330;
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
	const int GLSL_VERSION = 100;
#endif

	// #include <stdlib.h>

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - SDF fonts");

		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)

		string msg = "Signed Distance Fields";

		// Loading file to memory
		uint fileSize = 0;
		byte* fileData = LoadFileData("resources/anonymous_pro_bold.ttf", out fileSize);

		// Default font generation from TTF font
		Font fontDefault = new Font();
		fontDefault.baseSize = 16;
		fontDefault.glyphCount = 95;

		// Loading font data from memory data
		// Parameters > font size: 16, no glyphs array provided (0), glyphs count: 95 (autogenerate chars array)
		fontDefault.glyphs = LoadFontData(fileData, (int)fileSize, 16, (int*)0, 95, FONT_DEFAULT);
		// Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 4 px, pack method: 0 (default)
		Image atlas = GenImageFontAtlas(fontDefault.glyphs, &fontDefault.recs, 95, 16, 4, 0);
		fontDefault.texture = LoadTextureFromImage(atlas);
		UnloadImage(atlas);

		// SDF font generation from TTF font
		Font fontSDF = new Font();
		fontSDF.baseSize = 16;
		fontSDF.glyphCount = 95;
		// Parameters > font size: 16, no glyphs array provided (0), glyphs count: 0 (defaults to 95)
		fontSDF.glyphs = LoadFontData(fileData, (int)fileSize, 16, (int*)0, 0, FONT_SDF);
		// Parameters > glyphs count: 95, font size: 16, glyphs padding in image: 0 px, pack method: 1 (Skyline algorythm)
		atlas = GenImageFontAtlas(fontSDF.glyphs, &fontSDF.recs, 95, 16, 0, 1);
		fontSDF.texture = LoadTextureFromImage(atlas);
		UnloadImage(atlas);

		UnloadFileData(fileData);      // Free memory from loaded file

		// Load SDF required shader (we use default vertex shader)
		Shader shader = LoadShader(null, TextFormat("resources/shaders/glsl%i/sdf.fs", GLSL_VERSION));
		SetTextureFilter(fontSDF.texture, TEXTURE_FILTER_BILINEAR);    // Required for SDF font

		Vector2 fontPosition = new Vector2(40, screenHeight / 2.0f - 50);
		Vector2 textSize = new Vector2(0.0f, 0.0f);
		float fontSize = 16.0f;
		int currentFont = 0;            // 0 - fontDefault, 1 - fontSDF

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			fontSize += GetMouseWheelMove() * 8.0f;

			if (fontSize < 6) fontSize = 6;

			if (IsKeyDown(KEY_SPACE)) currentFont = 1;
			else currentFont = 0;

			if (currentFont == 0) textSize = MeasureTextEx(fontDefault, msg, fontSize, 0);
			else textSize = MeasureTextEx(fontSDF, msg, fontSize, 0);

			fontPosition.X = GetScreenWidth() / 2 - textSize.X / 2;
			fontPosition.Y = GetScreenHeight() / 2 - textSize.Y / 2 + 80;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			if (currentFont == 1)
			{
				// NOTE: SDF fonts require a custom SDf shader to compute fragment color
				BeginShaderMode(shader);    // Activate SDF font shader
				DrawTextEx(fontSDF, msg, fontPosition, fontSize, 0, BLACK);
				EndShaderMode();            // Activate our default shader for next drawings

				DrawTexture(fontSDF.texture, 10, 10, BLACK);
			}
			else
			{
				DrawTextEx(fontDefault, msg, fontPosition, fontSize, 0, BLACK);
				DrawTexture(fontDefault.texture, 10, 10, BLACK);
			}

			if (currentFont == 1) DrawText("SDF!", 320, 20, 80, RED);
			else DrawText("default font", 315, 40, 30, GRAY);

			DrawText("FONT SIZE: 16.0", GetScreenWidth() - 240, 20, 20, DARKGRAY);
			DrawText(TextFormat("RENDER SIZE: %02.02f", fontSize), GetScreenWidth() - 240, 50, 20, DARKGRAY);
			DrawText("Use MOUSE WHEEL to SCALE TEXT!", GetScreenWidth() - 240, 90, 10, DARKGRAY);

			DrawText("HOLD SPACE to USE SDF FONT VERSION!", 340, GetScreenHeight() - 30, 20, MAROON);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadFont(fontDefault);    // Default font unloading
		UnloadFont(fontSDF);        // SDF font unloading

		UnloadShader(shader);       // Unload SDF shader

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}

}

/*******************************************************************************************
*
*   raylib [text] example - Sprite font loading
*
*   Loaded sprite fonts have been generated following XNA SpriteFont conventions:
*     - Characters must be ordered starting with character 32 (Space)
*     - Every character must be contained within the same Rectangle height
*     - Every character and every line must be separated by the same distance (margin/padding)
*     - Rectangles must be defined by a MAGENTA color background
*
*   If following this constraints, a font can be provided just by an image,
*   this is quite handy to avoid additional information files (like BMFonts use).
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class SpriteFontLoading
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - sprite font loading");

		string msg1 = "THIS IS A custom SPRITE FONT...";
		string msg2 = "...and this is ANOTHER CUSTOM font...";
		string msg3 = "...and a THIRD one! GREAT! :D";

		// NOTE: Textures/Fonts MUST be loaded after Window initialization (OpenGL context is required)
		Font font1 = LoadFont("resources/custom_mecha.png");          // Font loading
		Font font2 = LoadFont("resources/custom_alagard.png");        // Font loading
		Font font3 = LoadFont("resources/custom_jupiter_crash.png");  // Font loading

		Vector2 fontPosition1 = new Vector2(screenWidth / 2.0f - MeasureTextEx(font1, msg1, (float)font1.baseSize, -3).X / 2,
							  screenHeight / 2.0f - font1.baseSize / 2.0f - 80.0f);

		Vector2 fontPosition2 = new Vector2(screenWidth / 2.0f - MeasureTextEx(font2, msg2, (float)font2.baseSize, -2.0f).X / 2.0f,
							  screenHeight / 2.0f - font2.baseSize / 2.0f - 10.0f);

		Vector2 fontPosition3 = new Vector2(screenWidth / 2.0f - MeasureTextEx(font3, msg3, (float)font3.baseSize, 2.0f).X / 2.0f,
							  screenHeight / 2.0f - font3.baseSize / 2.0f + 50.0f);

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// TODO: Update variables here...
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawTextEx(font1, msg1, fontPosition1, (float)font1.baseSize, -3, WHITE);
			DrawTextEx(font2, msg2, fontPosition2, (float)font2.baseSize, -2, WHITE);
			DrawTextEx(font3, msg3, fontPosition3, (float)font3.baseSize, 2, WHITE);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadFont(font1);      // Font unloading
		UnloadFont(font2);      // Font unloading
		UnloadFont(font3);      // Font unloading

		CloseWindow();          // Close window and OpenGL context
								//--------------------------------------------------------------------------------------

		return 0;
	}
}

/*******************************************************************************************
*
*   raylib [text] example - Text formatting
*
*   This example has been created using raylib 1.1 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2014 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class TextFormatting
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - text formatting");

		int score = 100020;
		int hiscore = 200450;
		int lives = 5;

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

			DrawText(TextFormat("Score: %08i", score), 200, 80, 20, RED);

			DrawText(TextFormat("HiScore: %08i", hiscore), 200, 120, 20, GREEN);

			DrawText(TextFormat("Lives: %02i", lives), 200, 160, 40, BLUE);

			DrawText(TextFormat("Elapsed Time: %02.02f ms", GetFrameTime() * 1000), 200, 220, 20, BLACK);

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
*   raylib [text] example - Input Box
*
*   This example has been created using raylib 3.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class InputBox
{

	const int MAX_INPUT_CHARS = 9;

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - input box");

		//char name[MAX_INPUT_CHARS + 1] = "\0";      // NOTE: One extra space required for null terminator char '\0'
		string name = "";
		//int letterCount = 0;

		Rectangle textBox = new Rectangle(screenWidth / 2.0f - 100, 180, 225, 50);
		bool mouseOnText = false;

		int framesCounter = 0;

		SetTargetFPS(10);               // Set our game to run at 10 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			if (CheckCollisionPointRec(GetMousePosition(), textBox)) mouseOnText = true;
			else mouseOnText = false;

			if (mouseOnText)
			{
				// Set the window's cursor to the I-Beam
				SetMouseCursor(MOUSE_CURSOR_IBEAM);

				// Get char pressed (unicode character) on the queue
				int key = GetCharPressed();

				// Check if more characters have been pressed on the same frame
				while (key > 0)
				{
					// NOTE: Only allow keys in range [32..125]
					if ((key >= 32) && (key <= 125) && (name.Length < MAX_INPUT_CHARS))
					{
						//name[letterCount] = (char)key;
						//name[letterCount + 1] = '\0'; // Add null terminator at the end of the string.
						//letterCount++;
						name += (char)key;
					}

					key = GetCharPressed();  // Check next character in the queue
				}

				if (IsKeyPressed(KEY_BACKSPACE))
				{
					//letterCount--;
					//if (letterCount < 0) letterCount = 0;
					//name[letterCount] = '\0';
					name = name.Substring(0, name.Length - 1);
				}
			}
			else SetMouseCursor(MOUSE_CURSOR_DEFAULT);

			if (mouseOnText) framesCounter++;
			else framesCounter = 0;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawText("PLACE MOUSE OVER INPUT BOX!", 240, 140, 20, GRAY);

			DrawRectangleRec(textBox, LIGHTGRAY);
			if (mouseOnText) DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.width, (int)textBox.height, RED);
			else DrawRectangleLines((int)textBox.X, (int)textBox.Y, (int)textBox.width, (int)textBox.height, DARKGRAY);

			DrawText(name, (int)textBox.X + 5, (int)textBox.Y + 8, 40, MAROON);

			DrawText(TextFormat("INPUT CHARS: %i/%i", name.Length, MAX_INPUT_CHARS), 315, 250, 20, DARKGRAY);

			if (mouseOnText)
			{
				if (name.Length < MAX_INPUT_CHARS)
				{
					// Draw blinking underscore char
					if (((framesCounter / 20) % 2) == 0) DrawText("_", (int)textBox.X + 8 + MeasureText(name, 40), (int)textBox.Y + 12, 40, MAROON);
				}
				else DrawText("Press BACKSPACE to delete chars...", 230, 300, 20, GRAY);
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


	// Check if any key is pressed
	// NOTE: We limit keys check to keys between 32 (KEY_SPACE) and 126
	static bool IsAnyKeyPressed()
	{
		bool keyPressed = false;
		int key = GetKeyPressed();

		if ((key >= 32) && (key <= 126)) keyPressed = true;

		return keyPressed;
	}


}
/*******************************************************************************************
*
*   raylib [text] example - raylib font loading and usage
*
*   NOTE: raylib is distributed with some free to use fonts (even for commercial pourposes!)
*         To view details and credits for those fonts, check raylib license file
*
*   This example has been created using raylib 1.7 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2017 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class FontLoadingUsage
{

	const int MAX_FONTS = 8;

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - raylib fonts");

		// NOTE: Textures MUST be loaded after Window initialization (OpenGL context is required)
		Font[] fonts = new Font[MAX_FONTS];

		fonts[0] = LoadFont("resources/fonts/alagard.png");
		fonts[1] = LoadFont("resources/fonts/pixelplay.png");
		fonts[2] = LoadFont("resources/fonts/mecha.png");
		fonts[3] = LoadFont("resources/fonts/setback.png");
		fonts[4] = LoadFont("resources/fonts/romulus.png");
		fonts[5] = LoadFont("resources/fonts/pixantiqua.png");
		fonts[6] = LoadFont("resources/fonts/alpha_beta.png");
		fonts[7] = LoadFont("resources/fonts/jupiter_crash.png");

		string[] messages = new string[MAX_FONTS]{ "ALAGARD FONT designed by Hewett Tsoi",
								"PIXELPLAY FONT designed by Aleksander Shevchuk",
								"MECHA FONT designed by Captain Falcon",
								"SETBACK FONT designed by Brian Kent (AEnigma)",
								"ROMULUS FONT designed by Hewett Tsoi",
								"PIXANTIQUA FONT designed by Gerhard Grossmann",
								"ALPHA_BETA FONT designed by Brian Kent (AEnigma)",
								"JUPITER_CRASH FONT designed by Brian Kent (AEnigma)" };

		int[] spacings = new int[MAX_FONTS] { 2, 4, 8, 4, 3, 4, 4, 1 };

		Vector2[] positions = new Vector2[MAX_FONTS];

		for (int i = 0; i < MAX_FONTS; i++)
		{
			positions[i].X = screenWidth / 2.0f - MeasureTextEx(fonts[i], messages[i], fonts[i].baseSize * 2.0f, (float)spacings[i]).X / 2.0f;
			positions[i].Y = 60.0f + fonts[i].baseSize + 45.0f * i;
		}

		// Small Y position corrections
		positions[3].Y += 8;
		positions[4].Y += 2;
		positions[7].Y -= 8;

		Color[] colors = new Color[MAX_FONTS] { MAROON, ORANGE, DARKGREEN, DARKBLUE, DARKPURPLE, LIME, GOLD, RED };

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

			DrawText("free fonts included with raylib", 250, 20, 20, DARKGRAY);
			DrawLine(220, 50, 590, 50, DARKGRAY);

			for (int i = 0; i < MAX_FONTS; i++)
			{
				DrawTextEx(fonts[i], messages[i], positions[i], fonts[i].baseSize * 2.0f, (float)spacings[i], colors[i]);
			}

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------

		// Fonts unloading
		for (int i = 0; i < MAX_FONTS; i++) UnloadFont(fonts[i]);

		CloseWindow();                 // Close window and OpenGL context
									   //--------------------------------------------------------------------------------------

		return 0;
	}
}


/*******************************************************************************************
*
*   raylib [text] example - Draw text inside a rectangle
*
*   This example has been created using raylib 2.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2018 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class DrawTextInsideRectangle
{

	// Main entry point
	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - draw text inside a rectangle");

		string text = "Text cannot escape\tthis container\t...word wrap also works when active so here's " +
			"a long text for testing.\n\nLorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod " +
			"tempor incididunt ut labore et dolore magna aliqua. Nec ullamcorper sit amet risus nullam eget felis eget.";

		bool resizing = false;
		bool wordWrap = true;

		Rectangle container = new Rectangle(25.0f, 25.0f, screenWidth - 50.0f, screenHeight - 250.0f);
		Rectangle resizer = new Rectangle(container.X + container.width - 17, container.Y + container.height - 17, 14, 14);

		// Minimum width and heigh for the container rectangle
		const float minWidth = 60;
		const float minHeight = 60;
		const float maxWidth = screenWidth - 50.0f;
		const float maxHeight = screenHeight - 160.0f;

		Vector2 lastMouse = new Vector2(0.0f, 0.0f); // Stores last mouse coordinates
		Color borderColor = MAROON;         // Container border color
		Font font = GetFontDefault();       // Get default system font

		SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second
											//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())        // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			if (IsKeyPressed(KEY_SPACE)) wordWrap = !wordWrap;

			Vector2 mouse = GetMousePosition();

			// Check if the mouse is inside the container and toggle border color
			if (CheckCollisionPointRec(mouse, container)) borderColor = Fade(MAROON, 0.4f);
			else if (!resizing) borderColor = MAROON;

			// Container resizing logic
			if (resizing)
			{
				if (IsMouseButtonReleased(MOUSE_BUTTON_LEFT)) resizing = false;

				float width = container.width + (mouse.X - lastMouse.X);
				container.width = (width > minWidth) ? ((width < maxWidth) ? width : maxWidth) : minWidth;

				float height = container.height + (mouse.Y - lastMouse.Y);
				container.height = (height > minHeight) ? ((height < maxHeight) ? height : maxHeight) : minHeight;
			}
			else
			{
				// Check if we're resizing
				if (IsMouseButtonDown(MOUSE_BUTTON_LEFT) && CheckCollisionPointRec(mouse, resizer)) resizing = true;
			}

			// Move resizer rectangle properly
			resizer.X = container.X + container.width - 17;
			resizer.Y = container.Y + container.height - 17;

			lastMouse = mouse; // Update mouse
							   //----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawRectangleLinesEx(container, 3, borderColor);    // Draw container border

			// Draw text in container (add some padding)
			DrawTextBoxed(font, text, new Rectangle(container.X + 4, container.Y + 4, container.width - 4, container.height - 4), 20.0f, 2.0f, wordWrap, GRAY);

			DrawRectangleRec(resizer, borderColor);             // Draw the resize box

			// Draw bottom info
			DrawRectangle(0, screenHeight - 54, screenWidth, 54, GRAY);
			DrawRectangleRec(new Rectangle(382.0f, screenHeight - 34.0f, 12.0f, 12.0f), MAROON);

			DrawText("Word Wrap: ", 313, screenHeight - 115, 20, BLACK);
			if (wordWrap) DrawText("ON", 447, screenHeight - 115, 20, RED);
			else DrawText("OFF", 447, screenHeight - 115, 20, BLACK);

			DrawText("Press [SPACE] to toggle word wrap", 218, screenHeight - 86, 20, GRAY);

			DrawText("Click hold & drag the    to resize the container", 155, screenHeight - 38, 20, RAYWHITE);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		CloseWindow();        // Close window and OpenGL context
							  //--------------------------------------------------------------------------------------

		return 0;
	}


	//--------------------------------------------------------------------------------------
	// Module functions definition
	//--------------------------------------------------------------------------------------

	// Draw text using font inside rectangle limits
	static void DrawTextBoxed(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint)
	{
		DrawTextBoxedSelectable(font, text, rec, fontSize, spacing, wordWrap, tint, 0, 0, WHITE, WHITE);
	}


	// Draw text using font inside rectangle limits with support for text selection
	static void DrawTextBoxedSelectable(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint)
	{
		int length = TextLength(text);  // Total length in bytes of the text, scanned by codepoints in loop

		float textOffsetY = 0;          // Offset between lines (on line break '\n')
		float textOffsetX = 0.0f;       // Offset X to next character to draw

		float scaleFactor = fontSize / (float)font.baseSize;     // Character rectangle scaling factor

		// Word/character wrapping mechanism variables
		int MEASURE_STATE = 0, DRAW_STATE = 1;

		int state = wordWrap ? MEASURE_STATE : DRAW_STATE;

		int startLine = -1;         // Index where to begin drawing (where a line begins)
		int endLine = -1;           // Index where to stop drawing (where a line ends)
		int lastk = -1;             // Holds last value of the character position

		for (int i = 0, k = 0; i < length; i++, k++)
		{
			// Get next codepoint from byte string and glyph index in font
			int codepointByteCount = 0;
			int codepoint = GetCodepoint(text[i], out codepointByteCount);
			int index = GetGlyphIndex(font, codepoint);

			// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol moving one byte
			if (codepoint == 0x3f) codepointByteCount = 1;
			i += (codepointByteCount - 1);

			float glyphWidth = 0;
			if (codepoint != '\n')
			{
				glyphWidth = (font.glyphs[index].advanceX == 0) ? font.recs[index].width * scaleFactor : font.glyphs[index].advanceX * scaleFactor;

				if (i + 1 < length) glyphWidth = glyphWidth + spacing;
			}

			// NOTE: When wordWrap is ON we first measure how much of the text we can draw before going outside of the rec container
			// We store this info in startLine and endLine, then we change states, draw the text between those two variables
			// and change states again and again recursively until the end of the text (or until we get outside of the container).
			// When wordWrap is OFF we don't need the measure state so we go to the drawing state immediately
			// and begin drawing on the next line before we can get outside the container.
			if (state == MEASURE_STATE)
			{
				// TODO: There are multiple types of spaces in UNICODE, maybe it's a good idea to add support for more
				// Ref: http://jkorpela.fi/chars/spaces.html
				if ((codepoint == ' ') || (codepoint == '\t') || (codepoint == '\n')) endLine = i;

				if ((textOffsetX + glyphWidth) > rec.width)
				{
					endLine = (endLine < 1) ? i : endLine;
					if (i == endLine) endLine -= codepointByteCount;
					if ((startLine + codepointByteCount) == endLine) endLine = (i - codepointByteCount);

					state = state == 0 ? 1 : 0;
				}
				else if ((i + 1) == length)
				{
					endLine = i;
					state = state == 0 ? 1 : 0;
				}
				else if (codepoint == '\n') state = state == 0 ? 1 : 0;

				if (state == DRAW_STATE)
				{
					textOffsetX = 0;
					i = startLine;
					glyphWidth = 0;

					// Save character position when we switch states
					int tmp = lastk;
					lastk = k - 1;
					k = tmp;
				}
			}
			else
			{
				if (codepoint == '\n')
				{
					if (!wordWrap)
					{
						textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
						textOffsetX = 0;
					}
				}
				else
				{
					if (!wordWrap && ((textOffsetX + glyphWidth) > rec.width))
					{
						textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
						textOffsetX = 0;
					}

					// When text overflows rectangle height limit, just stop drawing
					if ((textOffsetY + font.baseSize * scaleFactor) > rec.height) break;

					// Draw selection background
					bool isGlyphSelected = false;
					if ((selectStart >= 0) && (k >= selectStart) && (k < (selectStart + selectLength)))
					{
						DrawRectangleRec(new Rectangle(rec.X + textOffsetX - 1, rec.Y + textOffsetY, glyphWidth, (float)font.baseSize * scaleFactor), selectBackTint);
						isGlyphSelected = true;
					}

					// Draw current character glyph
					if ((codepoint != ' ') && (codepoint != '\t'))
					{
						DrawTextCodepoint(font, codepoint, new Vector2(rec.X + textOffsetX, rec.Y + textOffsetY), fontSize, isGlyphSelected ? selectTint : tint);
					}
				}

				if (wordWrap && (i == endLine))
				{
					textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
					textOffsetX = 0;
					startLine = endLine;
					endLine = -1;
					glyphWidth = 0;
					selectStart += lastk - k;
					k = lastk;

					state = state == 0 ? 1 : 0;
				}
			}

			textOffsetX += glyphWidth;
		}
	}
}


/*******************************************************************************************
*
*   raylib [text] example - Using unicode with raylib
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by Vlad Adrian (@demizdor) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 Vlad Adrian (@demizdor) and Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class Unicode
{

	// # include <stdio.h>
	// # include <string.h>

	//#define A.Length (A.Length/sizeof(A[0]))
	const int EMOJI_PER_WIDTH = 8;
	const int EMOJI_PER_HEIGHT = 4;

	// String containing 180 emoji codepoints separated by a '\0' char
	const string emojiCodepoints = "\xF0\x9F\x8C\x80\x00\xF0\x9F\x98\x80\x00\xF0\x9F\x98\x82\x00\xF0\x9F\xA4\xA3\x00\xF0\x9F\x98\x83\x00\xF0\x9F\x98\x86\x00\xF0\x9F\x98\x89\x00" +
	"\xF0\x9F\x98\x8B\x00\xF0\x9F\x98\x8E\x00\xF0\x9F\x98\x8D\x00\xF0\x9F\x98\x98\x00\xF0\x9F\x98\x97\x00\xF0\x9F\x98\x99\x00\xF0\x9F\x98\x9A\x00\xF0\x9F\x99\x82\x00" +
	"\xF0\x9F\xA4\x97\x00\xF0\x9F\xA4\xA9\x00\xF0\x9F\xA4\x94\x00\xF0\x9F\xA4\xA8\x00\xF0\x9F\x98\x90\x00\xF0\x9F\x98\x91\x00\xF0\x9F\x98\xB6\x00\xF0\x9F\x99\x84\x00" +
	"\xF0\x9F\x98\x8F\x00\xF0\x9F\x98\xA3\x00\xF0\x9F\x98\xA5\x00\xF0\x9F\x98\xAE\x00\xF0\x9F\xA4\x90\x00\xF0\x9F\x98\xAF\x00\xF0\x9F\x98\xAA\x00\xF0\x9F\x98\xAB\x00" +
	"\xF0\x9F\x98\xB4\x00\xF0\x9F\x98\x8C\x00\xF0\x9F\x98\x9B\x00\xF0\x9F\x98\x9D\x00\xF0\x9F\xA4\xA4\x00\xF0\x9F\x98\x92\x00\xF0\x9F\x98\x95\x00\xF0\x9F\x99\x83\x00" +
	"\xF0\x9F\xA4\x91\x00\xF0\x9F\x98\xB2\x00\xF0\x9F\x99\x81\x00\xF0\x9F\x98\x96\x00\xF0\x9F\x98\x9E\x00\xF0\x9F\x98\x9F\x00\xF0\x9F\x98\xA4\x00\xF0\x9F\x98\xA2\x00" +
	"\xF0\x9F\x98\xAD\x00\xF0\x9F\x98\xA6\x00\xF0\x9F\x98\xA9\x00\xF0\x9F\xA4\xAF\x00\xF0\x9F\x98\xAC\x00\xF0\x9F\x98\xB0\x00\xF0\x9F\x98\xB1\x00\xF0\x9F\x98\xB3\x00" +
	"\xF0\x9F\xA4\xAA\x00\xF0\x9F\x98\xB5\x00\xF0\x9F\x98\xA1\x00\xF0\x9F\x98\xA0\x00\xF0\x9F\xA4\xAC\x00\xF0\x9F\x98\xB7\x00\xF0\x9F\xA4\x92\x00\xF0\x9F\xA4\x95\x00" +
	"\xF0\x9F\xA4\xA2\x00\xF0\x9F\xA4\xAE\x00\xF0\x9F\xA4\xA7\x00\xF0\x9F\x98\x87\x00\xF0\x9F\xA4\xA0\x00\xF0\x9F\xA4\xAB\x00\xF0\x9F\xA4\xAD\x00\xF0\x9F\xA7\x90\x00" +
	"\xF0\x9F\xA4\x93\x00\xF0\x9F\x98\x88\x00\xF0\x9F\x91\xBF\x00\xF0\x9F\x91\xB9\x00\xF0\x9F\x91\xBA\x00\xF0\x9F\x92\x80\x00\xF0\x9F\x91\xBB\x00\xF0\x9F\x91\xBD\x00" +
	"\xF0\x9F\x91\xBE\x00\xF0\x9F\xA4\x96\x00\xF0\x9F\x92\xA9\x00\xF0\x9F\x98\xBA\x00\xF0\x9F\x98\xB8\x00\xF0\x9F\x98\xB9\x00\xF0\x9F\x98\xBB\x00\xF0\x9F\x98\xBD\x00" +
	"\xF0\x9F\x99\x80\x00\xF0\x9F\x98\xBF\x00\xF0\x9F\x8C\xBE\x00\xF0\x9F\x8C\xBF\x00\xF0\x9F\x8D\x80\x00\xF0\x9F\x8D\x83\x00\xF0\x9F\x8D\x87\x00\xF0\x9F\x8D\x93\x00" +
	"\xF0\x9F\xA5\x9D\x00\xF0\x9F\x8D\x85\x00\xF0\x9F\xA5\xA5\x00\xF0\x9F\xA5\x91\x00\xF0\x9F\x8D\x86\x00\xF0\x9F\xA5\x94\x00\xF0\x9F\xA5\x95\x00\xF0\x9F\x8C\xBD\x00" +
	"\xF0\x9F\x8C\xB6\x00\xF0\x9F\xA5\x92\x00\xF0\x9F\xA5\xA6\x00\xF0\x9F\x8D\x84\x00\xF0\x9F\xA5\x9C\x00\xF0\x9F\x8C\xB0\x00\xF0\x9F\x8D\x9E\x00\xF0\x9F\xA5\x90\x00" +
	"\xF0\x9F\xA5\x96\x00\xF0\x9F\xA5\xA8\x00\xF0\x9F\xA5\x9E\x00\xF0\x9F\xA7\x80\x00\xF0\x9F\x8D\x96\x00\xF0\x9F\x8D\x97\x00\xF0\x9F\xA5\xA9\x00\xF0\x9F\xA5\x93\x00" +
	"\xF0\x9F\x8D\x94\x00\xF0\x9F\x8D\x9F\x00\xF0\x9F\x8D\x95\x00\xF0\x9F\x8C\xAD\x00\xF0\x9F\xA5\xAA\x00\xF0\x9F\x8C\xAE\x00\xF0\x9F\x8C\xAF\x00\xF0\x9F\xA5\x99\x00" +
	"\xF0\x9F\xA5\x9A\x00\xF0\x9F\x8D\xB3\x00\xF0\x9F\xA5\x98\x00\xF0\x9F\x8D\xB2\x00\xF0\x9F\xA5\xA3\x00\xF0\x9F\xA5\x97\x00\xF0\x9F\x8D\xBF\x00\xF0\x9F\xA5\xAB\x00" +
	"\xF0\x9F\x8D\xB1\x00\xF0\x9F\x8D\x98\x00\xF0\x9F\x8D\x9D\x00\xF0\x9F\x8D\xA0\x00\xF0\x9F\x8D\xA2\x00\xF0\x9F\x8D\xA5\x00\xF0\x9F\x8D\xA1\x00\xF0\x9F\xA5\x9F\x00" +
	"\xF0\x9F\xA5\xA1\x00\xF0\x9F\x8D\xA6\x00\xF0\x9F\x8D\xAA\x00\xF0\x9F\x8E\x82\x00\xF0\x9F\x8D\xB0\x00\xF0\x9F\xA5\xA7\x00\xF0\x9F\x8D\xAB\x00\xF0\x9F\x8D\xAF\x00" +
	"\xF0\x9F\x8D\xBC\x00\xF0\x9F\xA5\x9B\x00\xF0\x9F\x8D\xB5\x00\xF0\x9F\x8D\xB6\x00\xF0\x9F\x8D\xBE\x00\xF0\x9F\x8D\xB7\x00\xF0\x9F\x8D\xBB\x00\xF0\x9F\xA5\x82\x00" +
	"\xF0\x9F\xA5\x83\x00\xF0\x9F\xA5\xA4\x00\xF0\x9F\xA5\xA2\x00\xF0\x9F\x91\x81\x00\xF0\x9F\x91\x85\x00\xF0\x9F\x91\x84\x00\xF0\x9F\x92\x8B\x00\xF0\x9F\x92\x98\x00" +
	"\xF0\x9F\x92\x93\x00\xF0\x9F\x92\x97\x00\xF0\x9F\x92\x99\x00\xF0\x9F\x92\x9B\x00\xF0\x9F\xA7\xA1\x00\xF0\x9F\x92\x9C\x00\xF0\x9F\x96\xA4\x00\xF0\x9F\x92\x9D\x00" +
	"\xF0\x9F\x92\x9F\x00\xF0\x9F\x92\x8C\x00\xF0\x9F\x92\xA4\x00\xF0\x9F\x92\xA2\x00\xF0\x9F\x92\xA3\x00";

	//	struct {

	//	char* text;
	//	char* language;
	//}
	static (string text, string language)[] messages = new (string text, string language)[]{ // Array containing all of the emojis messages
	("\x46\x61\x6C\x73\x63\x68\x65\x73\x20\xC3\x9C\x62\x65\x6E\x20\x76\x6F\x6E\x20\x58\x79\x6C\x6F\x70\x68\x6F\x6E\x6D\x75\x73\x69\x6B\x20\x71\x75\xC3\xA4\x6C"+

	"\x74\x20\x6A\x65\x64\x65\x6E\x20\x67\x72\xC3\xB6\xC3\x9F\x65\x72\x65\x6E\x20\x5A\x77\x65\x72\x67", "German"),
	(
	"\x42\x65\x69\xC3\x9F\x20\x6E\x69\x63\x68\x74\x20\x69\x6E\x20\x64\x69\x65\x20\x48\x61\x6E\x64\x2C\x20\x64\x69\x65\x20\x64\x69\x63\x68\x20\x66\xC3\xBC\x74"+

	"\x74\x65\x72\x74\x2E", "German"),
	(
		"\x41\x75\xC3\x9F\x65\x72\x6F\x72\x64\x65\x6E\x74\x6C\x69\x63\x68\x65\x20\xC3\x9C\x62\x65\x6C\x20\x65\x72\x66\x6F\x72\x64\x65\x72\x6E\x20\x61\x75\xC3\x9F"+

	"\x65\x72\x6F\x72\x64\x65\x6E\x74\x6C\x69\x63\x68\x65\x20\x4D\x69\x74\x74\x65\x6C\x2E", "German"),
	(
			"\xD4\xBF\xD6\x80\xD5\xB6\xD5\xA1\xD5\xB4\x20\xD5\xA1\xD5\xBA\xD5\xA1\xD5\xAF\xD5\xAB\x20\xD5\xB8\xD6\x82\xD5\xBF\xD5\xA5\xD5\xAC\x20\xD6\x87\x20\xD5\xAB"+

	"\xD5\xB6\xD5\xAE\xD5\xAB\x20\xD5\xA1\xD5\xB6\xD5\xB0\xD5\xA1\xD5\xB6\xD5\xA3\xD5\xAB\xD5\xBD\xD5\xBF\x20\xD5\xB9\xD5\xA8\xD5\xB6\xD5\xA5\xD6\x80", "Armenian"),
	(
				"\xD4\xB5\xD6\x80\xD5\xA2\x20\xD5\xB8\xD6\x80\x20\xD5\xAF\xD5\xA1\xD6\x81\xD5\xAB\xD5\xB6\xD5\xA8\x20\xD5\xA5\xD5\xAF\xD5\xA1\xD6\x82\x20\xD5\xA1\xD5\xB6\xD5"+

	"\xBF\xD5\xA1\xD5\xBC\x2C\x20\xD5\xAE\xD5\xA1\xD5\xBC\xD5\xA5\xD6\x80\xD5\xA8\x20\xD5\xA1\xD5\xBD\xD5\xA1\xD6\x81\xD5\xAB\xD5\xB6\x2E\x2E\x2E\x20\xC2\xAB\xD4\xBF"+

	"\xD5\xB8\xD5\xBF\xD5\xA8\x20\xD5\xB4\xD5\xA5\xD6\x80\xD5\xB8\xD5\xB6\xD6\x81\xD5\xAB\xD6\x81\x20\xD5\xA7\x3A\xC2\xBB", "Armenian"),
	(
					"\xD4\xB3\xD5\xA1\xD5\xBC\xD5\xA8\xD5\x9D\x20\xD5\xA3\xD5\xA1\xD6\x80\xD5\xB6\xD5\xA1\xD5\xB6\x2C\x20\xD5\xB1\xD5\xAB\xD6\x82\xD5\xB6\xD5\xA8\xD5\x9D\x20\xD5"+

	"\xB1\xD5\xB4\xD5\xBC\xD5\xA1\xD5\xB6", "Armenian"),
	(
						"\x4A\x65\xC5\xBC\x75\x20\x6B\x6C\xC4\x85\x74\x77\x2C\x20\x73\x70\xC5\x82\xC3\xB3\x64\xC5\xBA\x20\x46\x69\x6E\x6F\x6D\x20\x63\x7A\xC4\x99\xC5\x9B\xC4\x87"+

	"\x20\x67\x72\x79\x20\x68\x61\xC5\x84\x62\x21", "Polish")   ,
	(
							"\x44\x6F\x62\x72\x79\x6D\x69\x20\x63\x68\xC4\x99\x63\x69\x61\x6D\x69\x20\x6A\x65\x73\x74\x20\x70\x69\x65\x6B\xC5\x82\x6F\x20\x77\x79\x62\x72\x75\x6B\x6F"+

	"\x77\x61\x6E\x65\x2E", "Polish"),
	(
								"\xC3\x8E\xC8\x9B\x69\x20\x6D\x75\x6C\xC8\x9B\x75\x6D\x65\x73\x63\x20\x63\xC4\x83\x20\x61\x69\x20\x61\x6C\x65\x73\x20\x72\x61\x79\x6C\x69\x62\x2E\x0A\xC8\x98"+

	"\x69\x20\x73\x70\x65\x72\x20\x73\xC4\x83\x20\x61\x69\x20\x6F\x20\x7A\x69\x20\x62\x75\x6E\xC4\x83\x21", "Romanian"),
	(
									"\xD0\xAD\xD1\x85\x2C\x20\xD1\x87\xD1\x83\xD0\xB6\xD0\xB0\xD0\xBA\x2C\x20\xD0\xBE\xD0\xB1\xD1\x89\xD0\xB8\xD0\xB9\x20\xD1\x81\xD1\x8A\xD1\x91\xD0\xBC\x20"+

	"\xD1\x86\xD0\xB5\xD0\xBD\x20\xD1\x88\xD0\xBB\xD1\x8F\xD0\xBF\x20\x28\xD1\x8E\xD1\x84\xD1\x82\xD1\x8C\x29\x20\xD0\xB2\xD0\xB4\xD1\x80\xD1\x8B\xD0\xB7\xD0\xB3\x21", "Russian"),
	(
										"\xD0\xAF\x20\xD0\xBB\xD1\x8E\xD0\xB1\xD0\xBB\xD1\x8E\x20\x72\x61\x79\x6C\x69\x62\x21", "Russian"),
	(
											"\xD0\x9C\xD0\xBE\xD0\xBB\xD1\x87\xD0\xB8\x2C\x20\xD1\x81\xD0\xBA\xD1\x80\xD1\x8B\xD0\xB2\xD0\xB0\xD0\xB9\xD1\x81\xD1\x8F\x20\xD0\xB8\x20\xD1\x82\xD0\xB0\xD0\xB8"+

	"\x0A\xD0\x98\x20\xD1\x87\xD1\x83\xD0\xB2\xD1\x81\xD1\x82\xD0\xB2\xD0\xB0\x20\xD0\xB8\x20\xD0\xBC\xD0\xB5\xD1\x87\xD1\x82\xD1\x8B\x20\xD1\x81\xD0\xB2\xD0\xBE\xD0\xB8\x20"+

	"\xE2\x80\x93\x0A\xD0\x9F\xD1\x83\xD1\x81\xD0\xBA\xD0\xB0\xD0\xB9\x20\xD0\xB2\x20\xD0\xB4\xD1\x83\xD1\x88\xD0\xB5\xD0\xB2\xD0\xBD\xD0\xBE\xD0\xB9\x20\xD0\xB3\xD0\xBB\xD1"+

	"\x83\xD0\xB1\xD0\xB8\xD0\xBD\xD0\xB5\x0A\xD0\x98\x20\xD0\xB2\xD1\x81\xD1\x85\xD0\xBE\xD0\xB4\xD1\x8F\xD1\x82\x20\xD0\xB8\x20\xD0\xB7\xD0\xB0\xD0\xB9\xD0\xB4\xD1\x83\xD1"+

	"\x82\x20\xD0\xBE\xD0\xBD\xD0\xB5\x0A\xD0\x9A\xD0\xB0\xD0\xBA\x20\xD0\xB7\xD0\xB2\xD0\xB5\xD0\xB7\xD0\xB4\xD1\x8B\x20\xD1\x8F\xD1\x81\xD0\xBD\xD1\x8B\xD0\xB5\x20\xD0\xB2"+

	"\x20\xD0\xBD\xD0\xBE\xD1\x87\xD0\xB8\x2D\x0A\xD0\x9B\xD1\x8E\xD0\xB1\xD1\x83\xD0\xB9\xD1\x81\xD1\x8F\x20\xD0\xB8\xD0\xBC\xD0\xB8\x20\xE2\x80\x93\x20\xD0\xB8\x20\xD0\xBC"+

	"\xD0\xBE\xD0\xBB\xD1\x87\xD0\xB8\x2E", "Russian"),
	(
												"\x56\x6F\x69\x78\x20\x61\x6D\x62\x69\x67\x75\xC3\xAB\x20\x64\xE2\x80\x99\x75\x6E\x20\x63\xC5\x93\x75\x72\x20\x71\x75\x69\x20\x61\x75\x20\x7A\xC3\xA9\x70"+

	"\x68\x79\x72\x20\x70\x72\xC3\xA9\x66\xC3\xA8\x72\x65\x20\x6C\x65\x73\x20\x6A\x61\x74\x74\x65\x73\x20\x64\x65\x20\x6B\x69\x77\x69", "French"),
	(
													"\x42\x65\x6E\x6A\x61\x6D\xC3\xAD\x6E\x20\x70\x69\x64\x69\xC3\xB3\x20\x75\x6E\x61\x20\x62\x65\x62\x69\x64\x61\x20\x64\x65\x20\x6B\x69\x77\x69\x20\x79\x20"+

	"\x66\x72\x65\x73\x61\x3B\x20\x4E\x6F\xC3\xA9\x2C\x20\x73\x69\x6E\x20\x76\x65\x72\x67\xC3\xBC\x65\x6E\x7A\x61\x2C\x20\x6C\x61\x20\x6D\xC3\xA1\x73\x20\x65\x78"+

	"\x71\x75\x69\x73\x69\x74\x61\x20\x63\x68\x61\x6D\x70\x61\xC3\xB1\x61\x20\x64\x65\x6C\x20\x6D\x65\x6E\xC3\xBA\x2E", "Spanish"),
	(
														"\xCE\xA4\xCE\xB1\xCF\x87\xCE\xAF\xCF\x83\xCF\x84\xCE\xB7\x20\xCE\xB1\xCE\xBB\xCF\x8E\xCF\x80\xCE\xB7\xCE\xBE\x20\xCE\xB2\xCE\xB1\xCF\x86\xCE\xAE\xCF\x82\x20"+

	"\xCF\x88\xCE\xB7\xCE\xBC\xCE\xAD\xCE\xBD\xCE\xB7\x20\xCE\xB3\xCE\xB7\x2C\x20\xCE\xB4\xCF\x81\xCE\xB1\xCF\x83\xCE\xBA\xCE\xB5\xCE\xBB\xCE\xAF\xCE\xB6\xCE\xB5\xCE"+

	"\xB9\x20\xCF\x85\xCF\x80\xCE\xAD\xCF\x81\x20\xCE\xBD\xCF\x89\xCE\xB8\xCF\x81\xCE\xBF\xCF\x8D\x20\xCE\xBA\xCF\x85\xCE\xBD\xCF\x8C\xCF\x82", "Greek"),
	(
															"\xCE\x97\x20\xCE\xBA\xCE\xB1\xCE\xBB\xCF\x8D\xCF\x84\xCE\xB5\xCF\x81\xCE\xB7\x20\xCE\xAC\xCE\xBC\xCF\x85\xCE\xBD\xCE\xB1\x20\xCE\xB5\xCE\xAF\xCE\xBD"+

	"\xCE\xB1\xCE\xB9\x20\xCE\xB7\x20\xCE\xB5\xCF\x80\xCE\xAF\xCE\xB8\xCE\xB5\xCF\x83\xCE\xB7\x2E", "Greek"),
	(
																"\xCE\xA7\xCF\x81\xCF\x8C\xCE\xBD\xCE\xB9\xCE\xB1\x20\xCE\xBA\xCE\xB1\xCE\xB9\x20\xCE\xB6\xCE\xB1\xCE\xBC\xCE\xAC\xCE\xBD\xCE\xB9\xCE\xB1\x21", "Greek"),
	(
																	"\xCE\xA0\xCF\x8E\xCF\x82\x20\xCF\x84\xCE\xB1\x20\xCF\x80\xCE\xB1\xCF\x82\x20\xCF\x83\xCE\xAE\xCE\xBC\xCE\xB5\xCF\x81\xCE\xB1\x3B", "Greek"),

	(
																		"\xE6\x88\x91\xE8\x83\xBD\xE5\x90\x9E\xE4\xB8\x8B\xE7\x8E\xBB\xE7\x92\x83\xE8\x80\x8C\xE4\xB8\x8D\xE4\xBC\xA4\xE8\xBA\xAB\xE4\xBD\x93\xE3\x80\x82", "Chinese"),
	(
																			"\xE4\xBD\xA0\xE5\x90\x83\xE4\xBA\x86\xE5\x90\x97\xEF\xBC\x9F", "Chinese"),
	(
																				"\xE4\xB8\x8D\xE4\xBD\x9C\xE4\xB8\x8D\xE6\xAD\xBB\xE3\x80\x82", "Chinese"),
	(
																					"\xE6\x9C\x80\xE8\xBF\x91\xE5\xA5\xBD\xE5\x90\x97\xEF\xBC\x9F", "Chinese"),
	(
																						"\xE5\xA1\x9E\xE7\xBF\x81\xE5\xA4\xB1\xE9\xA9\xAC\xEF\xBC\x8C\xE7\x84\x89\xE7\x9F\xA5\xE9\x9D\x9E\xE7\xA6\x8F\xE3\x80\x82", "Chinese"),
	(
																							"\xE5\x8D\x83\xE5\x86\x9B\xE6\x98\x93\xE5\xBE\x97\x2C\x20\xE4\xB8\x80\xE5\xB0\x86\xE9\x9A\xBE\xE6\xB1\x82", "Chinese"),
	(
																								"\xE4\xB8\x87\xE4\xBA\x8B\xE5\xBC\x80\xE5\xA4\xB4\xE9\x9A\xBE\xE3\x80\x82", "Chinese"),
	(
																									"\xE9\xA3\x8E\xE6\x97\xA0\xE5\xB8\xB8\xE9\xA1\xBA\xEF\xBC\x8C\xE5\x85\xB5\xE6\x97\xA0\xE5\xB8\xB8\xE8\x83\x9C\xE3\x80\x82", "Chinese"),
	(
																										"\xE6\xB4\xBB\xE5\x88\xB0\xE8\x80\x81\xEF\xBC\x8C\xE5\xAD\xA6\xE5\x88\xB0\xE8\x80\x81\xE3\x80\x82", "Chinese"),
	(
																											"\xE4\xB8\x80\xE8\xA8\x80\xE6\x97\xA2\xE5\x87\xBA\xEF\xBC\x8C\xE9\xA9\xB7\xE9\xA9\xAC\xE9\x9A\xBE\xE8\xBF\xBD\xE3\x80\x82", "Chinese"),
	(
																												"\xE8\xB7\xAF\xE9\x81\xA5\xE7\x9F\xA5\xE9\xA9\xAC\xE5\x8A\x9B\xEF\xBC\x8C\xE6\x97\xA5\xE4\xB9\x85\xE8\xA7\x81\xE4\xBA\xBA\xE5\xBF\x83", "Chinese"),
	(
																													"\xE6\x9C\x89\xE7\x90\x86\xE8\xB5\xB0\xE9\x81\x8D\xE5\xA4\xA9\xE4\xB8\x8B\xEF\xBC\x8C\xE6\x97\xA0\xE7\x90\x86\xE5\xAF\xB8\xE6\xAD\xA5\xE9\x9A\xBE\xE8\xA1\x8C\xE3\x80\x82", "Chinese"),

	(
																														"\xE7\x8C\xBF\xE3\x82\x82\xE6\x9C\xA8\xE3\x81\x8B\xE3\x82\x89\xE8\x90\xBD\xE3\x81\xA1\xE3\x82\x8B", "Japanese"),
	(
																															"\xE4\xBA\x80\xE3\x81\xAE\xE7\x94\xB2\xE3\x82\x88\xE3\x82\x8A\xE5\xB9\xB4\xE3\x81\xAE\xE5\x8A\x9F", "Japanese"),
	(
																																"\xE3\x81\x86\xE3\x82\x89\xE3\x82\x84\xE3\x81\xBE\xE3\x81\x97\x20\x20\xE6\x80\x9D\xE3\x81\xB2\xE5\x88\x87\xE3\x82\x8B\xE6\x99\x82\x20\x20\xE7\x8C\xAB\xE3\x81\xAE\xE6\x81\x8B", "Japanese"),
	(
																																	"\xE8\x99\x8E\xE7\xA9\xB4\xE3\x81\xAB\xE5\x85\xA5\xE3\x82\x89\xE3\x81\x9A\xE3\x82\x93\xE3\x81\xB0\xE8\x99\x8E\xE5\xAD\x90\xE3\x82\x92\xE5\xBE\x97\xE3\x81\x9A\xE3\x80\x82", "Japanese"),
	(
																																		"\xE4\xBA\x8C\xE5\x85\x8E\xE3\x82\x92\xE8\xBF\xBD\xE3\x81\x86\xE8\x80\x85\xE3\x81\xAF\xE4\xB8\x80\xE5\x85\x8E\xE3\x82\x92\xE3\x82\x82\xE5\xBE\x97\xE3\x81\x9A\xE3\x80\x82", "Japanese"),
	(
																																			"\xE9\xA6\xAC\xE9\xB9\xBF\xE3\x81\xAF\xE6\xAD\xBB\xE3\x81\xAA\xE3\x81\xAA\xE3\x81\x8D\xE3\x82\x83\xE6\xB2\xBB\xE3\x82\x89\xE3\x81\xAA\xE3\x81\x84\xE3\x80\x82", "Japanese"),
	(
																																				"\xE6\x9E\xAF\xE9\x87\x8E\xE8\xB7\xAF\xE3\x81\xAB\xE3\x80\x80\xE5\xBD\xB1\xE3\x81\x8B\xE3\x81\x95\xE3\x81\xAA\xE3\x82\x8A\xE3\x81\xA6\xE3\x80\x80\xE3\x82\x8F\xE3\x81\x8B\xE3\x82\x8C\xE3\x81\x91\xE3\x82\x8A", "Japanese"),
	(
																																					"\xE7\xB9\xB0\xE3\x82\x8A\xE8\xBF\x94\xE3\x81\x97\xE9\xBA\xA6\xE3\x81\xAE\xE7\x95\x9D\xE7\xB8\xAB\xE3\x81\xB5\xE8\x83\xA1\xE8\x9D\xB6\xE5\x93\x89", "Japanese"),

	(
																																						"\xEC\x95\x84\xEB\x93\x9D\xED\x95\x9C\x20\xEB\xB0\x94\xEB\x8B\xA4\x20\xEC\x9C\x84\xEC\x97\x90\x20\xEA\xB0\x88\xEB\xA7\xA4\xEA\xB8\xB0\x20\xEB\x91\x90\xEC\x97\x87\x20"+

	"\xEB\x82\xA0\xEC\x95\x84\x20\xEB\x8F\x88\xEB\x8B\xA4\x2E\x0A\xEB\x84\x88\xED\x9B\x8C\xEB\x84\x88\xED\x9B\x8C\x20\xEC\x8B\x9C\xEB\xA5\xBC\x20\xEC\x93\xB4\xEB\x8B\xA4\x2E"+

	"\x20\xEB\xAA\xA8\xEB\xA5\xB4\xEB\x8A\x94\x20\xEB\x82\x98\xEB\x9D\xBC\x20\xEA\xB8\x80\xEC\x9E\x90\xEB\x8B\xA4\x2E\x0A\xEB\x84\x90\xEB\x94\xB0\xEB\x9E\x80\x20\xED\x95\x98"+

	"\xEB\x8A\x98\x20\xEB\xB3\xB5\xED\x8C\x90\xEC\x97\x90\x20\xEB\x82\x98\xEB\x8F\x84\x20\xEA\xB0\x99\xEC\x9D\xB4\x20\xEC\x8B\x9C\xEB\xA5\xBC\x20\xEC\x93\xB4\xEB\x8B\xA4\x2E", "Korean"),
	(
																																							"\xEC\xA0\x9C\x20\xEB\x88\x88\xEC\x97\x90\x20\xEC\x95\x88\xEA\xB2\xBD\xEC\x9D\xB4\xEB\x8B\xA4", "Korean"),
	(
																																								"\xEA\xBF\xA9\x20\xEB\xA8\xB9\xEA\xB3\xA0\x20\xEC\x95\x8C\x20\xEB\xA8\xB9\xEB\x8A\x94\xEB\x8B\xA4", "Korean"),
	(
																																									"\xEB\xA1\x9C\xEB\xA7\x88\xEB\x8A\x94\x20\xED\x95\x98\xEB\xA3\xA8\xEC\x95\x84\xEC\xB9\xA8\xEC\x97\x90\x20\xEC\x9D\xB4\xEB\xA3\xA8\xEC\x96\xB4\xEC\xA7\x84\x20\xEA\xB2\x83\xEC\x9D\xB4"+

	"\x20\xEC\x95\x84\xEB\x8B\x88\xEB\x8B\xA4", "Korean"),
	(
																																										"\xEA\xB3\xA0\xEC\x83\x9D\x20\xEB\x81\x9D\xEC\x97\x90\x20\xEB\x82\x99\xEC\x9D\xB4\x20\xEC\x98\xA8\xEB\x8B\xA4", "Korean"),
	(
																																											"\xEA\xB0\x9C\xEC\xB2\x9C\xEC\x97\x90\xEC\x84\x9C\x20\xEC\x9A\xA9\x20\xEB\x82\x9C\xEB\x8B\xA4", "Korean"),
	(
																																												"\xEC\x95\x88\xEB\x85\x95\xED\x95\x98\xEC\x84\xB8\xEC\x9A\x94\x3F", "Korean"),
	(
																																													"\xEB\xA7\x8C\xEB\x82\x98\xEC\x84\x9C\x20\xEB\xB0\x98\xEA\xB0\x91\xEC\x8A\xB5\xEB\x8B\x88\xEB\x8B\xA4", "Korean"),
	(
																																														"\xED\x95\x9C\xEA\xB5\xAD\xEB\xA7\x90\x20\xED\x95\x98\xEC\x8B\xA4\x20\xEC\xA4\x84\x20\xEC\x95\x84\xEC\x84\xB8\xEC\x9A\x94\x3F", "Korean"),
};


	//--------------------------------------------------------------------------------------
	// Global variables
	//--------------------------------------------------------------------------------------
	// Arrays that holds the random emojis
	record struct emojiStruct(


		int index,      // Index inside `emojiCodepoints`
	int message,   // Message index
	Color color    // Emoji color
	);

	static emojiStruct[] emoji = new emojiStruct[EMOJI_PER_WIDTH * EMOJI_PER_HEIGHT];

	static int hovered = -1, selected = -1;

	//--------------------------------------------------------------------------------------
	// Main entry point
	//--------------------------------------------------------------------------------------
	public static int main()//int argc, char** argv)
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		SetConfigFlags(FLAG_MSAA_4X_HINT | FLAG_VSYNC_HINT);
		InitWindow(screenWidth, screenHeight, "raylib [text] example - unicode");

		// Load the font resources
		// NOTE: fontAsian is for asian languages,
		// fontEmoji is the emojis and fontDefault is used for everything else
		Font fontDefault = LoadFont("resources/dejavu.fnt");
		Font fontAsian = LoadFont("resources/noto_cjk.fnt");
		Font fontEmoji = LoadFont("resources/symbola.fnt");

		Vector2 hoveredPos = new Vector2(0.0f, 0.0f);
		Vector2 selectedPos = new Vector2(0.0f, 0.0f);

		// Set a random set of emojis when starting up
		RandomizeEmoji();

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			// Add a new set of emojis when SPACE is pressed
			if (IsKeyPressed(KEY_SPACE)) RandomizeEmoji();

			// Set the selected emoji and copy its text to clipboard
			if (IsMouseButtonPressed(MOUSE_BUTTON_LEFT) && (hovered != -1) && (hovered != selected))
			{
				selected = hovered;
				selectedPos = hoveredPos;
				SetClipboardText(messages[emoji[selected].message].text);
			}

			Vector2 mouse = GetMousePosition();
			Vector2 pos = new Vector2(28.8f, 10.0f);
			hovered = -1;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			// Draw random emojis in the background
			//------------------------------------------------------------------------------
			for (int i = 0; i < emoji.Length; ++i)
			{
				string txt = emojiCodepoints[emoji[i].index].ToString();
				Rectangle emojiRect = new Rectangle(pos.X, pos.Y, (float)fontEmoji.baseSize, (float)fontEmoji.baseSize);

				if (!CheckCollisionPointRec(mouse, emojiRect))
				{
					DrawTextEx(fontEmoji, txt, pos, (float)fontEmoji.baseSize, 1.0f, selected == i ? emoji[i].color : Fade(LIGHTGRAY, 0.4f));
				}
				else
				{
					DrawTextEx(fontEmoji, txt, pos, (float)fontEmoji.baseSize, 1.0f, emoji[i].color);
					hovered = i;
					hoveredPos = pos;
				}

				if ((i != 0) && (i % EMOJI_PER_WIDTH == 0)) { pos.Y += fontEmoji.baseSize + 24.25f; pos.X = 28.8f; }
				else pos.X += fontEmoji.baseSize + 28.8f;
			}
			//------------------------------------------------------------------------------

			// Draw the message when a emoji is selected
			//------------------------------------------------------------------------------
			if (selected != -1)
			{
				int message = emoji[selected].message;
				int horizontalPadding = 20, verticalPadding = 30;
				Font* font = &fontDefault;

				// Set correct font for asian languages
				if (TextIsEqual(messages[message].language, "Chinese") ||
					TextIsEqual(messages[message].language, "Korean") ||
					TextIsEqual(messages[message].language, "Japanese")) font = &fontAsian;

				// Calculate size for the message box (approximate the height and width)
				Vector2 sz = MeasureTextEx(*font, messages[message].text, (float)font->baseSize, 1.0f);
				if (sz.X > 300) { sz.Y *= sz.X / 300; sz.X = 300; }
				else if (sz.X < 160) sz.X = 160;

				Rectangle msgRect = new Rectangle(selectedPos.X - 38.8f, selectedPos.Y, 2 * horizontalPadding + sz.X, 2 * verticalPadding + sz.Y);
				msgRect.Y -= msgRect.height;

				// Coordinates for the chat bubble triangle
				Vector2 a = new Vector2(selectedPos.X, msgRect.Y + msgRect.height), b = new(a.X + 8, a.Y + 10), c = new(a.X + 10, a.Y);

				// Don't go outside the screen
				if (msgRect.X < 10) msgRect.X += 28;
				if (msgRect.Y < 10)
				{
					msgRect.Y = selectedPos.Y + 84;
					a.Y = msgRect.Y;
					c.Y = a.Y;
					b.Y = a.Y - 10;

					// Swap values so we can actually render the triangle :(
					Vector2 tmp = a;
					a = b;
					b = tmp;
				}
				if (msgRect.X + msgRect.width > screenWidth) msgRect.X -= (msgRect.X + msgRect.width) - screenWidth + 10;

				// Draw chat bubble
				DrawRectangleRec(msgRect, emoji[selected].color);
				DrawTriangle(a, b, c, emoji[selected].color);

				// Draw the main text message
				Rectangle textRect = new Rectangle(msgRect.X + horizontalPadding / 2, msgRect.Y + verticalPadding / 2, msgRect.width - horizontalPadding, msgRect.height);
				DrawTextBoxed(*font, messages[message].text, textRect, (float)font->baseSize, 1.0f, true, WHITE);

				// Draw the info text below the main message	
				//int size = (int)strlen(messages[message].text);
				int size = Raylib.TextLength(messages[message].text);
				int length = GetCodepointCount(messages[message].text);
				string info = TextFormat("%s %u characters %i bytes", messages[message].language, length, size);
				sz = MeasureTextEx(GetFontDefault(), info, 10, 1.0f);
				pos = new Vector2(textRect.X + textRect.width - sz.X, msgRect.Y + msgRect.height - sz.Y - 2);
				DrawText(info, (int)pos.X, (int)pos.Y, 10, RAYWHITE);
			}
			//------------------------------------------------------------------------------

			// Draw the info text
			DrawText("These emojis have something to tell you, click each to find out!", (screenWidth - 650) / 2, screenHeight - 40, 20, GRAY);
			DrawText("Each emoji is a unicode character from a font, not a texture... Press [SPACEBAR] to refresh", (screenWidth - 484) / 2, screenHeight - 16, 10, GRAY);

			EndDrawing();
			//----------------------------------------------------------------------------------
		}

		// De-Initialization
		//--------------------------------------------------------------------------------------
		UnloadFont(fontDefault);    // Unload font resource
		UnloadFont(fontAsian);      // Unload font resource
		UnloadFont(fontEmoji);      // Unload font resource

		CloseWindow();              // Close window and OpenGL context
									//--------------------------------------------------------------------------------------

		return 0;
	}

	// Fills the emoji array with random emoji (only those emojis present in fontEmoji)
	static void RandomizeEmoji()
	{
		hovered = selected = -1;
		int start = GetRandomValue(45, 360);

		for (int i = 0; i < emoji.Length; ++i)
		{
			// 0-179 emoji codepoints (from emoji char array) each 4bytes + null char
			emoji[i].index = GetRandomValue(0, 179) * 5;

			// Generate a random color for this emoji
			emoji[i].color = Fade(ColorFromHSV((float)((start * (i + 1)) % 360), 0.6f, 0.85f), 0.8f);

			// Set a random message for this emoji
			emoji[i].message = GetRandomValue(0, messages.Length - 1);
		}
	}

	//--------------------------------------------------------------------------------------
	// Module functions definition
	//--------------------------------------------------------------------------------------

	// Draw text using font inside rectangle limits
	static void DrawTextBoxed(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint)
	{
		DrawTextBoxedSelectable(font, text, rec, fontSize, spacing, wordWrap, tint, 0, 0, WHITE, WHITE);
	}

	// Draw text using font inside rectangle limits with support for text selection
	static void DrawTextBoxedSelectable(Font font, string text, Rectangle rec, float fontSize, float spacing, bool wordWrap, Color tint, int selectStart, int selectLength, Color selectTint, Color selectBackTint)
	{
		int lengthUtf8 = TextLength(text);  // Total length in bytes of the text, scanned by codepoints in loop

		float textOffsetY = 0;          // Offset between lines (on line break '\n')
		float textOffsetX = 0.0f;       // Offset X to next character to draw

		float scaleFactor = fontSize / (float)font.baseSize;     // Character rectangle scaling factor

		// Word/character wrapping mechanism variables
		int MEASURE_STATE = 0, DRAW_STATE = 1;
		int state = wordWrap ? MEASURE_STATE : DRAW_STATE;

		int startLine = -1;         // Index where to begin drawing (where a line begins)
		int endLine = -1;           // Index where to stop drawing (where a line ends)
		int lastk = -1;             // Holds last value of the character position

		for (int i = 0, k = 0; i < text.Length; i++, k++)
		{
			// Get next codepoint from byte string and glyph index in font
			int codepointByteCount = 0;
			int codepoint = GetCodepoint(text[i], out codepointByteCount);
			int index = GetGlyphIndex(font, codepoint);

			// NOTE: Normally we exit the decoding sequence as soon as a bad byte is found (and return 0x3f)
			// but we need to draw all of the bad bytes using the '?' symbol moving one byte
			if (codepoint == 0x3f) codepointByteCount = 1;
			i += (codepointByteCount - 1);

			float glyphWidth = 0;
			if (codepoint != '\n')
			{
				glyphWidth = (font.glyphs[index].advanceX == 0) ? font.recs[index].width * scaleFactor : font.glyphs[index].advanceX * scaleFactor;

				if (i + 1 < lengthUtf8) glyphWidth = glyphWidth + spacing;
			}

			// NOTE: When wordWrap is ON we first measure how much of the text we can draw before going outside of the rec container
			// We store this info in startLine and endLine, then we change states, draw the text between those two variables
			// and change states again and again recursively until the end of the text (or until we get outside of the container).
			// When wordWrap is OFF we don't need the measure state so we go to the drawing state immediately
			// and begin drawing on the next line before we can get outside the container.
			if (state == MEASURE_STATE)
			{
				// TODO: There are multiple types of spaces in UNICODE, maybe it's a good idea to add support for more
				// Ref: http://jkorpela.fi/chars/spaces.html
				if ((codepoint == ' ') || (codepoint == '\t') || (codepoint == '\n')) endLine = i;

				if ((textOffsetX + glyphWidth) > rec.width)
				{
					endLine = (endLine < 1) ? i : endLine;
					if (i == endLine) endLine -= codepointByteCount;
					if ((startLine + codepointByteCount) == endLine) endLine = (i - codepointByteCount);

					state = state == 0 ? 1 : 0;
				}
				else if ((i + 1) == lengthUtf8)
				{
					endLine = i;
					state = state == 0 ? 1 : 0;
				}
				else if (codepoint == '\n') state = state == 0 ? 1 : 0;

				if (state == DRAW_STATE)
				{
					textOffsetX = 0;
					i = startLine;
					glyphWidth = 0;

					// Save character position when we switch states
					int tmp = lastk;
					lastk = k - 1;
					k = tmp;
				}
			}
			else
			{
				if (codepoint == '\n')
				{
					if (!wordWrap)
					{
						textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
						textOffsetX = 0;
					}
				}
				else
				{
					if (!wordWrap && ((textOffsetX + glyphWidth) > rec.width))
					{
						textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
						textOffsetX = 0;
					}

					// When text overflows rectangle height limit, just stop drawing
					if ((textOffsetY + font.baseSize * scaleFactor) > rec.height) break;

					// Draw selection background
					bool isGlyphSelected = false;
					if ((selectStart >= 0) && (k >= selectStart) && (k < (selectStart + selectLength)))
					{
						DrawRectangleRec(new Rectangle(rec.X + textOffsetX - 1, rec.Y + textOffsetY, glyphWidth, (float)font.baseSize * scaleFactor), selectBackTint);
						isGlyphSelected = true;
					}

					// Draw current character glyph
					if ((codepoint != ' ') && (codepoint != '\t'))
					{
						DrawTextCodepoint(font, codepoint, new Vector2(rec.X + textOffsetX, rec.Y + textOffsetY), fontSize, isGlyphSelected ? selectTint : tint);
					}
				}

				if (wordWrap && (i == endLine))
				{
					textOffsetY += (font.baseSize + font.baseSize / 2) * scaleFactor;
					textOffsetX = 0;
					startLine = endLine;
					endLine = -1;
					glyphWidth = 0;
					selectStart += lastk - k;
					k = lastk;

					state = state == 0 ? 1 : 0;
				}
			}

			textOffsetX += glyphWidth;
		}
	}

}


/*******************************************************************************************
*
*   raylib [text] example - Text Writing Animation
*
*   This example has been created using raylib 2.3 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/

public unsafe static class WritingAnimation
{

	public static int main()
	{
		// Initialization
		//--------------------------------------------------------------------------------------
		const int screenWidth = 800;
		const int screenHeight = 450;

		InitWindow(screenWidth, screenHeight, "raylib [text] example - text writing anim");

		string message = "This sample illustrates a text writing\nanimation effect! Check it out! ;)";

		int framesCounter = 0;

		SetTargetFPS(60);               // Set our game to run at 60 frames-per-second
										//--------------------------------------------------------------------------------------

		// Main game loop
		while (!WindowShouldClose())    // Detect window close button or ESC key
		{
			// Update
			//----------------------------------------------------------------------------------
			if (IsKeyDown(KEY_SPACE)) framesCounter += 8;
			else framesCounter++;

			if (IsKeyPressed(KEY_ENTER)) framesCounter = 0;
			//----------------------------------------------------------------------------------

			// Draw
			//----------------------------------------------------------------------------------
			BeginDrawing();

			ClearBackground(RAYWHITE);

			DrawText(TextSubtext(message, 0, framesCounter / 10), 210, 160, 20, MAROON);

			DrawText("PRESS [ENTER] to RESTART!", 240, 260, 20, LIGHTGRAY);
			DrawText("PRESS [SPACE] to SPEED UP!", 239, 300, 20, LIGHTGRAY);

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
