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
//*   raylib [audio] example - Module playing (streaming)
//*
//*   This example has been created using raylib 1.5 (www.raylib.com)
//*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
//*
//*   Copyright (c) 2016 Ramon Santamaria (@raysan5)
//*
//********************************************************************************************/

//public unsafe static class ModulePlayingStreaming
//{

//	const int MAX_CIRCLES = 64;

//	 struct CircleWave
//	{

//	public Vector2 position;
//		public float radius;
//		public float alpha;
//		public float speed;
//		public Color color;
//}

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

//public unsafe static class MultichannelSoundPlaying
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







