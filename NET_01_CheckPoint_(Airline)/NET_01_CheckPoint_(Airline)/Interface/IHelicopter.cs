using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Airline
{
    public interface IHelicopter : IFlying
    {
        TypeHelicopter TypeHelicopter { get; set; }
    }
}
