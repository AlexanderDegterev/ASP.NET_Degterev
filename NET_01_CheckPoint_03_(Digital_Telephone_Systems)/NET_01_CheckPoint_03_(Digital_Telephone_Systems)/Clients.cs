using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_01_CheckPoint_03__Digital_Telephone_Systems
{
    //public event EventHandler BallInPlay;
    //public delegate int BinaryOp (int x, int y);
    public class Clients //: IClients
    {
        public Clients() { clientBalance = 100; }
        public Clients(string clientName, string clientSurname, string clientTerminal, int clientBalance)
        {
            ClientName = clientName;
            ClientSurname = clientSurname;
            ClientTerminal = clientTerminal;
            ClientBalance = clientBalance;
        }
        // 1) Define a delegate type.
        public delegate void CarEngineHandler(string msgForCaller);

        // Client EVENT
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;

        // 2) Define a member variable of this delegate.
        private CarEngineHandler listOfHandlers;

        // 3) Add registration function for the caller.
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            // listOfHandlers = methodToCall;
            // listOfHandlers += methodToCall; // Group vyzov
            if (listOfHandlers == null)
                listOfHandlers = methodToCall;
            else
                Delegate.Combine(listOfHandlers, methodToCall);  // vmesto +=
        }

        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        // Create method accelerate
        public void Accelerate (int deltaBal)
        {
            if (clientIsDead)
            {
                if (listOfHandlers != null)
                    listOfHandlers("Sorry,this client is dead...");
            }
            else
            { 
                ClientBalance -=deltaBal;
                Console.WriteLine("Balance: {0}",ClientBalance);
                if ((ClientBalance <= 0 ) && (listOfHandlers != null))
                {
                    listOfHandlers ("Limin ischerpan !!!");
                }
            }
        }


        //public delegate int BinaryOp(int x, int y);
        public int Add(int x, int y)
        { return x + y; }
        public static int Subtract(int x, int y)
        { return x - y; }
        public static int SquareNumber(int a)
        { return a * a; }


        private string clientName;
        public string ClientName
        {
            get
            {
                return clientName;
            }
            set
            {
                clientName = value;
            }
        }

        private string clientSurname;
        public string ClientSurname
        {
            get
            {
                return clientSurname;
            }
            set
            {
                clientSurname = value;
            }
        }

        private string clientTerminal;
        public string ClientTerminal
        {
            get
            {
                return clientTerminal;
            }
            set
            {
                clientTerminal = value;
            }
        }

        private int clientBalance;
        public int ClientBalance
        {
            get
            {
                return clientBalance;
            }
            set
            {
                clientBalance = value;
            }
        }

        public int ClientTelNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ClientTariff
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime ClientStartTariff
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        private bool clientIsDead;

        
    }
}
