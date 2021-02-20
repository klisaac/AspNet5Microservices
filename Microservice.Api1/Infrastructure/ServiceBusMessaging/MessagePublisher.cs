using System.Text;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Microservice.Api2.Core.ServiceBusMessaging;

namespace Microservice.Api2.Infrastructure.ServiceBusMessaging
{
    public class MessagePublisher : IMessagePublisher 
    {
        private readonly ITopicClient _topicClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<MessagePublisher> _logger;

        public MessagePublisher(ITopicClient topicClient, IConfiguration configuration, ILogger<MessagePublisher> logger)
        {
            _topicClient = topicClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task PublishAsync<T>(T request)
        {
            try
            {
                var message = new Message
                {
                    MessageId = Guid.NewGuid().ToString(),
                    ContentType = "application/json",
                    Label = typeof(T).Name,
                    Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request))
                };
                message.UserProperties.Add("MessageApplication", "Microservice.Api1");
                message.UserProperties.Add("MessagePayload", typeof(T).Name);
                await _topicClient.SendAsync(message);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                await _topicClient.CloseAsync();
            }
        }
    }
}
