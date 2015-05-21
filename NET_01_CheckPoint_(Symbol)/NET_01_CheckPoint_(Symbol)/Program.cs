using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NET_01_CheckPoint__Symbol_
{
    class Program
    {


        static void PR1(string filename, out int c)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader fr = new StreamReader(filename, enc);
            int p = 0;
            int g = 0;
            while (!fr.EndOfStream)
            {
                char s = (char)fr.Read();
                //char s = (char)fr.ReadLine();
                if (s == '\r' || s == '\n' || s == ' ');
                else p++;
                g++;
                Console.Write("{0}", s);
            }
            c = g;
            fr.Close();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Символов в тексте: {0}", p);

        }

        static void Main(string[] args)
        {
            int c = 0;
            PR1("text2.txt",out c);
            Co(c);
            Console.ReadLine();
        }
        
        static void Co(int c)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader fr = new StreamReader("text2.txt", enc);
            char[] ms = new char[c];
            int i = 0;
            while (!fr.EndOfStream)
            {
                fr.Read(ms, i, 1);
                i++;
            }
            string str = new string(ms);
            char raz = ' ';
            char[] raz2 = { '.', '?', ';', ':', '!' };
            string[] mstp = str.Split(raz2);
            string[] msts = str.Split(raz);
            Console.WriteLine("Cлов в тексте: {0}", msts.Length);
            Console.WriteLine("Предложений в тексте: {0}", mstp.Length);
            Console.WriteLine();   //   Console.Write();
            /*  foreach (string s in mstp)
                  Console.WriteLine("\n|{0}|",s);*/
            for (int j = 1; j <= mstp.Length; j++)
            {

                Console.WriteLine("\n{1}|{0}|", mstp[j - 1], j);
            }

            foreach (string p in mstp.Reverse())
                Console.Write("{0}. ", p);
            fr.Close();
        }
    }
}
