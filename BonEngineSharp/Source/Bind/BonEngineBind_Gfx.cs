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
        /// Draw text with outline on screen.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET, CallingConvention = CallingConvention.Cdecl)]
        public static extern void BON_Gfx_DrawTextWithOutline(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] string text, float x, float y, float r, float g, float b, float a, int fontSize, int maxWidth, int blend, float originX, float originY, float rotation, int outlineWidth, float outlineR, float outlineG, float outlineB, float outlineA);

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
        /// Get window size.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_WindowSize(ref int x, ref int y);

        /// <summary>
        /// Get renderable size.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_RenderableSize(ref int x, ref int y);

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

        /// <summary>
        /// Get the estimated bounding box of a text drawing.
        /// </summary>
        [DllImport(NATIVE_DLL_FILE_NAME, CharSet = CHARSET)]
        public static extern void BON_Gfx_GetTextBoundingBox(IntPtr font, [MarshalAs(UnmanagedType.LPStr)] string text, float x, float y, int fontSize, int maxWidth, float originX, float originY, float rotation, ref int outX, ref int outY, ref int outWidth, ref int outHeight);

    }
}
