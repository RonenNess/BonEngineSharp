using System;
using BonEngineSharp.Assets;
using BonEngineSharp.Framework;
using BonEngineSharp.Defs;

namespace BonEngineSharp.Managers
{
    /// <summary>
    /// Gfx manager.
    /// Responsible to rendering sprites, shapes, texts, and control the main window's properties.
    /// </summary>
    public class GfxManager : IManager
    {
        /// <summary>
        /// Get manager id.
        /// </summary>
        public override string Id => "gfx";

        /// <summary>
        /// Draws an image on screen.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawImage(ImageAsset image, PointF position, BlendModes blend = BlendModes.AlphaBlend)
        {
            DrawImage(image, position, PointI.Zero, blend);
        }

        /// <summary>
        /// Draws an image on screen.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="size">Drawing size.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawImage(ImageAsset image, PointF position, PointI size, BlendModes blend = BlendModes.AlphaBlend)
        {
            if (!image.HaveHandle) { throw new Exception("Tried to render an image without handle!"); }
            _BonEngineBind.BON_Gfx_DrawImage(image._handle, position.X, position.Y, size.X, size.Y, (int)blend);
        }

        /// <summary>
        /// Draws an image on screen.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="size">Drawing size.</param>
        /// <param name="blend">Blend mode.</param>
        /// <param name="sourceRect">Source rectangle to draw.</param>
        public void DrawImage(ImageAsset image, PointF position, PointI size, BlendModes blend, RectangleI sourceRect)
        {
            DrawImage(image, position, size, blend, sourceRect, PointF.Zero, 0.0f, Color.White);
        }

        /// <summary>
        /// Draws an image on screen.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="size">Drawing size.</param>
        /// <param name="blend">Blend mode.</param>
        /// <param name="sourceRect">Source rectangle to draw.</param>
        /// <param name="origin">Rotation and source position origin (relative to size).</param>
        /// <param name="rotation">Rotation, in degrees.</param>
        public void DrawImage(ImageAsset image, PointF position, PointI size, BlendModes blend, RectangleI sourceRect, PointF origin, float rotation = 0.0f)
        {
            DrawImage(image, position, size, blend, sourceRect, origin, rotation, Color.White);
        }

        /// <summary>
        /// Draws an image on screen.
        /// </summary>
        /// <param name="image">Image to draw.</param>
        /// <param name="position">Drawing position.</param>
        /// <param name="size">Drawing size.</param>
        /// <param name="blend">Blend mode.</param>
        /// <param name="sourceRect">Source rectangle to draw.</param>
        /// <param name="origin">Rotation and source position origin (relative to size).</param>
        /// <param name="rotation">Rotation, in degrees.</param>
        /// <param name="color">Tint color.</param>
        public void DrawImage(ImageAsset image, PointF position, PointI size, BlendModes blend, RectangleI sourceRect, PointF origin, float rotation, Color color)
        {
            if (!image.HaveHandle) { throw new Exception("Tried to render an image without handle!"); }
            _BonEngineBind.BON_Gfx_DrawImageEx(image._handle, position.X, position.Y, size.X, size.Y, (int)blend, sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height, origin.X, origin.Y, rotation, color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// Draw a sprite on screen.
        /// </summary>
        /// <param name="sprite">Sprite to draw.</param>
        public void DrawSprite(Sprite sprite)
        {
            DrawImage(sprite.Image, sprite.Position, sprite.Size, sprite.Blend, sprite.SourceRect, sprite.Origin, sprite.Rotation, sprite.Color);
        }

        /// <summary>
        /// Draw a sprite on screen.
        /// </summary>
        /// <param name="sprite">Sprite to draw.</param>
        /// <param name="offset">Extra offset from sprite original position.</param>
        public void DrawSprite(Sprite sprite, PointF offset)
        {
            DrawImage(sprite.Image, sprite.Position.Add(offset), sprite.Size, sprite.Blend, sprite.SourceRect, sprite.Origin, sprite.Rotation, sprite.Color);
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        /// <param name="color">Text color.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="maxWidth">Max line width.</param>
        /// <param name="blend">Blend mode.</param>
        /// <param name="origin">Text origin.</param>
        /// <param name="rotation">Text rotation.</param>
        public void DrawText(FontAsset font, string text, PointF position, Color color, int fontSize, int maxWidth, BlendModes blend, PointF origin, float rotation)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            _BonEngineBind.BON_Gfx_DrawText(font._handle, text, position.X, position.Y, color.R, color.G, color.B, color.A, fontSize, maxWidth, (int)blend, origin.X, origin.Y, rotation);
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        /// <param name="color">Text color.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="maxWidth">Max line width.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawText(FontAsset font, string text, PointF position, Color color, int fontSize = 0, int maxWidth = 0, BlendModes blend = BlendModes.AlphaBlend)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            _BonEngineBind.BON_Gfx_DrawText(font._handle, text, position.X, position.Y, color.R, color.G, color.B, color.A, fontSize, maxWidth, (int)blend, 0, 0, 0);
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        /// <param name="color">Text color.</param>
        /// <param name="outlineColor">Text outline color.</param>
        /// <param name="outlineWidth">Text outline width.</param>
        /// <param name="origin">Text origin point.</param>
        /// <param name="rotation">Rotate text.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="maxWidth">Max line width.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawText(FontAsset font, string text, PointF position, Color color, Color outlineColor, int outlineWidth, PointF origin, float rotation, int fontSize = 0, int maxWidth = 0, BlendModes blend = BlendModes.AlphaBlend)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            _BonEngineBind.BON_Gfx_DrawTextWithOutline(font._handle, text, position.X, position.Y, color.R, color.G, color.B, color.A, fontSize, maxWidth, (int)blend, origin.X, origin.Y, rotation, outlineWidth, outlineColor.R, outlineColor.G, outlineColor.B, outlineColor.A);
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        /// <param name="color">Text color.</param>
        /// <param name="outlineColor">Text outline color.</param>
        /// <param name="outlineWidth">Text outline width.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="maxWidth">Max line width.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawText(FontAsset font, string text, PointF position, Color color, Color outlineColor, int outlineWidth = 1, int fontSize = 0, int maxWidth = 0, BlendModes blend = BlendModes.AlphaBlend)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            _BonEngineBind.BON_Gfx_DrawTextWithOutline(font._handle, text, position.X, position.Y, color.R, color.G, color.B, color.A, fontSize, maxWidth, (int)blend, 0, 0, 0, outlineWidth, outlineColor.R, outlineColor.G, outlineColor.B, outlineColor.A);
        }

        /// <summary>
        /// Draw text on screen.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        public void DrawText(FontAsset font, string text, PointF position)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            _BonEngineBind.BON_Gfx_DrawText(font._handle, text, position.X, position.Y, 1f, 1f, 1f, 1f, 0, 0, (int)BlendModes.AlphaBlend, 0, 0, 0);
        }

        /// <summary>
        /// Get the estimated bounding box of a text rendering.
        /// </summary>
        /// <param name="font">Font to use.</param>
        /// <param name="text">Text to draw.</param>
        /// <param name="position">Text position.</param>
        /// <param name="fontSize">Font size.</param>
        /// <param name="maxWidth">Max line width.</param>
        /// <param name="origin">Text origin.</param>
        /// <param name="rotation">Text rotation.</param>
        /// <returns>Estimated text drawing bounding box.</returns>
        public RectangleI GetTextBoundingBox(FontAsset font, string text, PointF position, int fontSize, int maxWidth, PointF origin, float rotation)
        {
            if (!font.HaveHandle) { throw new Exception("Tried to render a font without handle!"); }
            RectangleI ret = new RectangleI();
            _BonEngineBind.BON_Gfx_GetTextBoundingBox(font._handle, text, position.X, position.Y, fontSize, maxWidth, origin.X, origin.Y, rotation, ref ret.X, ref ret.Y, ref ret.Width, ref ret.Height);
            return ret;
        }

        /// <summary>
        /// Draw a line.
        /// </summary>
        /// <param name="from">Source point.</param>
        /// <param name="to">Destination point.</param>
        /// <param name="color">Line color.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawLine(PointI from, PointI to, Color color, BlendModes blend = BlendModes.Opaque)
        {
            _BonEngineBind.BON_Gfx_DrawLine(from.X, from.Y, to.X, to.Y, color.R, color.G, color.B, color.A, (int)blend);
        }

        /// <summary>
        /// Draw a pixel.
        /// </summary>
        /// <param name="position">Pixel position.</param>
        /// <param name="color">Pixel color.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawPixel(PointI position, Color color, BlendModes blend = BlendModes.Opaque)
        {
            _BonEngineBind.BON_Gfx_DrawPixel(position.X, position.Y, color.R, color.G, color.B, color.A, (int)blend);
        }

        /// <summary>
        /// Set window properties.
        /// This will recreate the window.
        /// </summary>
        /// <param name="title">Window title.</param>
        /// <param name="width">Window width (0 for fullscreen).</param>
        /// <param name="height">Window height (0 for fullscreen).</param>
        /// <param name="windowMode">Window startup mode.</param>
        /// <param name="showCursor">Show / hide cursor.</param>
        public void SetWindowProperties(string title, int width, int height, WindowModes windowMode, bool showCursor)
        {
            _BonEngineBind.BON_Gfx_SetWindowProperties(title, width, height, (int)windowMode, showCursor);
        }

        /// <summary>
        /// Set active effect to use for future rendering.
        /// Note: active effect resets after every new frame.
        /// </summary>
        /// <param name="effect">New active effect to set, or null to disable special effects.</param>
        public void UseEffect(EffectAsset effect)
        {
            _BonEngineBind.BON_Gfx_UseEffect(effect == null ? IntPtr.Zero : effect._handle);
        }

        /// <summary>
        /// Set window title.
        /// </summary>
        /// <param name="title">New title.</param>
        public void SetTitle(string title)
        {
            _BonEngineBind.BON_Gfx_SetTitle(title);
        }

        /// <summary>
        /// Get current window size.
        /// </summary>
        public PointI WindowSize
        {
            get
            {
                var ret = new PointI();
                _BonEngineBind.BON_Gfx_WindowSize(ref ret.X, ref ret.Y);
                return ret;
            }
        }

        /// <summary>
        /// Get currently renderable size.
        /// If a viewport is set, will return viewport size.
        /// If a render target is set, will return render target size.
        /// If none of the above are set, will just return window size.
        /// </summary>
        public PointI RenderableSize
        {
            get
            {
                var ret = new PointI();
                _BonEngineBind.BON_Gfx_RenderableSize(ref ret.X, ref ret.Y);
                return ret;
            }    
        }

        /// <summary>
        /// Get or set render target.
        /// Render target is a texture to draw on. Later you can use this texture and draw it as sprite.
        /// </summary>
        public ImageAsset RenderTarget
        {
            get { return _renderTarget; }
            set
            {
                _renderTarget = value;
                _BonEngineBind.BON_Gfx_SetRenderTarget(value != null ? value._handle : IntPtr.Zero);
            }
        }
        ImageAsset _renderTarget;

        /// <summary>
        /// Draws a rectangle.
        /// </summary>
        /// <param name="rectangle">Rectangle to draw.</param>
        /// <param name="color">Drawing color.</param>
        /// <param name="filled">Draw filled / hollow rectangle.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawRectangle(RectangleI rectangle, Color color, bool filled, BlendModes blend = BlendModes.AlphaBlend)
        {
            _BonEngineBind.BON_Gfx_DrawRectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, color.R, color.G, color.B, color.A, filled, (int)blend);
        }

        /// <summary>
        /// Draws a circle.
        /// </summary>
        /// <param name="center">Circle center.</param>
        /// <param name="radius">Circle radius.</param>
        /// <param name="color">Drawing color.</param>
        /// <param name="filled">Draw filled / hollow circle.</param>
        /// <param name="blend">Blend mode.</param>
        public void DrawCircle(PointI center, int radius, Color color, bool filled, BlendModes blend = BlendModes.AlphaBlend)
        {
            _BonEngineBind.BON_Gfx_DrawCircle(center.X, center.Y, radius, color.R, color.G, color.B, color.A, filled, (int)blend);
        }

        /// <summary>
        /// Clear a region of screen.
        /// </summary>
        /// <param name="color">Color to clear to.</param>
        /// <param name="region">Region to clear.</param>
        public void ClearScreen(Color color, RectangleI region)
        {
            _BonEngineBind.BON_Gfx_ClearScreen(color.R, color.G, color.B, color.A, region.X, region.Y, region.Width, region.Height);
        }


        /// <summary>
        /// Clear the entire screen.
        /// </summary>
        /// <param name="color">Color to clear to.</param>
        public void ClearScreen(Color color)
        {
            _BonEngineBind.BON_Gfx_ClearScreen(color.R, color.G, color.B, color.A, 0, 0, 0, 0);
        }

        /// <summary>
        /// Set rendering viewport (limits where you can render).
        /// To disable viewport, set RectangleI.Empty.
        /// </summary>
        public RectangleI Viewport
        {
            set
            {
                _BonEngineBind.BON_Gfx_SetViewport(value.X, value.Y, value.Width, value.Height);
            }
        }
    }
}
