using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Client : IClient
    {
        public string ClientName { get; set;}

        public string ClientSurname { get; set;}

        public ITerminal ClientTerminal { get; set;}

        public int ClientBalance { get; set;}

        public TarifEnum ClientTariff {get; set;}

        public DateTime ClientStartTariff {get; set;}

        public Client()
        {

            this.ClientName = _names[Program.GetRandomValue((_names.Count()))];
            this.ClientSurname = _surnames[Program.GetRandomValue((_surnames.Count()))]; 
            Array values = Enum.GetValues(typeof(TarifEnum));
            this.ClientTariff = (TarifEnum)values.GetValue(Program.GetRandomValue(values.Length));
            this.ClientStartTariff = DateTime.Now.AddDays(-Program.GetRandomValue(90)); 
            this.ClientTerminal = new Terminal();
        }

        public Client(string name)
        {
            this.ClientName = name;
        }

        private readonly string[] _names = new string[] { "Alex", "Mike", "Leha", "Dima" };
        private readonly string[] _surnames = new string[] { "Degterev", "Ivanov ", "Petrov ", "Sidorov" };

        
        public override string ToString() {
            return ClientName + "\t " + ClientSurname + "\t" + ClientTariff + "\t" + ClientTerminal.PhoneNumber + "\t " + ClientStartTariff; 
        }


    }
}
