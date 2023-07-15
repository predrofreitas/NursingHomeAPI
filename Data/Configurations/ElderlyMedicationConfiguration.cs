using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ElderlyMedicationConfiguration : IEntityTypeConfiguration<ElderlyMedication>
    {
        public void Configure(EntityTypeBuilder<ElderlyMedication> builder)
        {
            builder.ToTable("ElderlyMedications");

            builder.HasKey(em => em.Id);

            builder.Property(em => em.ElderlyId)
                .IsRequired();

            builder.HasOne(em => em.Elderly)
                .WithMany(e => e.ElderlyMedications)
                .HasForeignKey(em => em.ElderlyId);

            builder.Property(em => em.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(em => em.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(em => em.MedicationRoute)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            builder.Property(em => em.Manufacturer)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}