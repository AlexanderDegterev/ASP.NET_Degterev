using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    class Helicopter : Flying, IHelicopter
    {
        public TypeHelicopter TypeHelicopter { get; set; }        
    }
}
