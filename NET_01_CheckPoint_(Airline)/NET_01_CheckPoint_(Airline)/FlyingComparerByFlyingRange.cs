using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckPoint.Airline
{
    class FlyingComparerByFlyingRange : IComparer<IFlying>
    {
        public int Compare(IFlying x, IFlying y)
        {
            if (x != null && y != null)
            {
                if (x.FlyingRange > y.FlyingRange)
                {
                    return 1;
                }
                else
                {
                    return (x.FlyingRange == y.FlyingRange) ? 0 : -1;
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
