using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface IClients
    {
        string ClientName { get; set; }
        string ClientSurname { get; set; }
        string ClientTerminal { get; set; }
        int ClientBalance { get; set; }
        int ClientTelNumber { get; set; }
        string ClientTariff { get; set; }
        DateTime ClientStartTariff { get; set; }
    }
}
