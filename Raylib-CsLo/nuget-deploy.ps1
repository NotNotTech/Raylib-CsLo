## be sure to set your nuget publish key first:
# $env:NUGET_KEY = 'your_key'


#help on passing args: https://morgantechspace.com/2014/12/How-to-pass-arguments-to-PowerShell-script.html
param( 
	[Parameter(Mandatory = $true, HelpMessage = "either set env:NUGET_KEY = 'your_key' or input it now")] $NugetKey
	#, [Parameter(Mandatory = $true)] 	$NugetPackage
)
if (!($NugetKey)) {
	$NugetKey = $env:NUGET_KEY
}

# change dir to folder containing script
pushd $PSScriptRoot


#Get-ChildItem -Path "$PSScriptRoot\bin\Release\" -Filter "*.nupkg" -Name |
#Select-Object -First 1 -Wait


Write-Output "********  SELECT NUGET PACKAGE FROM $PSScriptRoot ********  (see selection prompt)" 

# #$NugetPackage = "./bin/Release/Raylib-CsLo.4.0.0-rc.1.nupkg"

$NugetPackage = @(Get-ChildItem -Path "$PSScriptRoot\bin\Release\" -Filter "*.nupkg" -Name | Out-GridView -Title 'Choose a file' -PassThru)
$NugetPackage = "$PSScriptRoot\bin\Release\" + $NugetPackage




####################  DOESN'T WORK ANYMORE?
# Add-Type -AssemblyName System.Windows.Forms
# $FileBrowser = New-Object System.Windows.Forms.OpenFileDialog -Property @{
# 	Title            = "Select the nuget package to publish"
# 	Multiselect      = $false # Multiple files can be chosen
# 	InitialDirectory = "$PSScriptRoot\bin\Release\"
# 	Filter           = 'Nuget Packages (*.nupkg)|*.nupkg' # Specified file types	
# } 
# [void]$FileBrowser.ShowDialog()
# $NugetPackage = $FileBrowser.FileName;

Write-Output "********  YOUR NUGET DEPLOY COMMAND ******** "
Write-Output dotnet nuget push "$NugetPackage" --source https://api.nuget.org/v3/index.json --api-key $NugetKey
$response = read-host "Type 'makeitso' and Press enter to continue.  Anything else to abort"
if ($response -ne "makeitso") {
	"Aborted"
	Exit(-1)
}

dotnet nuget push "$NugetPackage" --source https://api.nuget.org/v3/index.json --api-key $NugetKey


popd
Write-Output "********  PUBLISH DONE! ******** "

