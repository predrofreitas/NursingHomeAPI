using Application.Elderlies.Queries;
using Application.Elderlies.Responses;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class GetElderlyByIdQueryHandler : IRequestHandler<GetElderlyByIdQuery, ElderlyResponse>
    {
        private readonly IElderlyRepository _repository;

        public GetElderlyByIdQueryHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ElderlyResponse> Handle(GetElderlyByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetElderlyById(request.Id);
        }
    }
}