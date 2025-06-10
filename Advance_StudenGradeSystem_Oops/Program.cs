using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Advance_StudenGradeSystem_Oops
{
    internal class Program
    {
        static Dictionary<int, Student> students = new Dictionary<int, Student>();
        static void Main(string[] args)
        {
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("|        Student Mark System        |");
            Console.WriteLine("+-----------------------------------+");
            Console.WriteLine("| 1.   |     Add student Detials    |");
            Console.WriteLine("| 2.   |     Show the List          |");
            Console.WriteLine("| 3.   |     Exit                   |");
            Console.WriteLine("+-----------------------------------+");

            while (true)
            {
                Console.Write("Enter the code operation : ");
                string MainInput = Console.ReadLine();
                switch (MainInput)
                {
                    case "1":
                        addStudent();
                        break;
                    case "2":
                        showItem();
                        break;
                    case "3":
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("Invalid try again");
                        break;
                }

            }

        }
        public static void addStudent()
        {
            string anotherStudent;
            do
            {
            Enterregis:
                Console.Write("Enter student register number: ");
                int registerNumber;
                try
                {
                    registerNumber = int.Parse(Console.ReadLine());
                    if (students.ContainsKey(registerNumber))
                    {
                        Console.WriteLine("Register number must not be same");
                        goto Enterregis;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid try again");
                    goto Enterregis;
                }

                Console.Write("Enter student name: ");
                string inputname = Console.ReadLine();
                string studentName = StringCheck(inputname);

                int[] marks = new int[5];

                Console.WriteLine("Enter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    bool isValid = false;
                    while (!isValid)
                    {
                        Console.Write($"Subject {i + 1}: ");
                        isValid = int.TryParse(Console.ReadLine(), out marks[i]) && marks[i] >= 0 && marks[i] <= 100;
                        if (!isValid)
                        {
                            Console.WriteLine("Please enter a valid mark between 0 and 100.");
                        }
                    }
                }

                Student student = new Student(studentName, registerNumber, marks);
                students.Add(registerNumber, student);

                Console.Write("\nDo you want to enter another student's data? (yes/no): ");
                anotherStudent = Console.ReadLine().ToLower();

            } while (anotherStudent == "yes");
        }
        public static void showItem()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("List is Empty");
                return;
            }

            Console.WriteLine("\nDisplaying all student reports:");
            foreach (var student in students.Values)
            {
                student.DisplayStudentReport();
            }

            Console.WriteLine("\nThank you for using the Student Marks Report system!");
        }

        public static  string StringCheck(string input)
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

    }

}
