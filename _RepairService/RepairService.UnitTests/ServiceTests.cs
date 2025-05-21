using _RepairService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairService.UnitTests
{
    [TestFixture]
    public class ServiceTests
    {
        [Test]
        public void Device_CompareTo_SortsCorrectly()
        {
            var device1 = new Device("TV", "Sony", "SN1")
            { TechnicianFullName = "Иванов А.А." };  
            var device2 = new Device("Fridge", "LG", "SN2")
            { TechnicianFullName = "Петров Б.Б." };  
            var device3 = new Device("Microwave", "Samsung", "SN3")
            { TechnicianFullName = "Иванов А.А." };  

            var devices = new List<Device> { device2, device1, device3 };

            devices.Sort();

            Assert.That(devices[0].Name, Is.EqualTo("Microwave")); 
            Assert.That(devices[1].Name, Is.EqualTo("TV"));        
            Assert.That(devices[2].Name, Is.EqualTo("Fridge"));   
        }

        [Test]
        public void Service_AddRemove_Works()
        {
            var service = new Service("TechService", "ул. Мира 5", "+79990001122");
            var device = new Device("TV", "Sony", "SN-123");

            Assert.That(service.Count, Is.EqualTo(0));
            service.AddDevice(device);
            Assert.That(service.Count, Is.EqualTo(1));
            service.RemoveDevice(device);
            Assert.That(service.Count, Is.EqualTo(0));
        }

        [Test]
        public void Service_CanBeIterated()
        {
            var service = new Service("TechService", "ул. Мира 5", "+79990001122");
            service.AddDevice(new Device("TV", "Sony", "SN1"));
            service.AddDevice(new Device("Fridge", "LG", "SN2"));

            int count = 0;
            foreach (var device in service)
            {
                count++;
            }
            Assert.That(count, Is.EqualTo(2));
        }
    }
}