using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMeters
{
    public class Apartment
    {
        public int Number { get; }
        public string Owner { get; set; } = "Не указан";
        public string Phone { get; set; } = "Не указан";
        public double ColdWater { get; set; }
        public double HotWater { get; set; }
        public ElectricMeterType MeterType { get; }
        public double[] ElectricityReadings { get; set; }

        public Apartment(int number, ElectricMeterType meterType)
        {
            if (number <= 0)
                throw new ArgumentException("Номер квартиры должен быть положительным");

            Number = number;
            MeterType = meterType;

            ElectricityReadings = meterType == ElectricMeterType.SingleRate
                ? new double[1]
                : new double[2];
        }

        public virtual string[] GetInfo()
        {
            string Format(double value) => value.ToString("0.0##", CultureInfo.InvariantCulture);

            return new string[]
            {
                $"Квартира #{Number}",
                $"Собственник: {Owner}",
                $"Телефон: {Phone}",
                $"ХВС: {Format(ColdWater)}, ГВС: {Format(HotWater)}",
                $"Электричество ({MeterType}): {string.Join(" / ", ElectricityReadings.Select(Format))}"
            };
        }
    }
}