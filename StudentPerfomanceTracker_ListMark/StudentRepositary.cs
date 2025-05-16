using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class StudentRepositary : IStudent
    {
        //object for checking input
        InputChecker check = new InputChecker();

        //static id used in studentid auto increment
        static int StudentId = 100;

        //private specifer only access within the class
        //using static for access easily within the class method
        private static Dictionary<int, Student> StudentDetails = new Dictionary<int, Student>();
        

        //checking for student id in studentdetails
        public bool StudentCheck(int checkId)
        {
            if(StudentDetails.ContainsKey(checkId))
            {
                return true;
            }
            return false;
        }

        //add new student
        public void AddStudentDetails(Student student)
        {
            student.StudentId = StudentId;
            StudentDetails.Add(student.StudentId, student);
            
            Console.WriteLine($"Student Id      : {StudentId}, Student Name     : {student.StudentName}");
            StudentId++;
        }

        //update student with all details
        public void updateStudentAll(int upId)
        {

            //before update check
            if (StudentDetails.ContainsKey(upId))
            {
                Student student = StudentDetails[upId];
                Operations ops = new Operations();

                Console.Write("Enter the Student Name : ");
                student.StudentName = Console.ReadLine();

                List<int> StudentMarks = new List<int>();
                Console.WriteLine("Enter the Five Subjects Marks : ");
                for (int i = 1; i <= 5; i++)
                {
                    Console.Write($"Enter the Subject {i} mark :");
                    string inputcheck = Console.ReadLine();
                    int Mark = check.IntCheckMark(inputcheck);

                    StudentMarks.Add(Mark);
                }

                int TotalMark = 0;
                foreach (int i in StudentMarks)
                {
                    TotalMark += i;
                }

                Double AvarageMark = TotalMark / 5;

                //update if regular
                if (student is RegularStudent regular)
                {
                    regular.Grade = ops.gradecheckforRegular(AvarageMark);
                }

                //update if exchange
                else if (student is ExchangeStudent exchange)
                {
                    exchange.Grade = ops.gradecheckforExchange(AvarageMark);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student updated successfully.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student ID not found.");
                Console.ResetColor();
            }
        }

        //update student for specific update
        public void updateStudentSpecific(int upId)
        {
            Student student = StudentDetails[upId];
            Operations ops = new Operations();

            //asking which need to update
            Console.WriteLine("Select the field to update:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Tamil Mark");
            Console.WriteLine("3. English Mark");
            Console.WriteLine("4. Math Mark");
            Console.WriteLine("5. Science Mark");
            Console.WriteLine("6. Social Mark");
            Console.Write("Enter your choice (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter new name: ");
                    student.StudentName = Console.ReadLine();
                    break;
                case "2":
                    Console.Write("Enter new Tamil mark: ");
                    student.StudentMarks[0] = check.IntCheckMark(Console.ReadLine());
                    break;
                case "3":
                    Console.Write("Enter new English mark: ");
                    student.StudentMarks[1] = check.IntCheckMark(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter new Math mark: ");
                    student.StudentMarks[2] = check.IntCheckMark(Console.ReadLine());
                    break;
                case "5":
                    Console.Write("Enter new Science mark: ");
                    student.StudentMarks[3] = check.IntCheckMark(Console.ReadLine());
                    break;
                case "6":
                    Console.Write("Enter new Social mark: ");
                    student.StudentMarks[4] = check.IntCheckMark(Console.ReadLine());
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor();
                    return;
            }

            int totalMarks = 0;
            foreach (int mark in student.StudentMarks)
            {
                totalMarks += mark;
            }

            Double AvarageMark = totalMarks / 5;

            if (student is RegularStudent regular)
            {
                regular.Grade = ops.gradecheckforRegular(AvarageMark);
            }
            else if (student is ExchangeStudent exchange)
            {
                exchange.Grade = ops.gradecheckforExchange(AvarageMark);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Student detail updated successfully.");
            Console.ResetColor();
        }

        //delete student using id
        public void delteStudentDetails(int deleteId)
        {
            if(StudentDetails.ContainsKey(deleteId))
            {
                StudentDetails.Remove(deleteId);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Student Detials Deleted succesfully");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Stundent not found.");
                Console.ResetColor();
            }
        }

        //search student detials using id and name
        public void StudentSearch(int searchId, string searchName)
        {
            bool found = false;
            foreach (Student student in StudentDetails.Values)
            {
                if (student.StudentId == searchId ||
                    student.StudentName.ToLower() == searchName.ToLower())
                {

                    Console.WriteLine($"Student Id : {student.StudentId}, Student Name : {student.StudentName}");
                    Console.WriteLine($"Student Tamil Mark      : {student.StudentMarks[0]}");
                    Console.WriteLine($"Student English Mark    : {student.StudentMarks[1]}");
                    Console.WriteLine($"Student Math Mark       : {student.StudentMarks[2]}");
                    Console.WriteLine($"Student Science Mark    : {student.StudentMarks[3]}");
                    Console.WriteLine($"Student Social Mark     : {student.StudentMarks[4]}");
                    if (student is RegularStudent reg)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student Type         : Regular Student");
                        Console.WriteLine($"Student Grade       : {reg.Grade}");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();
                    }

                    if (student is ExchangeStudent exchange)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student Type            : Exchange Student");
                        Console.WriteLine($"Student Grade           : {exchange.Grade}");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine();
                    }
                    found = true;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No student found with the given ID or name.");
                Console.ResetColor();
            }
        }

        //dislplay all student details
        public void DisplayStudentDetails()
        {
            foreach (var student in StudentDetails)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Student Id              : {student.Key}");
                Console.WriteLine($"Student Name            : {student.Value.StudentName}");
                Console.WriteLine($"Student Tamil Mark      : {student.Value.StudentMarks[0]}");
                Console.WriteLine($"Student English Mark    : {student.Value.StudentMarks[1]}");
                Console.WriteLine($"Student Math Mark       : {student.Value.StudentMarks[2]}");
                Console.WriteLine($"Student Science Mark    : {student.Value.StudentMarks[3]}");
                Console.WriteLine($"Student Social Mark     : {student.Value.StudentMarks[4]}");
                Console.WriteLine("------------------------------------------");


                if (student.Value is RegularStudent reg)
                {
                    Console.WriteLine("Student Type   : Regular Student");
                    Console.WriteLine($"Student Grade  : {reg.Grade}");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine();
                }

                if (student.Value is ExchangeStudent exchange)
                {
                    Console.WriteLine("Student Type   : Exchange Student");
                    Console.WriteLine($"Student Grade  : {exchange.Grade}");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine();
                }
            }
        }

        //display by grade
        public void DisplayByGrade()
        {
            Console.WriteLine("=== Regular Students by Grade ===");
            var regularGroups = StudentDetails.Values
                .OfType<RegularStudent>()
                .GroupBy(r => r.Grade);

            foreach (var group in regularGroups)
            {
                Console.WriteLine($"\n-- Grade: {group.Key} --");
                foreach (var student in group)
                {
                    Console.WriteLine($"Student Id   : {student.StudentId}");
                    Console.WriteLine($"Student Name : {student.StudentName}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n=== Exchange Students by Status ===");
            var exchangeGroups = StudentDetails.Values
                .OfType<ExchangeStudent>()
                .GroupBy(e => e.Grade.Equals("Pass", StringComparison.OrdinalIgnoreCase) ? "Pass" : "Fail");

            foreach (var group in exchangeGroups)
            {
                Console.WriteLine($"\n-- Status: {group.Key} --");
                foreach (var student in group)
                {
                    Console.WriteLine($"Student Id   : {student.StudentId}");
                    Console.WriteLine($"Student Name : {student.StudentName}");
                    Console.WriteLine();
                }
            }
        }

        //display count numbers of each grade
        public void DisplayCount_Grade()
        {
            Dictionary<String, int> GradeCounter = new Dictionary<String, int>();
            foreach(var value in StudentDetails.Values)
            {
                string grade = "";

                if(value is RegularStudent reg)
                {
                    grade = reg.Grade;
                }
                else if(value is ExchangeStudent exchange)
                {
                    grade = exchange.Grade;
                }
                if (GradeCounter.ContainsKey(grade))
                {
                    GradeCounter[grade]++;
                }
                else
                {
                    GradeCounter.Add(grade, 1);
                }
            }

            foreach(var k  in GradeCounter)
            {
                Console.WriteLine($"Grade : {k.Key},    Count : {k.Value}");
            }
        }

    }
}
