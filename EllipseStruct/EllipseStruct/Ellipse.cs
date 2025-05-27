using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllipseStruct
{
    public struct Ellipse
    {
        private double _a;
        private double _b;
        private const double Tolerance = 1e-13;

        public double A
        {
            get => _a;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось A должна быть положительной.");
                _a = value;
            }
        }

        public double B
        {
            get => _b;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Полуось B должна быть положительной.");
                _b = value;
            }
        }

        public double E
        {
            get
            {
                if (A >= B)
                    return Math.Sqrt(A * A - B * B) / A;
                else
                    return Math.Sqrt(B * B - A * A) / B;
            }
        }

        public double Area => Math.PI * A * B;

        public Ellipse(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new ArgumentException("Полуоси должны быть положительными.");

            _a = a;
            _b = b;
        }

        public override string ToString()
        {
            var culture = CultureInfo.InvariantCulture;

            string FormatDouble(double value)
            {
                string formatted = value.ToString("0.###############", culture);
                if (formatted.Contains("."))
                {
                    formatted = formatted.TrimEnd('0').TrimEnd('.');
                }
                return formatted;
            }

            return $"Эллипс с полуосями а = {FormatDouble(A)} и b = {FormatDouble(B)}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Ellipse other)
                return Math.Abs(A - other.A) < Tolerance && Math.Abs(B - other.B) < Tolerance;
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Math.Round(A, 13).GetHashCode();
                hash = hash * 23 + Math.Round(B, 13).GetHashCode();
                return hash;
            }
        }

        public static Ellipse operator *(double factor, Ellipse ellipse)
        {
            if (factor <= 0)
                throw new ArgumentException("Коэффициент должен быть положительным.");

            return new Ellipse(ellipse.A * factor, ellipse.B * factor);
        }

        public static bool operator ==(Ellipse left, Ellipse right) => left.Equals(right);
        public static bool operator !=(Ellipse left, Ellipse right) => !left.Equals(right);
    }
}