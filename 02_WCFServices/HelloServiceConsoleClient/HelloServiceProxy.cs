using HelloService;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HelloServiceConsoleClient
{
    public class HelloServiceProxy : ClientBase<IHelloService>, IHelloService
    {
        public HelloServiceProxy(string endpointConfigurationName) 
            : base(endpointConfigurationName)
        {
        }

        public string Ping(string message)
        {
            return base.Channel.Ping(message);
        }

        public void Send(string content)
        {
            base.Channel.Send(content);
        }
    }
}
