using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HW_Task_04
{
    class Task_6
    {
        public static IEnumerable<int> FindAllPositive(IEnumerable<int> a)
        {
            int cnt = 0;
            foreach (int i in a)
            {
                if (i > 0)
                {
                    cnt++;
                }
            }

            int[] res = new int[cnt];
            cnt = 0;
            foreach (int i in a)
            {
                if (i > 0)
                {
                    res[cnt] = i;
                    cnt++;
                }
            }

            return res;
        }

        public static IEnumerable<T> FindAll<T>(IEnumerable<T> a, Predicate<T> predicate)
        {
            if (a == null)
            {
                throw new ArgumentNullException("a");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            int cnt = 0;
            foreach (T i in a)
            {
                if (predicate(i))
                {
                    cnt++;
                }
            }

            T[] res = new T[cnt];
            cnt = 0;
            foreach (T i in a)
            {
                if (predicate(i))
                {
                    res[cnt] = i;
                    cnt++;
                }
            }

            return res;
        }

        private static bool IsPositive(int n)
        {
            return n > 0;
        }

        private static int[] GenerateArray(int count, int min = -100, int max = 101)
        {
            Random random = new Random();
            int[] res = new int[count];
            for(int i = 0; i < count; i++)
            {
                res[i] = random.Next(min, max);
            }
            return res;
        }

        enum Finders
        {
            Method, DelegateInstance, AnonMethod, Lambda, LINQ
        }

        private static long CheckFinder<T>(int count, int test_count, 
            Stopwatch timer, Func<IEnumerable<T>, IEnumerable<T>> finder)
        {
            int[] a = null;
            IEnumerable<int> res = null;
            long[] ticks = new long[test_count];

            for (int i = 0; i < test_count; i++)
            {
                a = GenerateArray(count);

                timer.Start();
                res = FindAllPositive(a);
                timer.Stop();
                ticks[i] = timer.ElapsedTicks;
                timer.Reset();
            }

            Array.Sort(ticks);
            return ticks[test_count / 2];
        }

        public static void Task()
        {
            Stopwatch timer = new Stopwatch();
            (Finders, long)[] finders_time = new (Finders, long)[5];
            int element_count = 10000;
            int test_count = 1000;

            Console.WriteLine("Method");
            finders_time[0] = (Finders.Method,
                CheckFinder<int>(element_count, test_count, timer, FindAllPositive));
            Console.WriteLine($"Ticks: {finders_time[0].Item2}");
            Console.WriteLine();

            Console.WriteLine("Delegate instance");
            finders_time[1] = (Finders.DelegateInstance,
                CheckFinder<int>(
                    element_count, test_count, timer,
                    (a) =>
                        FindAll(
                            a,
                            new Predicate<int>(IsPositive)
                            )
                        )
                );
            Console.WriteLine($"Ticks: {finders_time[1].Item2}");
            Console.WriteLine();

            Console.WriteLine("Anon Method");
            finders_time[2] = (Finders.AnonMethod,
                CheckFinder<int>(
                    element_count, test_count, timer,
                    (a) =>
                        FindAll(
                            a,
                            delegate (int n) { return n > 0; }
                            )
                        )
                );
            Console.WriteLine($"Ticks: {finders_time[2].Item2}");
            Console.WriteLine();

            Console.WriteLine("Lambda");
            finders_time[3] = (Finders.Lambda,
                CheckFinder<int>(
                    element_count, test_count, timer,
                    (a) =>
                        FindAll(
                            a,
                            (x) => (x > 0)
                            )
                        )
                );
            Console.WriteLine($"Ticks: {finders_time[3].Item2}");
            Console.WriteLine();

            Console.WriteLine("LINQ");
            finders_time[4] = (Finders.LINQ,
                CheckFinder<int>(
                    element_count, test_count, timer,
                    (a) => a.Where((x) => (x > 0))
                    )
                );
            Console.WriteLine($"Ticks: {finders_time[4].Item2}");
            Console.WriteLine();

            Array.Sort(finders_time,
                (x, y) =>
                {
                    if (x.Item2 < y.Item2) return -1;
                    if (x.Item2 > y.Item2) return 1;
                    return 0;
                });


            Console.Write($"{finders_time[0].Item1} ");
            for(int i = 1; i <finders_time.Length; i++)
            {
                Console.Write($"< {finders_time[i].Item1} ");
            }
        }
    }
}
