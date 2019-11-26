using IServices;
using System;
using System.Linq;
using System.ServiceModel.Web;
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
            if (!IsValid(request.LicenseKey))
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Forbidden;
                return null;
            }

            Employee employee = employeeRepository.Get(request.EmployeeId);
            return new EmployeeResponse(employee);

        }

        private bool IsValid(string licenseKey)
        {
            return false;
        }
    }
}
