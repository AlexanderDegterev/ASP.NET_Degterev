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

            Clients client1 = new Clients("Alex", "Degterev", "Lenovo", 200);
            client1.RegisterWithCarEngine(new Clients.CarEngineHandler(OnCarEngineEvent));
            Console.WriteLine("Balance minus");
            for (int i = 0; i < 6; i++)
                client1.Accelerate(50);
        }

        /*Clients.CarEngineHandler handler2 = new Clients.CarEngineHandler(OnCarEngineEvent);
        Clients.RegisterWithCarEngine(handler2);*/
        // Unregister from the second handler. 
        //client1.UnRegisterWithCarEngine(handler2);

        static void DisplayDelegateInfo(Delegate delObj)
            {
                foreach (Delegate d in delObj.GetInvocationList())
                {
                Console.WriteLine("Method Name: {0}", d.Method);
                Console.WriteLine("Type Name: {0}", d.Target);
                }
            }
        public static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("\n Message From Client Object");
            Console.WriteLine("=> {0}", msg);
            Console.WriteLine("******************************\n");
        }
    }

}
