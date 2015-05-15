using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    class Passenger : Plane, IPassenger
    {
        private int passengerscapacity;
        public int PassengersCapacity
        {
            get
            {
                return passengerscapacity;
            }
            set
            {
                if (passengerscapacity > 0)
                    passengerscapacity = value;
            }
        }        
        
        public Make Make { get; set; }
    }
}
