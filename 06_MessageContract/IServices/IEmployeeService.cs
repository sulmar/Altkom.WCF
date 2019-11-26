using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        EmployeeResponse Get(EmployeeRequest request);
    }

    [MessageContract]
    public class EmployeeRequest
    {
        [MessageHeader(Namespace = "http://altkom.pl")]
        public string LicenseKey { get; set; }

        [MessageBodyMember(Namespace = "http://altkom.pl")]
        public int EmployeeId { get; set; }
    }

    [MessageContract(IsWrapped = true, WrapperName ="EmployeeResponse", WrapperNamespace ="http://altkom.pl")]
    public class EmployeeResponse
    {
        [MessageBodyMember(Order = 1)]
        public int Id { get; set; }

        [MessageBodyMember(Order = 2)] 
        public string FirstName { get; set; }

        [MessageBodyMember(Order = 3)] 
        public string LastName { get; set; }


        public EmployeeResponse()
        {

        }

        public EmployeeResponse(Employee employee)
        {
            this.Id = employee.Id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}
