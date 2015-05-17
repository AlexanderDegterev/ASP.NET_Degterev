using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    public interface IPassenger : ICars
    {
        int CapacityPassanger { get; set; }
        TypePass TypePass { get; set; }
         
    }
}
