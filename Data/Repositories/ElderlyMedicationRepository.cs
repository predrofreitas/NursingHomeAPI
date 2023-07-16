using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class ElderlyMedicationRepository : IElderlyMedicationRepository
    {
        private readonly AppDbContext _dbContext;

        public ElderlyMedicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<ElderlyMedication>> GetAllMedicationsQueryable()
        {
            IQueryable<ElderlyMedication> medicationsQuery = _dbContext.ElderlyMedications;

            return medicationsQuery;
        }

        public async Task<ElderlyMedication> GetMedicationById(int id)
        {
            return await _dbContext.ElderlyMedications
                .Include(em => em.Elderly)
                .FirstOrDefaultAsync(em => em.Id == id);
        }

        public async Task<ElderlyMedication> CreateMedication(ElderlyMedication medication)
        {
            _dbContext.ElderlyMedications.Add(medication);

            await _dbContext.SaveChangesAsync();
            await _dbContext.Entry(medication).Reference(m => m.Elderly).LoadAsync();

            return medication;
        }

        public async Task<bool> UpdateMedication(ElderlyMedication medication)
        {
            _dbContext.Entry(medication).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMedication(int id)
        {
            var medication = await _dbContext.ElderlyMedications.FindAsync(id);

            if (medication is null)
            {
                return false;
            }

            _dbContext.ElderlyMedications.Remove(medication);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}