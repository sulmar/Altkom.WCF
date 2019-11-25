using System.ServiceModel;

namespace IServices
{
    [ServiceContract]
    public interface ICompanyConfidentialService
    {
        [OperationContract]
        string GetConfidentialInformation();
    }
}
