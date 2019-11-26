using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServiceConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/ChatService";

            WSDualHttpBinding binding = new WSDualHttpBinding();
            EndpointAddress endpoint = new EndpointAddress(url);

            InstanceContext context = new InstanceContext(new ConsoleCallback());

            DuplexChannelFactory<IChatService> channelFactory = new DuplexChannelFactory<IChatService>(context, binding, endpoint);

            IChatService client = channelFactory.CreateChannel();

            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            client.Join(username);

            Console.WriteLine("Enter message or (q)uit: ");
            string message = Console.ReadLine();

            while(message != "q")
            {
                client.Send(message);
                message = Console.ReadLine();
            }
        }
    }

    internal class ConsoleCallback : IChatServiceCallback
    {
        public void OnReceive(string username, string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{username}] {message}");
            Console.ResetColor();
        }
    }
}
