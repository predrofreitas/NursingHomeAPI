using Application.Medicines.Commands;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.ElderlyMedications.Handlers
{
    public class DeleteElderlyMedicationHandler : IRequestHandler<DeleteElderlyMedicationCommand, bool>
    {
        private readonly IElderlyMedicationRepository _repository;

        public DeleteElderlyMedicationHandler(IElderlyMedicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteElderlyMedicationCommand request, CancellationToken cancellationToken)
        {
            bool result = await _repository.DeleteMedication(request.Id);

            return result;
        }
    }
}