using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileManagerApp
{
    class Program
    {
        static string directoryPath;

        public static void Main(string[] args)
        {
            directoryPath = ConfigurationManager.AppSettings["DirectoryPath"];

            Console.WriteLine("Directory path read from App.config: " + directoryPath);

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Error: Directory '{directoryPath}' does not exist.");
                return;
            }
            Console.WriteLine("Directory exists.");
            Console.WriteLine();

            while (true)
            {
                // Display menu options
                Console.Clear();
                Console.WriteLine("--- File Manager ---\n");
                Console.WriteLine("1. Create File");
                Console.WriteLine("2. Read File");
                Console.WriteLine("3. Append to File");
                Console.WriteLine("4. Delete File");
                Console.WriteLine("5. Exit");
                Console.WriteLine();

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateFile();
                        break;

                    case "2":
                        ReadFile();
                        break;

                    case "3":
                        AppendFile();
                        break;

                    case "4":
                        DeleteFile();
                        break;

                    case "5":
                        Console.WriteLine("Exiting the program...");
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        public static string GetFileName()
        {
            string fileName;
            while (true)
            {
                Console.Write("Enter the file name: ");
                fileName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(fileName))
                {
                    Console.WriteLine("File name cannot be emptt. Please try again.");
                    continue;
                }

                //if (ContainsInvalidChars(fileName))
                //{
                //    Console.WriteLine("File name contains invalid characters. Please try again.");
                //    continue;
                //}

                break;
            }

            return fileName;
        }
        //public static bool ContainsInvalidChars(string fileName)
        //{
        //    char[] invalidChars = Path.GetInvalidFileNameChars();
        //    foreach (char c in invalidChars)
        //    {
        //        if (fileName.Contains(c))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public static void CreateFile()
        {
            string fileName = GetFileName();
            string filepath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filepath))
            {
                Console.WriteLine("File already exists.");
            }
            else
            {
                Console.Write("File does not exist. Do you want to create it? (yes/no): ");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "yes")
                {
                    try
                    {
                        using (StreamWriter newfile = new StreamWriter(filepath))
                        {
                            Console.WriteLine("File created successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("File creation aborted.");
                }
            }
        }
        public static void ReadFile()
        {
            string fileName = GetFileName();
            string filepath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(filepath))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        string content = reader.ReadToEnd();
                        if (string.IsNullOrEmpty(content))
                        {
                            Console.WriteLine("The file is empty.");
                        }
                        else
                        {
                            Console.WriteLine("File content:\n");
                            Console.WriteLine(content);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file: {ex.Message}");
                }
            }
        }

        public static void AppendFile()
        {
            string fileName = GetFileName();
            string filepath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(filepath))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                try
                {
                    Console.Write("Enter text to append: ");
                    string input = Console.ReadLine();
                    using (StreamWriter writer = new StreamWriter(filepath, true)) 
                    {
                        writer.WriteLine(input);
                    }
                    Console.WriteLine("Text appended successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error appending to file: {ex.Message}");
                }
            }
        }

        public static void DeleteFile()
        {
            string fileName = GetFileName();
            string filepath = Path.Combine(directoryPath, fileName);

            if (!File.Exists(filepath))
            {
                Console.WriteLine("File not found.");
            }
            else
            {
                Console.Write("Are you sure you want to delete the file? (yes/no): ");
                string confirmation = Console.ReadLine().Trim().ToLower();
                if (confirmation == "yes")
                {
                    try
                    {
                        File.Delete(filepath);
                        Console.WriteLine("File deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error deleting file: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("File deletion aborted.");
                }
            }
        }
    }
}
