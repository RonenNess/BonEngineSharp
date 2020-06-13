using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Sound track asset type.
    /// This asset is used to play sound effects on mix channels. For music tracks, use the MusicAsset.
    /// </summary>
    public class SoundAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public SoundAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Image;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~SoundAsset()
        {
            Dispose();
        }

        /// <summary>
        /// Get sound track length.
        /// </summary>
        public float Length
        {
            get
            {
                if (_length == 0f && HaveHandle)
                {
                    _length = _BonEngineBind.BON_Sound_Length(_handle);
                }
                return _length;
            }
        }
        float _length;

        /// <summary>
        /// Check if this sound track is currently playing.
        /// </summary>
        /// <returns>True if sound track is playing.</returns>
        public bool IsPlaying()
        {
            return _BonEngineBind.BON_Sound_IsPlaying(_handle);
        }
    }
}
