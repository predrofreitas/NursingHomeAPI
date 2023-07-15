using Application.Elderlies.Responses;
using MediatR;

namespace Application.Elderlies.Queries
{
    public class GetElderlyByIdQuery : IRequest<ElderlyResponse>
    {
        public int Id { get; }

        public GetElderlyByIdQuery(int id)
        {
            Id = id;
        }
    }
}