using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public interface IAirline
    {
        String Name {get; set;}
        DateTime ProductionDate {get; set;}
        int Price {get; set; } 
    }
}
