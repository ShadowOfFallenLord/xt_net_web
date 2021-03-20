using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_00
{
    static class Task_2
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

        private static int Input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter positive integer:");

            while(true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                break;
            }

            return res;
        }

        /// <summary>
        /// Check on prime number
        /// </summary>
        /// <param name="n">Number for check</param>
        /// <returns>If number is prime return true</returns>        
        public static bool Task(int n)
        {
            if(n % 2 == 0)
            {
                return false;
            }

            for(int i = 3, end = (int)Math.Sqrt(n) + 1; i <= end; i += 2)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Test of task 2
        /// </summary>
        public static void TestTask()
        {
            int n = Input();

            Console.Write($"{n} is");
            if(!Task(n))
            {
                Console.Write(" not");
            }
            Console.WriteLine(" prime.");

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
