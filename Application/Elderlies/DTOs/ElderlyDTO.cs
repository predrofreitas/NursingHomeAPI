using Application.Medicines.DTOs;

namespace Application.Elderlies.DTOs
{
    public class ElderlyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public List<PersonalMedicationDTO> PersonalMedications { get; set; }
    }
}
