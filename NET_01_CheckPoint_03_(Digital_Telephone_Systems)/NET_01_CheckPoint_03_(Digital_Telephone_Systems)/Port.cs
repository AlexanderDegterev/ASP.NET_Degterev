using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class Port : IPort
    {

        public int Id {get; set;}
        public PortState State {get; set;}
        private DateTime openPortTime;

        public bool IsAvailableForCall()
        {
            return State == PortState.ConnectedPort;
        }
        //TODO return class with actionResult and duration of port was opened
        public string changeState(PortState newState)
        {
            switch (newState)
            {

                case PortState.DisconnectedPort : //unplug
                    String result = "Port disconnected";
                    if (State == PortState.Busy)
                    {
                     //   new DateTime() - openPortTime;

                        result = "Port disconnected. Call finished, duration : ";
                    } 
                    State = PortState.DisconnectedPort;
                    return result;
                    break;
                case PortState.ConnectedPort:  // plugged / hangup
                     result = "Port connected";
                    if (State == PortState.Busy)
                    {
                     //   new DateTime() - openPortTime;
                      
                        result = "Call finished, duration : ";
                    } 
                    State = PortState.ConnectedPort;
                    return result;
                    break;
                case PortState.Busy:  // startCall
                    if (State == PortState.Busy)
                    { 
                        return "Already busy";
                    }
                    if (State == PortState.DisconnectedPort)
                    {
                        return "Port disconnected";
                    }
                    State = PortState.Busy;
                    openPortTime = new DateTime();
                    return "Call started";
                    break;
            }
            return "";
        }

        public Port(int phoneNumber)
        {
            this.Id = phoneNumber;
            this.State = PortState.ConnectedPort;
        }

        public Port()
        {
            Id = 42;
            State = PortState.ConnectedPort;
        }
    }
}
