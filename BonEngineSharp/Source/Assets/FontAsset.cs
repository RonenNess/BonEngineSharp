using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Font asset type.
    /// This asset is used to render text.
    /// </summary>
    public class FontAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public FontAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Font;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~FontAsset()
        {
            Dispose();
        }

        /// <summary>
        /// Get the font size
        /// </summary>
        public int Size
        {
            get
            {
                if (_size == 0 && HaveHandle)
                {
                    _size = _BonEngineBind.BON_Font_Size(_handle);
                }
                return _size;
            }
        }
        int _size;
    }
}
