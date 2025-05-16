using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    class InputChecker
    {
        //checking interger
        public int IntergerCheck(string input)
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
                    Console.Write("Enter the valid numerical value : ");
                    input = Console.ReadLine();
                }
                catch(OverflowException)
                {
                    Console.Write("Enter the Valid Range value : ");
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        //checking double
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
                    Console.Write("Enter the valid numerical value : ");
                    input = Console.ReadLine();
                }
                catch (OverflowException)
                {
                    Console.Write("Enter the Valid Range value : ");
                    input = Console.ReadLine();
                }
            }
            return value;
        }

        //checking string
        public string StringCheck(string input)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new Exception("String cannot be empty");
                    }
                    if (Regex.IsMatch(input, @"\d"))
                    {
                        throw new Exception("String cannot be Numerical Value");
                    }
                    if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                    {
                        throw new Exception("String cannot be Symbol");
                    }
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Invalid input, {e.Message}");
                    input = Console.ReadLine();
                }
                
            }
            return input;
        }

        //checking password
        public string PasswordCheck(string input)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new Exception("Password can't be empty or spaces");
                    }
                    if(input.Length != 4)
                    {
                        throw new Exception("Password be in 4 char");
                    }
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine($"Invalid. {e.Message}");
                    input = Console.ReadLine();
                }
                
            }
            return input;
        }
    }
}
