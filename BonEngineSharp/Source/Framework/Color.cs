using System;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Base color object.
    /// </summary>
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Red component.
        /// </summary>
        public float R;

        /// <summary>
        /// Green component.
        /// </summary>
        public float G;

        /// <summary>
        /// Blue component.
        /// </summary>
        public float B;

        /// <summary>
        /// Opacity.
        /// </summary>
        public float A;
        
        /// <summary>
        /// Clone this color.
        /// </summary>
        /// <returns>Cloned color object.</returns>
        public Color Clone()
        {
            return new Color(R, G, B, A);
        }

        /// <summary>
        /// Red component as byte.
        /// </summary>
        public byte RByte
        {
            get { return (byte)(R * 255f); }
            set { R = (float)value / 255f; }
        }

        /// <summary>
        /// Green component as byte.
        /// </summary>
        public byte GByte
        {
            get { return (byte)(G * 255f); }
            set { G = (float)value / 255f; }
        }

        /// <summary>
        /// Blue component as byte.
        /// </summary>
        public byte BByte
        {
            get { return (byte)(B * 255f); }
            set { B = (float)value / 255f; }
        }

        /// <summary>
        /// Opacity as byte.
        /// </summary>
        public byte AByte
        {
            get { return (byte)(A * 255f); }
            set { A = (float)value / 255f; }
        }

        /// <summary>
        /// Create the color component.
        /// </summary>
        public Color(float r, float g, float b, float a = 1f)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Clone self and add other color to clone.
        /// </summary>
        /// <param name="other">Color to add.</param>
        /// <param name="includeAlpha">If true, will include alpha component.</param>
        /// <returns>Cloned color with added other color.</returns>
        public Color Add(Color other, bool includeAlpha = true)
        {
            var ret = Clone();
            ret.R += other.R;
            ret.G += other.G;
            ret.B += other.B;
            if (includeAlpha) { ret.A += other.A; }
            return ret;
        }

        /// <summary>
        /// Add other color to self.
        /// </summary>
        /// <param name="other">Color to add.</param>
        /// <param name="includeAlpha">If true, will include alpha component.</param>
        public void AddSelf(Color other, bool includeAlpha = true)
        {
            R += other.R;
            G += other.G;
            B += other.B;
            if (includeAlpha) { A += other.A; }
        }

        /// <summary>
        /// Decrease all color components and make sure in valid range (0-1).
        /// </summary>
        /// <param name="amount">Quantity to reduce.</param>
        /// <param name="includeAlpha">If true, will reduce opacity as well.</param>
        public void Decrease(float amount, bool includeAlpha)
        {
            R -= amount;
            G -= amount;
            B -= amount;
            if (includeAlpha) A -= amount;
            PutInRange();
        }

        /// <summary>
        /// Increase all color components and make sure in valid range (0-1).
        /// </summary>
        /// <param name="amount">Quantity to reduce.</param>
        /// <param name="includeAlpha">If true, will reduce opacity as well.</param>
        public void Increase(float amount, bool includeAlpha)
        {
            R += amount;
            G += amount;
            B += amount;
            if (includeAlpha) A += amount;
            PutInRange();
        }

        /// <summary>
        /// Make sure all color values are in given valid range.
        /// </summary>
        /// <param name="min">Min value for color components.</param>
        /// <param name="max">Max value for color components.</param>
        public void PutInRange(float min = 0f, float max = 1f)
        {
            if (R < min) R = min;
            if (R > max) R = max;
            if (G < min) G = min;
            if (G > max) G = max;
            if (B < min) B = min;
            if (B > max) B = max;
            if (A < min) A = min;
            if (A > max) A = max;
        }

        /// <summary>
        /// Create color from components.
        /// </summary>
        public static Color FromRGBA(float r, float g, float b, float a = 1f)
        {
            var ret = new Color();
            ret.R = r;
            ret.G = g;
            ret.B = b;
            ret.A = a;
            return ret;
        }

        /// <summary>
        /// Create color from components.
        /// </summary>
        public static Color FromBytes(byte r, byte g, byte b, byte a = 255)
        {
            var ret = new Color();
            ret.R = r / 255f;
            ret.G = g / 255f;
            ret.B = b / 255f;
            ret.A = a / 255f;
            return ret;
        }

        /// <summary>
        /// Create color from string with byte values.
        /// </summary>
        public static Color FromString(string str)
        {
            var parts = str.Split(',');
            return FromBytes(
                byte.Parse(parts[0].Trim()),
                byte.Parse(parts[1].Trim()),
                byte.Parse(parts[2].Trim()),
                parts.Length > 3 ? byte.Parse(parts[3].Trim()) : (byte)255
            );
        }

        /// <summary>
        /// White color const.
        /// </summary>
        public static readonly Color White = FromRGBA(1, 1, 1, 1);

        /// <summary>
        /// Black color const.
        /// </summary>
        public static readonly Color Black = FromRGBA(0, 0, 0, 1);

        /// <summary>
        /// Transparent black color const.
        /// </summary>
        public static readonly Color TransparentBlack = FromRGBA(0, 0, 0, 0);

        /// <summary>
        /// Transparent color const.
        /// </summary>
        public static readonly Color Transparent = FromRGBA(1, 1, 1, 0);

        /// <summary>
        /// Half transparent color const.
        /// </summary>
        public static readonly Color HalfTransparent = FromRGBA(1, 1, 1, 0.5f);

        /// <summary>
        /// Gray color const.
        /// </summary>
        public static readonly Color Gray = FromRGBA(0.5f, 0.5f, 0.5f, 1);

        /// <summary>
        /// Red color const.
        /// </summary>
        public static readonly Color Red = FromRGBA(1, 0, 0, 1);

        /// <summary>
        /// Green color const.
        /// </summary>
        public static readonly Color Green = FromRGBA(0, 1, 0, 1);

        /// <summary>
        /// Blue color const.
        /// </summary>
        public static readonly Color Blue = FromRGBA(0, 0, 1, 1);

        /// <summary>
        /// Yellow color const.
        /// </summary>
        public static readonly Color Yellow = FromRGBA(1, 1, 0, 1);

        /// <summary>
        /// Orange color const.
        /// </summary>
        public static readonly Color Orange = FromRGBA(1, 0.545f, 0, 1);

        /// <summary>
        /// Purple color const.
        /// </summary>
        public static readonly Color Purple = FromRGBA(1, 0, 1, 1);

        /// <summary>
        /// Teal color const.
        /// </summary>
        public static readonly Color Teal = FromRGBA(0, 1, 1, 1);

        /// <summary>
        /// Famous blue-ish Cornflower color (commonly used as background color).
        /// </summary>
        public static readonly Color Cornflower = new Color(0.2f, 0.5f, 1.0f);

        /// <summary>
        /// Convert color to pretty string, either as bytes or float values.
        /// </summary>
        public string ToString(bool asByte)
        {
            if (asByte)
            {
                return RByte.ToString() + "," + GByte.ToString() + "," + BByte.ToString() + "," + AByte.ToString();
            }
            else
            {
                return R.ToString() + "," + G.ToString() + "," + B.ToString() + "," + A.ToString();
            }
        }

        // for randomness
        static Random _rand = new Random();

        /// <summary>
        /// Create and return a random color.
        /// </summary>
        /// <returns>Random color.</returns>
        public static Color Random()
        {
            return new Color((float)_rand.NextDouble(), (float)_rand.NextDouble(), (float)_rand.NextDouble(), 1f);
        }

        /// <summary>
        /// Lerp between two colors.
        /// </summary>
        /// <param name="a">From color.</param>
        /// <param name="b">To color.</param>
        /// <param name="delta">Lerp factor.</param>
        /// <returns>Lerped color.</returns>
        public static Color Lerp(Color a, Color b, float delta)
        {
            return new Color((a.R * (1f - delta) + b.R * delta), (a.G * (1f - delta) + b.G * delta), (a.B * (1f - delta) + b.B * delta), (a.A * (1f - delta) + b.A * delta));
        }

        /// <summary>
        /// Check if this color equals to another object.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (!(obj is Color)) { return false; }
            var other = (Color)obj;
            return (other.R == R) && (other.G == G) && (other.B == B) && (other.A == A);
        }

        /// <summary>
        /// Implement == operator.
        /// </summary>
        public static bool operator ==(Color obj1, Color obj2)
        {
            return obj1.Equals(obj2);
        }

        /// <summary>
        /// Implement != operator.
        /// </summary>
        public static bool operator !=(Color obj1, Color obj2)
        {
            return !(obj1 == obj2);
        }

        /// <summary>
        /// Check if this color equals to another color.
        /// </summary>
        public bool Equals(Color other)
        {
            return (other.R == R) && (other.G == G) && (other.B == B) && (other.A == A);
        }

        /// <summary>
        /// Implement hash code of color.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * 23 + (int)R;
                hash = hash * 23 + (int)G;
                hash = hash * 23 + (int)B;
                hash = hash * 23 + (int)A;
                return hash;
            }
        }
    }
}
