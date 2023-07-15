using Application.Elderlies.Responses;
using MediatR;

namespace Application.Elderlies.Queries
{
    public class GetAllElderliesQuery : IRequest<List<ElderlyResponse>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}