using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Showing Menu
            Console.WriteLine("<<<---------- Employee Mangemnet System ---------->>>");
            Console.WriteLine("+---------------------------------------------------+");
            Console.WriteLine("|                      Operations                   |");
            Console.WriteLine("+---------------------------------------------------+");
            Console.WriteLine("|  1.            New Permanent Employee             |");
            Console.WriteLine("|  2.            New Constract Employee             |");
            Console.WriteLine("|  3.            Delete Employee                    |");
            Console.WriteLine("|  4.            Show Employee List                 |");
            Console.WriteLine("|  5.            Show Permanent Employee List       |");
            Console.WriteLine("|  6.            Show Contract Employee List        |");
            Console.WriteLine("|  7.            Exit                               |");
            Console.WriteLine("+---------------------------------------------------+");

            //Object creation for access operations method
            Operations obj = new Operations();

            //Object creation for access printing method
            PrintingClass print = new PrintingClass();

            while (true)
            {
                Console.Write("Enter the Operation code : ");
                string MainInput = Console.ReadLine();
                switch (MainInput)
                {
                    case "1":
                        obj.addPermanentEmp();
                        break;
                    case "2":
                        obj.addContractEmp();
                        break;
                    case "3":
                        obj.removeEmp();
                        break;
                    case "4":
                        print.PrintAllEmployees();
                        break;
                    case "5":
                        print.PrintPerEmp();
                        break;
                    case "6":
                        print.PrintConEmp();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}