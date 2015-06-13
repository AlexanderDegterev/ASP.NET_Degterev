using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public interface ICallItem
    {
        DateTime DateOfCall { get; set; }
        IClient Client { get; set; }
        TimeSpan CallDuration { get; set; }
        double CostOfCall { get; set; }
    }
}
