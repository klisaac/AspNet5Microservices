using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Microservice.Api2.Application.Commands;
using Microservice.Api2.Core.Repository;
using Microservice.Api2.Core.Models.Entities;
using Microservice.Api2.Application.Responses;

namespace Microservice.Api2.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeComannd , EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeCommandHandler> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeComannd  request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.AddAsync(_mapper.Map<Employee>(request));
            _logger.LogInformation($"Employee { JsonConvert.SerializeObject(employee)} added to the database.");
            return _mapper.Map<EmployeeResponse>(employee);

            //var employee =_mapper.Map<Employee>(request);
            //employee.EmployeeId = 999999;
            //return await Task.Run(() => _mapper.Map<EmployeeResponse>(employee));
        }
    }
}