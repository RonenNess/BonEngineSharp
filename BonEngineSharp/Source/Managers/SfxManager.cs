using System;
using BonEngineSharp.Assets;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Sfx manager.
    /// Used to play sound effects and music.
    /// </summary>
    public class SfxManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "sfx";

        /// <summary>
        /// Initialize / set audio device properties.
        /// If not called, BonEngine will initialize with defaults.
        /// </summary>
        /// <param name="frequency">Audio frequency.</param>
        /// <param name="format">Audio format.</param>
        /// <param name="stereo">Support stereo?</param>
        /// <param name="audioChunkSize">Size of the chunks to break sound tracks into. Smaller values means more responsiveness, but also more CPU to play sounds.</param>
        public void SetAudioProperties(int frequency = 22050, AudioFormats format = AudioFormats.S16LSB, bool stereo = true, int audioChunkSize = 4096)
        {
            _BonEngineBind.BON_Sfx_SetAudioProperties(frequency, (int)format, stereo, audioChunkSize);
        }

        /// <summary>
        /// Play a music track.
        /// </summary>
        /// <param name="music">Music asset to play.</param>
        /// <param name="volume">Music volume.</param>
        /// <param name="loops">How many times to repeat music (-1 = endless, 0 = once, above 0 = number of times).</param>
        /// <param name="fadeInTime">Fade in time, in seconds (or 0 to play immediately).</param>
        public void PlayMusic(MusicAsset music, int volume = 100, int loops = -1, float fadeInTime = 0f)
        {
            if (music._handle == IntPtr.Zero) { throw new Exception("Can't play music asset with null handle!"); }
            _BonEngineBind.BON_Sfx_PlayMusic(music._handle, volume, loops, fadeInTime);
        }

        /// <summary>
        /// Pause / resume currently played music track.
        /// </summary>
        /// <param name="pause">True to pause, false to resume.</param>
        public void PauseMusic(bool pause)
        {
            _BonEngineBind.BON_Sfx_PauseMusic(pause);
        }

        /// <summary>
        /// Set the volume of the currently played music track.
        /// </summary>
        /// <param name="volume">Music volume.</param>
        public void SetMusicVolume(int volume)
        {
            _BonEngineBind.BON_Sfx_SetMusicVolume(volume);
        }

        /// <summary>
        /// Stop the currently played music track.
        /// </summary>
        public void StopMusic()
        {
            _BonEngineBind.BON_Sfx_StopMusic();
        }

        /// <summary>
        /// Play a sound effect.
        /// </summary>
        /// <param name="sound">Sound to play.</param>
        /// <param name="volume">Sound volume.</param>
        /// <param name="loops">How many times to repeat this sound (-1 = endless, 0 = once, above 0 = number of times).</param>
        /// <param name="pitch">Sound pitch effect.</param>
        /// <param name="fadeInTime">Fade in time, in seconds (or 0 to play immediately).</param>
        /// <returns>Channel id, which you can use later to modify sound. Can be Invalid if there was no available channel.</returns>
        public SoundChannelId PlaySound(SoundAsset sound, int volume = 100, int loops = 0, float pitch = 1f, float fadeInTime = 0f)
        {
            if (sound._handle == IntPtr.Zero) { throw new Exception("Can't play sound asset with null handle!"); }
            return _BonEngineBind.BON_Sfx_PlaySound(sound._handle, volume, loops, pitch, fadeInTime);
        }

        /// <summary>
        /// Play a sound effect.
        /// </summary>
        /// <param name="sound">Sound to play.</param>
        /// <param name="volume">Sound volume.</param>
        /// <param name="loops">How many times to repeat this sound (-1 = endless, 0 = once, above 0 = number of times).</param>
        /// <param name="pitch">Sound pitch effect.</param>
        /// <param name="panLeft">Pan sound left - value should be 0.0-1.0.</param>
        /// <param name="panRight">Pan sound right - value should be 0.0-1.0.</param>
        /// <param name="distance">Sound source distance (affect volume) - value should be 0.0-1.0.</param>
        /// <param name="fadeInTime">Fade in time, in seconds (or 0 to play immediately).</param>
        /// <returns>Channel id, which you can use later to modify sound. Can be Invalid if there was no available channel.</returns>
        public SoundChannelId PlaySound(SoundAsset sound, int volume, int loops, float pitch, float panLeft, float panRight, float distance, float fadeInTime = 0f)
        {
            if (sound._handle == IntPtr.Zero) { throw new Exception("Can't play sound asset with null handle!"); }
            return _BonEngineBind.BON_Sfx_PlaySoundEx(sound._handle, volume, loops, pitch, panLeft, panRight, distance, fadeInTime);
        }

        /// <summary>
        /// Fade out a channel.
        /// </summary>
        /// <param name="channel">Channel id to fade out.</param>
        /// <param name="fadeOutTime">Fade out time, in seconds.</param>
        public void FadeOutChannel(SoundChannelId channel, float fadeOutTime)
        {
            if (channel.IsValid)
            {
                _BonEngineBind.BON_Sfx_FadeOutChannel(channel, fadeOutTime);
            }
        }

        /// <summary>
        /// Fade out music.
        /// </summary>
        /// <param name="fadeOutTime">Fade out time, in seconds.</param>
        public void FadeOutMusic(float fadeOutTime)
        {
            _BonEngineBind.BON_Sfx_FadeOutMusic(fadeOutTime);
        }

        /// <summary>
        /// Set sound channel distance,
        /// </summary>
        /// <param name="channel">Channel id.</param>
        /// <param name="distance">Channel distance.</param>
        public void SetChannelDistance(SoundChannelId channel, float distance)
        {
            if (channel.IsValid)
            {
                _BonEngineBind.BON_Sfx_SetChannelDistance(channel, distance);
            }
        }

        /// <summary>
        /// Set sound channel distance,
        /// </summary>
        /// <param name="channel">Channel id.</param>
        /// <param name="volume">Channel volume.</param>
        public void SetChannelVolume(SoundChannelId channel, int volume)
        {
            if (channel.IsValid)
            {
                _BonEngineBind.BON_Sfx_SetChannelVolume(channel, volume);
            }
        }

        /// <summary>
        /// Set sound channel panning,
        /// </summary>
        /// <param name="channel">Channel id.</param>
        /// <param name="panLeft">Pan sound left - value should be 0.0-1.0.</param>
        /// <param name="panRight">Pan sound right - value should be 0.0-1.0.</param>
        public void SetChannelPanning(SoundChannelId channel, float panLeft, float panRight)
        {
            if (channel.IsValid)
            {
                _BonEngineBind.BON_Sfx_SetChannelPanning(channel, panLeft, panRight);
            }
        }

        /// <summary>
        /// Stop a playing channel.
        /// </summary>
        /// <param name="channel">Channel id.</param>
        public void StopChannel(SoundChannelId channel)
        {
            if (channel.IsValid)
            {
                _BonEngineBind.BON_Sfx_StopChannel(channel);
            }
        }

        /// <summary>
        /// Set master volume.
        /// </summary>
        /// <param name="soundEffectsVolume">Volume for sound effects.</param>
        /// <param name="musicVolume">Volume for music.</param>
        public void SetMasterVolume(int soundEffectsVolume, int musicVolume)
        {
            _BonEngineBind.BON_Sfx_SetMasterVolume(soundEffectsVolume, musicVolume);
        }
    }
}
