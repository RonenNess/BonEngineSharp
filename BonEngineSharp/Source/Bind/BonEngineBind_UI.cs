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
		/// Release a UI element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UI_ReleaseElement(IntPtr element);

		/// <summary>
		/// Set UI cursor
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UI_SetCursorEx(IntPtr imageAsset, int width, int height, int offsetX, int offsetY);

		/// <summary>
		/// Set UI cursor
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UI_SetCursor(IntPtr uiImage);

		/// <summary>
		/// Draw UI cursor
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UI_DrawCursor();

		/// <summary>
		/// Draw a UI system or element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern void BON_UI_Draw(IntPtr root, bool drawCursor);

		/// <summary>
		/// Update a UI system and to all interactions.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern IntPtr BON_UI_UpdateUI(IntPtr root);

		/// <summary>
		/// Create and return a new root element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
		public static extern IntPtr BON_UI_CreateRoot();

		/// <summary>
		/// Create and return an empty container element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateContainer([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);

		/// <summary>
		/// Create and return an image element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateImage([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);

		/// <summary>
		/// Create and return a text element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateText([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string text);


		/// <summary>
		/// Create and return a text input element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateTextInput([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string startingVal, [MarshalAs(UnmanagedType.LPStr)] string placeholder);


		/// <summary>
		/// Create and return awindow element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateWindow([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string title);
		
		/// <summary>
		/// Create and return a button element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateButton([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string caption);

		/// <summary>
		/// Create and return a checkbox element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateCheckbox([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string caption);

		/// <summary>
		/// Create and return a radio button element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateRadioButton([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent, [MarshalAs(UnmanagedType.LPStr)] string caption);

		/// <summary>
		/// Create and return a list element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateList([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);

		/// <summary>
		/// Create and return a dropdown element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateDropDown([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);

		/// <summary>
		/// Create and return a slider element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateSlider([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);

		/// <summary>
		/// Create and return a scrollbar element.
		/// </summary>
		[DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr BON_UI_CreateVerticalScrollbar([MarshalAs(UnmanagedType.LPStr)] string stylesheet, IntPtr parent);
	}
}
