using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription);
            builder.Property(e => e.IdPrescription).ValueGeneratedOnAdd();
            builder.Property(e => e.IdPrescription).IsRequired();

            builder.Property(e => e.Date)
                   .IsRequired();

            builder.Property(e => e.DueDate)
                   .IsRequired();

            builder.HasMany(e => e.PrescriptionMedicaments)
                   .WithOne(e => e.Prescription)
                   .HasForeignKey(e => e.IdPrescription)
                   .IsRequired();

            builder.HasOne(e => e.Doctor)
                   .WithMany(e => e.Prescriptions)
                   .HasForeignKey(e => e.IdDoctor);

            builder.HasOne(e => e.Patient)
                   .WithMany(e => e.Prescriptions)
                   .HasForeignKey(e => e.IdPatient);
        }
    }
}
