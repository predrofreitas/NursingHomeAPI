using Application.Elderlies.Commands;
using Application.Elderlies.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NursingHomeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ElderlyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElderlyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all elderly records with pagination and sorting options.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="searchTerm">Search term.</param>
        /// <param name="sortColumn">Column to sort by.</param>
        /// <param name="sortOrder">Sort order (asc or desc).</param>
        /// <returns>List of elderly records.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Elderly>), 200)]
        public async Task<IActionResult> GetAllElderlies(
            [FromQuery] int page,
            [FromQuery] int pageSize,
            [FromQuery] string searchTerm,
            [FromQuery] string sortColumn,
            [FromQuery] string sortOrder)
        {
            var query = new GetAllElderliesQuery
            {
                Page = page,
                PageSize = pageSize,
                SearchTerm = searchTerm,
                SortColumn = sortColumn,
                SortOrder = sortOrder
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Get an elderly record by ID.
        /// </summary>
        /// <param name="id">Elderly ID.</param>
        /// <returns>The elderly record.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Elderly), 200)]
        [ProducesResponseType(404)]
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

        /// <summary>
        /// Create a new elderly record.
        /// </summary>
        /// <param name="command">Create elderly command.</param>
        /// <returns>The created elderly record.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Elderly), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateElderly(CreateElderlyCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetElderlyById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Update an existing elderly record.
        /// </summary>
        /// <param name="id">Elderly ID.</param>
        /// <param name="command">Update elderly command.</param>
        /// <returns>Success status.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateElderly(int id, UpdateElderlyCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Delete an elderly record by ID.
        /// </summary>
        /// <param name="id">Elderly ID.</param>
        /// <returns>Success status.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteElderly(int id)
        {
            var command = new DeleteElderlyCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
