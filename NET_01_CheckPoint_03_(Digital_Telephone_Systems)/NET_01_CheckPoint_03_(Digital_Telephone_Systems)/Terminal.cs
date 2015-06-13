using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Terminal : ITerminal
    {
        public int PhoneNumber { get; set;}
        public Port Port { get; set;}

        private List<int> numbers;
         
        public Terminal() 
        {
            this.PhoneNumber = Program.getRandomValue(420001, 420101);
            Port = new Port();
        }
           
        public Terminal(int phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
            Port = new Port();
        }

       
            //this.Port = new Port();  
        
        // Начинвем звонить, проверяем порт
        //public void Call(int PhoneNumber)
        //{
        //    if ()
        //    {
        //        OnStartCalling(PhoneNumber)58;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Error port");
        //    }
        //}

        //protected virtual void OnStartCalling(int PhoneNumber)
        //{
        //    CallingEventArgs e = new CallingEventArgs(PhoneNumber);
        //    if (StartCalling != null)
        //    {
        //        StartCalling(this, e);
        //    }
        //    Console.WriteLine(e.response);
        //}

        //return event 
    }
}
