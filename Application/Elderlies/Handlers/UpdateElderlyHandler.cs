using Application.Elderlies.Commands;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class UpdateElderlyHandler : IRequestHandler<UpdateElderlyCommand, bool>
    {
        private readonly IElderlyRepository _repository;

        public UpdateElderlyHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateElderlyCommand request, CancellationToken cancellationToken)
        {
            var elderly = await _repository.GetElderlyById(request.Id);

            if (elderly is null)
            {
                return false;
            }

            elderly.Name = request.Name;
            elderly.DateOfBirth = request.DateOfBirth;
            elderly.Gender = request.Gender;
            elderly.Address = request.Address;

            return await _repository.UpdateElderly(elderly);
        }
    }
}
