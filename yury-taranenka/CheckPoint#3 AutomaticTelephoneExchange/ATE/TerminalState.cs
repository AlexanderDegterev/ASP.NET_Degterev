using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    [Flags]
    public enum TerminalState
    {
        Broken = 1,
        Working = 2,
        UnPlugged = 4,
        Plugged = 8,
    }
}
