using System;

namespace BonEngineSharp.Framework
{
    /// <summary>
    /// Base color object.
    /// </summary>
    public struct Color
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
        /// Purple color const.
        /// </summary>
        public static readonly Color Purple = FromRGBA(1, 0, 1, 1);

        /// <summary>
        /// Teal color const.
        /// </summary>
        public static readonly Color Teal = FromRGBA(0, 1, 1, 1);

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
    }
}
