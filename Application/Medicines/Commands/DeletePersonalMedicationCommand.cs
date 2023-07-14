using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Commands
{
    public class DeletePersonalMedicationCommand : IRequest<PersonalMedicationDTO>
    {
        public int Id { get; }

        public DeletePersonalMedicationCommand(int id)
        {
            Id = id;
        }
    }
}
