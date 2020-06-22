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

#if BUILD_X64
        public const string NATIVE_DLL_PATH = "BoneEngineCore/_x64";
        public const string NATIVE_DLL_FILE_NAME = "BoneEngineCore/_x64/BonEngine.dll";
#else
        public const string NATIVE_DLL_PATH = "BoneEngineCore/_x86";
        public const string NATIVE_DLL_FILE_NAME = "BoneEngineCore/_x86/BonEngine.dll";
#endif

        /// <summary>
        /// Static constructor - setup dll include paths.
        /// </summary>
        public static void Initialize()
        {
            string AssemblyFolder = AppDomain.CurrentDomain.BaseDirectory;
#if BUILD_X64
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + System.IO.Path.Combine(AssemblyFolder, NATIVE_DLL_PATH));
#else
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + System.IO.Path.Combine(AssemblyFolder, NATIVE_DLL_PATH));
#endif
        }

        // set charset we use
        public const CharSet CHARSET = CharSet.Unicode;
    }
}
