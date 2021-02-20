using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Api2.Core.Models.Entities;
using Microservice.Api2.Infrastructure.Data;
using Microservice.Api2.Core.Repository;
using Microservice.Api2.Core.Specifications.Base;
using Microservice.Api2.Infrastructure.Repository.Base;

namespace Microservice.Api2.Infrastructure.Repository
{ 
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Api1Context dataContext)
            : base(dataContext) {}

        public async Task<IEnumerable<Employee>> SearchEmployeesAsync(ISpecification<Employee> specification)
        {
            return await GetAsync(specification);
        }
    }
}