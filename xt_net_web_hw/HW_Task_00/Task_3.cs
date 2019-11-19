using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_00
{
    static class Task_3
    {
        private static bool CheckOnNumber(string input, out int res)
        {
            if (!int.TryParse(input, out res))
            {
                res = 0;
                Console.WriteLine(" Error!");
                Console.WriteLine($" \"{input}\" is not integer.");
                Console.WriteLine(" Repeat input please.");
                return false;
            }
            return true;
        }

        private static bool CheckOnPositive(int num)
        {
            if (num > 0) return true;

            Console.WriteLine(" Error!");
            Console.WriteLine($" {num} is not positive.");
            Console.WriteLine(" Repeat input please.");

            return false;
        }

        private static bool CheckOnOdd(int num)
        {
            if (num % 2 != 0) return true;

            Console.WriteLine(" Error!");
            Console.WriteLine($" {num} is not odd.");
            Console.WriteLine(" Repeat input please.");

            return false;
        }

        private static int Input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter positive odd integer:");

            while(true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                if (!CheckOnPositive(res)) continue;

                if (!CheckOnOdd(res)) continue;

                break;
            }

            return res;
        }

        /// <summary>
        /// Print square of stars
        /// </summary>
        /// <param name="n">Side of a square</param>
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
        
        /// <summary>
        /// Test of task 3
        /// </summary>
        public static void TestTask()
        {
            int n = Input();
            Task(n);

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    } 
}
