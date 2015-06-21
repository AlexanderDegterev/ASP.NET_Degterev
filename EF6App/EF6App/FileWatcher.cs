using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EF6App
{
    public class FileWatcher
    {
        public void Run()
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

            fileSystemWatcher.Path = "C:\\Temp";
            fileSystemWatcher.IncludeSubdirectories = false;
            fileSystemWatcher.NotifyFilter =
            NotifyFilters.LastAccess | NotifyFilters.LastWrite
            | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            fileSystemWatcher.Filter = "*.csv";

            //fileSystemWatcher.Changed += new FileSystemEventHandler(OnChanged);
            fileSystemWatcher.Created += new FileSystemEventHandler(OnChanged);
            //fileSystemWatcher.Deleted += new FileSystemEventHandler(OnChanged);
            //fileSystemWatcher.Renamed += new RenamedEventHandler(OnRenamed);

            fileSystemWatcher.EnableRaisingEvents = true;

            Console.WriteLine("Press any key to stop programm");
            Console.ReadKey(true);
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //Console.WriteLine("File or directory " + e.FullPath + " was " + e.ChangeType);
            FileInfo file = new FileInfo(e.FullPath);
            string fileString = file.ToString();
            //Console.WriteLine(file.Name); 
            Program prog = new Program();
            prog.AddToDb(fileString);
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File or directory {0} was renamed to {1}", e.OldName, e.Name);
        }
        
    }
}
