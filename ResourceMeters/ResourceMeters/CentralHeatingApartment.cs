using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters
{
    public class CentralHeatingApartment : Apartment
    {
        public double Area { get; set; }

        public CentralHeatingApartment(int number, ElectricMeterType meterType, double area)
            : base(number, meterType)
        {
            Area = area;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];
            baseInfo.CopyTo(newInfo, 0);
            newInfo[newInfo.Length - 1] = $"Тип: Центральное отопление, Площадь: {Area.ToString("0.0##", CultureInfo.InvariantCulture)} кв. м";
            return newInfo;
        }
    }
}