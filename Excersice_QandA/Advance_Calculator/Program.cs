using System;

namespace Advance_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            bool start = true;

            // Instructions
            Console.WriteLine("===== Welcome to the Advanced Console Calculator =====\n");
            Console.WriteLine("Instructions:");
            Console.WriteLine("1. Start by entering a basic arithmetic expression (e.g., 2 + 3)");
            Console.WriteLine("2. After that, continue with operations (e.g., * 4, + 5)");
            Console.WriteLine("3. Type 'end' at any time to exit the calculator.\n");

            while (true)
            {
                if (!start)
                {
                    Console.WriteLine($"\n Current Result: {result}");
                }

                Console.Write(" Enter expression (or type 'end' to quit): ");
                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "end")
                {
                    Console.WriteLine("\n Exiting calculator...");
                    break;
                }

                try
                {
                    string exp;

                    if (start)
                    {
                        exp = input;
                    }
                    else
                    {
                        string trimmedInput = input.Trim();

                        if (!(trimmedInput.StartsWith("+") || trimmedInput.StartsWith("-") ||
                              trimmedInput.StartsWith("*") || trimmedInput.StartsWith("/")))
                        {
                            Console.WriteLine(" Error: After the first expression, input must start with an operator (+, -, *, /). Try again.");
                            continue;
                        }

                        exp = result + " " + trimmedInput;
                    }

                    result = Calci(exp);
                    Console.WriteLine($" Result: {result}");
                    start = false;
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine(" Error: Division by zero.");
                }
                catch
                {
                    Console.WriteLine(" Invalid expression. Please try again.");
                }
            }

            Console.WriteLine("\n Thank you for using the Advanced Calculator. Goodbye!");
        }

        // Main calculation logic
        public static int Calci(string exp)
        {
            int result = 0;
            int currentnum = 0;
            char operation = '+';

            for (int i = 0; i < exp.Length; i++)
            {
                char ch = exp[i];

                if (char.IsDigit(ch))
                {
                    currentnum = currentnum * 10 + (ch - '0');
                }

                if ((!char.IsDigit(ch) && ch != ' ') || i == exp.Length - 1)
                {
                    switch (operation)
                    {
                        case '+':
                            result += currentnum;
                            break;
                        case '-':
                            result -= currentnum;
                            break;
                        case '*':
                            result *= currentnum;
                            break;
                        case '/':
                            if (currentnum == 0)
                                throw new DivideByZeroException();
                            result /= currentnum;
                            break;
                    }

                    operation = ch;
                    currentnum = 0;
                }
            }

            return result;
        }
    }
}
