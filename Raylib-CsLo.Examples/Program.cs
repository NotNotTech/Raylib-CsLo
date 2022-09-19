// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the MPL-2.0.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]


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
global using Raylib_CsLo;
global using Raylib_CsLo.InternalHelpers;

global using static Raylib_CsLo.Raylib;
global using static Raylib_CsLo.RayMath;
global using static Raylib_CsLo.RayGui;
global using static Raylib_CsLo.RlGl;

global using static Raylib_CsLo.KeyboardKey;
global using static Raylib_CsLo.MouseButton;
global using static Raylib_CsLo.GamepadAxis;
global using static Raylib_CsLo.GamepadButton;
global using static Raylib_CsLo.Gesture;
global using static Raylib_CsLo.ConfigFlags;
global using static Raylib_CsLo.CameraProjection;
global using static Raylib_CsLo.CameraMode;
global using static Raylib_CsLo.TextureFilter;
global using static Raylib_CsLo.TextureWrap;
global using static Raylib_CsLo.ShaderUniformDataType;
global using static Raylib_CsLo.TraceLogLevel;
global using static Raylib_CsLo.MaterialMapIndex;
global using static Raylib_CsLo.CubemapLayout;
global using static Raylib_CsLo.PixelFormat;

global using static Raylib_CsLo.rlFramebufferAttachType;
global using static Raylib_CsLo.rlFramebufferAttachTextureType;
global using static Raylib_CsLo.rlShaderLocationIndex;


global using static Raylib_CsLo.ShaderAttributeDataType;
global using static Raylib_CsLo.ShaderLocationIndex;


global using static Raylib_CsLo.Examples.RLights;
global using static Raylib_CsLo.Examples.RLights.LightType;


global using static Raylib_CsLo.BlendMode;
global using static Raylib_CsLo.NPatchLayout;


global using static Raylib_CsLo.FontType;
global using static Raylib_CsLo.MouseCursor;


global using static Raylib_CsLo.Easings;
global using static Raylib_CsLo.Physac;

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


public static class Program
{


	public static void Main(params string[] args)
	{

		/////////////////////////////////////////
		////////////////////////  AUDIO
		Raylib_CsLo.Examples.Audio.ModulePlayingStreaming.main();
		//Raylib_CsLo.Examples.Audio.MultichannelSoundPlaying.main();
		Raylib_CsLo.Examples.Audio.MusicPlayingStreaming.main();
		Raylib_CsLo.Examples.Audio.RawAudioStreaming.main();
		Raylib_CsLo.Examples.Audio.SoundLoadingAndPlaying.main();


		/////////////////////////////////////////
		//////////////////////////  PHYSICS
		Raylib_CsLo.Examples.Physics.PhysicsDemo.main();
		Raylib_CsLo.Examples.Physics.PhysicsFriction.main();
		Raylib_CsLo.Examples.Physics.PhysicsMovement.main();
		Raylib_CsLo.Examples.Physics.PhysicsRestitution.main();
		Raylib_CsLo.Examples.Physics.PhysicsShatter.main();

		//Raylib_CsLo.Examples.Shaders.MeshInstancing.main();
		return;

		/////////////////////////////////////////
		/////////////////////////////////////////
		/////////////////////////////////////////
		///////////////////////  ALL THE EXAMPLES.   you can comment out the ones you don't want to run.
		/////////////////////////////////////////
		/////////////////////////////////////////
		/////////////////////////////////////////

		/////////////////////////////////////////
		//////////////////  CORE
		Raylib_CsLo.Examples.Core.BasicWindow.main();
		Raylib_CsLo.Examples.Core.BasicScreenManager.main();
		Raylib_CsLo.Examples.Core.KeyboardInput.main();
		Raylib_CsLo.Examples.Core.InputMouse.main();
		Raylib_CsLo.Examples.Core.InputMouseWheel.main();
		Raylib_CsLo.Examples.Core.GamepadInput.main();
		Raylib_CsLo.Examples.Core.InputMultitouch.main();
		Raylib_CsLo.Examples.Core.InputGesturesDetection.main();
		Raylib_CsLo.Examples.Core.Camera2d.main();
		Raylib_CsLo.Examples.Core.Camera2dPlatformer.main();
		Raylib_CsLo.Examples.Core.Camera3dMode.main();
		Raylib_CsLo.Examples.Core.Camera3dFree.main();
		Raylib_CsLo.Examples.Core.Camera3dFirstPerson.main();
		Raylib_CsLo.Examples.Core.Picking3d.main();
		Raylib_CsLo.Examples.Core.WorldToScreen.main();
		Raylib_CsLo.Examples.Core.CustomLogging.main();
		Raylib_CsLo.Examples.Core.WindowLetterbox.main();
		Raylib_CsLo.Examples.Core.WindowsDropFiles.main();
		Raylib_CsLo.Examples.Core.ScissorTest.main();
		Raylib_CsLo.Examples.Core.VrSimulator.main();
		Raylib_CsLo.Examples.Core.QuatConversions.main();
		Raylib_CsLo.Examples.Core.WindowFlags.main();
		Raylib_CsLo.Examples.Core.SplitScreen.main();
		Raylib_CsLo.Examples.Core.SmoothPixelPerfectCamera.main();
		//the following example requires a custom build of raylib to work.  see it's docs for info.
		Raylib_CsLo.Examples.Core.CustomFrameControl.main();


		/////////////////////////////////////////
		////////////  MODELS
		Raylib_CsLo.Examples.Models.Animation.main();
		Raylib_CsLo.Examples.Models.Billboard.main();
		Raylib_CsLo.Examples.Models.BoxCollisions.main();
		Raylib_CsLo.Examples.Models.Cubicmap.main();
		Raylib_CsLo.Examples.Models.FirstPersonMaze.main();
		Raylib_CsLo.Examples.Models.GeometricShapes.main();
		Raylib_CsLo.Examples.Models.Heightmap.main();
		Raylib_CsLo.Examples.Models.Loading.main();
		Raylib_CsLo.Examples.Models.LoadingGltf.main();
		Raylib_CsLo.Examples.Models.LoadingVox.main();
		Raylib_CsLo.Examples.Models.MeshGeneration.main();
		Raylib_CsLo.Examples.Models.MeshPicking.main();
		Raylib_CsLo.Examples.Models.OrthographicProjection.main();
		Raylib_CsLo.Examples.Models.RlglSolarSystem.main();
		Raylib_CsLo.Examples.Models.Skybox.main();
		Raylib_CsLo.Examples.Models.WavingCubes.main();
		Raylib_CsLo.Examples.Models.YawPitchRoll.main();


		/////////////////////////////////////////
		////////// SHADERS
		Raylib_CsLo.Examples.Shaders.BasicLighting.main();
		Raylib_CsLo.Examples.Shaders.CustomUniform.main();
		Raylib_CsLo.Examples.Shaders.Eratosthenes.main();
		Raylib_CsLo.Examples.Shaders.Fog.main();
		Raylib_CsLo.Examples.Shaders.HotReloading.main();
		Raylib_CsLo.Examples.Shaders.JuliaSet.main();
		Raylib_CsLo.Examples.Shaders.MeshInstancing.main();
		Raylib_CsLo.Examples.Shaders.ModelShader.main();
		Raylib_CsLo.Examples.Shaders.MultiSample2d.main();
		Raylib_CsLo.Examples.Shaders.PaletteColorSwitch.main();
		Raylib_CsLo.Examples.Shaders.PostProcessingShader.main();
		Raylib_CsLo.Examples.Shaders.RaymarchingShapes.main();
		Raylib_CsLo.Examples.Shaders.ShapesAndTextureShaders.main();
		Raylib_CsLo.Examples.Shaders.SimpleMask.main();
		Raylib_CsLo.Examples.Shaders.Spotlight.main();
		Raylib_CsLo.Examples.Shaders.TextureDrawing.main();
		Raylib_CsLo.Examples.Shaders.TextureOutline.main();
		Raylib_CsLo.Examples.Shaders.TextureWaves.main();


		/////////////////////////////////////////
		////////////  TEXTURES
		Raylib_CsLo.Examples.Textures.BackgroundScrolling.main();
		Raylib_CsLo.Examples.Textures.BlendModes.main();
		Raylib_CsLo.Examples.Textures.Bunnymark.main();
		Raylib_CsLo.Examples.Textures.ImageDrawing.main();
		Raylib_CsLo.Examples.Textures.ImageGeneration.main();
		Raylib_CsLo.Examples.Textures.ImageLoading.main();
		Raylib_CsLo.Examples.Textures.ImageProcessing.main();
		Raylib_CsLo.Examples.Textures.ImageTextDrawing.main();
		Raylib_CsLo.Examples.Textures.LoadingAndDrawing.main();
		Raylib_CsLo.Examples.Textures.MousePainting.main();
		Raylib_CsLo.Examples.Textures.NPatchDrawing.main();
		Raylib_CsLo.Examples.Textures.ParticlesBlending.main();
		Raylib_CsLo.Examples.Textures.SpriteButton.main();
		Raylib_CsLo.Examples.Textures.SpriteExplosion.main();
		Raylib_CsLo.Examples.Textures.TexturedPolygon.main();
		Raylib_CsLo.Examples.Textures.TextureFromRawData.main();
		Raylib_CsLo.Examples.Textures.TextureRectangle.main();
		Raylib_CsLo.Examples.Textures.TextureSourceAndDestinationRectangles.main();
		Raylib_CsLo.Examples.Textures.TextureToImage.main();
		Raylib_CsLo.Examples.Textures.TiledExture.main();


		/////////////////////////////////////////
		//////////////////// TEXT
		Raylib_CsLo.Examples.Text.Draw2dIn3d.main();
		Raylib_CsLo.Examples.Text.DrawTextInsideRectangle.main();
		Raylib_CsLo.Examples.Text.FontFilters.main();
		Raylib_CsLo.Examples.Text.FontLoading.main();
		Raylib_CsLo.Examples.Text.FontLoadingUsage.main();
		Raylib_CsLo.Examples.Text.InputBox.main();
		Raylib_CsLo.Examples.Text.SdfFonts.main();
		Raylib_CsLo.Examples.Text.SpriteFontLoading.main();
		Raylib_CsLo.Examples.Text.TextFormatting.main();
		Raylib_CsLo.Examples.Text.WritingAnimation.main();
		///////////// the unicode example doesn't work properly.  I guess the fonts don't include the needed unicode chars
		Raylib_CsLo.Examples.Text.Unicode.main();


		/////////////////////////////////////////
		////////////////////// SHAPES
		Raylib_CsLo.Examples.Shapes.BasicShapesDrawing.main();
		Raylib_CsLo.Examples.Shapes.BoundingBall.main();
		Raylib_CsLo.Examples.Shapes.CollisionArea.main();
		Raylib_CsLo.Examples.Shapes.ColorsPalette.main();
		Raylib_CsLo.Examples.Shapes.DrawCircleSector.main();
		Raylib_CsLo.Examples.Shapes.DrawRectangleRounded.main();
		Raylib_CsLo.Examples.Shapes.DrawRing.main();
		Raylib_CsLo.Examples.Shapes.EasingsBallAnim.main();
		Raylib_CsLo.Examples.Shapes.EasingsBoxAnim.main();
		Raylib_CsLo.Examples.Shapes.EasingsRectangleArray.main();
		Raylib_CsLo.Examples.Shapes.FollowingEyes.main();
		Raylib_CsLo.Examples.Shapes.LogoAnimation.main();
		Raylib_CsLo.Examples.Shapes.LogoUsingShapes.main();
		Raylib_CsLo.Examples.Shapes.RectangleScalingMouse.main();
		Raylib_CsLo.Examples.Shapes.LinesCubicBezier.main();


		/////////////////////////////////////////
		////////////////////////  AUDIO
		Raylib_CsLo.Examples.Audio.ModulePlayingStreaming.main();
		Raylib_CsLo.Examples.Audio.MultichannelSoundPlaying.main();
		Raylib_CsLo.Examples.Audio.MusicPlayingStreaming.main();
		Raylib_CsLo.Examples.Audio.RawAudioStreaming.main();
		Raylib_CsLo.Examples.Audio.SoundLoadingAndPlaying.main();


		/////////////////////////////////////////
		//////////////////////////  PHYSICS
		Raylib_CsLo.Examples.Physics.PhysicsDemo.main();
		Raylib_CsLo.Examples.Physics.PhysicsFriction.main();
		Raylib_CsLo.Examples.Physics.PhysicsMovement.main();
		Raylib_CsLo.Examples.Physics.PhysicsRestitution.main();
		Raylib_CsLo.Examples.Physics.PhysicsShatter.main();

	}

	
}
