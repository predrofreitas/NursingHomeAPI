using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class PersonalMedicationConfiguration : IEntityTypeConfiguration<PersonalMedication>
    {
        public void Configure(EntityTypeBuilder<PersonalMedication> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.MedicationName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Dosage)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.Frequency)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(p => p.Elderly)
                .WithMany(e => e.Medications)
                .HasForeignKey(p => p.ElderlyId);
        }
    }
}
