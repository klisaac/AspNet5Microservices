using System.Collections.Generic;
using MediatR;
using Microservice.Api2.Application.Responses;

namespace Microservice.Api2.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeResponse>>
    {
        public GetAllEmployeesQuery()
        {
        }
    }
}
