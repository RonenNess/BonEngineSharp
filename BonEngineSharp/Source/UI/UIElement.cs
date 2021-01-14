using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using BonEngineSharp.Assets;
using BonEngineSharp.Defs;
using BonEngineSharp.Framework;

namespace BonEngineSharp.UI
{
	/// <summary>
	/// UI Element base class.
	/// This is the basic class all UI Elements inherit from and its main purpose is to manage the handle to the CPP-side elements.
	/// </summary>
	public class UIElement : IDisposable
	{
		/// <summary>
		/// The element's handle in BonEngine.
		/// </summary>
		internal protected IntPtr _handle = IntPtr.Zero;

		// if true, will release (delete) the cpp side element when disposed.
		internal bool _releaseElementOnDispose = true;

		/// <summary>
		/// Child elements.
		/// This list is not actually used, but its important to prevent the GC from collecting children while
		/// they still have callbacks attached to them.
		/// </summary>
		List<UIElement> _children = new List<UIElement>();

		// parent element.
		UIElement _parent;

		/// <summary>
		/// Get element type.
		/// </summary>
		public virtual UIElementType ElementType => UIElementType.Element;

		/// <summary>
		/// Set width in pixels.
		/// </summary>
		public int WidthPixels
		{
			set
            {
				var size = Size;
				size.Width = value;
				size.WidthType = UISizeType.Pixels;
				Size = size;
            }
			get
            {
				var size = Size;
				if (size.WidthType == UISizeType.Pixels) { return size.Width; }
				return CalculatedDestRect.Width;
            }
		}

		/// <summary>
		/// Set height in pixels.
		/// </summary>
		public int HeightPixels
		{
			set
			{
				var size = Size;
				size.Height = value;
				size.HeightType = UISizeType.Pixels;
				Size = size;
			}
			get
			{
				var size = Size;
				if (size.HeightType == UISizeType.Pixels) { return size.Height; }
				return CalculatedDestRect.Height;
			}
		}

		/// <summary>
		/// Set width in percents.
		/// </summary>
		public int WidthPercents
		{
			set
			{
				var size = Size;
				size.Width = value;
				size.WidthType = UISizeType.PercentOfParent;
				Size = size;
			}
		}

		/// <summary>
		/// Set height in percents.
		/// </summary>
		public int HeightPercents
		{
			set
			{
				var size = Size;
				size.Height = value;
				size.HeightType = UISizeType.PercentOfParent;
				Size = size;
			}
		}

		/// <summary>
		/// Implement UI element callbacks.
		/// </summary>
		#region Callbacks

		// cache of callbacks so we can register them without getting them deleted under our feet.
		// these actions wrap the private _onXXX() functions, which in turn invoke the callbacks.
		_BonEngineBind.UICallback _ref_onMousePressed;
		_BonEngineBind.UICallback _ref_onMouseReleased;
		_BonEngineBind.UICallback _ref_onMouseEnter;
		_BonEngineBind.UICallback _ref_onMouseLeave;
		_BonEngineBind.UICallback _ref_onDraw;
		_BonEngineBind.UICallback _ref_onValueChange;

		// the callbacks user registered to recieve events.
		System.Action<UIElement> _onMousePressedCallback;
		System.Action<UIElement> _onMouseReleasedCallback;
		System.Action<UIElement> _onMouseEnterCallback;
		System.Action<UIElement> _onMouseLeaveCallback;
		System.Action<UIElement> _onDrawCallback;
		System.Action<UIElement> _onValueChangeCallback;

		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onMousePressed(IntPtr handle)
        {
			_onMousePressedCallback?.Invoke(this);
		}

		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onMouseReleased(IntPtr handle)
		{
			_onMouseReleasedCallback?.Invoke(this);
		}
		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onMouseEnter(IntPtr handle)
		{
			_onMouseEnterCallback?.Invoke(this);
		}
		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onMouseLeave(IntPtr handle)
		{
			_onMouseLeaveCallback?.Invoke(this);
		}
		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onDraw(IntPtr handle)
		{
			_onDrawCallback?.Invoke(this);
		}
		/// <summary>
		/// Register internally to call event.
		/// </summary>
		private void _onValueChange(IntPtr handle)
		{
			_onValueChangeCallback?.Invoke(this);
		}

		/// <summary>
		/// Register callback to respond to mouse pressed events.
		/// </summary>
		public void OnMousePressed(System.Action<UIElement> callback)
		{
			_onMousePressedCallback = callback;
			_ref_onMousePressed = _onMousePressed;
			_BonEngineBind.BON_UIElement_OnMousePressed(_handle, _ref_onMousePressed);
		}

		/// <summary>
		/// Register callback to respond to mouse released events.
		/// </summary>
		public void OnMouseReleased(System.Action<UIElement> callback)
		{
			_onMouseReleasedCallback = callback;
			_ref_onMouseReleased = _onMouseReleased;
			_BonEngineBind.BON_UIElement_OnMouseReleased(_handle, _ref_onMouseReleased);
		}

		/// <summary>
		/// Register callback to respond to mouse enter events.
		/// </summary>
		public void OnMouseEnter(System.Action<UIElement> callback)
		{
			_onMouseEnterCallback = callback;
			_ref_onMouseEnter = _onMouseEnter;
			_BonEngineBind.BON_UIElement_OnMouseEnter(_handle, _ref_onMouseEnter);
		}

		/// <summary>
		/// Register callback to respond to mouse leave events.
		/// </summary>
		public void OnMouseLeave(System.Action<UIElement> callback)
		{
			_onMouseLeaveCallback = callback;
			_ref_onMouseLeave = _onMouseLeave;
			_BonEngineBind.BON_UIElement_OnMouseLeave(_handle, _ref_onMouseLeave);
		}

		/// <summary>
		/// Register callback to respond to draw events.
		/// </summary>
		public void OnDraw(System.Action<UIElement> callback)
		{
			_onDrawCallback = callback;
			_ref_onDraw = _onDraw;
			_BonEngineBind.BON_UIElement_OnDraw(_handle, _ref_onDraw);
		}

		/// <summary>
		/// Register callback to respond to draw events.
		/// </summary>
		public void OnValueChange(System.Action<UIElement> callback)
		{
			_onValueChangeCallback = callback;
			_ref_onValueChange = _onValueChange;
			_BonEngineBind.BON_UIElement_OnValueChange(_handle, _ref_onValueChange);
		}

		#endregion

		/// <summary>
		/// Iterate children under this element.
		/// </summary>
		public void IterateChildren(System.Action<UIElement> callback)
        {
			_BonEngineBind.BON_UIElement_IterateChildren(_handle, (IntPtr handle) =>
			{
				var curr = new UIElement(handle);
				curr._releaseElementOnDispose = false;
				callback(curr);
			});
		}

		/// <summary>
		/// Initialize element.
		/// This is called automatically by the UI manager, call this only if you create custom elements outside of it.
		/// </summary>
		public void _Init()
        {
			_BonEngineBind.BON_UIElement_Init(_handle);
        }

		/// <summary>
		/// Get / set if this element is interactive.
		/// Elements that are not interactive will ignore all input events, mouse or keyboard.
		/// </summary>
		public bool Interactive
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetInteractive(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetInteractive(_handle, value);
			}
		}

		/// <summary>
		/// Get / set if this element capture input events and prevent them from propagating to other elements.
		/// If true and you click on this element, click will not reach anything under it. If false, you can click this element and also elements behind it.
		/// </summary>
		public bool CaptureInput
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetCaptureInput(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetCaptureInput(_handle, value);
			}
		}

		/// <summary>
		/// Get / set if this element should always copy its parent state.
		/// This is useful for things like a label attached to a button, where you want to highlight the text when the background button is highlighted too.
		/// </summary>
		public bool CopyParentState
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetCopyParentState(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetCopyParentState(_handle, value);
			}
		}

		/// <summary>
		/// Get / set if this element is visible.
		/// Note: if element is not visible, its children will be hidden too.
		/// </summary>
		public bool Visible
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetVisible(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetVisible(_handle, value);
			}
		}

		/// <summary>
		/// Get / set if this element is draggable.
		/// </summary>
		public bool Draggable
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetDraggable(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetDraggable(_handle, value);
			}
		}

		/// <summary>
		/// Get if this element is being dragged right now.
		/// </summary>
		public bool IsBeingDragged => _BonEngineBind.BON_UIElement_GetIsBeingDragged(_handle);

		/// <summary>
		/// Get / set if should limit dragging to parent element bounding box.
		/// </summary>
		public bool LimitDragToParentArea
        {
			get
            {
				return _BonEngineBind.BON_UIElement_GetLimitDragToParentArea(_handle);
			}
			set
            {
				_BonEngineBind.BON_UIElement_SetLimitDragToParentArea(_handle, value);
			}
        }

		/// <summary>
		/// If true, will ignore parent padding.
		/// </summary>
		/// <param name="ignore">True to ignore parent padding.</param>
		public void IgnoreParentPadding(bool ignore)
        {
			_BonEngineBind.BON_UIElement_SetIgnoreParentPadding(_handle, ignore);
        }

		/// <summary>
		/// Load stylesheet from config file.
		/// </summary>
		/// <param name="config">Config asset to load stylesheet from.</param>
		public void LoadStyleFrom(ConfigAsset config)
        {
			_BonEngineBind.BON_UIElement_LoadStyleFrom(_handle, config._handle);
        }

		/// <summary>
		/// If true, will force the element state to be active / pressed.
		/// </summary>
		public bool ForceActiveState
        {
			get
            {
				return _BonEngineBind.BON_UIElement_GetForceActiveState(_handle);
            }
			set
            {
				_BonEngineBind.BON_UIElement_SetForceActiveState(_handle, value);
			}
        }

		/// <summary>
		/// If true, will ignore parent auto arrange.
		/// </summary>
		public bool ExemptFromAutoArrange
        {
			get
            {
				return _BonEngineBind.BON_UIElement_GetExemptFromAutoArrange(_handle);
            }
			set
            {
				_BonEngineBind.BON_UIElement_SetExemptFromAutoArrange(_handle, value);
			}
        }

		/// <summary>
		/// If true, will automatically arrange children position based on their actual dest rect.
		/// </summary>
		public bool AutoArrangeChildren
		{
			get
			{
				return _BonEngineBind.BON_UIElement_GetAutoArrangeChildren(_handle);
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetAutoArrangeChildren(_handle, value);
			}
		}

		/// <summary>
		/// Get / set element origin.
		/// Origin is the point on the element that touches the calculated position.
		/// For example, if Origin is 0,0, it means the element calculated position will be the element top-left corner.
		/// </summary>
		public PointF Origin
		{
			get
			{
				PointF ret = new PointF();
				_BonEngineBind.BON_UIElement_GetOrigin(_handle, ref ret.X, ref ret.Y);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetOrigin(_handle, value.X, value.Y);
			}
		}

		/// <summary>
		/// Get / set element color while idle.
		/// </summary>
		public Color Color
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIElement_GetColor(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetColor(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Get / set element color while user points on it / focused.
		/// </summary>
		public Color ColorHighlight
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIElement_GetColorHighlight(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetColorHighlight(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Get / set element color while being pressed / active.
		/// </summary>
		public Color ColorPressed
		{
			get
			{
				Color ret = new Color();
				_BonEngineBind.BON_UIElement_GetColorPressed(_handle, ref ret.R, ref ret.G, ref ret.B, ref ret.A);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetColorPressed(_handle, value.R, value.G, value.B, value.A);
			}
		}

		/// <summary>
		/// Mark this element as dirty (requires update).
		/// </summary>
		public void MarkAsDirty()
        {
			_BonEngineBind.BON_UIElement_MarkAsDirty(_handle);
		}

		/// <summary>
		/// Get / set element offset.
		/// Offset is the element offset, in pixel, from its calculated position based on Anchor and Origin.
		/// </summary>
		public PointI Offset
		{
			get
			{
				PointI ret = new PointI();
				_BonEngineBind.BON_UIElement_GetOffset(_handle, ref ret.X, ref ret.Y);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetOffset(_handle, value.X, value.Y);
			}
		}

		/// <summary>
		/// Get / set element anchor.
		/// Anchor is the element base position, relative to parent destination rect.
		/// For example, values of 1,1, will position element at the bottom-right corner of its parent.
		/// Note that you need to combine this property with Origin if you want to decide which part of this element will stick to the anchor position.
		/// </summary>
		public PointF Anchor
		{
			get
			{
				PointF ret = new PointF();
				_BonEngineBind.BON_UIElement_GetAnchor(_handle, ref ret.X, ref ret.Y);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetAnchor(_handle, value.X, value.Y);
			}
		}

		/// <summary>
		/// Set width value to max.
		/// </summary>
		public void SetWidthToMax()
        {
			_BonEngineBind.BON_UIElement_SetWidthToMax(_handle);
		}

		/// <summary>
		/// Set height value to max (100%).
		/// </summary>
		public void SetHeightToMax()
		{
			_BonEngineBind.BON_UIElement_SetHeightToMax(_handle);
		}

		/// <summary>
		/// Set width and height values to max (100%).
		/// </summary>
		public void SetSizeToMax()
		{
			SetWidthToMax();
			SetHeightToMax();
		}

		/// <summary>
		/// Get / set element size.
		/// For width and height we also have unit types, that define the meaning of the value. 
		/// </summary>
		public UISize Size
        {
			get
			{
				UISize ret = new UISize();
				int wt = 0;
				int ht = 0;
				_BonEngineBind.BON_UIElement_GetSize(_handle, ref ret.Width, ref wt, ref ret.Height, ref ht);
				ret.WidthType = (UISizeType)wt;
				ret.HeightType = (UISizeType)ht;
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetSize(_handle, value.Width, (int)value.WidthType, value.Height, (int)value.HeightType);
			}
		}

		/// <summary>
		/// Set / get element size in pixels.
		/// </summary>
		public PointI SizePixels
        {
			get { return new PointI(WidthPixels, HeightPixels); }
			set { Size = new UISize(value.X, UISizeType.Pixels, value.Y, UISizeType.Pixels); }
        }

		/// <summary>
		/// Get / set padding. 
		/// Padding adds distance between the boundaries of this element and its children.
		/// </summary>
		public UISides Padding
		{
			get
			{
				UISides ret = new UISides();
				_BonEngineBind.BON_UIElement_GetPadding(_handle, ref ret.Left, ref ret.Top, ref ret.Right, ref ret.Bottom);
				return ret;
			}
			set
            {
				_BonEngineBind.BON_UIElement_SetPadding(_handle, value.Left, value.Top, value.Right, value.Bottom);
			}
		}

		/// <summary>
		/// Get / set margin. 
		/// Margin adds distance to neighbor elements when auto-arranging them.
		/// </summary>
		public UISides Margin
		{
			get
			{
				UISides ret = new UISides();
				_BonEngineBind.BON_UIElement_GetMargin(_handle, ref ret.Left, ref ret.Top, ref ret.Right, ref ret.Bottom);
				return ret;
			}
			set
			{
				_BonEngineBind.BON_UIElement_SetMargin(_handle, value.Left, value.Top, value.Right, value.Bottom);
			}
		}

		/// <summary>
		/// Get parent element.
		/// </summary>
		public UIElement Parent => new UIElement(_BonEngineBind.BON_UIElement_GetParent(_handle));

		/// <summary>
		/// Add a child element to childrens list, without actually updating the CPP side.
		/// </summary>
		internal void _addChildToInternalList(UIElement element)
        {
			_children.Add(element);
        }

		/// <summary>
		/// Grow / shrink element size.
		/// Note: doesn't change unit type, only value, so this can either grow percents or pixels, depends on what was previously set.
		/// </summary>
		/// <param name="width">Width to grow.</param>
		/// <param name="height">Height to grow.</param>
		public void Grow(int width, int height)
        {
			if (width != 0)
			{
				Size = new UISize(Size.Width + width, Size.WidthType, Size.Height, Size.HeightType);
			}
			if (height != 0)
			{
				Size = new UISize(Size.Width, Size.WidthType, Size.Height + height, Size.HeightType);
			}
		}

		/// <summary>
		/// Add child element to this element.
		/// </summary>
		/// <param name="element">Element to add.</param>
		public void AddChild(UIElement element)
		{
			_BonEngineBind.BON_UIElement_AddChild(_handle, element._handle);
			_children.Add(element);
			element._parent = this;
		}

		/// <summary>
		/// Remove child element from this element.
		/// </summary>
		/// <param name="element">Element to remove.</param>
		public void RemoveChild(UIElement element)
        {
			_BonEngineBind.BON_UIElement_RemoveChild(_handle, element._handle);
			_children.Remove(element);
			element._parent = null;
		}

		/// <summary>
		/// Create a column container inside this element.
		/// Columns are sub elements that takes 100% of height, and arrange themselves automatically based on alignment and other columns.
		/// For example if you create 3 columns in the sizes of 50, 100, and 150, and they all align left, the last column will have offset of 50 + 100.
		/// Columns are useful when you want to arrange elements side by side.
		/// </summary>
		/// <remarks>To remove the column, use RemoveChild() just like you would do with a regular child element.</remarks>
		/// <param name="stylesheet">Column stylesheet or null to create empty container.</param>
		/// <param name="width">Column width.</param>
		/// <param name="widthType">Column width unit (pixels / percents).</param>
		/// <param name="alignment">Column alignment, ie which side of the parent element it will stick to.</param>
		/// <returns>New column element.</returns>
		public UIElement CreateColumn(string stylesheet, int width, UISizeType widthType = UISizeType.Pixels, UIAlignment alignment = UIAlignment.Left)
        {
			return new UIElement(_BonEngineBind.BON_UIElement_CreateColumn(_handle, stylesheet, width, (int)widthType, (int)alignment));

		}

		/// <summary>
		/// Remove element from its parent.
		/// </summary>
		public void Remove()
        {
			_BonEngineBind.BON_UIElement_RemoveSelf(_handle);
			if (_parent != null)
			{
				_parent._children.Remove(this);
				_parent = null;
			}
		}

		/// <summary>
		/// Draw this element and its children.
		/// </summary>
		public void Draw()
        {
			_BonEngineBind.BON_UIElement_Draw(_handle);
        }

		/// <summary>
		/// Update UI Element and its children.
		/// </summary>
		/// <param name="deltaTime">Delta time, in seconds, since last update call.</param>
		public void Update(double deltaTime)
        {
			_BonEngineBind.BON_UIElement_Update(_handle, deltaTime);
		}

		/// <summary>
		/// Move this element to front.
		/// </summary>
		public void MoveToFront()
        {
			_BonEngineBind.BON_UIElement_MoveToFront(_handle);
		}

		/// <summary>
		/// Debug draw UI symbols (bounding boxes, paddings, ect).
		/// </summary>
		/// <param name="recursive">If true, will debug draw child elements recursively.</param>
		public void DebugDraw(bool recursive)
        {
			_BonEngineBind.BON_UIElement_DebugDraw(_handle, recursive);

		}

		/// <summary>
		/// Get calculated destination rect (position and size of element).
		/// Updated after Update() is called.
		/// </summary>
		public RectangleI CalculatedDestRect
        {
			get
            {
				RectangleI ret = new RectangleI();
				_BonEngineBind.BON_UIElement_GetCalculatedDestRect(_handle, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
				return ret;
			}
        }

		/// <summary>
		/// Get actual destination rect.
		/// Updated after Update() is called. 
		/// This is usually the same as CalculatedDestRect, except for special cases like with text.
		/// </summary>
		public RectangleI ActualDestRect
		{
			get
			{
				RectangleI ret = new RectangleI();
				_BonEngineBind.BON_UIElement_GetActualDestRect(_handle, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
				return ret;
			}
		}

		/// <summary>
		/// Validate the element offset is inside parent boundaries.
		/// </summary>
		public void ValidateOffsetInsideParent()
        {
			_BonEngineBind.BON_UIElement_ValidateOffsetInsideParent(_handle);
		}

		/// <summary>
		/// Create the UI element.
		/// </summary>
		/// <param name="handle">UI element handle inside the low-level engine.</param>
		public UIElement(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Get if this element got a handle.
        /// </summary>
        protected bool HaveHandle => _handle != IntPtr.Zero;

        /// <summary>
        /// Dispose on destructor.
        /// </summary>
        ~UIElement()
        {
            Dispose();
        }

        /// <summary>
        /// Destroy the asset pointer by releasing its handle.
        /// </summary>
        public void Dispose()
        {
            if (HaveHandle)
            {
				if (_releaseElementOnDispose) { _BonEngineBind.BON_UI_ReleaseElement(_handle); }
                _handle = IntPtr.Zero;
            }
        }
    }
}
