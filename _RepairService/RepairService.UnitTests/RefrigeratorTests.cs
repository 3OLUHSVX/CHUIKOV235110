using _RepairService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairService.UnitTests
{
    [TestFixture]
    public class RefrigeratorTests
    {
        [Test]
        public void Refrigerator_GetInfo_ReturnsCorrectData()
        {            
            var fridge = new Refrigerator("FrostFree", "LG", "SN-FR-456", 2, 180, 70, 75);
            
            var info = fridge.GetInfo();
            
            Assert.That(info.Length, Is.EqualTo(3));
            StringAssert.Contains("FrostFree (LG)", info[0]);
            StringAssert.Contains("Габариты: 180см x 70см x 75см", info[2]);
        }
    }
}