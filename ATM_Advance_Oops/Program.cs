using System;
using System.Collections.Generic;

namespace Advance_ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Create obj = new Create();

            Console.WriteLine("<-------- Welcome to the Console Bank --------->");
            while (true)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("|         Welcome to the Bank System          |");
                Console.WriteLine("===============================================");
                Console.WriteLine("| Option |           Operation                |");
                Console.WriteLine("===============================================");
                Console.WriteLine("|   1    | Create New Account                 |");
                Console.WriteLine("|   2    | Check Balance                      |");
                Console.WriteLine("|   3    | Deposit Money                      |");
                Console.WriteLine("|   4    | Withdraw Money                     |");
                Console.WriteLine("|   5    | Transfer                           |");
                Console.WriteLine("|   6    | Delete you Account                 |");
                Console.WriteLine("|   7    | Pin Change                         |");
                Console.WriteLine("|   8    | Exit                               |");
                Console.WriteLine("===============================================");
                Console.Write("Enter your choice (1-5): ");


                int Maininput;
                while (true)
                {
                    try
                    {
                        Maininput = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Please enter a valid operation: ");
                    }
                }

                switch (Maininput)
                {
                    case 1:
                        obj.Create_Acc();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 2:
                        obj.check_Balance();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 3:
                        obj.Deposit();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 4:
                        obj.Withraw();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 5:
                        obj.Transfer();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 6:
                        obj.Delete();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 7:
                        obj.Pin_change();
                        if (obj.Out())
                        {
                            Console.WriteLine("Thank You");
                            return;
                        }
                        break;
                    case 8:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }

    class Account
    {
        public string Acc_Num { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        protected string Pin { get; set; }
        protected double Balance { get; set; }

        public Account(string num, string name, string email, string pin, double balance)
        {
            Acc_Num = num;
            Name = name;
            Email = email;
            Pin = pin;
            Balance = balance;
        }

        public bool ValidatePin(string pin)
        {
            return this.Pin == pin;
        }

        public double GetBalance()
        {
            return Balance;
        }

        public void AddAmount(double amount)
        {
            Balance += amount;
        }
        public void WithrawAmount(double amount)
        {
            Balance -= amount;
        }
        public void PinChange(string new_pin)
        {
            this.Pin = new_pin;
        }
    }

    class Create : Account
    {
        private Dictionary<string, Account> Details = new Dictionary<string, Account>
        {
            {"ACC1000", new Account("ACC1000", "Imran", "ex01@gmail.com", "1234", 500)},
            {"ACC1001", new Account("ACC1001", "Santhosh", "ex02@gmail.com", "5678", 500)},
            {"ACC1002", new Account("ACC1002", "Felix", "ex03@gmail.com","9101", 500)},
        };

        private static int Acc_Counter = 1003;

        public Create() : base("", "", ""," ", 0) { }

        public bool Out()
        {
            Console.Write("Do you want to continue with other Operations? (yes/no): ");
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "yes")
            {
                return false;
            }
            return true;
        }
        public bool acc_out()
        {
            Console.Write("Do you want to try agian Account number ? (yes/no): ");
            string confirm = Console.ReadLine().ToLower();
            if (confirm == "yes")
            {
                return true;
            }
            return false;
        }
        public void Create_Acc()
        {
            string acc_num = "ACC" + Acc_Counter++;
            Console.Write("Enter the Account Holder Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter the email id :");
            string email = Console.ReadLine();

            string pin;
            do
            {
                Console.Write("Set a 4-digit PIN: ");
                pin = Console.ReadLine();
            } while (pin.Length != 4 || !int.TryParse(pin, out _));

            double balance;
            Console.Write("Enter Initial Balance: ");
            while (!double.TryParse(Console.ReadLine(), out balance) || balance < 0)
            {
                Console.Write("Invalid amount. Enter a positive number: ");
            }


            Details.Add(acc_num, new Account(acc_num, name, email, pin, balance));

            Console.WriteLine("=============================================");
            Console.WriteLine("=====Your Account was Succesfully Created====");
            Console.WriteLine($"    Account Number      : {acc_num}");
            Console.WriteLine($"    Account Holder Name : {name}");
            Console.WriteLine($"    Account Email       : {email}");
            Console.WriteLine($"    Account Balance     : {balance}");
            Console.WriteLine("=============================================");

        }

        public void check_Balance()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {
                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");
                    while (true)
                    {
                        Console.Write("Enter your 4-digit PIN: ");
                        string pin = Console.ReadLine();

                        if (user.ValidatePin(pin))
                        {
                            Console.WriteLine("=============================================");
                            Console.WriteLine($"Your current balance is: {user.GetBalance()}");
                            Console.WriteLine("=============================================");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect PIN.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }
        }

        public void Deposit()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {

                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");
                    while (true)
                    {

                        Console.Write("Enter your 4-digit PIN: ");
                        string pin = Console.ReadLine();

                        if (user.ValidatePin(pin))
                        {
                            Console.Write("Enter amount to deposit: ");
                            double amount;
                            while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                            {
                                Console.Write("Enter a valid amount: ");
                            }

                            user.AddAmount(amount);
                            Console.WriteLine("Deposit successful.");
                            Console.WriteLine("=============================================");
                            Console.WriteLine($"New Balance: {user.GetBalance()}");
                            Console.WriteLine("=============================================");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect PIN.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }
        }
        public void Withraw()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {
                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");
                    while (true)
                    {
                        Console.Write("Enter your 4-digit PIN: ");
                        string pin = Console.ReadLine();

                        if (user.ValidatePin(pin))
                        {
                            Console.Write("Enter amount to Withraw: ");
                            double amount;
                            while (!double.TryParse(Console.ReadLine(), out amount) || amount > 0)
                            {
                                Console.Write("Enter a valid amount: ");
                            }

                            user.WithrawAmount(amount);
                            Console.WriteLine("=============================================");
                            Console.WriteLine($"New Balance: {user.GetBalance()}");
                            Console.WriteLine("=============================================");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect PIN.");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }

        }
        public void Transfer()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {
                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");
                    Console.Write("Enter your 4-digit PIN: ");
                    string pin = Console.ReadLine();

                    if (user.ValidatePin(pin))
                    {
                        Console.Write("Enter the account number to transfer to: ");
                        string acc2 = Console.ReadLine().ToUpper();

                        if (!Details.ContainsKey(acc2))
                        {
                            Console.WriteLine("Recipient account not found.");
                            return;
                        }

                        if (acc2 == acc)
                        {
                            Console.WriteLine("You cannot transfer to the same account.");
                            return;
                        }

                        Account recipient = Details[acc2];

                        Console.Write("Enter amount to transfer: ");
                        double amount;
                        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                        {
                            Console.Write("Enter a valid positive amount: ");
                        }

                        if (user.GetBalance() >= amount)
                        {
                            user.WithrawAmount(amount);
                            recipient.AddAmount(amount);
                            Console.WriteLine("=============================================");
                            Console.WriteLine($"Successfully transferred ₹{amount} to {recipient.Name} ({acc2})");
                            Console.WriteLine($"Your new balance is: ₹{user.GetBalance()}");
                            Console.WriteLine("=============================================");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance for this transfer.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect PIN.");
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }
        }
        public void Delete()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {
                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");

                    while (true)
                    {
                        Console.Write("Enter your 4-digit PIN: ");
                        string pin = Console.ReadLine();

                        if (user.ValidatePin(pin))
                        {
                            Console.Write("Are you sure you want to delete this account? (yes/no): ");
                            string confirm = Console.ReadLine().ToLower();

                            if (confirm == "yes")
                            {
                                Details.Remove(acc);
                                Console.WriteLine("Account deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Account deletion cancelled.");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect PIN. Try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }
        }
        public void Pin_change()
        {
            while (true)
            {
                Console.Write("Enter your Account Number: ");
                string acc = Console.ReadLine().ToUpper();

                if (Details.ContainsKey(acc))
                {
                    Account user = Details[acc];
                    Console.WriteLine($"Welcome {user.Name}");

                    while (true)
                    {
                        Console.Write("Enter your 4-digit PIN: ");
                        string pin = Console.ReadLine();

                        if (user.ValidatePin(pin))
                        {
                            Console.Write("Are you sure you want to change pin this account? (yes/no): ");
                            string confirm = Console.ReadLine().ToLower();

                            if (confirm == "yes")
                            {
                                string new_pin;
                                do
                                {
                                    Console.Write("Set a 4-digit PIN: ");
                                    new_pin = Console.ReadLine();
                                } while (new_pin.Length != 4 || !int.TryParse(new_pin, out _));

                                user.PinChange(new_pin);


                                Console.WriteLine("New Pin changed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Account pin Change cancelled.");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect PIN. Try again.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Account not found.");
                    if (!acc_out())
                    {
                        return;
                    }
                }
            }
        }
    }
}
