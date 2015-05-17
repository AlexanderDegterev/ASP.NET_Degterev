using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET_01_CheckPoint__TaxiStation_
{
    class CarsComparerBYFuelUsage : IComparer<ICars>
    {
        public int Compare(ICars x, ICars y)
        {
            if (x != null && y != null)
            {
                if (x.FuelUsage > y.FuelUsage)
                {
                    return 1;
                }
                else
                {
                    return (x.FuelUsage == y.FuelUsage) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
