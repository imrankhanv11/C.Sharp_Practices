using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement
{
    internal class PrintingClass
    {

        //Printing all Employee
        public void PrintAllEmployees()
        {
            if (Operations.EmpDetails.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            int counter = 1;
            foreach (var entry in Operations.EmpDetails)
            {
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine($"Employee Serial NO. {counter}");
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

                counter++;
            }
        }

        //Printing only Permenent Employee
        public void PrintPerEmp()
        {
            if (Operations.EmpDetails.Count == 0)
            {
                Console.WriteLine("No employee found");
                return;
            }
            int counter = 1;
            foreach (var entry in Operations.EmpDetails)
            {
                if (entry.Value is PermanentEmployee pEmp)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Employee Serial NO. {counter}");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine($"Employee ID     : {entry.Key}");
                    Console.WriteLine($"Name            : {pEmp.Name}");
                    Console.WriteLine($"Department      : {pEmp.Department}");
                    Console.WriteLine($"Salary          : {pEmp.Salary}");
                    Console.WriteLine($"Joining Date    : {pEmp.JoiningDate.ToShortDateString()}");
                    Console.WriteLine($"Insurance       : {pEmp.HasInsuranceCoverage}");
                    Console.WriteLine($"Leave Balance   : {pEmp.LeaveEncashmentBalance}");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();

                    counter++;
                }
            }
            Console.WriteLine("Permenent Employee List is Details Over.");
            Console.WriteLine();
        }

        //Printing only Contract Employee
        public void PrintConEmp()
        {
            if (Operations.EmpDetails.Count == 0)
            {
                Console.WriteLine("No employee found");
                return;
            }
            int counter = 1;
            foreach (var Values in Operations.EmpDetails)
            {
                if (Values.Value is ContractEmployee cEmp)
                {
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"Employee Serial NO. {counter}");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine($"Employee ID     : {cEmp.EmpId}");
                    Console.WriteLine($"Name            : {cEmp.Name}");
                    Console.WriteLine($"Department      : {cEmp.Department}");
                    Console.WriteLine($"Salary          : {cEmp.Salary}");
                    Console.WriteLine($"Contract Months : {cEmp.ContractDurationMonths}");
                    Console.WriteLine($"Remote Worker   : {cEmp.IsRemote}");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine();

                    counter++;
                }
            }
            Console.WriteLine("Contract Employee List is Details Over.");
            Console.WriteLine();
        }
    }
}
