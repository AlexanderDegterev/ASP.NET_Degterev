using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckPoint_Symbol
{
    class Program
        /*Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.

        Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
        Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины.
        Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.*/

    {


        /*static void PR1(string filename, out int c)
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
            //Console.WriteLine();
            //Console.WriteLine();
            Console.WriteLine("\nСимволов в тексте: {0}", p);

        }*/

        static void Main()
        {
            Reader reader = new Reader();
            //reader.Readertext();
            //Console.WriteLine(reader.Readertext());
            char[] charArray = reader.Readertext().ToCharArray();
            int i;
            for (i = 0; i < charArray.Length; i++)
            {
                Console.WriteLine(charArray[i]);//print symbols
                // ADD TO CLASS SYMBOL
            }
            //string str = new string(reader.Readertext());
            Console.WriteLine("Print text:\n " + reader.Readertext());
            string str = reader.Readertext();
            char raz = ' ';
            char[] raz2 = { '.', '?', ';', ':', '!' };
            string[] msWord = str.Split(raz2); //Split разбивает строку на массив строк, разбив строку ....
            string[] msOffer = str.Split(raz);
            Console.WriteLine("\nOffers in the text  : " + msWord.Length);
            Console.WriteLine("Word in text : " + msOffer.Length);
        }
        

            //try
            //{
            //    Encoding enc = Encoding.GetEncoding(1251);  //CP1251
            //    StreamReader reader = new StreamReader("text2.txt", enc);
            //    //string content = reader.Readline();
            //    string content = System.IO.File.ReadAllText(@"text2.txt", enc);
            //    Console.WriteLine("Print text:\n"+content);
            //    char[] charArray = content.ToCharArray();
            //    int i;
            //    for (i = 0; i < content.Length; i++)
            //    {
            //        //Console.WriteLine(charArray[i]);  //print symbols
            //        // ADD TO CLASS SYMBOL
            //    }
            //    string str = new string(charArray);
            //    char raz = ' ';
            //    char[] raz2 = { '.', '?', ';', ':', '!' };
            //    string[] msWord = str.Split(raz2); //Split разбивает строку на массив строк, разбив строку ....
            //    string[] msOffer = str.Split(raz);
            //    //Console.WriteLine("Offers in the text  : " + msWord.Length);
            //    //Console.WriteLine("Word in text : " + msOffer.Length);

            //}

            //catch (FileNotFoundException e)
            //{
            //    Console.WriteLine("ОШИБКА: " + e.Message);
            //}
         



           /* int i;
            while((i = reader.Read()) > 0) {
            char c = (char) i;
            if(c == '\r' || c == '\n') {
                yield return currentLine.ToString();
                currentLine.Length = 0;
                continue;*/

            /*char[] ms = new char[c];
            int i = 0;
            while (!reader.EndOfStream)
            {
                reader.Read(ms, i, 1);
                i++;
            }
            string str = new string(ms);
            char raz = ' ';
            char[] raz2 = { '.', '?', ';', ':', '!' };
            string[] msWord = str.Split(raz2); //Split разбивает строку на массив строк, разбив строку пробелами.
            string[] msOffer = str.Split(raz);

            Console.WriteLine("MY 1: " + line.Length);
            Console.WriteLine("MY 2: " + line);
            Console.WriteLine("MY Count: " + line.Count());
            IEnumerable<string> filteredNames = System.Linq.Enumerable.Where(reader, n => n.Length >= 4);
            foreach (string n in filteredNames)
            {
                Console.WriteLine(n + "|");
            }
        }*/
        
        
        /*static void Co(int c)
        {
            Encoding enc = Encoding.GetEncoding(1251);
            StreamReader reader = new StreamReader("text2.txt", enc);
            string line = reader.ReadLine();
            Console.WriteLine("MY 1: " + line.Length);
            Console.WriteLine("MY 2: " + line);
            Console.WriteLine("MY Count: " + line.Count());

            char[] ms = new char[c];
            int i = 0;
            while (!reader.EndOfStream)
            {
                reader.Read(ms, i, 1);
                i++;
            }
            string str = new string(ms);
            char raz = ' ';
            char[] raz2 = { '.', '?', ';', ':', '!' };
            string[] msWord = str.Split(raz2); //Split разбивает строку на массив строк, разбив строку пробелами.
            string[] msOffer = str.Split(raz);
            Console.WriteLine("Cлов в тексте: {0}", msOffer.Length);
            Console.WriteLine("Предложений в тексте: {0}", msWord.Length);
            Console.WriteLine();   //   Console.Write();
            /*  foreach (string s in mstp)
                  Console.WriteLine("\n|{0}|",s);*/
            /*for (int j = 1; j <= msWord.Length; j++)
            {

                Console.WriteLine("\n{1}|{0}|", msWord[j - 1], j);
            }

            foreach (string p in msWord.Reverse())
                Console.Write("{0}. ", p);
            reader.Close();
        }*/
    }
}
