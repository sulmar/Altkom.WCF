using IServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CompanyServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPublicInformationTest();
            GetConfidentialInformationTest();

        }

        private static void GetPublicInformationTest()
        {
            string url = ConfigurationManager.AppSettings["public-url"];

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<ICompanyPublicService> proxy = new ChannelFactory<ICompanyPublicService>(binding, endpoint);

            ICompanyPublicService client = proxy.CreateChannel();

            string result = client.GetPublicInformation();

            Console.WriteLine(result);
        }

        private static void GetConfidentialInformationTest()
        {
            string url = ConfigurationManager.AppSettings["confidential-url"];

            NetTcpBinding binding = new NetTcpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<ICompanyConfidentialService> proxy = new ChannelFactory<ICompanyConfidentialService>(binding, endpoint);

            ICompanyConfidentialService client = proxy.CreateChannel();

            string result = client.GetConfidentialInformation();

            Console.WriteLine(result);
        }

    }
}
