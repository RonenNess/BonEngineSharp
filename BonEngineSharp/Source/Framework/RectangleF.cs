using System;


namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Represent a rectangle.
    /// </summary>
    public struct RectangleF
    {
        /// <summary>
        /// X position.
        /// </summary>
        public float X;

        /// <summary>
        /// Y position.
        /// </summary>
        public float Y;

        /// <summary>
        /// Rectangle width.
        /// </summary>
        public float Width;

        /// <summary>
        /// Rectangle height.
        /// </summary>
        public float Height;

        /// <summary>
        /// Set / get rectangle left position.
        /// </summary>
        public float Left
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// Set / get rectangle right position.
        /// </summary>
        public float Right
        {
            get { return X + Width; }
            set { Width = value - Left; }
        }

        /// <summary>
        /// Set / get rectangle top position.
        /// </summary>
        public float Top
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// Set / get rectangle bottom position.
        /// </summary>
        public float Bottom
        {
            get { return Y + Height; }
            set { Height = value - Top; }
        }

        /// <summary>
        /// Create the rectangle.
        /// </summary>
        public RectangleF(float x = 0, float y = 0, float width = 0, float height = 0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Set the rectangle components.
        /// </summary>
        public void Set(float x, float y, float w, float h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        /// <summary>
        /// Reset the rectangle.
        /// </summary>
        public void Reset()
        {
            X = Y = Width = Height = 0;
        }

        /// <summary>
        /// Check if contains a point.
        /// </summary>
        /// <param name="point">Point to check.</param>
        /// <returns>If point is within the rectangle.</returns>
        public bool Contains(PointF point)
        {
            return point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height;
        }

        /// <summary>
        /// Check if containing another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to test.</param>
        /// <returns>True if other rectangle is inside this rectangle.</returns>
        public bool Contains(RectangleF other)
        {
            return other.Left >= Left && other.Right <= Right && other.Top >= Top && other.Bottom <= Bottom;
        }

        /// <summary>
        /// Check if intersects with or containing another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to check.</param>
        /// <returns>True if containing or intersecting with given rectangle.</returns>
        public bool Overlaps(RectangleF other)
        {
            // if one RectangleI is on left side of other 
            if (Left > other.Right || other.Left > Right)
            {
                return false;
            }

            // if one RectangleI is above other 
            if (Top > other.Bottom || other.Top > Bottom)
            {
                return false;
            }

            // rectangleIs overlaps
            return true;
        }

        /// <summary>
        /// Get absolute center point.
        /// Check if contains a point.
        /// </summary>
        public PointF Center => new PointF(X + Width / 2, Y + Height / 2);

        /// <summary>
        /// An empty rectangle const.
        /// </summary>
        public static readonly RectangleF Empty = new RectangleF(0, 0, 0, 0);

        /// <summary>
        /// Implicit conversion to RectangleI.
        /// </summary>
        public static implicit operator RectangleI(RectangleF p) => new RectangleI((int)p.X, (int)p.Y, (int)p.Width, (int)p.Height);

    }
}
