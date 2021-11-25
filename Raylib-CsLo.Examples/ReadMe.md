# `Raylib-CsLo` Examples

These examples are direct ports of the original `raylib 4.0` examples, with as few modifications made to the original sources as possible.

Some important notes if you want to run/use/copy these examples:
- DotNet 6 `global using`
  - Refer to the top of `Program.cs` to see the various `using` statements.  This allows C# to emulate the scopes used by the original C examples, which lets us make minimal changes to the C code.
- Run this project to see all examples run in order.   you can simply comment out examples you don't want in the `Program.cs` file
- For Math/ConsolePrint/DateTime/FileIo, it would be better that you don't follow the examples, but rather "normal" dotnet workflows like using `System.Io.File` or math helpers found directly in `System.Numerics`.  Invoking native code is relatively expensive, adding perhaps `0.001ms` per call.  These native invokes were left as-is so that the original C code could be used with minimal changes.

Here are links to most the examples

| [`Core`](./Core/)                            | [`Shapes`](./Shapes/)                              | [`Textures`](./Textures/)                                | [`Text`](./Text/)                            | [`Models`](./Models/)                              | [`Shaders`](./Shaders/)                               | [`Audio`](./Audio/)                             | [`Physics`](./Physics/)                               |
| -------------------------------------------- | -------------------------------------------------- | -------------------------------------------------------- | -------------------------------------------- | -------------------------------------------------- | ----------------------------------------------------- | ----------------------------------------------- | ----------------------------------------------------- |
| [![Ex1](./Core/examples-core-1.png)](./Core) | [![Ex1](./Shapes/examples-shapes-1.png)](./Shapes) | [![Ex1](./Textures/examples-textures-1.png)](./Textures) | [![Ex1](./Text/examples-text-1.png)](./Text) | [![Ex1](./Models/examples-models-1.png)](./Models) | [![Ex1](./Shaders/examples-shaders-1.png)](./Shaders) | [![Ex1](./Audio/examples-audio-1.png)](./Audio) | [![Ex1](./Physics/examples-physics-1.png)](./Physics) |
| [![Ex2](./Core/examples-core-2.png)](./Core) | [![Ex2](./Shapes/examples-shapes-2.png)](./Shapes) | [![Ex2](./Textures/examples-textures-2.png)](./Textures) | [![Ex2](./Text/examples-text-2.png)](./Text) | [![Ex2](./Models/examples-models-2.png)](./Models) | [![Ex2](./Shaders/examples-shaders-2.png)](./Shaders) | [![Ex2](./Audio/examples-audio-2.png)](./Audio) | [![Ex2](./Physics/examples-physics-2.png)](./Physics) |


