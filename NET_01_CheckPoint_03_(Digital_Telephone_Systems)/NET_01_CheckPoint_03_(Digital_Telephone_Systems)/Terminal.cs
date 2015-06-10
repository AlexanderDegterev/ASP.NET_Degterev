using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Terminal : ITerminal
    {
        public int PhoneNumber{get; set;}
        public IPort Port{get; set;}

        private List<int> numbers;

        
         
        public Terminal() 
        {
            //Generate availadle numbers
            if (numbers == null)
            {
                numbers = new List<int>();
                for (int i = 420001; i < 420101; i++ )
                {
                    numbers.Add(i);
                }
            }
            // get next available number\
            Random rnd = new Random();
            this.PhoneNumber = rnd.Next(420001, 420101);
            //this.PhoneNumber = -1;
            /*if ((numbers != null) && (numbers.Count > 0))
            {
                foreach (var c in numbers) //TODO get first element correctly
                {
                    this.PhoneNumber = c;
                    break;
                }
                //numbers.Remove(this.PhoneNumber);
            }*/

       
            this.Port = new Port();  
        }
        // Начинвем звонить, проверяем порт
        public void Call(int PhoneNumber)
        {
            if (Port.State = ConnectedPort )
            {
                OnStartCalling(PhoneNumber);
            }
            else
            {
                Console.WriteLine("Error port");
            }
        }

        protected virtual void OnStartCalling(int PhoneNumber)
        {
            CallingEventArgs e = new CallingEventArgs(PhoneNumber);
            if (StartCalling != null)
            {
                StartCalling(this, e);
            }
            Console.WriteLine(e.response);
        }

        //return event 
    }
}
