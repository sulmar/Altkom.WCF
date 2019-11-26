using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/CalculatorService";

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<ICalculatorService> proxy = new ChannelFactory<ICalculatorService>(binding, endpoint);

            ICalculatorService client = proxy.CreateChannel();

            while (true)
            {
                Console.Write("Type numerator: ");

                if (int.TryParse(Console.ReadLine(), out int numerator))
                {
                    Console.Write("Type denominator: ");

                    if (int.TryParse(Console.ReadLine(), out int denominator))
                    {
                        try
                        {
                            int result = client.Divide(numerator, denominator);
                            Console.WriteLine($"Result: {result}");
                        }
                        catch (FaultException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            }

        }

        
    }
}
