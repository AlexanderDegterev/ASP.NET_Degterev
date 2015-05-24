using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CheckPoint_Symbol
{
    public class Reader
    {
        public void ReadertextOriginal(String filename)
        {
            string content = ReadFileToString(filename);
            Console.WriteLine("Print text (Original):\n" + content);
        }

        private static string ReadFileToString(String filename)
        {
            try
            {
                Encoding enc = Encoding.GetEncoding(1251);  //CP1251
                string content = System.IO.File.ReadAllText(filename, enc);
                return content;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Error: " + e.Message);
                return "error";
            }
        }

        private static string RemoveRedundantSymbols(String target)
        {
            target = System.Text.RegularExpressions.Regex.Replace(target, @"\s+", " ");
            // content = content.Replace("  ", " ");
            target = target.Replace("\r\n", " ");
            target = target.Trim();
            //Console.WriteLine("Print text:\n" + content);
            return target;
        }
        public string Readertext(String filename)
        {
            string content = ReadFileToString(filename);
            return RemoveRedundantSymbols(content);
        }

    }
}

