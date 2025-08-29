namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class PatientMedicineConfg : IEntityTypeConfiguration<PatientMedicine>
    {
        public void Configure(EntityTypeBuilder<PatientMedicine> builder)
        {
            builder.HasKey(pm => new { pm.PatientId, pm.MedicineId });
            builder.HasOne(pm => pm.Patient)
                   .WithMany(p => p.patientMedicines)
                   .HasForeignKey(pm => pm.PatientId);
            builder.HasOne(pm => pm.Medicine)
                     .WithMany(m => m.PatientMedicines)
                     .HasForeignKey(pm => pm.MedicineId);
            builder.Property(pm => pm.Duration)
                     .IsRequired()
                     .HasMaxLength(50);
            builder.HasData
                (
                new { PatientId = 1, MedicineId = 1, Duration = "3 Months" },
                new { PatientId = 2, MedicineId = 2, Duration = "6 Months" },
                new { PatientId = 3, MedicineId = 3, Duration = "12 Months" },
                new { PatientId = 4, MedicineId = 4, Duration = "1 Month" },
                new { PatientId = 5, MedicineId = 5, Duration = "Indefinite" }
                );
        }
    }
}
