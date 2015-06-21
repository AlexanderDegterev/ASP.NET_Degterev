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
            Console.WriteLine("Main() invoked on thread {0}.",Thread.CurrentThread.ManagedThreadId);
            DirectoryInfo di = new DirectoryInfo(path);
            string countFiles = di.GetFiles().Length.ToString();
            Console.WriteLine("files in folder:{0}", countFiles);
            
            string[] files = Directory.GetFiles(path, "*.csv");
            Parallel.ForEach(files, currentFile =>
            {
                //string filename = Path.GetFileName(currentFile);
                if (File.Exists(currentFile))
                { 
                    Add2Db(currentFile);
                }
            }
                );

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
            
    