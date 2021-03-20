using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02.task_2_7
{
    class Line : Figure
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }

        public Line(Point start_points, Point end_points, Color color) : base()
        {
            Color = color;
            StartPoint = start_points;
            EndPoint = end_points;

            int tx = start_points.X;
            int ty = start_points.Y;

            if (end_points.X < tx)
            {
                tx = end_points.X;
            }

            if (end_points.Y < ty)
            {
                ty = end_points.Y;
            }

            Position = new Point(tx, ty);
        }

        public Line(Point start_points, Point end_points) 
            : this(start_points, end_points, Color.Black)
        {
            //
        }

        public override void Print()
        {
            Console.Write($"Print line at ({Position.X}, {Position.Y}) ");
            Console.Write($"from ({StartPoint.X}, {StartPoint.Y}) ");
            Console.Write($"to ({EndPoint.X}, {EndPoint.Y}) ");
            Console.WriteLine($"with {Color} color");
        }
    }
}
