using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    [Flags]
    public enum PortState
    {
        Working = 1,
        Broken = 2,
        Free = 4,
        Busy = 8,
        Plugged = 16,
        UnPlugged = 32
    }
}
