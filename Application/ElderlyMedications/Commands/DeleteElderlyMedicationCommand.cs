using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Commands
{
    public class DeleteElderlyMedicationCommand : IRequest<MedicationDTO>
    {
        public int Id { get; }

        public DeleteElderlyMedicationCommand(int id)
        {
            Id = id;
        }
    }
}
