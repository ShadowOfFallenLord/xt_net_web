using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HW_Task_7
{
    class Task_3
    {
        public static void Task()
        {
            string letters = "([a-z])";
            string numbers = "([0-9])";
            string letter_or_number = "(" + letters + "|" + numbers + ")";
            string other_name_simvols = "([.-_])";
            string user_name = "(" + letter_or_number + 
                "|(" + letter_or_number +
                "(" + letter_or_number + "|" + other_name_simvols + ")*" +
                letter_or_number + "))";
            string dog = "@";
            string poddomen = "((" + letter_or_number
                + "|(" + letter_or_number +
                "(" + letter_or_number + "|[.-])*" + letter_or_number + @"))\.)";
            string domen = "((" + letter_or_number
                + "|(" + letter_or_number +
                "(" + letter_or_number + "|[.-]){0,4}" + letter_or_number + @"))\.)";
            string tail = "((ru)|(com)|(net))";

            string patterm = user_name + dog + "(" + poddomen + ")*" + domen + tail;

            Regex regex = new Regex(patterm, RegexOptions.IgnoreCase);

            Console.WriteLine("Enter your string:");
            Console.Write("> ");
            string input = Console.ReadLine();

            MatchCollection collection = regex.Matches(input);
            Console.WriteLine("Found emails:");
            foreach(Match match in collection)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
