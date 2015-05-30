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

        const int countSymbol = 6;

        static void Main()
        {
            Reader reader = new Reader();
            string original = reader.ReadOriginal("text2.txt");
            Console.WriteLine("Print text (Original):\n" + original);

            string textCorrected = reader.ReadOptimized("text2.txt");

            Console.WriteLine("Print text(corrected):\n " + textCorrected);
            Console.WriteLine("\n ");

            List<ISentence> sentence = Reader.ParseString(textCorrected);

            task1(sentence);

            //foreach (ISentence a in sentence)
            // Console.WriteLine(a);

            //2
            // из List sentences получить только вопросительные предложения
            // из них выбрать слова заданной длины
            // HashSet соберет только уникальные
            // вывести сет
            //List<ISentence> sentence = Reader.ParseString(textCorrected);
            //IEnumerable<ISentence> query2 = sentence.OrderBy(x => x.wordsCount);
            task2(sentence);

            task3(textCorrected, sentence);
            

            //3 выбрать все слова на удаление
            // и в исходном тексте их заменить на "";

            //4 
            // взять рандом преложение
            // найти слова на замену
            // заменить исходное предложение
        }

        private static void task1(List<ISentence> sentence)
        {
            //1   add sort(LINQ)
            IEnumerable<ISentence> query = sentence.OrderBy(x => x.wordsCount);
            /*var wordCountSort = from element in sentence
                          orderby element.wordsCount
                          select element;*/
            Console.WriteLine("TASK 1 :Sort by words count: \n");
            //foreach (var value in wordCountSort)
            foreach (var value in query)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("End sort by words count \n");
        }

        private static void task2(List<ISentence> sentence)
        {
            IEnumerable<ISentence> query2 = from element in sentence
                                            where element.isQuestion == true
                                            select element;
            ISet<IWord> words = getUniqueWords(query2, countSymbol);
            Console.WriteLine("TASK 2 :start words from questions (6 symbols): \n");
            foreach (IWord item in words)
            {
                Console.WriteLine(item.wordValue);
            }
            Console.WriteLine("end words from questions (6 symbols): \n");
        }
        //Из текста удалить все слова заданной длины, начинающиеся на согласную букву.
        private static void task3(String original, List<ISentence> sentence)
        {

            Console.WriteLine("TASK 3 :To remove all words of the set length (6) beginning on a consonant from the text.: \n");
            //string vowels = "AEIOUYАаЕеЁЁИиОоУуЫыЭэЮюЯя";
            string none = "";
            //if  сделать проверку на гласную букву 
            String result = replaceTask3(original, sentence, none, countSymbol);
            //Regex r = new Regex(@"\b[аеёиоуыэюя]\S+\b"/*vowels*/, RegexOptions.IgnoreCase);
            //string result2 = r.Replace(result, "");

            Console.WriteLine(result);
        }

        private static void task4(String original, List<ISentence> sentence)
        {
            // взять рандом преложение, сделать с ним список с одним элементом
            Console.WriteLine("TASK 4 :start words from questions: \n");
            String result = replace(original, sentence, "sample", countSymbol);
            Console.WriteLine(result);
        }

        private static String replace(String original, List<ISentence> sentence, String newChars, int length)
        {
            ISet<IWord> words = getUniqueWords(sentence, length);
            foreach (IWord item in words)
            
            {
                original = original.Replace(item.wordValue, newChars);
            }
            return original;
        }

        private static String replaceTask3(String original, List<ISentence> sentence, String newChars, int length)
        {
            //string vowels = "AEIOUYАаЕеЁЁИиОоУуЫыЭэЮюЯя";
            //string vowels = "ауоыиэяюёеАУОЫИЭЯЮЁЕ";
            //string[] stringArray = { "а", "е", "у", "я" };
            char[] vowels = new[] { 'а', 'я', 'о', 'ё', 'ы', 'и', 'э', 'е', 'у', 'ю' };
            //string s = new string(vowels);
            //char vowels = 'е';
            ISet<IWord> words = getUniqueWords(sentence, length);
            foreach (IWord item in words)
            {
                //foreach (char x in vowels)
                for (int i = 0; i < vowels.Length; i++)
                {
                    if (vowels.Contains(item.firstChar))
                    {
                        original = original.Replace(item.wordValue, newChars);
                    }
                }
            }
            return original;
        }
   
        private static ISet<IWord> getUniqueWords(IEnumerable<ISentence> sentences, int length)
        {
            ISet<IWord> words = new HashSet<IWord>();
            foreach (var value in sentences)
            {
                foreach (IWord word in value.words)
                {
                    if (word.lenght == length)
                    {
                        words.Add(word);
                    }
                }
            }
            return words;
        }

    }


    }


