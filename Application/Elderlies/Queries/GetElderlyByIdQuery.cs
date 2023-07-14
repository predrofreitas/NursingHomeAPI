using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Queries
{
    public class GetElderlyByIdQuery : IRequest<Elderly>
    {
        public int Id { get; }

        public GetElderlyByIdQuery(int id)
        {
            Id = id;
        }
    }
}
