using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    class Passenger : Flying, IPassenger
    {        
        public Make Make { get; set; }
    }
}
