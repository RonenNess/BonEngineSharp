using System;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Point class.
    /// </summary>
    public struct PointI
    {
        /// <summary>
        /// X component of the point.
        /// </summary>
        public int X;

        /// <summary>
        /// Y component of the point.
        /// </summary>
        public int Y;

        /// <summary>
        /// Create the point.
        /// </summary>
        public PointI(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Point with value 1,1.
        /// </summary>
        public static readonly PointI One = new PointI(1, 1);

        /// <summary>
        /// Point with value 0,0.
        /// </summary>
        public static readonly PointI Zero = new PointI(0, 0);

        /// <summary>
        /// Point with value 0.5, 0.5.
        /// </summary>
        public static readonly PointI Half = new PointI((int)0.5, (int)0.5);

        /// <summary>
        /// Multiply point with a scalar.
        /// </summary>
        public PointI Multiply(int scalar)
        {
            return new PointI(X * scalar, Y * scalar);
        }

        /// <summary>
        /// Multiply point with a scalar.
        /// </summary>
        public PointI Multiply(float scalar)
        {
            return new PointI((int)(X * scalar), (int)(Y * scalar));
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointI Multiply(PointI other)
        {
            return new PointI(X * other.X, Y * other.Y);
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointI Multiply(int x, int y)
        {
            return new PointI(X * x, Y * y);
        }

        /// <summary>
        /// Divide point with a scalar.
        /// </summary>
        public PointI Divide(int scalar)
        {
            return new PointI(X / scalar, Y / scalar);
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointI Divide(PointI other)
        {
            return new PointI(X / other.X, Y / other.Y);
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointI Divide(int x, int y)
        {
            return new PointI(X / x, Y / y);
        }

        /// <summary>
        /// Add point with a scalar.
        /// </summary>
        public PointI Add(int scalar)
        {
            return new PointI(X + scalar, Y + scalar);
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointI Add(PointI other)
        {
            return new PointI(X + other.X, Y + other.Y);
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointI Add(int x, int y)
        {
            return new PointI(X + x, Y + y);
        }

        /// <summary>
        /// Substract point with a scalar.
        /// </summary>
        public PointI Substract(int scalar)
        {
            return new PointI(X - scalar, Y - scalar);
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointI Substract(PointI other)
        {
            return new PointI(X - other.X, Y - other.Y);
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointI Substract(int x, int y)
        {
            return new PointI(X - x, Y - y);
        }
		
		/// <summary>
        /// Rotate self by degrees.
        /// </summary>
		public PointI RotateSelf(float angle) 
		{ 
			// calc cos and sin of angle as radians
			var rad = angle * (Math.PI / 180.0);
			var cos = Math.Cos(rad);
			var sin = Math.Sin(rad);

			// calculate rotated position
			var _x = (cos * (X)) + (sin * (Y));
			var _y = (cos * (Y)) - (sin * (X));
			X = (int)_x;
			Y = (int)_y;
			return this;
		} 
		
		/// <summary>
        /// Rotate clone by degrees.
        /// </summary>
		public PointI Rotate(float angle) 
		{ 
			var ret = Clone();
			ret.RotateSelf(angle);
			return ret;
		} 
		
		/// <summary>
        /// Clone point.
        /// </summary>
		public PointI Clone()
		{
			return new PointI(X, Y);
		}
		
        /// <summary>
        /// Multiply point with a scalar.
        /// </summary>
        public PointI MultiplySelf(int scalar)
        {
            X *= scalar;
            Y *= scalar;
			return this;
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointI MultiplySelf(PointI other)
        {
            X *= other.X;
            Y *= other.Y;
			return this;
        }

        /// <summary>
        /// Multiply point with a point.
        /// </summary>
        public PointI MultiplySelf(int x, int y)
        {
            X *= x;
            Y *= y;
			return this;
        }

        /// <summary>
        /// Divide point with a scalar.
        /// </summary>
        public PointI DivideSelf(int scalar)
        {
            X /= scalar;
            Y /= scalar;
			return this;
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointI DivideSelf(PointI other)
        {
            X /= other.X;
            Y /= other.Y;
			return this;
        }

        /// <summary>
        /// Divide point with a point.
        /// </summary>
        public PointI DivideSelf(int x, int y)
        {
            X /= x;
            Y /= y;
			return this;
        }

        /// <summary>
        /// Add point with a scalar.
        /// </summary>
        public PointI AddSelf(int scalar)
        {
            X += scalar;
            Y += scalar;
			return this;
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointI AddSelf(PointI other)
        {
            X += other.X;
            Y += other.Y;
			return this;
        }

        /// <summary>
        /// Add point with a point.
        /// </summary>
        public PointI AddSelf(int x, int y)
        {
            X += x;
            Y += y;
			return this;
        }

        /// <summary>
        /// Substract point with a scalar.
        /// </summary>
        public PointI SubstractSelf(int scalar)
        {
            X -= scalar;
            Y -= scalar;
			return this;
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointI SubstractSelf(PointI other)
        {
            X -= other.X;
            Y -= other.Y;
			return this;
        }

        /// <summary>
        /// Substract point with a point.
        /// </summary>
        public PointI SubstractSelf(int x, int y)
        {
            X -= x;
            Y -= y;
			return this;
        }

        /// <summary>
        /// Get distance to another point.
        /// </summary>
        public float DistanceTo(PointI other)
        {
            return (float)Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        /// <summary>
        /// Convert direction in degrees to Point.
        /// </summary>
        public static PointI FromAngle(int directionDegrees)
        {
            var dirRads = directionDegrees * (Math.PI / 180);
            var ret = new PointI((int)System.Math.Cos(dirRads), (int)System.Math.Sin(dirRads));
            ret.Normalize();
            return ret;
        }

        /// <summary>
        /// Create point from string.
        /// </summary>
        /// <param name="str">String to parse, must be in format "x,y".</param>
        /// <returns>Point instance.</returns>
        public static PointI FromString(string str)
        {
            var parts = str.Split(',');
            int x = int.Parse(parts[0].Trim());
            int y = int.Parse(parts[1].Trim());
            return new PointI(x, y);
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
            int distance = (int)Math.Sqrt((X * X) + (Y * Y));
            X /= distance;
            Y /= distance;
        }

        /// <summary>
        /// Set point values.
        /// </summary>
        public void Set(int x, int y)
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
            var other = (PointI)obj;
            return (other.X == X) && (other.Y == Y);
        }

        /// <summary>
        /// Lerp between two points.
        /// </summary>
        /// <param name="a">From point.</param>
        /// <param name="b">To point.</param>
        /// <param name="delta">Lerp factor.</param>
        /// <returns>Lerped point.</returns>
        public static PointI Lerp(PointI a, PointI b, float delta)
        {
            return new PointI((int)((a.X * (1f - delta) + b.X * delta)), (int)((a.Y * (1f - delta) + b.Y * delta)));
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
        /// Implicit conversion to pointF.
        /// </summary>
        public static implicit operator PointF(PointI p) => new PointF((float)p.X, (float)p.Y);
    }
}
