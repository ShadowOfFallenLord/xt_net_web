using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_01
{
    class Task_1_6
    {
        enum Styles : byte
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        struct TextStyle
        {
            private byte style;

            public void SetStyle(Styles style)
            {
                this.style |= (byte)style;
            }

            public void ClearStyle(Styles style)
            {
                this.style &= (byte)~style;
            }

            public bool CheckStyle(Styles style)
            {
                return (this.style & (byte)style) != 0;
            }

            public void SwichStyle(Styles style)
            {
                if (CheckStyle(style))
                {
                    ClearStyle(style);
                }
                else
                {
                    SetStyle(style);
                }
            }

            public void Print()
            {
                Console.Write("Parameter: ");

                if (style == (byte)Styles.None)
                {
                    Console.WriteLine(Styles.None);
                    return;
                }

                bool is_first = true;

                if ((style & (byte)Styles.Bold) != 0)
                {
                    Console.Write(Styles.Bold);
                    is_first = false;
                }

                if ((style & (byte)Styles.Italic) != 0)
                {
                    if (!is_first)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(Styles.Italic);
                    is_first = false;
                }

                if ((style & (byte)Styles.Underline) != 0)
                {
                    if (!is_first)
                    {
                        Console.Write(", ");
                    }
                    Console.Write(Styles.Underline);
                    is_first = false;
                }
                Console.WriteLine();
            }
        }

        private static bool CheckOnNumber(string input, out int res)
        {
            if (!int.TryParse(input, out res))
            {
                res = 0;
                Console.WriteLine(" Error!");
                Console.WriteLine($" \"{input}\" is not integer.");
                Console.WriteLine(" Repeat input please.");
                return false;
            }
            return true;
        }

        private static bool CheckOnCorrect(int num)
        {
            if (num >= 0 && num <= 3) return true;

            Console.WriteLine(" Error!");
            Console.WriteLine($" {num} is not 1, 2, 3 or 0.");
            Console.WriteLine(" Repeat input please.");

            return false;
        }

        private static int Input()
        {
            string input;
            int res;

            Console.WriteLine("Enter:");
            Console.WriteLine("   1) Bold:");
            Console.WriteLine("   2) Italic:");
            Console.WriteLine("   3) Underline:");
            Console.WriteLine("   0) Exit:");

            while (true)
            {
                Console.Write("> ");
                input = Console.ReadLine();

                if (!CheckOnNumber(input, out res)) continue;

                if (!CheckOnCorrect(res)) continue;

                break;
            }

            return res;
        }

        private static Styles StyleParse(int input)
        {
            switch (input)
            {
                case 1: return Styles.Bold;
                case 2: return Styles.Italic;
                case 3: return Styles.Underline;
            }
            return Styles.None;
        }

        public static void Task()
        {
            TextStyle style = new TextStyle();

            int input;
            while(true)
            {
                style.Print();
                input = Input();

                if (input == 0) break;

                style.SwichStyle(StyleParse(input));
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
