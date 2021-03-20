using System;
using System.Collections.Generic;

namespace EpamTest
{
    class Program
    {
        static bool IsOpenBracket(char c)
        {
            return c == '(' || c == '{' || c == '[';
        }

        static bool IsClosedBracket(char c)
        {

            return c == ')' || c == '}' || c == ']';
        }

        static bool IsRightClosedBracket(char open, char close)
        {
            switch(open)
            {
                case '(': return close == ')';
                case '[': return close == ']';
                case '{': return close == '}';
            }

            return false;
        }

        static bool CheckBracketSequence(string sequence)
        {
            if (sequence.Length == 0) return false;

            Stack<char> stack = new Stack<char>();
            
            foreach(char i in sequence)
            {
                if(IsOpenBracket(i))
                {
                    stack.Push(i);
                    continue;
                }

                if(IsClosedBracket(i))
                {
                    if (stack.Count == 0) return false;

                    char last = stack.Pop();
                    if (IsRightClosedBracket(last, i)) continue;

                    return false;
                }

                throw new ArgumentException($"Sequence \"{sequence}\" contains not only brackets.");
            }

            if (stack.Count != 0) return false;
            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start:");

            string[] sequences = new string[8];
            sequences[0] = "()";
            sequences[1] = "([{}])";
            sequences[2] = "((()";
            sequences[3] = "()))";
            sequences[4] = "({]}[)";
            sequences[5] = "";
            sequences[6] = "(abc)";

            try
            {
                foreach (string i in sequences)
                {
                    bool res = CheckBracketSequence(i);
                    Console.WriteLine($"\"{i}\" -> {res}");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("end.");
            Console.ReadKey();
        }
    }
}
