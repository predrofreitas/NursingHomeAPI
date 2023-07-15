using Application.Medicines.DTOs;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetAllPersonalMedicationsQuery : IRequest<List<MedicationDTO>>
    {
        public GetAllPersonalMedicationsQuery() { }
    }
}
