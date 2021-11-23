using Raylib_CsLo;

namespace StandaloneExample
{
	public static class Program
	{
		public static async Task Main(string[] args)
		{
			Raylib.InitWindow(1280, 720, "Hello, Raylib-CsLo");
			Raylib.SetTargetFPS(60);
			// Main game loop
			while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
			{
				Raylib.BeginDrawing();
				Raylib.ClearBackground(Raylib.SKYBLUE);
				Raylib.DrawFPS(10, 10);
				Raylib.DrawText("Raylib is easy!!!", 640 , 360, 50, Raylib.RED);
				Raylib.EndDrawing();
			}
			Raylib.CloseWindow();
		}
	}
}
