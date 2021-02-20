using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microservice.Api2.Core.Configuration;
using Microservice.Api2.Core.Repository;
using Microservice.Api2.Core.Repository.Base;
using Microservice.Api2.Infrastructure.Repository;
using Microservice.Api2.Infrastructure.Repository.Base;
using Microservice.Api2.Infrastructure.Data;

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
            services.AddDbContext<Api2Context>(c => c.UseSqlServer(configuration.GetSection(nameof(SqlDatabase)).Get<SqlDatabase>().ConnectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Scoped);

            //seed data
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var dataContext = scopedServices.GetRequiredService<Api2Context>();
                dataContext.Database.Migrate();
                dataContext.Database.EnsureCreated();
                SeedData.SeedAsync(dataContext).Wait();
            }

            return services;
        }
    }
}
