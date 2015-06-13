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
            dts.AddClients(generateClients(4));
            foreach (var item in dts.GetClients())
            {
                Console.WriteLine(item.ToString());
            }

            ProcessCommand();

            // dts.events();
            //   dts.SetCalls();
            // dts.report()
        /*    bool isActive = true;*/
            // while (isActive)
            //{
            //    String command = Console.ReadLine(); //todo split, check first
            //    if (command.Equals("exit")) {
            //        isActive = false;
            //    }
            //    if (command.Equals("generateClients"))
            //    {

            //    }
            //    if (command.Equals("startCall 420312 420903"))
            //    {
            //        dts.makeCall(420312, 420903, new Handler(CallStatus));
                    
            //    }
            //    if (command.Equals("unplug 420903"))
            //    {
            //        dts.unplug(420903);
            //    }
            //}

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
            foreach (var c in journal)
            {
                Console.WriteLine(c);
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
                catch (Exception e)
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

