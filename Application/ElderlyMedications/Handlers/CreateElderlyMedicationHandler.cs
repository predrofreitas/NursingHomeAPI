using Application.ElderlyMedications.Responses;
using Application.Medicines.Commands;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;

public class CreateElderlyMedicationHandler : IRequestHandler<CreateElderlyMedicationCommand, ElderlyMedicationResponse>
{
    private readonly IElderlyMedicationRepository _repository;

    public CreateElderlyMedicationHandler(IElderlyMedicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ElderlyMedicationResponse> Handle(CreateElderlyMedicationCommand request, CancellationToken cancellationToken)
    {
        var elderlyMedication = new ElderlyMedication
        {
            ElderlyId = request.ElderlyId,
            Name = request.Name,
            Description = request.Description,
            MedicationRoute = request.MedicationRoute,
            Manufacturer = request.Manufacturer
        };

        var createdMedication = await _repository.CreateMedication(elderlyMedication);

        return createdMedication;
    }
}