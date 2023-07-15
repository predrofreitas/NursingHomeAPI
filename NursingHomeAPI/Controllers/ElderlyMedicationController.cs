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
        public async Task<IActionResult> GetAllMedications()
        {
            var query = new GetAllElderlyMedicationsQuery();
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