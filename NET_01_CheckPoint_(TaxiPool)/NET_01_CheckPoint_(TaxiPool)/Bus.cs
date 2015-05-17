using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    class Bus : Cars,IBus
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

        private TypeBus typeBus;
        public TypeBus TypeBus
        {
            get
            {
                return typeBus;
            }
            set
            {
                typeBus = value;
            }
        }
    }
}
