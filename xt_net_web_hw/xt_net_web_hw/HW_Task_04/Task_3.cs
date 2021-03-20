using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HW_Task_04
{
    class Task_3
    {
        static event Action OnSortEnding = delegate { };

        static void PrintArray<T>(IEnumerable<T> list)
        {
            foreach (T i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        static void SortArray<T>(T[] array, Func<T, T, bool> is_less, Action end_action)
        {
            int l = array.Length;
            for (int i = 1, j = 0; i < l; i++)
            {
                j = i;
                while (j > 0 && is_less(array[j], array[j - 1]))
                {
                    T t = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = t;
                    j--;
                }
            }
            OnSortEnding += end_action;
            OnSortEnding?.Invoke();
            OnSortEnding -= end_action;
        }

        static void SortEnd<T>(IEnumerable<T> list, int number)
        {
            Console.WriteLine($"Sorting {number} was ended.");
            PrintArray(list);
        }

        static void StartSortThread<T>(T[] array, Func<T, T, bool> is_less, Action end_action)
        {
            Thread thread = new Thread(() => SortArray(array, is_less, end_action));
            thread.Start();
        }

        public static void Task()
        {
            Console.WriteLine("MultiThread Sort?:");
            int[] array = new int[] { 9, 1, 8, 2, 7, 3, 6, 4, 5 };

            StartSortThread(array, (x, y) => x < y, () => SortEnd(array, 1));
            StartSortThread(array, (x, y) => x < y, () => SortEnd(array, 2));
            StartSortThread(array, (x, y) => x < y, () => SortEnd(array, 3));
        }
    }
}
