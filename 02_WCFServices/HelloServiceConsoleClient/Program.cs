using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //PingTest();

            PingProxyTest();

            PingChannelFactoryTest();

        }

        private static void PingChannelFactoryTest()
        {
            string endpointConfigurationName = "BasicHttpBinding_IHelloService";

            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:8080/HelloService");

            //ChannelFactory<IHelloService> proxy = new ChannelFactory<IHelloService>(endpointConfigurationName);

            ChannelFactory<IHelloService> proxy = new ChannelFactory<IHelloService>(binding, endpoint);

            IHelloService client = proxy.CreateChannel();
            
            string result = client.Ping("Hello");
            Console.WriteLine(result);

            client.Send("World");
        }

        private static void PingProxyTest()
        {
            string endpointConfigurationName = "BasicHttpBinding_IHelloService";

            HelloServiceProxy client = new HelloServiceProxy(endpointConfigurationName);
            string result = client.Ping("Hello");
            Console.WriteLine(result);

            client.Send("World");
        }

        // Wygenerowana klasa Proxy
        private static void PingTest()
        {
            string endpointConfigurationName = "BasicHttpBinding_IHelloService";

            HelloService.HelloServiceClient client = new HelloService.HelloServiceClient(endpointConfigurationName);
            string result = client.Ping("Hello");
            Console.WriteLine(result);

            client.Send("World");
        }
    }
}
