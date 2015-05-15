using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint__Airline_
{
    public class Fleighter : Plane, IFreighter
    {
        private int loadingcapacity;
        public int LoadingCapacity
        {
            get
            {
                return loadingcapacity;
            }
            set
            {
                if (loadingcapacity>0)
                    loadingcapacity = value;
            }
        }
    }
}
