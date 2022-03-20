// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

/*******************************************************************************************
*
*   raylib [core] example - 2d camera platformer
*
*   This example has been created using raylib 2.5 (www.raylib.com)
*   raylib is licensed under an unmodified zlib/libpng license (View raylib.h for details)
*
*   Example contributed by arvyy (@arvyy) and reviewed by Ramon Santamaria (@raysan5)
*
*   Copyright (c) 2019 arvyy (@arvyy)
*
********************************************************************************************/


namespace Raylib_CsLo.Examples.Core;



public static unsafe class Camera2dPlatformer
{
    public class Player
    {
        public Vector2 position;
        public float speed;
        public bool canJump;
    }

    public class EnvItem
    {
        public Rectangle rect;
        public int blocking;
        public Color color;
    }

    internal static class DefineConstants
    {
        public const int G = 400;
        public const float PLAYER_JUMP_SPD = 350.0f;
        public const float PLAYER_HOR_SPD = 200.0f;
    }

    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static float UpdateCameraEvenOutOnLanding_evenOutSpeed = 700F;
    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static int UpdateCameraEvenOutOnLanding_eveningOut;
    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static float UpdateCameraEvenOutOnLanding_evenOutTarget;

    public static void UpdateCameraEvenOutOnLanding(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height)
    {
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static float evenOutSpeed = 700;
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static int eveningOut = false;
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static float evenOutTarget;

        camera.offset = new(
            width / 2.0f, height / 2.0f
        );
        camera.target.X = player.position.X;

        if (UpdateCameraEvenOutOnLanding_eveningOut != 0)
        {
            if (UpdateCameraEvenOutOnLanding_evenOutTarget > camera.target.Y)
            {
                camera.target.Y += UpdateCameraEvenOutOnLanding_evenOutSpeed * delta;

                if (camera.target.Y > UpdateCameraEvenOutOnLanding_evenOutTarget)
                {
                    camera.target.Y = UpdateCameraEvenOutOnLanding_evenOutTarget;
                    UpdateCameraEvenOutOnLanding_eveningOut = 0;
                }
            }
            else
            {
                camera.target.Y -= UpdateCameraEvenOutOnLanding_evenOutSpeed * delta;

                if (camera.target.Y < UpdateCameraEvenOutOnLanding_evenOutTarget)
                {
                    camera.target.Y = UpdateCameraEvenOutOnLanding_evenOutTarget;
                    UpdateCameraEvenOutOnLanding_eveningOut = 0;
                }
            }
        }
        else
        {
            if (player.canJump && (player.speed == 0F) && (player.position.Y != camera.target.Y))
            {
                UpdateCameraEvenOutOnLanding_eveningOut = 1;
                UpdateCameraEvenOutOnLanding_evenOutTarget = player.position.Y;
            }
        }
    }

    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static Vector2 UpdateCameraPlayerBoundsPush_bbox = new(0.2f, 0.2f);

    public static void UpdateCameraPlayerBoundsPush(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height)
    {
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static Vector2 bbox = { 0.2f, 0.2f };

        Vector2 bboxWorldMin = GetScreenToWorld2D(new((1 - UpdateCameraPlayerBoundsPush_bbox.X) * 0.5f * width, (1 - UpdateCameraPlayerBoundsPush_bbox.Y) * 0.5f * height), camera);
        Vector2 bboxWorldMax = GetScreenToWorld2D(new((1 + UpdateCameraPlayerBoundsPush_bbox.X) * 0.5f * width, (1 + UpdateCameraPlayerBoundsPush_bbox.Y) * 0.5f * height), camera);
        camera.offset = new(
            (1 - UpdateCameraPlayerBoundsPush_bbox.X) * 0.5f * width, (1 - UpdateCameraPlayerBoundsPush_bbox.Y) * 0.5f * height
        );

        if (player.position.X < bboxWorldMin.X)
        {
            camera.target.X = player.position.X;
        }
        if (player.position.Y < bboxWorldMin.Y)
        {
            camera.target.Y = player.position.Y;
        }
        if (player.position.X > bboxWorldMax.X)
        {
            camera.target.X = bboxWorldMin.X + (player.position.X - bboxWorldMax.X);
        }
        if (player.position.Y > bboxWorldMax.Y)
        {
            camera.target.Y = bboxWorldMin.Y + (player.position.Y - bboxWorldMax.Y);
        }
    }

    public static void UpdatePlayer(Player player, EnvItem[] envItems, int envItemsLength, float delta)
    {
        if (IsKeyDown(KeyLeft))
        {
            player.position.X -= DefineConstants.PLAYER_HOR_SPD * delta;
        }
        if (IsKeyDown(KeyRight))
        {
            player.position.X += DefineConstants.PLAYER_HOR_SPD * delta;
        }
        if (IsKeyDown(KeySpace) && player.canJump)
        {
            player.speed = -DefineConstants.PLAYER_JUMP_SPD;
            player.canJump = false;
        }

        int hitObstacle = 0;
        for (int i = 0; i < envItemsLength; i++)
        {
            EnvItem ei = envItems[i];
            Vector2 p = player.position;
            if (ei.blocking != 0 && ei.rect.X <= p.X && ei.rect.X + ei.rect.Width >= p.X && ei.rect.Y >= p.Y && ei.rect.Y < p.Y + (player.speed * delta))
            {
                hitObstacle = 1;
                player.speed = 0.0f;
                p.Y = ei.rect.Y;
            }
        }

        if (hitObstacle == 0)
        {
            player.position.Y += player.speed * delta;
            player.speed += DefineConstants.G * delta;
            player.canJump = false;
        }
        else
        {
            player.canJump = true;
        }
    }

    public static void UpdateCameraCenter(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height)
    {
        camera.offset = new(
            width / 2.0f, height / 2.0f
        );
        camera.target = player.position;
    }

    public static void UpdateCameraCenterInsideMap(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height)
    {
        camera.target = player.position;
        camera.offset = new(
            width / 2.0f, height / 2.0f
        );
        float minX = 1000F;
        float minY = 1000F;
        float maxX = -1000F;
        float maxY = -1000F;

        for (int i = 0; i < envItemsLength; i++)
        {
            EnvItem ei = envItems[i];
            minX = MathF.Min(ei.rect.X, minX);
            maxX = MathF.Max(ei.rect.X + ei.rect.Width, maxX);
            minY = MathF.Min(ei.rect.Y, minY);
            maxY = MathF.Max(ei.rect.Y + ei.rect.Height, maxY);

        }

        Vector2 max = GetWorldToScreen2D(new(maxX, maxY), camera);
        Vector2 min = GetWorldToScreen2D(new(minX, minY), camera);

        if (max.X < width)
        {
            camera.offset.X = width - (max.X - (width / 2));
        }
        if (max.Y < height)
        {
            camera.offset.Y = height - (max.Y - (height / 2));
        }
        if (min.X > 0)
        {
            camera.offset.X = (width / 2) - min.X;
        }
        if (min.Y > 0)
        {
            camera.offset.Y = (height / 2) - min.Y;
        }
    }
    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static float UpdateCameraCenterSmoothFollow_minSpeed = 30F;
    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static float UpdateCameraCenterSmoothFollow_minEffectLength = 10F;
    //C++ TO C# CONVERTER NOTE: This was formerly a static local variable declaration (not allowed in C#):
    internal static float UpdateCameraCenterSmoothFollow_fractionSpeed = 0.8f;

    public static void UpdateCameraCenterSmoothFollow(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height)
    {
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static float minSpeed = 30;
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static float minEffectLength = 10;
        //C++ TO C# CONVERTER NOTE: This static local variable declaration (not allowed in C#) has been moved just prior to the method:
        //	static float fractionSpeed = 0.8f;

        camera.offset = new(
            width / 2.0f, height / 2.0f
        );
        Vector2 diff = Vector2.Subtract(player.position, camera.target);
        float length = diff.Length();

        if (length > UpdateCameraCenterSmoothFollow_minEffectLength)
        {
            float speed = MathF.Max(UpdateCameraCenterSmoothFollow_fractionSpeed * length, UpdateCameraCenterSmoothFollow_minSpeed);
            camera.target = Vector2.Add(camera.target, diff * (speed * delta / length));
        }
    }
    public static int Example()
    {
        // Initialization

        const int screenWidth = 800;
        const int screenHeight = 450;

        InitWindow(screenWidth, screenHeight, "raylib [core] example - 2d camera");

        Player player = new();
        player.position = new(
            400, 280
        );
        player.speed = 0F;
        player.canJump = false;
        EnvItem[] envItems =
        {
            new EnvItem() {rect = new(0, 0, 1000, 400), blocking = 0, color = Lightgray},
            new EnvItem() {rect = new(0, 400, 1000, 200), blocking = 1, color = Gray},
            new EnvItem() {rect = new(300, 200, 400, 10), blocking = 1, color = Gray},
            new EnvItem() {rect = new(250, 300, 100, 10), blocking = 1, color = Gray},
            new EnvItem() {rect = new(650, 300, 100, 10), blocking = 1, color = Gray}
        };

        //C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
        //ORIGINAL LINE: int envItemsLength = sizeof(envItems)/sizeof(envItems[0]);
        int envItemsLength = envItems.Length;

        Camera2D camera = new();
        camera.target = player.position;
        camera.offset = new(
            screenWidth / 2.0f, screenHeight / 2.0f
        );
        camera.rotation = 0.0f;
        camera.zoom = 1.0f;

        // Store pointers to the multiple update camera functions
        //C++ TO C# CONVERTER TODO TASK: The following line could not be converted:
        //cameraUpdatersDelegate cameraUpdaters[] = { UpdateCameraCenter, UpdateCameraCenterInsideMap, UpdateCameraCenterSmoothFollow, UpdateCameraEvenOutOnLanding, UpdateCameraPlayerBoundsPush };
        CameraUpdaters[] cameraUpdaters = { UpdateCameraCenter, UpdateCameraCenterInsideMap, UpdateCameraCenterSmoothFollow, UpdateCameraEvenOutOnLanding, UpdateCameraPlayerBoundsPush };

        int cameraOption = 0;
        //C++ TO C# CONVERTER WARNING: This 'sizeof' ratio was replaced with a direct reference to the array length:
        //ORIGINAL LINE: int cameraUpdatersLength = sizeof(cameraUpdaters)/sizeof(cameraUpdaters[0]);
        int cameraUpdatersLength = cameraUpdaters.Length;

        string[] cameraDescriptions = { "Follow player center", "Follow player center, but clamp to map edges", "Follow player center; smoothed", "Follow player center horizontally; updateplayer center vertically after landing", "Player push camera on getting too close to screen edge" };

        SetTargetFPS(60);


        // Main game loop
        while (!WindowShouldClose())
        {
            // Update

            float deltaTime = GetFrameTime();

            UpdatePlayer(player, envItems, envItemsLength, deltaTime);

            camera.zoom += (float)GetMouseWheelMove() * 0.05f;

            if (camera.zoom > 3.0f)
            {
                camera.zoom = 3.0f;
            }
            else if (camera.zoom < 0.25f)
            {
                camera.zoom = 0.25f;
            }

            if (IsKeyPressed(KeyR))
            {
                camera.zoom = 1.0f;
                player.position = new(
                    400, 280
                );
            }

            if (IsKeyPressed(KeyC))
            {
                cameraOption = (cameraOption + 1) % cameraUpdatersLength;
            }

            // Call update camera function by its pointer
            cameraUpdaters[cameraOption](ref camera, player, envItems, envItemsLength, deltaTime, screenWidth, screenHeight);


            // Draw

            BeginDrawing();

            ClearBackground(Lightgray);

            BeginMode2D(camera);

            for (int i = 0; i < envItemsLength; i++)
            {
                DrawRectangleRec(envItems[i].rect, envItems[i].color);
            }

            Rectangle playerRect = new((int)player.position.X - 20, (int)player.position.Y - 40, 40, 40);
            DrawRectangleRec(playerRect, Red);

            EndMode2D();

            DrawText("Controls:", 20, 20, 10, Black);
            DrawText("- Right/Left to move", 40, 40, 10, Darkgray);
            DrawText("- Space to jump", 40, 60, 10, Darkgray);
            DrawText("- Mouse Wheel to Zoom in-out, R to reset zoom", 40, 80, 10, Darkgray);
            DrawText("- C to change camera mode", 40, 100, 10, Darkgray);
            DrawText("Current camera mode:", 20, 120, 10, Black);
            DrawText(cameraDescriptions[cameraOption], 40, 140, 10, Darkgray);

            EndDrawing();

        }

        // De-Initialization

        CloseWindow(); // Close window and OpenGL context


        return 0;
    }

    public delegate void CameraUpdaters(ref Camera2D camera, Player player, EnvItem[] envItems, int envItemsLength, float delta, int width, int height);

}
