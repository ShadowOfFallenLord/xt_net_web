using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_Task_7
{
    class Task_2
    {
        public static void Task()
        {
            Regex regex = new Regex(@"<[^<>]*>");

            Console.WriteLine("Enter your text");
            Console.Write("> ");

            string input = Console.ReadLine();

            while (input.Length == 0)
            {
                Console.WriteLine("Input error!");
                Console.WriteLine("Enter NOT EMPTY string, please.");
                Console.Write("> ");
                input = Console.ReadLine();
            }

            string result = regex.Replace(input, "_");
            Console.WriteLine($"Result: {result}");
        }
    }
}
