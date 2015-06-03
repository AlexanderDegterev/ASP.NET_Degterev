using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems_
{
    public interface IClients
    {
        string NameClient { get; set; }
        string SurnameClient { get; set; }
        string TerminalClient { get; set; }
    }
}
