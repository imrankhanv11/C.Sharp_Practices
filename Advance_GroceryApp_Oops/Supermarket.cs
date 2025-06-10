using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_GroceryApp_Oops
{
    class Supermarket
    {
        //main dictionary only acces by admin using inherit
        protected static Dictionary<int, Item> items = new Dictionary<int, Item>();

        public Supermarket()
        {
            // Default items
            if (items.Count == 0)
            {
                //default values
                items[101] = new Item(101, "Apple", 1.5);
                items[102] = new Item(102, "Banana", 0.7);
                items[103] = new Item(103, "Carrot", 1.2);
                items[104] = new Item(104, "Orange", 1.5);
                items[105] = new Item(105, "Jack", 2.5);
                items[106] = new Item(106, "Water Melon", 1.2);
            }
        }

        public void ShowMenu()
        {
            while (true)
            {
                //main menu
                Console.WriteLine("\n+----------------------------+");
                Console.WriteLine("|     -Supermarket Menu-     |");
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("| 1 | Buy Grocery Items      |");
                Console.WriteLine("|   | (Customer)             |");
                Console.WriteLine("| 2 | Admin Panel            |");
                Console.WriteLine("| 3 | Exit                   |");
                Console.WriteLine("+----------------------------+");
                Console.Write("Enter your choice: ");

                string choiceInput = Console.ReadLine();

                //object creation for customer class to access customer operations
                customer obj = new customer();

                switch (choiceInput)
                {
                    case "1":
                        obj.CustomerSection();
                        if (check())
                            return;
                        break;

                    case "2":
                        //object creation for admin operations
                        admin admin = new admin();
                        //verifiying with password
                        if (admin.VerifyOwner())
                        {
                            while (true)
                            {
                                //admin menu
                                Console.WriteLine("\n+-----------------------+");
                                Console.WriteLine("|     Admin Panel       |");
                                Console.WriteLine("+-----------------------+");
                                Console.WriteLine("| 1 | Add item          |");
                                Console.WriteLine("| 2 | Remove item       |");
                                Console.WriteLine("| 3 | View All          |");
                                Console.WriteLine("| 4 | Update            |");
                                Console.WriteLine("| 5 | Exit              |");
                                Console.WriteLine("+-----------------------+");
                                Console.Write("Enter your choice: ");

                                string admininput = Console.ReadLine();

                                switch (admininput)
                                {
                                    case "1":
                                        admin.AddItem();
                                        break;
                                    case "2":
                                        admin.RemoveItem();
                                        break;
                                    case "3":
                                        admin.ViewItem();
                                        break;
                                    case "4":
                                        admin.UpdateItem();
                                        break;
                                    case "5":
                                        Console.WriteLine("Exiting Admin Panel.");
                                        goto EndAdminLoop;
                                    default:
                                        Console.WriteLine("Invalid choice. Please try again.");
                                        break;
                                }
                            }
                        EndAdminLoop:;
                        }
                        break;

                    case "3":
                        Console.WriteLine("Thank you! Visit again.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        //check if want to continue or not in multiple areas
        public bool check()
        {
            Console.Write("Do you want to continue (yes/no) : ");
            string input = Console.ReadLine().Trim().ToLower();
            return input != "yes";
        }
    }
}
