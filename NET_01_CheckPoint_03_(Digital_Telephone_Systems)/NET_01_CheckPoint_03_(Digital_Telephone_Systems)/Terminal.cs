using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Terminal : ITerminal
    {
        public int PhoneNumber { get; set;}
        public Port Port { get; set;}

        public Terminal() 
        {
            this.PhoneNumber = Program.GetRandomValue(420001, 420101);
            Port = new Port();
        }
           
        public Terminal(int phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            Port = new Port();
        }
    }
}
