namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class PatientConfg : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(p=>p.Name)
                .HasMaxLength(30);
            builder.Property(p => p.Address)
                .HasMaxLength(50);
            builder.Property(p => p.NationalId)
                .HasMaxLength(14);
            builder.Property(p => p.Age)
                .HasMaxLength(3);
            builder.HasData
                (
                new Patient { Id = 1, Name = "Omar Ali", Age = 45, NationalId = "12345678901234", Address = "Cairo" },
                new Patient { Id = 2, Name = "Sara Mohamed", Age = 32, NationalId = "98765432109876", Address = "Alexandria" },
                new Patient { Id = 3, Name = "Mahmoud Tarek", Age = 50, NationalId = "55555555555555", Address = "Giza" },
                new Patient { Id = 4, Name = "Aya Ibrahim", Age = 27, NationalId = "44444444444444", Address = "Mansoura" },
                new Patient { Id = 5, Name = "Hassan Gamal", Age = 60, NationalId = "33333333333333", Address = "Tanta" }
                );
        }
    }
}
