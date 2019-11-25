using IServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private ICollection<Employee> employees;

        public EmployeeService()
        {
            employees = new List<Employee>();
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
