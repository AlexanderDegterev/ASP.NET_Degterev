using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATE
{
    public struct PhoneNumber 
    {
        int countryCode;
        int areaCode;
        int exchangeCode;
        int lineNumberDigit1;
        int lineNumberDigit2;
        int lineNumberDigit3;
        int lineNumberDigit4;
        int lineNumberDigit5;
        int lineNumberDigit6;

        public PhoneNumber(int number)
        {
            countryCode = number / 100000000;
            areaCode = number % 100000000 / 10000000;
            exchangeCode = number % 10000000 / 1000000;
            lineNumberDigit1 = number % 1000000 / 100000;
            lineNumberDigit2 = number % 100000 / 10000;
            lineNumberDigit3 = number % 10000 / 1000;
            lineNumberDigit4 = number % 1000 / 100;
            lineNumberDigit5 = number % 100 / 10;
            lineNumberDigit6 = number % 10;

        }
       
        public override string ToString()
        {
            return String.Format("+{0}({1}){2}{3}{4}-{5}{6}-{7}{8}", countryCode, areaCode, exchangeCode, 
                lineNumberDigit1, lineNumberDigit2, lineNumberDigit3, lineNumberDigit4, lineNumberDigit5, 
                lineNumberDigit6);
        }

        
    }
}
