using System;
using System.Text;

namespace HW_Task_00
{
    static class Task_1
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

            while(true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                if (!CheckOnPositive(res)) continue;

                break;
            }

            return res;
        }

        /// <summary>
        /// Generate string of numbers
        /// </summary>
        /// <param name="n">Stop number</param>
        /// <returns>String of numbers</returns>
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

        /// <summary>
        /// Test of task 1
        /// </summary>
        public static void TestTask()
        {
            int n = Input();
            string res = Task(n);
            Console.WriteLine($" Result: {res}");
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
