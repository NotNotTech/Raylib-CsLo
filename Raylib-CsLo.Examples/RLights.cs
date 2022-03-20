// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

namespace Raylib_CsLo.Examples;


/**********************************************************************************************
*
*   raylib.lights - Some useful functions to deal with lights data
*
*   CONFIGURATION:
*
*   #define RLIGHTS_IMPLEMENTATION
*       Generates the implementation of the library into the included file.
*       If not defined, the library is in header only mode and can be included in other headers
*       or source files without problems. But only ONE file should hold the implementation.
*
*   LICENSE: zlib/libpng
*
*   Copyright (c) 2017-2020 Victor Fisac (@victorfisac) and Ramon Santamaria (@raysan5)
*
*   This software is provided "as-is", without any express or implied warranty. In no event
*   will the authors be held liable for any damages arising from the use of this software.
*
*   Permission is granted to anyone to use this software for any purpose, including commercial
*   applications, and to alter it and redistribute it freely, subject to the following restrictions:
*
*     1. The origin of this software must not be misrepresented; you must not claim that you
*     wrote the original software. If you use this software in a product, an acknowledgment
*     in the product documentation would be appreciated but is not required.
*
*     2. Altered source versions must be plainly marked as such, and must not be misrepresented
*     as being the original software.
*
*     3. This notice may not be removed or altered from any source distribution.
*
**********************************************************************************************/
public unsafe class RLights
{



    // Defines and Macros

    public const int MAX_LIGHTS = 4;         // Max dynamic lights supported by shader


    // Types and Structures Definition


    // Light data
    public struct Light
    {

        public LightType type;
        public Vector3 position;
        public Vector3 target;
        public Color color;
        public bool enabled;

        // Shader locations
        public int enabledLoc;
        public int typeLoc;
        public int posLoc;
        public int targetLoc;
        public int colorLoc;
    }

    // Light type
    public enum LightType
    {
        LIGHT_DIRECTIONAL,
        LIGHT_POINT
    }



    /***********************************************************************************
	*
	*   RLIGHTS IMPLEMENTATION
	*
	************************************************************************************/



    // Defines and Macros

    // ...


    // Types and Structures Definition

    // ...


    // Global Variables Definition

    int lightsCount;    // Current amount of created lights


    // Module specific Functions Declaration

    // ...


    // Module Functions Definition


    // Create a light and get shader locations
    public Light CreateLight(LightType type, Vector3 position, Vector3 target, Color color, Shader shader)
    {
        Light light = new();

        if (lightsCount < MAX_LIGHTS)
        {
            light.enabled = true;
            light.type = type;
            light.position = position;
            light.target = target;
            light.color = color;

            // TODO: Below code doesn't look good to me,
            // it assumes a specific shader naming and structure
            // Probably this implementation could be improved
            string enabledName = $"lights[{lightsCount}].enabled";
            string typeName = $"lights[{lightsCount}].type";
            string posName = $"lights[{lightsCount}].position";
            string targetName = $"lights[{lightsCount}].target";
            string colorName = $"lights[{lightsCount}].color";

            //// Set location name [x] depending on lights count
            //enabledName[7] = '0' + lightsCount;
            //typeName[7] = '0' + lightsCount;
            //posName[7] = '0' + lightsCount;
            //targetName[7] = '0' + lightsCount;
            //colorName[7] = '0' + lightsCount;

            light.enabledLoc = GetShaderLocation(shader, enabledName);
            light.typeLoc = GetShaderLocation(shader, typeName);
            light.posLoc = GetShaderLocation(shader, posName);
            light.targetLoc = GetShaderLocation(shader, targetName);
            light.colorLoc = GetShaderLocation(shader, colorName);

            UpdateLightValues(shader, light);

            lightsCount++;
        }

        return light;
    }

    // Send light properties to shader
    // NOTE: Light shader locations should be available
    public static void UpdateLightValues(Shader shader, Light light)
    {
        // Send to shader light enabled state and type
        SetShaderValue(shader, light.enabledLoc, &light.enabled, ShaderUniformInt);
        SetShaderValue(shader, light.typeLoc, &light.type, ShaderUniformInt);

        // Send to shader light position values
        Vector3 position = new(light.position.X, light.position.Y, light.position.Z);
        SetShaderValue(shader, light.posLoc, position, ShaderUniformVec3);

        // Send to shader light target position values
        Vector3 target = new(light.target.X, light.target.Y, light.target.Z);
        SetShaderValue(shader, light.targetLoc, target, ShaderUniformVec3);

        // Send to shader light color values
        Vector4 color = new(light.color.r / (float)255, light.color.g / (float)255, light.color.b / (float)255, light.color.a / (float)255);
        SetShaderValue(shader, light.colorLoc, color, ShaderUniformVec4);
    }

}
