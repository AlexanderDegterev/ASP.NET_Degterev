using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace ParsingText
{
    public class Reader
    {
        public string ReadOriginal(String filename)
        {
            return ReadFileToString(filename);
            
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
        public string ReadOptimized(String filename)
        {
            string content = ReadFileToString(filename);
            return RemoveRedundantSymbols(content);
        }

        static string patternEndSentence = @"(\.)|(\?)|(\!)";
        static string patternEndWord = @"\W+";
        static char patternQuestion = '?';

        internal static List<ISentence> ParseString(String text)
        {
            List<ISentence> sentences = new List<ISentence>();
            string[] split = Regex.Split(text, patternEndSentence, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            int splitLenght = split.Length;
            for (int i = 0; i < splitLenght; i++)
            {
                if (split[i].Length == 1)
                {
                    continue; // we got divider
                }
                string sentenceDivider = "";
                if (i + 1 < splitLenght)
                {
                    sentenceDivider = split[i + 1];
                    
                }
                string sentenceAsString = (split[i] + sentenceDivider).Trim();
                bool isCurrentQuestion = patternQuestion.ToString().Equals(sentenceDivider);
                ISentence current = new Sentence(sentenceAsString, isCurrentQuestion);
                current.words = ParseSentence(sentenceAsString);
                sentences.Add(current);
            }
            return sentences;
        }

        private static List<IWord> ParseSentence(String sentence)
        {
            List<IWord> words = new List<IWord>();
            string[] splitWords = Regex.Split(sentence, patternEndWord, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            int splitWor = splitWords.Length;
            for (int x = 0; x < splitWor; x++)
            {
                if (splitWords[x].Length > 0)
                {
                   words.Add(new Word(splitWords[x]));
                }
            }
            return words;
        }

    }
}

