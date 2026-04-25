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
        public async Task<IActionResult> GetMockiData()
        {
            MockiData result = await sender.Send(new GetMockiDataQuery());

            return Ok(result);
        }

        [HttpGet("joke")]
        public async Task<IActionResult> GetJoke()
        {
            JokeModel result = await sender.Send(new GetJokeQuery());

            return Ok(result);
        }
    }
}
