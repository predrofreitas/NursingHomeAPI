using MediatR;

namespace Application.Medicines.Commands
{
    public class DeleteElderlyMedicationCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteElderlyMedicationCommand(int id)
        {
            Id = id;
        }
    }
}