// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples.Models;

/// <summary>/*******************************************************************************************
//*
//* raylib example - procedural mesh generation
//*
//* This example has been created using raylib 1.8 (www.raylib.com)
//* raylib is licensed under an unmodified zlib/libpng license(View raylib.h for details)
//*
//* Copyright(c) 2017 Ramon Santamaria(Ray San)
//*
//********************************************************************************************/
///</summary>
public static unsafe class MeshGeneration
{
    const int NUM_MODELS = 9;      // Parametric 3d shapes to generate


    static void AllocateMeshData(Mesh* mesh, int triangleCount)
    {
        mesh->vertexCount = triangleCount * 3;
        mesh->triangleCount = triangleCount;

        mesh->vertices = (float*)Raylib.MemAlloc(mesh->vertexCount * 3 * sizeof(float));
        mesh->texcoords = (float*)Raylib.MemAlloc(mesh->vertexCount * 2 * sizeof(float));
        mesh->normals = (float*)Raylib.MemAlloc(mesh->vertexCount * 3 * sizeof(float));
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
    public static void Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [models] example - mesh generation");

        // We generate a checked image for texturing
        Image checkedImage = GenImageChecked(2, 2, 1, 1, Red, Green);
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
        for (int i = 0; i < NUM_MODELS; i++)
        {
            models[i].materials[0].maps[(int)MaterialMapAlbedo].texture = texture;
        }

        // Define the camera to look into our 3d world
        Camera3D camera = new(new(5.0f, 5.0f, 5.0f), new(0.0f, 0.0f, 0.0f), new(0.0f, 1.0f, 0.0f), 45.0f, 0);

        // Model drawing position
        Vector3 position = new(0.0f, 0.0f, 0.0f);

        int currentModel = 0;

        SetCameraMode(camera, CameraOrbital);  // Set a orbital camera mode

        SetTargetFPS(60);               // Set our game to run at 60 frames-per-second


        // Main game loop
        while (!WindowShouldClose())    // Detect window close button or ESC key
        {
            // Update

            UpdateCamera(ref camera);      // Update internal camera and our camera

            if (IsMouseButtonPressed(MouseButtonLeft))
            {
                currentModel = (currentModel + 1) % NUM_MODELS; // Cycle between the textures
            }

            if (IsKeyPressed(KeyRight))
            {
                currentModel++;
                if (currentModel >= NUM_MODELS)
                {
                    currentModel = 0;
                }
            }
            else if (IsKeyPressed(KeyLeft))
            {
                currentModel--;
                if (currentModel < 0)
                {
                    currentModel = NUM_MODELS - 1;
                }
            }


            // Draw

            BeginDrawing();

            ClearBackground(Raywhite);

            BeginMode3D(camera);

            DrawModel(models[currentModel], position, 1.0f, White);
            DrawGrid(10, 1.0f);

            EndMode3D();

            DrawRectangle(30, 400, 310, 30, Fade(Skyblue, 0.5f));
            DrawRectangleLines(30, 400, 310, 30, Fade(Darkblue, 0.5f));
            DrawText("MOUSE LEFT BUTTON to CYCLE PROCEDURAL MODELS", 40, 410, 10, Blue);

            switch (currentModel)
            {
                case 0:
                DrawText("PLANE", 680, 10, 20, Darkblue);
                break;
                case 1:
                DrawText("CUBE", 680, 10, 20, Darkblue);
                break;
                case 2:
                DrawText("SPHERE", 680, 10, 20, Darkblue);
                break;
                case 3:
                DrawText("HEMISPHERE", 640, 10, 20, Darkblue);
                break;
                case 4:
                DrawText("CYLINDER", 680, 10, 20, Darkblue);
                break;
                case 5:
                DrawText("TORUS", 680, 10, 20, Darkblue);
                break;
                case 6:
                DrawText("KNOT", 680, 10, 20, Darkblue);
                break;
                case 7:
                DrawText("POLY", 680, 10, 20, Darkblue);
                break;
                case 8:
                DrawText("Parametric(custom)", 580, 10, 20, Darkblue);
                break;
                default:
                break;
            }

            EndDrawing();

        }

        // De-Initialization

        UnloadTexture(texture); // Unload texture

        // Unload models data (GPU VRAM)
        for (int i = 0; i < NUM_MODELS; i++)
        {
            UnloadModel(models[i]);
        }

        CloseWindow();          // Close window and OpenGL context



    }
}
