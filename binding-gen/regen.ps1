# change dir to folder containing script
pushd $PSScriptRoot
# cmd script: pushd %~dp0
del -Recurse -Force ..\Raylib-CsLo\autogen
del -Recurse -Force ..\Raylib-CsLo.Tests\autogen
# del /F /Q .\output
pushd ..\sub-modules\ClangSharp\
dotnet build -c Release
popd
# raylib
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file raylib.h --methodClassName Raylib
# raymath
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file raymath.h --methodClassName RayMath
robocopy "./raylib-4.0.0_win64_msvc16/lib" "..\Raylib-CsLo\" raylib.dll
#hack: replace malformed autogen content
$replaceFile = '../Raylib-CsLo/autogen/bindings/RayMath.cs'
(Get-Content $replaceFile).replace('.operator=', '=') | Set-Content $replaceFile

popd
