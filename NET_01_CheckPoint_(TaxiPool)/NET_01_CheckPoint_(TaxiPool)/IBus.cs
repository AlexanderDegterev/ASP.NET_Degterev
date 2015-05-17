using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    public interface IBus : ICars
    {
        int CapacityPassanger { get; set; }
        TypeBus TypeBus { get; set; }
    }
}
