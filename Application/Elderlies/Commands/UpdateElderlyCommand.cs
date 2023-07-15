using MediatR;

namespace Application.Elderlies.Commands
{
    public class UpdateElderlyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}
