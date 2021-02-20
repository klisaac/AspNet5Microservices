using MediatR;
using Microservice.Api2.Application.Responses;

namespace Microservice.Api2.Application.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeResponse>
    {
        public int EmployeeId { get; }
        public  GetEmployeeByIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
