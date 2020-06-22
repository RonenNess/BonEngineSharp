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
		/// Validate element offset is in parent.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UIElement_ValidateOffsetInsideParent(IntPtr element);
	}
}
