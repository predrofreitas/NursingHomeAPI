using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IPersonalMedicationRepository
    {
        Task<List<PersonalMedication>> GetAllMedications();
        Task<PersonalMedication> GetMedicationById(int id);
        Task<PersonalMedication> CreateMedication(PersonalMedication medication);
        Task<bool> UpdateMedication(PersonalMedication medication);
        Task<bool> DeleteMedication(int id);
    }
}
