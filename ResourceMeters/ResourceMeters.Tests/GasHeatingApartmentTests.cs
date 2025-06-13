using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters.Tests
{
    [TestFixture]
    public class GasHeatingApartmentTests
    {
        [Test]
        public void GetInfo_IncludesGasMeterInfo()
        {
            var apt = new GasHeatingApartment(202, ElectricMeterType.DoubleRate)
            {
                GasMeterReading = 123.45,
                ElectricityReadings = new double[] { 100, 200 }
            };

            var info = apt.GetInfo();

            Assert.That(info[info.Length - 1], Is.EqualTo("Тип: Газовое отопление, Показания газа: 123.45"));
        }
    }
}