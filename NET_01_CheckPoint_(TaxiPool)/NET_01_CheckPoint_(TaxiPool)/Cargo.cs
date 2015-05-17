using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__TaxiStation_
{
    class Cargo : Cars, ICargo
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

        private int lenght;
        public int Lenght
        {
            get
            {
                return lenght;
            }
            set
            {
                lenght = value;
            }
        }
    }
}
