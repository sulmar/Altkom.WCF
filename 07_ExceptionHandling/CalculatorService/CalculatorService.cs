using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorService
{
    public class CalculatorService : ICalculatorService
    {
        public int Divide(int numerator, int denominator)
        {
            return numerator / denominator;
        }
    }
}
