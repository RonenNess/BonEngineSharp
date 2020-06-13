using System;
using System.Reflection;
using System.Runtime.InteropServices;


namespace BonEngineSharp
{

#region Static Constructor And Dll Resolve
    /// <summary>
    /// Import the public methods we use from the BonEngine native dll in order to implement the C# bind.
    /// This class wraps everything we need from the CAPI headers.
    /// </summary>
    internal static class _BonEngineBind
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

#endregion

#region General

        /// <summary>
        /// Start the engine.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Start(IntPtr scene);

        /// <summary>
        /// Stop the engine.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Stop();

        /// <summary>
        /// Callback without params.
        /// </summary>
        public delegate void NoParamsCallback();

        /// <summary>
        /// Callback with a single double.
        /// </summary>
        public delegate void DoubleParamCallback(double dt);

#endregion

#region Scene

        /// <summary>
        /// Create a scene.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr BON_Scene_Create(
            [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback onLoad,
            [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback onUnload,
            [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback onStart,
            [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback onDraw,
            [MarshalAs(UnmanagedType.FunctionPtr)]DoubleParamCallback onUpdate,
            [MarshalAs(UnmanagedType.FunctionPtr)]DoubleParamCallback onFixedUpdate);

        /// <summary>
        /// Destroy a scene.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Scene_Destroy(IntPtr scene);

        /// <summary>
        /// Get if its the first scene we loaded.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Scene_IsFirstScene(IntPtr scene);

#endregion

#region Engine

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
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Engine_Destroyed();

        /// <summary>
        /// Is the engine running?
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Engine_Running();

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
        public static extern IntPtr BON_Manager_Create([MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback initialize, [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback start, [MarshalAs(UnmanagedType.FunctionPtr)]NoParamsCallback dispose, [MarshalAs(UnmanagedType.FunctionPtr)]DoubleParamCallback update, [MarshalAs(UnmanagedType.LPStr)] string id);

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

        #endregion

#region Game Manager

        /// <summary>
        /// Exit game.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Game_Exit();

        /// <summary>
        /// Change scene.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Game_ChangeScene(IntPtr scene);

        /// <summary>
        /// Load config.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Game_LoadConfig([MarshalAs(UnmanagedType.LPStr)] string path);

        /// <summary>
        /// Get elapsed time.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern double BON_Game_ElapsedTime();

        /// <summary>
        /// Get delta time.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern double BON_Game_DeltaTime();

#endregion

#region Log Manager

        /// <summary>
        /// Check if log level is valid.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Log_IsValid(int level);

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

#endregion

#region Diagnostics Manager

        /// <summary>
        /// Get diagnostics counter.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern long BON_Diagnostics_GetCounter(int id);

        /// <summary>
        /// Increase diagnostics counter.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Diagnostics_IncreaseCounter(int id, int amount);
        
        /// <summary>
        /// Reset diagnostics counter.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Diagnostics_ResetCounter(int id);

        /// <summary>
        /// Get FPS count.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Diagnostics_FpsCounter();

#endregion

#region Assets Manager

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
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Assets_SaveConfig(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string filename);
        
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

#endregion

#region Assets

        /// <summary>
        /// Check if an asset is valid.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Asset_IsValid(IntPtr asset);

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
        /// Get string value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        static extern IntPtr BON_Config_GetStr(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string defaultVal);

        /// <summary>
        /// Get string value from config.
        /// </summary>
        public static string BON_Config_GetStr_(IntPtr config, string section, string name, string defaultVal)
        {
            return Marshal.PtrToStringAnsi(BON_Config_GetStr(config, section, name, defaultVal));
        }

        /// <summary>
        /// Get bool value from config, with raw return value.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Config_GetBool(IntPtr config, [MarshalAs(UnmanagedType.LPStr)] string section, [MarshalAs(UnmanagedType.LPStr)] string name, bool defaultVal);

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
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Sound_IsPlaying(IntPtr sound);

        /// <summary>
        /// Get font asset size.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Font_Size(IntPtr font);
#endregion

#region Gfx Manager

        /// <summary>
        /// Draw an image on screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawImage(IntPtr image, float x, float y, int width, int height, int blend);

	    /// <summary>
        /// Draw an image on screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawImageEx(IntPtr image, float x, float y, int width, int height, int blend, int sx, int sy, int swidth, int sheight, float originX, float originY, float rotation, float r, float g, float b, float a);

        /// <summary>
        /// Draw text on sreen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Gfx_DrawText(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] string text, float x, float y, float r, float g, float b, float a, int fontSize, int maxWidth, int blend, float originX, float originY, float rotation);

        /// <summary>
        /// Draw a line.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawLine(int x1, int y1, int x2, int y2, float r, float g, float b, float a, int blend);

        /// <summary>
        /// Draw a pixel.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawPixel(int x, int y, float r, float g, float b, float a, int blend);

        /// <summary>
        /// Set viewport.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_SetViewport(int x, int y, int w, int h);

        /// <summary>
        /// Set window properties.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Gfx_SetWindowProperties([MarshalAs(UnmanagedType.LPStr)] string title, int width, int height, int windowMode, bool showCursor);

        /// <summary>
        /// Set window title.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Gfx_SetTitle([MarshalAs(UnmanagedType.LPStr)] string title);

        /// <summary>
        /// Get window size X.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Gfx_WindowSizeX();

        /// <summary>
        /// Get window size Y.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Gfx_WindowSizeY();

        /// <summary>
        /// Set rendering target.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_SetRenderTarget(IntPtr image);

        /// <summary>
        /// Draw a rectangle on screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawRectangle(int x, int y, int w, int h, float r, float g, float b, float a, bool filled, int blend);
        
        /// <summary>
        /// Draw a circle on screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_DrawCircle(int x, int y, int radius, float r, float g, float b, float a, bool filled, int blend);

        /// <summary>
        /// Clear screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_ClearScreen(float r, float g, float b, float a, int x, int y, int w, int h);

#endregion

#region Sfx Manager

        /// <summary>
        /// Set audio device properties.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetAudioProperties(int frequency, int format, bool stereo, int audio_chunk_size);

        /// <summary>
        /// Play music track.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_PlayMusic(IntPtr music, int volume, int loops);

        /// <summary>
        /// Pause music.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_PauseMusic(bool pause);

        /// <summary>
        /// Set music volume.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetMusicVolume(int volume);

        /// <summary>
        /// Stop music.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_StopMusic();

        /// <summary>
        /// Play sound.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern
        int BON_Sfx_PlaySound(IntPtr sound, int volume, int loops, float pitch);

        /// <summary>
        /// Play sound.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern int BON_Sfx_PlaySoundEx(IntPtr sound, int volume, int loops, float pitch, float panLeft, float panRight, float distance);

        /// <summary>
        /// Set channel distance.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelDistance(int channel, float distance);

        /// <summary>
        /// Set channel volume.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelVolume(int channel, int volume);

        /// <summary>
        /// Set channel panning.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetChannelPanning(int channel, float panLeft, float panRight);

        /// <summary>
        /// Stop channel.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_StopChannel(int channel);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Sfx_SetMasterVolume(int soundEffectsVolume, int musicVolume);

        #endregion

#region Input Manager

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_Down([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_ReleasedNow([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_PressedNow([MarshalAs(UnmanagedType.LPStr)] string actionId);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyDown(int key);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyReleasedNow(int key);

        /// <summary>
        /// Set master volumes.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        [return:MarshalAs(UnmanagedType.I1)] public static extern bool BON_Input_KeyPressedNow(int key);

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

#endregion

    }
}
