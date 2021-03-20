using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_Task_7
{
    class Task_4
    {
        public static void Task()
        {
            string number = "([0-9])";
            string numbers = "(" + number + "+)";
            string plus_minus = "(([+-]){0,1})";
            string only_numbers = "(" + plus_minus + numbers + ")";
            string after_point_part = "(" + @"\." + numbers + ")";

            string only_numbers_with_point = 
                "(" + only_numbers + after_point_part + "{0,1})";

            string with_mult = 
                "(" + only_numbers_with_point + @"\*" +
                numbers + @"(\^" + only_numbers + "){0,1})";

            string exp = 
                "(" + only_numbers_with_point + "e" + only_numbers + ")";

            Regex regex_numbers = new Regex("^" + only_numbers_with_point + "$");
            Regex regex_mult = new Regex("^" + with_mult + "$");
            Regex regex_exp = new Regex("^" + exp + "$");

            Console.WriteLine("Enter your string:");
            Console.Write("> ");
            string input = Console.ReadLine();

            if (regex_numbers.IsMatch(input))
            {
                Console.WriteLine("It is normal number");
                return;
            }

            if (regex_mult.IsMatch(input))
            {
                Console.WriteLine("It is number with mult");
                return;
            }

            if (regex_exp.IsMatch(input))
            {
                Console.WriteLine("This number is in scientific notation");
                return;
            }

            Console.WriteLine("It is not number.");
        }
    }
}
