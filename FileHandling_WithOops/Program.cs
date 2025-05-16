using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandling_WithOops;

namespace File_Handlng_Advance
{
    internal class Program
    {
        static string DirectPath;
        static void Main(string[] args)
        {
            DirectPath = ConfigurationManager.AppSettings["DirectoryPath"];

            Console.WriteLine($"Directory path is -{DirectPath}");

            FileRepository file = new FileRepository(DirectPath);
            IOperations opertion = file;

            ICretionCheck createcheck = file;

            IDictionaryFiles Dict = file;

            while (true)
            {
                // Display menu options
                Console.WriteLine("--- File Manager ---\n");

                Console.WriteLine("Option  | Description");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1       | Create a New File");
                Console.WriteLine("2       | Read File");
                Console.WriteLine("3       | Append to File");
                Console.WriteLine("4       | Delete File");
                Console.WriteLine("5       | Empty the File");
                Console.WriteLine("6       | Show Dictionary");
                Console.WriteLine("7       | Clear Dictionary");
                Console.WriteLine("8       | Copy Dictionary to File");
                Console.WriteLine("9       | Copy File to Dictionary");
                Console.WriteLine("10      | Add details in Dictionary also in File");
                Console.WriteLine("11      | Delete details in Dictionary also in File");
                Console.WriteLine("12      | Exit");

                Console.WriteLine();

                Console.Write("Enter the Operation code : ");
                string MainInput = Console.ReadLine();
                Console.WriteLine();

                switch (MainInput)
                {
                    case "1":
                        createcheck.CreateFile(DirectPath);
                        break;
                    case "2":
                        opertion.ReadFile(DirectPath);
                        break;
                    case "3":
                        opertion.WriteFile(DirectPath);
                        break;
                    case "4":
                        opertion.DeleteFile(DirectPath);
                        break;
                    case "5":
                        opertion.EmptyFile(DirectPath);
                        break;
                    case "6":
                        Dict.ShowDictionary();
                        break;
                    case "7":
                        Dict.ClearDictionary();
                        break;
                    case "8":
                        Dict.DictionarytoFile(DirectPath);
                        break;
                    case "9":
                        Dict.FiletoDictionary(DirectPath);
                        break;
                    case "10":
                        Dict.AddValueDictionary(DirectPath);
                        break;
                    case "11":
                        Dict.RemoveValueDictionary(DirectPath);
                        break;
                    case "12":
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("Enter the valid operation code");
                        break;

                }
            }
        }
    }
}
