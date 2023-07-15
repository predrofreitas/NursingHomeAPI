using Application.Elderlies.Queries;
using Application.Elderlies.Responses;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class GetAllElderliesHandler : IRequestHandler<GetAllElderliesQuery, List<ElderlyResponse>>
    {
        private readonly IElderlyRepository _repository;

        public GetAllElderliesHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ElderlyResponse>> Handle(GetAllElderliesQuery request, CancellationToken cancellationToken)
        {
            var elderlies = await _repository.GetAllElderlies(request.Page, request.PageSize, request.SearchTerm, request.SortColumn, request.SortOrder);
            return elderlies.Select(elderly => (ElderlyResponse)elderly).ToList();
        }
    }
}