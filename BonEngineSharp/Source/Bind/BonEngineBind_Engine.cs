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
        /// Get current engine state.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Engine_CurrentState();

        /// <summary>
        /// Get updates count.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern UInt64 BON_Engine_UpdatesCount();

        /// <summary>
        /// Get fixed updates count.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern UInt64 BON_Engine_FixedUpdatesCount();

        /// <summary>
        /// Was the engine destroyed?
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Engine_Destroyed();

        /// <summary>
        /// Is the engine running?
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Engine_Running();

        /// <summary>
        /// Get fixed updates interval.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern double BON_Engine_GetFixedUpdatesInterval();

        /// <summary>
        /// Set fixed updates interval.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Engine_SetFixedUpdatesInterval(double value);

        /// <summary>
        /// Set fixed updates interval.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Manager_Create([MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback initialize, [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback start, [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback dispose, [MarshalAs(UnmanagedType.FunctionPtr)] DoubleParamCallback update, [MarshalAs(UnmanagedType.LPStr)] string id);

        /// <summary>
        /// Register a custom manager.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Manager_Register(IntPtr manager);

        /// <summary>
        /// Destroy a custom manager.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Manager_Destroy(IntPtr manager);
    }
}
