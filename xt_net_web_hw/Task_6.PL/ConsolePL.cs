using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_6.BLL;
using Task_6.Interfaces;

namespace Task_6.PL
{
    public class ConsolePL
    {
        private UserLogic logic;

        public ConsolePL()
        {
            logic = new UserLogic();
        }

        private void DisplayInitErrors()
        {
            switch (logic.InitError)
            {
                case InitErrors.FileExistError:
                    Console.WriteLine("DataBase file not found!");
                    Console.WriteLine($"Check {logic.DataBaseFile} file.");
                    Console.WriteLine("DataBase created empty.");
                    break;
                case InitErrors.FileFormatError:
                    Console.WriteLine("DataBase file was damaged.");
                    Console.WriteLine($"Check {logic.DataBaseFile} file.");
                    Console.WriteLine("DataBase created empty.");
                    break;
                case InitErrors.None:
                    Console.WriteLine("DataBase loaded successfully");
                    break;
            }
        }

        public void Main()
        {
            bool is_first = true;
            while (true)
            {
                Console.Clear();

                if (is_first)
                {
                    DisplayInitErrors();
                    is_first = false;
                }

                Console.WriteLine("Choise your action:");
                Console.WriteLine("1) Look users");
                Console.WriteLine("2) Save");
                Console.WriteLine("0) Exit");
                Console.Write("> ");

                int input = 0;
                while (!int.TryParse(Console.ReadLine(), out input)
                    && (input < 0 || input > 2))
                {
                    Console.WriteLine("Input error!");
                    Console.WriteLine("Enter 0, 1 or 2.");
                    Console.Write("> ");
                }

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Goodbye.");
                        return;
                    case 1:
                        LookUsersComand();
                        break;
                    case 2:
                        Console.Clear();
                        if (logic.Save())
                        {
                            Console.WriteLine("DataBase saved successfully.");
                        }
                        else
                        {
                            Console.WriteLine("DataBase not saved.");
                        }
                        Console.WriteLine("Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void LookUsersComand()
        {
            int records_on_page = 10;

            string[] users = logic.GetAllUsers();
            int current_page = 1;

            while(true)
            {   
                if(current_page == 0)
                {
                    current_page = 1;
                }

                int max_page = users.Length / records_on_page;
                if (users.Length % records_on_page != 0) max_page++;

                if (current_page > max_page)
                {
                    current_page = max_page;
                }

                Console.Clear();
                Console.WriteLine($"DataBase contains {users.Length} users.");
                Console.WriteLine($"Page {current_page}/{max_page}");

                int last_index_of_page = current_page * records_on_page;
                if (last_index_of_page > users.Length) last_index_of_page = users.Length;

                int records_counter = 0;
                for (int i = (current_page - 1) * records_on_page; 
                    i >= 0 && i < last_index_of_page; 
                    i++, records_counter++)
                {
                    Console.WriteLine($"{records_counter}) {users[i]}");
                }

                Console.WriteLine("Choise your action:");
                Console.WriteLine("0-9) Look user");
                Console.WriteLine("a) Add user");
                if (current_page < max_page)
                {
                    Console.WriteLine("n) Next page");
                }

                if(current_page > 1)
                {
                    Console.WriteLine("p) Prev page");
                }
                
                Console.WriteLine("e) Back");
                Console.Write("> ");

                char input = '\0';
                while (true)
                {
                    while (!char.TryParse(Console.ReadLine(), out input))
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine("Enter character.");
                        Console.Write("> ");
                        continue;
                    }

                    if((input < '0' || input > '9') 
                        && input != 'n' && input != 'p' && input != 'a' && input != 'e')
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine("Enter 0-9, n, p, a or e.");
                        Console.Write("> ");
                        continue;
                    }

                    if (input >= '0' && input <= '9')
                    {
                        if (users.Length == 0)
                        {
                            Console.WriteLine("Input error!");
                            Console.WriteLine($"DataBase have not users.");
                            Console.Write("> ");
                            continue;
                        }
                        else
                        {
                            if(input >= records_counter + '0')
                            {
                                Console.WriteLine("Input error!");
                                Console.WriteLine($"Last record is {records_counter}.");
                                Console.Write("> ");
                                continue;
                            }
                        }
                    }

                    if (input == 'n' && current_page >= max_page)
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine($"Have not next page");
                        Console.Write("> ");
                        continue;
                    }

                    if (input == 'p' && current_page <= 1)
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine($"Have not prev page");
                        Console.Write("> ");
                        continue;
                    }

                    break;
                }

                if(input >= '0' && input <= '9')
                {
                    int index = (input - '0') + (current_page - 1) * records_on_page;
                    LookUser(index);
                    users = logic.GetAllUsers();
                    continue;
                }

                switch(input)
                {
                    case 'n':
                        current_page++;
                        break;
                    case 'p':
                        current_page--;
                        break;
                    case 'a':
                        AddUser();
                        users = logic.GetAllUsers();
                        break;
                    case 'e': return;
                }
            }
        }

        private void LookUser(int index)
        {
            IUser user = logic.GetUserInfo(index);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("User info:");
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Date of Birth: {user.DateOfBirth:d}");
                Console.WriteLine($"Age: {user.Age}");
                Console.Write("Awards: ");

                if (user.Awards.Count == 0)
                {
                    Console.WriteLine("have not awards");
                }
                else
                {
                    Console.WriteLine();
                    foreach (IAward award in user.Awards)
                    {
                        Console.WriteLine($"- {award.ID} : {award.Title}");
                    }
                }

                Console.WriteLine("Choise your action:");
                Console.WriteLine("1) Add award");
                Console.WriteLine("2) Remove");
                Console.WriteLine("0) Back");
                Console.Write("> ");

                int input = 0;
                while (!int.TryParse(Console.ReadLine(), out input)
                    && (input < 0 || input > 2))
                {
                    Console.WriteLine("Input error!");
                    Console.WriteLine("Enter 0, 1 or 2.");
                    Console.Write("> ");
                }

                switch (input)
                {
                    case 0:
                        return;
                    case 1:
                        AddAward(index);
                        break;
                    case 2:
                        Console.Clear();
                        if (logic.Remove(index))
                        {
                            Console.WriteLine("User delete successfully.");
                        }
                        else
                        {
                            Console.WriteLine("User not delete.");
                        }
                        return;
                }
            }
        }

        private void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Enter name");
            Console.Write("> ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            Console.Write("> ");
            DateTime date;

            while(!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Input Error!");
                Console.WriteLine("Enter correct date please.");
                Console.Write("> ");
            }

            if(logic.Add(name, date, DateTime.Now.Year - date.Year))

            {
                Console.WriteLine("User added successfully.");
            }
            else
            {
                Console.WriteLine("User not added.");
            }
        }

        private void AddAward(int user_id)
        {
            Console.Clear();
            Console.WriteLine("Choise your action:");
            Console.WriteLine("1) Add existing award");
            Console.WriteLine("2) Add new award");
            Console.WriteLine("0) Back");
            Console.Write("> ");

            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input)
                && (input < 0 || input > 2))
            {
                Console.WriteLine("Input error!");
                Console.WriteLine("Enter 0, 1 or 2.");
                Console.Write("> ");
            }

            switch(input)
            {
                case 0:
                    return;
                case 1:
                    AddExistingAward(user_id);
                    break;
                case 2:
                    AddNewAward(user_id);
                    break;
            }
        }

        private void AddExistingAward(int user_id)
        {
            int records_on_page = 10;
            IAward[] awards = logic.GetAllAwards();
            int max_page = awards.Length / records_on_page;
            if (awards.Length % records_on_page != 0) max_page++;
            int current_page = 1;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"DataBase contains {awards.Length} awards.");
                Console.WriteLine($"Page {current_page}/{max_page}");

                int last_index_of_page = current_page * records_on_page;
                if (last_index_of_page > awards.Length) last_index_of_page = awards.Length;

                int records_counter = 0;
                for (int i = (current_page - 1) * records_on_page;
                    i >= 0 && i < last_index_of_page;
                    i++, records_counter++)
                {
                    Console.WriteLine($"{records_counter}) {awards[i].Title}");
                }

                Console.WriteLine("Choise your action:");
                Console.WriteLine("0-9) Add award");
                if (current_page < max_page)
                {
                    Console.WriteLine("n) Next page");
                }

                if (current_page > 1)
                {
                    Console.WriteLine("p) Prev page");
                }

                Console.WriteLine("e) Back");
                Console.Write("> ");

                char input = '\0';
                while (true)
                {
                    while (!char.TryParse(Console.ReadLine(), out input))
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine("Enter character.");
                        Console.Write("> ");
                        continue;
                    }

                    if ((input < '0' || input > '9')
                        && input != 'n' && input != 'p' && input != 'e')
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine("Enter 0-9, n, p or e.");
                        Console.Write("> ");
                        continue;
                    }

                    if (input >= '0' && input <= '9')
                    {
                        if (awards.Length == 0)
                        {
                            Console.WriteLine("Input error!");
                            Console.WriteLine($"DataBase have not awards.");
                            Console.Write("> ");
                            continue;
                        }
                        else
                        {
                            if(input >= records_counter + '0')
                            {
                                Console.WriteLine("Input error!");
                                Console.WriteLine($"Last record is {records_counter}.");
                                Console.Write("> ");
                                continue;
                            }
                        }
                    }

                    if (input == 'n' && current_page >= max_page)
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine($"Have not next page");
                        Console.Write("> ");
                        continue;
                    }

                    if (input == 'p' && current_page <= 1)
                    {
                        Console.WriteLine("Input error!");
                        Console.WriteLine($"Have not prev page");
                        Console.Write("> ");
                        continue;
                    }

                    break;
                }

                if (input >= '0' && input <= '9')
                {
                    int index = (input - '0') + (current_page - 1) * records_on_page;
                    logic.AddAward(user_id, index);
                    break;
                }

                switch (input)
                {
                    case 'n':
                        current_page++;
                        break;
                    case 'p':
                        current_page--;
                        break;
                    case 'e': return;
                }
            }
        }

        private void AddNewAward(int user_id)
        {
            Console.Clear();
            Console.WriteLine("Enter new award title");
            Console.Write("> ");
            string title = Console.ReadLine();
            

            Console.WriteLine($"Add award with title \"{title}\"?");
            Console.WriteLine("1) Yes");
            Console.WriteLine("2) No");
            Console.Write("> ");

            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input)
                && (input < 1 || input > 2))
            {
                Console.WriteLine("Input error!");
                Console.WriteLine("Enter 1 or 2.");
                Console.Write("> ");
            }

            switch (input)
            {
                case 1:
                    logic.AddAward(user_id, title);
                    break;
                case 2:                    
                    break;
            }
        }
    }
}
