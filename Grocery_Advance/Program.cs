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
            string inputCode;
            int code;

        EnterItemCode:
            Console.Write("\nEnter item code to purchase (or type 'exit' to finish): ");
            inputCode = Console.ReadLine();

            if (inputCode.ToLower().Trim() == "exit")
                break;

            try
            {
                code = int.Parse(inputCode);
                if (!items.ContainsKey(code))
                {
                    Console.WriteLine("Invalid item code.");
                    goto EnterItemCode;
                }
            }
            catch
            {
                Console.WriteLine("Please enter a valid numeric code.");
                goto EnterItemCode;
            }

            var product = items[code];
            Console.WriteLine($"You selected: {product.Name} - ${product.Price}");

            if (userPurchases.ContainsKey(code))
            {
                Console.WriteLine($"Already in cart with quantity {userPurchases[code]}.");
                Console.Write("Add more? (yes/no): ");
                string response = Console.ReadLine().ToLower();

                if (response == "yes")
                {
                    int additionalQuantity;

                EnterAdditionalQuantity:
                    try
                    {
                        Console.Write("Enter additional quantity: ");
                        additionalQuantity = int.Parse(Console.ReadLine());
                        if (additionalQuantity <= 0)
                        {
                            Console.WriteLine("Quantity must be positive.");
                            goto EnterAdditionalQuantity;
                        }

                        userPurchases[code] += additionalQuantity;
                        Console.WriteLine($"Added {additionalQuantity} more {product.Name}(s).");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        goto EnterAdditionalQuantity;
                    }
                }
            }
            else
            {
                int quantity;

            EnterQuantity:
                try
                {
                    Console.Write("Enter quantity: ");
                    quantity = int.Parse(Console.ReadLine());
                    if (quantity <= 0)
                    {
                        Console.WriteLine("Quantity must be positive.");
                        goto EnterQuantity;
                    }

                    userPurchases[code] = quantity;
                    Console.WriteLine($"Added {quantity} {product.Name}(s) to your cart.");
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    goto EnterQuantity;
                }
            }
        }

        Console.WriteLine("Your Cart to purchase :");
        foreach(var item in userPurchases)
        {
            int temp = item.Key;
            var product = items[temp];
            Console.WriteLine($"Code : {item.Key}, Item :{product.Name}, Quantity : {item.Value}");
        }
        Console.Write("Do you want to update quantity or remove any Item before bill (yes/no): ");
        string finalcheck = Console.ReadLine();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(finalcheck))
            {
                Console.WriteLine("Input cannot be empty or just spaces. Try again.");
                Console.Write("Do you want to update quantity or remove any Item before bill (yes/no): ");
                finalcheck = Console.ReadLine();
            }
            else
            {
                finalcheck = finalcheck.Trim().ToLower();
                break;
            }
        }
        
        if (finalcheck == "yes")
        {
            
            string second;
            do
            {
                while (true)
                {
                    Console.Write("Update quantity - Q or Remove item - R or Proceed to bill - P: ");
                    string finalcheck2 = Console.ReadLine();

                    while (true)
                    {
                        if (string.IsNullOrWhiteSpace(finalcheck2))
                        {
                            Console.WriteLine("Input cannot be empty or just spaces. Try again.");
                            Console.Write("Update quantity - Q or Remove item - R or Proceed to bill - P: ");
                            finalcheck2 = Console.ReadLine();
                        }
                        else
                        {
                            finalcheck2 = finalcheck2.Trim().ToUpper();
                            break;
                        }
                    }

                    if (finalcheck2 == "R")
                    {
                    EnterCode:
                        Console.Write("Enter the item code to remove or 0 for proceed bill : ");
                        if (int.TryParse(Console.ReadLine(), out int codeToRemove))
                        {
                            if (codeToRemove == 0)
                            {
                                Console.WriteLine("Proceeding to bill...");
                                break;
                            }
                            if (userPurchases.ContainsKey(codeToRemove))
                            {
                                userPurchases.Remove(codeToRemove);
                                Console.WriteLine("Item removed from your purchase list.");
                            }
                            else
                            {
                                Console.WriteLine("Item not found in your purchase list.");
                                goto EnterCode;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid item code.");
                            goto EnterCode;
                        }
                        break;
                    }
                    else if (finalcheck2 == "Q")
                    {
                    EnterQuantity:
                        Console.Write("Enter the item code to update quantity or 0 for proceed bill: ");
                        if (int.TryParse(Console.ReadLine(), out int codeToUpdate))
                        {
                            if (codeToUpdate == 0)
                            {
                                Console.WriteLine("Proceeding to bill...");
                                break;
                            }
                            if (userPurchases.ContainsKey(codeToUpdate))
                            {
                                Console.Write("Enter the new quantity: ");
                                if (int.TryParse(Console.ReadLine(), out int newQty) && newQty > 0)
                                {
                                    userPurchases[codeToUpdate] = newQty;
                                    Console.WriteLine("Quantity updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Item not found in your purchase list.");
                                goto EnterQuantity;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid item code.");
                            goto EnterQuantity;
                        }
                        break;
                    }
                    else if (finalcheck2 == "P")
                    {
                        Console.WriteLine("Proceeding to bill...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid option. Try again.");
                    }
                }
                Console.Write("Do you want to update again (yes/no) : ");
                second = Console.ReadLine().Trim().ToLower();
            } while (second == "yes");
        }
        else
        {
            Console.WriteLine("Proceeding to bill...");
        }

        

        string customerName;
    EnterName:
        try
        {
            Console.Write("\nEnter your name: ");
            customerName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                Console.WriteLine("Name cannot be empty.");
                goto EnterName;
            }
        }
        catch
        {
            Console.WriteLine("Invalid name.");
            goto EnterName;
        }

        string mobileNumber;
    EnterMobile:
        try
        {
            Console.Write("Enter your 10-digit mobile number: ");
            mobileNumber = Console.ReadLine();
            if (!Regex.IsMatch(mobileNumber, @"^\d{10}$"))
            {
                Console.WriteLine("Invalid mobile number.");
                goto EnterMobile;
            }
        }
        catch
        {
            Console.WriteLine("Invalid input.");
            goto EnterMobile;
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
            int itemCode = entry.Key;
            int quantity = entry.Value;
            var product = items[itemCode];
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
        catch(FormatException e)
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
