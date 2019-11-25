using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RemotingServiceConsoleClient
{
    // add reference System.Runtime.Remoting
    class Program
    {
        static void Main(string[] args)
        {
            IServices.IHelloRemotingService client;

            TcpChannel channel = new TcpChannel();
            ChannelServices.RegisterChannel(channel);

            client = (IServices.IHelloRemotingService)
                Activator.GetObject(typeof(IServices.IHelloRemotingService), "tcp://localhost:8080/Ping");

            while (true)
            {
                string response = client.Ping("Hello");
                Console.WriteLine(response);

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
    }
}
