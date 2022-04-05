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
        bool runall = false; //set to true to run all, otherwise will show a gui to run specific tests

        List<int> bulkRunExampleIds=null;
        if (runall == true)
        {
            bulkRunExampleIds = new();
            for (var i = 0; i < 116;i++)
            {
                bulkRunExampleIds.Add(i);
            }
        }

        //debugging certain tests that need fixing
        bulkRunExampleIds = new() {48,66,11,112,113,114,115 };

        int choice = 0;
        while (choice != -1)
        {
            if (bulkRunExampleIds == null)
            {
                //the default: run an example via the picker
                choice = ExamplePicker.Example();
            }
            else
            {
                //run bulk examples then exit
                if (bulkRunExampleIds.Count == 0)
                {
                    break;
                }
                choice = bulkRunExampleIds[0];
                bulkRunExampleIds.RemoveAt(0);
            }

            switch (choice)
            {
                // Core
                case 0: BasicWindow.Example(); break;
                case 1: BasicScreenManager.Example(); break;
                case 2: InputKeys.Example(); break;
                case 3: InputMouse.Example(); break;
                case 4: InputMouseWheel.Example(); break;
                case 5: InputGamepad.Example(); break;
                case 6: InputMultitouch.Example(); break;
                case 7: InputGestures.Example(); break;
                case 8: Camera2d.Example(); break;
                case 9: Camera2dPlatformer.Example(); break;
                case 10: Camera3dMode.Example(); break;
                case 11: Camera3dFree.Example(); break;
                case 12: Camera3dFirstPerson.Example(); break;
                case 13: Picking3d.Example(); break;
                case 14: WorldScreen.Example(); break;
                case 15: CustomLogging.Example(); break;
                case 16: WindowLetterbox.Example(); break;
                case 17: DropFiles.Example(); break;
                case 18: ScissorTest.Example(); break;
                case 19: VrSimulator.Example(); break;
                case 20: QuatConversion.Example(); break;
                case 21: WindowFlags.Example(); break;
                case 22: SplitScreen.Example(); break;
                case 23: SmoothPixelperfect.Example(); break;
                case 24: CustomFrameControl.Example(); break;// The following example requires a custom build of raylib to work.see it's docs for info.

                // Models
                case 25: Animation.Example(); break;
                case 26: Billboard.Example(); break;
                case 27: BoxCollisions.Example(); break;
                case 28: Cubicmap.Example(); break;
                case 29: FirstPersonMaze.Example(); break;
                case 30: GeometricShapes.Example(); break;
                case 31: Heightmap.Example(); break;
                case 32: Loading.Example(); break;
                case 33: LoadingGltf.Example(); break;
                case 34: LoadingVox.Example(); break;
                case 35: MeshGeneration.Example(); break;
                case 36: MeshPicking.Example(); break;
                case 37: OrthographicProjection.Example(); break;
                case 38: RlglSolarSystem.Example(); break;
                case 39: Skybox.Example(); break;
                case 40: WavingCubes.Example(); break;
                case 41: YawPitchRoll.Example(); break;

                // Shaders
                case 42: BasicLighting.Example(); break;
                case 43: CustomUniform.Example(); break;
                case 44: Eratosthenes.Example(); break;
                case 45: Fog.Example(); break;
                case 46: HotReloading.Example(); break;
                case 47: JuliaSet.Example(); break;
                case 48: MeshInstancing.Example(); break;// FIXME I have no clue whats going on here
                case 49: ModelShader.Example(); break;
                case 50: MultiSample2d.Example(); break;
                case 51: PaletteColorSwitch.Example(); break;
                case 52: PostProcessing.Example(); break;
                case 53: Raymarching.Example(); break;
                case 54: ShapesAndTextureShaders.Example(); break;
                case 55: SimpleMask.Example(); break;
                case 56: Spotlight.Example(); break;
                case 57: TextureDrawing.Example(); break;
                case 58: TextureOutline.Example(); break;
                case 59: TextureWaves.Example(); break;

                // Textures
                case 60: BackgroundScrolling.Example(); break;
                case 61: BlendModes.Example(); break;
                case 62: Bunnymark.Example(); break;
                case 63: ImageDrawing.Example(); break;
                case 64: ImageGeneration.Example(); break;
                case 65: ImageLoading.Example(); break;
                case 66: ImageProcessing.Example(); break;// FIXME
                case 67: ImageText.Example(); break;
                case 68: LoadingAndDrawing.Example(); break;
                case 69: MousePainting.Example(); break;
                case 70: NPatchDrawing.Example(); break;
                case 71: ParticlesBlending.Example(); break;
                case 72: SpriteButton.Example(); break;
                case 73: SpriteExplosion.Example(); break;
                case 74: TexturedPolygon.Example(); break;
                case 75: TextureRawData.Example(); break;
                case 76: TextureRectangle.Example(); break;
                case 77: TextureSourceAndDestinationRectangles.Example(); break;
                case 78: TextureToImage.Example(); break;
                case 79: TiledTexture.Example(); break;

                // Text
                case 80: Draw2dIn3d.Example(); break;
                case 81: DrawTextInsideRectangle.Example(); break;
                case 82: FontFilters.Example(); break;
                case 83: FontLoading.Example(); break;
                case 84: RaylibFonts.Example(); break;
                case 85: InputBox.Example(); break;
                case 86: SdfFonts.Example(); break;
                case 87: SpriteFontLoading.Example(); break;
                case 88: TextFormatting.Example(); break;
                case 89: WritingAnimation.Example(); break;
                case 90: Unicode.Example(); break;// the unicode example doesn't work properly.  I guess the fonts don't include the needed unicode chars

                // Shapes
                case 91: BasicShapes.Example(); break;
                case 92: BouncingBall.Example(); break;
                case 93: CollisionArea.Example(); break;
                case 94: ColorsPalette.Example(); break;
                case 95: DrawCircleSector.Example(); break;
                case 96: DrawRectangleRounded.Example(); break;
                case 97: DrawRing.Example(); break;
                case 98: EasingsBallAnim.Example(); break;
                case 99: EasingsBoxAnim.Example(); break;
                case 100: EasingsRectangleArray.Example(); break;
                case 101: FollowingEyes.Example(); break;
                case 102: LogoAnimation.Example(); break;
                case 103: LogoUsingShapes.Example(); break;
                case 104: RectangleScalingMouse.Example(); break;
                case 105: LinesBezier.Example(); break;

                // Audio
                case 106: ModulePlaying.Example(); break;
                case 107: MultichannelSound.Example(); break;
                case 108: MusicStreaming.Example(); break;
                case 109: RawAudioStreaming.Example(); break;
                case 110: SoundLoadingAndPlaying.Example(); break;

                // Physics
                case 111: PhysicsDemo.Example(); break;// FIXME
                case 112: PhysicsFriction.Example(); break;// FIXME
                case 113: PhysicsMovement.Example(); break;// FIXME
                case 114: PhysicsRestitution.Example(); break;// FIXME
                case 115: PhysicsShatter.Example(); break;// FIXME

                default:
                break;
            }
        }
    }
}
