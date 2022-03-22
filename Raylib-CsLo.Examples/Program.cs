// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples;

using Raylib_CsLo.Examples.Audio;
using Raylib_CsLo.Examples.Core;
using Raylib_CsLo.Examples.Models;
using Raylib_CsLo.Examples.Physics;
using Raylib_CsLo.Examples.Shaders;
using Raylib_CsLo.Examples.Shapes;
using Raylib_CsLo.Examples.Text;
using Raylib_CsLo.Examples.Textures;

public static class Program
{
    public static void Main()
    {

        // CORE

        BasicWindow.Example();
        BasicScreenManager.Example();
        KeyboardInput.Example();
        InputMouse.Example();
        InputMouseWheel.Example();
        GamepadInput.Example();
        InputMultitouch.Example();
        InputGesturesDetection.Example();
        Camera2d.Example();
        Camera2dPlatformer.Example();
        Camera3dMode.Example();
        Camera3dFree.Example();
        Camera3dFirstPerson.Example();
        Picking3d.Example();
        WorldToScreen.Example();
        CustomLogging.Example();
        WindowLetterbox.Example();
        WindowsDropFiles.Example();
        ScissorTest.Example();
        VrSimulator.Example();
        QuatConversions.Example();
        WindowFlags.Example();
        SplitScreen.Example();
        SmoothPixelPerfectCamera.Example();
        CustomFrameControl.Example();// The following example requires a custom build of raylib to work.see it's docs for info.

        // MODELS

        Animation.Example();
        Billboard.Example();
        BoxCollisions.Example();
        Cubicmap.Example();
        FirstPersonMaze.Example();
        GeometricShapes.Example();
        Heightmap.Example();
        Loading.Example();
        LoadingGltf.Example();
        LoadingVox.Example();
        MeshGeneration.Example();
        MeshPicking.Example();
        OrthographicProjection.Example();
        RlglSolarSystem.Example();
        Skybox.Example();
        WavingCubes.Example();
        YawPitchRoll.Example();

        // SHADERS

        BasicLighting.Example();
        CustomUniform.Example();
        Eratosthenes.Example();
        Fog.Example();
        HotReloading.Example();
        JuliaSet.Example();
        MeshInstancing.Example();// FIXME I have no clue whats going on here
        ModelShader.Example();
        MultiSample2d.Example();
        PaletteColorSwitch.Example();
        PostProcessingShader.Example();
        RaymarchingShapes.Example();
        ShapesAndTextureShaders.Example();
        SimpleMask.Example();
        Spotlight.Example();
        TextureDrawing.Example();
        TextureOutline.Example();
        TextureWaves.Example();

        // TEXTURES

        BackgroundScrolling.Example();
        BlendModes.Example();
        Bunnymark.Example();
        ImageDrawing.Example();
        ImageGeneration.Example();
        ImageLoading.Example();
        ImageProcessing.Example();// FIXME
        ImageTextDrawing.Example();
        LoadingAndDrawing.Example();
        MousePainting.Example();
        NPatchDrawing.Example();
        ParticlesBlending.Example();
        SpriteButton.Example();
        SpriteExplosion.Example();
        TexturedPolygon.Example();
        TextureFromRawData.Example();
        TextureRectangle.Example();
        TextureSourceAndDestinationRectangles.Example();
        TextureToImage.Example();
        TiledTexture.Example();

        // TEXT

        Draw2dIn3d.Example();
        DrawTextInsideRectangle.Example();
        FontFilters.Example();
        FontLoading.Example();
        FontLoadingUsage.Example();
        InputBox.Example();
        SdfFonts.Example();
        SpriteFontLoading.Example();
        TextFormatting.Example();
        WritingAnimation.Example();
        Unicode.Example();// the unicode example doesn't work properly.  I guess the fonts don't include the needed unicode chars

        // SHAPES

        BasicShapes.Example();
        BoundingBall.Example();
        CollisionArea.Example();
        ColorsPalette.Example();
        DrawCircleSector.Example();
        DrawRectangleRounded.Example();
        DrawRing.Example();
        EasingsBallAnim.Example();
        EasingsBoxAnim.Example();
        EasingsRectangleArray.Example();
        FollowingEyes.Example();
        LogoAnimation.Example();
        LogoUsingShapes.Example();
        RectangleScalingMouse.Example();
        LinesCubicBezier.Example();

        // AUDIO

        ModulePlayingStreaming.Example();
        MultichannelSoundPlaying.Example();
        MusicPlayingStreaming.Example();
        RawAudioStreaming.Example();
        SoundLoadingAndPlaying.Example();

        // PHYSICS

        PhysicsDemo.Example();// FIXME
        PhysicsFriction.Example();// FIXME
        PhysicsMovement.Example();// FIXME
        PhysicsRestitution.Example();// FIXME
        PhysicsShatter.Example();// FIXME
    }
}
