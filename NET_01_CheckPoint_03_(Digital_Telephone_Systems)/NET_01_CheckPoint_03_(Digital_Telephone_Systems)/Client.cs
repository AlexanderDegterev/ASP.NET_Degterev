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

        public Tarif_enum ClientTariff {get; set;}

        public DateTime ClientStartTariff {get; set;}

        public Client()
        {

            this.ClientName = names[Program.getRandomValue((names.Count()))];
            this.ClientSurname = surnames[Program.getRandomValue((surnames.Count()))]; 
            Array values = Enum.GetValues(typeof(Tarif_enum));
            this.ClientTariff = (Tarif_enum)values.GetValue(Program.getRandomValue(values.Length));
            this.ClientStartTariff = DateTime.Now.AddDays(-Program.getRandomValue(90)); 
            this.ClientTerminal = new Terminal();
        }

        public Client(string name)
        {
            this.ClientName = name;
        }

        string[] names = new string[] { "Alex", "Mike", "Leha", "Dima" };
        string[] surnames = new string[] { "Degterev", "Ivanov ", "Petrov ", "Sidorov" };

        
        public override string ToString() {
            return ClientName + "\t " + ClientSurname + "\t" + ClientTariff + "\t" + ClientTerminal.PhoneNumber + "\t " + ClientStartTariff; 
        }


    }
}
