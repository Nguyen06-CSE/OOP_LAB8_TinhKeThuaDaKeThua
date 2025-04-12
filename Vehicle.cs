using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    public class Vehicle : IVehicle
    {
        public string Ten { get; set; }
        public int TocDo { get; set; }

        public void Chay()
        {

        }
        public void Dung()
        {

        }
        public override string ToString()
        {
            return $"Ten: {Ten}, TocDo: {TocDo}";
        }
    }
}
