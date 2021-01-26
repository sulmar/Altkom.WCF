using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DocumentServiceHost
{
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
