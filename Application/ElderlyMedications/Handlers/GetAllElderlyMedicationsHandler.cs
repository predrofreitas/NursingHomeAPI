using Application.Elderlies.Responses;
using Application.ElderlyMedications.Responses;
using Application.Medicines.Queries;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.ElderlyMedications.Handlers
{
    public class GetAllElderlyMedicationsHandler : IRequestHandler<GetAllElderlyMedicationsQuery, List<ElderlyMedicationResponse>>
    {
        private readonly IElderlyMedicationRepository _repository;

        public GetAllElderlyMedicationsHandler(IElderlyMedicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ElderlyMedicationResponse>> Handle(GetAllElderlyMedicationsQuery request, CancellationToken cancellationToken)
        {
            var elderlyMedications = await _repository.GetAllMedications();

            return elderlyMedications.Select(elderlyMedication => (ElderlyMedicationResponse)elderlyMedication).ToList();
        }
    }
}