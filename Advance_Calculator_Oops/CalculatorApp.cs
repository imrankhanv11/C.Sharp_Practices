using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_Calculator_OOPS
{
    public class CalculatorApp
    {
        private readonly Calculator calculator;
        private bool FirstInput;

        public CalculatorApp()
        {
            calculator = new Calculator();
            FirstInput = true;
        }

        public void Run()
        {
            Console.WriteLine("===== Welcome to the Advanced Console Calculator =====\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Start by entering a basic arithmetic expression (e.g., 2 + 3)");
            Console.WriteLine("2. After that, continue with operations (e.g., * 4, + 5)");
            Console.WriteLine("3. Type 'end' at any time to exit the calculator.\n");

            while (true)
            {
                if (!FirstInput)
                {
                    Console.WriteLine($"\n Current Result: {calculator.CurrentResult}");
                }

                Console.Write(" Enter expression (or type 'end' to quit): ");
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "end")
                {
                    Console.WriteLine("\n Exiting calculator...");
                    break;
                }

                // Validate input
                if (!FirstInput)
                {
                    if (string.IsNullOrWhiteSpace(input) ||
                        !(input.StartsWith("+") || input.StartsWith("-") || input.StartsWith("*") || input.StartsWith("/")))
                    {
                        Console.WriteLine(" Error: After the first expression, input must start with an operator (+, -, *, /). Please try again.");
                        continue;
                    }
                }

                try
                {
                    int result = calculator.Evaluate(input, FirstInput);
                    Console.WriteLine($" Result: {result}");
                    FirstInput = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error: {ex.Message}");
                }
            }

            Console.WriteLine("\n Thank you for using the Advanced Calculator. Goodbye!");
        }


    }
}
