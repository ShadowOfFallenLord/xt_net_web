using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_12
    {
        private static string Update(string inp1, string inp2)
        {
            StringBuilder builder = new StringBuilder(inp1);

            for(int i = 0; i < builder.Length; i++)
            {
                if(inp2.Contains(builder[i]))
                {
                    builder.Insert(i, builder[i]);
                    i++;
                }
            }

            return builder.ToString();
        }

        public static void Task()
        {
            Console.WriteLine("Enter first string: ");
            Console.Write("> ");
            string input1 = Console.ReadLine();

            Console.WriteLine("Enter second string: ");
            Console.Write("> ");
            string input2 = Console.ReadLine();

            Console.WriteLine($"Result: {Update(input1, input2)}");

            Console.WriteLine($"{Environment.NewLine} Press any key to continue...");
            Console.ReadKey();
        }
    }
}
