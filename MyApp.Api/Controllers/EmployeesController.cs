using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Commands;
using MyApp.Application.Dtos;
using MyApp.Application.Queries;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] CreateEmployeeRequest request,
            CancellationToken cancellationToken)
        {
            EmployeeDto result = await sender.Send(new AddEmployeeCommand(request), cancellationToken);

            return CreatedAtRoute(nameof(GetEmployeeByIdAsync), new { employeeId = result.Id }, result);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEmployeesAsync(CancellationToken cancellationToken)
        {
            IEnumerable<EmployeeDto> result =
                await sender.Send(new GetAllEmployeesQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("{employeeId:guid}", Name = nameof(GetEmployeeByIdAsync))]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmployeeByIdAsync([FromRoute] Guid employeeId,
            CancellationToken cancellationToken)
        {
            EmployeeDto? result = await sender.Send(new GetEmployeeByIdQuery(employeeId), cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{employeeId:guid}")]
        [ProducesResponseType(typeof(EmployeeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEmployeeAsync([FromRoute] Guid employeeId,
            [FromBody] UpdateEmployeeRequest employee, CancellationToken cancellationToken)
        {
            EmployeeDto? result =
                await sender.Send(new UpdateEmployeeCommand(employeeId, employee), cancellationToken);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{employeeId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEmployeeAsync([FromRoute] Guid employeeId,
            CancellationToken cancellationToken)
        {
            bool deleted = await sender.Send(new DeleteEmployeeCommand(employeeId), cancellationToken);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
