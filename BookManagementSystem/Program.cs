using System;

namespace BookManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputGetter input = new InputGetter();//access input getter
            InputChecker checker = new InputChecker();//input checker

            IAdminManagement admin = new AdminRepository();//access admin repository

        Repeat:
            while (true)
            {
                Console.WriteLine("+------------------------------------------+");
                Console.WriteLine("|       Welcome to Book Management System  |");
                Console.WriteLine("+------------------------------------------+");
                Console.WriteLine("| Select your role:                        |");
                Console.WriteLine("| 1. Admin                                 |");
                Console.WriteLine("| 2. User                                  |");
                Console.WriteLine("| 3. Exit                                  |");
                Console.WriteLine("+------------------------------------------+");

                Console.Write("Enter choice: ");
                string role = Console.ReadLine();
                bool isAdmin = false;
                bool isUser = false;

                switch (role)
                {
                    case "1": // Admin
                        while (true)
                        {
                            isAdmin = input.Adminlogin();

                            if (isAdmin)
                            {
                                Console.WriteLine("Logged in as Admin");
                                goto AdminPanel;
                            }
                            else
                            {
                                Console.WriteLine("Invalid admin credentials. Please try again.");
                            }
                        }

                    case "2": // User
                        while (true)
                        {
                            Console.WriteLine("+------------------------------------------+");
                            Console.WriteLine("| Select your Option :                     |");
                            Console.WriteLine("| 1. Login                                 |");
                            Console.WriteLine("| 2. Register                              |");
                            Console.WriteLine("+------------------------------------------+");

                            Console.Write("Enter the Option code: ");
                            string userOption = Console.ReadLine();

                            switch (userOption)
                            {
                                case "1":

                                    isUser = input.UserLoginpage();

                                    if (isUser)
                                    {
                                        Console.WriteLine("User login successful.");
                                        goto UserPanel; // Enter user panel
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid credentials. Please try again.");
                                    }
                                    break;

                                case "2":
                                    Console.WriteLine("User registration selected.");
                                    // You need to implement actual registration logic here.
                                    input.UserRegister();
                                    // Don't break loop, return to login/register options
                                    break;

                                default:
                                    Console.WriteLine("Invalid option. Try again.");
                                    break;
                            }
                        }

                    case "3":
                        Console.WriteLine("Exiting system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid role selected. Please choose 1, 2, or 3.");
                        break;
                }
            }

        AdminPanel:
            while (true)
            {
                Console.WriteLine("\n+----------- Admin Operations -----------+");
                Console.WriteLine("| 1. Add new Book                        |");
                Console.WriteLine("| 2. Delete Book                         |");
                Console.WriteLine("| 3. Update Book Details                 |");
                Console.WriteLine("| 4. Search Book                         |");
                Console.WriteLine("| 5. Display All Books                   |");
                Console.WriteLine("| 6. Display Books by Category           |");
                Console.WriteLine("| 7. Show Users List                     |");
                Console.WriteLine("| 8. Exit                                |");
                Console.WriteLine("+----------------------------------------+");
                Console.Write("Enter operation code: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        input.AddBook();
                        break;
                    case "2":
                        input.RemoveBook();
                        break;
                    case "3":
                        input.UpdateBook();
                        break;
                    case "4":
                        input.SearchBook();
                        break;
                    case "5":
                        input.Display();
                        break;
                    case "6":
                        input.DisplayCetegery();
                        break;
                    case "7":
                        input.ShowUserList();
                        break;
                    case "8":
                        Console.WriteLine("Thank you!");
                        goto Repeat;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }

        UserPanel:
            while (true)
            {
                Console.WriteLine("\n+----------- User Operations -----------+");
                Console.WriteLine("| 1. Search Book                        |");
                Console.WriteLine("| 2. Display All Books                  |");
                Console.WriteLine("| 3. Display Books by Category          |");
                Console.WriteLine("| 4. Delete your Account                |");
                Console.WriteLine("| 5. Add Book to Favorites              |");
                Console.WriteLine("| 6. View Favorites                     |");
                Console.WriteLine("| 7. Remove Favorites                   |");
                Console.WriteLine("| 8. Exit                               |");
                Console.WriteLine("+---------------------------------------+");
                Console.Write("Enter operation code: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        input.SearchBook();
                        break;
                    case "2":
                        input.Display();
                        break;
                    case "3":
                        input.DisplayCetegery();
                        break;
                    case "4":
                        input.UserDeleteAccount();
                        goto Repeat;
                    case "5":
                        input.AddFavorites();
                        break;
                    case "6":
                        input.ViewFavorites();
                        break;
                    case "7":
                        input.RemoveFavorites();
                        break;
                    case "8":
                        Console.WriteLine("Thank you!");
                        goto Repeat;
                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;
                }
            }
        }
    }
}
