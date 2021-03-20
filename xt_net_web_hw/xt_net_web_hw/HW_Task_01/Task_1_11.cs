using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_11
    {
        private static int LengthOfWords_v1(string input)
        {
            int res = 0;
            bool is_word = false;
            int cnt = 0;
            int length = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                {
                    if (is_word)
                    {
                        length++;
                    }
                    else
                    {
                        is_word = true;
                        length = 1;
                        cnt++;
                    }
                }
                else
                {
                    if (is_word)
                    {
                        res += length;
                        is_word = false;
                    }
                }
            }

            if (is_word)
            {
                res += length;
            }

            return res / cnt;
        }

        private static int LengthOfWords_v2(string input)
        {
            StringBuilder builder = new StringBuilder(input);

            for (int i = 0; i < builder.Length; i++)
            {
                if (char.IsPunctuation(builder[i]))
                {
                    builder.Replace(builder[i].ToString(), "");
                    i--;
                }
            }

            string[] words = builder
                .ToString().Trim().Split()
                .Where(x => x.Length > 0).ToArray();

            return words.Sum(x => x.Length) / words.Length;
        }

        public static void Task()
        {
            Console.WriteLine(" Enter your string:");
            Console.Write("> ");
            string input = Console.ReadLine();

            Console.WriteLine($"Res v1: {LengthOfWords_v1(input)}");
            Console.WriteLine($"Res v2: {LengthOfWords_v2(input)}");

            Console.WriteLine($"{Environment.NewLine} Press any key to continue...");
            Console.ReadKey();
        }
    }
}
