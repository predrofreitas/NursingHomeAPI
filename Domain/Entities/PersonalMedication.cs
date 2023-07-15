namespace Domain.Entities
{
    public class PersonalMedication : Entity
    {
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public int ElderlyId { get; set; }
        public Elderly Elderly { get; set; }
    }
}
