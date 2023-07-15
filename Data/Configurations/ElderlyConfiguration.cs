using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ElderlyConfiguration : IEntityTypeConfiguration<Elderly>
    {
        public void Configure(EntityTypeBuilder<Elderly> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.DateOfBirth)
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(e => e.Address)
                .HasMaxLength(200)
                .IsRequired();

            builder.HasMany(e => e.Medications)
                .WithOne(m => m.Elderly)
                .HasForeignKey(m => m.ElderlyId);
        }
    }
}