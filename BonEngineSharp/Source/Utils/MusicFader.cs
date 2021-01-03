using System;
using System.Collections.Generic;
using System.Text;

namespace BonEngineSharp.Utils
{
    /// <summary>
    /// Utility class to fade out one music track and fade in the next.
    /// This will decrease the volume of the faded out track until it reach 0, then start to fade in the next.
    /// </summary>
    public class MusicFader
    {
        /// <summary>
        /// Music track we fade from.
        /// </summary>
        public Assets.MusicAsset FromTrack { get; private set; }

        /// <summary>
        /// Music track we fade to.
        /// </summary>
        public Assets.MusicAsset ToTrack { get; private set; }

        /// <summary>
        /// Volume to fade out from.
        /// </summary>
        public int FromVolume { get; private set; }

        /// <summary>
        /// Volume to fade in to.
        /// </summary>
        public int ToVolume { get; private set; }

        /// <summary>
        /// Music track currently played.
        /// </summary>
        public Assets.MusicAsset CurrentlyPlayedTrack { get; private set; }

        /// <summary>
        /// Current music track volume.
        /// </summary>
        public int CurrentVolume { get; private set; }

        /// <summary>
        /// Fade in speed.
        /// </summary>
        public float FadeInSpeed;

        /// <summary>
        /// Fade out speed.
        /// </summary>
        public float FadeOutSpeed;

        /// <summary>
        /// Did we finish the transition?
        /// When true it means we set the target volume track at its desired volume.
        /// </summary>
        public bool IsDone { get; private set; }

        // fading out progress. goes from 1 to 0.
        double _fadeOutProgress;

        // fading in progress. goes from 0 to 1.
        double _fadeInProgress;

        /// <summary>
        /// Callback to invoke when finishing fade out.
        /// Must be set before fade out is complete or it won't be called.
        /// </summary>
        public Action OnFinishFadeOut;

        /// <summary>
        /// Callback to invoke when finishing fade in.
        /// Must be set before fade in is complete or it won't be called.
        /// </summary>
        public Action OnFinishFadeIn;

        /// <summary>
        /// Create the music fader.
        /// </summary>
        /// <param name="fromTrack">Track to transition from. Note: fromTrack is assumed to be already playing.</param>
        /// <param name="fromTrackVolume">Start volume to fade out from.</param>
        /// <param name="toTrack">Track to transition to.</param>
        /// <param name="toTrackVolume">Target volume to fade in to.</param>
        /// <param name="fadeOutSpeed">Fade out speed. 1f = takes one second to complete, 0f = immediate.</param>
        /// <param name="fadeInSpeed">Fade in speed. 1f = takes one second to complete, 0f = immediate.</param>
        public MusicFader(Assets.MusicAsset fromTrack, int fromTrackVolume, Assets.MusicAsset toTrack, int toTrackVolume, float fadeOutSpeed = 1f, float fadeInSpeed = 1f)
        {
            FromTrack = fromTrack;
            ToTrack = toTrack;
            FromVolume = fromTrackVolume;
            ToVolume = toTrackVolume;
            FadeOutSpeed = fadeOutSpeed;
            FadeInSpeed = fadeInSpeed;
            _fadeOutProgress = 1;
            _fadeInProgress = 0;
        }

        /// <summary>
        /// Update the music volume.
        /// Note: its your responsibility to check if done using 'IsDone', and after the transition is finished you may release this object.
        /// </summary>
        /// <param name="deltaTime">Current frame delta time.</param>
        public void Update(double deltaTime)
        {
            // done? skip
            if (IsDone) { return; }

            // are we still in fade out stage?
            if (_fadeOutProgress > 0f)
            {
                // set current track
                CurrentlyPlayedTrack = FromTrack;

                // check if need to skip fade out
                if (FromTrack == null || FadeOutSpeed == 0)
                {
                    _fadeOutProgress = 0;
                }
                // do fade out progress
                else
                {
                    _fadeOutProgress -= deltaTime * FadeOutSpeed;
                }

                // did finish? set to 0 and stop music or play next track
                if (_fadeOutProgress <= 0)
                {
                    // set fadeout and volume
                    _fadeOutProgress = 0f;
                    CurrentVolume = 0;

                    // set / stop music
                    if (ToTrack != null)
                    {
                        BonEngine._Engine.Sfx.PlayMusic(ToTrack, 0);
                    }
                    else
                    {
                        BonEngine._Engine.Sfx.StopMusic();
                    }

                    // invoke callback
                    OnFinishFadeOut?.Invoke();
                }
                // not done? only update volume
                else
                {
                    CurrentVolume = (int)((double)FromVolume * _fadeOutProgress);
                    BonEngine._Engine.Sfx.SetMusicVolume(CurrentVolume);
                }

                // stop here
                return;
            }

            // are we fading in?
            else if (ToTrack != null && _fadeInProgress < 1)
            {
                // set current track
                CurrentlyPlayedTrack = ToTrack;

                // check if need to skip fade in
                if (FadeInSpeed == 0)
                {
                    _fadeInProgress = 0;
                }
                // do fade in progress
                else
                {
                    _fadeInProgress += deltaTime * FadeInSpeed;
                }

                // did finish?
                if (_fadeInProgress >= 1)
                {
                    _fadeInProgress = 1;
                    OnFinishFadeIn?.Invoke();
                }

                // calculate and set volume
                CurrentVolume = (int)((double)ToVolume * _fadeInProgress);
                BonEngine._Engine.Sfx.SetMusicVolume(CurrentVolume);

                // stop here
                return;
            }

            // if we got here it means we're done!
            IsDone = true;
        }
    }
}
