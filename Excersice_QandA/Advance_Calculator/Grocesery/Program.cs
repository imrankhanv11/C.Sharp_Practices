using System;
using System.Collections.Generic;
using Grocesery;

class GroceryBillCalculator
{
    class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total => Quantity * UnitPrice;
    }

    InputHandle input = new InputHandle();
    public void Main()
    {
        List<Item> items = new List<Item>();
        decimal grandTotal = 0m;

        Console.WriteLine("Welcome to Grocery Bill Calculator!");
        Console.WriteLine("-----------------------------------");

        while (true)
        {
            Console.Write("Do you want to add an item? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();

            if (response == "no")
            {
                break;
            }
            else if (response == "yes")
            {
                Console.Write("Item Name: ");
                string inputname = Console.ReadLine();
                string name = input.StringCheck(inputname);

                Console.Write("Quantity: ");
                string inputquantity = Console.ReadLine();
                int quantity = input.IntCheck(inputquantity);

                Console.Write("Unit Price: ");
                while (!decimal.TryParse(Console.ReadLine(), out unitPrice) || unitPrice <= 0)
                {
                    Console.Write("Invalid input. Enter a positive decimal for unit price: ");
                }

                Item newItem = new Item { Name = name, Quantity = quantity, UnitPrice = unitPrice };
                items.Add(newItem);

                grandTotal += newItem.Total; 

                Console.WriteLine(newItem.Name + " added successfully. Current Grand Total: " + grandTotal );
            }
            else
            {
                Console.WriteLine("Please type 'yes' or 'no'.");
            }
        }

        // Final Bill Display
        Console.WriteLine("FINAL GROCERY BILL");
        Console.WriteLine("-------------------------------------------");

        foreach (var item in items)
        {
            Console.WriteLine(item.Name + "  Quantity: " + item.Quantity +"," + "Unit Price:" +  item.UnitPrice+","+ " Total: " + item.Total);
        }

        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Grand Total: " + grandTotal);
    }
}