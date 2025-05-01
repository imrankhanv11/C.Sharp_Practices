using System;
using System.Collections.Generic;

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
            Console.WriteLine("\n--- Supermarket Menu ---");
            Console.WriteLine("1. Buy Grocery Items (Customer)");
            Console.WriteLine("2. Admin Panel");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choiceInput = Console.ReadLine();

            switch (choiceInput)
            {
                case "1":
                    CustomerSection();
                    break;

                case "2":
                    Console.WriteLine("\n--- Admin Panel ---");
                    if (VerifyOwner())
                    Console.WriteLine("1. Add item");
                    Console.WriteLine("2. Remove item");
                    Console.WriteLine("3. Exit");
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
                    return false; // or break; depending on where this is used
                }
            }
        }
    }

    private void AddItem()
    {
        Console.Write("Enter new item code: ");
        if (int.TryParse(Console.ReadLine(), out int code))
        {
            if (items.ContainsKey(code))
            {
                Console.WriteLine("Item code already exists.");
                return;
            }

            Console.Write("Enter item name: ");
            string name = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out double price))
            {
                items[code] = new Item(code, name, price);
                Console.WriteLine($"{name} added successfully with code {code} and price ${price:F2}.");
            }
            else
            {
                Console.WriteLine("Invalid price input.");
            }
        }
        else
        {
            Console.WriteLine("Invalid code input.");
        }
    }

    private void RemoveItem()
    {
        Console.Write("Enter item code to remove: ");
        if (int.TryParse(Console.ReadLine(), out int code))
        {
            if (items.Remove(code))
            {
                Console.WriteLine($"Item with code {code} removed successfully.");
            }
            else
            {
                Console.WriteLine("Item code not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid code input.");
        }
    }

    private void CustomerSection()
    {
        Dictionary<int, int> userPurchases = new Dictionary<int, int>();

        Console.WriteLine("\nAvailable Items:");
        foreach (var item in items.Values)
        {
            Console.WriteLine($"Code: {item.Code}, Name: {item.Name}, Price: ${item.Price}");
        }

        while (true)
        {
            Console.Write("\nEnter item code to purchase (or type 'exit' to finish): ");
            string inputCode = Console.ReadLine();

            if (inputCode.ToLower() == "exit")
                break;

            if (int.TryParse(inputCode, out int code) && items.ContainsKey(code))
            {
                Console.Write("Enter quantity: ");
                if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0)
                {
                    if (userPurchases.ContainsKey(code))
                        userPurchases[code] += quantity;
                    else
                        userPurchases[code] = quantity;

                    Console.WriteLine($"Added {quantity} {items[code].Name}(s) to your cart.");
                }
                else
                {
                    Console.WriteLine("Invalid quantity.");
                }
            }
            else
            {
                Console.WriteLine("Invalid item code.");
            }
        }

        Console.WriteLine("\n--- Final Bill ---");
        double totalBill = 0;
        foreach (var entry in userPurchases)
        {
            int code = entry.Key;
            int quantity = entry.Value;
            var product = items[code];
            double subtotal = product.Price * quantity;
            totalBill += subtotal;
            Console.WriteLine($"{product.Name} - Quantity: {quantity}, Total: ${subtotal:F2}");
        }

        Console.WriteLine("\nTotal Amount: $" + totalBill.ToString("F2"));
        Console.WriteLine("Thank you for shopping with us.");
    }
}
