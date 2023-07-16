using Application.Elderlies.Responses;
using MediatR;

namespace Application.Elderlies.Commands
{
    public class CreateElderlyCommand : IRequest<ElderlyResponse>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    }
}