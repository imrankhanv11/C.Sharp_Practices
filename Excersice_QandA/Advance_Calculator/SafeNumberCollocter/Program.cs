using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeNumberCollocter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10]; 
            int count = 0; 
            string input;

            
            while (true)
            {
                Console.Write("Enter a number or type 'exit' to stop: ");
                input = Console.ReadLine();

                
                if (input.ToLower() == "exit")
                {
                    break;
                }

                // Try to convert the input to an integer
                if (int.TryParse(input, out int number))
                {
                    // Resize array if it's full
                    if (count == numbers.Length)
                    {
                        Array.Resize(ref numbers, numbers.Length * 2); // Double the size of the array
                    }

                    numbers[count] = number;
                    count++;
                }
                else
                {
                    
                    Console.WriteLine("Invalid input, please enter a valid integer.");
                }
            }

            Console.WriteLine("\nValid integers collected:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
