using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public void GiamToc()
        {
            TocDo -= 5;
        }
        public void TangToc()
        {
            TocDo += 5;
        }
        public override string ToString()
        {
            return base.ToString() + " (Motorcycle)";
        }
    }
}
