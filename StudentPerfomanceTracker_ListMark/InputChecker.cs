using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class InputChecker
    {
        //double check
        public double DoubleCheck(string input)
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid numeric salary:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number entered is too large or too small. Try again:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }

            return value;
        }

        //string check
        public string StringCheck(string input)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new FormatException("Input cannot be empty.");
                        Console.ResetColor();
                    }

                    if (Regex.IsMatch(input, @"\d"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new FormatException("Input should not contain numbers.");
                        Console.ResetColor();
                    }

                    if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        throw new FormatException("Input should not contain symbols.");
                        Console.ResetColor();
                    }

                    break;
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Invalid input: {ex.Message} Please try again:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }

            return input;

        }

        //input check for mark 
        public int IntCheckMark(string input)
        {
            int value;
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(input);

                    if (value <= 100 && value >= 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number must be less than or equal to 100. Try again:");
                        Console.ResetColor();
                        input = Console.ReadLine();
                    }
                }
                catch (FormatException)
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid numeric value:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number entered is too large or too small. Try again:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        //int check
        public int IntCheck(string input)
        {
            int value;
            while (true)
            {
                try
                {
                    value = Convert.ToInt32(input);
                    break;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid numeric value:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The number entered is too large or too small. Try again:");
                    Console.ResetColor();
                    input = Console.ReadLine();
                }
            }
            return value;
        }
       
    }
}