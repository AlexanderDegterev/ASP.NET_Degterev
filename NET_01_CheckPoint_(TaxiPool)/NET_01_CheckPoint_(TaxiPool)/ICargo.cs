using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    interface ICargo : ICars
    {
        int Volume { get; set; }
        int Lenght { get; set; }
    }
}
