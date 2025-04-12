using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    public class Car : Vehicle, ICar
    {
        public int SoChoNgoi { get; set; }

        public void DongCua()
        {
            if(SoChoNgoi > 7)
            {
                SoChoNgoi = 7;
            }
        }
        public void MoCua()
        {
            SoChoNgoi = 0;
        }
        public override string ToString()
        {
            return base.ToString() + $", SoChoNgoi: {SoChoNgoi} (Car)";
        }
    }
}
