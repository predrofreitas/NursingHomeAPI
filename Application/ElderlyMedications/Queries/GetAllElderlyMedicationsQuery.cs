using Application.ElderlyMedications.Responses;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetAllElderlyMedicationsQuery : IRequest<List<ElderlyMedicationResponse>>
    {
        public GetAllElderlyMedicationsQuery() { }
    }
}
