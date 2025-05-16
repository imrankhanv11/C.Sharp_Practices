using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class InputGetter
    {
        //object for using grade checker
        Operations op = new Operations();

        //object for input checker
        InputChecker check = new InputChecker();

        //object for using inherited class
        IStudent student=new StudentRepositary();

        //adding student
        public void AddStudent()
        {
            string addAgian;
            do
            {
                Console.Write("Enter the Student Name :");
                string inputcheck1 = Console.ReadLine();
                string Name = check.StringCheck(inputcheck1);

                List<int> StudentMarks = new List<int>();

                string[] Subjects = new string[] { "Test", "Tamil", "English", "Math", "Science", "Social" };

                Console.WriteLine("Enter the Five Subjects Marks : ");
                for(int i=1; i<=5; i++)
                {
                    Console.Write($"Enter the Subject {Subjects[i]} mark :");
                    string inputcheck = Console.ReadLine();
                    int Mark = check.IntCheckMark(inputcheck);

                    StudentMarks.Add(Mark);
                }

                int TotalMark =0;
                foreach(int i in StudentMarks)
                {
                    TotalMark += i;
                }

                Double AvarageMark = TotalMark / 5;

                Console.Write("Enter the Student Type Regular - R, Exchange - E : ");
                Console.WriteLine();
                string StudendType = Console.ReadLine().ToUpper();

                if (StudendType.Equals("R"))
                {
                    string StudentGrade = op.gradecheckforRegular(AvarageMark);
                    RegularStudent regular = new RegularStudent(0, Name, StudentMarks, StudentGrade);
                    student.AddStudentDetails(regular);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New Student Added Succesfully");
                    Console.ResetColor();
                    Console.WriteLine();

                }
                else if (StudendType.Equals("E"))
                {
                    string StudentPassFail = op.gradecheckforExchange(AvarageMark);
                    ExchangeStudent exchange = new ExchangeStudent(0, Name, StudentMarks, StudentPassFail);
                    student.AddStudentDetails(exchange);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("New Student Added Succesfully");
                    Console.ResetColor();
                    Console.WriteLine();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid code.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                Console.Write("Do you add another Student (Y/N) :");
                addAgian = Console.ReadLine().ToUpper();
            } while (addAgian.Equals("Y"));
            Console.WriteLine();

        }

        //update student
        public void UpdateStudent()
        {
            Console.Write("Enter the Student Id to update : ");
            string inputchek = Console.ReadLine();
            int updateId = check.IntCheck(inputchek);

            //verify for id in details
            bool verify = student.StudentCheck(updateId);

            if(verify)
            {
                int count = 0;
                while (true)
                {
                    Console.Write("Do you want to update All - 1 or update specfic one - 2 : ");
                    string inputcheck2 = Console.ReadLine();
                    int choice = check.IntCheck(inputcheck2);
                    if (choice == 1)
                    {
                        student.updateStudentAll(updateId);
                        Console.WriteLine();
                        break;
                    }
                    else if (choice == 2)
                    {
                        student.updateStudentSpecific(updateId);
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        //only 3 attempts for update
                        if (count == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("your chance are over.");
                            Console.WriteLine();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid try agian.");
                        Console.ResetColor();
                        count++;
                    }
                } 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Student Id not found.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        //display by id
        public void DetletbyId()
        {
            Console.Write("Enter the Student Id to delete : ");
            string inputcheck1 = Console.ReadLine();
            int delteId = check.IntCheck(inputcheck1);

            student.delteStudentDetails(delteId);
            Console.WriteLine();
        }

        //search student
        public void SearchStudent()
        {
            Console.Write("Enter the Id to Serach :");
            string inputcheck1 = Console.ReadLine();
            int SerachId = check.IntCheck(inputcheck1);

            Console.Write("Enter the Name to Serach : ");
            string inputcheck2 = Console.ReadLine();
            string SerachName = check.StringCheck(inputcheck2);

            Console.WriteLine();
            student.StudentSearch(SerachId, SerachName);
            Console.WriteLine();


        }

        //display in order of grade
        public void DisplayByGrade()
        {
            student.DisplayByGrade();
            Console.WriteLine();
        }
        
        //display all details
        public void Display()
        {
            student.DisplayStudentDetails();
            Console.WriteLine();
        }

        //disply grade counter
        public void DisplaycountGrade()
        {
            student.DisplayCount_Grade();
            Console.WriteLine();
        }
    }
}
