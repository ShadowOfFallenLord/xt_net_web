using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class Triangle
    {
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }

        public double Perimeter { get; private set; }
        public double Area { get; private set; }

        public Triangle(int a, int b, int c)
        {
            if (a < 0) throw new ArgumentOutOfRangeException("a < 0");
            if (b < 0) throw new ArgumentOutOfRangeException("b < 0");
            if (c < 0) throw new ArgumentOutOfRangeException("c < 0");

            if (b + c <= a) throw new ArgumentException("b + c <= a");
            if (c + a <= b) throw new ArgumentException("c + a <= b");
            if (a + b <= c) throw new ArgumentException("a + b <= c");

            A = a;
            B = b;
            C = c;

            Perimeter = a + b + c;
            double half_p = Perimeter / 2.0;
            Area = Math.Sqrt(half_p * (half_p - a) * (half_p - b) * (half_p - c));
        }
    }
}
