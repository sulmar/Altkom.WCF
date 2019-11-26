using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ChatService : IChatService
    {
        private IDictionary<IChatServiceCallback, string> users = new Dictionary<IChatServiceCallback, string>();

        public void Join(string username)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();
            users.Add(connection, username);

            connection.OnReceive("Server", $"Welcome {username}");
        }

        public void Send(string message)
        {
            var connection = OperationContext.Current.GetCallbackChannel<IChatServiceCallback>();

            if (!users.TryGetValue(connection, out string username))
            {
                return;
            }

            foreach (var user in users.Keys)
            {
                if (user == connection)
                    continue;

                user.OnReceive(username, message);
            }
        }
    }
}
