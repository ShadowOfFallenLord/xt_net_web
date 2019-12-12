using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_04
{
    static class Task_4
    {
        public static int SumOfArray(this IEnumerable<int> a)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            int res = 0;
            foreach (int i in a)
            {
                res += i;
            }
            return res;
        }

        public static double SumOfArray(this IEnumerable<double> a)
        {
            if(a == null)
            {
                throw new ArgumentNullException("a");
            }

            double res = 0;
            foreach (double i in a)
            {
                res += i;
            }
            return res;
        }

        public static void Task()
        {
            int[] a = new int[] { 2, 2, 2, 2, 2 };

            Console.Write("Array: ");
            foreach(int i in a)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            

            int res = a.SumOfArray();
            Console.WriteLine($"Sum: {res}");
        }
    }
}
