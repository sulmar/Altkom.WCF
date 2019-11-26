using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    [ServiceContract]
   
    public interface ICalculatorService
    {
        [OperationContract]
        int Divide(int numerator, int denominator);
    }

    [DataContract]
    public class DivideByZeroFault
    {
        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public string Details { get; set; }
    }
}
