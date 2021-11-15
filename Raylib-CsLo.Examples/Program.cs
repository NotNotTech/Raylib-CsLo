global using Raylib_CsLo;
global using static Raylib_CsLo.Raylib;
global using static Raylib_CsLo.KeyboardKey;
global using static Raylib_CsLo.MouseButton;
global using static Raylib_CsLo.GamepadAxis;
global using static Raylib_CsLo.GamepadButton;
global using static Raylib_CsLo.Gesture;
global using Raylib_CsLo.InternalHelpers;
global using static Raylib_CsLo.ConfigFlags;
global using Texture2D = Raylib_CsLo.Texture;

global using System.Numerics;

/* Tips:

1) To use the raylib Resources, add this to your .csproj file: <RunWorkingDirectory>$(MSBuildThisFileDirectory)</RunWorkingDirectory>
2) To use wrapper functions that differ only in return values, add an underscore at the end of the function name.   example:  Gesture gesture = Raylib.GetGestureDetected_()

*/

Raylib_CsLo.Examples.Core.BasicWindow.main();
Raylib_CsLo.Examples.Core.BasicScreenManager.main();
Raylib_CsLo.Examples.Core.KeyboardInput.main();
Raylib_CsLo.Examples.Core.InputMouse.main();
Raylib_CsLo.Examples.Core.InputMouseWheel.main();
Raylib_CsLo.Examples.Core.GamepadInput.main();
Raylib_CsLo.Examples.Core.InputMultitouch.main();
Raylib_CsLo.Examples.Core.InputGesturesDetection.main();



