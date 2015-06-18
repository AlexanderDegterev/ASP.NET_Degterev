using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class Dts
    {
        public delegate void DtsEventHandler(string msg);

        private ICollection<IClient> _clientsDts = new List<IClient>();
        private Call _callsJournal = new Call();

        public void Add(IClient item)
        {
            _clientsDts.Add(item);
        }

        public ICollection<IClient> GetClients()
        {
            return _clientsDts;
        }


        public void AddClients(ICollection<IClient> newClients) {
            _clientsDts = newClients; //TODO don't replace, need to add list to list
        }

        public void Clear()
        {
            _clientsDts.Clear();
        }

        public void ActionUnPlug(int phonenumber, DtsEventHandler handler)
        {
            if (phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }
            var client = from clients in _clientsDts
                         where clients.ClientTerminal.PhoneNumber == phonenumber
                         select clients;
            if (client != null && client.Count() > 0)
            {
                Port port = client.ElementAt(0).ClientTerminal.Port;  
                Result result = port.ChangeState(PortState.DisconnectedPort);
                if (result.CallDuration.TotalSeconds > 0)
                {
                    ICallItem ringItem = new CallItem(client.ElementAt(0), result.CallDuration);
                    _callsJournal.Add(ringItem);
                }
                handler(result.Message);

            }
            else
            {
                handler("Client not found");
            }
            
        }

        internal void ActionPlug(int phonenumber, DtsEventHandler handler)
        {
            if (phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }

            handler("Plug " + phonenumber);
        }

        internal void ActionCall(int phonenumber, DtsEventHandler handler)
        {
            if (phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }
            var client = from clients in _clientsDts
                         where clients.ClientTerminal.PhoneNumber == phonenumber
                         select clients;
            // who are we?
            Console.WriteLine("We call the subscriber " + phonenumber);
            Console.WriteLine("check of the port caused the subscriber " + phonenumber);
            if (client != null && client.Count() > 0)
            {
                Port port = client.ElementAt(0).ClientTerminal.Port;  
                port.ChangeState(PortState.Busy);  
                handler("Port for " + phonenumber + " was changed on " + port.State);
            }
            else
                {
                    handler("Client not found");
                }
        }

        internal void ActionHangUp(int phonenumber, DtsEventHandler handler)
        {
            if (phonenumber < 0)
            {
                handler("Not valid number");
                return;
            }
            var client = from clients in _clientsDts
                         where clients.ClientTerminal.PhoneNumber == phonenumber
                         select clients;
            if (client != null && client.Count() > 0)
            {
                Console.WriteLine("the subscriber with number " + phonenumber + " hung up");
                IClient current = client.ElementAt(0);
                Port port = current.ClientTerminal.Port;
                Result result = port.ChangeState(PortState.ConnectedPort);
                ICallItem ringItem = new CallItem(current, result.CallDuration);
                _callsJournal.Add(ringItem);
                handler(result.Message);
                //handler("Port for " + Phonenumber + " was changed on " + port.State);
            }
            else
            {
                handler("Client not found");
            }
        }

        internal void ActionChangeTarif(int phoneNumber, string newTarif, DtsEventHandler handler)
        {
            TarifEnum selected;
            try
            {
                selected = (TarifEnum)System.Enum.Parse(typeof(TarifEnum), newTarif);
            }
            catch
            {
                handler("Tarif not found.");
                return;
            }

            var client = from clients in _clientsDts
                         where clients.ClientTerminal.PhoneNumber == phoneNumber
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
            return _callsJournal;
        }
    }
}
