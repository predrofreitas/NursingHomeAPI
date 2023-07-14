using Domain.Entities;
using MediatR;

namespace Application.Elderlies.Queries
{
    public class GetAllElderliesQuery : IRequest<List<Elderly>>
    {
    }
}
