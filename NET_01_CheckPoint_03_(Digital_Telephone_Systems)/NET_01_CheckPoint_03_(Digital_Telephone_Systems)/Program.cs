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
                case "call":
                    ProcessCall(parsed);
                    break;
                case "hangup":
                    break;
                case "plug":
                    ProcessPlug(parsed);
                    break;
                case "unplug":
                    ProcessUnplug(parsed);
                    break;
                case "exit" :
                    break;
                default: Console.WriteLine("Help is coming");
                    ProcessCommand();
                    break;
                
            }
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
            //generate clients Iclients collection + metod get client by phonenumber
            // ICollectoin<ICalls>
            //

            //readln
            //parse
            //perform action
            //write result to console

        //    Clients client1 = new Clients("Alex", "Degterev", "Lenovo", 250);
        //    Console.WriteLine("Balance:{0}", client1.ClientBalance);
        //    client1.Exploded += client1_Exploded;
        //    //client1.AboutToBlow +=client1_AboutToBlow;
        //    Console.WriteLine("Balance minus");
        //    for (int i = 0; i < 6; i++)
        //        client1.Accelerate(50);
        //}

    //    private static void actionPlug(int phoneNumber)
    //    {
            
    //        IClients client;
    //      //client.Plug();
    //    }

        private static void actionPerformCall(int CallerId, int TargetId)
        {
            //find client by phoneNumber
            //check your port isAvailable
            //find target by phoneNumber
            //check target port
            // if (canCall) {
            //  self: startCall
            //target : port => busy;
            //}
        }

    //     private static void unplug(int CallerId) 
    //     { 
    //         //find client by phoneNumber
                
    // //        Client.unplug();
    //     }
        
    //    private static void actionFinishCall(int CallerId) 
    //    {
    //       //find client by phoneNumber
                
    //       //Client.finish();
    //    }
    
    //    private void client1_AboutToBlow(object sender, CarEventAgrs e)
    //    {
    //        Console.WriteLine("\n Message From About to blow");
    //        Console.WriteLine("=> {0} says:", e.msg);
    //        Console.WriteLine("******************************\n");
    //    }
    //    static void DisplayDelegateInfo(Delegate delObj)
    //        {
    //            foreach (Delegate d in delObj.GetInvocationList())
    //            {
    //            Console.WriteLine("Method Name: {0}", d.Method);
    //            Console.WriteLine("Type Name: {0}", d.Target);
    //            }
    //        }
    //    public static void client1_Exploded(object sender, CarEventAgrs e)
    //    {
    //        if (sender is Clients)
    //        {
    //            Clients clien = (Clients)sender;
    //            Console.WriteLine("\n Message From Client Object");
    //            Console.WriteLine("\n Message {0}, Balamce {1},Name {2}", e.msg, clien.ClientBalance, clien.ClientName);
    //            Console.WriteLine("******************************\n");
    //            clien.ClientBalance = 500;
    //        }
    //    }
    //}

}
}

