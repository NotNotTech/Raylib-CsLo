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
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ./raylib-4.0.0_win64_msvc16/include/ --file raylib.h --methodClassName Raylib --libraryPath raylib.dll --exclude PI DEG2RAD RAD2DEG
" ################ # raymath"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ./raylib-4.0.0_win64_msvc16/include/ --file raymath.h --methodClassName RayMath --libraryPath raylib.dll
#robocopy "./raylib-4.0.0_win64_msvc16/lib" "..\Raylib-CsLo\" raylib.dll
robocopy "." "..\Raylib-CsLo\" raylib.dll
##hack: replace malformed autogen content
$replaceFile = '../Raylib-CsLo/autogen/bindings/RayMath.cs'
(Get-Content $replaceFile).replace('.operator=', '=') | Set-Content $replaceFile
" ################ # rlgl"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ./raylib-4.0.0_win64_msvc16/include/ --file rlgl.h --methodClassName RlGl --libraryPath raylib.dll
" ################ # raygui"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ./raylib-4.0.0_win64_msvc16/include/ --file raygui.h --methodClassName RayGui --libraryPath raygui.dll
robocopy "." "..\Raylib-CsLo\" raygui.dll
" ################ # physac"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ../sub-modules/raylib/src/extras/ --include-directory ../sub-modules/raylib/src/ --file physac.h --methodClassName Physac --libraryPath physac.dll
" ################ # Easings "
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory ../sub-modules/raylib/src/extras/ --include-directory ../sub-modules/raylib/src/ --file easings.h --methodClassName Easings --exclude EaseElasticInOut PI DEG2RAD RAD2DEG

popd
