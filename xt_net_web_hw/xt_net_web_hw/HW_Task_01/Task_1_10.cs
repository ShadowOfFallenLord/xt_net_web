using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_10
    {
        private static int[,] InitArray(int count, int min, int max)
        {
            Random random = new Random();
            int[,] res = new int[count, count];

            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count; y++)
                {
                    res[x, y] = random.Next(min, max + 1);
                }
            }

            return res;
        }

        private static void Print(int[,] array)
        {
            int count = array.GetLength(0);
            for (int y = 0; y < count; y++)
            {
                for (int x = 0; x < count; x++)
                {
                    Console.Write($"{array[x, y]} ");
                }
                Console.WriteLine();
            }            
        }

        private static int Sum(int[,] array)
        {
            int res = 0;
            int count = array.GetLength(0);
            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count; y++)
                {
                    if((x + y) % 2 == 0)
                    {                        
                        res += array[x, y];
                    }
                }
            }
            return res;
        }

        public static void Task()
        {
            const int count = 5;
            const int min_element = 0;
            const int max_element = 100;
            int[,] array = InitArray(count, min_element, max_element);

            Print(array);

            Console.WriteLine($"Sum: {Sum(array)}");

            Console.WriteLine("\n\r Press any key to continue...");
            Console.ReadKey();
        }
    }
}
