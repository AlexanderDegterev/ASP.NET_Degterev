using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class DTS // implement actions that could happen to dts
    {
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
    }
}
