using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ParsingText
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
            string original = reader.ReadOriginal("text2.txt");
            Console.WriteLine("Print text (Original):\n" + original);

            string textCorrected = reader.ReadOptimized("text2.txt");

            Console.WriteLine("Print text(corrected):\n " + textCorrected);
            Console.WriteLine("\n ");

            List<ISentence> sentence = Reader.ParseString(textCorrected);
            
            //1   add sort(LINQ)
            var wordCountSort = from element in sentence
                          orderby element.wordsCount
                          select element;
            Console.WriteLine("Sort by words count: \n");
            foreach (var value in wordCountSort)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("End sort by words count \n");

            //foreach (ISentence a in sentence)
               // Console.WriteLine(a);
            }
        //2
        // из List sentences получить только вопросительные предложения
        // из них выбрать слова заданной длины
        // HashSet соберет только уникальные
        // вывести сет

        //3 выбрать все слова на удаление
        // и в исходном тексте их заменить на "";

        //4 
        // взять рандом преложение
        // найти слова на замену
        // заменить исходное предложение
        }


    }


