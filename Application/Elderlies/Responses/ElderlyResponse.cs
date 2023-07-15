using Domain.Entities;

namespace Application.Elderlies.Responses
{
    public class ElderlyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        //Para não fazer conversões no Handler ao retornar a Entidade diretamente do repository
        public static implicit operator ElderlyResponse(Elderly elderly)
        {
            if (elderly is null)
            {
                return null;
            }

            return new ElderlyResponse
            {
                Id = elderly.Id.Value,
                Name = elderly.Name,
                DateOfBirth = elderly.DateOfBirth,
                Gender = elderly.Gender,
            };
        }
    }
}