using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;


// add reference System.Runtime.Remoting
namespace RemotingServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;

            RemotingServices.HelloRemotingService remotingService = new RemotingServices.HelloRemotingService();

            TcpChannel channel = new TcpChannel(port);
            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingServices.HelloRemotingService), "Ping", WellKnownObjectMode.Singleton);

            Console.WriteLine($"Remoting service started on {port}");
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
