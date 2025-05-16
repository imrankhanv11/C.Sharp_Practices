using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling_WithOops
{
    public class Employee
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

    public class PermanentEmployee : Employee
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
    public class ContractEmployee : Employee
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
