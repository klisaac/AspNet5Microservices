
using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice.Api2.Core.Repository.Base;
using Microservice.Api2.Core.Models.Entities;
using Microservice.Api2.Core.Specifications.Base;

namespace Microservice.Api2.Core.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>> SearchEmployeesAsync(ISpecification<Employee> specification);
    }
}
