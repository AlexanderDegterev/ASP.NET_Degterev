using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public class Cargo : Flying, ICargo
    {

        private int volume;
        public int Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }
    }
}
