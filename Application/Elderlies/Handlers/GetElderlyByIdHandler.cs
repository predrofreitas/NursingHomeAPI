using Application.Elderlies.Queries;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class GetElderlyByIdQueryHandler : IRequestHandler<GetElderlyByIdQuery, Elderly>
    {
        private readonly IElderlyRepository _repository;

        public GetElderlyByIdQueryHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Elderly> Handle(GetElderlyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetElderlyById(request.Id);
        }
    }
}
