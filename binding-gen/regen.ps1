# change dir to folder containing script
pushd $PSScriptRoot
# cmd script: pushd %~dp0
del -Recurse -Force ..\Raylib-CsLo\autogen
del -Recurse -Force ..\Raylib-CsLo.Tests\autogen
# del /F /Q .\output
pushd ..\sub-modules\ClangSharp\
dotnet build -c Release
popd
" ################ # raylib"
$RaylibReleaseDir = "./raylib-4.0.0_win64_msvc16/include/"
$RaylibSrc = "..\sub-modules\raylib\src"
$RaylibExtrasSrc = "../sub-modules/raylib/src/extras/"
$RayBin = "..\sub-modules\bin\Release.DLL\" 
$RayGuiSrc = "..\sub-modules\raygui"
$PhysacSrc = "..\sub-modules\physac"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file raylib.h --methodClassName Raylib --libraryPath raylib.dll --exclude PI DEG2RAD RAD2DEG
" ################ # raymath"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file raymath.h --methodClassName RayMath --libraryPath raylib.dll
#robocopy "./raylib-4.0.0_win64_msvc16/lib" "..\Raylib-CsLo\" raylib.dll
robocopy "$RayBin" "..\Raylib-CsLo\" raylib.dll raylib.pdb
##hack: replace malformed autogen content
$replaceFile = '../Raylib-CsLo/autogen/bindings/RayMath.cs'
(Get-Content $replaceFile).replace('.operator=', '=') | Set-Content $replaceFile
" ################ # rlgl"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file rlgl.h --methodClassName RlGl --libraryPath raylib.dll
" ################ # raygui"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RayGuiSrc" --file raygui.h --methodClassName RayGui --libraryPath raygui.dll --include-directory "$RaylibSrc"
robocopy "$RayBin" "..\Raylib-CsLo\" raygui.dll raygui.pdb
" ################ # physac"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$PhysacSrc" --include-directory ../sub-modules/raylib/src/ --file physac.h --methodClassName Physac --libraryPath physac.dll
robocopy "$RayBin" "..\Raylib-CsLo\" physac.dll physac.pdb
" ################ # Easings "
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibExtrasSrc" --include-directory ../sub-modules/raylib/src/ --file easings.h --methodClassName Easings --exclude EaseElasticInOut PI DEG2RAD RAD2DEG

popd
