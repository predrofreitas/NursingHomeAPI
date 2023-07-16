using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Application.Elderlies.Commands
{
    public class UpdateElderlyCommand : IRequest<bool>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        public string Gender { get; set; }
    }
}
