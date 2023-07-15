﻿using Data.Helpers;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class ElderlyRepository : IElderlyRepository
    {
        private readonly AppDbContext _dbContext;

        public ElderlyRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Elderly>> GetAllElderlies(int page, int pageSize, string? searchTerm, string? sortColumn, string? sortOrder)
        {
            IQueryable<Elderly> elderliesQuery = _dbContext.Elderlies;
            
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                elderliesQuery = elderliesQuery.Where(e => e.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == DataConstants.Descending)
            {
                elderliesQuery = elderliesQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else{
                elderliesQuery = elderliesQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var elderlies = await elderliesQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return elderlies;
        }
            
        public async Task<Elderly> GetElderlyById(int id)
        {
            return await _dbContext.Elderlies.FindAsync(id);
        }

        public async Task<Elderly> CreateElderly(Elderly elderly)
        {
            _dbContext.Elderlies.Add(elderly);
            await _dbContext.SaveChangesAsync();
            return elderly;
        }

        public async Task<bool> UpdateElderly(Elderly elderly)
        {
            _dbContext.Entry(elderly).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteElderly(int id)
        {
            var elderly = await _dbContext.Elderlies.FindAsync(id);

            if (elderly is null)
            {
                return false;
            }

            _dbContext.Elderlies.Remove(elderly);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        private static Expression<Func<Elderly, object>> GetSortProperty(string? sortColumn) =>
            sortColumn?.ToLower() switch
            {
                DataConstants.PropertyName => e => e.Name,
                DataConstants.PropertyDateOfBirth => e => e.DateOfBirth,
                _ => e => e.Id
            };
    }
}
