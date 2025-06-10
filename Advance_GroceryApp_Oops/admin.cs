using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_GroceryApp_Oops
{
    //admin class inherit form supermarket for acces the protected items
    class admin : Supermarket
    {
        //only acces within the class
        private const string ownerPassword = "admin123";


        //verifing owner
        public bool VerifyOwner()
        {
            while (true)
            {
                Console.Write("Enter owner password: ");
                string password = Console.ReadLine();
                if (password == ownerPassword)
                    return true;

                Console.WriteLine("Incorrect password.");
                Console.Write("Retry? (yes/no): ");
                if (Console.ReadLine().Trim().ToLower() != "yes")
                    return false;
            }
        }

        //adding items
        public void AddItem()
        {
            int code;
        EnterCode:
            try
            {
                Console.Write("Enter the New Item Code : ");
                code = int.Parse(Console.ReadLine());
                if (items.ContainsKey(code))
                {
                    Console.WriteLine("Item code already exists.");
                    goto EnterCode;
                }

            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid type try again");
                goto EnterCode;
            }

            string name;
        EnterName:
            try
            {
                Console.Write("Enter item name: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                    throw new Exception();
            }
            catch
            {
                Console.WriteLine("Invalid input.");
                goto EnterName;
            }
            double price;
            while (true)
            {
                try
                {
                    Console.Write("Enter item price: ");
                    price = Double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid price.");
                }
            }

            items[code] = new Item(code, name, price);
            Console.WriteLine($"Item '{name}' added with code {code} and price ${price:F2}.");
        }


        //remove items
        public void RemoveItem()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter item code to remove: ");
                    int code = Convert.ToInt32(Console.ReadLine());

                    if (items.ContainsKey(code))
                    {
                        string name = items[code].Name;
                        items.Remove(code);
                        Console.WriteLine($"Item '{name}' with code {code} removed successfully.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric item code.");
                }
            }
        }


        //view items 
        public void ViewItem()
        {
            Console.WriteLine("\n+--------+----------------------+--------+");
            Console.WriteLine("| Code   | Name                 | Price  |");
            Console.WriteLine("+--------+----------------------+--------+");

            foreach (var item in items.Values)
            {
                Console.WriteLine($"| {item.Code,-5} | {item.Name,-20} | {item.Price,-6} |");
            }

            Console.WriteLine("+--------+----------------------+--------+");
        }

        //update the items details
        public void UpdateItem()
        {
            while (true)
            {
                try
                {
                    ViewItem();
                    Console.Write("Enter the item code to update: ");
                    int code = Convert.ToInt32(Console.ReadLine());

                    if (items.ContainsKey(code))
                    {
                        var value = items[code];
                        Console.Write("Enter the update to Name - N (or) Prize - P: ");
                        string temp = Console.ReadLine().Trim().ToUpper();

                        if (temp == "N")
                        {
                            Console.Write("Enter the new product name: ");
                            string new_name = Console.ReadLine();
                            value.Name = new_name;
                            Console.WriteLine("Product name changed successfully");
                            break;
                        }
                        else if (temp == "P")
                        {
                            Console.Write("Enter the new price for product: ");
                            int amount;
                            while (true)
                            {
                                try
                                {
                                    amount = Convert.ToInt32(Console.ReadLine());
                                    value.Price = amount;
                                    Console.WriteLine("Product price changed successfully");
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                                }
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Please choose either 'N' for Name or 'P' for Price.");
                        }
                    }
                    else
                    {
                        Console.Write("Item not found. Try again? (Y/N): ");
                        if (Console.ReadLine().Trim().ToUpper() != "Y")
                        {
                            Console.WriteLine("Exiting update process.");
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid item code.");

                }
            }
        }
    }
}
