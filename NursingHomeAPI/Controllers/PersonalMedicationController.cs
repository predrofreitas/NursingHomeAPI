using Application.Medicines.Commands;
using Application.Medicines.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NursingHomeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalMedicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalMedicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMedications()
        {
            var query = new GetAllPersonalMedicationsQuery();
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicationById(int id)
        {
            var query = new GetPersonalMedicationByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedication(CreatePersonalMedicationCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetMedicationById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMedication(int id, UpdatePersonalMedicationCommand command)
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
        public async Task<IActionResult> DeleteMedication(int id)
        {
            var command = new DeletePersonalMedicationCommand(id);
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
