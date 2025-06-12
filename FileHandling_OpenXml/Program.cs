using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;


namespace FileHandling_OpenXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Directpath = ConfigurationManager.AppSettings["DirectoryPath"];

            Operaions operate = new Operaions();

            Console.WriteLine("------ Operations ----");
            Console.WriteLine("1.       Create");
            Console.WriteLine("2.       Read");
            Console.WriteLine("3.       Append");
            Console.WriteLine("4.       Delete");
            

            while (true)
            {
                Console.Write("Enter the Operation code : ");
                string mainInput = Console.ReadLine();

                switch (mainInput)
                {
                    case "1":
                        operate.CreateFile(Directpath);
                        break;
                    case "2":
                        operate.ReadFile(Directpath);
                        break;
                    case "3":
                        operate.AppendFile(Directpath);
                        break;
                    case "4":
                        operate.DeleteFile(Directpath);
                        break;
                    case "5":
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("Invalid Try Again");
                        break;
                }
            }
            

        }
    }
}
