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
