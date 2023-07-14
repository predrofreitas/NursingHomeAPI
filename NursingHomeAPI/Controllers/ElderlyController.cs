using Application.Elderlies.Commands;
using Application.Elderlies.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ElderlyController : ControllerBase
{
    private readonly IMediator _mediator;

    public ElderlyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllElderlies()
    {
        var query = new GetAllElderliesQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetElderlyById(int id)
    {
        var query = new GetElderlyByIdQuery(id);
        var result = await _mediator.Send(query);

        if (result is null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateElderly(CreateElderlyCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetElderlyById), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateElderly(int id, UpdateElderlyCommand command)
    {
        command.Id = id;
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteElderly(int id)
    {
        var command = new DeleteElderlyCommand(id);
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return NotFound();
        }

        return NoContent();
    }
}