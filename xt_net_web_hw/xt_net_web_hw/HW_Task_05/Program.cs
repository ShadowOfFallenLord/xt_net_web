using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HW_Task_05.Common;

namespace HW_Task_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Folder:");
            Console.WriteLine(ValueKeeper.Root);

            while(true)
            {
                Console.Clear();
                Console.WriteLine("What you want:");
                Console.WriteLine("1 - Observe");
                Console.WriteLine("2 - Recovery");
                Console.WriteLine("0 - Exit");

                int input = 0;
                while (!int.TryParse(Console.ReadLine(), out input)
                    && (input != 0 || input != 1 || input != 2))
                {
                    Console.WriteLine("Enter 1, 2 or 0");
                    Console.Write("> ");
                }

                if (input == 0)
                {
                    return;
                }

                if (input == 1)
                {
                    Console.WriteLine("Press Enter to stop observing.");
                    BackUpper.BackUp(DateTime.Now);
                    Observer logger = new Observer(true);
                    logger.OnUpdate += BackUpper.BackUp;
                    logger.StartObserve();
                    while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                    logger.StopObserve();
                }
                else
                {
                    RecoveryUI recovery = new RecoveryUI();
                    recovery.ChoiseVersion();
                }

                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}
