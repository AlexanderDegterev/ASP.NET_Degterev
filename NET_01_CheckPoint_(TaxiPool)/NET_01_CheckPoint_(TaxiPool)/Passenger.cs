using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    class Passenger: Cars,IPassenger
    {
        private int capacityPassanger;
        public int CapacityPassanger
        {
            get
            {
                return capacityPassanger;
            }
            set
            {
                capacityPassanger = value;
            }
        }

        public TypePass TypePass { get; set; }
        
    }
}
