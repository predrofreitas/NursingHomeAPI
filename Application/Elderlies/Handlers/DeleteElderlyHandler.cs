using Application.Elderlies.Commands;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class DeleteElderlyHandler : IRequestHandler<DeleteElderlyCommand, bool>
    {
        private readonly IElderlyRepository _repository;

        public DeleteElderlyHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteElderlyCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteElderly(request.Id);
        }
    }

}
