using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.ServiceBus;
using Microservice.Api2.Core.Configuration;
using Microservice.Api2.Core.Repository;
using Microservice.Api2.Core.Repository.Base;
using Microservice.Api2.Infrastructure.Repository;
using Microservice.Api2.Infrastructure.Repository.Base;
using Microservice.Api2.Infrastructure.Data;
using Microservice.Api2.Core.ServiceBusMessaging;
using Microservice.Api2.Infrastructure.ServiceBusMessaging;

namespace Microservice.Api2.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // repositories
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //database configuration
            services.AddDbContext<Api1Context>(c => c.UseSqlServer(configuration.GetSection(nameof(SqlDatabase)).Get<SqlDatabase>().ConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped);

            //seed data
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dataContext = scopedServices.GetRequiredService<Api1Context>();
                dataContext.Database.Migrate();
                dataContext.Database.EnsureCreated();
                SeedData.SeedAsync(dataContext).Wait();
            }

            //ServiceBus messaging
            var azureServiceBus = configuration.GetSection(nameof(AzureServiceBus)).Get<AzureServiceBus>();
            services.AddScoped<ITopicClient>(serviceProvider => new TopicClient(connectionString: azureServiceBus.ConnectionString, entityPath: azureServiceBus.TopicName));
            services.AddScoped<IMessagePublisher, MessagePublisher>();

            return services;
        }
    }
}
