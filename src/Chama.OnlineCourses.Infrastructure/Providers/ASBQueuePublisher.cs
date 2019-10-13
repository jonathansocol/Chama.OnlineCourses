using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Infrastructure.Providers
{
    public class ASBQueuePublisher : IServiceBusPublisher
    {
        private QueueClient _client;

        public ASBQueuePublisher(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("AzureServiceBus:ConnectionString").Value ??
                throw new ArgumentNullException("ConnectionString");

            _client = new QueueClient(new ServiceBusConnectionStringBuilder(connectionString));
        }

        public async Task SendMessage(object message)
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            await _client.SendAsync(new Message(Encoding.UTF8.GetBytes(serializedMessage)));
        }
    }
}
