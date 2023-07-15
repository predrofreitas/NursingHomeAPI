using Application.Elderlies.Commands;
using Application.Elderlies.Responses;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Elderlies.Handlers
{
    public class CreateElderlyHandler : IRequestHandler<CreateElderlyCommand, ElderlyResponse>
    {
        private readonly IElderlyRepository _repository;

        public CreateElderlyHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<ElderlyResponse> Handle(CreateElderlyCommand request, CancellationToken cancellationToken)
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