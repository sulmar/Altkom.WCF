using IServices;

namespace HelloService
{
    public class HelloService : IHelloService
    {
        public string Ping(string message)
        {
            return message;
        }

        public void Send(string content)
        {
            
        }
    }
}
