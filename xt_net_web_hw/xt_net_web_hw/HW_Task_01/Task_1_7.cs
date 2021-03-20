using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_7
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

        private static int FindMaxElement(int[] array)
        {
            int res = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > res)
                {
                    res = array[i];
                }
            }
            return res;
        }

        private static int FindMinElement(int[] array)
        {
            int res = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < res)
                {
                    res = array[i];
                }
            }
            return res;
        }

        private static void SortArray(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int new_index = i;

                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] < a[new_index])
                    {
                        new_index = j;
                    }
                }

                int t = a[i];
                a[i] = a[new_index];
                a[new_index] = t;
            }
        }

        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }

        public static void Task()
        {
            const int count = 20;
            const int min_element = 0;
            const int max_element = 100;
            int[] array = InitArray(count, min_element, max_element);

            int max = FindMaxElement(array);
            Console.WriteLine($"Max: {max}");
            int min = FindMinElement(array);
            Console.WriteLine($"Min: {min}");

            SortArray(array);
            Print(array);

            Console.WriteLine("\n\r Press any key to continue...");
            Console.ReadKey();
        }
    }
}
