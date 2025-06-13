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

            Assert.That(info[4], Is.EqualTo("Электричество (SingleRate): 150.7"));
        }
    }
}