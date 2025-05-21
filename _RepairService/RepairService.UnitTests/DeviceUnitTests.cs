using _RepairService;
using RepairServices;

namespace RepairService.UnitTests
{
    [TestFixture]
    public class DeviceTests
    {
        [Test]
        public void Device_Creation_Test()
        {
            var device = new Device("Холодильник", "Samsung", "SN-12345");

            Assert.AreEqual("Холодильник", device.Name);
            Assert.AreEqual("Samsung", device.Manufacturer);
            Assert.AreEqual("SN-12345", device.SerialNumber);
        }

        [Test]
        public void GetInfo_Returns_Correct_Data()
        {

            var device = new Device("Стиральная машина", "LG", "SN-67890")
            {
                RepairType = RepairType.Paid,
                FaultDescription = "Не сливает воду",
                RepairCost = 4500m,
                TechnicianFullName = "Петров А.С."
            };


            var info = device.GetInfo();

            StringAssert.Contains("LG", info[0]);
            StringAssert.Contains("Не сливает воду", info[1]);
        }
    }
}