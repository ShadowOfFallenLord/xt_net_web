using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_1
    {
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

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!int.TryParse(input, out res)) continue;

                if (!CheckOnPositive(res)) continue;

                break;
            }

            return res;
        }

        public static void Task()
        {
            Console.WriteLine(" Enter positive integer width:");
            int a = Input();
            Console.WriteLine(" Enter positive integer height:");
            int b = Input();
            Console.WriteLine($" Area: {a * b}");

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
