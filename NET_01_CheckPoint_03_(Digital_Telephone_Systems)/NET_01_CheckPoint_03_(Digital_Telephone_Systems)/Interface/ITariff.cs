using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface ITariff
    {
        string NameTariff { get; set; }
        double CostTariff { get; set; }

    }
}
