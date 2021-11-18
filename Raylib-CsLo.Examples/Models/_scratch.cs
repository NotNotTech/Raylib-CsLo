
namespace Raylib_CsLo.Examples.Models;

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

# include "raylib.h"

#define FOVY_PERSPECTIVE    45.0f
#define WIDTH_ORTHOGRAPHIC  10.0f

		int main(void)
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
					if (camera.projection == CAMERA_PERSPECTIVE)
					{
						camera.fovy = WIDTH_ORTHOGRAPHIC;
						camera.projection = CAMERA_ORTHOGRAPHIC;
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

				if (camera.projection == CAMERA_ORTHOGRAPHIC) DrawText("ORTHOGRAPHIC", 10, 40, 20, BLACK);
				else if (camera.projection == CAMERA_PERSPECTIVE) DrawText("PERSPECTIVE", 10, 40, 20, BLACK);

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

# include "raylib.h"
# include "rlgl.h"

# include <math.h>           // Required for: cosf(), sinf()

		//------------------------------------------------------------------------------------
		// Module Functions Declaration
		//------------------------------------------------------------------------------------
		void DrawSphereBasic(Color color);      // Draw sphere without any matrix transformation

		//------------------------------------------------------------------------------------
		// Program main entry point
		//------------------------------------------------------------------------------------
		int main(void)
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
				rlRotatef(earthRotation, 0.25, 1.0, 0.0);       // Rotation for Earth itself
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
		void DrawSphereBasic(Color color)
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
					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * sinf(DEG2RAD * (j * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * cosf(DEG2RAD * (j * 360 / slices)));
					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * (j * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * (j * 360 / slices)));

					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * sinf(DEG2RAD * (j * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * i)),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * i)) * cosf(DEG2RAD * (j * 360 / slices)));
					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
					rlVertex3f(cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * sinf(DEG2RAD * ((j + 1) * 360 / slices)),
							   sinf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))),
							   cosf(DEG2RAD * (270 + (180 / (rings + 1)) * (i + 1))) * cosf(DEG2RAD * ((j + 1) * 360 / slices)));
				}
			}
			rlEnd();
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

# include "raylib.h"

# include "rlgl.h"
# include "raymath.h"      // Required for: MatrixPerspective(), MatrixLookAt()

#if defined(PLATFORM_DESKTOP)
#define GLSL_VERSION            330
#else   // PLATFORM_RPI, PLATFORM_ANDROID, PLATFORM_WEB
#define GLSL_VERSION            100
#endif

		// Generate cubemap (6 faces) from equirectangular (panorama) texture
		static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format);

		int main(void)
		{
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

			SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "environmentMap"), (int[1]){ MATERIAL_MAP_CUBEMAP ), SHADER_UNIFORM_INT);
		SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "doGamma"), (int[1]) {
			useHDR ? 1 : 0 ), SHADER_UNIFORM_INT);
			SetShaderValue(skybox.materials[0].shader, GetShaderLocation(skybox.materials[0].shader, "vflipped"), (int[1]){
				useHDR ? 1 : 0 ), SHADER_UNIFORM_INT);

				// Load cubemap shader and setup required shader locations
				Shader shdrCubemap = LoadShader(TextFormat("resources/shaders/glsl%i/cubemap.vs", GLSL_VERSION),
												TextFormat("resources/shaders/glsl%i/cubemap.fs", GLSL_VERSION));

				SetShaderValue(shdrCubemap, GetShaderLocation(shdrCubemap, "equirectangularMap"), (int[1])new(), SHADER_UNIFORM_INT);

				char skyboxFileName[256];

				Texture2D panorama;

				if (useHDR)
				{
					TextCopy(skyboxFileName, "resources/dresden_square_2k.hdr");

					// Load HDR panorama (sphere) texture
					panorama = LoadTexture(skyboxFileName);

					// Generate cubemap (texture with 6 quads-cube-mapping) from panorama HDR texture
					// NOTE 1: New texture is generated rendering to texture, shader calculates the sphere->cube coordinates mapping
					// NOTE 2: It seems on some Android devices WebGL, fbo does not properly support a FLOAT-based attachment,
					// despite texture can be successfully created.. so using PIXELFORMAT_UNCOMPRESSED_R8G8B8A8 instead of PIXELFORMAT_UNCOMPRESSED_R32G32B32A32
					skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);

					//UnloadTexture(panorama);    // Texture not required anymore, cubemap already generated
				}
				else
				{
					Image img = LoadImage("resources/skybox.png");
					skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);    // CUBEMAP_LAYOUT_PANORAMA
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
						char** droppedFiles = GetDroppedFiles(&count);

						if (count == 1)         // Only support one file dropped
						{
							if (IsFileExtension(droppedFiles[0], ".png;.jpg;.hdr;.bmp;.tga"))
							{
								// Unload current cubemap texture and load new one
								UnloadTexture(skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture);
								if (useHDR)
								{
									Texture2D panorama = LoadTexture(droppedFiles[0]);

									// Generate cubemap from panorama texture
									skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = GenTextureCubemap(shdrCubemap, panorama, 1024, PIXELFORMAT_UNCOMPRESSED_R8G8B8A8);
									UnloadTexture(panorama);
								}
								else
								{
									Image img = LoadImage(droppedFiles[0]);
									skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture = LoadTextureCubemap(img, CUBEMAP_LAYOUT_AUTO_DETECT);
									UnloadImage(img);
								}

								TextCopy(skyboxFileName, droppedFiles[0]);
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

					//DrawTextureEx(panorama, new( 0, 0 ), 0.0f, 0.5f, WHITE);

					if (useHDR) DrawText(TextFormat("Panorama image from hdrihaven.com: %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);
					else DrawText(TextFormat(": %s", GetFileName(skyboxFileName)), 10, GetScreenHeight() - 20, 10, BLACK);

					DrawFPS(10, 10);

					EndDrawing();
					//----------------------------------------------------------------------------------
				}

				// De-Initialization
				//--------------------------------------------------------------------------------------
				UnloadShader(skybox.materials[0].shader);
				UnloadTexture(skybox.materials[0].maps[MATERIAL_MAP_CUBEMAP].texture);

				UnloadModel(skybox);        // Unload skybox model

				CloseWindow();              // Close window and OpenGL context
											//--------------------------------------------------------------------------------------

				return 0;
			}

			// Generate cubemap texture from HDR texture
			static TextureCubemap GenTextureCubemap(Shader shader, Texture2D panorama, int size, int format)
			{
				TextureCubemap cubemap = new();

				rlDisableBackfaceCulling();     // Disable backface culling to render inside the cube

				// STEP 1: Setup framebuffer
				//------------------------------------------------------------------------------------------
				uint rbo = rlLoadTextureDepth(size, size, true);
				cubemap.id = rlLoadTextureCubemap(0, size, format);

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
				rlSetUniformMatrix(shader.locs[SHADER_LOC_MATRIX_PROJECTION], matFboProjection);

				// Define view matrix for every side of the cubemap
				Matrix fboViews[6] = new(
					MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
				MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(-1.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f)),
				MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 1.0f)),
				MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, -1.0f, 0.0f), new(0.0f, 0.0f, -1.0f)),
				MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, 1.0f), new(0.0f, -1.0f, 0.0f)),
				MatrixLookAt(new(0.0f, 0.0f, 0.0f), new(0.0f, 0.0f, -1.0f), new(0.0f, -1.0f, 0.0f))
			);

				rlViewport(0, 0, size, size);   // Set viewport to current fbo dimensions

				// Activate and enable texture for drawing to cubemap faces
				rlActiveTextureSlot(0);
				rlEnableTexture(panorama.id);

				for (int i = 0; i < 6; i++)
				{
					// Set the view matrix for the current cube face
					rlSetUniformMatrix(shader.locs[SHADER_LOC_MATRIX_VIEW], fboViews[i]);

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
				cubemap.format = format;

				return cubemap;
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

# include "raylib.h"

# include <math.h>

			int main()
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
					float scale = (2.0f + (float)sin(time)) * 0.7f;

					// Move camera around the scene
					double cameraTime = time * 0.3;
					camera.position.X = (float)cos(cameraTime) * 40.0f;
					camera.position.Z = (float)sin(cameraTime) * 40.0f;
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
								float scatter = sinf(blockScale * 20.0f + (float)(time * 4.0f));

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

# include "raylib.h"

# include "raymath.h"        // Required for: Matrix4x4.CreateFromYawPitchRoll()

			int main(void)
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
					if (IsKeyDown(KEY_LEFT)) roll += 1.0f;
					else if (IsKeyDown(KEY_RIGHT)) roll -= 1.0f;
					else
					{
						if (roll > 0.0f) roll -= 0.5f;
						else if (roll < 0.0f) roll += 0.5f;
					}

					// Tranformation matrix for rotations
					model.transform = Matrix4x4.CreateFromYawPitchRoll(new Vector3(DEG2RAD * pitch, DEG2RAD * yaw, DEG2RAD * roll));
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


			/**********************************************************************************************
			*
			*   raylib.lights - Some useful functions to deal with lights data
			*
			*   CONFIGURATION:
			*
			*   #define RLIGHTS_IMPLEMENTATION
			*       Generates the implementation of the library into the included file.
			*       If not defined, the library is in header only mode and can be included in other headers 
			*       or source files without problems. But only ONE file should hold the implementation.
			*
			*   LICENSE: zlib/libpng
			*
			*   Copyright (c) 2017-2020 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
			*
			*   This software is provided "as-is", without any express or implied warranty. In no event
			*   will the authors be held liable for any damages arising from the use of this software.
			*
			*   Permission is granted to anyone to use this software for any purpose, including commercial
			*   applications, and to alter it and redistribute it freely, subject to the following restrictions:
			*
			*     1. The origin of this software must not be misrepresented; you must not claim that you
			*     wrote the original software. If you use this software in a product, an acknowledgment
			*     in the product documentation would be appreciated but is not required.
			*
			*     2. Altered source versions must be plainly marked as such, and must not be misrepresented
			*     as being the original software.
			*
			*     3. This notice may not be removed or altered from any source distribution.
			*
			**********************************************************************************************/

# ifndef RLIGHTS_H
#define RLIGHTS_H

			//----------------------------------------------------------------------------------
			// Defines and Macros
			//----------------------------------------------------------------------------------
#define MAX_LIGHTS            4         // Max dynamic lights supported by shader

			//----------------------------------------------------------------------------------
			// Types and Structures Definition
			//----------------------------------------------------------------------------------

			// Light data
			typedef struct {

	int type;
	Vector3 position;
	Vector3 target;
	Color color;
	bool enabled;

	// Shader locations
	int enabledLoc;
	int typeLoc;
	int posLoc;
	int targetLoc;
	int colorLoc;
}
Light;

// Light type
typedef enum {
	LIGHT_DIRECTIONAL,
	LIGHT_POINT
}
LightType;

# ifdef __cplusplus
extern "C" {            // Prevents name mangling of functions
#endif

	//----------------------------------------------------------------------------------
	// Module Functions Declaration
	//----------------------------------------------------------------------------------
	Light CreateLight(int type, Vector3 position, Vector3 target, Color color, Shader shader);   // Create a light and get shader locations
void UpdateLightValues(Shader shader, Light light);         // Send light properties to shader

# ifdef __cplusplus
}
#endif

#endif // RLIGHTS_H


/***********************************************************************************
*
*   RLIGHTS IMPLEMENTATION
*
************************************************************************************/

#if defined(RLIGHTS_IMPLEMENTATION)

# include "raylib.h"

//----------------------------------------------------------------------------------
// Defines and Macros
//----------------------------------------------------------------------------------
// ...

//----------------------------------------------------------------------------------
// Types and Structures Definition
//----------------------------------------------------------------------------------
// ...

//----------------------------------------------------------------------------------
// Global Variables Definition
//----------------------------------------------------------------------------------
static int lightsCount = 0;    // Current amount of created lights

//----------------------------------------------------------------------------------
// Module specific Functions Declaration
//----------------------------------------------------------------------------------
// ...

//----------------------------------------------------------------------------------
// Module Functions Definition
//----------------------------------------------------------------------------------

// Create a light and get shader locations
Light CreateLight(int type, Vector3 position, Vector3 target, Color color, Shader shader)
{
	Light light = new();

	if (lightsCount < MAX_LIGHTS)
	{
		light.enabled = true;
		light.type = type;
		light.position = position;
		light.target = target;
		light.color = color;

		// TODO: Below code doesn't look good to me, 
		// it assumes a specific shader naming and structure
		// Probably this implementation could be improved
		char enabledName[32] = "lights[x].enabled\0";
		char typeName[32] = "lights[x].type\0";
		char posName[32] = "lights[x].position\0";
		char targetName[32] = "lights[x].target\0";
		char colorName[32] = "lights[x].color\0";
		
		// Set location name [x] depending on lights count
		enabledName[7] = '0' + lightsCount;
		typeName[7] = '0' + lightsCount;
		posName[7] = '0' + lightsCount;
		targetName[7] = '0' + lightsCount;
		colorName[7] = '0' + lightsCount;

		light.enabledLoc = GetShaderLocation(shader, enabledName);
		light.typeLoc = GetShaderLocation(shader, typeName);
		light.posLoc = GetShaderLocation(shader, posName);
		light.targetLoc = GetShaderLocation(shader, targetName);
		light.colorLoc = GetShaderLocation(shader, colorName);

		UpdateLightValues(shader, light);
		
		lightsCount++;
	}

	return light;
}

// Send light properties to shader
// NOTE: Light shader locations should be available 
void UpdateLightValues(Shader shader, Light light)
{
	// Send to shader light enabled state and type
	SetShaderValue(shader, light.enabledLoc, &light.enabled, SHADER_UNIFORM_INT);
	SetShaderValue(shader, light.typeLoc, &light.type, SHADER_UNIFORM_INT);

	// Send to shader light position values
	float position[3] =new( light.position.X, light.position.Y, light.position.Z );
	SetShaderValue(shader, light.posLoc, position, SHADER_UNIFORM_VEC3);

	// Send to shader light target position values
	float target[3] =new( light.target.X, light.target.Y, light.target.Z );
	SetShaderValue(shader, light.targetLoc, target, SHADER_UNIFORM_VEC3);

	// Send to shader light color values
	float color[4] =new( (float)light.color.r/(float)255, (float)light.color.g/(float)255, 
					   (float)light.color.b/(float)255, (float)light.color.a/(float)255 );
	SetShaderValue(shader, light.colorLoc, color, SHADER_UNIFORM_VEC4);
}

#endif // RLIGHTS_IMPLEMENTATION

