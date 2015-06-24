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
            AddFilesInFolderToDB(); 

            new FileWatcher(_fileHandler); //Add handler, which recieves new filename, starts addToDB method on new thread
            
        }

        private static void AddFilesInFolderToDB()
        {
            Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            DirectoryInfo di = new DirectoryInfo(Constants.Path);
            string countFiles = di.GetFiles().Length.ToString();
            Console.WriteLine("files in folder:{0}", countFiles);

            string[] files = Directory.GetFiles(Constants.Path, "*.csv");
            Parallel.ForEach(files, currentFile =>
            {
                if (File.Exists(currentFile))
                {
                    Add2Db(currentFile);
                }
            }
                );
        }

        private static void NewFileHandler(string fileName)
        {
            Task.Factory.StartNew(() => Add2Db(fileName));
        }


        private static void Add2Db(string tofile)
        {
            Console.WriteLine("Add2Db() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            Reader reader = new Reader();
            reader.ReadFileAndAddToDb(tofile, _eventHandler);
        }

        private static void MessageResult(string msg)
        {
            Console.WriteLine(msg);
        }

        private static Reader.ReaderEventHandler _eventHandler = new Reader.ReaderEventHandler(MessageResult);

        private static FileWatcher.FileWatcherHandler _fileHandler = new FileWatcher.FileWatcherHandler(NewFileHandler);
    }
}
            
    