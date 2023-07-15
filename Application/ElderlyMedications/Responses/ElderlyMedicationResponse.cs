using Domain.Entities;
using Domain.Enums;

namespace Application.ElderlyMedications.Responses
{
    public class ElderlyMedicationResponse
    {
        public int Id { get; set; }
        public string ElderlyName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MedicationRouteEnum MedicationRoute { get; set; }
        public string Manufacturer { get; set; }

        //Para não fazer conversões no Handler ao retornar a Entidade diretamente do repository
        public static implicit operator ElderlyMedicationResponse(ElderlyMedication elderlyMedication)
        {
            if (elderlyMedication is null)
            {
                return null;
            }

            return new ElderlyMedicationResponse
            {
                Id = elderlyMedication.Id.Value,
                ElderlyName = elderlyMedication.Elderly.Name,
                Name = elderlyMedication.Name,
                Description = elderlyMedication.Description,
                MedicationRoute = elderlyMedication.MedicationRoute,
                Manufacturer = elderlyMedication.Manufacturer
            };
        }
    }
}