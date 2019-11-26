using Bogus;
using IServices;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeService
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private ICollection<Employee> employees;

        public EmployeeRepository()
        {
            employees = new Faker<Employee>()
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(50))
                .Generate(50);
        }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }

        public Employee Get(int id)
        {
            return employees.SingleOrDefault(e => e.Id == id);
        }
    }
}
