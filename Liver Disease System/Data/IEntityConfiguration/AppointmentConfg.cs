namespace Liver_Disease_System.Data.IEntityConfiguration
{
    public class AppointmentConfg:IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property(p => p.Notes)
                .HasMaxLength(500);
            builder.HasData(
                new Appointment { Id = 1, AppointmentDate = new DateTime(2025, 8, 25), Notes = "Follow-up visit", PatientId = 1, DoctorId = 1 },
                new Appointment { Id = 2, AppointmentDate = new DateTime(2025, 8, 27), Notes = "Blood test", PatientId = 2, DoctorId = 2 },
                new Appointment { Id = 3, AppointmentDate = new DateTime(2025, 8, 29), Notes = "Ultrasound check", PatientId = 3, DoctorId = 4 },
                new Appointment { Id = 4, AppointmentDate = new DateTime(2025, 9, 1), Notes = "Medication adjustment", PatientId = 4, DoctorId = 1 },
                new Appointment { Id = 5, AppointmentDate = new DateTime(2025, 9, 4), Notes = "Chemotherapy session", PatientId = 5, DoctorId = 3 }
);

        }
    }
}
