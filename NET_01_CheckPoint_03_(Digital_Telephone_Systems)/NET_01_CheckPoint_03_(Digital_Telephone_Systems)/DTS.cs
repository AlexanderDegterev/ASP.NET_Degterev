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
        private Call callsJournal = new Call();

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
                Port port = client.ElementAt(0).ClientTerminal.Port;  
                Result result = port.changeState(PortState.DisconnectedPort);
                if (result.callDuration.TotalSeconds > 0)
                {
                    ICallItem ringItem = new CallItem(client.ElementAt(0), result.callDuration);
                    callsJournal.Add(ringItem);
                }
                handler(result.message);

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
            // КТО МЫ !
            Console.WriteLine("We call the subscriber " + Phonenumber);
            Console.WriteLine("check of the port caused the subscriber " + Phonenumber);
            if (client != null && client.Count() > 0)
            {
                Port port = client.ElementAt(0).ClientTerminal.Port;  
                port.changeState(PortState.Busy);  //check result, if call finished - add call to journal
                handler("Port for " + Phonenumber + " was changed on " + port.State);
            }
            else
                {
                    handler("Client not found");
                }
        }

        internal void ActionHangUp(int Phonenumber, DtsEventHandler handler)
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
                Console.WriteLine("the subscriber with number " + Phonenumber + " hung up");
                IClient current = client.ElementAt(0);
                Port port = current.ClientTerminal.Port;
                Result result = port.changeState(PortState.ConnectedPort);
                ICallItem ringItem = new CallItem(current, result.callDuration);
                callsJournal.Add(ringItem);
                handler(result.message);
                //handler("Port for " + Phonenumber + " was changed on " + port.State);
            }
            else
            {
                handler("Client not found");
            }
        }

        internal void ActionChangeTarif(int PhoneNumber, string newTarif, DtsEventHandler handler)
        {
            Tarif_enum selected;
            try
            {
                selected = (Tarif_enum)System.Enum.Parse(typeof(Tarif_enum), newTarif);
            }
            catch
            {
                handler("Tarif not found.");
                return;
            }

            var client = from clients in clientsDTS
                         where clients.ClientTerminal.PhoneNumber == PhoneNumber
                         select clients;
            if (client != null && client.Count() > 0)
            {
                IClient clienttarget = client.ElementAt(0);
                if (clienttarget.ClientTariff == selected)
                {
                    handler("You allready have this tarif");
                    return;
                }
                DateTime lastChange = clienttarget.ClientStartTariff;
                if (lastChange.AddMonths(1) < DateTime.Now)
                {
                    clienttarget.ClientStartTariff = DateTime.Now;
                    clienttarget.ClientTariff = selected;
                    handler("Tarif was changed to " + newTarif);
                }
                else
                {
                    handler("You can't change tarif");
                }
            }
            else
            {
                handler("Client not found");
            }
            
        }

        internal Call GetCalls()
        {
            return callsJournal;
        }
    }
}
