using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Task_05.Common
{
    class RecoveryUI
    {
        private string[] versions;

        public RecoveryUI()
        {
            versions = RecoveryMaster.GetVersions();
        }

        public void ShowAllVersions()
        {
            Console.WriteLine("All versions:");
            foreach(string s in versions)
            {
                Console.WriteLine(s);
            }
        }

        public void ChoiseVersion()
        {
            while(true)
            {
                string[] current_versions = versions;
                while (true)
                {
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;
                    //Console.WriteLine($"Have {current_versions.Length} versions");

                    Console.WriteLine("Enter year:");
                    Console.Write("> ");

                    string year = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0)
                    {
                        Console.WriteLine("Enter positive integer (year)!");
                        Console.Write("> ");
                        year = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, year, 4, 0);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter month:");
                    Console.Write("> ");
                    string month = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 12)
                    {
                        Console.WriteLine("Enter integer between 0 and 12 (month)!");
                        Console.Write("> ");
                        month = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, month, 2, 5);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter day:");
                    Console.Write("> ");
                    string day = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 31)
                    {
                        Console.WriteLine("Enter integer between 0 and 31 (day)!");
                        Console.Write("> ");
                        day = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, day, 2, 8);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter hour:");
                    Console.Write("> ");
                    string hour = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 23)
                    {
                        Console.WriteLine("Enter integer between 0 and 23 (hour)!");
                        Console.Write("> ");
                        hour = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, hour, 2, 11);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter minute:");
                    Console.Write("> ");
                    string minute = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 59)
                    {
                        Console.WriteLine("Enter integer between 0 and 59 (minute)!");
                        Console.Write("> ");
                        minute = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, minute, 2, 14);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter second:");
                    Console.Write("> ");
                    string second = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 59)
                    {
                        Console.WriteLine("Enter integer between 0 and 59 (second)!");
                        Console.Write("> ");
                        second = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, second, 2, 17);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    if (current_versions.Length == 0 || current_versions.Length == 1) break;

                    Console.WriteLine("Enter milisecond:");
                    Console.Write("> ");
                    string milisecond = Console.ReadLine();
                    while (!int.TryParse(year, out var t) && t < 0 && t > 999)
                    {
                        Console.WriteLine("Enter integer between 0 and 999 (milisecond)!");
                        Console.Write("> ");
                        milisecond = Console.ReadLine();
                    }

                    current_versions = UpdateCurrentVersions(current_versions, milisecond, 3, 20);
                    //Console.WriteLine($"Have {current_versions.Length} versions");
                    break;
                }

                if (current_versions.Length != 1)
                {
                    Console.WriteLine("Error! Have not this version.");
                    Console.WriteLine("1 - try agan");
                    Console.WriteLine("0 - exit");

                    int input = 0;
                    while (!int.TryParse(Console.ReadLine(), out input)
                        && (input != 0 || input != 1))
                    {
                        Console.WriteLine("Enter 1 or 0");
                        Console.Write("> ");
                    }

                    if (input == 0)
                    {
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }

                if(current_versions.Length == 1)
                {
                    Console.WriteLine($"Find version {current_versions[0]}");
                    Console.WriteLine("Recovery?");
                    Console.WriteLine("1 - Yes");
                    Console.WriteLine("2 - No");
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

                    if(input == 1)
                    {
                        RecoveryMaster.RecoverySave(current_versions[0]);
                        Console.WriteLine("Recovery successful");
                    }
                    else
                    {
                        continue;
                    }
                }

                break;
            }            
        }

        private string[] UpdateCurrentVersions(string[] current, 
            string check, int check_length, int offset)
        {
            while(check.Length < check_length)
            {
                check = "0" + check;
            }

            return current.Where((x) =>
            {
                for (int i = 0; i < check_length; i++)
                {
                    if (x[offset + i] != check[i])
                    {
                        return false;
                    }
                }
                return true;
            }).ToArray();
        }
    }
}
