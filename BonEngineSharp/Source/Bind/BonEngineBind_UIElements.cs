using System;
using System.Runtime.InteropServices;


namespace BonEngineSharp
{

    /// <summary>
    /// Import the public methods we use from the BonEngine native dll in order to implement the C# bind.
    /// This class wraps everything we need from the CAPI headers.
    /// </summary>
    internal static partial class _BonEngineBind
    {
		/// <summary>
		/// Callback for UI callbacks.
		/// </summary>
		public delegate void UICallback(IntPtr element);

		/// <summary>
		/// Iterate element's children.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_IterateChildren(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback uicallback);

		/// <summary>
		/// Get element type.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern int BON_UIElement_GetType(IntPtr element);

		/// <summary>
		/// Init UI element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_Init(IntPtr element);

		/// <summary>
		/// Set element interactive mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetInteractive(IntPtr element, bool val);

		/// <summary>
		/// Get element interactive mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetInteractive(IntPtr element);

		/// <summary>
		/// Set element capture input mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetCaptureInput(IntPtr element, bool val);

		/// <summary>
		/// Get element capture input mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetCaptureInput(IntPtr element);

		/// <summary>
		/// Set element copy parent state mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetCopyParentState(IntPtr element, bool val);

		/// <summary>
		/// Get element copy parent state mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetCopyParentState(IntPtr element);

		/// <summary>
		/// Set element visibility.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetVisible(IntPtr element, bool val);

		/// <summary>
		/// Get element visibility.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetVisible(IntPtr element);

		/// <summary>
		/// Set element draggable.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetDraggable(IntPtr element, bool val);

		/// <summary>
		/// get element draggable.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetDraggable(IntPtr element);

		/// <summary>
		/// Get if element is being dragged.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetIsBeingDragged(IntPtr element);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnMousePressed(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnMouseReleased(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnMouseEnter(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnMouseLeave(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnDraw(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set event callback.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern void BON_UIElement_OnValueChange(IntPtr element, [MarshalAs(UnmanagedType.FunctionPtr)] UICallback  callback);

		/// <summary>
		/// Set if should limit to parent dragging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetLimitDragToParentArea(IntPtr element, bool val);

		/// <summary>
		/// Get if should limit to parent dragging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetLimitDragToParentArea(IntPtr element);

		/// <summary>
		/// Set if should ignore parent auto arranging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetExemptFromAutoArrange(IntPtr element, bool val);

		/// <summary>
		/// Get if should ignore parent auto arranging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetExemptFromAutoArrange(IntPtr element);

		/// <summary>
		/// Set if should ignore parent auto arranging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetAutoArrangeChildren(IntPtr element, bool val);

		/// <summary>
		/// Get if should ignore parent auto arranging.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetAutoArrangeChildren(IntPtr element);

		/// <summary>
		/// Set if should ignore parent padding.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetIgnoreParentPadding(IntPtr element, bool val);

		/// <summary>
		/// Load element stylesheet from config asset.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_LoadStyleFrom(IntPtr element, IntPtr config);

		/// <summary>
		/// Set if should force active state.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetForceActiveState(IntPtr element, bool val);

		/// <summary>
		/// Get if should force active state.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIElement_GetForceActiveState(IntPtr element);

		/// <summary>
		/// Set origin.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetOrigin(IntPtr element, float x, float y);

		/// <summary>
		/// Get origin.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetOrigin(IntPtr element, ref float x, ref float y);

		/// <summary>
		/// Set color.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetColor(IntPtr element, float r, float g, float b, float a);

		/// <summary>
		/// Get origin.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetColor(IntPtr element, ref float r, ref float g, ref float b, ref float a);

		/// <summary>
		/// Set color highlight.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetColorHighlight(IntPtr element, float r, float g, float b, float a);

		/// <summary>
		/// Get color highlight.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetColorHighlight(IntPtr element, ref float r, ref float g, ref float b, ref float a);

		/// <summary>
		/// Set color pressed.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetColorPressed(IntPtr element, float r, float g, float b, float a);

		/// <summary>
		/// Get color pressed.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetColorPressed(IntPtr element, ref float r, ref float g, ref float b, ref float a);

		/// <summary>
		/// Mark element as dirty.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_MarkAsDirty(IntPtr element);

		/// <summary>
		/// Set offset.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetOffset(IntPtr element, int x, int y);

		/// <summary>
		/// Get offset.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetOffset(IntPtr element, ref int x, ref int y);

		/// <summary>
		/// Set anchor.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetAnchor(IntPtr element, float x, float y);

		/// <summary>
		/// Get anchor.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetAnchor(IntPtr element, ref float x, ref float y);

		/// <summary>
		/// Set size.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetSize(IntPtr element, int x, int xtype, int y, int ytype);

		/// <summary>
		/// Set width to max.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetWidthToMax(IntPtr element);

		/// <summary>
		/// Set height to max.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetHeightToMax(IntPtr element);

		/// <summary>
		/// Get size.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetSize(IntPtr element, ref int x, ref int xtype, ref int y, ref int ytype);

		/// <summary>
		/// Set padding.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetPadding(IntPtr element, int left, int top, int right, int bottom);

		/// <summary>
		/// Get padding.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetPadding(IntPtr element, ref int left, ref int top, ref int right, ref int bottom);

		/// <summary>
		/// Set margin.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_SetMargin(IntPtr element, int left, int top, int right, int bottom);

		/// <summary>
		/// Get margin.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetMargin(IntPtr element, ref int left, ref int top, ref int right, ref int bottom);

		/// <summary>
		/// Get parent.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern IntPtr BON_UIElement_GetParent(IntPtr element);

		/// <summary>
		/// Add child to element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_AddChild(IntPtr element,  IntPtr child);

		/// <summary>
		/// Remove child from element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_RemoveChild(IntPtr element,  IntPtr child);

		/// <summary>
		/// Remove element from parent.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_RemoveSelf(IntPtr element);
		
		/// <summary>
		/// Draw element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_Draw(IntPtr element);

		/// <summary>
		/// Update element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_Update(IntPtr element, double dt);

		/// <summary>
		/// Update element inputs.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_DoInputUpdates(IntPtr element, int mx, int my);

		/// <summary>
		/// Move element to front.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_MoveToFront(IntPtr element);

		/// <summary>
		/// Debug draw element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_DebugDraw(IntPtr element, bool recursive);

		/// <summary>
		/// Get element dest rect.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetCalculatedDestRect(IntPtr element, ref int x, ref int y, ref int width, ref int height);

		/// <summary>
		/// Get element actual dest rect.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_GetActualDestRect(IntPtr element, ref int x, ref int y, ref int width, ref int height);

		/// <summary>
		/// Validate element offset is in parent.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_ValidateOffsetInsideParent(IntPtr element);

        /// <summary>
        /// Get caption from button.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIButton_Caption(IntPtr element);

        /// <summary>
        /// Get caption from checkbox.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UICheckbox_Caption(IntPtr element);

        /// <summary>
        /// Get if checkbox is checked.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UICheckbox_Checked(IntPtr element);

		/// <summary>
		/// Get if checkbox allow uncheck.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UICheckbox_GetAllowUncheck(IntPtr element);

		/// <summary>
		/// Set if checkbox allow uncheck.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UICheckbox_SetAllowUncheck(IntPtr element, bool value);

		/// <summary>
		/// Set if radio allows uncheck.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIRadio_GetAllowUncheck(IntPtr element);

		/// <summary>
		/// Get if radio allows uncheck.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIRadio_SetAllowUncheck(IntPtr element, bool value);

		/// <summary>
		/// Set checkbox value.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UICheckbox_SetValue(IntPtr element, bool value);

        /// <summary>
        /// Toggle checkbox.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UICheckbox_Toggle(IntPtr element);

        /// <summary>
        /// Get caption from radio button.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIRadio_Caption(IntPtr element);

        /// <summary>
        /// Get if radio button is checked.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIRadio_Checked(IntPtr element);

        /// <summary>
        /// Set radio button value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIRadio_SetValue(IntPtr element, bool value);

        /// <summary>
        /// Toggle radio button.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIRadio_Toggle(IntPtr element);

        /// <summary>
        /// Get ui image image.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIImage_GetImage(IntPtr element);

        /// <summary>
        /// Set ui image image.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetImage(IntPtr element, IntPtr image);

        /// <summary>
        /// Set ui image source rect.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetSourceRect(IntPtr element, int x, int y, int width, int height);

        /// <summary>
        /// Get ui image source rect.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_GetSourceRect(IntPtr element,ref int x,ref int y,ref int width,ref int height);

        /// <summary>
        /// Set ui image source rect highlight.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetSourceRectHighlight(IntPtr element, int x, int y, int width, int height);

        /// <summary>
        /// Get ui image source rect highlight.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_GetSourceRectHighlight(IntPtr element,ref int x,ref int y,ref int width,ref int height);

        /// <summary>
        /// Set ui image source rect pressed.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetSourceRectPressed(IntPtr element, int x, int y, int width, int height);

        /// <summary>
        /// Get ui image source rect pressed.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_GetSourceRectPressed(IntPtr element,ref int x,ref int y,ref int width,ref int height);

        /// <summary>
        /// Set ui image blend mode.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetBlendMode(IntPtr element, int blend);

        /// <summary>
        /// Get ui image blend mode.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIImage_GetBlendMode(IntPtr element);

        /// <summary>
        /// Set ui image blend mode.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetImageTypes(IntPtr element, int type);

        /// <summary>
        /// Get ui image blend mode.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIImage_GetImageTypes(IntPtr element);

        /// <summary>
        /// Set ui image scale.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetImageScale(IntPtr element, float scale);

        /// <summary>
        /// Get ui image scale.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern float BON_UIImage_GetImageScale(IntPtr element);

        /// <summary>
        /// Set element slided image sides.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_SetSlicedImageSides(IntPtr element, int left, int top, int right, int bottom);

        /// <summary>
        /// Get element slided image sides.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIImage_GetSlicedImageSides(IntPtr element,ref int left,ref int top,ref int right,ref int bottom);

        /// <summary>
        /// Get list background
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIList_Background(IntPtr element);

        /// <summary>
        /// Set list line height.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_SetLineHeight(IntPtr element, int height);

        /// <summary>
        /// Get list line height.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIList_GetLineHeight(IntPtr element);

        /// <summary>
        /// Set if to show list scrollbar.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_ShowScrollbar(IntPtr element, bool show);

        /// <summary>
        /// Add item to list.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_AddItem(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string item);

		/// <summary>
		/// Get if list contains an item.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIList_Contains(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string item);

		/// <summary>
		/// Remove item from list.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_RemoveItem(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string item, bool removeAll);

        /// <summary>
        /// Remove item from list.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_RemoveItemByIndex(IntPtr element, int index);

        /// <summary>
        /// Remove item from list.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_Clear(IntPtr element);

        /// <summary>
        /// Get list selected index.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIList_SelectedIndex(IntPtr element);

        /// <summary>
        /// Get list selected item.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]  
		public static extern IntPtr BON_UIList_SelectedItem(IntPtr element);

		/// <summary>
		/// Get list selected item, converted to string.
		/// </summary>
		public static string BON_UIList_SelectedItem_Str(IntPtr element)
		{
			return Marshal.PtrToStringAnsi(BON_UIList_SelectedItem(element));
		}

		/// <summary>
		/// Set selected value.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_Select(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string item);

        /// <summary>
        /// Set selected value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_SelectIndex(IntPtr element, int index);

        /// <summary>
        /// Clear list selection.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIList_ClearSelection(IntPtr element);

        /// <summary>
        /// Set slider max value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UISlider_SetMaxValue(IntPtr element, int maxVal);

        /// <summary>
        /// Get slider max value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UISlider_GetMaxValue(IntPtr element);

        /// <summary>
        /// Set slider value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UISlider_SetValue(IntPtr element, int val);

        /// <summary>
        /// Get slider value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UISlider_GetValue(IntPtr element);

        /// <summary>
        /// Get text font.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIText_GetFont(IntPtr element);

        /// <summary>
        /// Set text font.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetFont(IntPtr element, IntPtr font);

        /// <summary>
        /// Get text outline.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIText_GetOutlineWidth(IntPtr element);

        /// <summary>
        /// Set text outline.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlineWidth(IntPtr element, int width);

        /// <summary>
        /// Get text outline highlight.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIText_GetOutlineHighlightWidth(IntPtr element);

        /// <summary>
        /// Set text outline highlight.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlineHighlightWidth(IntPtr element, int width);

        /// <summary>
        /// Get text outline pressed.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIText_GetOutlinePressedWidth(IntPtr element);

        /// <summary>
        /// Set text outline pressed.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlinePressedWidth(IntPtr element, int width);

        /// <summary>
        /// Get text font size.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIText_GetFontSize(IntPtr element);

        /// <summary>
        /// Set text font size.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetFontSize(IntPtr element, int size);

        /// <summary>
        /// Get text alignment.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIText_GetAlignment(IntPtr element);

        /// <summary>
        /// Set text alignment.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetAlignment(IntPtr element, int alignment);

		/// <summary>
		/// Get text word wrap state.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UIText_GetWordWrap(IntPtr element);

		/// <summary>
		/// Set text word wrap state.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIText_SetWordWrap(IntPtr element, bool value);

		/// <summary>
		/// Get text text.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]  
		public static extern IntPtr BON_UIText_GetText(IntPtr element);

		/// <summary>
		/// Get text string, converted to string.
		/// </summary>
		public static string BON_UIText_GetText_Str(IntPtr asset)
		{
			return Marshal.PtrToStringAnsi(BON_UIText_GetText(asset));
		}

		/// <summary>
		/// Set text text.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetText(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string text);

        /// <summary>
        /// Set element outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlineColor(IntPtr element, float r, float g, float b, float a);

        /// <summary>
        /// Get element outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_GetOutlineColor(IntPtr element, ref float r, ref float g, ref float b, ref float a);

        /// <summary>
        /// Set element highlight outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlineHighlightColor(IntPtr element, float r, float g, float b, float a);

        /// <summary>
        /// Get element highlight outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_GetOutlineHighlightColor(IntPtr element, ref float r, ref float g, ref float b, ref float a);

        /// <summary>
        /// Set element pressed outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_SetOutlinePressedColor(IntPtr element, float r, float g, float b, float a);

        /// <summary>
        /// Get element pressed outline color.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIText_GetOutlinePressedColor(IntPtr element, ref float r, ref float g, ref float b, ref float a);

        /// <summary>
        /// Get title from window.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern IntPtr BON_UIWindow_Title(IntPtr element);

        /// <summary>
        /// Get scrollbar max value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern void BON_UIScrollbar_SetMaxValue(IntPtr element, int maxVal);

        /// <summary>
        /// Get scrollbar max value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIScrollbar_GetMaxValue(IntPtr element);

        /// <summary>
        /// Get scrollbar value.
        /// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]  
		public static extern int BON_UIScrollbar_GetValue(IntPtr element);

		/// <summary>
		/// Set text input caret character.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetCaretCharacter(IntPtr element, char value);

		/// <summary>
		/// Get text input caret character.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern char BON_UITextInput_GetCaretCharacter(IntPtr element);

		/// <summary>
		/// Set text input input mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetInputMode(IntPtr element, int value);

		/// <summary>
		/// Get text input input mode.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern int BON_UITextInput_GetInputMode(IntPtr element);

		/// <summary>
		/// Get text input text element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern IntPtr BON_UITextInput_Text(IntPtr element);

		/// <summary>
		/// Get text input placeholder element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern IntPtr BON_UITextInput_Placeholder(IntPtr element);

		/// <summary>
		/// Get text input caret blinking interval.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetCaretBlinkingInterval(IntPtr element, float value);

		/// <summary>
		/// Set text input caret blinking interval.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern float BON_UITextInput_GetCaretBlinkingInterval(IntPtr element);

		/// <summary>
		/// Set if text input is currently receiving input.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetReceivingInput(IntPtr element, bool value);

		/// <summary>
		/// Get if text input is currently receiving input.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UITextInput_GetReceivingInput(IntPtr element);

		/// <summary>
		/// Set if text input allows tab input.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetAllowTabs(IntPtr element, bool value);

		/// <summary>
		/// Get if text input allows tab input.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		[return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_UITextInput_GetAllowTabs(IntPtr element);

		/// <summary>
		/// Set text input max length.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetMaxLength(IntPtr element, int value);

		/// <summary>
		/// Get text input max length.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern int BON_UITextInput_GetMaxLength(IntPtr element);

		/// <summary>
		/// Set text input value.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetValue(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string value);

		/// <summary>
		/// Get text input value.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UITextInput_GetValue(IntPtr element);

		/// <summary>
		/// Get text string, converted to string.
		/// </summary>
		public static string BON_UITextInput_GetValue_Str(IntPtr element)
		{
			return Marshal.PtrToStringAnsi(BON_UITextInput_GetValue(element));
		}

		/// <summary>
		/// Set text input placeholder.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UITextInput_SetPlaceholder(IntPtr element, [MarshalAs(UnmanagedType.LPStr)] string value);

		/// <summary>
		/// Get text input placeholder.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UITextInput_GetPlaceholder(IntPtr element);

		/// <summary>
		/// Get text placeholder, converted to string.
		/// </summary>
		public static string BON_UITextInput_GetPlaceholder_Str(IntPtr element)
		{
			return Marshal.PtrToStringAnsi(BON_UITextInput_GetPlaceholder(element));
		}
	}
}
