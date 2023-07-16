using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Elderlies.Commands
{
    public class UpdateElderlyCommand : IRequest<bool>
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
    }
}
