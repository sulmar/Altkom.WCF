using System;
using System.Runtime.Serialization;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class FullTimeEmployee : Employee
    {
        public decimal AnnualSalary { get; set; }
    }

    public class PartTimeEmployee : Employee
    {
        public decimal HourlyPay { get; set; }
    }
}
