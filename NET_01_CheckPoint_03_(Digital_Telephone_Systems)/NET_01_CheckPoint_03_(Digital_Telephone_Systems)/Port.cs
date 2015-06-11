using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Port : IPort
    {
        public int Id {get; set;}
        public PortState State {get; set;}
        
        public bool IsAvailableForCall()
        {
            return State == PortState.ConnectedPort;
        }

        public Port()
        {
            Id = 42;
            State = PortState.ConnectedPort;
        }
    }
}
