using System;

namespace EpamTest
{
    class Program
    {
        static void ArraySortFunction(int[] array)
        {
            Array.Sort(array);
        }

        static int[] InitArray(int length)
        {
            Random random = new Random();

            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(100);
            }

            return array;
        }

        static void PrintArray(int[] array)
        {
            foreach (int i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start:");

            const int count = 10;
            int[] array = InitArray(count);

            Console.Write("Start array : ");
            PrintArray(array);

            ArraySortFunction(array);

            Console.Write("Sorted array: ");
            PrintArray(array);

            Console.WriteLine("end.");
            Console.ReadKey();
        }
    }
}
