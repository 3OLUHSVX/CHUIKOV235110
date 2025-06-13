namespace ResourceMeters.Tests
{
    [TestFixture]
    public class ApartmentTests
    {
        [Test]
        public void Constructor_ValidData_InitializesProperties()
        {
            var apt = new Apartment(101, ElectricMeterType.DoubleRate)
            {
                Owner = "Иванов И.И.",
                Phone = "+7(999)123-4567",
                ColdWater = 50.2,
                HotWater = 30.5
            };
            apt.ElectricityReadings[0] = 100;
            apt.ElectricityReadings[1] = 200;

            Assert.AreEqual(101, apt.Number);
            Assert.AreEqual(ElectricMeterType.DoubleRate, apt.MeterType);
            Assert.AreEqual(2, apt.ElectricityReadings.Length);
        }

        [Test]
        public void Constructor_InvalidNumber_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() =>
                new Apartment(-10, ElectricMeterType.SingleRate));
        }

        [Test]
        public void GetInfo_ReturnsCorrectData()
        {
            var apt = new Apartment(25, ElectricMeterType.SingleRate)
            {
                Owner = "Петров П.П.",
                Phone = "+7(495)111-2233",
                ColdWater = 75.0,
                HotWater = 40.3
            };
            apt.ElectricityReadings[0] = 150.7;

            var info = apt.GetInfo();

            Assert.AreEqual(5, info.Length);
            Assert.AreEqual("Квартира #25", info[0]);
            Assert.AreEqual("Собственник: Петров П.П.", info[1]);
            Assert.AreEqual("Электричество (SingleRate): 150.7", info[4]);
        }

        [Test]
        public void Constructor_InitializesElectricityArray()
        {
            var aptSingle = new Apartment(101, ElectricMeterType.SingleRate);
            var aptDouble = new Apartment(102, ElectricMeterType.DoubleRate);

            Assert.That(aptSingle.ElectricityReadings, Is.Not.Null);
            Assert.That(aptSingle.ElectricityReadings.Length, Is.EqualTo(1));

            Assert.That(aptDouble.ElectricityReadings, Is.Not.Null);
            Assert.That(aptDouble.ElectricityReadings.Length, Is.EqualTo(2));
        }

        [Test]
        public void CompareTo_ApartmentWithLowerNumber_ReturnsPositive()
        {
            var apt1 = new Apartment(101, ElectricMeterType.SingleRate);
            var apt2 = new Apartment(50, ElectricMeterType.DoubleRate);

            Assert.That(apt1.CompareTo(apt2), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_ApartmentWithSameNumber_ReturnsZero()
        {
            var apt1 = new Apartment(101, ElectricMeterType.SingleRate);
            var apt2 = new Apartment(101, ElectricMeterType.DoubleRate);

            Assert.That(apt1.CompareTo(apt2), Is.EqualTo(0));
        }

        [Test]
        public void CompareTo_ApartmentWithHigherNumber_ReturnsNegative()
        {
            var apt1 = new Apartment(50, ElectricMeterType.SingleRate);
            var apt2 = new Apartment(101, ElectricMeterType.DoubleRate);

            Assert.That(apt1.CompareTo(apt2), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_WithNull_ReturnsPositive()
        {
            var apt1 = new Apartment(50, ElectricMeterType.SingleRate);
            Assert.That(apt1.CompareTo(null), Is.GreaterThan(0));
        }
    }
}