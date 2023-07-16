using Application.Elderlies.Queries;
using Application.Medicines.Commands;
using Application.Medicines.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NursingHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElderlyMedicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ElderlyMedicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedications(
            int page,
            int pageSize,
            string? searchTerm,
            string? sortColumn,
            string? sortOrder)
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

        [HttpGet("{id}")]
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

        [HttpPost]
        public async Task<IActionResult> CreateMedication(CreateElderlyMedicationCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound("Elderly not found.");
            }

            return CreatedAtAction(nameof(GetMedicationById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
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