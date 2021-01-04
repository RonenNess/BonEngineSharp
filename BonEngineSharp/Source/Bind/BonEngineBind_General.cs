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
        /// Callback without params.
        /// </summary>
        public delegate void NoParamsCallback();

        /// <summary>
        /// Callback with a single double.
        /// </summary>
        public delegate void DoubleParamCallback(double dt);

        /// <summary>
        /// Start the engine.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Start(IntPtr scene);

        /// <summary>
        /// Start the engine with custom features flags.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_StartEx(IntPtr scene, bool enableLogs, bool registerToSignals);

        /// <summary>
        /// Stop the engine.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Stop();
    }
}
