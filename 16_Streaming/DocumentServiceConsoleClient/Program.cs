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
            EndpointAddress endpoint = new EndpointAddress(url);

            ChannelFactory<IDocumentService> proxy = new ChannelFactory<IDocumentService>(binding, endpoint);

            IDocumentService client = proxy.CreateChannel();

            Stream stream = client.GetLargeDocument();

            MemoryStream memoryStream = new MemoryStream();
            stream.CopyTo(stream);

            stream.Dispose();
            memoryStream.Dispose();


        }
    }
}
