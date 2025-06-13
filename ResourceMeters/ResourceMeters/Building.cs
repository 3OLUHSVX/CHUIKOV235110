using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters
{
    public class Building : IEnumerable<Apartment>
    {
        public string Address { get; }
        private List<Apartment> Apartments { get; }

        public Building(string address, IEnumerable<Apartment> apartments)
        {
            Address = address;
            Apartments = new List<Apartment>(apartments);
        }

        public IEnumerator<Apartment> GetEnumerator() => Apartments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}