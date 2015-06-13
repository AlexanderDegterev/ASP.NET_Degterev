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

            this.ClientName = names[Program.getRandomValue((names.Count()))];
            this.ClientSurname = surnames[Program.getRandomValue((surnames.Count()))]; 
            Array values = Enum.GetValues(typeof(Tarif_enum));
            Random random = new Random();
            //Tarif_enum randomTarif = (Tarif_enum)values.GetValue(random.Next(values.Length));
            this.ClientTariff = (Tarif_enum)values.GetValue(random.Next(values.Length));
            //this.ClientTariff = Enum.GetValues(typeof()); //GetRandomEnum<Tarif_enum>();// Tarif_enum.Optima1; // how to choose randomly
            this.ClientStartTariff = DateTime.Now; // - remove random  1-90 days
            this.ClientTerminal = new Terminal();
        }

        public Client(String name)
        {
            this.ClientName = name;
        }

        String[] names = new String[] { "Alex", "Mike", "Leha" };
        String[] surnames = new String[] { "Degterev", "Ivanov", "Petrov" };

        
        public override String ToString() {
            return ClientName + " " + ClientSurname + " " + ClientTariff + " " + ClientTerminal.PhoneNumber + " " + ClientStartTariff; 
        }


    }
}
