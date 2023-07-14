using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetPersonalMedicationByIdQuery : IRequest<PersonalMedicationDTO>
    {
        public int Id { get; }

        public GetPersonalMedicationByIdQuery(int id)
        {
            Id = id;
        }
    }
}
