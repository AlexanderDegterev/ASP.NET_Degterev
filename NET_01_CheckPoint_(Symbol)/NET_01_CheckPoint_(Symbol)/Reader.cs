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
        public string Readertext()
        {
            //try
            //{
                Encoding enc = Encoding.GetEncoding(1251);  //CP1251
                StreamReader reader = new StreamReader("text2.txt", enc);
                //string content = reader.Readline();
                string content = System.IO.File.ReadAllText(@"text2.txt", enc);
                //Console.WriteLine("Print text:\n" + content);
                //char[] charArray = content.ToCharArray();
                return content;
            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine("ОШИБКА: " + e.Message);
            //}
        }
    }
}

