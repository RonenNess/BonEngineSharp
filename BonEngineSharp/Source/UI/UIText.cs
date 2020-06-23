using System;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

namespace BonEngineSharp.UI
{
    /// <summary>
    /// UI Text element.
    /// </summary>
    public class UIText : UIElement
    {
        /// <summary>
        /// Get element type.
        /// </summary>
        public override UIElementType ElementType => UIElementType.Text;

		/// <summary>
		/// Get / set text outline color while idle.
		/// </summary>
		public Color OutlineColor
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIText_GetOutlineColor(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIText_SetOutlineColor(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Get / set text outline color while user points on it / focused.
		/// </summary>
		public Color OutlineColorHighlight
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIText_GetOutlineHighlightColor(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIText_SetOutlineHighlightColor(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Get / set text outline color while being pressed / active.
		/// </summary>
		public Color OutlineColorPressed
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIText_GetOutlinePressedColor(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIText_SetOutlinePressedColor(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Set / get text font.
		/// </summary>
		public Assets.FontAsset Font
        {
			get
			{
				var ret = new Assets.FontAsset(_BonEngineBind.BON_UIText_GetFont(_handle));
				ret._releaseElementOnDispose = false;
				return ret;
			}
			set { _BonEngineBind.BON_UIText_SetFont(_handle, value._handle); }
		}

		/// <summary>
		/// Set / get text outline width.
		/// </summary>
		public int OutlineWidth
		{
			get { return _BonEngineBind.BON_UIText_GetOutlineWidth(_handle); }
			set { _BonEngineBind.BON_UIText_SetOutlineWidth(_handle, value); }
		}

		/// <summary>
		/// Set / get text outline highlighted width.
		/// </summary>
		public int OutlineWidthHighlight
		{
			get { return _BonEngineBind.BON_UIText_GetOutlineHighlightWidth(_handle); }
			set { _BonEngineBind.BON_UIText_SetOutlineHighlightWidth(_handle, value); }
		}

		/// <summary>
		/// Set / get text outline pressed width.
		/// </summary>
		public int OutlineWidthPressed
		{
			get { return _BonEngineBind.BON_UIText_GetOutlinePressedWidth(_handle); }
			set { _BonEngineBind.BON_UIText_SetOutlinePressedWidth(_handle, value); }
		}

		/// <summary>
		/// Set / get text font size.
		/// </summary>
		public int FontSize
		{
			get { return _BonEngineBind.BON_UIText_GetFontSize(_handle); }
			set { _BonEngineBind.BON_UIText_SetFontSize(_handle, value); }
		}

		/// <summary>
		/// Set / get text alignment.
		/// </summary>
		public UITextAlignment Alignment
        {
			get { return (UITextAlignment)_BonEngineBind.BON_UIText_GetAlignment(_handle); }
			set { _BonEngineBind.BON_UIText_SetAlignment(_handle, (int)value); }
		}

		/// <summary>
		/// Set / get text.
		/// </summary>
		public string Text
        {
			get { return _BonEngineBind.BON_UIText_GetText_Str(_handle); }
			set { _BonEngineBind.BON_UIText_SetText(_handle, value); }
        }

		/// <summary>
		/// Create the UI element.
		/// </summary>
		/// <param name="handle">UI element handle inside the low-level engine.</param>
		public UIText(IntPtr handle) : base(handle)
        {
        }
    }
}
