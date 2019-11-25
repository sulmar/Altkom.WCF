using Models;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    //[ServiceKnownType(typeof(FullTimeEmployee))]
    //[ServiceKnownType(typeof(PartTimeEmployee))]

    [ServiceContract]
    public interface IEmployeeService
    {
        [ServiceKnownType(typeof(FullTimeEmployee))]
        [ServiceKnownType(typeof(PartTimeEmployee))]
        [OperationContract]
        void Add(Employee employee);

        [OperationContract]
        Employee Get(int id);

    }
}
