﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6.DAL;
using Task_6.DAL.Awards;
using Task_6.DAL.Users;
using Task_6.BLL;
using Task_6.PL;

namespace HW_Task_06
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsolePL task = new ConsolePL();
            task.Main();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
