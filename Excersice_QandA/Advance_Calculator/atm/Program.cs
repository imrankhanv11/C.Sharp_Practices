using System;

class ATM
{
    static void Main()
    {
        double balance = 5000.00; 
        int choice;

        // Loop for the ATM menu
        do
        {
            Console.WriteLine("\nATM Menu:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Please choose an option (1-4): ");

            // Input from the user
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Check Balance
                    Console.WriteLine("Your current balance is: " + balance);
                    break;

                case 2:
                    // Deposit
                    Console.Write("Enter the amount to deposit: ");
                    string inputdeposit = Console.ReadLine();
                    double depositAmount = DoubleCheck(inputdeposit);

                    // If-else to validate deposit amount
                    if (depositAmount > 0)
                    {
                        balance += depositAmount;
                        Console.WriteLine("Successfully deposited: " + depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid deposit amount.");
                    }
                    break;

                case 3:
                    // Withdraw
                    Console.Write("Enter the amount to withdraw: ");
                    string inputwithdraw = Console.ReadLine();
                    double withdrawAmount = DoubleCheck(inputwithdraw);

                    if (withdrawAmount > 0 && withdrawAmount <= balance)
                    {
                        balance -= withdrawAmount;
                        Console.WriteLine("Successfully withdrew: " + withdrawAmount);
                    }
                    else if (withdrawAmount <= 0)
                    {
                        Console.WriteLine("Invalid withdrawal amount.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance. Withdrawal denied.");
                    }
                    break;

                case 4:
                    // Exit
                    Console.WriteLine("Thank you for using the ATM. Goodbye!");
                    break;

                default:
                    // Invalid option
                    Console.WriteLine("Invalid choice. Please select a valid option (1-4).");
                    break;
            }
        }
        while (choice != 4); 
    }
    public static double DoubleCheck(string input)
    {
        double value;

        while (true)
        {
            try
            {
                value = Convert.ToDouble(input);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric salary:");
                input = Console.ReadLine();
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number entered is too large or too small. Try again:");
                input = Console.ReadLine();
            }
        }

        return value;
    }
}