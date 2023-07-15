using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetPersonalMedicationByIdQuery : IRequest<MedicationDTO>
    {
        public int Id { get; }

        public GetPersonalMedicationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
