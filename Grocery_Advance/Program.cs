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
    protected static Dictionary<int, Item> items = new Dictionary<int, Item>();

    public Supermarket()
    {
        // Default items
        if (items.Count == 0)
        {
            items[101] = new Item(101, "Apple", 1.5);
            items[102] = new Item(102, "Banana", 0.7);
            items[103] = new Item(103, "Carrot", 1.2);
        }
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
            customer obj = new customer();

            switch (choiceInput)
            {
                case "1":
                    obj.CustomerSection();
                    if (check())
                        return;
                    break;

                case "2":
                    admin admin = new admin();
                    if (admin.VerifyOwner())
                    {
                        while (true)
                        {
                            Console.WriteLine("\n+-----------------------+");
                            Console.WriteLine("|     Admin Panel       |");
                            Console.WriteLine("+-----------------------+");
                            Console.WriteLine("| 1 | Add item          |");
                            Console.WriteLine("| 2 | Remove item       |");
                            Console.WriteLine("| 3 | View All          |");
                            Console.WriteLine("| 4 | Exit              |");
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

    public bool check()
    {
        Console.Write("Do you want to continue (yes/no) : ");
        string input = Console.ReadLine().Trim().ToLower();
        return input != "yes";
    }
}

class customer : Supermarket
{
    private static int billNumber = 1001;

    public void CustomerSection()
    {
        Dictionary<int, int> userPurchases = new Dictionary<int, int>();

        Console.WriteLine("\n+--------+----------------------+--------+");
        Console.WriteLine("| Code   | Name                 | Price  |");
        Console.WriteLine("+--------+----------------------+--------+");

        foreach (var item in items.Values)
        {
            Console.WriteLine($"| {item.Code,-5} | {item.Name,-20} | {item.Price,-6} |");
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
                    Console.WriteLine($"Already in cart with quantity {userPurchases[code]}.");
                    Console.Write("Add more? (yes/no): ");
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
                                Console.WriteLine($"Added {quantity} more {product.Name}(s).");
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
            Console.WriteLine("Invalid mobile number.");
        }

        Console.WriteLine("\n----------------- Final Bill -----------------");
        Console.WriteLine($" Bill Number         : {billNumber++}");
        Console.WriteLine($" Customer Name       : {customerName}");
        Console.WriteLine($" Mobile Number       : {mobileNumber}");
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

class admin : Supermarket
{
    private const string ownerPassword = "admin123";

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

    public void RemoveItem()
    {
        while (true)
        {
            Console.Write("Enter item code to remove: ");
            if (int.TryParse(Console.ReadLine(), out int code))
            {
                if (items.ContainsKey(code))
                {
                    string name = items[code].Name;
                    items.Remove(code);
                    Console.WriteLine($"Item '{name}' with code {code} removed successfully.");
                    break;
                }
                else
                {
                    Console.Write("Item not found. Try again? (Y/N): ");
                    if (Console.ReadLine().Trim().ToUpper() != "Y")
                    {
                        Console.WriteLine("Exiting removal process.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid item code.");
            }
        }
    }

    public void AddItem()
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
                Console.WriteLine("Invalid input.");
            }
        }

        Console.Write("Enter item name: ");
        string name = Console.ReadLine();

        double price;
        while (true)
        {
            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out price))
                break;

            Console.WriteLine("Invalid input.");
        }

        items[code] = new Item(code, name, price);
        Console.WriteLine($"Item '{name}' added with code {code} and price ${price:F2}.");
    }

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
}
