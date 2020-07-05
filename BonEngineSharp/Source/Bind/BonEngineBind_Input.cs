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
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_Down([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_ReleasedNow([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_PressedNow([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Get list of key codes assigned to given action id.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Input_GetAssignedKeys([MarshalAs(UnmanagedType.LPStr)] string actionId, ref int retLength);

        /// <summary>
        /// Get clipboard content.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Input_GetClipboard();

        /// <summary>
        /// Get clipboard content, converted to string.
        /// </summary>
        public static string BON_Input_GetClipboard_Str()
        {
            return Marshal.PtrToStringAnsi(BON_Input_GetClipboard());
        }

        /// <summary>
        /// Set clipboard content.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Input_SetClipboard([MarshalAs(UnmanagedType.LPStr)] string value);

        /// <summary>
        /// Struct to get text input data - must match the CPP side.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct TextInputData
        {
            public byte Backspace;
            public byte Delete;
            public byte Copy;
            public byte Paste;
            public byte Tab;
            public byte Up;
            public byte Down;
            public byte Left;
            public byte Right;
            public byte Home;
            public byte End;
            public byte Insert;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] Text;
        };

        /// <summary>
        /// Set clipboard content.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern TextInputData BON_Input_GetTextInput();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyDown(int key);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyReleasedNow(int key);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyPressedNow(int key);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_ScrollDeltaX();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_ScrollDeltaY();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_CursorPositionX();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_CursorPositionY();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_CursorDeltaX();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Input_CursorDeltaY();

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Input_SetKeyBind(int keyCode, [MarshalAs(UnmanagedType.LPStr)] string actionId);
    }
}
