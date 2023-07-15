using Domain.Enums;

namespace Domain.Entities
{
    public class ElderlyMedication : Entity
    {
        public int ElderlyId { get; set; }
        public Elderly Elderly { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MedicationRouteEnum MedicationRoute { get; set; }
        public string Manufacturer { get; set; }
    }
}