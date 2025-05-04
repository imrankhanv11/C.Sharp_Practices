using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Supermarket market = new Supermarket();
        market.ShowMenu();
    }
}

class Item
{
    public int Code { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Item(int code, string name, double price)
    {
        Code = code;
        Name = name;
        Price = price;
    }
}

class Supermarket
{
    private Dictionary<int, Item> items = new Dictionary<int, Item>();
    private const string ownerPassword = "admin123";

    public Supermarket()
    {
        // Default items
        items[101] = new Item(101, "Apple", 1.5);
        items[102] = new Item(102, "Banana", 0.7);
        items[103] = new Item(103, "Carrot", 1.2);
    }

    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n+----------------------------+");
            Console.WriteLine("|     Supermarket Menu       |");
            Console.WriteLine("+----------------------------+");
            Console.WriteLine("| 1 | Buy Grocery Items      |");
            Console.WriteLine("|   | (Customer)             |");
            Console.WriteLine("| 2 | Admin Panel            |");
            Console.WriteLine("| 3 | Exit                   |");
            Console.WriteLine("+----------------------------+");
            Console.Write("Enter your choice: ");

            string choiceInput = Console.ReadLine();

            switch (choiceInput)
            {
                case "1":
                    CustomerSection();
                    if (check())
                    {
                        return;
                    }
                    break;
                case "2":
                    if (VerifyOwner())
                    Console.WriteLine("\n+-----------------------+");
                    Console.WriteLine("|     Admin Panel       |");
                    Console.WriteLine("+-----------------------+");
                    Console.WriteLine("| 1 | Add item          |");
                    Console.WriteLine("| 2 | Remove item       |");
                    Console.WriteLine("| 3 | Exit              |");
                    Console.WriteLine("+-----------------------+");
                    Console.Write("Enter your choice: ");

                    string admininput = Console.ReadLine();

                    switch (admininput)
                    {
                        case "1":
                            AddItem();
                            break;
                        case "2":
                            RemoveItem();
                            break;
                        case "3":
                            Console.WriteLine("Thank you");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
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

    private bool VerifyOwner()
    {
        while (true)
        {
            Console.Write("Enter owner password: ");
            string password = Console.ReadLine();
            if (password == ownerPassword)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect password.");
                Console.Write("Do you want to retry password (yes / no): ");
                string pass = Console.ReadLine().Trim().ToLower();
                if (pass != "yes")
                {
                    return false; 
                }
            }
        }
    }

    private void AddItem()
    {
        int code;
        while (true)
        {
            Console.Write("Enter new item code: ");
            if (int.TryParse(Console.ReadLine(), out code))
            {
                if (items.ContainsKey(code))
                {
                    Console.WriteLine("Item code already exists.");
                    return;
                }
                break; 
            }
            else
            {
                Console.WriteLine("Invalid code input. Please enter a valid number.");
            }
        }

        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        double price;
        while (true)
        {
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out price))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Invalid price input. Please enter a valid number.");
            }
        }
        items[code] = new Item(code, name, price);
        Console.WriteLine($"{name} added successfully with code {code} and price ${price:F2}.");
    }
    private void RemoveItem()
    {
        while (true)
        {
            Console.Write("Enter item code to remove: ");
            if (int.TryParse(Console.ReadLine(), out int code))
            {
                if (items.Remove(code))
                {
                    Console.WriteLine($"Item with code {code} removed successfully.");
                    break; 
                }
                else
                {
                    Console.Write("Item code not found. Try again? (Y/N): ");
                    string choice = Console.ReadLine().Trim().ToUpper();
                    if (choice != "Y")
                    {
                        Console.WriteLine("Exiting removal process.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid code input. Please enter a valid number.");
            }
        }
    }


    public bool check()
    {
        Console.Write("Do you want to continue (yes/no) : ");
        string input = Console.ReadLine().Trim().ToLower();
        if(input == "yes")
        {
            return false;
        }
        return true;
    }

    private int billNumber = 1001; 

    private void CustomerSection()
    {
        Dictionary<int, int> userPurchases = new Dictionary<int, int>();

        Console.WriteLine("\n+--------+----------------------+--------+");
        Console.WriteLine("| Code   | Name                 | Price  |");
        Console.WriteLine("+--------+----------------------+--------+");

        foreach (var item in items.Values)
        {
            Console.WriteLine($"| {item.Code,-5} | {item.Name,-20} | ${item.Price,-6} |");
        }

        Console.WriteLine("+--------+----------------------+--------+");

        while (true)
        {
            Console.Write("\nEnter item code to purchase (or type 'exit' to finish): ");
            string inputCode = Console.ReadLine();

            if (inputCode.ToLower() == "exit")
                break;

            if (int.TryParse(inputCode, out int code) && items.ContainsKey(code))
            {
                var product = items[code];

                Console.WriteLine($"You selected: {product.Name} - ${product.Price}");

                if (userPurchases.ContainsKey(code))
                {
                    Console.WriteLine($"This item is already in your cart with quantity {userPurchases[code]}.");
                    Console.Write("Do you want to add more? (yes/no): ");
                    string response = Console.ReadLine().ToLower();

                    if (response == "yes")
                    {
                        int quantity;
                        while (true)
                        {
                            Console.Write("Enter additional quantity: ");
                            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                            {
                                userPurchases[code] += quantity;
                                Console.WriteLine($"Added {quantity} more {product.Name}(s) to your cart.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Skipping addition of this item.");
                    }
                }
                else
                {
                    int quantity;
                    while (true)
                    {
                        Console.Write("Enter quantity: ");
                        if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                        {
                            userPurchases[code] = quantity;
                            Console.WriteLine($"Added {quantity} {product.Name}(s) to your cart.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid quantity. Please enter a positive number.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid item code.");
            }
        }



        Console.Write("\nEnter your name: ");
        string customerName = Console.ReadLine();

        string mobileNumber;
        while (true)
        {
            Console.Write("Enter your 10-digit mobile number: ");
            mobileNumber = Console.ReadLine();
            if (Regex.IsMatch(mobileNumber, @"^\d{10}$"))
                break;
            Console.WriteLine("Invalid mobile number. Please enter exactly 10 digits.");
        }

        Console.WriteLine("----------------- Final Bill -----------------");
        Console.WriteLine($" Bill Number         :         {billNumber++}");
        Console.WriteLine($" Customer Name       :         {customerName}");
        Console.WriteLine($" Mobile Number       :         {mobileNumber}");
        Console.WriteLine("+----------------------+----------+----------+");
        Console.WriteLine("| Item Name            | Quantity | Subtotal |");
        Console.WriteLine("+----------------------+----------+----------+");

        double totalBill = 0;
        foreach (var entry in userPurchases)
        {
            int code = entry.Key;
            int quantity = entry.Value;
            var product = items[code];
            double subtotal = product.Price * quantity;
            totalBill += subtotal;
            Console.WriteLine($"| {product.Name,-20} | {quantity,8} | {subtotal,8:F2} |");
        }

        Console.WriteLine("+----------------------+----------+----------+");
        Console.WriteLine($"| {"Total",-20} | {"",8} | {totalBill,8:F2} |");
        Console.WriteLine("+----------------------+----------+----------+");
        Console.WriteLine("       Thank you for shopping with us.        ");
        Console.WriteLine("----------------------------------------------");
    }
}

