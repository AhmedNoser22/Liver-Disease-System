
namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class DoctorConfg : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.Property(d => d.Name)
                .HasMaxLength(30);
            builder.Property(d => d.Specialization)
                .HasMaxLength(50);
            builder.HasData
                (
                new Doctor { Id = 1, Name = "Dr. Ahmed Nasser", Specialization = "Hepatology" },
                new Doctor { Id = 2, Name = "Dr. Mona Hassan", Specialization = "Gastroenterology" },
                new Doctor { Id = 3, Name = "Dr. Youssef Ali", Specialization = "Infectious Diseases" },
                new Doctor { Id = 4, Name = "Dr. Salma Ibrahim", Specialization = "Radiology" },
                new Doctor { Id = 5, Name = "Dr. Hany Kamal", Specialization = "Transplant Surgery" },
                new Doctor { Id = 6, Name = "Dr. Sara Adel", Specialization = "Pathology" }
                );


        }
    }
}
