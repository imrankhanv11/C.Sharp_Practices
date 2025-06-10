using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance_StudenGradeSystem_Oops
{
    public class Student
    {
        public string Name { get; set; }
        public int RegisterNumber { get; set; }
        public int[] Marks { get; set; }

        public Student(string name, int registerNumber, int[] marks)
        {
            Name = name;
            RegisterNumber = registerNumber;
            Marks = marks;
        }

        public void DisplayStudentReport()
        {
            Console.WriteLine($"Student Name: {Name}");
            Console.WriteLine($"Register Number: {RegisterNumber}");
            Console.WriteLine("Marks:");
            Console.WriteLine("+--------------------+--------+");
            Console.WriteLine("| Subject            | Marks  |");
            Console.WriteLine("+--------------------+--------+");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"| Subject {i + 1}          |   {Marks[i]}   |");
            }

            Console.WriteLine("+--------------------+--------+");

            int totalMarks = 0;
            foreach (int mark in Marks)
            {
                totalMarks += mark;
            }
            double averageMarks = totalMarks / 5.0;

            Console.WriteLine($"| Total Marks  :       {totalMarks}    |");
            Console.WriteLine("+--------------------+--------+");
            Console.WriteLine($"| Average Marks :      {averageMarks:F2}  |");
            Console.WriteLine("+--------------------+--------+");

            if (totalMarks >= 450 && totalMarks <= 500)
            {
                Console.WriteLine("     Grade is O");
            }
            else if (totalMarks >= 400 && totalMarks < 450)
            {
                Console.WriteLine("     Grade is A+");
            }
            else if (totalMarks >= 350 && totalMarks < 400)
            {
                Console.WriteLine("     Grade is A");
            }
            else if (totalMarks >= 300 && totalMarks < 350)
            {
                Console.WriteLine("     Grade is B+");
            }
            else if (totalMarks < 300)
            {
                Console.WriteLine("     Grade is B");
            }

        }
    }
}
