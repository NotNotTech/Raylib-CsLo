// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] 
// [!!] Copyright ©️ Raylib-CsLo and Contributors. 
// [!!] This file is licensed to you under the LGPL-2.1.
// [!!] See the LICENSE file in the project root for more info. 
// [!!] ------------------------------------------------- 
// [!!] The code ane examples are here! https://github.com/NotNotTech/Raylib-CsLo 
// [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!] [!!]  [!!] [!!] [!!] [!!]

global using System.Numerics;

global using Raylib_CsLo;
global using static Raylib_CsLo.Raylib;
global using static Raylib_CsLo.KeyboardKey;
global using static Raylib_CsLo.MouseButton;
global using static Raylib_CsLo.GamepadAxis;
global using static Raylib_CsLo.GamepadButton;
global using static Raylib_CsLo.Gesture;
global using Raylib_CsLo.InternalHelpers;
global using static Raylib_CsLo.ConfigFlags;
global using static Raylib_CsLo.CameraProjection;
global using static Raylib_CsLo.CameraMode;
global using static Raylib_CsLo.TextureFilter;
global using static Raylib_CsLo.TextureWrap;
global using static Raylib_CsLo.ShaderUniformDataType;

global using Camera = Raylib_CsLo.Camera3D;
global using Texture2D = Raylib_CsLo.Texture;
global using RenderTexture2D = Raylib_CsLo.RenderTexture;

global using Matrix = System.Numerics.Matrix4x4;






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
//Raylib_CsLo.Examples.Core.CustomFrameControl.main();


