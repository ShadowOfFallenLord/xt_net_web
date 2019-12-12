using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_04
{
    static class Task_5
    {
        public static bool IsInteger(this string s)
        {
            if (s == null)
            {
                throw new ArgumentNullException("a");
            }

            if (s.Length == 0)
            {
                return false;
            }

            int i = 0;
            if (s[0] == '-' | s[0] == '+')
            {
                i++;
            }

            for(; i < s.Length; i++)
            {
                if(!char.IsDigit(s[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public static void Task()
        {
            string s = "";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "abc";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "+5";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "3476";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "-346";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "3.23";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = "1/42";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
            s = ":3";
            Console.WriteLine($"For \"{s}\" - {s.IsInteger()}");
        }
    }
}
