using System;
using System.Collections.Generic;
using System.Linq;

namespace Advance_MultiUserExpeseTraker_Oops
{
    class Program
    {
        static void Main(string[] args)
        {
            //object creation for expensesmager to perform Operations
            ExpenseManager manager = new ExpenseManager();

            while (true)
            {
                //main menu
                Console.WriteLine("------------ Expense Tracker ----------");
                Console.WriteLine("| Option |           Action           |");
                Console.WriteLine("|--------|----------------------------|");
                Console.WriteLine("|   1    | Register New User          |");
                Console.WriteLine("|   2    | Login and Manage Expenses  |");
                Console.WriteLine("|   3    | Exit                       |");
                Console.WriteLine("---------------------------------------");

                Console.Write("Enter your choice: ");

                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        manager.RegisterUser();
                        break;

                    case "2":
                        manager.LoginAndManage();
                        break;

                    case "3":
                        Console.WriteLine("Thank you!");
                        return;

                    default:
                        Console.WriteLine("Invalid input, try again.");
                        break;
                }
            }
        }
    }
}
