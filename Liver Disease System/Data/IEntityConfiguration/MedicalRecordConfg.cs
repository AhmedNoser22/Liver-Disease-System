namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class MedicalRecordConfg : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.Property(p=>p.Diagnosis)
                .HasMaxLength(100);
            builder.Property(p=>p.LiverStage)
                .HasMaxLength(50);
        }
    }
}
