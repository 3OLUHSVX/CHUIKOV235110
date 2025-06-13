using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelStruct
{
    public struct Pixel : IEquatable<Pixel>
    {
        private int r;
        private int g;
        private int b;

        public int R
        {
            get => r;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("R must be between 0 and 255");
                r = value;
            }
        }

        public int G
        {
            get => g;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("G must be between 0 and 255");
                g = value;
            }
        }

        public int B
        {
            get => b;
            set
            {
                if (value < 0 || value > 255)
                    throw new ArgumentOutOfRangeException("B must be between 0 and 255");
                b = value;
            }
        }

        public int L => (int)Math.Round(0.3 * R + 0.6 * G + 0.1 * B);

        public Pixel(int r, int g, int b)
        {
            this.r = 0;
            this.g = 0;
            this.b = 0;
            R = r;
            G = g;
            B = b;
        }

        public override bool Equals(object obj)
        {
            return obj is Pixel pixel && Equals(pixel);
        }

        public bool Equals(Pixel other)
        {
            return R == other.R &&
                   G == other.G &&
                   B == other.B;
        }

        public static bool operator ==(Pixel left, Pixel right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Pixel left, Pixel right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return (R << 16) | (G << 8) | B;
        }

        public override string ToString()
        {
            return $"#{R:X2}{G:X2}{B:X2}";
        }

        public static Pixel operator *(double factor, Pixel pixel)
        {
            if (factor < 0)
                throw new ArgumentOutOfRangeException("Factor must be positive");

            int Clamp(double value)
            {
                int result = (int)Math.Round(value);
                return result > 255 ? 255 : result;
            }

            return new Pixel(
                Clamp(pixel.R * factor),
                Clamp(pixel.G * factor),
                Clamp(pixel.B * factor)
            );
        }
    }
}