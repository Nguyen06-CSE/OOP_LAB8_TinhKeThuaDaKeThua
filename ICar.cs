using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB8_TinhKeThuaVaDaKeThua
{
    public interface ICar
    {
        int SoChoNgoi { get; set; }

        void DongCua();
        void MoCua();
    }
}
