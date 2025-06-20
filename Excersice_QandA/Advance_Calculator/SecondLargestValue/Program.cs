using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLargestValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];

            Console.WriteLine("Enter 10 integers:");
            for (int i = 0; i < 10; i++)
            {
                string inputint = Console.ReadLine();
                numbers[i] = IntergerCheck(inputint);
            }

            int firstMax = int.MinValue;
            int secondMax = int.MinValue;

            for (int i = 0; i < 10; i++)
            {
                if (numbers[i] > firstMax)
                {
                    secondMax = firstMax;
                    firstMax = numbers[i];
                }
                else if (numbers[i] > secondMax && numbers[i] != firstMax)
                {
                    secondMax = numbers[i];
                }
            }

            if (secondMax == int.MinValue)
            {
                Console.WriteLine("There is no second largest unique number.");
            }
            else
            {
                Console.WriteLine("The second largest unique number is: " + secondMax);
            }
        }

        public static int IntergerCheck(string input)
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
