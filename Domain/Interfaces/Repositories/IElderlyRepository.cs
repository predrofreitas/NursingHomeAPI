using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IElderlyRepository
    {
        Task<IQueryable<Elderly>> GetAllElderliesQueryable();
        Task<Elderly> GetElderlyById(int id);
        Task<Elderly> CreateElderly(Elderly elderly);
        Task<bool> UpdateElderly(Elderly elderly);
        Task<bool> DeleteElderly(int id);
    }
}
