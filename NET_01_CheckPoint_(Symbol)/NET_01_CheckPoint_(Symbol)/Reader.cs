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
        static char patternQuestion = '?';

        public static List<ISentence> ParseString(String text)
        {
            List<ISentence> sentences = new List<ISentence>();
            string[] split = Regex.Split(text, patternEndSentence, RegexOptions.IgnoreCase | RegexOptions.Compiled);
            int splitLenght = split.Length;
            for (int i = 0; i < splitLenght; i++)
            {
                //if (split[i] = endSentence.GetValue(i))
                //foreach (Match match in Regex.Matches(split[i + 1], pattern1))
                //if (endSentence.Any(x=>split[i+1].Contains(x))) 
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

                bool isCurrentQuestion = sentenceDivider.All(x => x == patternQuestion);
                sentences.Add(new Sentence(sentenceAsString, isCurrentQuestion));



            }
            return sentences;
        }

    }
}

