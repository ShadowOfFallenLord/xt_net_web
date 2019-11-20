using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_5
    {
        public static void Task()
        {
            int res = 0;
            const int end_num = 1000;

            for(int i = 3; i < end_num; i++)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    res += i;
                }
            }
            
            Console.WriteLine($"Result: {res}");
            Console.WriteLine($"{Environment.NewLine} Press any key to continue...");
            Console.ReadKey();
        }
    }
}
