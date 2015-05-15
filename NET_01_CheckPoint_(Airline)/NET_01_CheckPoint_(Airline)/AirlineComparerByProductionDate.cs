using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET_01_CheckPoint__Airline_
{
    class AirlineComparerByProductionDate : IComparer<IAirline>
    {
        public int Compare(IAirline x, IAirline y)
        {
            if (x != null && y != null)
            {
                if (x.ProductionDate > y.ProductionDate)
                {
                    return 1;
                }
                else
                {
                    return (x.ProductionDate == y.ProductionDate) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}