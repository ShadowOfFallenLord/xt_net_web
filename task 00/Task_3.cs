using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xt_net_web_hw
{
    static class Task_3
    {
        private static int input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter positive odd integer:");

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

                if (res % 2 == 0)
                {
                    Console.WriteLine(" Error!");
                    Console.WriteLine($" {res} is not odd.");
                    Console.WriteLine(" Repeat input please.");
                    continue;
                }

                break;
            }

            return res;
        }

        // Print square of stars
        public static void Task(int n)
        {
            if(n < 1 || n % 2 == 0)
            {
                throw new ArgumentException();
            }

            int skip_index = n / 2;

            for(int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (x == y && y == skip_index)
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write('*');
                    }
                }
                Console.WriteLine();
            }
        }

        public static void TestTask()
        {
            int n = input();
            Task(n);

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    } 
}
