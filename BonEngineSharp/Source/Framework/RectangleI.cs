using System;


namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Represent a rectangle.
    /// </summary>
    public struct RectangleI : IEquatable<RectangleI>
    {
        /// <summary>
        /// X position.
        /// </summary>
        public int X;

        /// <summary>
        /// Y position.
        /// </summary>
        public int Y;

        /// <summary>
        /// Rectangle width.
        /// </summary>
        public int Width;

        /// <summary>
        /// Rectangle height.
        /// </summary>
        public int Height;

        /// <summary>
        /// Clone this rectangle.
        /// </summary>
        /// <returns>Cloned rectangle.</returns>
        public RectangleI Clone()
        {
            return new RectangleI(X, Y, Width, Height);
        }

        /// <summary>
        /// Set / get rectangle left position.
        /// </summary>
        public int Left
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// Set / get rectangle right position.
        /// </summary>
        public int Right
        {
            get { return X + Width; }
            set { Width = value - Left; }
        }

        /// <summary>
        /// Set / get rectangle top position.
        /// </summary>
        public int Top
        {
            get { return Y; }
            set { Y = value; }
        }

        /// <summary>
        /// Set / get rectangle bottom position.
        /// </summary>
        public int Bottom
        {
            get { return Y + Height; }
            set { Height = value - Top; }
        }

        /// <summary>
        /// Create the rectangle.
        /// </summary>
        public RectangleI(int x = 0, int y = 0, int width = 0, int height = 0)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Set the rectangle components.
        /// </summary>
        public void Set(int x, int y, int w, int h)
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
        public bool Contains(PointI point)
        {
            return point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height;
        }

        /// <summary>
        /// Check if containing another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to test.</param>
        /// <returns>True if other rectangle is inside this rectangle.</returns>
        public bool Contains(RectangleI other)
        {
            return other.Left >= Left && other.Right <= Right && other.Top >= Top && other.Bottom <= Bottom;
        }

        /// <summary>
        /// Check if intersects with or containing another rectangle.
        /// </summary>
        /// <param name="other">Other rectangle to check.</param>
        /// <returns>True if containing or intersecting with given rectangle.</returns>
        public bool Overlaps(RectangleI other)
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
        /// Create rectangle from string.
        /// </summary>
        /// <param name="str">String to convert to rectangle (x,y,wight,height)</param>
        /// <returns>Rectangle instance.</returns>
        public static RectangleI FromString(string str)
        {
            var parts = str.Split(',');
            return new RectangleI(
                    int.Parse(parts[0].Trim()),
                    int.Parse(parts[1].Trim()),
                    int.Parse(parts[2].Trim()),
                    int.Parse(parts[3].Trim())
                );
        }

        /// <summary>
        /// Get absolute center point.
        /// Check if contains a point.
        /// </summary>
        public PointI Center => new PointI(X + Width / 2, Y + Height / 2);

        /// <summary>
        /// An empty rectangle const.
        /// </summary>
        public static readonly RectangleI Empty = new RectangleI(0, 0, 0, 0);

        /// <summary>
        /// Implicit conversion to RectangleF.
        /// </summary>
        public static implicit operator RectangleF(RectangleI p) => new RectangleF((float)p.X, (float)p.Y, (float)p.Width, (float)p.Height);

        /// <summary>
        /// Check if this Rectangle equals to another object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is RectangleI)) { return false; }
            var other = (RectangleI)obj;
            return (other.X == X) && (other.Y == Y) && (other.Width == Width) && (other.Height == Height);
        }

        /// <summary>
        /// Implement == operator.
        /// </summary>
        public static bool operator ==(RectangleI obj1, RectangleI obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Implement != operator.
        /// </summary>
        public static bool operator !=(RectangleI obj1, RectangleI obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Check if this Rectangle equals to another Rectangle.
        /// </summary>
        public bool Equals(RectangleI other)
        {
            return (other.X == X) && (other.Y == Y) && (other.Width == Width) && (other.Height == Height);
        }

        /// <summary>
        /// Implement hash code of color.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (int)X;
                hash = hash * 23 + (int)Y;
                hash = hash * 23 + (int)Width;
                hash = hash * 23 + (int)Height;
                return hash;
            }
        }
    }
}
