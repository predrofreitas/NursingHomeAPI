using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PersonalMedicationRepository : IPersonalMedicationRepository
    {
        private readonly AppDbContext _dbContext;

        public PersonalMedicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PersonalMedication>> GetAllMedications()
        {
            return await _dbContext.PersonalMedications.ToListAsync();
        }

        public async Task<PersonalMedication> GetMedicationById(int id)
        {
            return await _dbContext.PersonalMedications.FindAsync(id);
        }

        public async Task<PersonalMedication> CreateMedication(PersonalMedication medication)
        {
            _dbContext.PersonalMedications.Add(medication);
            await _dbContext.SaveChangesAsync();
            return medication;
        }

        public async Task<bool> UpdateMedication(PersonalMedication medication)
        {
            _dbContext.Entry(medication).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMedication(int id)
        {
            var medication = await _dbContext.PersonalMedications.FindAsync(id);
            if (medication == null)
                return false;

            _dbContext.PersonalMedications.Remove(medication);
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
