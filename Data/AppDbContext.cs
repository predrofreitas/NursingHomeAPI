using Data.Configurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Elderly> Elderlies { get; set; }
        public DbSet<ElderlyMedication> ElderlyMedications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ElderlyConfiguration());
            modelBuilder.ApplyConfiguration(new ElderlyMedicationConfiguration());
        }
    }
}