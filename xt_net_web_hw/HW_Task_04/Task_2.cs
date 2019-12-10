using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_04
{
    class Task_2
    {        

        public static void Task()
        {
            string[] a = new string[] {
                "aaaaa",
                "a",
                "aaaa",
                "aa",
                "aaa", };

            Task_1.PrintArray(a);

            Task_1.SortArray(a, (x, y) => (x.Length < y.Length));

            Task_1.PrintArray(a);
        }
    }
}
