using Application.Medicines.Commands;
using Application.Medicines.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NursingHomeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ElderlyMedicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElderlyMedicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all medications with pagination, filtering and sorting options.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="searchTerm">Search term.</param>
        /// <param name="sortColumn">Column to sort by.</param>
        /// <param name="sortOrder">Sort order (asc or desc).</param>
        /// <returns>List of medications.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<ElderlyMedication>), 200)]
        public async Task<IActionResult> GetAllMedications(
            [FromQuery] int page,
            [FromQuery] int pageSize,
            [FromQuery] string searchTerm,
            [FromQuery] string sortColumn,
            [FromQuery] string sortOrder)
        {
            var query = new GetAllElderlyMedicationsQuery
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
        /// Get a medication by its ID.
        /// </summary>
        /// <param name="id">Medication ID.</param>
        /// <returns>The medication.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ElderlyMedication), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetMedicationById(int id)
        {
            var query = new GetElderlyMedicationByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Create a new medication.
        /// </summary>
        /// <param name="command">Create medication command.</param>
        /// <returns>The created medication.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ElderlyMedication), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateMedication(CreateElderlyMedicationCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound("Elderly not found.");
            }

            return CreatedAtAction(nameof(GetMedicationById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Delete a medication by its ID.
        /// </summary>
        /// <param name="id">Medication ID.</param>
        /// <returns>Success status.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteMedication(int id)
        {
            var command = new DeleteElderlyMedicationCommand(id);
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}