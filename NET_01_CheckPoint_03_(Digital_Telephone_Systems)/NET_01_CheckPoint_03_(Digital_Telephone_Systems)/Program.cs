using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    class Program
    {

        private static Dts _dts = new Dts();

        static void Main(string[] args)
        {
            Console.WriteLine("\nInstruction:\n");
            Console.WriteLine("Example call: call 420099; ");
            Console.WriteLine("Example hung up: hungup 420099; ");
            Console.WriteLine("Example change tariff: change 420099 Optima(1-3); ");
            Console.WriteLine("Example report: report; ");
            Console.WriteLine("Talk less than 6 seconds are not charged");
            Console.WriteLine("Exit: Exit; \n");
            

            _dts.AddClients(GenerateClients(4));
            foreach (var item in _dts.GetClients())
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
            Call journal = _dts.GetCalls();
            Console.WriteLine("\n Show all calls");
            foreach (var c in journal)
            {
                Console.WriteLine(c);
            }
            
            var sortedByDate = journal.OrderBy(x => x.DateOfCall);
            Console.WriteLine("\n Sorted by date");
                foreach (var value in sortedByDate)
                {
                    Console.WriteLine(value);
                }
            
            var sortedByCost = journal.OrderBy(x => x.CostOfCall);
            Console.WriteLine("\n Sorted by cost");
            foreach (var value in sortedByCost)
                {
                    Console.WriteLine(value);
                }
            
            var sortedBySubscriber = journal.OrderBy(x => x.Client.ClientSurname);
            Console.WriteLine("\n Sorted by subscriber");
            foreach (var value in sortedBySubscriber)
            {
                Console.WriteLine(value);
            }
            ProcessCommand();
        }

        private static void ProcessChangeTarif(string[] parsed)
        {
            int phoneNumber = GetPhoneNumber(parsed);
            if (phoneNumber < 0)
            {
                Console.WriteLine("Not valid number");
                ProcessCommand();
                return;
            }
            if (parsed.Count() > 2)
            {
                _dts.ActionChangeTarif(phoneNumber, parsed[2], DtsEventHandler);
            }
            else
            {
                Console.WriteLine("Please define new tarif.");
                ProcessCommand();
            }
        }

        private static void ProcessHangUp(string[] parsed)
        {
            _dts.ActionHangUp(GetPhoneNumber(parsed), DtsEventHandler);
        }

        private static void ProcessCall(string[] parsed)
        {
            _dts.ActionCall(GetPhoneNumber(parsed), DtsEventHandler);
        }
        public static void ProcessResult(string msg)
        {
            Console.WriteLine(msg);
            ProcessCommand();
        }

       public static Dts.DtsEventHandler DtsEventHandler =  new Dts.DtsEventHandler(ProcessResult);

        private static void ProcessUnplug(string[] parsed)
        {
            _dts.ActionUnPlug(GetPhoneNumber(parsed), DtsEventHandler);
        }

        private static int GetPhoneNumber(string[] parsed)
        {
            if (parsed.Count() > 1)
            {
                try
                {
                    int phonenumber = Convert.ToInt32(parsed[1]);
                    return phonenumber;
                }
                catch (Exception)
                {
                }
            }
            return -1;
        }
        private static void ProcessPlug(string[] parsed)
        {
           _dts.ActionPlug(GetPhoneNumber(parsed), DtsEventHandler);
        } 

        public static void CallStatus (String message) {
            Console.WriteLine(message);
        }

        public static ICollection<IClient> GenerateClients(int count)
        {
            ICollection<IClient> clients = new List<IClient>();
            for (int i = 0; i < count; i++)
            {
                Client item = new Client();
                    clients.Add(item);
            }
                
            return clients;
        }

        static Random _random = new Random();
        public static int GetRandomValue(int maxValue)
        {
            return _random.Next(maxValue);
        }
        public static int GetRandomValue(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }
}
}

