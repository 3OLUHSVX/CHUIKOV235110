using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _RepairService
{
    public class Television : Device
    {        
        public double ScreenDiagonal { get; set; }  
        public string MatrixType { get; set; }      
        public string BacklightType { get; set; }   
        
        public Television(string name, string manufacturer, string serialNumber,
                          double diagonal, string matrix, string backlight)
            : base(name, manufacturer, serialNumber)
        {
            ScreenDiagonal = diagonal;
            MatrixType = matrix;
            BacklightType = backlight;
        }
        
        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();  
            var newInfo = new string[baseInfo.Length + 1]; 
          
            Array.Copy(baseInfo, newInfo, baseInfo.Length);
           
            newInfo[newInfo.Length - 1] =
                $"Экран: {ScreenDiagonal}\", Матрица: {MatrixType}, Подсветка: {BacklightType}";

            return newInfo;
        }
    }
}