using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advance_GroceryApp_Oops
{

    //inheit form supermarket to access items
    class customer : Supermarket
    {
        private static int billNumber = 1001;

        public void CustomerSection()
        {
            //to storing user cart storing
            Dictionary<int, int> userPurchases = new Dictionary<int, int>();

            Console.WriteLine("\n+--------+----------------------+--------+");
            Console.WriteLine("| Code   | Name                 | Price  |");
            Console.WriteLine("+--------+----------------------+--------+");


            //showing the items list
            foreach (var item in items.Values)
            {
                Console.WriteLine($"| {item.Code,-6} | {item.Name,-20} | {item.Price,-6} |");
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

                //input handling
                try
                {
                    code = int.Parse(inputCode);
                    if (!items.ContainsKey(code))
                    {
                        Console.WriteLine("Invalid item code.");
                        Console.WriteLine();
                        goto EnterItemCode;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid numeric code.");
                    Console.WriteLine();
                    goto EnterItemCode;
                }

                var product = items[code];
                Console.WriteLine($"You selected: {product.Name} - ${product.Price}");

                //check if user already have the same item in cart
                if (userPurchases.ContainsKey(code))
                {
                    Console.WriteLine($"Already in cart with quantity {userPurchases[code]}.");
                    Console.Write("Add more? (yes/no): ");
                    string response = Console.ReadLine().ToLower();
                    Console.WriteLine();

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
                                Console.WriteLine();
                                goto EnterAdditionalQuantity;
                            }

                            userPurchases[code] += additionalQuantity;
                            Console.WriteLine($"Added {additionalQuantity} more {product.Name}(s).");
                        }
                        catch
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.WriteLine();
                            goto EnterAdditionalQuantity;
                        }
                    }
                }
                //new item add in cart
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
                        Console.WriteLine();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.WriteLine();
                        goto EnterQuantity;
                    }
                }
            }

            Console.WriteLine("Your Cart to purchase :");
            //showing cart detials
            foreach (var item in userPurchases)
            {
                int temp = item.Key;
                var product = items[temp];
                Console.WriteLine($"Code : {item.Key}, Item :{product.Name}, Quantity : {item.Value}");
            }
            Console.WriteLine();
            Console.Write("Do you want to update quantity or remove any Item before bill (yes/no): ");
            string finalcheck = Console.ReadLine();
            Console.WriteLine();

            //final check before bill to update
            while (true)
            {
                if (string.IsNullOrWhiteSpace(finalcheck))
                {
                    Console.WriteLine("Input cannot be empty or just spaces. Try again.");
                    Console.Write("Do you want to update quantity or remove any Item before bill (yes/no): ");
                    finalcheck = Console.ReadLine();
                    Console.WriteLine();
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
                        Console.WriteLine();

                        while (true)
                        {
                            if (string.IsNullOrWhiteSpace(finalcheck2))
                            {
                                Console.WriteLine("Input cannot be empty or just spaces. Try again.");
                                Console.Write("Update quantity - Q or Remove item - R or Proceed to bill - P: ");
                                finalcheck2 = Console.ReadLine();
                                Console.WriteLine();
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
                                    Console.WriteLine();
                                    goto EnterCode;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid item code.");
                                Console.WriteLine();
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

            //billing
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

            //final bill
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
}
