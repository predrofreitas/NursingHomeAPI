using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IElderlyRepository
    {
        Task<List<Elderly>> GetAllElderlies();
        Task<Elderly> GetElderlyById(int id);
        Task<Elderly> CreateElderly(Elderly elderly);
        Task<bool> UpdateElderly(Elderly elderly);
        Task<bool> DeleteElderly(int id);
    }
}
