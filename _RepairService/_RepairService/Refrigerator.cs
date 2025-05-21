using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RepairService
{
    public class Refrigerator : Device
    {  
        public int ChamberCount { get; set; }       
        public double Height { get; set; }         
        public double Width { get; set; } 
        public double Depth { get; set; }

        public Refrigerator(string name, string manufacturer, string serialNumber,
                            int chambers, double height, double width, double depth)
            : base(name, manufacturer, serialNumber)
        {
            ChamberCount = chambers;
            Height = height;
            Width = width;
            Depth = depth;
        }
     
        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var newInfo = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, newInfo, baseInfo.Length);
            newInfo[newInfo.Length - 1] =
                $"Камеры: {ChamberCount}, Габариты: {Height}см x {Width}см x {Depth}см";

            return newInfo;
        }
    }
}