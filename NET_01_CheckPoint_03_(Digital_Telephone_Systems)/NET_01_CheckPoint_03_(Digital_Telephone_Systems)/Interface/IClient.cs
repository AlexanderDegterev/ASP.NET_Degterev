using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface IClient 
    {
        string ClientName { get; set; }
        string ClientSurname { get; set; }
        ITerminal ClientTerminal { get; set; }
        int ClientBalance { get; set; }
        Tarif_enum ClientTariff { get; set; }
        DateTime ClientStartTariff { get; set; }

        //change tariff plan (set client tarif returt true for success, false for error

        
    }

    
}
