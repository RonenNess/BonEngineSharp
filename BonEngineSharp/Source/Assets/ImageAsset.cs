using System;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Assets
{
    /// <summary>
    /// Image asset type.
    /// Used to render sprites on screen, or as a render target to draw on.
    /// </summary>
    public class ImageAsset : IAsset
    {
        /// <summary>
        /// Create the asset.
        /// </summary>
        /// <param name="handle">Asset handle inside the low-level engine.</param>
        public ImageAsset(IntPtr handle) : base(handle)
        {
        }

        /// <summary>
        /// Get asset type.
        /// </summary>
        public override AssetType AssetType => AssetType.Image;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~ImageAsset()
        {
            Dispose();
        }

        /// <summary>
        /// Get image width.
        /// </summary>
        public int Width
        {
            get
            {
                if (_width == 0 && HaveHandle)
                {
                    _width = _BonEngineBind.BON_Image_Width(_handle);
                }
                return _width;
            }
        }
        int _width;

        /// <summary>
        /// Get image height.
        /// </summary>
        public int Height
        {
            get
            {
                if (_height == 0 && HaveHandle)
                {
                    _height = _BonEngineBind.BON_Image_Height(_handle);
                }
                return _height;
            }
        }
        int _height;

        /// <summary>
        /// Get image filtering mode.
        /// </summary>
        public ImageFilterMode FilteringMode => (ImageFilterMode)_BonEngineBind.BON_Image_FilteringMode(_handle);
    }
}
