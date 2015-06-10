using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE
{
    class Program
    {
        static void Main(string[] args)
        {
            //Terminal t = new Terminal();
            //Console.WriteLine(t.id);
            
            ////t.State &= ~TerminalState.Working;
            ////t.State |= TerminalState.UnPlugged;
            ////t.State |= TerminalState.Plugged;
            
            ////if (t.State.HasFlag(TerminalState.Working))
            ////{
            ////    t.State &= ~TerminalState.Working & ~TerminalState.Broken;
            ////}
            ////Console.WriteLine(t.State & TerminalState.Working | TerminalState.UnPlugged);
            //if (t.State.HasFlag(TerminalState.WorkingPlugged))
            //{
            //    Console.WriteLine("OOOOOOOOOOOOOOOOOK");
            //}
            ////Console.WriteLine(t.State);

            //Console.WriteLine(t.State);
            //t.Plug();
            //Console.WriteLine(t.State);
            //t.UnPlug();
            //Console.WriteLine(t.State);

            //PhoneNumber p1 = new PhoneNumber(123456789);
            //PhoneNumber p2 = new PhoneNumber(123456788);
            //Console.WriteLine(p1);
            //Console.WriteLine(p2);
            //Console.WriteLine(p1.Equals(p2));

            Client client = new Client("Jack Daniels");

            ATE ate = new ATE();

            ate.SignContract(client, new Tariff());
            client.Contracts[0].terminal.Plug();
             Console.WriteLine("Callers number is " + client.Contracts[0].terminal.myPhoneNumber); 

            client.Contracts[0].terminal.Call(new PhoneNumber(197000002));



            Console.ReadKey();
        }
    }
}
