using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Commands
{
    public class CreatePersonalMedicationCommand : IRequest<PersonalMedicationDTO>
    {
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
    }
}
