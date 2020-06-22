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
        /// Create a scene.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Scene_Create(
            [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback onLoad,
            [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback onUnload,
            [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback onStart,
            [MarshalAs(UnmanagedType.FunctionPtr)] NoParamsCallback onDraw,
            [MarshalAs(UnmanagedType.FunctionPtr)] DoubleParamCallback onUpdate,
            [MarshalAs(UnmanagedType.FunctionPtr)] DoubleParamCallback onFixedUpdate);

        /// <summary>
        /// Destroy a scene.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Scene_Destroy(IntPtr scene);

        /// <summary>
        /// Get if its the first scene we loaded.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Scene_IsFirstScene(IntPtr scene);
    }
}
