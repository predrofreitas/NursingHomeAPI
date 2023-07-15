using Application.Elderlies.Commands;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class CreateElderlyHandler : IRequestHandler<CreateElderlyCommand, Elderly>
    {
        private readonly IElderlyRepository _repository;

        public CreateElderlyHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Elderly> Handle(CreateElderlyCommand request, CancellationToken cancellationToken)
        {
            var elderly = new Elderly
            {
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Address = request.Address
            };

            return await _repository.CreateElderly(elderly);
        }
    }
}
