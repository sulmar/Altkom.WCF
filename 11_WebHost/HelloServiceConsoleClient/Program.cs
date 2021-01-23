using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            AltkomServiceReference.IHelloService client = new AltkomServiceReference.HelloServiceClient();

            string result = client.Hello("Hello world!");

            Console.WriteLine(result);
        }
    }
}
