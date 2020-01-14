using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HW_Task_7
{
    class Task_5
    {
        public static void Task()
        {
            string hour = "(([0-9])|(0[0-9])|(1[0-9])|(2[0-3]))";
            string minute = "([0-5][0-9])";
            string pattern = "(" + hour + @"\:" + minute + ")";

            Regex regex = new Regex(pattern);

            Console.WriteLine("Enter your string:");
            Console.Write("> ");

            string input = Console.ReadLine();
            MatchCollection collection = regex.Matches(input);

            Console.WriteLine($"Found {collection.Count} time:");
            foreach(Match match in collection)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
