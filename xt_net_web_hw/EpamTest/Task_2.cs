using System;

namespace EpamTest
{
    class Program
    {
        static Random random;

        static bool FindFunction(int[] array, int element)
        {
            return Array.FindIndex(array, (x) => (x == element)) != -1;
        }

        static (int[], int) Init(int length)
        {    
            int[] array = new int[length];
            array[0] = random.Next(1, 6);

            for (int i = 1; i < length; i++)
            {
                // Sorted Ascend
                array[i] = array[i - 1] + random.Next(1, 3);
            }

            // max : [1, 5] + (length - 1) * [1 , 2] => 5 + (length - 1) * 2
            int val = random.Next(1, 5 + 2 * (length - 1) + 1);

            return (array, val);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start:");
            random = new Random();

            const int count = 10;

            for(int i = 0; i < count; i++)
            {
                (int[], int) content = Init(count);

                foreach (int t in content.Item1)
                {
                    Console.Write($"{t} ");
                }

                Console.WriteLine("find {0} : {1}", content.Item2,
                    FindFunction(content.Item1, content.Item2));
            }            

            Console.WriteLine("end.");
            Console.ReadKey();
        }
    }
}
