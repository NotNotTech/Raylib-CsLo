# change dir to folder containing script
pushd $PSScriptRoot
# cmd script: pushd %~dp0
del -Recurse -Force ..\Raylib-CsLo\autogen
del -Recurse -Force ..\Raylib-CsLo.Tests\autogen
# del /F /Q .\output
pushd ..\sub-modules\ClangSharp\
dotnet build -c Release
popd

$RaylibSrc = "..\sub-modules\raylib\src"
$RaylibExtrasSrc = "../sub-modules/raylib/src/extras/"
$PhysacSrc = "../sub-modules/physac/src/"
$RayGuiSrc = "../sub-modules/raygui/src/"
$EasingsSrc = "../sub-modules/raylib/examples/others/"
$RayBin = "../sub-modules/raylib-with-extras/bin/Release.DLL/" 

" ################ # raylib"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file raylib.h --methodClassName Raylib --libraryPath raylib --exclude PI DEG2RAD RAD2DEG
" ################ # raymath"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file raymath.h --methodClassName RayMath --libraryPath raylib
#robocopy "./raylib-4.0.0_win64_msvc16/lib" "..\Raylib-CsLo\" raylib.dll
# robocopy "$RayBin" "..\Raylib-CsLo\" raylib.dll raylib.pdb

" ################ # rlgl"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RaylibSrc" --file rlgl.h --methodClassName RlGl --libraryPath raylib
" ################ # raygui"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$RayGuiSrc" --file raygui.h --methodClassName RayGui --libraryPath raylib --include-directory "$RaylibSrc"
# robocopy "$RayBin" "..\Raylib-CsLo\" raygui.dll raygui.pdb
" ################ # physac"
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$PhysacSrc" --include-directory "$RaylibSrc" --file physac.h --methodClassName Physac --libraryPath raylib
# robocopy "$RayBin" "..\Raylib-CsLo\" physac.dll physac.pdb
" ################ # Easings "
dotnet ..\sub-modules\ClangSharp\artifacts\bin\sources\ClangSharpPInvokeGenerator\Release\net6.0\ClangSharpPInvokeGenerator.dll @gen-raylib.rsp --file-directory "$EasingsSrc" --include-directory "$RaylibSrc" --file reasings.h --methodClassName Easings --exclude EaseElasticInOut PI DEG2RAD RAD2DEG

"########################## FIX UP FILES"

#Start-Sleep -Seconds 1
function Retry-Command {
	[CmdletBinding()]
	Param(
		[Parameter(Position = 0, Mandatory = $true)]
		[scriptblock]$ScriptBlock,

		[Parameter(Position = 1, Mandatory = $false)]
		[int]$Maximum = 5,

		[Parameter(Position = 2, Mandatory = $false)]
		[int]$Delay = 100
	)

	Begin {
		$cnt = 0
	}

	Process {
		do {
			$cnt++
			try {
				$ScriptBlock.Invoke()
				return
			}
			catch {
				Write-Error $_.Exception.InnerException.Message -ErrorAction Continue
				Start-Sleep -Milliseconds $Delay
			}
		} while ($cnt -lt $Maximum)

		# Throw an error after $Maximum unsuccessful invocations. Doesn't need
		# a condition, since the function returns upon successful invocation.
		throw 'Execution failed.'
	}
}

$path = "../Raylib-CsLo/autogen/bindings/"
foreach ($file in Get-ChildItem $path) {
	$target = $path + $file
	#Write-Output "=========  PROCESSING:        $target"
	##hack: replace malformed autogen content
	$tempContents = (Get-Content $target -Raw).replace('.operator=', '=')	
	# make all C bools marshal properly.   see: https://stackoverflow.com/a/4621621
	$tempContents = $tempContents.replace('public static extern Bool ', "[return: MarshalAs(UnmanagedType.U1)] public static extern bool ")
	$tempContents = $tempContents.replace(', Bool ', ", [MarshalAs(UnmanagedType.U1)] bool ")
	$tempContents = $tempContents.replace('(Bool ', "([MarshalAs(UnmanagedType.U1)] bool ")
	#write the file	
	$tempContents | Out-File -FilePath $target -NoNewline
	# $tempContents | Set-Content -Path $target
	# try {
	# 	Set-Content -Path $target -Value $tempContents
	# }
	# catch {	
	# 	try {
	# 		Set-Content -Path $target -Value $tempContents
	# 	}
	# 	catch {
	# 		Set-Content -Path $target -Value $tempContents
	# 	}
	# }
	# Retry-Command -ScriptBlock {
	# 	Set-Content -Path $target -Value $tempContents
	# }
}


popd

"########################## DONE!"