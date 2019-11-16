using System;
using System.Text;

namespace xt_net_web_hw
{
    static class Task_1
    {
        private static int input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter positive integer:");

            for (; ; )
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out res))
                {
                    Console.WriteLine(" Error!");
                    Console.WriteLine($" \"{input}\" is not integer.");
                    Console.WriteLine(" Repeat input please.");
                    continue;
                }

                if (res <= 0)
                {
                    Console.WriteLine(" Error!");
                    Console.WriteLine($" {res} is not positive.");
                    Console.WriteLine(" Repeat input please.");
                    continue;
                }

                break;
            }

            return res;
        }

        // String generator
        public static string Task(int n)
        {
            if(n <= 0)
            {
                throw new ArgumentException("n is not positive.");
            }

            StringBuilder builder = new StringBuilder(n * 3);

            builder.Append(1);
            for (int i = 2; i <= n; i++)
            {
                builder.AppendFormat($", {i}");
            }

            return builder.ToString();
        }

        public static void TestTask()
        {
            int n = input();
            string res = Task(n);
            Console.WriteLine($" Result: {res}");
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
