using Application.Actors.Create;
using Application.Actors.Get;
using Microsoft.AspNetCore.Mvc;

namespace MovieWebApi.Controllers;

[ApiController]
[Route("actor/")]
public class ActorsController : ControllerBase
{
    [HttpGet("")]
    public async Task<IActionResult> GetActors(ISender sender, [FromQuery] GetActorsQuery query)
    {
        var result = await sender.Send(query);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value());
    }

    [HttpGet("{actorId}")]
    public async Task<IActionResult> GetActor(int actorId, ISender sender)
    {
        var result = await sender.Send(new GetActorQuery(actorId));

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value());
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateActor([FromBody] CreateActorCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value());
    }
}
