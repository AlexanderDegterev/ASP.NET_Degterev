using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Vivod Simple delegate Example\n");
            //Create object delegate BinaryOp -> Clients.Add
            Clients m = new Clients();
            BinaryOp b = new BinaryOp(m.Add);
            DisplayDelegateInfo(b);
            Console.WriteLine("10+10 is {0}", b(10, 10));}
            //BinaryOp c = new BinaryOp(Clients.SquareNumber);*/

            Clients client1 = new Clients("Alex", "Degterev", "Lenovo", 250);
            Console.WriteLine("Balance:{0}", client1.ClientBalance);
            client1.Exploded += client1_Exploded;
            //client1.AboutToBlow +=client1_AboutToBlow;
            Console.WriteLine("Balance minus");
            for (int i = 0; i < 6; i++)
                client1.Accelerate(50);
        }

        private static void client1_AboutToBlow(object sender, CarEventAgrs e)
        {
            Console.WriteLine("\n Message From About to blow");
            Console.WriteLine("=> {0} says:", e.msg);
            Console.WriteLine("******************************\n");
            
            
        }
        static void DisplayDelegateInfo(Delegate delObj)
            {
                foreach (Delegate d in delObj.GetInvocationList())
                {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
                }
            }
        public static void client1_Exploded(object sender, CarEventAgrs e)
        {
            if (sender is Clients)
            {
                Clients clien = (Clients)sender;
                Console.WriteLine("\n Message From Client Object");
                Console.WriteLine("\n Message {0}, Balamce {1},Name {2}", e.msg, clien.ClientBalance, clien.ClientName);
                Console.WriteLine("******************************\n");
                clien.ClientBalance = 500;
            }
        }
    }

}
