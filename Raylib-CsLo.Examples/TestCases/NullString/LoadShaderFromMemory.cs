// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

/*******************************************************************************************
*
*   raylib [core] example - Basic window
*
*   Welcome to raylib!
*
*   To test examples, just press F6 and execute raylib_compile_execute script
*   Note that compiled executable is placed in the same folder as .c file
*
*   You can find all basic examples on C:\raylib\raylib\examples folder or
*   raylib official webpage: www.raylib.com
*
*   Enjoy using raylib. :)
*
*   This example has been created using raylib 1.0 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Copyright (c) 2013-2016 Ramon Santamaria (@raysan5)
*
********************************************************************************************/
using System.IO.Compression;
using System.Text;

namespace Raylib_CsLo.Examples.TestCases.NullString
{

	namespace LoadShaderFromMemory
	{
		public static class ResourceManager
		{
			internal struct ResourceInfo
			{
				public string extension;
				public byte[] data;

				public ResourceInfo(string extension, byte[] data) { this.extension = extension; this.data = data; }
			}


			//private static List<string> generatedLines = new();
			private static Dictionary<string, ResourceInfo> resources = new();

			public static void Initialize()
			{
				resources = LoadResources(Generate("resources/test-cases/"));
			}
			public static void Close()
			{
				resources.Clear();
			}

			public static Shader LoadFragmentShader(string name)
			{
				if (Path.HasExtension(name)) return Raylib.LoadShader(null, name);
				else
				{
					string file = Encoding.Default.GetString(resources[name].data);
					return Raylib.LoadShaderFromMemory(null, file);
				}
			}
			private static List<string> Generate(string sourcePath)
			{
				string[] files = Directory.GetFiles(sourcePath, "", SearchOption.AllDirectories);
				List<string> lines = new List<string>();
				foreach (var file in files)
				{
					lines.Add(Path.GetFileName(file));
					var d = File.ReadAllBytes(file);
					lines.Add(Convert.ToBase64String(Compress(d)));
				}
				return lines;
			}
			private static Dictionary<string, ResourceInfo> LoadResources(List<string> lines)
			{
				Dictionary<string, ResourceInfo> result = new();
				for (int i = 0; i < lines.Count; i += 2)
				{
					string filenName = lines[i];
					string name = Path.GetFileNameWithoutExtension(filenName);
					string extension = Path.GetExtension(filenName);
					string dataText = lines[i + 1];
					var data = Convert.FromBase64String(dataText);
					result.Add(name, new(extension, Decompress(data)));
				}
				return result;
			}

			private static byte[] Compress(byte[] data)
			{
				MemoryStream output = new MemoryStream();
				using (DeflateStream dstream = new DeflateStream(output, CompressionLevel.Optimal))
				{
					dstream.Write(data, 0, data.Length);
				}
				return output.ToArray();
			}
			private static byte[] Decompress(byte[] data)
			{
				MemoryStream input = new MemoryStream(data);
				MemoryStream output = new MemoryStream();
				using (DeflateStream dstream = new DeflateStream(input, CompressionMode.Decompress))
				{
					dstream.CopyTo(output);
				}
				return output.ToArray();
			}
		}

		/// <summary>
		/// This program is a test case that verifies passing null as a string argument to raylib gets marshalled properly (as NULL).
		/// the proper result is that the shader is properly loaded in both cases.
		/// </summary>
		public class Program
		{
			const int GLSL_VERSION = 330;

			/// <summary>
			/// 
			/// </summary>
			/// <param name="args"></param>
			public static void main(string[] args)
			{
				// Initialization
				//--------------------------------------------------------------------------------------
				const int screenWidth = 800;
				const int screenHeight = 450;

				Raylib.InitWindow(screenWidth, screenHeight, "Load Shader From Memory Test");

				Image imBlank = Raylib.GenImageColor(1024, 1024, Raylib.BLANK);
				Texture texture = Raylib.LoadTextureFromImage(imBlank);  // Load blank texture to fill on shader
				Raylib.UnloadImage(imBlank);

				ResourceManager.Initialize();

				Shader shaderFromFile = Raylib.LoadShader(null, "resources/test-cases/cubes-panning.fs");
				Shader shaderFromMemory = ResourceManager.LoadFragmentShader("cubes-panning");
				Shader currentShader = shaderFromFile;
				int currentShaderIndex = 0;

				float time = 0.0f;
				int timeLoc = Raylib.GetShaderLocation(shaderFromFile, "uTime");
				Raylib.SetShaderValue(shaderFromFile, timeLoc, time, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
				Raylib.SetShaderValue(shaderFromMemory, timeLoc, time, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);

				Raylib.SetTargetFPS(60); // Set our game to run at 60 frames-per-second
										 // -------------------------------------------------------------------------------------------------------------

				// Main game loop
				while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
				{

					//toggle between the shader loaded from memory and the shader loaded from file
					if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
					{
						if (currentShaderIndex == 0)
						{
							currentShader = shaderFromMemory;
							currentShaderIndex = 1;
						}
						else
						{
							currentShader = shaderFromFile;
							currentShaderIndex = 0;
						}

					}

					// Update
					//----------------------------------------------------------------------------------
					time = (float)Raylib.GetTime();
					Raylib.SetShaderValue(currentShader, timeLoc, time, ShaderUniformDataType.SHADER_UNIFORM_FLOAT);
					//----------------------------------------------------------------------------------

					// Draw
					//----------------------------------------------------------------------------------
					Raylib.BeginDrawing();
					Raylib.ClearBackground(Raylib.RAYWHITE);

					Raylib.BeginShaderMode(currentShader);    // Enable our custom shader for next shapes/textures drawings
					Raylib.DrawTexture(texture, 0, 0, Raylib.WHITE);  // Drawing BLANK texture, all magic happens on shader
					Raylib.EndShaderMode();            // Disable our custom shader, return to default shader

					Raylib.DrawRectangleV(new(0), new(screenWidth, 100), new(0, 0, 0, 210));
					Raylib.DrawText("BACKGROUND is PAINTED and ANIMATED on SHADER!", 10, 10, 20, Raylib.MAROON);
					if (currentShaderIndex == 0)
					{
						Raylib.DrawText("Shader From File Active", 10, 38, 40, Raylib.BLUE);
					}
					else
					{
						Raylib.DrawText("Shader From Memory Active", 10, 38, 40, Raylib.BLUE);
					}
					Raylib.DrawText("[SPACE] - Cycle Shaders", 10, 76, 20, Raylib.BLUE);


					Raylib.EndDrawing();
					//----------------------------------------------------------------------------------
				}

				// De-Initialization
				//--------------------------------------------------------------------------------------
				Raylib.UnloadShader(currentShader);

				Raylib.CloseWindow();        // Close window and OpenGL context
											 //--------------------------------------------------------------------------------------

			}

		}

	}

}
