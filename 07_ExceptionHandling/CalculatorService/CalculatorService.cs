using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
   // [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                DivideByZeroFault divideByZeroFault = new DivideByZeroFault
                {
                    Error = "Dzielenie przez 0",
                    Details = "Nastąpila proba dzielenia przez zero"
                };

                FaultReason reason = new FaultReason("Nieprawidlowy mianownik");

                throw new FaultException<DivideByZeroFault>(divideByZeroFault, reason);
            }
           
            return numerator / denominator;
            
        }
    }
}
