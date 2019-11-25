using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace IServices
{
    // add reference System.ServiceModel

    [ServiceContract]
    public interface ICompanyPublicService
    {
        [OperationContract]
        string GetPublicInformation();
    }
}
