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
            AddEmployeeTest();

        }

        private static void AddEmployeeTest()
        {
            Models.FullTimeEmployee employee = new Models.FullTimeEmployee
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                AnnualSalary = 100000m
            };

            string url = "http://localhost:8080/EmployeeService";

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<IEmployeeService> proxy = new ChannelFactory<IEmployeeService>(binding, endpoint);

            IEmployeeService client = proxy.CreateChannel();

            client.Add(employee);
        }
    }
}
