using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters.Tests
{
    [TestFixture]
    public class BuildingTests
    {
        private List<Apartment> testApartments;
        private Building testBuilding;

        [SetUp]
        public void Setup()
        {
            testApartments = new List<Apartment>
            {
                new Apartment(101, ElectricMeterType.SingleRate),
                new Apartment(202, ElectricMeterType.DoubleRate),
                new Apartment(303, ElectricMeterType.SingleRate)
            };

            testBuilding = new Building("ул. Центральная, 1", testApartments);
        }

        [Test]
        public void Constructor_InitializesAddressAndApartments()
        {
            Assert.That(testBuilding.Address, Is.EqualTo("ул. Центральная, 1"));
            Assert.That(testBuilding.Count(), Is.EqualTo(3));
        }

        [Test]
        public void IEnumerable_CanEnumerateApartments()
        {
            var apartments = testBuilding.ToList();

            Assert.That(apartments.Count, Is.EqualTo(3));
            Assert.That(apartments[0].Number, Is.EqualTo(101));
            Assert.That(apartments[1].Number, Is.EqualTo(202));
            Assert.That(apartments[2].Number, Is.EqualTo(303));
        }

        [Test]
        public void Building_AsCollection_ContainsAllApartments()
        {
            var apartmentNumbers = new List<int>();
            foreach (var apartment in testBuilding)
            {
                apartmentNumbers.Add(apartment.Number);
            }

            Assert.That(apartmentNumbers, Is.EquivalentTo(new[] { 101, 202, 303 }));
        }

        [Test]
        public void Building_WithDifferentApartmentTypes()
        {
            var apartments = new List<Apartment>
            {
                new CentralHeatingApartment(101, ElectricMeterType.SingleRate, 75.5),
                new GasHeatingApartment(202, ElectricMeterType.DoubleRate)
            };

            var building = new Building("ул. Смешанная, 5", apartments);

            Assert.That(building.Count(), Is.EqualTo(2));
            Assert.That(building.First(), Is.TypeOf<CentralHeatingApartment>());
            Assert.That(building.Last(), Is.TypeOf<GasHeatingApartment>());
        }
    }
}