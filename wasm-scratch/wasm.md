from https://jeedify.com/gamedev/raylib/cswasm/

# Introduction
This is a step-by-step guide on how to build a small C# [Raylib](https://github.com/raysan5/raylib) demo project for WebAssembly using [Uno.Wasm.Bootstrap](https://github.com/unoplatform/Uno.Wasm.Bootstrap). 

**This guide will not use the official C# bindings for Raylib and will instead use just a few P/Invokes to build a small demo.  
Building an existing project for WebAssembly will require changes to the existing project's `csproj` file, this is not covered in this guide.  
However, this guide provides a `csrpoj` file that is set up to use `Uno.Wasm.Bootstrap`, so you can use it as a reference for your existing project.**

This guide assumes that you start from scratch, with none of the prerequisites installed. You can skip certain steps if you meet their requirements.  
Big thanks to [Caleb](https://twitter.com/TheSpydog) for [his post on how to build FNA games for WebAssembly](https://gist.github.com/TheSpydog/e94c8c23c01615a5a3b2cc1a0857415c), which helped me understand how to do the same with Raylib.

> *Note: All of the commands to run in Linux are meant to be as easy as possible to follow.  
Whenever there are multiple lines in one code block, simply copy & paste the **entire block** and press enter.  
**Do not** copy & paste line by line*

# Prerequisites
In order to build a C# Raylib project for WebAssembly we need the following:
* A Linux machine (I will be using WSL2 on Windows in this guide.)
* Mono with Mono's version of MSBuild (not all distros have Mono's MSBuild in their respective repo, so I will be using one that does, Ubuntu 20.04.)
* Emscripten.
* Raylib static library that was built with Emscripten (we will build this from source.)

# Installing WSL
> *If you are using Linux or already have WSL installed, you can skip this step.*  

1. Open up PowerShell or Command Prompt and run the following:  

```powershell
wsl --install
```
2. Reboot your computer once the installation is completed.

# Installing Ubuntu 20.04 on WSL
> *If you are using Linux or already have Ubuntu 20.04 installed in WSL, you can skip this step.*

1. Open up PowerShell or Command Prompt and run the following:  
```powershell
wsl --install -d Ubuntu-20.04
```
2. Once the installation is finished, you will be prompted to choose a username and a password, so choose these and continue to the next step.

# Setting up prerequisites
### 1. Make sure we are up to date
> *From this point forward, every time you are required to enter a sudo password, enter the password you've chosen in the previous step*

Update and upgrade the Ubuntu machine, run the following:
```bash
sudo apt update && sudo apt upgrade -y
```

### 2. Installing Mono
1. Add the [official Mono repo](https://www.mono-project.com/download/stable/#download-lin) in order to be able to install the latest Mono packages:
```bash
sudo apt install gnupg ca-certificates && \
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF && \
echo "deb https://download.mono-project.com/repo/ubuntu stable-focal main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list && \
sudo apt update
```
2. Install the `mono-devel` package (*note: Mono will precompile some of its modules, this might take a while, please be patient*):
```bash
sudo apt install -y mono-devel
```
### 3. Installing Ninja
Run the following:
```bash
sudo apt install ninja-build -y
```

### 4. Installing .NET
1. First, we need to make sure we have `wget` installed, this package is used to download files:
```bash
sudo apt install -y wget
```
2. Add the [official .NET SDK repo](https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu#2004-) in order to be able to install the official .NET 6 SDK package:
```bash
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
sudo dpkg -i packages-microsoft-prod.deb && \
rm packages-microsoft-prod.deb && \
sudo apt update && \
sudo apt install -y apt-transport-https && \
sudo apt update
```
3. Install the .NET SDK 6 package:
```bash
sudo apt install -y dotnet-sdk-6.0
```

### 5. Setting up Emscripten
1. First, we need to make sure we have `git` installed, this package is used to manage git repositories:
```bash
sudo apt install -y git
```
2. Clone the emsdk repo and enter the directory:
```bash
cd ~/ && \
git clone https://github.com/emscripten-core/emsdk.git && \
cd emsdk
```
3. Get the latest Emscripten tools and activate them:
```bash
git pull && \
./emsdk install latest && \
./emsdk activate latest
```

### 6. Building Raylib 4.0.0 for WebAssembly from source
1. First, we need to make sure we have `unzip` and `make` installed, `unzip` is used to extract the zipped source and `make` is used to instruct Emscripten using the Makefile on how to build Raylib:
```bash
sudo apt install -y unzip make
```
2. Download Raylib 4.0.0 source:
```bash
cd ~/ && \
wget https://github.com/raysan5/raylib/archive/refs/tags/4.0.0.zip
```
3. Extract the zip file and enter the `src` directory:
```bash
unzip 4.0.0.zip && \
cd raylib-4.0.0/src/
```
4. Set the emsdk environment variables for the current terminal session:
```bash
source ~/emsdk/emsdk_env.sh
```
5. Because we are using the emsdk script to set up environment variables, we don't need the relevant variables in the Makefile, so we can remove them:
```bash
sed -i '/    # Emscripten required variables/d' ./Makefile && \
sed -i '/    EMSDK_PATH         ?= C:\/emsdk/d' ./Makefile && \
sed -i '/    EMSCRIPTEN_PATH    ?= $(EMSDK_PATH)\/upstream\/emscripten/d' ./Makefile && \
sed -i '/    CLANG_PATH          = $(EMSDK_PATH)\/upstream\/bin/d' ./Makefile && \
sed -i '/    PYTHON_PATH         = $(EMSDK_PATH)\/python\/3.9.2-1_64bit/d' ./Makefile && \
sed -i '/    NODE_PATH           = $(EMSDK_PATH)\/node\/14.15.5_64bit\/bin/d' ./Makefile && \
sed -i '/    export PATH         = $(EMSDK_PATH);$(EMSCRIPTEN_PATH);$(CLANG_PATH);$(NODE_PATH);$(PYTHON_PATH);C:\\raylib\\MinGW\\bin:$$(PATH)/d' ./Makefile
```
6. Build Raylib:
```bash
make PLATFORM=PLATFORM_WEB -B
```

# Setting up a C# project
### 1. Creating the project
1. Go back to the home directory:
```bash
cd ~/
```
2. Create the project and enter the directory (we're going to name it `RaylibSharpWasmDemo`):
```bash
dotnet new console -o RaylibSharpWasmDemo && \
cd RaylibSharpWasmDemo/
```
3. Copy the Raylib static library from the previous Emscripten step to the C# project directory:
```bash
cp ~/raylib-4.0.0/src/libraylib.a raylib.a
```
4. Create two new empty files called `index.html` and `LinkerConfig.xml`:
```bash
touch index.html LinkerConfig.xml
```

### 2. Setting up a way to edit files
> *If you are on native Linux, simply ignore this step and use your favorite Linux text editor.*

We will now need to have a way to edit files in the project.  
If you've been following this guide throughout and you are using WSL, you can open the directory as a network folder in Windows, and then use your favorite text editor from within Windows.  
To do this, just run the following (in WSL):
```bash
explorer.exe .
```
> If you are getting an error saying `unable to find an interpreter for /mnt/c/Windows/explorer.exe` then do the following:  
In Windows, open up a new PowerShell or Command Prompt instance and run:  
`wsl --shutdown`  
This will kill all WSL running machines, then start the Ubuntu machine again with:  
`wsl -d Ubuntu-20.04`  
Once it has started, go back to the `RaylibSharpWasmDemo` directory and try again by running the following:  
`cd ~/RaylibSharpWasmDemo && explorer.exe .`  

### 3. index.html
> *Again, big thanks to [Caleb](https://twitter.com/TheSpydog) for [his post](https://gist.github.com/TheSpydog/e94c8c23c01615a5a3b2cc1a0857415c).*  

Open `index.html` with your favorite text editor and copy & paste the following:
```html
<!DOCTYPE html>
<html>

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent" />

    <script type="text/javascript" src="./require.js"></script>
    <script type="text/javascript" src="./mono-config.js"></script>
    <script type="text/javascript" src="./uno-config.js"></script>
    <script type="text/javascript" src="./uno-bootstrap.js"></script>
    <script type="text/javascript">
        /* These functions are supposed to be included by passing
         * -s DEFAULT_LIBRARY_FUNCS_TO_INCLUDE=[...] to the emcc linker,
         * but MSBuild makes it impossible to do that. Instead I copied
         * them from Emscripten's library.js directly into here. -caleb
         */
        function listenOnce(object, event, func) {
            object.addEventListener(event, func, { 'once': true });
        }
        function autoResumeAudioContext(ctx, elements) {
            if (!elements) {
                elements = [document, document.getElementById('canvas')];
            }
            ['keydown', 'mousedown', 'touchstart'].forEach(function (event) {
                elements.forEach(function (element) {
                    if (element) {
                        listenOnce(element, event, function () {
                            if (ctx.state === 'suspended') ctx.resume();
                        });
                    }
                });
            });
        }
        function dynCallLegacy(sig, ptr, args) {
            assert(('dynCall_' + sig) in Module, 'bad function pointer type - no table for sig \'' + sig + '\'');
            if (args && args.length) {
                // j (64-bit integer) must be passed in as two numbers [low 32, high 32].
                assert(args.length === sig.substring(1).replace(/j/g, '--').length);
            } else {
                assert(sig.length == 1);
            }
            var f = Module["dynCall_" + sig];
            return args && args.length ? f.apply(null, [ptr].concat(args)) : f.call(null, ptr);
        }
        function dynCall(sig, ptr, args) {
            if (sig.indexOf('j') != -1) {
                return dynCallLegacy(sig, ptr, args);
            }
            assert(wasmTable.get(ptr), 'missing table entry in dynCall: ' + ptr);
            return wasmTable.get(ptr).apply(null, args)
        }
    </script>
    <script async type="text/javascript" src="./dotnet.js"></script>
    $(ADDITIONAL_CSS)
    $(ADDITIONAL_HEAD)
</head>

<body>
    <div id="uno-body" class="container-fluid uno-body">
        <div class="uno-loader" loading-position="bottom" loading-alert="none">

            <!-- Logo: change src to customize the logo -->
            <img class="logo" src="" title="Uno is loading your application" />

            <progress></progress>
            <span class="alert"></span>
        </div>
    </div>
    <canvas id="canvas"></canvas>
    <script>
        // This is required for GLFW!
        Module.canvas = document.getElementById("canvas");
    </script>
    <noscript>
        <p>This application requires Javascript and WebAssembly to be enabled.</p>
    </noscript>
</body>

</html>
```

### 4. LinkerConfig.xml
> *This is not needed for this demo, but it's added a POC.  
This is sometimes needed when the linker mistakenly trims code that is actually needed.  
This file forces the linker to link types or full namespaces.  
For more information please read the [official Uno docs page](https://platform.uno/docs/articles/features/using-il-linker-webassembly.html).*  

Open `LinkerConfig.xml` with your favorite text editor and copy & paste the following:
```xml
<linker>
    <assembly fullname="RaylibSharpWasmDemo">
        <namespace fullname="Raylib" />
    </assembly>
</linker>
```

### 5. Program.cs
This will be our very simple demo code.  
Open `Program.cs` with your favorite text editor, delete its existing content (generated by `dotnet`) and replace it with the following:
```csharp
using System;
using System.Runtime.InteropServices;

namespace Raylib
{
    class Program
    {
        private const string _raylibFileName = "raylib";

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitWindow(int width, int height, [MarshalAs(UnmanagedType.LPUTF8Str)] string title);

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool WindowShouldClose();

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BeginDrawing();

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ClearBackground(Color color);

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawText([MarshalAs(UnmanagedType.LPUTF8Str)] string text, int posX, int posY, int fontSize, Color color);

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EndDrawing();

        [DllImport(_raylibFileName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void CloseWindow();

        [StructLayout(LayoutKind.Sequential)]
        public struct Color
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;

            public static Color Skyblue = new Color(102, 191, 255, 255);
            public static Color White = new Color(255, 255, 255, 255);
            public static Color Raywhite = new Color(245, 245, 245, 255);

            public Color(byte r, byte g, byte b, byte a)
            {
                R = r;
                G = g;
                B = b;
                A = a;
            }
        }

        static void Main(string[] args)
        {
            InitWindow(1280, 720, "Raylib C# WASM Demo");

            while (!WindowShouldClose())
            {
                BeginDrawing();
                ClearBackground(Color.Skyblue);

                DrawText("Hello from C#!", 10, 10, 20, Color.Raywhite);
                DrawText("Thanks to Uno :)", 10, 50, 20, Color.White);

                EndDrawing();
            }

            CloseWindow();
        }
    }
}
```

### 6. RaylibSharpWasmDemo.csproj
Open `RaylibSharpWasmDemo.csproj` with your favorite text editor, delete its content (generated by `dotnet`) and replace it with the following:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <TargetLatestRuntimePatch>true</TargetLatestRuntimePatch>
    <LangVersion>latest</LangVersion>
    <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
    <GenerateTargetFrameworkAttribute>false</GenerateTargetFrameworkAttribute>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <PropertyGroup>
    <WasmShellMonoRuntimeExecutionMode>InterpreterAndAOT</WasmShellMonoRuntimeExecutionMode>
    <WasmShellIndexHtmlPath>index.html</WasmShellIndexHtmlPath>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Uno.Wasm.Bootstrap" Version="3.1.3" />
    <PackageReference Include="Uno.Wasm.Bootstrap.DevServer" Version="3.1.3" />
    <LinkerDescriptor Include="LinkerConfig.xml" />
    <Content Include="raylib.a" />
    <WasmShellExtraEmccFlags Include="-s MIN_WEBGL_VERSION=2 -s MAX_WEBGL_VERSION=2 -s USE_GLFW=3 -s TOTAL_MEMORY=67108864 -s FORCE_FILESYSTEM=1 -s ASYNCIFY" />
  </ItemGroup>

</Project>
```

# Finally, building the project
> *Building takes quite a while. And the first build will take even longer as `Uno.Wasm.Bootsrap` will need to download the wasm runtime. Please be patient.*

Simply run (*back in WSL*):
```bash
dotnet build -c Release
```
The output will be at `RaylibSharpWasmDemo/bin/Release/net6.0/dist`

# Bonus - Test the build with `emrun`
> *This might not work with old Windows 10 builds, as older WSL builds are not configured to pass localhost requests to the running WSL machines.  
If the following doesn't work, simply serve the build (the content of the `dist` folder) with any other webserver, either locally on Windows or if you have a webserver set up somewhere else, you can use that instead.*

In order to actually test the build, we need a way to serve the html with the WebAssembly binaries.  
Luckily, Emscripten comes with a utility (`emrun`) that does just that. So if you don't have a webserver to test it on, you can use this utility.  
In WSL, run the following:
```bash
source ~/emsdk/emsdk_env.sh && \
emrun --no_browser --port 8080 ~/RaylibSharpWasmDemo/bin/Release/net6.0/dist
```
Now in Windows, open your browser and navigate to:  
http://127.0.0.1:8080/

# Markdown
You can view or download this page's markdown [here](./RaylibSharpWasmDemo.md).  
Feel free to use it however you like.
