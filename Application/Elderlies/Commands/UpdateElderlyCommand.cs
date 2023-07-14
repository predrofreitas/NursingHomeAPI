using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Commands
{
    public class UpdateElderlyCommand : IRequest<Elderly>
    {
        public int Id { get; set; }
    }
}
