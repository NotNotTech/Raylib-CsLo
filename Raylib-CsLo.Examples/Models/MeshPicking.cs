// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib[models] example - Mesh picking in 3d mode, ground plane, triangle, mesh
//*
//* This example has been created using raylib 1.7 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Example contributed by Joel Davis(@joeld42) and reviewed by Ramon Santamaria(@raysan5)
//*
//* Copyright(c) 2017 Joel Davis(@joeld42) and Ramon Santamaria(@raysan5)
//*
//********************************************************************************************/
///</summary>
public static class MeshPicking
{
    //#define FLT_MAX     340282346638528859811704183484516925440.0f     // Maximum value of a float, from bit pattern 01111111011111111111111111111111
    const float FLT_MAX = float.MaxValue;
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh picking");

        // Define the camera to look into our 3d world
        Camera3D camera = new();
        camera.position = new(20.0f, 20.0f, 20.0f); // Camera position
        camera.target = new(0.0f, 8.0f, 0.0f);      // Camera looking at point
        camera.up = new(0.0f, 1.6f, 0.0f);          // Camera up vector (rotation towards target)
        camera.fovy = 45.0f;                                // Camera field-of-view Y
        camera.Projection = CameraPerspective;             // Camera mode type

        Ray ray = new();        // Picking ray

        Model tower = LoadModel("resources/models/obj/turret.obj");                 // Load OBJ model
        Texture2D texture = LoadTexture("resources/models/obj/turret_diffuse.png"); // Load model texture
        tower.materials[0].maps[(int)MaterialMapAlbedo].texture = texture;            // Set model diffuse texture

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

        SetCameraMode(camera, CameraFree); // Set a free camera mode

        SetTargetFPS(60);                   // Set our game to run at 60 frames-per-second

        // Main game loop
        while (!WindowShouldClose())        // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);          // Update camera

            // Display information about closest hit
            RayCollision collision = new();
            string hitObjectName = "None";
            collision.distance = FLT_MAX;
            collision.hit = false;
            Color cursorColor = White;

            // Get ray and test against objects
            ray = GetMouseRay(GetMousePosition(), camera);

            // Check ray collision against ground quad
            RayCollision groundHitInfo = GetRayCollisionQuad(ray, g0, g1, g2, g3);

            if (groundHitInfo.hit && (groundHitInfo.distance < collision.distance))
            {
                collision = groundHitInfo;
                cursorColor = Green;
                hitObjectName = "Ground";
            }

            // Check ray collision against test triangle
            RayCollision triHitInfo = GetRayCollisionTriangle(ray, ta, tb, tc);

            if (triHitInfo.hit && (triHitInfo.distance < collision.distance))
            {
                collision = triHitInfo;
                cursorColor = Purple;
                hitObjectName = "Triangle";

                bary = Vector3Barycenter(collision.point, ta, tb, tc);
            }

            // Check ray collision against test sphere
            RayCollision sphereHitInfo = GetRayCollisionSphere(ray, sp, sr);

            if (sphereHitInfo.hit && (sphereHitInfo.distance < collision.distance))
            {
                collision = sphereHitInfo;
                cursorColor = Orange;
                hitObjectName = "Sphere";
            }

            // Check ray collision against bounding box first, before trying the full ray-mesh test
            RayCollision boxHitInfo = GetRayCollisionBox(ray, towerBBox);

            if (boxHitInfo.hit && (boxHitInfo.distance < collision.distance))
            {
                collision = boxHitInfo;
                cursorColor = Orange;
                hitObjectName = "Box";

                // Check ray collision against model
                // NOTE: It considers model.transform matrix!
                RayCollision meshHitInfo = GetRayCollisionModel(ray, tower);

                if (meshHitInfo.hit)
                {
                    collision = meshHitInfo;
                    cursorColor = Orange;
                    hitObjectName = "Mesh";
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            // Draw the tower
            // WARNING: If scale is different than 1.0f,
            // not considered by GetRayCollisionModel()
            DrawModel(tower, towerPos, 1.0f, White);

            // Draw the test triangle
            DrawLine3D(ta, tb, Purple);
            DrawLine3D(tb, tc, Purple);
            DrawLine3D(tc, ta, Purple);

            // Draw the test sphere
            DrawSphereWires(sp, sr, 8, 8, Purple);

            // Draw the mesh bbox if we hit it
            if (boxHitInfo.hit)
            {
                DrawBoundingBox(towerBBox, Lime);
            }

            // If we hit something, draw the cursor at the hit point
            if (collision.hit)
            {
                DrawCube(collision.point, 0.3f, 0.3f, 0.3f, cursorColor);
                DrawCubeWires(collision.point, 0.3f, 0.3f, 0.3f, Red);

                Vector3 normalEnd;
                normalEnd.X = collision.point.X + collision.normal.X;
                normalEnd.Y = collision.point.Y + collision.normal.Y;
                normalEnd.Z = collision.point.Z + collision.normal.Z;

                DrawLine3D(collision.point, normalEnd, Red);
            }

            DrawRay(ray, Maroon);

            DrawGrid(10, 10.0f);

            EndMode3D();

            // Draw some debug GUI text
            DrawText("Hit Object: " + hitObjectName, 10, 50, 10, Black);

            if (collision.hit)
            {
                int ypos = 70;

                DrawText("Distance: " + collision.distance.ToString("000.00"), 10, ypos, 10, Black);

                DrawText(string.Format("Hit Pos: {0} {1} {2}", collision.point.X.ToString("000.00"), collision.point.Y.ToString("000.00"), collision.point.Z.ToString("000.00")), 10, ypos + 15, 10, Black);

                DrawText(string.Format("Hit Norm: {0} {1} {2}", collision.normal.X.ToString("000.00"), collision.normal.Y.ToString("000.00"), collision.normal.Z.ToString("000.00")), 10, ypos + 30, 10, Black);

                if (triHitInfo.hit && TextIsEqual(hitObjectName, "Triangle"))
                {
                    DrawText(string.Format("Barycenter: {0} {1} {2}", bary.X.ToString("000.00"), bary.Y.ToString("000.00"), bary.Z.ToString("000.00")), 10, ypos + 45, 10, Black);
                }
            }

            DrawText("Use Mouse to Move Camera", 10, 430, 10, Gray);

            DrawText("(c) Turret 3D model by Alberto Cano", screenWidth - 200, screenHeight - 20, 10, Gray);

            DrawFPS(10, 10);

            EndDrawing();

        }

        // De-Initialization

        UnloadModel(tower);         // Unload model
        UnloadTexture(texture);     // Unload texture

        CloseWindow();              // Close window and OpenGL context



    }
}
