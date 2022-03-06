#pragma warning disable
namespace Raylib_CsLo;

using System.Numerics;
using Microsoft.Toolkit.HighPerformance.Buffers;
using Raylib_CsLo.InternalHelpers;

public unsafe partial class RaylibS
{
    /// <summary>
    /// Initialize audio device and context
    /// </summary>
    public void InitAudioDevice()
    {
        Raylib.InitAudioDevice();
    }

    /// <summary>
    /// Close the audio device and context
    /// </summary>
    public void CloseAudioDevice()
    {
        Raylib.CloseAudioDevice();
    }

    /// <summary>
    /// Check if audio device has been initialized successfully
    /// </summary>
    public bool IsAudioDeviceReady()
    {
        return Raylib.IsAudioDeviceReady();
    }

    /// <summary>
    /// Set master volume (listener)
    /// </summary>
    public void SetMasterVolume(float volume)
    {
        Raylib.SetMasterVolume(volume);
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public Wave LoadWave(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.LoadWave(fileName_.AsPtr());
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public Wave LoadWaveFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        using var fileType_ = fileType.MarshalUtf8();
        return Raylib.LoadWaveFromMemory(fileType_.AsPtr(), fileData, dataSize);
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public Sound LoadSound(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.LoadSound(fileName_.AsPtr());
    }

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public Sound LoadSoundFromWave(Wave wave)
    {
        return Raylib.LoadSoundFromWave(wave);
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public void UpdateSound(Sound sound, IntPtr data, int sampleCount)
    {
        var data_ = (void*)data;
        Raylib.UpdateSound(sound, data_, sampleCount);
    }

    /// <summary>
    /// Unload wave data
    /// </summary>
    public void UnloadWave(Wave wave)
    {
        Raylib.UnloadWave(wave);
    }

    /// <summary>
    /// Unload sound
    /// </summary>
    public void UnloadSound(Sound sound)
    {
        Raylib.UnloadSound(sound);
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public bool ExportWave(Wave wave, string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.ExportWave(wave, fileName_.AsPtr());
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public bool ExportWaveAsCode(Wave wave, string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.ExportWaveAsCode(wave, fileName_.AsPtr());
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public void PlaySound(Sound sound)
    {
        Raylib.PlaySound(sound);
    }

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public void StopSound(Sound sound)
    {
        Raylib.StopSound(sound);
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    public void PauseSound(Sound sound)
    {
        Raylib.PauseSound(sound);
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public void ResumeSound(Sound sound)
    {
        Raylib.ResumeSound(sound);
    }

    /// <summary>
    /// Play a sound (using multichannel buffer pool)
    /// </summary>
    public void PlaySoundMulti(Sound sound)
    {
        Raylib.PlaySoundMulti(sound);
    }

    /// <summary>
    /// Stop any sound playing (using multichannel buffer pool)
    /// </summary>
    public void StopSoundMulti()
    {
        Raylib.StopSoundMulti();
    }

    /// <summary>
    /// Get number of sounds playing in the multichannel
    /// </summary>
    public int GetSoundsPlaying()
    {
        return Raylib.GetSoundsPlaying();
    }

    /// <summary>
    /// Check if a sound is currently playing
    /// </summary>
    public bool IsSoundPlaying(Sound sound)
    {
        return Raylib.IsSoundPlaying(sound);
    }

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public void SetSoundVolume(Sound sound, float volume)
    {
        Raylib.SetSoundVolume(sound, volume);
    }

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public void SetSoundPitch(Sound sound, float pitch)
    {
        Raylib.SetSoundPitch(sound, pitch);
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels)
    {
        Raylib.WaveFormat(wave, sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public Wave WaveCopy(Wave wave)
    {
        return Raylib.WaveCopy(wave);
    }

    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public void WaveCrop(Wave* wave, int initSample, int finalSample)
    {
        Raylib.WaveCrop(wave, initSample, finalSample);
    }

    /// <summary>
    /// Load samples data from wave as a floats array
    /// </summary>
    public float[] LoadWaveSamples(Wave wave)
    {
        return Helpers.PrtToArray(Raylib.LoadWaveSamples(wave));
    }

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    public void UnloadWaveSamples(float* samples)
    {
        Raylib.UnloadWaveSamples(samples);
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public Music LoadMusicStream(string fileName)
    {
        using var fileName_ = fileName.MarshalUtf8();
        return Raylib.LoadMusicStream(fileName_.AsPtr());
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public Music LoadMusicStreamFromMemory(string fileType, byte[] data, int dataSize)
    {
        using var fileType_ = fileType.MarshalUtf8();
        return Raylib.LoadMusicStreamFromMemory(fileType_.AsPtr(), data, dataSize);
    }

    /// <summary>
    /// Unload music stream
    /// </summary>
    public void UnloadMusicStream(Music music)
    {
        Raylib.UnloadMusicStream(music);
    }

    /// <summary>
    /// Start music playing
    /// </summary>
    public void PlayMusicStream(Music music)
    {
        Raylib.PlayMusicStream(music);
    }

    /// <summary>
    /// Check if music is playing
    /// </summary>
    public bool IsMusicStreamPlaying(Music music)
    {
        return Raylib.IsMusicStreamPlaying(music);
    }

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    public void UpdateMusicStream(Music music)
    {
        Raylib.UpdateMusicStream(music);
    }

    /// <summary>
    /// Stop music playing
    /// </summary>
    public void StopMusicStream(Music music)
    {
        Raylib.StopMusicStream(music);
    }

    /// <summary>
    /// Pause music playing
    /// </summary>
    public void PauseMusicStream(Music music)
    {
        Raylib.PauseMusicStream(music);
    }

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    public void ResumeMusicStream(Music music)
    {
        Raylib.ResumeMusicStream(music);
    }

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    public void SeekMusicStream(Music music, float position)
    {
        Raylib.SeekMusicStream(music, position);
    }

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    public void SetMusicVolume(Music music, float volume)
    {
        Raylib.SetMusicVolume(music, volume);
    }

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    public void SetMusicPitch(Music music, float pitch)
    {
        Raylib.SetMusicPitch(music, pitch);
    }

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    public float GetMusicTimeLength(Music music)
    {
        return Raylib.GetMusicTimeLength(music);
    }

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    public float GetMusicTimePlayed(Music music)
    {
        return Raylib.GetMusicTimePlayed(music);
    }

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    public AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels)
    {
        return Raylib.LoadAudioStream(sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    public void UnloadAudioStream(AudioStream stream)
    {
        Raylib.UnloadAudioStream(stream);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public void UpdateAudioStream(AudioStream stream, IntPtr data, int frameCount)
    {
        var data_ = (void*)data;
        Raylib.UpdateAudioStream(stream, data_, frameCount);
    }

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    public bool IsAudioStreamProcessed(AudioStream stream)
    {
        return Raylib.IsAudioStreamProcessed(stream);
    }

    /// <summary>
    /// Play audio stream
    /// </summary>
    public void PlayAudioStream(AudioStream stream)
    {
        Raylib.PlayAudioStream(stream);
    }

    /// <summary>
    /// Pause audio stream
    /// </summary>
    public void PauseAudioStream(AudioStream stream)
    {
        Raylib.PauseAudioStream(stream);
    }

    /// <summary>
    /// Resume audio stream
    /// </summary>
    public void ResumeAudioStream(AudioStream stream)
    {
        Raylib.ResumeAudioStream(stream);
    }

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    public bool IsAudioStreamPlaying(AudioStream stream)
    {
        return Raylib.IsAudioStreamPlaying(stream);
    }

    /// <summary>
    /// Stop audio stream
    /// </summary>
    public void StopAudioStream(AudioStream stream)
    {
        Raylib.StopAudioStream(stream);
    }

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    public void SetAudioStreamVolume(AudioStream stream, float volume)
    {
        Raylib.SetAudioStreamVolume(stream, volume);
    }

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public void SetAudioStreamPitch(AudioStream stream, float pitch)
    {
        Raylib.SetAudioStreamPitch(stream, pitch);
    }

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    public void SetAudioStreamBufferSizeDefault(int size)
    {
        Raylib.SetAudioStreamBufferSizeDefault(size);
    }

}
#pragma warning restore
