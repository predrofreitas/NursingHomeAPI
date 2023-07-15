using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Queries
{
    public class GetAllElderliesQuery : IRequest<List<Elderly>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}
