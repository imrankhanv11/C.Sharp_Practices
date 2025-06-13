using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeCategeryCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Age : ");
            string inputage = Console.ReadLine();
            int Age = IntegerCheck(inputage); 

            String Category = Age < 13 ? "Child" : Age <= 17 ? "teen" : Age <= 60 ? "Adult" : "Senior";

            Console.WriteLine(Category);
        }

        public static int IntegerCheck(string input)
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
}
