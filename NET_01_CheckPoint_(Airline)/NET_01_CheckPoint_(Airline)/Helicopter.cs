using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    class Helicopter : Flying, IHelicopter
    {
        public TypeHelicopter TypeHelicopter {get; set;}        
    }
}
