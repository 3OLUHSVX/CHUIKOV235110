using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EllipseStruct.UnitTests
{
    [TestFixture]
    public class EllipseTests
    {
        private const double Tolerance = 1e-13;

        [Test]
        public void Constructor_ValidParameters_CreatesEllipse()
        {
            var ellipse = new Ellipse(5.0, 3.0);
            Assert.That(ellipse.A, Is.EqualTo(5.0).Within(Tolerance));
            Assert.That(ellipse.B, Is.EqualTo(3.0).Within(Tolerance));
        }

        [Test]
        public void Constructor_InvalidParameters_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new Ellipse(0, 3));
            Assert.Throws<ArgumentException>(() => new Ellipse(-2, 3));
        }

        [TestCase(5.0, 3.0, 0.8)] 
        [TestCase(3.0, 5.0, 0.8)] 
        [TestCase(4.0, 4.0, 0.0)] 
        public void Eccentricity_CalculatesCorrectly(double a, double b, double expectedE)
        {
            var ellipse = new Ellipse(a, b);
            Assert.That(ellipse.E, Is.EqualTo(expectedE).Within(Tolerance));
        }

        [Test]
        public void Area_CalculatesCorrectly()
        {
            var ellipse = new Ellipse(5.0, 3.0);
            double expectedArea = Math.PI * 5.0 * 3.0;
            Assert.That(ellipse.Area, Is.EqualTo(expectedArea).Within(Tolerance));
        }

        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 3.0);
            Assert.That(ellipse1.Equals(ellipse2), Is.True);
        }

        [Test]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 3.0 + 2e-13); 
            Assert.That(ellipse1.Equals(ellipse2), Is.False);
        }

        [Test]
        public void Equals_NonEllipseObject_ReturnsFalse()
        {
            var ellipse = new Ellipse(5.0, 3.0);
            Assert.That(ellipse.Equals(new object()), Is.False);
        }

        [Test]
        public void GetHashCode_SameValues_ReturnsSameHash()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 3.0);
            Assert.That(ellipse1.GetHashCode(), Is.EqualTo(ellipse2.GetHashCode()));
        }

        [Test]
        public void GetHashCode_DifferentValues_ReturnsDifferentHash()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 3.0 + 1e-12);
            Assert.That(ellipse1.GetHashCode(), Is.Not.EqualTo(ellipse2.GetHashCode()));
        }

        [Test]
        public void EqualityOperator_SameValues_ReturnsTrue()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 3.0);
            Assert.That(ellipse1 == ellipse2, Is.True);
        }

        [Test]
        public void InequalityOperator_DifferentValues_ReturnsTrue()
        {
            var ellipse1 = new Ellipse(5.0, 3.0);
            var ellipse2 = new Ellipse(5.0, 4.0);
            Assert.That(ellipse1 != ellipse2, Is.True);
        }

        [Test]
        public void MultiplyOperator_ValidFactor_ReturnsScaledEllipse()
        {
            var ellipse = new Ellipse(2.0, 3.0);
            var scaledEllipse = 2.0 * ellipse;
            Assert.That(scaledEllipse.A, Is.EqualTo(4.0).Within(Tolerance));
            Assert.That(scaledEllipse.B, Is.EqualTo(6.0).Within(Tolerance));
        }

        [Test]
        public void MultiplyOperator_InvalidFactor_ThrowsException()
        {
            var ellipse = new Ellipse(2.0, 3.0);
            Assert.Throws<ArgumentException>(() =>
            {
                var result = 0.0 * ellipse;
            });
            Assert.Throws<ArgumentException>(() =>
            {
                var result = -1.0 * ellipse;
            });
        }

        [Test]
        public void ToString_ReturnsExpectedFormat()
        {
            var ellipse = new Ellipse(6.2, 3.21);
            string expected = "Эллипс с полуосями а = 6.2 и b = 3.21";
            Assert.That(ellipse.ToString(), Is.EqualTo(expected));
        }
    }
}