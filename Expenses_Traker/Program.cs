using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Expenses_Traker
{
    class Program
    {

        InputHandle input = new InputHandle();

        static Dictionary<string, int> map = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------- Expense Traker --------");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. For Show the list and other operation ");
                Console.WriteLine("3. For exit ");
                Console.Write("Enter the Operation :");

                string choiceInput = Console.ReadLine();

                switch (choiceInput)
                {
                    case "1":
                        AddExpenses();
                        break;
                    case "2":
                        Console.WriteLine("1. For Show the list ");
                        Console.WriteLine("2. To Check MIN and Max Expenses");
                        Console.WriteLine("3. To Check the Avg Expenses");
                        Console.WriteLine("4. To check Total Amount Spend ");
                        Console.Write("Enter the Operation :");

                        string InInput = Console.ReadLine();

                        switch (InInput)
                        {
                            case "1":
                                ShowList();
                                break;
                            case "2":
                                Min_Max();
                                break;
                            case "3":
                                Avg();
                                break;
                            case "4":
                                TotalSum();
                                break;
                            default:
                                Console.WriteLine("try Again invalid input");
                                break;
                        }
                        break;
                    case "3":
                        Console.WriteLine("Thank you !");
                        return;

                    default:
                        Console.WriteLine("try Again invalid input");
                        break;
                }
            }

        }
        public void AddExpenses()
        {
            int c = 1;
            while (c <= 5)
            {
                Console.Write("Enter the Expenses Name : ");
                string inputexpense = Console.ReadLine();
                string expense = input.StringCheck(inputexpense);


                Console.Write("Enter the Amount : ");
                string inputamount = Console.ReadLine();
                int amount = input.IntCheck(inputamount);
                

                map.Add(expense, amount);
                Console.Write("Do you want to add another expenses ( yes / no ) : ");
                string check = Console.ReadLine().ToLower().Trim();
                if (check != "yes")
                {
                    break;
                }

                c++;
            }
        }

        public static void ShowList()
        {
            if (map.Count == 0)
            {
                Console.WriteLine("The List is empty. Please Add Expenses First");
                return;
            }
            Console.WriteLine("The Expenses List :");
            foreach (var item in map)
            {
                Console.WriteLine($"Expenses : {item.Key},    Amount : {item.Value} ");
            }
        }

        public static void Min_Max()
        {
            if (map.Count == 0)
            {
                Console.WriteLine("The List is empty. Please Add Expenses First");
                return;
            }
            var maxValue = map.Values.Max();
            var minValue = map.Values.Min();

            foreach (var pair in map)
            {
                if (pair.Value == maxValue)
                {
                    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
                }
                if (pair.Value == minValue)
                {
                    Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
                }
            }
        }
        public static void Avg()
        {
            if (map.Count == 0)
            {
                Console.WriteLine("The List is empty. Please Add Expenses First");
                return;
            }
            double avg = map.Values.Sum() / map.Count();
            Console.WriteLine($"The Average of Expenses : {avg}");
        }
        public static void TotalSum()
        {
            if (map.Count == 0)
            {
                Console.WriteLine("The List is empty. Please Add Expenses First");
                return;
            }
            Console.WriteLine($"Total amount of Expenses is : {map.Values.Sum()}");
        }

    }
}


