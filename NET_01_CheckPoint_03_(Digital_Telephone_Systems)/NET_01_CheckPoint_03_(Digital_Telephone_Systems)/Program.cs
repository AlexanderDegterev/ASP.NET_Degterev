using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Program
    {

        private static DTS dts = new DTS();

        static void Main(string[] args)
        {
            Console.WriteLine("\nInstruction:\n");
            Console.WriteLine("Example call: call 420099; ");
            Console.WriteLine("Example hung up: hungup 420099; ");
            Console.WriteLine("Example change tariff: change 420099 Optima(1-3); ");
            Console.WriteLine("Example report: report; ");
            Console.WriteLine("Talk less than 6 seconds are not charged");
            Console.WriteLine("Exit: Exit; \n");
            

            dts.AddClients(generateClients(4));
            foreach (var item in dts.GetClients())
            {
                Console.WriteLine(item.ToString());
            }
            ProcessCommand();
        }

        private static void ProcessCommand()
        {
            Console.WriteLine("\n Enter command");
            String command = Console.ReadLine();
            String[] parsed = command.Trim().Split();
            String action = parsed[0].ToLower();
            switch (action)
            {
                case "call": // call callerId targetId
                    ProcessCall(parsed);
                    break;
                case "hangup": 
                    ProcessHangUp(parsed);
                    break;
                case "plug":
                    ProcessPlug(parsed);
                    break;
                case "unplug":
                    ProcessUnplug(parsed);
                    break;
                case "change":
                    ProcessChangeTarif(parsed);
                    break;
                case "report":
                    ProcessReport(parsed);
                    break;
                case "exit" :
                    break;
                default: Console.WriteLine("Help is coming");
                    ProcessCommand();
                    break;
            }
        }

        private static void ProcessReport(string[] parsed)
        {
            Call journal = dts.GetCalls();
            Console.WriteLine("\n Show all calls");
            foreach (var c in journal)
            {
                Console.WriteLine(c);
            }
            
            var SortedByDate = journal.OrderBy(x => x.DateOfCall);
            Console.WriteLine("\n Sorted by date");
                foreach (var value in SortedByDate)
                {
                    Console.WriteLine(value);
                }
            
            var SortedByCost = journal.OrderBy(x => x.CostOfCall);
            Console.WriteLine("\n Sorted by cost");
            foreach (var value in SortedByCost)
                {
                    Console.WriteLine(value);
                }
            
            var SortedBySubscriber = journal.OrderBy(x => x.Client.ClientSurname);
            Console.WriteLine("\n Sorted by subscriber");
            foreach (var value in SortedBySubscriber)
            {
                Console.WriteLine(value);
            }
            ProcessCommand();
        }

        private static void ProcessChangeTarif(string[] parsed)
        {
            int PhoneNumber = GetPhoneNumber(parsed);
            if (PhoneNumber < 0)
            {
                Console.WriteLine("Not valid number");
                ProcessCommand();
                return;
            }
            if (parsed.Count() > 2)
            {
                dts.ActionChangeTarif(PhoneNumber, parsed[2], dtseventhandler);
            }
            else
            {
                Console.WriteLine("Please define new tarif.");
                ProcessCommand();
            }
        }

        private static void ProcessHangUp(string[] parsed)
        {
            dts.ActionHangUp(GetPhoneNumber(parsed), dtseventhandler);
        }

        private static void ProcessCall(string[] parsed)
        {
            dts.ActionCall(GetPhoneNumber(parsed), dtseventhandler);
        }
        public static void ProcessResult(string msg)
        {
            Console.WriteLine(msg);
            ProcessCommand();
        }

       public static DTS.DtsEventHandler dtseventhandler =  new DTS.DtsEventHandler(ProcessResult);

        private static void ProcessUnplug(string[] parsed)
        {
            dts.ActionUnPlug(GetPhoneNumber(parsed), dtseventhandler);
        }

        private static int GetPhoneNumber(string[] parsed)
        {
            if (parsed.Count() > 1)
            {
                try
                {
                    int Phonenumber = Convert.ToInt32(parsed[1]);
                    return Phonenumber;
                }
                catch (Exception)
                {
                }
            }
            return -1;
        }
        private static void ProcessPlug(string[] parsed)
        {
           dts.ActionPlug(GetPhoneNumber(parsed), dtseventhandler);
        } 

        public static void CallStatus (String message) {
            Console.WriteLine(message);
        }

        public static ICollection<IClient> generateClients(int count)
        {
            ICollection<IClient> clients = new List<IClient>();
            for (int i = 0; i < count; i++)
            {
                Client item = new Client();
                    clients.Add(item);
            }
                
            return clients;
        }

        static Random random = new Random();
        public static int getRandomValue(int maxValue)
        {
            return random.Next(maxValue);
        }
        public static int getRandomValue(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }
}
}

