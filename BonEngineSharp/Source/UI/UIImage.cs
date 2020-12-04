using System;
using BonEngineSharp.Assets;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI Image element.
    /// </summary>
    public class UIImage : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Image;

        /// <summary>
        /// Get / set UI Image image.
        /// </summary>
        public ImageAsset Image
        {
            get 
            { 
                var ret = new ImageAsset(_BonEngineBind.BON_UIImage_GetImage(_handle));
                ret._releaseElementOnDispose = false;
                return ret;
            }
            set 
            { 
                _BonEngineBind.BON_UIImage_SetImage(_handle, value != null ? value._handle : IntPtr.Zero); 
            }
        }

        /// <summary>
        /// Image source rectangle to draw.
        /// </summary>
        public RectangleI SourceRect
        {
            get
            {
                RectangleI ret = new RectangleI();
                _BonEngineBind.BON_UIImage_GetSourceRect(_handle, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
                return ret;
            }
            set
            {
                _BonEngineBind.BON_UIImage_SetSourceRect(_handle, value.X, value.Y, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Image source rectangle to draw when element is highlighted.
        /// </summary>
        public RectangleI SourceRectHighlight
        {
            get
            {
                RectangleI ret = new RectangleI();
                _BonEngineBind.BON_UIImage_GetSourceRectHighlight(_handle, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
                return ret;
            }
            set
            {
                _BonEngineBind.BON_UIImage_SetSourceRectHighlight(_handle, value.X, value.Y, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Image source rectangle to draw when element is pressed / active.
        /// </summary>
        public RectangleI SourceRectPressed
        {
            get
            {
                RectangleI ret = new RectangleI();
                _BonEngineBind.BON_UIImage_GetSourceRectPressed(_handle, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
                return ret;
            }
            set
            {
                _BonEngineBind.BON_UIImage_SetSourceRectPressed(_handle, value.X, value.Y, value.Width, value.Height);
            }
        }

        /// <summary>
        /// Get / set image blend mode.
        /// </summary>
        public BlendModes BlendMode
        {
            get { return (BlendModes)_BonEngineBind.BON_UIImage_GetBlendMode(_handle); }
            set { _BonEngineBind.BON_UIImage_SetBlendMode(_handle, (int)value); }
        }

        /// <summary>
        /// Get / set image texture scale.
        /// Texture Scale scales tiled / sliced texture when drawing in Tiled or Sliced mode.
        /// </summary>
        public float TextureScale
        {
            get { return _BonEngineBind.BON_UIImage_GetImageScale(_handle); }
            set { _BonEngineBind.BON_UIImage_SetImageScale(_handle, value); }
        }

        /// <summary>
        /// Get / set image drawing type.
        /// </summary>
        public UIImageTypes ImageType
        {
            get { return (UIImageTypes)_BonEngineBind.BON_UIImage_GetImageTypes(_handle); }
            set { _BonEngineBind.BON_UIImage_SetImageTypes(_handle, (int)value); }
        }

        /// <summary>
        /// The size, in pixels, of a sliced image sides / frame.
        /// Only relevant for Sliced image types.
        /// </summary>
        public UISides SlicedImageSides
        {
            get
            {
                UISides ret = new UISides();
                _BonEngineBind.BON_UIImage_GetSlicedImageSides(_handle, ref ret.Left, ref ret.Top, ref ret.Right, ref ret.Bottom);
                return ret;
            }
            set
            {
                _BonEngineBind.BON_UIImage_SetSlicedImageSides(_handle, value.Left, value.Top, value.Right, value.Bottom);
            }
        }

        /// <summary>
        /// Create the UI element.
        /// </summary>
        /// <param name="handle">UI element handle inside the low-level engine.</param>
        public UIImage(IntPtr handle) : base(handle)
        {
        }
    }
}
