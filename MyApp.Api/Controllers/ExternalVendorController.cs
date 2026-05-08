using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Queries;
using MyApp.Core.Models;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController(ISender sender) : ControllerBase
    {
        [HttpGet("")]
        [ProducesResponseType(typeof(MockiData), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> GetMockiData(CancellationToken cancellationToken)
        {
            MockiData result = await sender.Send(new GetMockiDataQuery(), cancellationToken);

            return Ok(result);
        }

        [HttpGet("joke")]
        [ProducesResponseType(typeof(JokeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status502BadGateway)]
        public async Task<IActionResult> GetJoke(CancellationToken cancellationToken)
        {
            JokeModel result = await sender.Send(new GetJokeQuery(), cancellationToken);

            return Ok(result);
        }
    }
}
