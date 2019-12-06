using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HW_Task_03
{
    class Program
    {
        static void PrintArray<T>(IEnumerable<T> list)
        {
            foreach (T i in list)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        static void CheckTask_3()
        {
            DynamicArray<int> list = new DynamicArray<int>();

            Console.WriteLine("Check add:");
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            PrintArray(list);

            Console.WriteLine("Check add range:");
            list.AddRange(new int[] { 1, 2, 3 });

            PrintArray(list);

            Console.WriteLine("Check remove:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintArray(list);

            Console.WriteLine("Check remove 2:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintArray(list);
        }

        static void CheckTask_4()
        {
            HardDynamicArray<int> list = new HardDynamicArray<int>();

            Console.WriteLine("Check add:");
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            PrintArray(list);

            Console.WriteLine("Check add range:");
            list.AddRange(new int[] { 1, 2, 3 });

            PrintArray(list);

            Console.WriteLine("Check remove:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintArray(list);

            Console.WriteLine("Check remove 2:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintArray(list);

            Console.WriteLine("Capacity:");
            Console.WriteLine($"1) {list.Capacity}");
            PrintArray(list);
            list.Capacity = list.Capacity * 3;
            Console.WriteLine($"2) {list.Capacity}");
            PrintArray(list);
            HardDynamicArray<int> clone = list.Clone() as HardDynamicArray<int>;
            list.Capacity = 3;
            Console.WriteLine($"3) {list.Capacity}");
            PrintArray(list);

            list = clone;
            Console.WriteLine($"Clone 2: cap: {list.Capacity}");
            PrintArray(list);

            Console.WriteLine("new index:");
            for (int i = -1, end = -list.Length; i >= end; i--)
            {
                Console.Write($"{list[i]} ");
            }
            Console.WriteLine();

            Console.WriteLine("array:");
            int[] a = list.ToArray();
            foreach(int i in a)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        static void CheckTask_5()
        {
            CycledDynamicArray<int> list = new CycledDynamicArray<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Thread thread = new Thread(() => PrintArray(list));

            thread.Start();
            Thread.Sleep(100);
            thread.Abort();
        }

        static void Main(string[] args)
        {
            Task_1.Task();
            Task_2.Task();
            CheckTask_3();
            CheckTask_4();
            CheckTask_5();

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
