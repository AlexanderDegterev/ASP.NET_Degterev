using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class Port
    {
        public readonly Guid id;

        private PortState state = PortState.Plugged | PortState.Free | PortState.Working;


        public PortState State
        {
            get { return state; }
            set { state = value; }
        }

        public Port()
        {
            id = Guid.NewGuid();
        }

        public event EventHandler<CallingEventArgs> PortConnecting;

        protected virtual void OnPortConnecting(CallingEventArgs e)
        {
            if (PortConnecting != null)
            {
                PortConnecting(this, e);
            }
        }

        public void OnStartCalling(object sender, CallingEventArgs e)
        {
            if ((State & PortState.Working) != 0 & (State & PortState.Free) != 0 & (State & PortState.Plugged) != 0)
            {
                OnPortConnecting(e);
                
            }
            else
            {
                if ((State & PortState.Broken) !=0)
                {
                    e.response = CallingState.YourPortBroken;
                }
                else if ((State & PortState.Busy) !=0)
	            {
                    e.response = CallingState.YourPortBusy;
	            }
                else if ((State & PortState.UnPlugged) !=0)
	            {
                    e.response = CallingState.YourPortUnPlugged;
	            }
                
                
                
                Console.WriteLine("Check your port");
            }
        }

        
    }
}
