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
        /// Load an image asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Assets_LoadImage([MarshalAs(UnmanagedType.LPStr)] string filename, int filter, bool useCache);

        /// <summary>
        /// Creates an empty image asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Assets_CreateEmptyImage(int x, int y, int filter);

        /// <summary>
        /// Load a music asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Assets_LoadMusic([MarshalAs(UnmanagedType.LPStr)] string filename, bool useCache);

        /// <summary>
        /// Load a sound asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Assets_LoadSound([MarshalAs(UnmanagedType.LPStr)] string filename, bool useCache);

        /// <summary>
        /// Load a font asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Assets_LoadFont([MarshalAs(UnmanagedType.LPStr)] string filename, int fontSize, bool useCache);

        /// <summary>
        /// Load a config asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Assets_LoadConfig([MarshalAs(UnmanagedType.LPStr)] string filename, bool useCache);

        /// <summary>
        /// Create an empty config asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Assets_CreateEmptyConfig();

        /// <summary>
        /// Create an empty config asset.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Assets_SaveConfig(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string filename);

        /// <summary>
        /// Free an asset pointer.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Assets_FreeAssetPointer(IntPtr asset);

        /// <summary>
        /// Clear assets cache.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Assets_ClearCache();


        /// <summary>
        /// Check if an asset is valid.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Asset_IsValid(IntPtr asset);

        /// <summary>
        /// Get asset's path.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Asset_Path(IntPtr asset);

        /// <summary>
        /// Get asset's path, converted to string.
        /// </summary>
        public static string BON_Asset_Path_Str(IntPtr asset)
        {
            return Marshal.PtrToStringAnsi(BON_Asset_Path(asset));
        }

        /// <summary>
        /// Get image filtering mode.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Image_FilteringMode(IntPtr asset);

        /// <summary>
        /// Get image width.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Image_Width(IntPtr asset);

        /// <summary>
        /// Get image height.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Image_Height(IntPtr asset);

        /// <summary>
        /// Save image to file.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Image_SaveToFile(IntPtr asset, [MarshalAs(UnmanagedType.LPStr)] string filename);

        /// <summary>
        /// Prepare image for reading pixels from it.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Image_PrepareReadingBuffer(IntPtr asset, int x, int y, int w, int h);

        /// <summary>
        /// Free reading buffer after PrepareReadingBuffer() was called.
        /// Happens automatically anyway when asset is destroyed.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Image_FreeReadingBuffer(IntPtr asset);

        /// <summary>
        /// Get pixel from image. Must call PrepareReadingBuffer() before calling this.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Image_GetPixel(IntPtr asset, int x, int y, ref float r, ref float g, ref float b, ref float a);

        /// <summary>
        /// Get string value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        static extern IntPtr BON_Config_GetStr(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string defaultVal);

        /// <summary>
        /// Get string value from config.
        /// </summary>
        public static string BON_Config_GetStr_(IntPtr config, string section, string name, string defaultVal)
        {
            var ret = BON_Config_GetStr(config, section, name, null);
            return ret != IntPtr.Zero ? Marshal.PtrToStringAnsi(ret) : defaultVal;
        }

        /// <summary>
        /// Get bool value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Config_GetBool(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, bool defaultVal);


        /// <summary>
        /// Checks if a section exists.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Config_SectionExists(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section);

        /// <summary>
        /// Checks if a key exists in section.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Config_KeyExists(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string key);

        /// <summary>
        /// Get int value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Config_GetInt(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, int defaultVal);

        /// <summary>
        /// Get float value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern float BON_Config_GetFloat(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, float defaultVal);

        /// <summary>
        /// Removes a key from config.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern float BON_Config_RemoveKey(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name);

        /// <summary>
        /// Set a value in config.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern float BON_Config_SetValue(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value);

        /// <summary>
        /// Get section name from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern IntPtr BON_Config_Section(IntPtr config, int index);

        /// <summary>
        /// Get section name from config.
        /// </summary>
        public static string BON_Config_Section_Str(IntPtr config, int index)
        {
            return Marshal.PtrToStringAnsi(BON_Config_Section(config, index));
        }

        /// <summary>
        /// Get sections count.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Config_SectionsCount(IntPtr config);

        /// <summary>
        /// Get key name from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        static extern IntPtr BON_Config_Key(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, int index);

        /// <summary>
        /// Get key name from config.
        /// </summary>
        public static string BON_Config_Key_Str(IntPtr config, string section, int index)
        {
            return Marshal.PtrToStringAnsi(BON_Config_Key(config, section, index));
        }

        /// <summary>
        /// Get keys count in section.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Config_KeysCount(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section);

        /// <summary>
        /// Get music track length.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern float BON_Music_Length(IntPtr music);

        /// <summary>
        /// Get sound track length.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern float BON_Sound_Length(IntPtr sound);


        /// <summary>
        /// Get if sound track is currently playing.
        /// </summary>

        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return: MarshalAs(UnmanagedType.I1)] public static extern bool BON_Sound_IsPlaying(IntPtr sound);

        /// <summary>
        /// Get font asset size.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Font_Size(IntPtr font);

    }
}
