using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class Result
    {
        public string message;
        public TimeSpan callDuration;

        public Result(string msg)
        {
            this.message = msg;
        }
        public Result(string msg, TimeSpan duration)
        {
            this.message = msg;
            this.callDuration = duration;
        }
    }
}
