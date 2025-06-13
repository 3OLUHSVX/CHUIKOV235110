using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters.Tests
{
    [TestFixture]
    public class CentralHeatingApartmentTests
    {
        [Test]
        public void GetInfo_IncludesAreaInfo()
        {
            var apt = new CentralHeatingApartment(101, ElectricMeterType.SingleRate, 75.5)
            {
                Owner = "Сидоров С.С.",
                ColdWater = 100.0,
                ElectricityReadings = new double[] { 150.7 }
            };

            var info = apt.GetInfo();

            Assert.That(info[info.Length - 1], Is.EqualTo("Тип: Центральное отопление, Площадь: 75.5 кв. м"));
        }
    }
}