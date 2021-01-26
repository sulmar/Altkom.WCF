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
