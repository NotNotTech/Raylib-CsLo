// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo


/////////////////////////////////////////
/////////////////////////////////////////
/////////////////////////////////////////
//all these `global using` statements are for convience in porting the examples.
//To allow the examples to be copy-pasted verbatum.
//if these statements were not here,
//all the examples would need to be modified: to prefix everything with the proper Class/Enum.
/////////////////////////////////////////
/////////////////////////////////////////
/////////////////////////////////////////


global using System.Numerics;
global using Raylib_CsLo.InternalHelpers;
global using static Raylib_CsLo.BlendMode;
global using static Raylib_CsLo.CameraMode;
global using static Raylib_CsLo.CameraProjection;
global using static Raylib_CsLo.ConfigFlags;
global using static Raylib_CsLo.CubemapLayout;
global using static Raylib_CsLo.Easings;
global using static Raylib_CsLo.Examples.RLights;
global using static Raylib_CsLo.Examples.RLights.LightType;
global using static Raylib_CsLo.FontType;
global using static Raylib_CsLo.GamepadAxis;
global using static Raylib_CsLo.GamepadButton;
global using static Raylib_CsLo.Gesture;
global using static Raylib_CsLo.KeyboardKey;
global using static Raylib_CsLo.MaterialMapIndex;
global using static Raylib_CsLo.MouseButton;
global using static Raylib_CsLo.MouseCursor;
global using static Raylib_CsLo.NPatchLayout;
global using static Raylib_CsLo.Physac;
global using static Raylib_CsLo.PixelFormat;
global using static Raylib_CsLo.RayguiS;
global using static Raylib_CsLo.RaylibS;
global using static Raylib_CsLo.RayMath;
global using static Raylib_CsLo.rlFramebufferAttachTextureType;
global using static Raylib_CsLo.rlFramebufferAttachType;
global using static Raylib_CsLo.RlGl;
global using static Raylib_CsLo.rlShaderLocationIndex;
global using static Raylib_CsLo.ShaderLocationIndex;
global using static Raylib_CsLo.ShaderUniformDataType;
global using static Raylib_CsLo.TextureFilter;
global using static Raylib_CsLo.TextureWrap;
global using static Raylib_CsLo.TraceLogLevel;
/////////////////////////////////////////
/////////////////////////////////////////
/////////////////////////////////////////
//The C examples use type aliases, so the following `global using * = ` lines are to match those.
/////////////////////////////////////////
/////////////////////////////////////////
/////////////////////////////////////////
global using Camera = Raylib_CsLo.Camera3D;
global using RenderTexture2D = Raylib_CsLo.RenderTexture;
global using Texture2D = Raylib_CsLo.Texture;
global using TextureCubemap = Raylib_CsLo.Texture;
global using Matrix = System.Numerics.Matrix4x4;


#pragma warning disable CA1050
public static class Program
#pragma warning restore CA1050
{
    public static void Main()
    {

        /////////////////////////////////////////
        /////////////////////////////////////////
        /////////////////////////////////////////
        ///////////////////////  ALL THE EXAMPLES.   you can comment out the ones you don't want to run.
        /////////////////////////////////////////
        /////////////////////////////////////////
        /////////////////////////////////////////

        /////////////////////////////////////////
        //////////////////  CORE
        // Raylib_CsLo.Examples.Core.BasicWindow.Example();
        // Raylib_CsLo.Examples.Core.BasicScreenManager.Example();
        // Raylib_CsLo.Examples.Core.KeyboardInput.Example();
        // Raylib_CsLo.Examples.Core.InputMouse.Example();
        // Raylib_CsLo.Examples.Core.InputMouseWheel.Example();
        // Raylib_CsLo.Examples.Core.GamepadInput.Example();
        // Raylib_CsLo.Examples.Core.InputMultitouch.Example();
        // Raylib_CsLo.Examples.Core.InputGesturesDetection.Example();
        // Raylib_CsLo.Examples.Core.Camera2d.Example();
        // Raylib_CsLo.Examples.Core.Camera2dPlatformer.Example();
        // Raylib_CsLo.Examples.Core.Camera3dMode.Example();
        // Raylib_CsLo.Examples.Core.Camera3dFree.Example();
        // Raylib_CsLo.Examples.Core.Camera3dFirstPerson.Example();
        // Raylib_CsLo.Examples.Core.Picking3d.Example();
        // Raylib_CsLo.Examples.Core.WorldToScreen.Example();
        // Raylib_CsLo.Examples.Core.CustomLogging.Example();
        // Raylib_CsLo.Examples.Core.WindowLetterbox.Example();
        // Raylib_CsLo.Examples.Core.WindowsDropFiles.Example();
        // Raylib_CsLo.Examples.Core.ScissorTest.Example();
        // Raylib_CsLo.Examples.Core.VrSimulator.Example();
        // Raylib_CsLo.Examples.Core.QuatConversions.Example();
        // Raylib_CsLo.Examples.Core.WindowFlags.Example();
        // Raylib_CsLo.Examples.Core.SplitScreen.Example();
        // Raylib_CsLo.Examples.Core.SmoothPixelPerfectCamera.Example();
        // //the following example requires a custom build of raylib to work.  see it's docs for info.
        // Raylib_CsLo.Examples.Core.CustomFrameControl.Example();


        /////////////////////////////////////////
        ////////////  MODELS
        // Raylib_CsLo.Examples.Models.Animation.Example();
        // Raylib_CsLo.Examples.Models.Billboard.Example();
        // Raylib_CsLo.Examples.Models.BoxCollisions.Example();
        Raylib_CsLo.Examples.Models.Cubicmap.Example();
        Raylib_CsLo.Examples.Models.FirstPersonMaze.Example();
        Raylib_CsLo.Examples.Models.GeometricShapes.Example();
        Raylib_CsLo.Examples.Models.Heightmap.Example();
        Raylib_CsLo.Examples.Models.Loading.Example();
        Raylib_CsLo.Examples.Models.LoadingGltf.Example();
        Raylib_CsLo.Examples.Models.LoadingVox.Example();
        Raylib_CsLo.Examples.Models.MeshGeneration.Example();
        Raylib_CsLo.Examples.Models.MeshPicking.Example();
        Raylib_CsLo.Examples.Models.OrthographicProjection.Example();
        Raylib_CsLo.Examples.Models.RlglSolarSystem.Example();
        Raylib_CsLo.Examples.Models.Skybox.Example();
        Raylib_CsLo.Examples.Models.WavingCubes.Example();
        Raylib_CsLo.Examples.Models.YawPitchRoll.Example();


        /////////////////////////////////////////
        ////////// SHADERS
        Raylib_CsLo.Examples.Shaders.BasicLighting.Example();
        Raylib_CsLo.Examples.Shaders.CustomUniform.Example();
        Raylib_CsLo.Examples.Shaders.Eratosthenes.Example();
        Raylib_CsLo.Examples.Shaders.Fog.Example();
        Raylib_CsLo.Examples.Shaders.HotReloading.Example();
        Raylib_CsLo.Examples.Shaders.JuliaSet.Example();
        Raylib_CsLo.Examples.Shaders.MeshInstancing.Example();
        Raylib_CsLo.Examples.Shaders.ModelShader.Example();
        Raylib_CsLo.Examples.Shaders.MultiSample2d.Example();
        Raylib_CsLo.Examples.Shaders.PaletteColorSwitch.Example();
        Raylib_CsLo.Examples.Shaders.PostProcessingShader.Example();
        Raylib_CsLo.Examples.Shaders.RaymarchingShapes.Example();
        Raylib_CsLo.Examples.Shaders.ShapesAndTextureShaders.Example();
        Raylib_CsLo.Examples.Shaders.SimpleMask.Example();
        Raylib_CsLo.Examples.Shaders.Spotlight.Example();
        Raylib_CsLo.Examples.Shaders.TextureDrawing.Example();
        Raylib_CsLo.Examples.Shaders.TextureOutline.Example();
        Raylib_CsLo.Examples.Shaders.TextureWaves.Example();


        /////////////////////////////////////////
        ////////////  TEXTURES
        Raylib_CsLo.Examples.Textures.BackgroundScrolling.Example();
        Raylib_CsLo.Examples.Textures.BlendModes.Example();
        Raylib_CsLo.Examples.Textures.Bunnymark.Example();
        Raylib_CsLo.Examples.Textures.ImageDrawing.Example();
        Raylib_CsLo.Examples.Textures.ImageGeneration.Example();
        Raylib_CsLo.Examples.Textures.ImageLoading.Example();
        Raylib_CsLo.Examples.Textures.ImageProcessing.Example();
        Raylib_CsLo.Examples.Textures.ImageTextDrawing.Example();
        Raylib_CsLo.Examples.Textures.LoadingAndDrawing.Example();
        Raylib_CsLo.Examples.Textures.MousePainting.Example();
        Raylib_CsLo.Examples.Textures.NPatchDrawing.Example();
        Raylib_CsLo.Examples.Textures.ParticlesBlending.Example();
        Raylib_CsLo.Examples.Textures.SpriteButton.Example();
        Raylib_CsLo.Examples.Textures.SpriteExplosion.Example();
        Raylib_CsLo.Examples.Textures.TexturedPolygon.Example();
        Raylib_CsLo.Examples.Textures.TextureFromRawData.Example();
        Raylib_CsLo.Examples.Textures.TextureRectangle.Example();
        Raylib_CsLo.Examples.Textures.TextureSourceAndDestinationRectangles.Example();
        Raylib_CsLo.Examples.Textures.TextureToImage.Example();
        Raylib_CsLo.Examples.Textures.TiledExture.Example();


        /////////////////////////////////////////
        //////////////////// TEXT
        Raylib_CsLo.Examples.Text.Draw2dIn3d.Example();
        Raylib_CsLo.Examples.Text.DrawTextInsideRectangle.Example();
        Raylib_CsLo.Examples.Text.FontFilters.Example();
        Raylib_CsLo.Examples.Text.FontLoading.Example();
        Raylib_CsLo.Examples.Text.FontLoadingUsage.Example();
        Raylib_CsLo.Examples.Text.InputBox.Example();
        Raylib_CsLo.Examples.Text.SdfFonts.Example();
        Raylib_CsLo.Examples.Text.SpriteFontLoading.Example();
        Raylib_CsLo.Examples.Text.TextFormatting.Example();
        Raylib_CsLo.Examples.Text.WritingAnimation.Example();
        ///////////// the unicode example doesn't work properly.  I guess the fonts don't include the needed unicode chars
        Raylib_CsLo.Examples.Text.Unicode.Example();


        /////////////////////////////////////////
        ////////////////////// SHAPES
        Raylib_CsLo.Examples.Shapes.BasicShapes.Example();
        Raylib_CsLo.Examples.Shapes.BoundingBall.Example();
        Raylib_CsLo.Examples.Shapes.CollisionArea.Example();
        Raylib_CsLo.Examples.Shapes.ColorsPalette.Example();
        Raylib_CsLo.Examples.Shapes.DrawCircleSector.Example();
        Raylib_CsLo.Examples.Shapes.DrawRectangleRounded.Example();
        Raylib_CsLo.Examples.Shapes.DrawRing.Example();
        Raylib_CsLo.Examples.Shapes.EasingsBallAnim.Example();
        Raylib_CsLo.Examples.Shapes.EasingsBoxAnim.Example();
        Raylib_CsLo.Examples.Shapes.EasingsRectangleArray.Example();
        Raylib_CsLo.Examples.Shapes.FollowingEyes.Example();
        Raylib_CsLo.Examples.Shapes.LogoAnimation.Example();
        Raylib_CsLo.Examples.Shapes.LogoUsingShapes.Example();
        Raylib_CsLo.Examples.Shapes.RectangleScalingMouse.Example();
        Raylib_CsLo.Examples.Shapes.LinesCubicBezier.Example();


        /////////////////////////////////////////
        ////////////////////////  AUDIO
        Raylib_CsLo.Examples.Audio.ModulePlayingStreaming.Example();
        Raylib_CsLo.Examples.Audio.MultichannelSoundPlaying.Example();
        Raylib_CsLo.Examples.Audio.MusicPlayingStreaming.Example();
        Raylib_CsLo.Examples.Audio.RawAudioStreaming.Example();
        Raylib_CsLo.Examples.Audio.SoundLoadingAndPlaying.Example();


        /////////////////////////////////////////
        //////////////////////////  PHYSICS
        Raylib_CsLo.Examples.Physics.PhysicsDemo.Example();
        Raylib_CsLo.Examples.Physics.PhysicsFriction.Example();
        Raylib_CsLo.Examples.Physics.PhysicsMovement.Example();
        Raylib_CsLo.Examples.Physics.PhysicsRestitution.Example();
        Raylib_CsLo.Examples.Physics.PhysicsShatter.Example();

    }


}
