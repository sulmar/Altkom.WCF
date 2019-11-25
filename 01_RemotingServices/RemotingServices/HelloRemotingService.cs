using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServices
{
    public class HelloRemotingService : MarshalByRefObject, IHelloRemotingService
    {
        public string Ping(string message)
        {
            return message;
        }

        public string Ping()
        {
            return "Pong";
        }
    }
}
