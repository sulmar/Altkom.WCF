using System;
using System.Collections.Generic;
using System.Linq;
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
}
