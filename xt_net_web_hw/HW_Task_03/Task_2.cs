using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class Task_2
    {
        private static char[] sepatarors = { '.', ' ' };

        private static string ReadText()
        {
            // some logic, may be reading from file
            Console.WriteLine("Enter your text:");
            Console.Write("> ");
            return Console.ReadLine();
        }

        private static string[] SplitText(string s)
        {
            return s.Split(sepatarors, StringSplitOptions.RemoveEmptyEntries);
        }

        private static Dictionary<string, int> CountWords(string[] words)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();

            string ts = "";
            foreach(string s in words)
            {
                ts = s.ToLower();
                if(res.ContainsKey(ts))
                {
                    res[ts]++;
                }
                else
                {
                    res.Add(ts, 1);
                }
            }

            return res;
        }

        private static void PrintWords(Dictionary<string, int> words)
        {
            foreach(string s in words.Keys)
            {
                Console.WriteLine($"{s} -> {words[s]}");
            }
        }

        public static void Task()
        {
            string text = ReadText();
            string[] words = SplitText(text);
            Dictionary<string, int> words_count = CountWords(words);
            PrintWords(words_count);
        }
    }
}
