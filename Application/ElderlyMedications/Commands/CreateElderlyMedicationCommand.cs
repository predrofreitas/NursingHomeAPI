using Application.ElderlyMedications.Responses;
using Domain.Enums;
using MediatR;

namespace Application.Medicines.Commands
{
    public class CreateElderlyMedicationCommand : IRequest<ElderlyMedicationResponse>
    {
        public int ElderlyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MedicationRouteEnum MedicationRoute { get; set; }
        public string Manufacturer { get; set; }
    }
}