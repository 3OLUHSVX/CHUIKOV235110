namespace PixelStruct.Tests
{
    [TestFixture]
    public class PixelTests
    {
        [Test]
        public void Constructor_ValidValues_InitializesProperties()
        {
            var pixel = new Pixel(223, 8, 155);

            Assert.AreEqual(223, pixel.R);
            Assert.AreEqual(8, pixel.G);
            Assert.AreEqual(155, pixel.B);
        }

        [TestCase(-1, 0, 0)]
        [TestCase(0, -1, 0)]
        [TestCase(0, 0, -1)]
        [TestCase(256, 0, 0)]
        [TestCase(0, 256, 0)]
        [TestCase(0, 0, 256)]
        public void PropertySet_InvalidValue_ThrowsException(int r, int g, int b)
        {
            var pixel = new Pixel();

            if (r < 0 || r > 255)
                Assert.Throws<ArgumentOutOfRangeException>(() => pixel.R = r);
            else
                pixel.R = r;

            if (g < 0 || g > 255)
                Assert.Throws<ArgumentOutOfRangeException>(() => pixel.G = g);
            else
                pixel.G = g;

            if (b < 0 || b > 255)
                Assert.Throws<ArgumentOutOfRangeException>(() => pixel.B = b);
            else
                pixel.B = b;
        }

        [TestCase(0, 0, 0, ExpectedResult = 0)]
        [TestCase(255, 255, 255, ExpectedResult = 255)]
        [TestCase(100, 150, 200, ExpectedResult = 140)]
        public int L_Property_CalculatesCorrectly(int r, int g, int b)
        {
            var pixel = new Pixel(r, g, b);
            return pixel.L;
        }

        [Test]
        public void Equals_SameValues_ReturnsTrue()
        {
            var pixel1 = new Pixel(100, 150, 200);
            var pixel2 = new Pixel(100, 150, 200);

            Assert.IsTrue(pixel1.Equals(pixel2));
            Assert.IsTrue(pixel1.Equals((object)pixel2));
            Assert.IsTrue(pixel1 == pixel2);
        }

        [Test]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            var pixel1 = new Pixel(100, 150, 200);
            var pixel2 = new Pixel(101, 150, 200);

            Assert.IsFalse(pixel1.Equals(pixel2));
            Assert.IsFalse(pixel1.Equals((object)pixel2));
            Assert.IsTrue(pixel1 != pixel2);
        }

        [Test]
        public void Equals_NonPixelObject_ReturnsFalse()
        {
            var pixel = new Pixel(100, 150, 200);
            var obj = new object();

            Assert.IsFalse(pixel.Equals(obj));
        }

        [Test]
        public void GetHashCode_SameValues_EqualHashCodes()
        {
            var pixel1 = new Pixel(100, 150, 200);
            var pixel2 = new Pixel(100, 150, 200);

            Assert.AreEqual(pixel1.GetHashCode(), pixel2.GetHashCode());
        }

        [Test]
        public void GetHashCode_DifferentValues_DifferentHashCodes()
        {
            var pixel1 = new Pixel(100, 150, 200);
            var pixel2 = new Pixel(101, 150, 200);

            Assert.AreNotEqual(pixel1.GetHashCode(), pixel2.GetHashCode());
        }

        [TestCase(0, 0, 0, ExpectedResult = "#000000")]
        [TestCase(255, 255, 255, ExpectedResult = "#FFFFFF")]
        [TestCase(223, 8, 155, ExpectedResult = "#DF089B")]
        public string ToString_ReturnsCorrectFormat(int r, int g, int b)
        {
            var pixel = new Pixel(r, g, b);
            return pixel.ToString();
        }

        [TestCase(1.0, 100, 150, 200, 100, 150, 200)]
        [TestCase(0.5, 100, 150, 200, 50, 75, 100)]
        [TestCase(2.0, 100, 150, 200, 200, 255, 255)]
        [TestCase(1.5, 200, 100, 50, 255, 150, 75)]
        public void MultiplicationOperator_ReturnsCorrectPixel(
            double factor,
            int r, int g, int b,
            int expectedR, int expectedG, int expectedB)
        {
            var pixel = new Pixel(r, g, b);
            var result = factor * pixel;

            Assert.AreEqual(expectedR, result.R);
            Assert.AreEqual(expectedG, result.G);
            Assert.AreEqual(expectedB, result.B);
        }

        [Test]
        public void MultiplicationOperator_NegativeFactor_ThrowsException()
        {
            var pixel = new Pixel(100, 150, 200);
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = -1.0 * pixel);
        }
    }
}