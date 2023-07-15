using Application.ElderlyMedications.Responses;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetElderlyMedicationByIdQuery : IRequest<ElderlyMedicationResponse>
    {
        public int Id { get; }

        public GetElderlyMedicationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
