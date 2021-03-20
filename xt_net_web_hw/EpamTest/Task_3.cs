using System;
using System.Text;
using System.Collections.Generic;

namespace EpamTest
{
    class Program
    {
        static Random random;

        static char GenerateChar()
        {
            int a_char = (int)('a');
            int z_char = (int)('z');
            return (char)random.Next(a_char, z_char + 1);
        }

        static string GenerateWord()
        {
            int length = random.Next(1, 6);

            StringBuilder builder = new StringBuilder();

            for(int i = 0; i < length; i++)
            {
                char c = GenerateChar();
                builder.Append(c);
            }

            return builder.ToString();
        }

        static string GenerateString(int word_count)
        {
            List<string> words = new List<string>();
            StringBuilder builder = new StringBuilder();
            const int offset = 2;

            for(int i = 0; i < word_count; i++)
            {
                int roll = random.Next(words.Count + offset);

                if(roll >= words.Count)
                {
                    string t = GenerateWord();
                    words.Add(t);
                    builder.Append(t);
                }
                else
                {
                    builder.Append(words[roll]);
                }
                builder.Append(' ');
            }

            return builder.ToString();
        }

        static string[] FindSingleWords(string input)
        {
            string[] words = input.Trim().Split(' ');

            Dictionary<string, int> words_count = new Dictionary<string, int>();

            foreach(string i in words)
            {
                if(words_count.ContainsKey(i))
                {
                    words_count[i]++;
                }
                else
                {
                    words_count.Add(i, 1);
                }
            }

            List<string> res = new List<string>();

            foreach(string i in words_count.Keys)
            {
                if(words_count[i] == 1)
                {
                    res.Add(i);
                }
            }

            return res.ToArray();
        }

        static void BlackMagic(int word_count)
        {
            Console.WriteLine("--- --- ---");

            string line = GenerateString(word_count);

            Console.WriteLine($"\"{line}\":");

            string[] single_words = FindSingleWords(line);

            foreach(string i in single_words)
            {
                Console.WriteLine($"- {i}");
            }

            Console.WriteLine("--- --- ---");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start:");
            random = new Random();

            for(int i = 0; i < 10; i++)
            {
                BlackMagic(10);
            }

            Console.WriteLine("end.");
            Console.ReadKey();
        }
    }
}
