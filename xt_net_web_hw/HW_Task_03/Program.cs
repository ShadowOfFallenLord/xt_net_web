using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class Program
    {
        static void PrintDynamicArray<T>(DynamicArray<T> list)
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

            PrintDynamicArray(list);

            Console.WriteLine("Check add range:");
            list.AddRange(new int[] { 1, 2, 3 });

            PrintDynamicArray(list);

            Console.WriteLine("Check remove:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintDynamicArray(list);

            Console.WriteLine("Check remove 2:");
            for (int i = 0; i < 3; i++)
            {
                list.Remove(i);
            }

            PrintDynamicArray(list);
        }

        static void Main(string[] args)
        {
            //Task_1.Task();
            //Task_2.Task();
            CheckTask_3();

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
