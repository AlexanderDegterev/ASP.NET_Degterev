using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public enum CallingState
    {
        WrongNumber = 1,
        YourPortBroken,
        YourPortUnPlugged,
        YourPortBusy,
        OuterPortUnavailable,
        OuterPortBusy,
        ConnectionSucceded
    }
}
