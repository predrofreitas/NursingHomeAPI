using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Commands
{
    public class DeleteElderlyCommand : IRequest<Elderly>
    {
        public int Id { get; }

        public DeleteElderlyCommand(int id)
        {
            Id = id;
        }
    }
}
