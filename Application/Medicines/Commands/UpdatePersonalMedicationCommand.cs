using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Commands
{
    public class UpdatePersonalMedicationCommand : IRequest<PersonalMedicationDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }
}
