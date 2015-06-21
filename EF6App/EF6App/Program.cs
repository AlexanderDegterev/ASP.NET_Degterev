using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace EF6App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string path = @"C:\Temp";
            // We will define the necessary maximum quantity of flows
            // Let will be on 4 on each processor
            int MaxThreadsCount = Environment.ProcessorCount * 4;
            // We will set the maximum quantity of worker threads
            ThreadPool.SetMaxThreads(MaxThreadsCount, MaxThreadsCount);
            // We will set the minimum quantity of worker threads
            ThreadPool.SetMinThreads(2, 2);

            Console.WriteLine("Main() invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);
            DirectoryInfo di = new DirectoryInfo(path);
            string countFiles = di.GetFiles().Length.ToString();
            Console.WriteLine("files in folder:{0}", countFiles);
            
            string[] files = Directory.GetFiles(path, "*.csv");
            foreach (string file in files)
            {
                Console.WriteLine(file);
                new Thread(() => Add2Db(file)).Start();
            }
            //for (int i = 0; i < 3; i++)
            //    (new Thread(new ThreadStart(AddToDb()))).Start();
            FileWatcher watcher = new FileWatcher();
            watcher.Run();
        }

        public void AddToDb(string tofile)
        {
            Console.WriteLine("AddToDb() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            //const string toFile = "1.csv";
            Reader reader = new Reader();
            reader.ReadFileAndAddToDb(tofile, _eventHandler);
        }

        private static void Add2Db(string tofile)
        {
            Console.WriteLine("Add2Db() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            //const string toFile = "1.csv";
            Reader reader = new Reader();
            reader.ReadFileAndAddToDb(tofile, _eventHandler);
        }

        private static void MessageResult(string msg)
        {
            Console.WriteLine(msg);
        }

        private static Reader.ReaderEventHandler _eventHandler = new Reader.ReaderEventHandler(MessageResult);
        //private static void PrintInfoToConsole(ICollection<IFlying> flyings)
        //{
        //    foreach (var item in flyings)
        //    {
        //        Console.WriteLine(item.GetInfo());
        //    }
        //}
    }
}
            
    