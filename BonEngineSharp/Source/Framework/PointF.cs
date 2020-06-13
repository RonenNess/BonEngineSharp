using System;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Point class.
    /// </summary>
    public struct PointF
    {
        /// <summary>
        /// X component of the point.
        /// </summary>
        public float X;

        /// <summary>
        /// Y component of the point.
        /// </summary>
        public float Y;

        /// <summary>
        /// Create the point.
        /// </summary>
        public PointF(float x = 0, float y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Point with value 1,1.
        /// </summary>
        public static readonly PointF One = new PointF(1, 1);

        /// <summary>
        /// Point with value 0,0.
        /// </summary>
        public static readonly PointF Zero = new PointF(0, 0);

        /// <summary>
        /// Point with value 0.5, 0.5.
        /// </summary>
        public static readonly PointF Half = new PointF((float)0.5, (float)0.5);

        /// <summary>
        /// Multiply point with a scalar.
        /// </summary>
        public PointF Multiply(float scalar)
        {
            return new PointF(X * scalar, Y * scalar);
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointF Multiply(PointF other)
        {
            return new PointF(X * other.X, Y * other.Y);
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointF Multiply(float x, float y)
        {
            return new PointF(X * x, Y * y);
        }

        /// <summary>
        /// Divide point with a scalar.
        /// </summary>
        public PointF Divide(float scalar)
        {
            return new PointF(X / scalar, Y / scalar);
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointF Divide(PointF other)
        {
            return new PointF(X / other.X, Y / other.Y);
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointF Divide(float x, float y)
        {
            return new PointF(X / x, Y / y);
        }

        /// <summary>
        /// Add point with a scalar.
        /// </summary>
        public PointF Add(float scalar)
        {
            return new PointF(X + scalar, Y + scalar);
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointF Add(PointF other)
        {
            return new PointF(X + other.X, Y + other.Y);
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointF Add(float x, float y)
        {
            return new PointF(X + x, Y + y);
        }

        /// <summary>
        /// Substract point with a scalar.
        /// </summary>
        public PointF Substract(float scalar)
        {
            return new PointF(X - scalar, Y - scalar);
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointF Substract(PointF other)
        {
            return new PointF(X - other.X, Y - other.Y);
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointF Substract(float x, float y)
        {
            return new PointF(X - x, Y - y);
        }
		
		/// <summary>
        /// Rotate self by degrees.
        /// </summary>
		public PointF RotateSelf(float angle) 
		{ 
			// calc cos and sin of angle as radians
			var rad = angle * (Math.PI / 180.0);
			var cos = Math.Cos(rad);
			var sin = Math.Sin(rad);

			// calculate rotated position
			var _x = (cos * (X)) + (sin * (Y));
			var _y = (cos * (Y)) - (sin * (X));
			X = (float)_x;
			Y = (float)_y;
			return this;
		} 
		
		/// <summary>
        /// Rotate clone by degrees.
        /// </summary>
		public PointF Rotate(float angle) 
		{ 
			var ret = Clone();
			ret.RotateSelf(angle);
			return ret;
		} 
		
		/// <summary>
        /// Clone point.
        /// </summary>
		public PointF Clone()
		{
			return new PointF(X, Y);
		}
		
        /// <summary>
        /// Multiply point with a scalar.
        /// </summary>
        public PointF MultiplySelf(float scalar)
        {
            X *= scalar;
            Y *= scalar;
			return this;
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointF MultiplySelf(PointF other)
        {
            X *= other.X;
            Y *= other.Y;
			return this;
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointF MultiplySelf(float x, float y)
        {
            X *= x;
            Y *= y;
			return this;
        }

        /// <summary>
        /// Divide point with a scalar.
        /// </summary>
        public PointF DivideSelf(float scalar)
        {
            X /= scalar;
            Y /= scalar;
			return this;
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointF DivideSelf(PointF other)
        {
            X /= other.X;
            Y /= other.Y;
			return this;
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointF DivideSelf(float x, float y)
        {
            X /= x;
            Y /= y;
			return this;
        }

        /// <summary>
        /// Add point with a scalar.
        /// </summary>
        public PointF AddSelf(float scalar)
        {
            X += scalar;
            Y += scalar;
			return this;
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointF AddSelf(PointF other)
        {
            X += other.X;
            Y += other.Y;
			return this;
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointF AddSelf(float x, float y)
        {
            X += x;
            Y += y;
			return this;
        }

        /// <summary>
        /// Substract point with a scalar.
        /// </summary>
        public PointF SubstractSelf(float scalar)
        {
            X -= scalar;
            Y -= scalar;
			return this;
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointF SubstractSelf(PointF other)
        {
            X -= other.X;
            Y -= other.Y;
			return this;
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointF SubstractSelf(float x, float y)
        {
            X -= x;
            Y -= y;
			return this;
        }

        /// <summary>
        /// Get distance to another point.
        /// </summary>
        public float DistanceTo(PointF other)
        {
            return (float)Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        /// <summary>
        /// Convert direction in degrees to Point.
        /// </summary>
        public static PointF FromAngle(int directionDegrees)
        {
            var dirRads = directionDegrees * (Math.PI / 180);
            var ret = new PointF((float)System.Math.Cos(dirRads), (float)System.Math.Sin(dirRads));
            ret.Normalize();
            return ret;
        }

        /// <summary>
        /// Create point from string.
        /// </summary>
        /// <param name="str">String to parse, must be in format "x,y".</param>
        /// <returns>Point instance.</returns>
        public static PointF FromString(string str)
        {
            var parts = str.Split(',');
            float x = float.Parse(parts[0].Trim());
            float y = float.Parse(parts[1].Trim());
            return new PointF(x, y);
        }

        /// <summary>
        /// Convert point to degree.
        /// </summary>
        public short ToAngle()
        {
            var ret = (short)(Math.Atan2(Y, X) * (180f / (float)Math.PI));
            if (ret < 0) ret += 360;
            return ret;
        }

        /// <summary>
        /// Normalize this point value.
        /// </summary>
        public void Normalize()
        {
			if (X == 0 && Y == 0) { return; }
            float distance = (float)Math.Sqrt((X * X) + (Y * Y));
            X /= distance;
            Y /= distance;
        }

        /// <summary>
        /// Set point values.
        /// </summary>
        public void Set(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Calc point magnitude.
        /// </summary>
        public float Magnitude
        {
            get { return (float)Math.Sqrt(X * X + Y * Y); }
        }

        /// <summary>
        /// Check if this point equals to another point.
        /// </summary>
        public override bool Equals(object obj)
        {
            var other = (PointF)obj;
            return (other.X == X) && (other.Y == Y);
        }

        /// <summary>
        /// Implement hash code of point.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (int)X;
                hash = hash * 23 + (int)Y;
                return hash;
            }
        }

        /// <summary>
        /// Implicit conversion to pointI.
        /// </summary>
        public static implicit operator PointI(PointF p) => new PointI((int)p.X, (int)p.Y);
    }
}
