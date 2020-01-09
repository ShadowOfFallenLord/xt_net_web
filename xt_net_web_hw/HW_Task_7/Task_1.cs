using System;
using System.Text.RegularExpressions;

namespace HW_Task_7
{
    class Task_1
    {
        public static void Task()
        {
            string day_pattern = @"((0[1-9])|(1[0-9])|(2[0-9])|(3[01]))";
            string month_pattern = @"((0[1-9])|(1[012]))";
            string year_pattern = @"([0-9]{4})";
            string pattern = @"\b(" + day_pattern + 
                "-" + month_pattern + 
                "-" + year_pattern + @")\b";

            Regex regex = new Regex(pattern);

            Console.WriteLine("Enter text containing the date in the format dd-mm-yyyy:");
            Console.Write("> ");
            string input = Console.ReadLine();

            while(input.Length == 0)
            {
                Console.WriteLine("Input error!");
                Console.WriteLine("Enter NOT EMPTY string, please.");
                Console.Write("> ");
                input = Console.ReadLine();
            }

            MatchCollection dates = regex.Matches(input);
            Console.Write("This string contains ");

            if(dates.Count == 0)
            {
                Console.WriteLine(" no dates.");
                return;
            }
            else
            {
                Console.WriteLine($"{dates.Count} dates:");
            }

            foreach(Match match in dates)
            {
                Console.WriteLine($"- {match.Value}");
            }
        }
    }
}
