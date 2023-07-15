using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IElderlyMedicationRepository
    {
        Task<List<ElderlyMedication>> GetAllMedications();
        Task<ElderlyMedication> GetMedicationById(int id);
        Task<ElderlyMedication> CreateMedication(ElderlyMedication medication);
        Task<bool> UpdateMedication(ElderlyMedication medication);
        Task<bool> DeleteMedication(int id);
    }
}
