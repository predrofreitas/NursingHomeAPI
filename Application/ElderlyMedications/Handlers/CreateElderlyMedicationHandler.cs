using Application.ElderlyMedications.Responses;
using Application.Medicines.Commands;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

public class CreateElderlyMedicationHandler : IRequestHandler<CreateElderlyMedicationCommand, ElderlyMedicationResponse>
{
    private readonly IElderlyMedicationRepository _elderlyMedicationRepository;
    private readonly IElderlyRepository _elderlyRepository;

    public CreateElderlyMedicationHandler(IElderlyMedicationRepository elderlyMedicationRepository, IElderlyRepository elderlyRepository)
    {
        _elderlyMedicationRepository = elderlyMedicationRepository;
        _elderlyRepository = elderlyRepository;
    }

    public async Task<ElderlyMedicationResponse> Handle(CreateElderlyMedicationCommand request, CancellationToken cancellationToken)
    {
        if (await _elderlyRepository.GetElderlyById(request.ElderlyId) is null)
        {
            return null;
        }

        var elderlyMedication = new ElderlyMedication
        {
            ElderlyId = request.ElderlyId,
            Name = request.Name,
            Description = request.Description,
            MedicationRoute = request.MedicationRoute,
            Manufacturer = request.Manufacturer
        };

        var createdMedication = await _elderlyMedicationRepository.CreateMedication(elderlyMedication);

        return createdMedication;
    }
}