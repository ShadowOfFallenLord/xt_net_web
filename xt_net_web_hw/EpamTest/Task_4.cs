using System;

namespace EpamTest
{
    class Program
    {
        static int Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("n must be positive.");

            int res = 1;

            for (int i = 2; i <= n; i++)
            {
                res *= i;
            }

            return res;
        }

        static double Factorial(double n)
        {
            if (n < 0) throw new ArgumentException("n must be positive.");

            if (n == (double)((int)n)) return Factorial((int)n);

            // Difficult formula from the internet
            double part_1 = Math.Sqrt(2 * Math.PI * n);
            double part_2 = Math.Pow(n / Math.E, n);
            double part_3_divider = Math.Sqrt(52 * Math.E) * n;
            double part_3 = 1.0 + (1.0 / part_3_divider);

            return part_1 * part_2 * part_3;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("start:");

            double start_n = 3;

            for(double i = 0; i <= 1; i += 0.1)
            {
                double n = start_n + i;
                Console.WriteLine($"{n}! = {Factorial(n)}");
            }

            Console.WriteLine("end.");
            Console.ReadKey();
        }
    }
}
