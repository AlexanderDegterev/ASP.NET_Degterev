using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    public class Result
    {
        public string Message;
        public TimeSpan CallDuration;

        public Result(string msg)
        {
            this.Message = msg;
        }
       
        public Result(string msg, TimeSpan duration)
        {
            this.Message = msg;
            this.CallDuration = Round(duration);
        }

        public static TimeSpan Round(TimeSpan input)
        {
            if (input < TimeSpan.Zero)
            {
                return -Round(-input);
            }
            int minutes = (int)input.TotalMinutes;
            if (input.Seconds >= 6)
            {
                minutes++;
            }
            return TimeSpan.FromMinutes(minutes);
        }
    }
}
