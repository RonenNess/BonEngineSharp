using System;
using BonEngineSharp.UI;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// UI manager.
    /// Responsible to create, render and interact with UI systems.
    /// </summary>
    public class UIManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "ui";

		/// <summary>
		/// Override cursor position for UI.
		/// </summary>
		public PointI? OverrideCursorPosition
		{
			set
			{
				if (value.HasValue)
				{
					_BonEngineBind.BON_UI_OverrideCursorPosition(value.Value.X, value.Value.Y);
				}
				else
				{
					_BonEngineBind.BON_UI_OverrideCursorPosition(-1, -1);
				}
			}
		}

		/// <summary>
		/// Set UI cursor from image, size and offset.
		/// </summary>
		/// <param name="image">Image asset to use as cursor.</param>
		/// <param name="size">Cursor size in pixels.</param>
		/// <param name="offset">Cursor offset from mouse position.</param>
		public void SetCursor(ImageAsset image, PointI size, PointI offset)
        {
			_BonEngineBind.BON_UI_SetCursorEx(image._handle, size.X, size.Y, offset.X, offset.Y);
        }

		/// <summary>
		/// Set UI cursor from UI image.
		/// </summary>
		/// <param name="image">UI Image to use as cursor.</param>
		public void SetCursor(UIImage image)
		{
			_BonEngineBind.BON_UI_SetCursor(image._handle);
		}

		/// <summary>
		/// Set cursor from stylesheet file path.
		/// </summary>
		public void SetCursor(string stylesheetPath)
        {
			var image = CreateImage(stylesheetPath, null);
			SetCursor(image);
		}

		/// <summary>
		/// Draw a cursor.
		/// </summary>
		public void DrawCursor()
        {
			_BonEngineBind.BON_UI_DrawCursor();
        }

		/// <summary>
		/// Draw a UI system.
		/// </summary>
		/// <param name="root">UI system root element to draw.</param>
		/// <param name="drawCursor">If true, will draw element and all its children recursively.</param>
		public void Draw(UIElement root, bool drawCursor = true)
        {
			_BonEngineBind.BON_UI_Draw(root._handle, drawCursor);
        }

		/// <summary>
		/// Debug draw a UI system.
		/// </summary>
		/// <param name="root">UI system root element to draw.</param>
		public void DebugDraw(UIElement root)
        {
			root.DebugDraw(true);
        }

		/// <summary>
		/// Update UI element and its children.
		/// You must call this on root to update your UI system.
		/// </summary>
		/// <param name="root">UI element to update.</param>
		/// <param name="activeElement">Active UI element, or null if we didn't interact with anything.</param>
		public void UpdateUI(UIElement root, out UIElement activeElement)
        {
			IntPtr activeElem = _BonEngineBind.BON_UI_UpdateUI(root._handle);
			activeElement = (activeElem == IntPtr.Zero) ? null : new UIElement(activeElem);
		}

		/// <summary>
		/// Update UI element and its children.
		/// You must call this on root to update your UI system.
		/// </summary>
		/// <param name="root">UI element to update.</param>
		public void UpdateUI(UIElement root)
		{
			UIElement _;
			UpdateUI(root, out _);
		}

		/// <summary>
		/// Init new UI element.
		/// </summary>
		private UIType InitNewElement<UIType>(UIType element, UIElement parent) where UIType : UIElement
		{
			if (parent != null)
            {
				parent._addChildToInternalList(element);

			}
			return element;
		}

		/// <summary>
		/// Create and return a root UI element.
		/// This is just an empty container without stylesheet that takes max width and height, and have no padding.
		/// </summary>
		/// <returns>New root element.</returns>
		public UIElement CreateRoot()
        {
			return InitNewElement(new UIElement(_BonEngineBind.BON_UI_CreateRoot()), null);
        }

		/// <summary>
		/// Create and return a base UI element.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIElement CreateContainer(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIElement(_BonEngineBind.BON_UI_CreateContainer(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI image.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIImage CreateImage(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIImage(_BonEngineBind.BON_UI_CreateImage(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI text.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="text">Text to set.</param>
		/// <returns>New UI element.</returns>
		public UIText CreateText(string stylesheet, UIElement parent, string text = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIText(_BonEngineBind.BON_UI_CreateText(stylesheet, parentHandle, text)), parent);
		}

		/// <summary>
		/// Create and return a UI window.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="title">Window title.</param>
		/// <returns>New UI element.</returns>
		public UIWindow CreateWindow(string stylesheet, UIElement parent, string title = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIWindow(_BonEngineBind.BON_UI_CreateWindow(stylesheet, parentHandle, title)), parent);
		}

		/// <summary>
		/// Create and return a UI button.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="text">Button text.</param>
		/// <returns>New UI element.</returns>
		public UIButton CreateButton(string stylesheet, UIElement parent, string text = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIButton(_BonEngineBind.BON_UI_CreateButton(stylesheet, parentHandle, text)), parent);
		}

		/// <summary>
		/// Create and return a UI Text input.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="startValue">Starting value.</param>
		/// <param name="placeholder">Placeholder text.</param>
		/// <returns>New UI element.</returns>
		public UITextInput CreateTextInput(string stylesheet, UIElement parent, string startValue = null, string placeholder = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UITextInput(_BonEngineBind.BON_UI_CreateTextInput(stylesheet, parentHandle, startValue, placeholder)), parent);
		}

		/// <summary>
		/// Create and return a UI checkbox.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="text">Checkbox text.</param>
		/// <returns>New UI element.</returns>
		public UICheckBox CreateCheckBox(string stylesheet, UIElement parent, string text = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UICheckBox(_BonEngineBind.BON_UI_CreateCheckbox(stylesheet, parentHandle, text)), parent);
		}

		/// <summary>
		/// Create and return a UI radio button.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <param name="text">Radio button text.</param>
		/// <returns>New UI element.</returns>
		public UIRadioButton CreateRadioButton(string stylesheet, UIElement parent, string text = null)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIRadioButton(_BonEngineBind.BON_UI_CreateRadioButton(stylesheet, parentHandle, text)), parent);
		}

		/// <summary>
		/// Create and return a UI slider.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UISlider CreateSlider(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UISlider(_BonEngineBind.BON_UI_CreateSlider(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI List.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIList CreateList(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIList(_BonEngineBind.BON_UI_CreateList(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI DropDown element.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIDropDown CreateDropDown(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIDropDown(_BonEngineBind.BON_UI_CreateDropDown(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI Rectangle element.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIRectangle CreateRectangle(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIRectangle(_BonEngineBind.BON_UI_CreateRectangle(stylesheet, parentHandle)), parent);
		}

		/// <summary>
		/// Create and return a UI vertical scrollbar.
		/// </summary>
		/// <param name="stylesheet">Stylesheet path to load.</param>
		/// <param name="parent">Optional parent to attach element to.</param>
		/// <returns>New UI element.</returns>
		public UIVerticalScrollbar CreateVerticalScrollbar(string stylesheet, UIElement parent)
		{
			if (!string.IsNullOrEmpty(stylesheet)) stylesheet = BonEngine._Engine.Assets.ToAssetsPath(stylesheet, true);
			var parentHandle = parent != null ? parent._handle : IntPtr.Zero;
			return InitNewElement(new UIVerticalScrollbar(_BonEngineBind.BON_UI_CreateVerticalScrollbar(stylesheet, parentHandle)), parent);
		}
	}
}
