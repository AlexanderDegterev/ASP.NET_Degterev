using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class Terminal
    {
        public readonly Guid id;
        public readonly PhoneNumber myPhoneNumber;

        public Terminal() 
        {
            id = Guid.NewGuid();
        }

        public Terminal(PhoneNumber myNumber) : this()
        {
            myPhoneNumber = myNumber;
        }
        
        private TerminalState state = TerminalState.Working | TerminalState.UnPlugged;

        public TerminalState State
        {
            get { return state; }
            set { state = value; }
        }

        # region StartCalling event, Call method & event envocation method

        public event EventHandler<CallingEventArgs> StartCalling;
        public void Call(PhoneNumber targetNumber)
        {
            if ((State & TerminalState.Working) != 0 & (State & TerminalState.Plugged) != 0)
            {
                OnStartCalling(targetNumber);
            }
            else
            {
                Console.WriteLine("Check your terminal");
            }
        }

        protected virtual void OnStartCalling(PhoneNumber targetNumber)
        {
            CallingEventArgs e = new CallingEventArgs(targetNumber);
            if (StartCalling != null)
            {
                StartCalling(this, e);
            }
            Console.WriteLine(e.response);
        }

        #endregion


        public void Plug()
        {
            if ((State & TerminalState.UnPlugged) != 0)
            {
                State &= ~TerminalState.UnPlugged;
                State |= TerminalState.Plugged;
            }
        }

        public void UnPlug()
        {
            if ((State & TerminalState.Plugged) != 0)
            {
                State &= ~TerminalState.Plugged;
                State |= TerminalState.UnPlugged;
            }
        }



    }
}
