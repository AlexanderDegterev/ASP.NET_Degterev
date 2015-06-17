using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EF6App
{
    class Program
    {
        static void Main(string[] args)
        {
            string toFile = "1.csv";
            Reader reader = new Reader();
            reader.ReadFileAndAddToDb(toFile,EventHandler);

            FileWatcher watcher = new FileWatcher();
            watcher.Run();
        }

        public static void MessageResult(string msg)
        {
            Console.WriteLine(msg);
        }

        public static Reader.ReaderEventHandler EventHandler = new Reader.ReaderEventHandler(MessageResult);
        //private static void PrintInfoToConsole(ICollection<IFlying> flyings)
        //{
        //    foreach (var item in flyings)
        //    {
        //        Console.WriteLine(item.GetInfo());
        //    }
        //}
    }
}
            
    