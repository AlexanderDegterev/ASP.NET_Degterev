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

        public bool StartCall(int Phonenumber)
        {
            throw new NotImplementedException();
        }

        public void FinishCall()
        {
            throw new NotImplementedException();
        }

        public void Plug()
        {
            throw new NotImplementedException();
        }

        public void UnPlug()
        {
            throw new NotImplementedException();
        }

        public Client()
        {
            Random random = new Random();
            int index = random.Next(names.Count);
            var name = names[index];
            names.RemoveAt(index);
            this.ClientName = name;
            //this.ClientName = names[random.Next(names.Count())]; //random max array size
            this.ClientSurname = surnames[random.Next(surnames.Count())]; //random max array size
            this.ClientTariff = Tarif_enum.Optima1; // how to choose randomly
            this.ClientStartTariff = DateTime.Now; // - remove random  1-90 days
            this.ClientTerminal = new Terminal();
        }

        public Client(String name)
        {
            this.ClientName = name;
        }

        List<string> names = new List<string> { "Alex", "Mike", "Leha" };
        String[] surnames = new String[] { "Degterev", "Ivanov", "Petrov" };

        
        public override String ToString() {
            return ClientName + " " + ClientSurname + " " + ClientTariff + " " + ClientTerminal.PhoneNumber + " " + ClientStartTariff; 
        }


    }
}
