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

        static class RandomStringArrayTool
        {
            static Random _random = new Random();

            public static string[] RandomizeStrings(string[] arr)
            {
                List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
                // Add all strings from array
                // Add new random int each time
                foreach (string s in arr)
                {
                    list.Add(new KeyValuePair<int, string>(_random.Next(), s));
                }
                // Sort the list by the random number
                var sorted = from item in list
                             orderby item.Key
                             select item;
                // Allocate new string array
                string[] result = new string[arr.Length];
                // Copy values to array
                int index = 0;
                foreach (KeyValuePair<int, string> pair in sorted)
                {
                    result[index] = pair.Value;
                    index++;
                }
                // Return copied array
                return result;
            }
        }

        static int GenerateDigit(Random rng)
        {
            // Предположим, что здесь много логики
            return rng.Next();
        }
        
        public Client()
        {
            string[] shuffle = RandomStringArrayTool.RandomizeStrings(surnames);
            foreach (string s in shuffle)
            {
                this.ClientSurname = s;
            }

            string[] shuffle2 = RandomStringArrayTool.RandomizeStrings(names);
            foreach (string s in shuffle2)
            {
                this.ClientName = s;
            }

            //this.ClientName = names[mIndex];
                //rng.Next(names.Count()); //names[random.Next(names.Count())]; //random max array size
            //this.ClientSurname = surnames[sIndex]; //surnames[rng.Next(surnames.Count())]; //random max array size
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
