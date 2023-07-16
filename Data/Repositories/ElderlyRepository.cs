using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ElderlyRepository : IElderlyRepository
    {
        private readonly AppDbContext _dbContext;

        public ElderlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<Elderly>> GetAllElderliesQueryable()
        {
            IQueryable<Elderly> elderliesQuery = _dbContext.Elderlies;
            
            return elderliesQuery;
        }

        public async Task<Elderly> GetElderlyById(int id)
        {
            return await _dbContext.Elderlies.FindAsync(id);
        }

        public async Task<Elderly> CreateElderly(Elderly elderly)
        {
            _dbContext.Elderlies.Add(elderly);
            await _dbContext.SaveChangesAsync();
            return elderly;
        }

        public async Task<bool> UpdateElderly(Elderly elderly)
        {
            _dbContext.Entry(elderly).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteElderly(int id)
        {
            var elderly = await _dbContext.Elderlies.FindAsync(id);

            if (elderly is null)
            {
                return false;
            }

            _dbContext.Elderlies.Remove(elderly);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
