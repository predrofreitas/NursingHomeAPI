namespace Domain.Entities
{
    public class Elderly : Entity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public ICollection<ElderlyMedication> ElderlyMedications { get; set; }
    }
}