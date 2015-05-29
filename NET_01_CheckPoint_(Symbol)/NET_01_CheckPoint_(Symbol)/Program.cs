using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace CheckPoint_Symbol
{
    class Program
    {/*Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.

        Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
        Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины.
        Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.*/
        // Patterns for check
        //string static patternAll = @"^[a-zA-Z0-9]|[\+\-\/\@\#\%\^\*\(\)\;\:\'\<\>]$";
        //string patternEndSentence = @"(\.)|(\?)|(\!)";
        //char endWord = ' ';
        //char[] endSentence = { '.', '?', '!' };  //Sentence MSDN
        // End patterns for check

        static void Main()
        {
            Reader reader = new Reader();
            //Story story = reader.parse();
            //reader.Readertext();

            //Textual textual = new Textual(); 
            //for (int i = 0; i < charArray.Length; i++)
            //{
            //    //Console.WriteLine(charArray[i]); //print symbols
            //    textual.Add(new Symbol()
            //    {
            //        SymbolValue = (charArray[i])
            //    }
            //    );

            //}
            //string str = new string(reader.Readertext());
            string original = reader.ReadOriginal("text2.txt");
            Console.WriteLine("Print text (Original):\n" + original);

            string textCorrected = reader.ReadOptimized("text2.txt");

            Console.WriteLine("Print text(corrected):\n " + textCorrected);
            Console.WriteLine("\n ");


            // Patterns for check
            string patternAll = @"[a-zA-Z0-9]|[\+\-\/\@\#\%\^\*\(\)\;\:\'\<\>]$";
            string patternEndSentence = @"(\.)|(\?)|(\!)";
            char patternQuestion = '?';
            char[] endSentence = { '.', '?', '!' };  //Sentence MSDN
            char[] patternEndWord = { ' ', ':', ';' };
            // End patterns for check

            Textual textual = new Textual();
            //Sentence sentence = new Sentence();
            bool isQuestion = false;
            List<Sentence> sentence = new List<Sentence>();
            Lexicon lexicon = new Lexicon();
            bool startsWithLetter = false;

            char[] charArray = textCorrected.ToCharArray();
            string current = textCorrected;
            string[] split = Regex.Split(current, patternEndSentence, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            for (int i = 0; i < split.Length; i++)
            {
                int splitLenght = split.Length;
                //if (split[i] = endSentence.GetValue(i))
                //foreach (Match match in Regex.Matches(split[i + 1], pattern1))
                if (endSentence.Any(x=>split[i+1].Contains(x)))
                //if (split[i + 1].Any(x => x.Contains(endSentence)) | ((i + 3) != splitLenght))
                //if (split[i] = vopros)
                {
                    string stringPlusQuestion = split[i] + split[i+1];
                    string[] wordsInText = stringPlusQuestion.Split(patternEndWord);
                    //Console.WriteLine("Word in text: {0}", wordsInText.Length);
                    sentence.Add(new Sentence(stringPlusQuestion, wordsInText.Length));
                    //Console.WriteLine(" " + stringPlusQuestion);
                    i++;
                    continue;
                }
                else
                {
                    string stringStandart = split[i];
                    string[] wordsInText = stringStandart.Split(patternEndWord);
                    //Console.WriteLine("Word in text: {0}", stringStandart);
                    sentence.Add(new Sentence(stringStandart, wordsInText.Length));
                    //Console.WriteLine(" " + split[i]);
                    continue;
                }
            }
            foreach (Sentence a in sentence)
                Console.WriteLine(a);

        //    private static void PrintInfoToConsole(Sentence sentence)
        //{
        //    foreach (var item in sentence)
        //    {
        //        Console.WriteLine(item.GetInfo());
        //    }
        //}
                /*if (current is endofword ) {
                     sentence.addWord(word);
                     word = new Word();
                 }
                 if (current is endOfSentence) {
                     story.add(Sentence);
                     sentence = new sentence();*/
                //  }


                //for (int i = 0; i < charArray.Length; i++)
                //{
                //    char[i] = 

                /*string[] wordParsing = str.Split(endWord);
                string[] sentenceParsing = str.Split(endSentence); //Split разбивает строку на массив строк, разбив строку ....
                //Console.WriteLine("\nSymbols in text : " + textual.Count());
                Console.WriteLine("\nOffers in the text  : " + sentenceParsing.Length);
                Console.WriteLine("Word in text : " + wordParsing.Length);
                //Encoding enc = Encoding.GetEncoding(1251);  //CP1251
                //string content = System.IO.File.ReadAllText(@"text2.txt", enc);
            
                List<string> list = new List<string>(sentenceParsing); // collection sentence
                //list = list.OrderBy(x => x.Length).ToList();
                //Console.WriteLine(string.Join("\n ", list));            

                string[] substrings = Regex.Split(str, patternEndSentence);  // ТУТ ЛУЧШЕ ПРИДУМАТЬ ВЕЛОСИПЕДИК
                int countSentence = (from t in substrings select t).Count();
                Console.WriteLine("Кол-во предложений :"+ countSentence);

                List<string> list2 = new List<string>(substrings);  //разбили на предложения
                //List<Sentence> sentenseTest = new List<Sentence>();
                Textual sentenseTest = new Textual();//sentenseTest.Add(new Sentence { sentence = "Sam", wordsCounter = 43 });
                foreach (var match in list2)
                {
                    //Textual sentenseTest = new Textual();
                    sentenseTest.Add(new Sentence() 
                    { 
                        sentence = match,
                        isQuestion = false
                    }
                    );
                    foreach (var sente in sentenseTest)
                    {
                        Console.WriteLine("exit:"+sente.sentence,sente.isQuestion);
                    }
                    //Console.WriteLine("'{0}'", match);
                }
                for (int i = 0; i < substrings.Length; i++)
                {
                
                    // add to class word
                    //if substrings[i]   '?'
                    string[] textArray = substrings[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //разбиваем текст на слова (в массив строк)
                    //sentenseTest.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });
                    //sentenseTest.Insert([0] = new Textual{ wordsCounter = 1 };
                    //    .wordsCounter = textArray.Length;
                    //wordsCounter = 
                    Console.WriteLine("words num: " + textArray.Length); //выводим длины массива == количество слов
                }*/

                //foreach (var sente in sentenseTest)
                //{
                //    Console.WriteLine(sente);
                //}




                //Textual textual = new Textual();

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


