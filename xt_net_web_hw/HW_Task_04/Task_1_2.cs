using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_04
{
    class Task_1_2
    {
        static void PrintArray<T>(IEnumerable<T> list)
        {
            foreach (T i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void SortArray<T>(T[] array, Func<T, T, bool> is_less)
        {
            int l = array.Length;
            for(int i = 1, j = 0; i < l; i++)
            {
                j = i;
                while(j > 0 && is_less(array[j], array[j - 1]))
                {
                    T t = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = t;
                    j--;
                }
            }
        }

        public static void Task()
        {
            string[] a = new string[] {
                "aaaaa",
                "a",
                "aaaa",
                "aa",
                "aaa", };

            PrintArray(a);

            SortArray(a, (x, y) => (x.Length < y.Length));

            PrintArray(a);
        }
    }
}
