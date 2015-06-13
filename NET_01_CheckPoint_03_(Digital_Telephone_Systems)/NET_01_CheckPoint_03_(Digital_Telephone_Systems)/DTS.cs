using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class DTS // implement actions that could happen to dts
    {
        public delegate void DtsEventHandler(string msg);


        private ICollection<IClient> clientsDTS = new List<IClient>();
        private ICollection<Call> callsJournal = new List<Call>();

        public void Add(IClient item)
        {
            clientsDTS.Add(item);
        }

        public ICollection<IClient> GetClients()
        {
            return clientsDTS;
        }


        public void AddClients(ICollection<IClient> newClients) {
            clientsDTS = newClients; //TODO don't replace, need to add list to list
        }

        public void Clear()
        {
            clientsDTS.Clear();
        }



        /*public void performCall(int outN, int inN, EventHandler handler) {
            MakeCall m = new MakeCall(CallsManager.Start);
           String result = m(clientsDTS, outN, inN);
           handler(result);
        }

        public delegate String MakeCall(List<Client> client, int outN, int inN);*/

        public void ActionUnPlug(int Phonenumber, DtsEventHandler handler)
        {
            if (Phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }
            var client = from clients in clientsDTS
                         where clients.ClientTerminal.PhoneNumber == Phonenumber
                         select clients;
            if (client != null && client.Count() > 0)
            {
                Port port = client.ElementAt(0).ClientTerminal.Port;  //bag !
                port.changeState(PortState.DisconnectedPort);  //check result, if call finished - add call to journal
                handler("Port for " + Phonenumber + " was successfully disconnected");

            }
            else
            {
                handler("Client not found");
            }
            
        }

        internal void ActionPlug(int Phonenumber, DtsEventHandler handler)
        {
            if (Phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }

            handler("Plug " + Phonenumber);
        }

        internal void ActionCall(int Phonenumber, DtsEventHandler handler)
        {
            if (Phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }
            var client = from clients in clientsDTS
                         where clients.ClientTerminal.PhoneNumber == Phonenumber
                         select clients;
            Console.WriteLine("We call the subscriber " + Phonenumber);
        }
    }
}
