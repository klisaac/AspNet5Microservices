using System.Threading.Tasks;

namespace Microservice.Api2.Core.ServiceBusMessaging
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T request);
    }
}
