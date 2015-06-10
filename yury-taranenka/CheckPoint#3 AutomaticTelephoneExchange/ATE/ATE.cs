using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class ATE
    {
        Queue<Port> freePortPool = new Queue<Port>();
        Queue<Terminal> freeTerminalPool = new Queue<Terminal>();
        Queue<PhoneNumber> freePhoneNumbersPool = new Queue<PhoneNumber>();
        int lastAllocatedPhoneNumber = 197000000;

        
        IDictionary<Port, Terminal> portTerminalDict = new Dictionary<Port, Terminal>();
        ICollection<Port> ports = new List<Port>();
        ICollection<Contract> contracts = new List<Contract>();
        ICollection<PhoneNumber> phoneNumbers = new List<PhoneNumber>();
        IDictionary<Port, PortState> portPortStateDict = new Dictionary<Port, PortState>(); // TODO: implement addint to dictionary + event portstate change

        public ATE()
        {
            for (int i = 0; i < 5; i++)
            {
                AllocateNewPhoneNumber();
                AllocateNewTerminal();
                AllocateNewPort();
            }
        }

        private void AllocateNewPhoneNumber()
        {
            lastAllocatedPhoneNumber++;
            freePhoneNumbersPool.Enqueue(new PhoneNumber(lastAllocatedPhoneNumber));
        }

        
        private void AllocateNewTerminal()
        {
            freeTerminalPool.Enqueue(new Terminal(GivePhoneNumber()));
        }

        private void AllocateNewPort()
        {
            freePortPool.Enqueue(new Port());
        }

        private Port GivePortToClient()
        {
            AllocateNewPort();
            return freePortPool.Dequeue();
        }

        private Terminal GiveTerminalToClient()
        {
            AllocateNewTerminal();
            return freeTerminalPool.Dequeue();
        }

        private PhoneNumber GivePhoneNumber()
        {
            AllocateNewPhoneNumber();
            return freePhoneNumbersPool.Dequeue();
        }

        public void SignContract(Client client, Tariff tariff)
        {
            Port port = GivePortToClient();
            port.PortConnecting += port_PortConnecting;
            Terminal terminal = GiveTerminalToClient();
            terminal.StartCalling += port.OnStartCalling;
            Contract contract = new Contract(client, terminal, tariff);
            client.Contracts.Add(contract);
            contracts.Add(contract);
            ports.Add(port);
            portTerminalDict.Add(port, terminal);
            phoneNumbers.Add(terminal.myPhoneNumber);
            portPortStateDict.Add(port, port.State);

            

        }

        void port_PortConnecting(object sender, CallingEventArgs e)
        {
            Connecting(e);
            
            if ((e.response & CallingState.ConnectionSucceded) !=0 )
            {
                (sender as Port).State &= ~PortState.Free;
                (sender as Port).State |= PortState.Busy;
            } 

            


            

            Console.WriteLine("Looking for terminal, where target number is {0}", e.TargetNumber);
        }

        void Connecting(CallingEventArgs e)
        {
            Terminal terminal = portTerminalDict.Values.Where(t => t.myPhoneNumber.Equals(e.TargetNumber)).SingleOrDefault();
            Port port = null;
            if (terminal != null)
            {
                port = portTerminalDict.First(x => x.Value == terminal).Key;

                if ((portPortStateDict[port] & PortState.Working) != 0 & (portPortStateDict[port] & PortState.Free) != 0 & (portPortStateDict[port] & PortState.Plugged) != 0)
                {
                    e.response = CallingState.ConnectionSucceded;
                    // TODO: terminal event - incoming call
                }
                else
                {
                    switch (portPortStateDict[port])
                    {
                        case PortState.Broken:
                            e.response = CallingState.OuterPortUnavailable;
                            break;
                        case PortState.Busy:
                            e.response = CallingState.OuterPortBusy;
                            break;
                        case PortState.UnPlugged:
                            e.response = CallingState.OuterPortUnavailable;
                            break;
                        default:
                            break;
                    }    
                }
            }
            else
            {
                e.response = CallingState.WrongNumber;
            }
        }
    }
}
