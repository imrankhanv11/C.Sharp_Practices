using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseAndAvg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[5]; 
            int sum = 0;

            Console.WriteLine("Enter 5 numbers:");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write("Enter number " + i + " :");
                string inputint = Console.ReadLine();
                numbers[i] = IntegerCheck(inputint);
                sum += numbers[i]; 
            }

            // Reverse
            Console.WriteLine("\nReversed Array:");
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(numbers[i]);
            }

            // Calculate the average
            double average = sum / 5.0;
            Console.WriteLine("\nAverage of the numbers: " + average);
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
