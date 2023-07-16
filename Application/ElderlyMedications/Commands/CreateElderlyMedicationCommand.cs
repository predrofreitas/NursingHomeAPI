using Application.ElderlyMedications.Responses;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Medicines.Commands
{
    public class CreateElderlyMedicationCommand : IRequest<ElderlyMedicationResponse>
    {
        [Range(1, int.MaxValue)]
        public int ElderlyId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public MedicationRouteEnum MedicationRoute { get; set; }
        [MaxLength(100)]
        public string Manufacturer { get; set; }
    }
}