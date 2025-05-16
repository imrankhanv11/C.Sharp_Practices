using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Performance_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //object for calling input getting class
            InputGetter input = new InputGetter();

            string MainInput;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("  --------------------------------");
                Console.WriteLine("  | Option | Operation           |");
                Console.WriteLine("  --------------------------------");
                Console.WriteLine("  |   1    | Add new Student     |");
                Console.WriteLine("  |   2    | Update Student      |");
                Console.WriteLine("  |   3    | Delete Student      |");
                Console.WriteLine("  |   4    | Search Students     |");
                Console.WriteLine("  |   5    | Display Students    |");
                Console.WriteLine("  |   6    | Display By Grade    |");
                Console.WriteLine("  |   7    | Display Grade Count |");
                Console.WriteLine("  |   8    | Exit                |");
                Console.WriteLine("  --------------------------------");
;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter the Operations code : ");
                Console.ResetColor();

                MainInput = Console.ReadLine();

                switch(MainInput)
                {
                    case "1":
                        //adding new Student
                        input.AddStudent();
                        break;
                    case "2":
                        //Update student specific or all details
                        input.UpdateStudent();
                        break;
                    case "3":
                        //delete student detials using id
                        input.DetletbyId();
                        break;
                    case "4":
                        //serach student details using id or name 
                        input.SearchStudent();
                        break;
                    case "5":
                        //display all student detials present in database
                        input.Display();
                        break;
                    case "6":
                        //display by grade for regular and pass/file for exchange
                        input.DisplayByGrade();
                        break;
                    case "7":
                        //display count of each grade
                        input.DisplaycountGrade();
                        break;
                    case "8":
                        //exit
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid code try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
