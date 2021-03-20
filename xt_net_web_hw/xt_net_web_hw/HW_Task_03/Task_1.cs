using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_03
{
    class Task_1
    {
        private static int ReadInt()
        {
            int res = 0;
            Console.WriteLine("Enter positive integer N:");
            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out res) && res > 0) break;
                Console.WriteLine("Input Error! Enter positive integer.");
            }
            return res;
        }

        private static void PrintQueue<T>(Queue<T> queue)
        {
            foreach (T i in queue)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        public static void Task()
        {
            int n = ReadInt();            

            Queue<int> queue = new Queue<int>(n);
            for (int i = 1; i <= n; i++)
            {
                queue.Enqueue(i);
            }

            PrintQueue(queue);

            while (queue.Count > 1)
            {
                int cnt = queue.Count;
                for(int i = 0, t; i < cnt; i++)
                {
                    t = queue.Dequeue();
                    if (i % 2 == 1) continue;
                    queue.Enqueue(t);
                }

                PrintQueue(queue);
            }
        }
    }
}
