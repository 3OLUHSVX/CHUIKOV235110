using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters
{
    public class GasHeatingApartment : Apartment
    {
        public double GasMeterReading { get; set; }

        public GasHeatingApartment(int number, ElectricMeterType meterType)
            : base(number, meterType) { }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];
            baseInfo.CopyTo(newInfo, 0);
            newInfo[newInfo.Length - 1] = $"Тип: Газовое отопление, Показания газа: {GasMeterReading.ToString("0.0##", CultureInfo.InvariantCulture)}";
            return newInfo;
        }
    }
}