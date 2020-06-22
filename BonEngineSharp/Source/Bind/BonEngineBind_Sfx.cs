using System;
using System.Runtime.InteropServices;


namespace BonEngineSharp
{

    /// <summary>
    /// Import the public methods we use from the BonEngine native dll in order to implement the C# bind.
    /// This class wraps everything we need from the CAPI headers.
    /// </summary>
    internal static partial class _BonEngineBind
    {
        /// <summary>
        /// Set audio device properties.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetAudioProperties(int frequency, int format, bool stereo, int audio_chunk_size);

        /// <summary>
        /// Play music track.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_PlayMusic(IntPtr music, int volume, int loops);

        /// <summary>
        /// Pause music.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_PauseMusic(bool pause);

        /// <summary>
        /// Set music volume.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetMusicVolume(int volume);

        /// <summary>
        /// Stop music.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_StopMusic();

        /// <summary>
        /// Play sound.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern
        int BON_Sfx_PlaySound(IntPtr sound, int volume, int loops, float pitch);

        /// <summary>
        /// Play sound.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Sfx_PlaySoundEx(IntPtr sound, int volume, int loops, float pitch, float panLeft, float panRight, float distance);

        /// <summary>
        /// Set channel distance.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelDistance(int channel, float distance);

        /// <summary>
        /// Set channel volume.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelVolume(int channel, int volume);

        /// <summary>
        /// Set channel panning.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelPanning(int channel, float panLeft, float panRight);

        /// <summary>
        /// Stop channel.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_StopChannel(int channel);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetMasterVolume(int soundEffectsVolume, int musicVolume);

    }
}
