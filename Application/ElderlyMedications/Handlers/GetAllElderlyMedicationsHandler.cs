using Application.ElderlyMedications.Responses;
using Application.Helpers;
using Application.Medicines.Queries;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Application.ElderlyMedications.Handlers
{
    public class GetAllElderlyMedicationsHandler : IRequestHandler<GetAllElderlyMedicationsQuery, PagedList<ElderlyMedicationResponse>>
    {
        private readonly IElderlyMedicationRepository _repository;

        public GetAllElderlyMedicationsHandler(IElderlyMedicationRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<ElderlyMedicationResponse>> Handle(GetAllElderlyMedicationsQuery request, CancellationToken cancellationToken)
        {
            var medicationsQuery = await _repository.GetAllMedicationsQueryable();
            var searchTerm = request.SearchTerm;
            var sortOrder = request.SortOrder;
            var sortColumn = request.SortColumn;
            var page = request.Page;
            var pageSize = request.PageSize;

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                medicationsQuery = medicationsQuery.Where(e => e.Name.Contains(searchTerm)
                    || e.Description.Contains(searchTerm)
                    || e.Manufacturer.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == Constants.Descending)
            {
                medicationsQuery = medicationsQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                medicationsQuery = medicationsQuery.OrderBy(GetSortProperty(sortColumn));
            }

            medicationsQuery.Include(m => m.Elderly);

            var medicationsResponseQuery = medicationsQuery.Select(m => new ElderlyMedicationResponse
            {
                Id = m.Id.Value,
                Name = m.Name,
                Description = m.Description,
                ElderlyName = m.Elderly.Name,
                Manufacturer = m.Manufacturer,
                MedicationRoute = m.MedicationRoute
            });

            var elderliesPagedList = await PagedList<ElderlyMedicationResponse>.CreateAsync(medicationsResponseQuery, page, pageSize);

            return elderliesPagedList;
        }

        private static Expression<Func<ElderlyMedication, object>> GetSortProperty(string? sortColumn) =>
            sortColumn?.ToLower() switch
            {
                Constants.PropertyName => e => e.Name,
                Constants.PropertyDescription => e => e.Description,
                Constants.PropertyManufacturer => e => e.Manufacturer,
                _ => e => e.Id
            };
    }
}