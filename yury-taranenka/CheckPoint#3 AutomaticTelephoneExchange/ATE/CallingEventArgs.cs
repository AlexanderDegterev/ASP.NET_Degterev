using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public class CallingEventArgs
    {
        private PhoneNumber targetNumber;

        public CallingState response = 0;

        public PhoneNumber TargetNumber
        {
            get { return targetNumber; }
            set { targetNumber = value; }
        }

        public CallingEventArgs(PhoneNumber target)
        {
            TargetNumber = target;
        }
    }
}
