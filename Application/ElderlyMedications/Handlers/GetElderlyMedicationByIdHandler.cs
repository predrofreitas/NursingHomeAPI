using Application.ElderlyMedications.Responses;
using Application.Medicines.Queries;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.ElderlyMedications.Handlers
{
    public class GetElderlyMedicationByIdQueryHandler : IRequestHandler<GetElderlyMedicationByIdQuery, ElderlyMedicationResponse>
    {
        private readonly IElderlyMedicationRepository _repository;

        public GetElderlyMedicationByIdQueryHandler(IElderlyMedicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ElderlyMedicationResponse> Handle(GetElderlyMedicationByIdQuery request, CancellationToken cancellationToken)
        {
            var elderlyMedication = await _repository.GetMedicationById(request.Id);

            return elderlyMedication;
        }
    }
}