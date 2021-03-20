using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_8
    {
        private static int[,,] InitArray(int count, int min, int max)
        {
            Random random = new Random();
            int[,,] res = new int[count, count, count];

            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count; y++)
                {
                    for (int z = 0; z < count; z++)
                    {
                        res[x, y, z] = random.Next(min, max + 1);
                    }
                }
            }

            return res;
        }

        private static void Print(int[,,] array)
        {
            int count = array.GetLength(0);
            for (int x = 0; x < count; x++)
            {
                Console.Write("{");
                for (int y = 0; y < count; y++)
                {
                    Console.Write("{");
                    for (int z = 0; z < count; z++)
                    {
                        Console.Write($"{array[x, y, z]} ");
                    }
                    Console.Write("} ");
                }
                Console.WriteLine("}");
            }
        }

        private static void PositiveToZero(int[,,] array)
        {
            int count = array.GetLength(0);
            for (int x = 0; x < count; x++)
            {
                for (int y = 0; y < count; y++)
                {
                    for (int z = 0; z < count; z++)
                    {
                        if (array[x, y, z] > 0)
                        {
                            array[x, y, z] = 0;
                        }
                    }
                }
            }
        }

        public static void Task()
        {
            const int count = 3;
            const int min_element = -100;
            const int max_element = 100;
            int[,,] array = InitArray(count, min_element, max_element);

            Console.WriteLine("Start array:");
            Print(array);

            PositiveToZero(array);

            Console.WriteLine("Final array:");
            Print(array);

            Console.WriteLine("\n\r Press any key to continue...");
            Console.ReadKey();
        }
    }
}
