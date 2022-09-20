## be sure to set your nuget publish key first:
# $env:NUGET_KEY = 'your_key'


######## STEPS TO NUGET DEPLOY:
# 0) set your NUGET_KEY as shown above
# 1) set nuget version in the csproj file
# 2) build RELEASE in visual studio, which will create the nuget package
# 3) checkin everything and tag the commit with the nuget version
# 4) run this script and pick the package you just built (if your key is set via env var, you can skip re-entering the key when prompted)

#help on passing args: https://morgantechspace.com/2014/12/How-to-pass-arguments-to-PowerShell-script.html
param( 
	[Parameter(Mandatory = $true, HelpMessage = "either set env:NUGET_KEY = 'your_key' or input it now.  if already set in env, just hit enter to use it.")] $NugetKey
	#, [Parameter(Mandatory = $true)] 	$NugetPackage
)
if (!($NugetKey)) {
	$NugetKey = $env:NUGET_KEY
}
Write-Output "Key Used: $NugetKey" 

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

