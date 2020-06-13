using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Music asset type.
    /// This asset is used to play long music tracks in background.
    /// </summary>
    public class MusicAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public MusicAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Image;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~MusicAsset()
        {
            Dispose();
        }

        /// <summary>
        /// Get music track length.
        /// </summary>
        public float Length
        {
            get
            {
                if (_length == 0f && HaveHandle)
                {
                    _length = _BonEngineBind.BON_Music_Length(_handle);
                }
                return _length;
            }
        }
        float _length;
    }
}
