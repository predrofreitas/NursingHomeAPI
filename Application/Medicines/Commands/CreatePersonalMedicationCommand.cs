using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Commands
{
    public class CreatePersonalMedicationCommand : IRequest<PersonalMedicationDTO>
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
