using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class UICore
    {
        public static UICore Instance => new UICore();

        private Core core;

        public UICore()
        {
            core = new Core();
        }

        private int Input()
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            int res = 0;

            if(!int.TryParse(input, out res))
            {
                throw new Exception($"Invalid input: \"{input}\" is not a number.");
            }

            return res;
        }

        private void Pause()
        {
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public void Start()
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Enter variant:");
                Console.WriteLine(" 1 - Add figure");
                Console.WriteLine(" 2 - Show figures");
                Console.WriteLine(" 0 - Exit");

                switch(Input())
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Show();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Your input is not 0, 1 or 2. Repeat please.");
                        Pause();
                        continue;
                }
            }
        }

        private Point ReadPoint()
        {
            Console.WriteLine("Enter X:");
            int x = Input();
            Console.WriteLine("Enter Y:");
            int y = Input();
            return new Point(x, y);
        }

        private Line ReadLine()
        {
            Console.Clear();
            Console.WriteLine("Enter start point:");
            Point start = ReadPoint();
            Console.WriteLine("Enter end point:");
            Point end = ReadPoint();
            return new Line(start, end);
        }

        private Circle ReadCircle()
        {
            Console.Clear();
            Console.WriteLine("Enter start point:");
            Point center = ReadPoint();
            int radius = 0;
            while (true)
            {
                Console.WriteLine("Enter positive radius:");
                radius = Input();
                if (radius >= 0) break;
                Console.WriteLine("Invalid input. Radius must be positive.");
            }
            return new Circle(center, radius);
        }

        private Ring ReadRing()
        {
            Circle circle = ReadCircle();
            int radius = 0;
            while (true)
            {
                Console.WriteLine("Enter positive inner radius:");
                radius = Input();
                if (radius >= 0) break;
                Console.WriteLine("Invalid input. Radius must be positive.");
            }

            return new Ring(circle, radius);
        }

        private Rectangle ReadRectangle()
        {
            Console.Clear();
            Console.WriteLine("Enter position:");
            Point pos = ReadPoint();

            int width = 0;
            while (true)
            {
                Console.WriteLine("Enter positive width:");
                width = Input();
                if (width > 0) break;
                Console.WriteLine("Invalid input. Width must be positive.");
            }

            int heigth = 0;
            while (true)
            {
                Console.WriteLine("Enter positive inner heigth:");
                heigth = Input();
                if (heigth > 0) break;
                Console.WriteLine("Invalid input. Heigth must be positive.");
            }

            return new Rectangle(pos, width, heigth);
        }

        private void Add()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(" What you want to create:");
                Console.WriteLine(" 1 - Line,");
                Console.WriteLine(" 2 - Circle,");
                Console.WriteLine(" 3 - Round,");
                Console.WriteLine(" 4 - Ring,");
                Console.WriteLine(" 5 - Rectangle");
                Console.WriteLine(" 0 - Back");

                Figure figure = null;

                switch (Input())
                {
                    case 1:
                        figure = ReadLine();
                        break;
                    case 2:
                        figure = ReadCircle();
                        break;
                    case 3:
                        figure = new Round(ReadCircle());
                        break;
                    case 4:
                        figure = ReadRing();
                        break;
                    case 5:
                        figure = ReadRectangle();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Your input is not 0, 1 or 2. Repeat please.");
                        Pause();
                        continue;
                }

                core.AddFigure(figure);
            }
        }

        private void Show()
        {
            Console.Clear();
            core.Print();
            Pause();
        }
    }
}
