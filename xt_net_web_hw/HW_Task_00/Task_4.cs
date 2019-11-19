using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_00
{
    static class Task_4
    {
        private static bool CheckOnNumber(string input, out int res)
        {
            if (!int.TryParse(input, out res))
            {
                res = 0;
                Console.WriteLine(" Error!");
                Console.WriteLine($" \"{input}\" is not integer.");
                Console.WriteLine(" Repeat input please.");
                return false;
            }
            return true;
        }

        private static bool CheckOnPositive(int num)
        {
            if (num > 0) return true;

            Console.WriteLine(" Error!");
            Console.WriteLine($" {num} is not positive.");
            Console.WriteLine(" Repeat input please.");

            return false;
        }

        private static int Input()
        {
            string input;
            int res;
            Console.WriteLine(" Enter positive integer:");

            while(true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                if (!CheckOnPositive(res)) continue;

                break;
            }

            return res;
        }

        private static int[][] InitArray(int n)
        {
            int[][] res = new int[n][];
            Random random = new Random();
            int max = 100 + 1;


            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Enter length of {i} array:");
                res[i] = new int[Input()];

                for (int j = 0; j < res[i].Length; j++)
                {
                    res[i][j] = random.Next(max);
                }
            }

            return res;
        }

        private static void PrintArrayLineByLine(int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a[i].Length; j++)
                {
                    Console.Write($"{a[i][j],3} ");
                }
                Console.WriteLine();
            }
        }

        private static void PrintArray(int[][] a)
        {
            Console.Write("{");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{");

                for (int j = 0; j < a[i].Length - 1; j++)
                {
                    Console.Write($"{a[i][j], 3}, ");
                }
                Console.Write($"{a[i][a[i].Length - 1], 3}");

                Console.Write("}, ");
            }

            Console.Write("}");
        }

        private static int GetElement(int[][] a, int index)
        {
            if (a == null)
            {
                throw new ArgumentNullException("Array was not initialized.");
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (index >= a[i].Length)
                {
                    index -= a[i].Length;
                    continue;
                }

                return a[i][index];
            }

            throw new IndexOutOfRangeException();
        }

        private static int GetLength(int[][] a)
        {
            int res = 0;

            foreach (int[] i in a)
            {
                res += i.Length;
            }

            return res;
        }

        private static void SwapElement(int[][] a, int index1, int index2)
        {
            if (a == null)
            {
                throw new ArgumentNullException("Array was not initialized.");
            }

            int l = GetLength(a);

            if (index1 < 0 || index1 >= l)
            {
                throw new IndexOutOfRangeException("index1");
            }

            if (index2 < 0 || index2 >= l)
            {
                throw new IndexOutOfRangeException("index2");
            }

            int i1_1, i1_2, i2_1, i2_2;
            i1_1 = i1_2 = i2_1 = i2_2 = 0;

            bool search1 = true, search2 = true;

            for (int i = 0; i < a.Length; i++)
            {
                if(search1)
                {
                    if(index1 < a[i].Length)
                    {
                        i1_1 = i;
                        i1_2 = index1;
                        search1 = false;
                    }
                    else
                    {
                        index1 -= a[i].Length;
                    }
                }

                if (search2)
                {
                    if(index2 < a[i].Length)
                    { 
                    i2_1 = i;
                    i2_2 = index2;
                    search2 = false;
                    }
                    else
                    {
                        index2 -= a[i].Length;
                    }
                }

                if (!search1 && !search2)
                {
                    break;
                }
            }

            int t = a[i1_1][i1_2];
            a[i1_1][i1_2] = a[i2_1][i2_2];
            a[i2_1][i2_2] = t;
        }

        private static void SortArray(int[][] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int new_index = i;

                for(int j = i + 1; j < a.Length; j++)
                {
                    if(a[j].Length < a[new_index].Length)
                    {
                        new_index = j;
                    }
                }

                int[] t = a[i];
                a[i] = a[new_index];
                a[new_index] = t;
            }

            int l = GetLength(a);

            for (int i = 0; i < l - 1; i++)
            {
                int new_index = i;
                int new_index_elem = GetElement(a, new_index);

                for (int j = i + 1; j < l; j++)
                {
                    int j_element = GetElement(a, j);
                    if (j_element < new_index_elem)
                    {
                        new_index = j;
                        new_index_elem = j_element;
                    }
                }

                SwapElement(a, i, new_index);
            }
        }

        public static void Task()
        {
            int n = Input();

            int[][] a = InitArray(n);
            Console.WriteLine("Array:");
            PrintArray(a);
            Console.WriteLine();

            SortArray(a);
            Console.WriteLine("Sorted array:");
            PrintArray(a);

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
