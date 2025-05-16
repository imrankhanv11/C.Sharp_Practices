using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using FileHandling_WithOops;

namespace File_Handlng_Advance
{
    internal class FileRepository : ICretionCheck, IOperations, IDictionaryFiles
    {
        InputHandle input = new InputHandle();

        private static SortedDictionary<int, Employee> EmpDetails = new SortedDictionary<int, Employee>();

        //constructor for load previous values to dictionary
        public FileRepository(string path)
        {
            //load data
            FiletoDictionary(path);
        }

        //create new file
        public void CreateFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists at the specified path.");
                Console.WriteLine();
            }
            else
            {
                Console.Write("File does not exist. Do you want to create it? (yes/no): ");
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (userInput == "yes")
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            
                        }
                        Console.WriteLine("File created successfully at: " + filePath);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error creating file: {ex.Message}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("File creation aborted by user.");
                    Console.WriteLine();
                }
            }
        }

        //get file name in accetable format
        public string GetFileName()
        {
            string FileName;
            while (true)
            {
                Console.Write("Enter the file name : ");
                FileName = Console.ReadLine().Trim();

                if (String.IsNullOrEmpty(FileName))
                {
                    Console.WriteLine("File name can't be empty");
                    Console.WriteLine();
                    continue;
                }
                if (ContainsInvalidChars(FileName))
                {
                    Console.WriteLine("File name contains invalid characters. Please try again.");
                    Console.WriteLine();
                    continue;
                }
                break;
            }
            return FileName;

        }

        //check invalid char in file name
        public static bool ContainsInvalidChars(string fileName)
        {
            char[] invalidChars = Path.GetInvalidFileNameChars();
            foreach (char c in invalidChars)
            {
                if (fileName.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        //read content form file
        public void ReadFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
            }
            else
            {
                try
                {
                    using (StreamReader read = new StreamReader(filePath))
                    {
                        String content = read.ReadToEnd();
                        if(String.IsNullOrEmpty(content))
                        {
                            Console.WriteLine("File is Empty");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine(content);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error reading file {ex.Message}");
                    Console.WriteLine();
                }
            }
        }

        //write content in file
        public void WriteFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            if(!File.Exists(filePath))
            {
                Console.WriteLine("File not found");
                Console.WriteLine();
            }
            else
            {
                try
                {
                    Console.Write("Enter text to append: ");
                    string input = Console.ReadLine();
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine(input);
                    }
                    Console.WriteLine("Text appended successfully.");
                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error appending to file: {ex.Message}");
                    Console.WriteLine();
                }
            }
        }

        //delelte the file
        public void DeleteFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Do you want to delete the file : ");
                string confirmation = Console.ReadLine().Trim().ToLower();

                if(confirmation == "yes")
                {
                    File.Delete(filePath);
                    Console.WriteLine("File Deleted succesfully");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Deleting file cancenled");
                    Console.WriteLine();
                }
            }

        }

        //empty the file
        public void EmptyFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Do you want to clear the file : ");
                string confirmation = Console.ReadLine().Trim().ToLower();

                if (confirmation == "yes")
                {
                    File.WriteAllText(filePath, string.Empty);
                    Console.WriteLine("File Cleared succesfully");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Clearing file cancenled");
                    Console.WriteLine();
                }
            }
        }

        //copy detials in dictionary to file
        public void DictionarytoFile(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var emp in EmpDetails.Values)
                    {
                        if (emp is PermanentEmployee per)
                        {
                            writer.WriteLine($"Permanent,{per.EmpId},{per.Name},{per.Department},{per.Salary},{per.JoiningDate:yyyy-MM-dd},{per.HasInsuranceCoverage},{per.LeaveEncashmentBalance}");
                        }
                        else if (emp is ContractEmployee con)
                        {
                            writer.WriteLine($"Contract,{con.EmpId},{con.Name},{con.Department},{con.Salary},{con.ContractDurationMonths},{con.IsRemote}");
                        }
                    }
                }

                Console.WriteLine("Employees written to file.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
                Console.WriteLine();
            }
        }

        //copy details in file to dictionary
        public void FiletoDictionary(string path)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
                return;
            }

            try
            {
               
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    string type = parts[0];
                    int empId = int.Parse(parts[1]);
                    string name = parts[2];
                    string dept = parts[3];
                    double salary = double.Parse(parts[4]);

                    if (type == "Permanent")
                    {
                        DateTime joiningDate = DateTime.Parse(parts[5]);
                        bool insurance = bool.Parse(parts[6]);
                        int leaveBalance = int.Parse(parts[7]);

                        var emp = new PermanentEmployee(empId, name, dept, salary, joiningDate, insurance, leaveBalance);
                        EmpDetails[empId] = emp;
                    }
                    else if (type == "Contract")
                    {
                        int duration = int.Parse(parts[5]);
                        bool isRemote = bool.Parse(parts[6]);

                        var emp = new ContractEmployee(empId, name, dept, salary, duration, isRemote);
                        EmpDetails[empId] = emp;
                    }
                }

                Console.WriteLine("Employees loaded from file.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading from file: " + ex.Message);
                Console.WriteLine();
            }
        }

        //printing the dictionary details 
        public void ShowDictionary()
        {
            if (EmpDetails.Count == 0)
            {
                Console.WriteLine("No employees found.");
                Console.WriteLine();
                return;
            }
            foreach (var entry in EmpDetails)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Employee ID   : {entry.Key}         Name   : {entry.Value.Name}");
                Console.WriteLine($"Department    : {entry.Value.Department}           Salary  : {entry.Value.Salary}");
                Console.WriteLine("--------------------------------------------------------");
                if (entry.Value is PermanentEmployee pEmp)
                {
                    Console.WriteLine("Type            : Permanent Employee");
                    Console.WriteLine($"Joining Date    : {pEmp.JoiningDate.ToShortDateString()}");
                    Console.WriteLine($"Insurance       : {pEmp.HasInsuranceCoverage}");
                    Console.WriteLine($"Leave Balance   : {pEmp.LeaveEncashmentBalance}");
                }
                else if (entry.Value is ContractEmployee cEmp)
                {
                    Console.WriteLine("Type            : Contract Employee");
                    Console.WriteLine($"Contract Months : {cEmp.ContractDurationMonths}");
                    Console.WriteLine($"Is Remote       : {cEmp.IsRemote}");
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine();

            }
        }

        //clear the dictionary details
        public void ClearDictionary()
        {
            Console.Write("Do you want to clear the Dictionary Details (yes/no) : ");
            string confirmation = Console.ReadLine().Trim().ToLower();
            if (confirmation.Equals("yes"))
            {
                EmpDetails.Clear();
                Console.WriteLine("Dictionary Cleared Succesfully");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Clearing stoped");
                Console.WriteLine();
            }
        }

        //add value in dictionary also in file
        public void AddValueDictionary(string path)
        {
            Console.Write("Enter Name: ");
            string name = input.StringCheck(Console.ReadLine());

            Console.Write("Enter Department: ");
            string department = input.StringCheck(Console.ReadLine());

            Console.Write("Enter Salary: ");
            double salary = input.DoubleCheck(Console.ReadLine());

            Console.Write("Employee type Permanent - P or Contract - C: ");
            string confirmation = input.StringCheck(Console.ReadLine().ToUpper());

            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
                return;
            }

            int empIdCounter = 1000;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length > 1 && int.TryParse(parts[1], out int id))
                {
                    //empIdCounter = Math.Max(empIdCounter, id + 1);
                    if(EmpDetails.ContainsKey(empIdCounter))
                    {
                        empIdCounter++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            if (confirmation.Equals("P"))
            {
                Console.Write("Enter Joining Date (yyyy-mm-dd): ");
                DateTime joiningDate = input.DateTimeCheck(Console.ReadLine());

                Console.Write("Has Insurance Coverage (true/false): ");
                bool hasInsurance = input.BoolCheck(Console.ReadLine());

                Console.Write("Enter Leave Encashment Balance: ");
                int leaveBalance = input.IntCheck(Console.ReadLine());

                PermanentEmployee emp = new PermanentEmployee(empIdCounter, name, department, salary, joiningDate, hasInsurance, leaveBalance);

                EmpDetails[empIdCounter] = emp;
                Console.WriteLine($"{emp.GetType().Name} added with ID: {empIdCounter}");

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Permanent,{empIdCounter},{name},{department},{salary},{joiningDate:yyyy-MM-dd},{hasInsurance},{leaveBalance}");
                }

                Console.WriteLine("Employee details added successfully");
                Console.WriteLine($"Employee ID: {empIdCounter}, Employee Name: {name}");
                Console.WriteLine();
            }
            else if (confirmation.Equals("C"))
            {
                Console.Write("Enter Contract Duration (months): ");
                int duration = input.IntCheck(Console.ReadLine());

                Console.Write("Is Remote (true/false): ");
                bool isRemote = input.BoolCheck(Console.ReadLine());

                ContractEmployee emp = new ContractEmployee(empIdCounter, name, department, salary, duration, isRemote);

                EmpDetails[empIdCounter] = emp;
                Console.WriteLine($"{emp.GetType().Name} added with ID: {empIdCounter}");

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"Contract,{empIdCounter},{name},{department},{salary},{duration},{isRemote}");
                }

                Console.WriteLine("Employee details added successfully");
                Console.WriteLine($"Employee ID: {empIdCounter}, Employee Name: {name}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Invalid employee type selected.");
            }
        }

        //delete value in dictionary also in file
        public void RemoveValueDictionary(string path)
        {
            Console.Write("Enter Employee ID to remove: ");
            int empId = input.IntCheck(Console.ReadLine());

            string fileName = GetFileName();
            string filePath = Path.Combine(path, fileName);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File not found.");
                Console.WriteLine();
            }
            else
            {
                 File.WriteAllText(filePath, string.Empty);

                //removing the value in dictionary
                EmpDetails.Remove(empId);
            }

            //removing the value in file
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var emp in EmpDetails.Values)
                    {
                        if (emp is PermanentEmployee per)
                        {
                            writer.WriteLine($"Permanent,{per.EmpId},{per.Name},{per.Department},{per.Salary},{per.JoiningDate:yyyy-MM-dd},{per.HasInsuranceCoverage},{per.LeaveEncashmentBalance}");
                        }
                        else if (emp is ContractEmployee con)
                        {
                            writer.WriteLine($"Contract,{con.EmpId},{con.Name},{con.Department},{con.Salary},{con.ContractDurationMonths},{con.IsRemote}");
                        }
                    }
                }

                Console.WriteLine("Employees written to file.");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
                Console.WriteLine();
            }
        }
    }
}
