using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Services service = new Process();

            Console.WriteLine("<<<---------- Employee Mangemnet System ---------->>>");
            Console.WriteLine("+---------------------------------------------------+");
            Console.WriteLine("|                      Operations                   |");
            Console.WriteLine("+---------------------------------------------------+");
            Console.WriteLine("|  1.            Add Student                        |");
            Console.WriteLine("|  2.            Add Teacher                        |");
            Console.WriteLine("|  3.            Show List                          |");
            Console.WriteLine("|  4.            Exit                               |");
            Console.WriteLine("+---------------------------------------------------+");
            

            while (true)
            {
                Console.Write("Enter the process number :");
                int MainInput = Convert.ToInt32(Console.ReadLine());
                switch (MainInput)
                {
                    case 1:
                        service.AddStudent();
                        break;
                    case 2:
                        service.AddTeacher();
                        break;
                    case 3:
                        service.ShowList();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invlaid try again");
                        break;
                }
            }
        }
    }
}
