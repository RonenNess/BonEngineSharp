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
        /// Check if log level is valid.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Log_IsValid(int level);

        /// <summary>
        /// Get log level.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Log_GetLevel();

        /// <summary>
        /// Set log level.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Log_SetLevel(int level);

        /// <summary>
        /// Write log.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Log_Write(int level, [MarshalAs(UnmanagedType.LPStr)] string msg);
    }
}
