using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Commands
{
    public class CreateElderlyCommand : IRequest<Elderly>
    {
    }
}
