using Application.Elderlies.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Elderlies.Commands
{
    public class CreateElderlyCommand : IRequest<ElderlyResponse>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
    }
}