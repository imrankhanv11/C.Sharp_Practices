using System;

class Calculator
{
    static void Main()
    {
        double num1, num2;
        string input;
        bool validInput;

        // Get the first number
        Console.Write("Enter the first number: ");
        input = Console.ReadLine();
        validInput = double.TryParse(input, out num1);

        if (!validInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        // Get the second number
        Console.Write("Enter the second number: ");
        input = Console.ReadLine();
        validInput = double.TryParse(input, out num2);

        if (!validInput)
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        // Choose the operation
        Console.WriteLine("Choose an operation:");
        Console.WriteLine("1. Add (+)");
        Console.WriteLine("2. Subtract (-)");
        Console.WriteLine("3. Multiply (*)");
        Console.WriteLine("4. Divide (/)");
        string operation = Console.ReadLine();

        double result = 0;

        // Perform the operation
        switch (operation)
        {
            case "1":
            case "+":
                result = num1 + num2;
                Console.WriteLine($"Result: {num1} + {num2} = {result}");
                break;

            case "2":
            case "-":
                result = num1 - num2;
                Console.WriteLine($"Result: {num1} - {num2} = {result}");
                break;

            case "3":
            case "*":
                result = num1 * num2;
                Console.WriteLine($"Result: {num1} * {num2} = {result}");
                break;

            case "4":
            case "/":
                // diving
                if (num2 != 0)
                {
                    result = num1 / num2;
                    Console.WriteLine($"Result: {num1} / {num2} = {result}");
                }
                else
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                }
                break;

            default:
                Console.WriteLine("Invalid operation selected.");
                break;
        }

    }
}