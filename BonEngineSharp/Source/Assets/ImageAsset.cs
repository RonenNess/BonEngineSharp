using System;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

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
        /// Return if this image have alpha channel.
        /// </summary>
        public bool AlphaChannel
        {
            get
            {
                if (_alphaChannel == null)
                {
                    _alphaChannel = _BonEngineBind.BON_Image_HaveAlphaChannel(_handle);
                }
                return _alphaChannel.Value;
            }
        }
        bool? _alphaChannel;

        /// <summary>
        /// Save image asset to file.
        /// </summary>
        /// <param name="path">Filename for the output image.</param>
        public void SaveToFile(string path)
        {
            _BonEngineBind.BON_Image_SaveToFile(_handle, path);
        }

        /// <summary>
        /// Clears image to transparent pixels, including alpha channels.
        /// </summary>
        public void Clear()
        {
            _BonEngineBind.BON_Image_Clear(_handle);
        }

        /// <summary>
        /// Prepare a reading buffer so we can query pixels data from this image asset.
        /// You must call this before calling GetPixel().
        /// </summary>
        /// <param name="sourceRect">Source rect to read.</param>
        public void PrepareReadingBuffer(RectangleI sourceRect)
        {
            _BonEngineBind.BON_Image_PrepareReadingBuffer(_handle, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height);
        }

        /// <summary>
        /// Prepare a reading buffer so we can query pixels data from this image asset.
        /// You must call this before calling GetPixel().
        /// </summary>
        public void PrepareReadingBuffer()
        {
            PrepareReadingBuffer(RectangleI.Empty);
        }

        /// <summary>
        /// Free a reading buffer created by PrepareReadingBuffer().
        /// This is done automatically anyway when asset is freed from memory on the CPP side of BonEngine.
        /// </summary>
        public void FreeReadingBuffer()
        {
            _BonEngineBind.BON_Image_FreeReadingBuffer(_handle);
        }

        /// <summary>
        /// Get pixel color from image.
        /// Note: you must call PrepareReadingBuffer() before using this function, otherwise you'll just get 0,0,0,0 values.
        /// </summary>
        /// <param name="position">Pixel position to query.</param>
        /// <returns>Pixel color.</returns>
        public Color GetPixel(PointI position)
        {
            float r = 0;
            float g = 0;
            float b = 0;
            float a = 0;
            _BonEngineBind.BON_Image_GetPixel(_handle, position.X, position.Y, ref r, ref g, ref b, ref a);
            return new Framework.Color(r, g, b, a);
        }

        /// <summary>
        /// Get image filtering mode.
        /// </summary>
        public ImageFilterMode FilteringMode => (ImageFilterMode)_BonEngineBind.BON_Image_FilteringMode(_handle);
    }
}
