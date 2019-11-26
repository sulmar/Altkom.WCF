using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/EmployeeService";

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<IEmployeeService> proxy = new ChannelFactory<IEmployeeService>(binding, endpoint);

            IEmployeeService client = proxy.CreateChannel();

            EmployeeRequest request = new EmployeeRequest
            {
                EmployeeId = 1,
                LicenseKey = "your_license_key"
            };

            EmployeeResponse response = client.Get(request);

            Console.WriteLine($"{response.FirstName} {response.LastName}");
        }
    }
}
