using IServices;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService()
            : this(new EmployeeRepository() )
        {
        }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public EmployeeResponse Get(EmployeeRequest request)
        {
            Employee employee = employeeRepository.Get(request.EmployeeId);
            return new EmployeeResponse(employee);

        }
    }
}
