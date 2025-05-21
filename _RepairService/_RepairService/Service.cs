using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RepairService
{
    public class Service : IEnumerable<Device>
    {
        public string Name { get; }
        public string Address { get; }
        public string Phone { get; }

        private List<Device> _devices = new List<Device>();

        public Service(string name, string address, string phone)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address;
            Phone = phone;
        }

        public void AddDevice(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            _devices.Add(device);
        }

        public bool RemoveDevice(Device device)
        {
            return _devices.Remove(device);
        }

        public IEnumerator<Device> GetEnumerator()
        {
            return _devices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _devices.Count;

        public void SortDevices()
        {
            _devices.Sort();
        }
    }
}