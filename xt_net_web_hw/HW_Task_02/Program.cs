using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_02
{
    class Program
    {
        static void CheckRound()
        {
            Console.WriteLine("Task 2.1");
            Round round = new Round(1, 2, 3);
            Console.WriteLine($"({round.X}, {round.Y}), {round.Radius}");
            Console.WriteLine($"Length: {round.Length}");
            Console.WriteLine($"Area: {round.Area}");
            Console.WriteLine();
        }

        static void CheckTriangle()
        {
            Console.WriteLine("Task 2.2");
            Triangle triangle = new Triangle(3, 3, 3);
            Console.WriteLine($"{triangle.A}, {triangle.B}, {triangle.C}");
            Console.WriteLine($"Length: {triangle.Perimeter}");
            Console.WriteLine($"Area: {triangle.Area}");
            Console.WriteLine();
        }

        static void CheckUser()
        {
            Console.WriteLine("Task 2.3");
            User user = new User("a", "b", "c", new DateTime(1, 2, 3), 666);
            Console.WriteLine($" Name: {user.Name}");
            Console.WriteLine($"LName: {user.LastName}");
            Console.WriteLine($"FName: {user.FatherName}");
            Console.WriteLine($"Birth: {user.Birth:d}");
            Console.WriteLine($" Age : {user.Age}");
            Console.WriteLine();
        }

        static void CheckString()
        {
            Console.WriteLine("Task 2.4");
            MyString s1 = new MyString("abcde");
            Console.WriteLine($"MyString1: {s1}");

            char[] c = (char[])s1;
            Console.Write($"Char[]: ");
            foreach(char i in c)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            
            MyString s2 = new MyString(c);
            Console.WriteLine($"MyString2: {s2}");

            s1.Concat(s2);
            Console.WriteLine($"MyString1: {s1}");

            Console.WriteLine($"cmp s1 s1: {s1.CompareTo(s1)}");
            Console.WriteLine($"cmp s1 s2: {s1.CompareTo(s2)}");
            Console.WriteLine($"cmp s2 s1: {s2.CompareTo(s1)}");

            for(int i = 0; i < s1.Length; i++)
            {
                Console.WriteLine($"Find: {s1[i]} -> {s1.Find(s1[i])}");
            }

            Console.WriteLine();
        }

        static void CheckEmployee()
        {
            Console.WriteLine("Task 2.5");
            Employee user = new Employee("a", "b", "c", new DateTime(1, 2, 3), 666, "c", 5);
            Console.WriteLine($" Name: {user.Name}");
            Console.WriteLine($"LName: {user.LastName}");
            Console.WriteLine($"FName: {user.FatherName}");
            Console.WriteLine($"Birth: {user.Birth:d}");
            Console.WriteLine($" Age : {user.Age}");
            Console.WriteLine($"Post : {user.Post}");
            Console.WriteLine($" Exp : {user.Experience}");
            Console.WriteLine();
        }

        static void CheckRing()
        {
            Console.WriteLine("Task 2.6");
            Ring ring = new Ring(1, 2, 2, 3);
            Console.WriteLine($"({ring.X}, {ring.Y}), {ring.Radius}, {ring.InnerRadius}");
            Console.WriteLine($"Length: {ring.Length}");
            Console.WriteLine($"Area: {ring.Area}");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //CheckRound();
            //CheckTriangle();
            //CheckUser();
            //CheckString();
            //CheckEmployee();
            CheckRing();

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}
