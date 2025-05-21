using RepairServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RepairService

{
    public class Device
    {
        public string Name { get; }
        public string Manufacturer { get; }

        public readonly string SerialNumber;

        public RepairType RepairType { get; set; }
        public string FaultDescription { get; set; }
        public decimal RepairCost { get; set; }
        public string TechnicianFullName { get; set; }

        public Device(string name, string manufacturer, string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
                throw new ArgumentException("Серийный номер не может быть пустым");

            Name = name;
            Manufacturer = manufacturer;
            SerialNumber = serialNumber;
        }

        public virtual string[] GetInfo()
        {
            return new string[]
            {
                $"{Name} ({Manufacturer}) - {SerialNumber}",
                $"Тип: {RepairType}, Неисправность: {FaultDescription}, Стоимость: {RepairCost:C}, Мастер: {TechnicianFullName}"
            };
        }
    }
}