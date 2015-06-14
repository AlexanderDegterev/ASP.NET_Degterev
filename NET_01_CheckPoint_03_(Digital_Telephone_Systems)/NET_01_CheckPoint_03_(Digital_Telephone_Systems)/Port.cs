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
        public DateTime StartCall { get; set; }


        public bool IsAvailableForCall()
        {
            return State == PortState.ConnectedPort;
        }

        public Result changeState(PortState newState)
        {
            TimeSpan Duration = new TimeSpan();
            switch (newState)
            {

                case PortState.DisconnectedPort : //unplug
                    String result = "Port disconnected";
                    if (State == PortState.Busy)
                    {
                        DateTime FinishCall = DateTime.Now;
                        Duration = FinishCall.TimeOfDay - StartCall.TimeOfDay;
                        result = "Port disconnected. Call finished, duration : " + Duration.ToString(@"dd\.hh\:mm\:ss"); 
                    } 
                    State = PortState.DisconnectedPort;
                    return new Result(result,Duration);
                    //break;
                
                case PortState.ConnectedPort:  // plugged / hangup
                     result = "Port connected";
                    if (State == PortState.Busy)
                    {
                        DateTime FinishCall = DateTime.Now;
                        Duration = FinishCall.TimeOfDay - StartCall.TimeOfDay;
                        //Console.WriteLine(DateTime.Now);
                        //Console.WriteLine("Duration : {0}", Duration.ToString(@"dd\.hh\:mm\:ss"));
                        result = "Call finished, duration:  "+ Duration.ToString(@"dd\.hh\:mm\:ss");
                    } 
                    State = PortState.ConnectedPort;
                    return new Result(result, Duration);
                    //break;
                
                case PortState.Busy:  // startCall
                    if (State == PortState.Busy)
                    { 
                        return new Result("Already busy");
                    }
                    
                    if (State == PortState.DisconnectedPort)
                    {
                        return new Result("Port disconnected");
                    }
                    State = PortState.Busy;
                    StartCall = DateTime.Now;
                    return new Result("Call started");
                    //break;
            }
            return new Result("");
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
