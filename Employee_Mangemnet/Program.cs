using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Employee_Mangemnet;

namespace Employee_Mangemnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<<------ Employee Mangemnet System ----->>>");
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine("|                 Operations               |");
            Console.WriteLine("+------------------------------------------+");
            Console.WriteLine("|  1.            New Permanet Employee     |");
            Console.WriteLine("|  2.            New Constract Employee    |");
            Console.WriteLine("|  3.            Remove Employee           |");
            Console.WriteLine("|  4.            Show Employee List        |");            
            Console.WriteLine("|  5.            Exit                      |");
            Console.WriteLine("+------------------------------------------+");

            Operations obj = new Operations();

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
                        obj.PrintAllEmployees();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }  
        }
    }
    class Operations
    {
        static int empIdCounter = 1000;
        static Dictionary<int, Employee> EmpDetails = new Dictionary<int, Employee>
        {
        {empIdCounter, new PermanentEmployee(empIdCounter++, "Ram", "Finance", 45000, new DateTime(2022, 4, 15), true, 15)},
        {empIdCounter, new PermanentEmployee(empIdCounter++, "Santhosh", "HR", 50000, new DateTime(2021, 8, 1), true, 20)},
        {empIdCounter, new ContractEmployee(empIdCounter++, "Karthik", "IT", 40000, 12, true)},
        {empIdCounter, new ContractEmployee(empIdCounter++, "Felix", "Marketing", 35000, 6, false)}
        };
        public void addPermanentEmp()
        {
            string check;
            do
            {
                Console.Write("Enter the Employee Name: ");
                string EmpName = Console.ReadLine();

                Console.Write("Enter the Department Name: ");
                string Department = Console.ReadLine();

                double Salary;
                while (true)
                {
                    Console.Write("Enter the Salary: ");
                    try
                    {
                        Salary = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid numeric salary.");
                    }
                }

                Console.Write("Enter the Joining Date (yyyy-mm-dd): ");
                DateTime JoiningDate;
                while (!DateTime.TryParse(Console.ReadLine(), out JoiningDate))
                {
                    Console.Write("Invalid date. Please enter again (yyyy-mm-dd): ");
                }

                Console.Write("Has Insurance Coverage (true/false): ");
                bool HasInsuranceCoverage;
                while (!bool.TryParse(Console.ReadLine(), out HasInsuranceCoverage))
                {
                    Console.Write("Invalid input. Please enter 'true' or 'false': ");
                }

                Console.Write("Enter Leave Encashment Balance: ");
                int LeaveEncashmentBalance;
                while (!int.TryParse(Console.ReadLine(), out LeaveEncashmentBalance))
                {
                    Console.Write("Invalid number. Please enter again: ");
                }

                PermanentEmployee newEmp = new PermanentEmployee(empIdCounter, EmpName, Department, Salary, JoiningDate, HasInsuranceCoverage, LeaveEncashmentBalance);

                EmpDetails[empIdCounter] = newEmp;
                Console.WriteLine($"Permanent Employee Added Successfully with ID: {empIdCounter}");

                empIdCounter++;
                Console.Write("Do you want to add another New Employee (yes/no) : ");
                check = Console.ReadLine().Trim().ToLower();
            } while (check == "yes");
             
        }

        public void addContractEmp()
        {
            string check;
            do
            {
                Console.Write("Enter the Employee Name: ");
                string EmpName = Console.ReadLine();

                Console.Write("Enter the Department Name: ");
                string Department = Console.ReadLine();

                double Salary;
                while (true)
                {
                    Console.Write("Enter the Salary: ");
                    try
                    {
                        Salary = Convert.ToDouble(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid numeric salary.");
                    }
                }

                int ContractDurationMonths;
                while (true)
                {
                    Console.Write("Enter Contract Duration in Months: ");
                    try
                    {
                        ContractDurationMonths = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

                bool IsRemote;
                while (true)
                {
                    Console.Write("Is the Employee Working Remotely? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out IsRemote))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'true' or 'false'.");
                    }
                }

                ContractEmployee newEmp = new ContractEmployee(empIdCounter, EmpName, Department, Salary, ContractDurationMonths, IsRemote);
                EmpDetails[empIdCounter] = newEmp;
                Console.WriteLine($"Contract Employee Added Successfully with ID: {empIdCounter}");

                empIdCounter++;

                Console.Write("Do you want to add another New Employee (yes/no) : ");
                check = Console.ReadLine().Trim().ToLower();
            } while (check == "yes");
             
        }
        public void removeEmp()
        {
            Console.Write("Enter the Employee Id to Remove :");
            int removeId;
            while (true)
            {
                try
                {
                    removeId = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            EmpDetails.Remove(removeId);
            Console.WriteLine("Removed Employee Succesfully");
        }

        public void PrintAllEmployees()
        {
            if (EmpDetails.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var entry in EmpDetails)
            {
                Console.WriteLine("\n----------------------------");
                Console.WriteLine($"Employee ID     : {entry.Key}");
                Console.WriteLine($"Name            : {entry.Value.Name}");
                Console.WriteLine($"Department      : {entry.Value.Department}");
                Console.WriteLine($"Salary          : {entry.Value.Salary}");

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
                Console.WriteLine("----------------------------");
            }
        }


    }

    class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }

        public Employee(int employeeId, string name, string department, double salary)
        {
            EmpId = employeeId;
            Name = name;
            Department = department;
            Salary = salary;
        }

    }
    class PermanentEmployee : Employee
    {
        public DateTime JoiningDate { get; set; }
        public bool HasInsuranceCoverage { get; set; }
        public int LeaveEncashmentBalance { get; set; }

        public PermanentEmployee(int employeeId, string name, string department, double salary, DateTime joiningDate, bool hasInsuranceCoverage, int leaveEncashmentBalance)
        : base(employeeId, name, department, salary)
        {
            JoiningDate = joiningDate;
            HasInsuranceCoverage = hasInsuranceCoverage;
            LeaveEncashmentBalance = leaveEncashmentBalance;
        }
    }
    class ContractEmployee : Employee
    {
        public int ContractDurationMonths { get; set; }
        public bool IsRemote { get; set; }
        public ContractEmployee(int employeeId, string name, string department, double salary, int contractDurationMonths, bool isRemote)
        : base(employeeId, name, department, salary)
        {
            ContractDurationMonths = contractDurationMonths;
            IsRemote = isRemote;
        }

    }
}
