using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement
{
    class Operations
    {
        //Counter Value with static for auto increment for empID
        static int empIdCounter = 1001;

        //Dictionary for storing both Permanent and Contract Employee
        static public Dictionary<int, Employee> EmpDetails = new Dictionary<int, Employee>
        {
            //Default Values
            {empIdCounter, new PermanentEmployee(empIdCounter++, "Ram", "Finance", 45000, new DateTime(2022, 4, 15), true, 15)},
            {empIdCounter, new PermanentEmployee(empIdCounter++, "Santhosh", "HR", 50000, new DateTime(2021, 8, 1), true, 20)},
            {empIdCounter, new ContractEmployee(empIdCounter++, "Karthik", "IT", 40000, 12, true)},
            {empIdCounter, new ContractEmployee(empIdCounter++, "Felix", "Marketing", 35000, 6, false)}
        };

        //object creation for printing Elements
        PrintingClass print = new PrintingClass();

        //object creation for input Handle
        InputHandle input = new InputHandle();

        //Adding Permanenent Employee
        public void addPermanentEmp()
        {
            string check;
            do
            {
                Console.Write("Enter the Employee Name: ");
                string EmpName = Console.ReadLine();

                Console.Write("Enter the Department Name: ");
                string Department = Console.ReadLine();


                Console.WriteLine("Enter salary:");
                string inputStr = Console.ReadLine();
                double Salary = input.DoubleCheck(inputStr);


                Console.Write("Enter the Joining Date (yyyy-mm-dd): ");
                string inputstringdate = Console.ReadLine();
                DateTime JoiningDate = input.DateTimeCheck(inputstringdate);
                

                Console.Write("Has Insurance Coverage (true/false): ");
                string inputstring = Console.ReadLine();
                bool HasInsuranceCoverage = input.BoolCheck(inputstring);

                Console.Write("Enter Leave Encashment Balance: ");
                string inputStr2 = Console.ReadLine();
                int LeaveEncashmentBalance = input.IntCheck(inputStr2);
                

                PermanentEmployee newEmp = new PermanentEmployee(empIdCounter, EmpName, Department, Salary,
                    JoiningDate, HasInsuranceCoverage, LeaveEncashmentBalance);

                EmpDetails[empIdCounter] = newEmp;
                Console.WriteLine($"Permanent Employee Added Successfully with ID: {empIdCounter}");

                empIdCounter++;

                Console.WriteLine();
                print.PrintAllEmployees();
                Console.WriteLine();

                Console.Write("Do you want to add another New Employee (yes/no) : ");
                check = Console.ReadLine().Trim().ToLower();
            } while (check == "yes");

        }


        //Adding contract Employee
        public void addContractEmp()
        {
            string check;
            do
            {
                Console.Write("Enter the Employee Name: ");
                string EmpName = Console.ReadLine();

                Console.Write("Enter the Department Name: ");
                string Department = Console.ReadLine();


                Console.WriteLine("Enter salary:");
                string inputStr = Console.ReadLine();
                double Salary = input.DoubleCheck(inputStr);

                Console.Write("Enter Contract Duration in Months: ");
                string inputstring = Console.ReadLine();
                int ContractDurationMonths = input.IntCheck(inputStr);

                Console.Write("Is the Employee Working Remotely? (true/false): ");
                string inputstring2 = Console.ReadLine();
                bool IsRemote = input.BoolCheck(inputstring2);
                

                ContractEmployee newEmp = new ContractEmployee(empIdCounter, EmpName, Department, Salary,
                    ContractDurationMonths, IsRemote);

                EmpDetails[empIdCounter] = newEmp;

                Console.WriteLine($"Contract Employee Added Successfully with ID: {empIdCounter}");

                empIdCounter++;

                Console.WriteLine();
                print.PrintAllEmployees();
                Console.WriteLine();

                Console.Write("Do you want to add another New Employee (yes/no) : ");
                check = Console.ReadLine().Trim().ToLower();
            } while (check == "yes");

        }

        //Remove Employee using empId
        public void removeEmp()
        {
            string check;
            do
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
                if (EmpDetails.ContainsKey(removeId))
                {
                    EmpDetails.Remove(removeId);
                    Console.WriteLine("Removed Employee Succesfully");
                    break;
                }
                else
                {
                    Console.WriteLine("EmpId not found.");
                    Console.WriteLine();
                }
                Console.Write("Do you want to try agian (yes/no) : ");
                check = Console.ReadLine().Trim().ToLower();
            } while (check == "yes");


            Console.WriteLine();
            print.PrintAllEmployees();
            Console.WriteLine();
        }
    }
}
