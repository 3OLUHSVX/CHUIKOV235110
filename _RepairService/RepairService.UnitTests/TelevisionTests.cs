using _RepairService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairService.UnitTests
{
    [TestFixture]
    public class TelevisionTests
    {
        [Test]
        public void Television_GetInfo_ReturnsCorrectData()
        {
            var tv = new Television("QLED 4K", "Samsung", "SN-TV-123", 55, "QLED", "Direct LED");

            var info = tv.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3)); 
            StringAssert.Contains("QLED 4K (Samsung)", info[0]);
            StringAssert.Contains("Экран: 55\"", info[2]);
        }
    }
}