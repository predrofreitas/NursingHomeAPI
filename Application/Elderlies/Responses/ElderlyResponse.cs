using Application.Medicines.DTOs;

namespace Application.Elderlies.Responses
{
    public class ElderlyResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<MedicationDTO> PersonalMedications { get; set; }
    }
}
