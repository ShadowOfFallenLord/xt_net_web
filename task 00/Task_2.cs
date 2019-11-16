using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xt_net_web_hw
{
    static class Task_2
    {
        private static int input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter integer count of tests:");

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

                break;
            }

            return res;
        }

        // Is simple check 
        public static bool Task(int n)
        {
            if(n % 2 == 0)
            {
                return false;
            }

            for(int i = 3, end = (int)Math.Sqrt(n) + 1; i <= end; i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void TestTask()
        {
            int n = input();
            int t;
            Random random = new Random();

            for(int i = 0; i < n; i++)
            {
                t = random.Next(-1000, 1001);
                Console.WriteLine($"{i + 1}) {t} -> {Task(t)}");
            }            

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
