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
using Microservice.Api2.Core.ServiceBusMessaging;
using Microservice.Api2.Core.Models.ServiceBus;

namespace Microservice.Api2.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeComannd , EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMessagePublisher _messagePublisher;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, ILogger<CreateEmployeeCommandHandler> logger, IMapper mapper, IMessagePublisher messagePublisher)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
            _messagePublisher = messagePublisher;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeComannd  request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.AddAsync(_mapper.Map<Employee>(request));
            _logger.LogInformation($"Employee { JsonConvert.SerializeObject(employee)} added to the database.");

              var employeePayload = _mapper.Map<EmployeePayload>(employee);
            await _messagePublisher.PublishAsync(employeePayload);
            _logger.LogInformation($"Employee { JsonConvert.SerializeObject(employeePayload)} published to the service bus.");

            return _mapper.Map<EmployeeResponse>(employee);
        }
    }
}