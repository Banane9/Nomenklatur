using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nomenklatur
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commonWords = File.ReadAllLines(args[0]);

            List<string> texts = new List<string>();
            for (int i = 1; i < args.Length; i++)
            {
                texts.Add(File.ReadAllText(args[i]).Replace(',', ' ').Replace('.', ' ').Replace('!', ' ').Replace('?', ' ').Replace(';', ' '));
            }

            List<string[]> textsWords = new List<string[]>();
            foreach(string text in texts)
            {
                textsWords.Add(text.ToLower().Split(' '));
            }

            Dictionary<string, uint> wordCounts = new Dictionary<string, uint>();
            foreach (string[] textWords in textsWords)
            {
                foreach (string word in textWords)
                {
                    if (!string.IsNullOrWhiteSpace(word))
                    {
                        if (!commonWords.Contains(word))
                        {
                            if (wordCounts.ContainsKey(word))
                            {
                                wordCounts[word]++;
                            }
                            else
                            {
                                wordCounts.Add(word, 1);
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, uint> word in wordCounts)
            {
                Console.WriteLine(word.Key + " (" + word.Value + ")");
            }
            Console.ReadLine();
        }
    }
}
