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
        /*|  float => float  |*/
        Raylib.SetMasterVolume(volume);
    }

    /// <summary>
    /// Load wave data from file
    /// </summary>
    public Wave LoadWave(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadWave(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load wave from memory buffer, fileType refers to extension: i.e. '.wav'
    /// </summary>
    public Wave LoadWaveFromMemory(string fileType, byte[] fileData, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  const unsigned char * => byte[]  |*/
        var fileDataLocal = Helpers.ArrayToPtr(fileData);
        /*|  int => int  |*/
        return Raylib.LoadWaveFromMemory(fileTypeLocal.AsPtr(), fileDataLocal, dataSize);
    }

    /// <summary>
    /// Load sound from file
    /// </summary>
    public Sound LoadSound(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadSound(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load sound from wave data
    /// </summary>
    public Sound LoadSoundFromWave(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Raylib.LoadSoundFromWave(wave);
    }

    /// <summary>
    /// Update sound buffer with new data
    /// </summary>
    public void UpdateSound(Sound sound, IntPtr data, int sampleCount)
    {
        /*|  Sound => Sound  |*/
        /*|  const void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        Raylib.UpdateSound(sound, dataLocal, sampleCount);
    }

    /// <summary>
    /// Unload wave data
    /// </summary>
    public void UnloadWave(Wave wave)
    {
        /*|  Wave => Wave  |*/
        Raylib.UnloadWave(wave);
    }

    /// <summary>
    /// Unload sound
    /// </summary>
    public void UnloadSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.UnloadSound(sound);
    }

    /// <summary>
    /// Export wave data to file, returns true on success
    /// </summary>
    public bool ExportWave(Wave wave, string fileName)
    {
        /*|  Wave => Wave  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportWave(wave, fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Export wave sample data to code (.h), returns true on success
    /// </summary>
    public bool ExportWaveAsCode(Wave wave, string fileName)
    {
        /*|  Wave => Wave  |*/
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.ExportWaveAsCode(wave, fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Play a sound
    /// </summary>
    public void PlaySound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.PlaySound(sound);
    }

    /// <summary>
    /// Stop playing a sound
    /// </summary>
    public void StopSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.StopSound(sound);
    }

    /// <summary>
    /// Pause a sound
    /// </summary>
    public void PauseSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.PauseSound(sound);
    }

    /// <summary>
    /// Resume a paused sound
    /// </summary>
    public void ResumeSound(Sound sound)
    {
        /*|  Sound => Sound  |*/
        Raylib.ResumeSound(sound);
    }

    /// <summary>
    /// Play a sound (using multichannel buffer pool)
    /// </summary>
    public void PlaySoundMulti(Sound sound)
    {
        /*|  Sound => Sound  |*/
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
        /*|  Sound => Sound  |*/
        return Raylib.IsSoundPlaying(sound);
    }

    /// <summary>
    /// Set volume for a sound (1.0 is max level)
    /// </summary>
    public void SetSoundVolume(Sound sound, float volume)
    {
        /*|  Sound => Sound  |*/
        /*|  float => float  |*/
        Raylib.SetSoundVolume(sound, volume);
    }

    /// <summary>
    /// Set pitch for a sound (1.0 is base level)
    /// </summary>
    public void SetSoundPitch(Sound sound, float pitch)
    {
        /*|  Sound => Sound  |*/
        /*|  float => float  |*/
        Raylib.SetSoundPitch(sound, pitch);
    }

    /// <summary>
    /// Convert wave data to desired format
    /// </summary>
    public void WaveFormat(Wave* wave, int sampleRate, int sampleSize, int channels)
    {
        /*|  Wave * => Wave*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.WaveFormat(wave, sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Copy a wave to a new wave
    /// </summary>
    public Wave WaveCopy(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Raylib.WaveCopy(wave);
    }

    /// <summary>
    /// Crop a wave to defined samples range
    /// </summary>
    public void WaveCrop(Wave* wave, int initSample, int finalSample)
    {
        /*|  Wave * => Wave*  |*/
        /*|  int => int  |*/
        /*|  int => int  |*/
        Raylib.WaveCrop(wave, initSample, finalSample);
    }

    /// <summary>
    /// Load samples data from wave as a floats array
    /// </summary>
    public float[] LoadWaveSamples(Wave wave)
    {
        /*|  Wave => Wave  |*/
        return Helpers.PrtToArray(Raylib.LoadWaveSamples(wave));
    }

    /// <summary>
    /// Unload samples data loaded with LoadWaveSamples()
    /// </summary>
    public void UnloadWaveSamples(float* samples)
    {
        /*|  float * => float*  |*/
        Raylib.UnloadWaveSamples(samples);
    }

    /// <summary>
    /// Load music stream from file
    /// </summary>
    public Music LoadMusicStream(string fileName)
    {
        /*|  const char * => string  |*/
        using var fileNameLocal = fileName.MarshalUtf8();
        return Raylib.LoadMusicStream(fileNameLocal.AsPtr());
    }

    /// <summary>
    /// Load music stream from data
    /// </summary>
    public Music LoadMusicStreamFromMemory(string fileType, byte[] data, int dataSize)
    {
        /*|  const char * => string  |*/
        using var fileTypeLocal = fileType.MarshalUtf8();
        /*|  unsigned char * => byte[]  |*/
        var dataLocal = Helpers.ArrayToPtr(data);
        /*|  int => int  |*/
        return Raylib.LoadMusicStreamFromMemory(fileTypeLocal.AsPtr(), dataLocal, dataSize);
    }

    /// <summary>
    /// Unload music stream
    /// </summary>
    public void UnloadMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.UnloadMusicStream(music);
    }

    /// <summary>
    /// Start music playing
    /// </summary>
    public void PlayMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.PlayMusicStream(music);
    }

    /// <summary>
    /// Check if music is playing
    /// </summary>
    public bool IsMusicStreamPlaying(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.IsMusicStreamPlaying(music);
    }

    /// <summary>
    /// Updates buffers for music streaming
    /// </summary>
    public void UpdateMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.UpdateMusicStream(music);
    }

    /// <summary>
    /// Stop music playing
    /// </summary>
    public void StopMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.StopMusicStream(music);
    }

    /// <summary>
    /// Pause music playing
    /// </summary>
    public void PauseMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.PauseMusicStream(music);
    }

    /// <summary>
    /// Resume playing paused music
    /// </summary>
    public void ResumeMusicStream(Music music)
    {
        /*|  Music => Music  |*/
        Raylib.ResumeMusicStream(music);
    }

    /// <summary>
    /// Seek music to a position (in seconds)
    /// </summary>
    public void SeekMusicStream(Music music, float position)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SeekMusicStream(music, position);
    }

    /// <summary>
    /// Set volume for music (1.0 is max level)
    /// </summary>
    public void SetMusicVolume(Music music, float volume)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SetMusicVolume(music, volume);
    }

    /// <summary>
    /// Set pitch for a music (1.0 is base level)
    /// </summary>
    public void SetMusicPitch(Music music, float pitch)
    {
        /*|  Music => Music  |*/
        /*|  float => float  |*/
        Raylib.SetMusicPitch(music, pitch);
    }

    /// <summary>
    /// Get music time length (in seconds)
    /// </summary>
    public float GetMusicTimeLength(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.GetMusicTimeLength(music);
    }

    /// <summary>
    /// Get current music time played (in seconds)
    /// </summary>
    public float GetMusicTimePlayed(Music music)
    {
        /*|  Music => Music  |*/
        return Raylib.GetMusicTimePlayed(music);
    }

    /// <summary>
    /// Load audio stream (to stream raw audio pcm data)
    /// </summary>
    public AudioStream LoadAudioStream(uint sampleRate, uint sampleSize, uint channels)
    {
        /*|  unsigned int => uint  |*/
        /*|  unsigned int => uint  |*/
        /*|  unsigned int => uint  |*/
        return Raylib.LoadAudioStream(sampleRate, sampleSize, channels);
    }

    /// <summary>
    /// Unload audio stream and free memory
    /// </summary>
    public void UnloadAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.UnloadAudioStream(stream);
    }

    /// <summary>
    /// Update audio stream buffers with data
    /// </summary>
    public void UpdateAudioStream(AudioStream stream, IntPtr data, int frameCount)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  const void * => IntPtr  |*/
        var dataLocal = (void*)data;
        /*|  int => int  |*/
        Raylib.UpdateAudioStream(stream, dataLocal, frameCount);
    }

    /// <summary>
    /// Check if any audio stream buffers requires refill
    /// </summary>
    public bool IsAudioStreamProcessed(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        return Raylib.IsAudioStreamProcessed(stream);
    }

    /// <summary>
    /// Play audio stream
    /// </summary>
    public void PlayAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.PlayAudioStream(stream);
    }

    /// <summary>
    /// Pause audio stream
    /// </summary>
    public void PauseAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.PauseAudioStream(stream);
    }

    /// <summary>
    /// Resume audio stream
    /// </summary>
    public void ResumeAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.ResumeAudioStream(stream);
    }

    /// <summary>
    /// Check if audio stream is playing
    /// </summary>
    public bool IsAudioStreamPlaying(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        return Raylib.IsAudioStreamPlaying(stream);
    }

    /// <summary>
    /// Stop audio stream
    /// </summary>
    public void StopAudioStream(AudioStream stream)
    {
        /*|  AudioStream => AudioStream  |*/
        Raylib.StopAudioStream(stream);
    }

    /// <summary>
    /// Set volume for audio stream (1.0 is max level)
    /// </summary>
    public void SetAudioStreamVolume(AudioStream stream, float volume)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  float => float  |*/
        Raylib.SetAudioStreamVolume(stream, volume);
    }

    /// <summary>
    /// Set pitch for audio stream (1.0 is base level)
    /// </summary>
    public void SetAudioStreamPitch(AudioStream stream, float pitch)
    {
        /*|  AudioStream => AudioStream  |*/
        /*|  float => float  |*/
        Raylib.SetAudioStreamPitch(stream, pitch);
    }

    /// <summary>
    /// Default size for new audio streams
    /// </summary>
    public void SetAudioStreamBufferSizeDefault(int size)
    {
        /*|  int => int  |*/
        Raylib.SetAudioStreamBufferSizeDefault(size);
    }

}
#pragma warning restore
