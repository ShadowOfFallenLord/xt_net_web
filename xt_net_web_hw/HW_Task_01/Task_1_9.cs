using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_9
    {
        private static int[] InitArray(int count, int min, int max)
        {
            Random random = new Random();
            int[] res = new int[count];

            for (int i = 0; i < count; i++)
            {
                res[i] = random.Next(min, max + 1);
            }

            return res;
        }

        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }

        private static int Sum(int[] array)
        {
            int res = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    res += array[i];
                }
            }
            return res;
        }

        public static void Task()
        {
            const int count = 20;
            const int min_element = -100;
            const int max_element = 100;
            int[] array = InitArray(count, min_element, max_element);
            
            Print(array);

            Console.WriteLine($"Sum: {Sum(array)}");

            Console.WriteLine("\n\r Press any key to continue...");
            Console.ReadKey();
        }
    }
}
