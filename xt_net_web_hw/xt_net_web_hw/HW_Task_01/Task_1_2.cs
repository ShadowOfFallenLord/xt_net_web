using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_2
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

        private static int Input()
        {
            string input;
            int res;

            Console.WriteLine(" Enter positive integer:");
            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                if (!CheckOnPositive(res)) continue;

                break;
            }

            return res;
        }

        public static void Task()
        {
            int n = Input();
            
            for(int y = 1; y <= n; y++)
            {
                for(int x = 0; x < y; x++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
