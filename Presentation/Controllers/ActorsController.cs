using Application.Actors.Create;
using Application.Actors.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("actor/")]
public class ActorsController : ControllerBase
{

    [HttpGet("")]
    public async Task<IActionResult> GetActors(string searchTerm, ISender sender)
    {
        var result = await sender.Send(new GetActorsQuery());

        return Ok();
    }

    [HttpGet("{actorId}")]
    public async Task<IActionResult> GetActor(int actorId, ISender sender)
    {
        var result = await sender.Send(new GetActorQuery(actorId));

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateActor([FromBody] CreateActorCommand command, ISender sender)
    {
        await sender.Send(command);

        return Ok();
    }
}
