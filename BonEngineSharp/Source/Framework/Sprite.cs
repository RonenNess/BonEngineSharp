using BonEngineSharp.Defs;
using BonEngineSharp.Assets;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// A renderable sprite - hold rendering params.
    /// </summary>
    public class Sprite
    {
        /// <summary>
        /// Source Image.
        /// </summary>
        public ImageAsset Image;

        /// <summary>
        /// Position.
        /// </summary>
        public PointF Position;

        /// <summary>
        /// Drawing size.
        /// </summary>
        public PointI Size;

        /// <summary>
        /// Blending mode.
        /// </summary>
        public BlendModes Blend = BlendModes.AlphaBlend;

        /// <summary>
        /// Source rectangle.
        /// </summary>
        public RectangleI SourceRect;

        /// <summary>
        /// Drawing origin (0.0 - 1.0 relative to sprite size).
        /// </summary>
        public PointF Origin;

        /// <summary>
        /// Drawing rotation.
        /// </summary>
        public float Rotation;

        /// <summary>
        /// Drawing color.
        /// </summary>
        public Color Color = Color.White;

        /// <summary>
        /// Get estimated dest rect, without rotation applied.
        /// </summary>
        public RectangleI LooseDestRect
        {
            get
            {
                var size = DestSize;
                return new RectangleI((int)(Position.X - size.X * Origin.X), (int)(Position.Y - size.Y * Origin.Y), size.X, size.Y);
            }
        }

        /// <summary>
        /// Get destination size in pixels.
        /// </summary>
        public PointI DestSize
        {
            get
            {
                var ret = Size;
                if (Image != null)
                {
                    if (ret.X == 0) { ret.X = SourceRect.Width == 0 ? Image.Width : SourceRect.Width; }
                    if (ret.Y == 0) { ret.Y = SourceRect.Height == 0 ? Image.Height : SourceRect.Height; }
                }
                if (ret.X < 0) { ret.X = -ret.X; }
                if (ret.Y < 0) { ret.Y = -ret.Y; }
                return ret;
            }
        }
    }
}
