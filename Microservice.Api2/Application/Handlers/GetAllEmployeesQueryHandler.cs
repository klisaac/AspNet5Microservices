using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using Microservice.Api2.Application.Queries;
using Microservice.Api2.Core.Repository;
using Microservice.Api2.Application.Responses;

namespace Microservice.Api2.Application.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeResponse>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<EmployeeResponse>>(await _employeeRepository.GetAllAsync());
        }
    }
}
