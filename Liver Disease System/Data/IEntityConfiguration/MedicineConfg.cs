namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class MedicineConfg : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.Property(m => m.Name)
                .HasMaxLength(50);
            builder.Property(p=>p.Dosage)
                .HasMaxLength(100);
            builder.HasData
                (
                new Medicine { Id = 1, Name = "Silymarin", Dosage = "140 mg, 3 times/day" },
                new Medicine { Id = 2, Name = "Tenofovir", Dosage = "300 mg, once daily" }, 
                new Medicine { Id = 3, Name = "Sofosbuvir", Dosage = "400 mg, once daily" },
                new Medicine { Id = 4, Name = "Paracetamol", Dosage = "500 mg, every 6-8 hours if needed" }, 
                new Medicine { Id = 5, Name = "Vitamin D3", Dosage = "1000 IU, once daily" } 
                );


        }
    }
}
