using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentGradeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string anotherStudent;

            do
            {
                // Ask for student's name
                Console.Write("Enter student name: ");
                string inputstring = Console.ReadLine();
                string studentName = StringCheck(inputstring);

              
                int[] marks = new int[5];
                int total = 0;

                
                Console.WriteLine("Enter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Subject " + (i + 1) + ": ");
                    string inputMark = Console.ReadLine();
                    marks[i] = IntMark(inputstring);
                    total += marks[i];
                }

                
                double average = total / 5.0;

                
                string grade;
                if (average >= 90)
                {
                    grade = "A";
                }
                else if (average >= 75)
                {
                    grade = "B";
                }
                else if (average >= 60)
                {
                    grade = "C";
                }
                else
                {
                    grade = "F";
                }

                Console.WriteLine("\nStudent: " + studentName);
                Console.WriteLine("Total Marks: " + total);
                Console.WriteLine("Average Marks: " + average);
                Console.WriteLine("Grade: " + grade);

               
                Console.Write("\nDo you want to enter another student's data? (yes/no): ");
                anotherStudent = Console.ReadLine().ToLower();

            } while (anotherStudent == "yes");

            Console.WriteLine("\nThank you for using the Student Marks Report system!");
        }

        public static string StringCheck(string input)
        {
            while (true)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new FormatException("Input cannot be empty.");
                    }

                    if (Regex.IsMatch(input, @"\d"))
                    {
                        throw new FormatException("Input should not contain numbers.");
                    }

                    if (!Regex.IsMatch(input, @"^[a-zA-Z\s]+$"))
                    {
                        throw new FormatException("Input should not contain symbols.");
                    }

                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message} Please try again:");
                    input = Console.ReadLine();
                }
            }

            return input;
        }

        public static int IntMark(string input)
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
                        Console.WriteLine("The number must be less than or equal to 100. Try again:");
                        Console.ResetColor();
                        input = Console.ReadLine();
                    }
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
