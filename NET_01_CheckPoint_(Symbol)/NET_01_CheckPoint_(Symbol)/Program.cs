using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ParsingText
{
    class Program
    {/*Во всех задачах с формированием текста заменять табуляции и последовательности пробелов одним пробелом.
      * 

        Вывести все предложения заданного текста в порядке возрастания количества слов в каждом из них.
        Во всех вопросительных предложениях текста найти и напеча¬тать без повторений слова заданной длины.
        Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        В некотором предложении текста слова заданной длины заменить указанной подстрокой, длина которой может не совпадать с длиной слова.*/

        const int CountSymbol = 6;
        const int CountSymbolTask4 = 6;

        static void Main()
        {
            Reader reader = new Reader();
            string textoriginal = reader.ReadOriginal("text2.txt");
            Console.WriteLine("Print text (Original):\n" + textoriginal);
            string textCorrected = reader.ReadOptimized("text2.txt");
            Console.WriteLine("Print text(corrected):\n " + textCorrected);
            Console.WriteLine("\n ");
            List<ISentence> sentence = Reader.ParseString(textCorrected);

            Task1(sentence);

            //2
            // из List sentences получить только вопросительные предложения
            // из них выбрать слова заданной длины
            // HashSet соберет только уникальные
            // вывести сет
            //List<ISentence> sentence = Reader.ParseString(textCorrected);
            //IEnumerable<ISentence> query2 = sentence.OrderBy(x => x.wordsCount);
            Task2(sentence);

            //3 выбрать все слова на удаление
            // и в исходном тексте их заменить на "";
            Task3(textCorrected, sentence);

            //4 
            // взять рандом преложение
            // найти слова на замену
            // заменить исходное предложение
            Task4(sentence, CountSymbolTask4);
        }

        private static void Task1(List<ISentence> sentence)
        {
            //1   add sort(LINQ)
            IEnumerable<ISentence> query = sentence.OrderBy(x => x.WordsCount);
            /*var wordCountSort = from element in sentence
                          orderby element.wordsCount
                          select element;*/
            Console.WriteLine("TASK 1 :Sort by words count: \n");
            foreach (var value in query)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("End sort by words count \n");
        }

        private static void Task2(List<ISentence> sentence)
        {
            IEnumerable<ISentence> query2 = from element in sentence
                                            where element.IsQuestion == true
                                            select element;
            ISet<IWord> words = GetUniqueWords(query2, CountSymbol);
            Console.WriteLine("TASK 2 :start words from questions (6 symbols): \n");
            foreach (IWord item in words)
            {
                Console.WriteLine(item.WordValue);
            }
            Console.WriteLine("end words from questions (6 symbols): \n");
        }
       
        //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        private static void Task3(String original, List<ISentence> sentence)
        {
            Console.WriteLine("TASK 3 :To remove all words of the set length (6) beginning on a consonant from the text.: \n");
            string none = "";
            String result = ReplaceTask3(original, sentence, none, CountSymbol);
            Console.WriteLine(result);
        }

        private static void Task4(List<ISentence> sentence, int length)
        {
            Console.WriteLine("\nTASK 4 :Replace word: \n");
            string randomSentenceString = GetRandomSentence(sentence);
            Console.WriteLine("Random sentence:"+randomSentenceString);
            foreach (string word in randomSentenceString.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries))
                if (word.Length == length)
                {
                    Console.WriteLine("Replace word:"+word);
                    //replase word
                    randomSentenceString = randomSentenceString.Replace(word, "REPLACE");
                }

            Console.WriteLine("Sentence replace:"+randomSentenceString);
                
        }

        private static String GetRandomSentence(List<ISentence> sentence)
        {
            var rand = new Random();
            var randomSentence = sentence[rand.Next(sentence.Count)];
            return randomSentence.SentenceStr;
                 
        }

        private static String Replace(String original, List<ISentence> sentence, String newChars, int length)
        {
            ISet<IWord> words = GetUniqueWords(sentence, length);
            foreach (IWord item in words)
            
            {
                original = original.Replace(item.WordValue, newChars);
            }
            return original;
        }

        private static String ReplaceTask3(String original, List<ISentence> sentence, String newChars, int length)
        {
            char[] vowels = new[] { 'а', 'я', 'о', 'ё', 'ы', 'и', 'э', 'е', 'у', 'ю' };
            ISet<IWord> words = GetUniqueWords(sentence, length);
            foreach (IWord item in words)
            {
                //foreach (char x in vowels)
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (vowels.Contains(item.FirstChar))
                    {
                        original = original.Replace(item.WordValue, newChars);
                    }
                }
            }
            return original;
        }
   
        private static ISet<IWord> GetUniqueWords(IEnumerable<ISentence> sentences, int length)
        {
            ISet<IWord> words = new HashSet<IWord>();
            foreach (var value in sentences)
            {
                foreach (IWord word in value.Words)
                {
                    if (word.Lenght == length)
                    {
                        words.Add(word);
                    }
                }
            }
            return words;
        }

    }


    }


