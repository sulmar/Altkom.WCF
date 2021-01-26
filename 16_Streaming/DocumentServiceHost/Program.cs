using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DocumentServiceHost
{

    // https://docs.microsoft.com/pl-pl/dotnet/framework/wcf/feature-details/how-to-enable-streaming
    // https://www.c-sharpcorner.com/uploadfile/afenster/wcf-streaming-large-data-files/
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var serviceHost = new ServiceHost(typeof(DocumentServices.DocumentService)))
                {
                    //NetTcpBinding binding = new NetTcpBinding();
                    //binding.Security.Mode = SecurityMode.None;
                    
                    //serviceHost.AddServiceEndpoint(typeof(DocumentServices.IDocumentService), binding, "net.tcp://localhost:9000/streamserver");

                    Console.WriteLine("Host started on");

                    foreach (var uri in serviceHost.BaseAddresses)
                    {
                        Console.WriteLine(uri);
                    }

                    serviceHost.Open();

                    Console.WriteLine("Press Enter to exit.");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
