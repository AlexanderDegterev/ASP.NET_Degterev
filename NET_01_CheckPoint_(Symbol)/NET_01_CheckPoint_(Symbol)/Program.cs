using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CheckPoint_Symbol
{
    class Program
        /*Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.

        Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
        Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины.
        Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.*/

    {
        static void Main()
        {
            Reader reader = new Reader();
            //Story story = reader.parse();
            //reader.Readertext();
            char[] charArray = reader.Readertext("text2.txt").ToCharArray();
            Textual textual = new Textual(); 
            for (int i = 0; i < charArray.Length; i++)
            {
                //Console.WriteLine(charArray[i]); //print symbols
                textual.Add(new Symbol()
                {
                    SymbolValue = (charArray[i])
                }
                );
                
            }
            //string str = new string(reader.Readertext());
            reader.ReadertextOriginal("text2.txt");
            Console.WriteLine("Print text(corrected):\n " + reader.Readertext("text2.txt"));
            string str = reader.Readertext("text2.txt");
            char endWord = ' ';
            char[] endSentence = { '.', '?', '!' };  //Sentence MSDN
            //                ("Mr.", "Mrs.", "Miss" или "Ms.")
            string[] wordParsing = str.Split(endWord);
            string[] sentenceParsing = str.Split(endSentence); //Split разбивает строку на массив строк, разбив строку ....
            Console.WriteLine("\nSymbols in text : " + textual.Count());
            Console.WriteLine("\nOffers in the text  : " + sentenceParsing.Length);
            Console.WriteLine("Word in text : " + wordParsing.Length);
            //Encoding enc = Encoding.GetEncoding(1251);  //CP1251
            //string content = System.IO.File.ReadAllText(@"text2.txt", enc);
            
            List<string> list = new List<string>(sentenceParsing); // collection sentence
            list = list.OrderBy(x => x.Length).ToList();
            Console.WriteLine(string.Join("\n ", list));            

            string pattern = @"(\.)|(\?)|(\!)";

            string[] substrings = Regex.Split(str, pattern);  
            foreach (string match in substrings)
            {
                Sentence sentence = new Sentence();
                sentence.add(new Sentence());
                {
                    Sentence = list;
                }
                Console.WriteLine("'{0}'", match);
            }

            /*Sentence sentence = new Sentence();
            int wordsCounter = 0;
            bool isQuestion = false;
            //Word wordParsing = new Word();
            //bool startsWithLetter = false;

            for (int i = 0; i < charArray.Length; i++)
            {
                char c = charArray[i];
                if (c is буква)
                {
                    addToWord;
                }
                else if (c is endOfWord)
                {
                    startsWithLetter = true; //if word length == 0?
                    addWordToSentance;
                    Word word = new Word();
                    bool startsWithLetter = false;
                }
                else if (c is EndOfSentance)
                {
                    startsWithLetter = true;//if sentance length == 0?
                    addWordToSentance;
                    addSentanceTo Story
                    sentance = new Sentance();
                    wordsCounter = 0;
                    wordParsing = new Word();
                    startsWithLetter = false;
                }

                HashSet set = new HashSet();
                foreach (sentance s : sentances) {
                 
                    set.add(s.getWords);
                }
                 HashSet set = new HashSet();
                foreach (sentance s : sentances) {
                    foreach (word w : s.words) {
                        if (w startsWithLetter && w.length == 3) {
                            resultStory = Replace...
                        }
                    }
                   
                }*/
            }
        }
        

    }

