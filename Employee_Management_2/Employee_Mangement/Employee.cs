using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Mangement
{
    //Base class for Employee
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

    //Inherited class for Permanent Employee
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

    //Inherited class for Contract Employee
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
