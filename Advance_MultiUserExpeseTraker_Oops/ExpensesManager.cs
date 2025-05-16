using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_MultiUserExpeseTraker_Oops
{

    class ExpenseManager
    {

        InputHandle input = new InputHandle();

        //storing the user all details in one dictionary
        //int is userId automatic increment
        //uer contain one list, userid, username, password
        //list contains expensesname, amount, small discription
        private Dictionary<int, User> users = new Dictionary<int, User>();
        private int nextUserId = 1;


        //register for new user
        public void RegisterUser()
        {
        
            Console.Write("Enter your name: ");
            string inputname = Console.ReadLine();
            string name = input.StringCheck(inputname);
            Console.WriteLine();
            
            Console.WriteLine("Password should be in 4 digits number");
        enterpass:
            Console.Write("Create a password: ");
            string password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password Can't be null");
                goto enterpass;
            }
            try
            {
                int.Parse(password);
            }
            catch (FormatException)
            {
                Console.WriteLine("Password should be in number");
                goto enterpass;
            }

            int a = password.Length;
            if (a != 4)
            {
                Console.WriteLine("Password size should be 4");
                goto enterpass;
            }



            users[nextUserId] = new User(nextUserId, name, password);
            Console.WriteLine($"User registered! Your User ID is: {nextUserId}");
            nextUserId++;
        }

        //login for registed user
        public void LoginAndManage()
        {
        EnterId:
            Console.Write("Enter User ID: ");
            if (!int.TryParse(Console.ReadLine(), out int userId) || !users.ContainsKey(userId))
            {
                Console.WriteLine("Invalid User ID. If you don't have account Plase Create");
                Console.Write("If you want to continue (y/n) : ");
                string check = Console.ReadLine().Trim().ToLower();
                if (check != "y")
                {
                    return;
                }
                goto EnterId;
            }

        EnterPass:
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = users[userId];
            if (user.Password != password)
            {
                Console.WriteLine("Incorrect password.");
                goto EnterPass;
            }

            Console.WriteLine($"\nWelcome, {user.UserName}!");

            while (true)
            {
                //operaions after have account
                Console.WriteLine("----------- Expense Menu ----------");
                Console.WriteLine("| Option |         Action         |");
                Console.WriteLine("|--------|------------------------|");
                Console.WriteLine("|   1    | Add Expense            |");
                Console.WriteLine("|   2    | Show Expenses          |");
                Console.WriteLine("|   3    | Show Total             |");
                Console.WriteLine("|   4    | Show MIN/MAX           |");
                Console.WriteLine("|   5    | Remove Expenses        |");
                Console.WriteLine("|   6    | Logout                 |");
                Console.WriteLine("-----------------------------------");

                Console.Write("Enter your choice: ");
                string op = Console.ReadLine();

                switch (op)
                {
                    case "1":
                        AddExpense(user);
                        break;
                    case "2":
                        ShowExpenses(user);
                        break;
                    case "3":
                        int total = user.Expenses.Sum(e => e.Amount);
                        Console.WriteLine($"Total Expenses: {total}");
                        break;
                    case "4":
                        ShowMinMax(user);
                        break;
                    case "5":
                        RemoveExpense(user);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }


        //adding expenses
        private void AddExpense(User user)
        {
            //loop for asking again
            string match;
            do
            {
                Console.Write("Enter Expense Name: ");
                string inputname = Console.ReadLine();
                string name = input.StringCheck(inputname);

                Console.Write("Enter Amount: ");
                string inputamount = Console.ReadLine();
                int amount = input.IntCheck(inputamount);

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                user.Expenses.Add(new Expense(name, amount, description));
                Console.WriteLine("Expense added successfully!");

                Console.WriteLine("Do you want to add another expenses (yes/no)");
                match = Console.ReadLine().Trim().ToLower();
            } while (match == "yes");
        }


        //showing expenses
        private void ShowExpenses(User user)
        {
            //check if any expenses already have to show 
            if (!user.Expenses.Any())
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            Console.WriteLine("\n--- Your Expenses ---\n");

            // Header
            Console.WriteLine("+----------------------+------------+------------------------------------------+");
            Console.WriteLine("| Name                 | Amount     | Description                              |");
            Console.WriteLine("+----------------------+------------+------------------------------------------+");

            // Rows
            foreach (var e in user.Expenses)
            {
                Console.WriteLine($"| {e.ExpenseName,-20} | {e.Amount,10} | {e.Description,-40} |");
            }

            // Footer
            Console.WriteLine("+----------------------+------------+------------------------------------------+");

        }

        //show min and max
        private void ShowMinMax(User user)
        {
            if (user.Expenses.Count == 0)
            {
                Console.WriteLine("No expenses found.");
                return;
            }

            var max = user.Expenses.Max(e => e.Amount);
            var min = user.Expenses.Min(e => e.Amount);

            Console.WriteLine("\n--- Highest Expense(s) ---");
            foreach (var exp in user.Expenses.Where(e => e.Amount == max))
            {
                Console.WriteLine($"Name: {exp.ExpenseName}, Amount: {exp.Amount}, Description: {exp.Description}");
            }

            Console.WriteLine("\n--- Lowest Expense(s) ---");
            foreach (var exp in user.Expenses.Where(e => e.Amount == min))
            {
                Console.WriteLine($"Name: {exp.ExpenseName}, Amount: {exp.Amount}, Description: {exp.Description}");
            }
        }

        //remove expenses
        private void RemoveExpense(User user)
        {
            if (user.Expenses.Count == 0)
            {
                Console.WriteLine("No expenses to remove.");
                return;
            }

            Console.WriteLine("\n--- Your Expenses ---");
            for (int i = 0; i < user.Expenses.Count; i++)
            {
                var e = user.Expenses[i];
                Console.WriteLine($"ID: {i} | Name: {e.ExpenseName}, Amount: {e.Amount}, Description: {e.Description}");
            }

            Console.Write("Enter the ID of the expense to remove: ");
            int idToRemove;
            while (!int.TryParse(Console.ReadLine(), out idToRemove) || idToRemove < 0 || idToRemove >= user.Expenses.Count)
            {
                Console.Write("Invalid input. Enter a valid expense ID: ");
            }

            var removed = user.Expenses[idToRemove];
            user.Expenses.RemoveAt(idToRemove);
            Console.WriteLine($"Removed expense '{removed.ExpenseName}' of amount {removed.Amount}.");
        }
    }
}
