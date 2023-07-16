using Application.ElderlyMedications.Responses;
using Application.Helpers;
using MediatR;

namespace Application.Medicines.Queries
{
    public class GetAllElderlyMedicationsQuery : IRequest<PagedList<ElderlyMedicationResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}