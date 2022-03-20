// Copyright ©️ Raylib-CsLo and Contributors.
// This file is licensed to you under the MPL-2.0.
// See the LICENSE file in the project root for more info.
// The code and 100+ examples are here! https://github.com/NotNotTech/Raylib-CsLo

// Warning This file is auto generated and changes will be lost

namespace Raylib_CsLo;

/// <summary> AudioStream, custom audio stream </summary>
public unsafe partial struct AudioStream
{
    /// <summary> Pointer to internal data used by the audio system </summary>
    public RAudioBuffer* buffer;

    /// <summary> Frequency (samples per second) </summary>
    public uint sampleRate;

    /// <summary> Bit depth (bits per sample): 8, 16, 32 (24 not supported) </summary>
    public uint sampleSize;

    /// <summary> Number of channels (1-mono, 2-stereo, ...) </summary>
    public uint channels;

}
