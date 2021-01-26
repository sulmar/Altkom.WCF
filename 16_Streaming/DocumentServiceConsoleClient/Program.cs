using DocumentServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DocumentServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/DocumentService";

            BasicHttpBinding binding = new BasicHttpBinding();

            //NetTcpBinding binding = new NetTcpBinding();
            //binding.Security.Mode = SecurityMode.None;

            // Create the address string, or get it from configuration.
            // string url = "net.tcp://localhost:9000/streamserver";

            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<IDocumentService> proxy = new ChannelFactory<IDocumentService>(binding, endpoint);

            IDocumentService client = proxy.CreateChannel();

            var result = client.Ping();

            Console.WriteLine(result);

            Stream stream = client.GetLargeDocument();

            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(stream);

            stream.Dispose();
            memoryStream.Dispose();


        }
    }
}
