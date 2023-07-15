using MediatR;

namespace Application.Elderlies.Commands
{
    public class DeleteElderlyCommand : IRequest<bool>
    {
        public int Id { get; }

        public DeleteElderlyCommand(int id)
        {
            Id = id;
        }
    }
}