using Application.Elderlies.Queries;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class GetAllElderliesHandler : IRequestHandler<GetAllElderliesQuery, List<Elderly>>
    {
        private readonly IElderlyRepository _repository;

        public GetAllElderliesHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Elderly>> Handle(GetAllElderliesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllElderlies();
        }
    }

}
