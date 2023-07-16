using Application.Elderlies.Queries;
using Application.Elderlies.Responses;
using Application.Helpers;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using MediatR;
using System.Linq.Expressions;

namespace Application.Elderlies.Handlers
{
    public class GetAllElderliesHandler : IRequestHandler<GetAllElderliesQuery, PagedList<ElderlyResponse>>
    {
        private readonly IElderlyRepository _repository;

        public GetAllElderliesHandler(IElderlyRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<ElderlyResponse>> Handle(GetAllElderliesQuery request, CancellationToken cancellationToken)
        {
            var elderliesQuery = await _repository.GetAllElderliesQueryable();

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                elderliesQuery = elderliesQuery.Where(e => e.Name.Contains(request.SearchTerm));
            }

            if (request.SortOrder?.ToLower() == Constants.Descending)
            {
                elderliesQuery = elderliesQuery.OrderByDescending(GetSortProperty(request.SortColumn));
            }
            else
            {
                elderliesQuery = elderliesQuery.OrderBy(GetSortProperty(request.SortColumn));
            }

            var elderliesResponseQuery = elderliesQuery.Select(e => new ElderlyResponse
            {
                Id = e.Id.Value,
                Name = e.Name,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender
            });

            var elderliesPagedList = await PagedList<ElderlyResponse>.CreateAsync(elderliesResponseQuery, request.Page, request.PageSize);
            return elderliesPagedList;
        }

        private static Expression<Func<Elderly, object>> GetSortProperty(string? sortColumn) =>
            sortColumn?.ToLower() switch
            {
                Constants.PropertyName => e => e.Name,
                Constants.PropertyDateOfBirth => e => e.DateOfBirth,
                _ => e => e.Id
            };
    }
}