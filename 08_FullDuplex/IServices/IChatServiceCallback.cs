using System.ServiceModel;

namespace IServices
{
    public interface IChatServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnReceive(string username, string message);
    }
}
