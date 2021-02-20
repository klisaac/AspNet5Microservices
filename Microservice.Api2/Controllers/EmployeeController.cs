using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microservice.Api2.Application.Commands;
using Microservice.Api2.Application.Queries;
using Microservice.Api2.Application.Responses;

namespace Microservice.Api2.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route ("api/[controller]")]
    //[Authorize()]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRepository"></param>
        /// <param name="mapper"></param>
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getById/{id:int}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetEmployeeByIdQuery(id)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getAll")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeResponse>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllEmployeesQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(EmployeeResponse) , StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create ([FromBody]CreateEmployeeComannd  request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
